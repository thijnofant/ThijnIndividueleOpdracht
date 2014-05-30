using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public class DBConnect
    {
        public OracleConnection conn;
        string pcn = "dbi292195";
        string pw = "kd1qoIM98M";

        public DBConnect()
        {
            this.conn = new OracleConnection();
            this.conn.ConnectionString = "User Id=" + this.pcn + ";Password=" + this.pw + ";Data Source=" + " //192.168.15.50:1521/fhictora" + ";";
        }

        public string LogIn(string userName, string password)
        {
            string returnValue = "0";

            #region LogInCHeck
            try
            {
                String Query1 = "SELECT COUNT(USERNAME) AS A FROM PERSON WHERE USERNAME = '" + userName + "' AND PASSWORD = '" + password + "'";
                OracleCommand getID = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = getID.ExecuteReader();
                reader.Read();
                int temp = reader.GetInt32(0);
                returnValue = Convert.ToString(temp);
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            #endregion
            if (returnValue != "0")
            {
                #region ChannelCheck
                #region userID
                int personID = 0;
                try
                {
                    String Query1 = "SELECT PERSONID AS A FROM PERSON WHERE USERNAME = '" + userName + "'";
                    OracleCommand getID = new OracleCommand(Query1, conn);
                    this.conn.Open();
                    OracleDataReader reader = getID.ExecuteReader();
                    reader.Read();
                    personID = reader.GetInt32(0);
                }
                catch
                {
                }
                finally
                {
                    conn.Close();
                }
                #endregion

                #region GetChannelName
                try
                {
                    String Query1 = "SELECT CHANNELNAME AS A FROM CHANNEL WHERE PERSONID = " + personID;
                    OracleCommand getID = new OracleCommand(Query1, conn);
                    this.conn.Open();
                    OracleDataReader reader = getID.ExecuteReader();
                    reader.Read();
                    string temp = reader.GetString(0);
                    returnValue = temp;
                }
                catch
                {
                }
                finally
                {
                    conn.Close();
                }
                #endregion

                #endregion
            }
            return returnValue;
        }

        public void CreateAccount(string userName, string password)
        {
            int HighestID = 0;
            #region MaxID

            try
            {
                String Query1 = "SELECT MAX(PERSONID) FROM PERSON";
                OracleCommand NewAccount = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
                reader.Read();
                HighestID = reader.GetInt32(0);
            }
            catch
            {                
            }
            finally
            {
                conn.Close();
            }
            #endregion

            try
            {
                String Query1 = "INSERT INTO PERSON(PERSONID, USERNAME, PASSWORD) VALUES ("+
                    (HighestID + 1).ToString() + ",'" +
                userName + "','"+ password +"')";
                OracleCommand NewAccount = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpgradeAccount(string userName, string channelName, bool Adds)
        {
            string adds = "N";
            if (Adds == true)
            {
                adds = "Y";
            }

            int UserID = 0;
            #region UserID
            try
            {
                String Query1 = "SELECT PERSONID FROM PERSON WHERE USERNAME = '" + userName + "'";
                OracleCommand NewAccount = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
                reader.Read();
                UserID = reader.GetInt32(0);
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            #endregion

            int HighestID = 0;
            #region GetID
            try
            {
                String Query1 = "SELECT MAX(CHANNELID) FROM CHANNEL";
                OracleCommand NewAccount = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
                reader.Read();
                HighestID = reader.GetInt32(0);
                HighestID += 1;
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            #endregion

            try
            {
                String Query1 = "INSERT INTO CHANNEL(CHANNELID, CHANNELNAME, PERSONID, ADVERTISEMENT) VALUES (" +
                HighestID + 1 + ",'" + channelName + "'," + UserID + ",'" + adds + "')";
                OracleCommand UpgradeChannel = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = UpgradeChannel.ExecuteReader();
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
        }

        public string GetSubs(string ChannelName)
        {
            string returnstring = "0";
            int ChannelID = 0;
            #region getID
            try
            {
                String Query1 = "SELECT CHANNELID FROM CHANNEL WHERE CHANNELNAME = '"+ ChannelName + "'";
                OracleCommand NewAccount = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
                reader.Read();
                int temp = reader.GetInt32(0);
                ChannelID = temp;
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            #endregion

            try
            {
                String Query1 = "SELECT COUNT(PERSONID) FROM SUBSCRIPTION WHERE CHANNELID = " + ChannelID;
                OracleCommand NewAccount = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
                reader.Read();
                int temp = reader.GetInt32(0);
                returnstring = temp.ToString();
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }

            return returnstring;

        }

        public void Subscribe(string channelName, string userName)
        {
            int ChannelID = 0;
            #region getChannelID
            try
            {
                String Query1 = "SELECT CHANNELID FROM CHANNEL WHERE CHANNELNAME = '" + channelName + "'";
                OracleCommand NewAccount = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
                reader.Read();
                ChannelID = reader.GetInt32(0);
            }
            catch
            {
                return;
            }
            finally
            {
                conn.Close();
            }
            #endregion

            int PersonID = 0;
            #region getPersonID
            try
            {
                String Query1 = "SELECT PERSONID FROM PERSON WHERE USERNAME = '" + userName + "'";
                OracleCommand NewAccount = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
                reader.Read();
                PersonID = reader.GetInt32(0);
            }
            catch
            {
                return;
            }
            finally
            {
                conn.Close();
            }
            #endregion

            try
            {
                String Query1 = "INSERT INTO SUBSCRIPTION(PERSONID, CHANNELID) VALUES (" +
                PersonID + "," + ChannelID + ")";
                OracleCommand UpgradeChannel = new OracleCommand(Query1, conn);
                this.conn.Open();
                OracleDataReader reader = UpgradeChannel.ExecuteReader();
            }
            catch
            {
                return;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}