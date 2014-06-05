using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.DataAccess.Client;
using System.Data;
using System.Data.SqlClient;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public class DBConnect
    {
        private OracleConnection conn;
        private string pcn = "dbi292195";
        private string pw = "kd1qoIM98M";

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
                String query1 = "SELECT COUNT(USERNAME) AS A FROM PERSON WHERE USERNAME = :UserName AND PASSWORD = :Password";

                OracleCommand getID = new OracleCommand(query1, conn);
                getID.Parameters.Add(new OracleParameter(":UserName", OracleDbType.Varchar2));
                getID.Parameters[":UserName"].Value = userName;

                getID.Parameters.Add(new OracleParameter(":Password", OracleDbType.Varchar2));
                getID.Parameters[":Password"].Value = password;

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
                    String query1 = "SELECT PERSONID AS A FROM PERSON WHERE USERNAME = '" + userName + "'";
                    OracleCommand getID = new OracleCommand(query1, conn);
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
                    String query1 = "SELECT CHANNELNAME AS A FROM CHANNEL WHERE PERSONID = " + personID;
                    OracleCommand getID = new OracleCommand(query1, conn);
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
                String query1 = "SELECT MAX(PERSONID) FROM PERSON";
                OracleCommand newAccount = new OracleCommand(query1, conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
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
                String query1 = "INSERT INTO PERSON(PERSONID, USERNAME, PASSWORD) VALUES ("+
                    (HighestID + 1).ToString() + ", :UserName, :Password)";

                OracleCommand newAccount = new OracleCommand(query1, conn);
                newAccount.Parameters.Add(new OracleParameter(":UserName", OracleDbType.Varchar2));
                newAccount.Parameters[":UserName"].Value = userName;

                newAccount.Parameters.Add(new OracleParameter(":Password", OracleDbType.Varchar2));
                newAccount.Parameters[":Password"].Value = password;

                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpgradeAccount(string userName, string channelName, bool Adds, string desc)
        {
            string adds = "N";
            if (Adds == true)
            {
                adds = "Y";
            }

            int userID = 0;
            #region UserID
            try
            {
                String query1 = "SELECT PERSONID FROM PERSON WHERE USERNAME = '" + userName + "'";
                OracleCommand newAccount = new OracleCommand(query1, conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
                reader.Read();
                userID = reader.GetInt32(0);
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
                String query1 = "SELECT MAX(CHANNELID) FROM CHANNEL";
                OracleCommand NewAccount = new OracleCommand(query1, conn);
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
                String query1 = "INSERT INTO CHANNEL(CHANNELID, CHANNELNAME, DESCRIPTION, PERSONID, ADVERTISEMENT) VALUES (" +
                HighestID + 1 + ",'" + channelName + "','" + desc + "'," + userID + ",'" + adds + "')";
                OracleCommand upgradeChannel = new OracleCommand(query1, conn);
                this.conn.Open();
                OracleDataReader reader = upgradeChannel.ExecuteReader();
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
        }

        public Channel GetChannel(string ChannelName)
        {
            Channel returnchannel = null;
            int ChannelID = 0;
            #region GetChannel
            try
            {
                String query1 = "SELECT CHANNELID, CHANNELNAME, DESCRIPTION, ADVERTISEMENT FROM CHANNEL WHERE CHANNELNAME = '" + ChannelName + "'";
                OracleCommand NewAccount = new OracleCommand(query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
                while (reader.Read())
                {
                    ChannelID = Convert.ToInt32(reader["CHANNELID"]);
                    string name = reader["CHANNELNAME"].ToString();
                    string discription = reader["DESCRIPTION"].ToString();
                    string tempAdd = reader["ADVERTISEMENT"].ToString();
                    bool adds = false;
                    if (tempAdd.ToUpper() == "YES")
                    {
                        adds = true;
                    }
                    returnchannel = new Channel(ChannelID, name, discription, adds);
                }
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            #endregion
            #region GetSubs
            try
            {
                String query1 = "SELECT COUNT(PERSONID) AS  FROM SUBSCRIPTION WHERE CHANNELID = " + ChannelID;
                OracleCommand NewAccount = new OracleCommand(query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
                reader.Read();
                int temp = reader.GetInt32(0);
                returnchannel.SetSubscribers(temp);
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
            #endregion
            return returnchannel;
        }

        public void Subscribe(string channelName, string userName)
        {
            int ChannelID = 0;
            #region getChannelID
            try
            {
                String query1 = "SELECT CHANNELID FROM CHANNEL WHERE CHANNELNAME = '" + channelName + "'";
                OracleCommand NewAccount = new OracleCommand(query1, conn);
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

            int personID = 0;
            #region getPersonID
            try
            {
                String query1 = "SELECT PERSONID FROM PERSON WHERE USERNAME = '" + userName + "'";
                OracleCommand NewAccount = new OracleCommand(query1, conn);
                this.conn.Open();
                OracleDataReader reader = NewAccount.ExecuteReader();
                reader.Read();
                personID = reader.GetInt32(0);
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
                String query1 = "INSERT INTO SUBSCRIPTION(PERSONID, CHANNELID) VALUES (" +
                personID + "," + ChannelID + ")";
                OracleCommand upgradeChannel = new OracleCommand(query1, conn);
                this.conn.Open();
                OracleDataReader reader = upgradeChannel.ExecuteReader();
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

        public DataTable read()
        {
            DataTable dataTable = new DataTable();
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT CHANNELID from CHANNEL", this.conn);
                this.conn.Open();
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                this.conn.Close();
            }

            return dataTable;
        }
    }
}