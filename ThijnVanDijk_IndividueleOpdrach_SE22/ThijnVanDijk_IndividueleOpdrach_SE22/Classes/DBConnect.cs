using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;

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
                string query1 = "SELECT COUNT(USERNAME) AS A FROM PERSON WHERE USERNAME = :UserName AND PASSWORD = :Password";

                OracleCommand getID = new OracleCommand(query1, this.conn);
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
                this.conn.Close();
            }
            #endregion
            if (returnValue != "0")
            {
                #region ChannelCheck
                #region userID
                int personID = 0;
                try
                {
                    string query1 = "SELECT PERSONID AS A FROM PERSON WHERE USERNAME = '" + userName + "'";
                    OracleCommand getID = new OracleCommand(query1, this.conn);
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
                    this.conn.Close();
                }
                #endregion

                #region GetChannelName
                try
                {
                    string query1 = "SELECT CHANNELNAME AS A FROM CHANNEL2 WHERE PERSONID = " + personID;
                    OracleCommand getID = new OracleCommand(query1, this.conn);
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
                    this.conn.Close();
                }
                #endregion

                #endregion
            }
            return returnValue;
        }

        public void CreateAccount(string userName, string password)
        {
            int highestID = 0;
            #region MaxID

            try
            {
                string query1 = "SELECT MAX(PERSONID) FROM PERSON";
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
                reader.Read();
                highestID = reader.GetInt32(0);
            }
            catch
            {                
            }
            finally
            {
                this.conn.Close();
            }
            #endregion

            try
            {
                string query1 = "INSERT INTO PERSON(PERSONID, USERNAME, PASSWORD) VALUES ("+
                    (highestID + 1).ToString() + ", :UserName, :Password)";

                OracleCommand newAccount = new OracleCommand(query1, this.conn);
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
                this.conn.Close();
            }
        }

        public void UpgradeAccount(string userName, string channelName, bool adds, string desc)
        {
            string addis = "N";
            if (adds == true)
            {
                addis = "Y";
            }

            int userID = 0;
            #region UserID
            try
            {
                string query1 = "SELECT PERSONID FROM PERSON WHERE USERNAME = '" + userName + "'";
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
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
                this.conn.Close();
            }
            #endregion

            int highestID = 0;
            #region GetID
            try
            {
                string query1 = "SELECT MAX(CHANNELID) FROM CHANNEL2";
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
                reader.Read();
                highestID = reader.GetInt32(0);
                highestID += 1;
            }
            catch
            {
            }
            finally
            {
                this.conn.Close();
            }
            #endregion

            try
            {
                string query1 = "INSERT INTO CHANNEL2(CHANNELID, CHANNELNAME, DESCRIPTION, PERSONID, ADVERTISEMENT) VALUES (" +
                highestID + 1 + ",'" + channelName + "','" + desc + "'," + userID + ",'" + addis + "')";
                OracleCommand upgradeChannel = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = upgradeChannel.ExecuteReader();
            }
            catch
            {
            }
            finally
            {
                this.conn.Close();
            }
        }

        public Channel GetChannel(string channelName)
        {
            Channel returnchannel = null;
            int channelID = 0;
            #region GetChannel
            try
            {
                string query1 = "SELECT CHANNELID, CHANNELNAME, DESCRIPTION, ADVERTISEMENT FROM CHANNEL2 WHERE CHANNELNAME = '" + channelName + "'";
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
                while (reader.Read())
                {
                    channelID = Convert.ToInt32(reader["CHANNELID"]);
                    string name = reader["CHANNELNAME"].ToString();
                    string discription = reader["DESCRIPTION"].ToString();
                    string tempAdd = reader["ADVERTISEMENT"].ToString();
                    bool adds = false;
                    if (tempAdd.ToUpper() == "YES")
                    {
                        adds = true;
                    }
                    returnchannel = new Channel(channelID, name, discription, adds);
                }
            }
            catch
            {
            }
            finally
            {
                this.conn.Close();
            }
            #endregion
            #region GetSubs
            try
            {
                string query1 = "SELECT COUNT(PERSONID) AS  FROM SUBSCRIPTION WHERE CHANNELID = " + channelID;
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
                reader.Read();
                int temp = reader.GetInt32(0);
                returnchannel.SetSubscribers(temp);
            }
            catch
            {
            }
            finally
            {
                this.conn.Close();
            }
            #endregion
            return returnchannel;
        }

        public void Subscribe(string channelName, string userName)
        {
            int channelID = 0;
            #region getChannelID
            try
            {
                string query1 = "SELECT CHANNELID FROM CHANNEL2 WHERE CHANNELNAME = '" + channelName + "'";
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
                reader.Read();
                channelID = reader.GetInt32(0);
            }
            catch
            {
                return;
            }
            finally
            {
                this.conn.Close();
            }
            #endregion

            int personID = 0;
            #region getPersonID
            try
            {
                string query1 = "SELECT PERSONID FROM PERSON WHERE USERNAME = '" + userName + "'";
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
                reader.Read();
                personID = reader.GetInt32(0);
            }
            catch
            {
                return;
            }
            finally
            {
                this.conn.Close();
            }
            #endregion

            try
            {
                string query1 = "INSERT INTO SUBSCRIPTION(PERSONID, CHANNELID) VALUES (" +
                personID + "," + channelID + ")";
                OracleCommand upgradeChannel = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = upgradeChannel.ExecuteReader();
            }
            catch
            {
                return;
            }
            finally
            {
                this.conn.Close();
            }
        }

        public DataTable Read()
        {
            DataTable dataTable = new DataTable();
            try
            {
                OracleCommand cmd = new OracleCommand("SELECT A.VIDEONAME AS VIDNAAM, B.CHANNELNAME AS CHANNAME FROM VIDEO2 A INNER JOIN CHANNEL2 B ON A.CHANNELID = B.CHANNELID WHERE A.VIDEOID > (SELECT MAX(VIDEOID)-20 FROM VIDEO2)", this.conn);
                //OracleCommand cmd = new OracleCommand("SELECT * FROM VIDEO2", this.conn);
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

        public Video GetVidByID(int videoID)
        {
            Video returnvideo = null;
            try
            {
                string query1 = "SELECT A.VIDEONAME, A.LENGHT, A.VIEWS, A.LIKES, A.DISLIKES, A.FILEPATH,B.CHANNELNAME FROM VIDEO2 A, CHANNEL2 B WHERE A.CHANNELID = B.CHANNELID AND VIDEOID = "+videoID;
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["VIDEONAME"].ToString();
                    int Lenght = Convert.ToInt32(reader["LENGHT"]);
                    int Views = 0;
                    if (!DBNull.Value.Equals(reader["VIEWS"]))
                        Views = Convert.ToInt32(reader["VIEWS"]);
                    int Likes = 0;
                    if (!DBNull.Value.Equals(reader["LIKES"]))
                        Likes = Convert.ToInt32(reader["LIKES"]);
                    int dislikes = 0;
                    if (!DBNull.Value.Equals(reader["DISLIKES"]))
                        dislikes = Convert.ToInt32(reader["DISLIKES"]);

                    string path = reader["FILEPATH"].ToString();

                    string channel = reader["CHANNELNAME"].ToString();
                    returnvideo = new Video(name, channel, Lenght, path, Likes, dislikes,Views);
                }
            }
            catch(Exception ex)
            {
            }
            finally
            {
                this.conn.Close();
            }

            try
            {
                string query1 = "UPDATE VIDEO2 SET VIEWS = Views + 1 WHERE VIDEOID ="+videoID;
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
                this.conn.Open();
                newAccount.ExecuteNonQuery();
            }
            catch
            {
            }
            finally
            {
                this.conn.Close();
            }

            return returnvideo;
        }

        public bool VideoUpload(Video vid)
        {
            int highestID = 0;
            int ChannelID = 0;
            bool returner = true;
            #region MaxID

            try
            {
                string query1 = "SELECT (MAX(VIDEOID)+1) FROM VIDEO2";
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
                reader.Read();
                highestID = reader.GetInt32(0);
            }
            catch
            {
                highestID = 1;
            }
            finally
            {
                this.conn.Close();
            }
            #endregion

            #region ChannelID

            try
            {
                string query1 = "SELECT CHANNELID FROM CHANNEL2 WHERE CHANNELNAME = '" + vid.ChannelName+"'";
                OracleCommand newAccount = new OracleCommand(query1, this.conn);
                this.conn.Open();
                OracleDataReader reader = newAccount.ExecuteReader();
                reader.Read();
                ChannelID = reader.GetInt32(0);
            }
            catch(Exception e)
            {
                returner = false;
            }
            finally
            {
                this.conn.Close();
            }
            #endregion

            try
            {
                string command = "INSERT INTO VIDEO2(VIDEOID,CHANNELID,VIDEONAME,LENGHT,VIEWS,FILEPATH) VALUES (:vidID , :ChannelID , :VidName, :lenght , :Views,:FILEPATH)";

                OracleCommand cmd = new OracleCommand(command, this.conn);

                cmd.Parameters.Add(new OracleParameter(":vidID", OracleDbType.Int32));
                cmd.Parameters[":vidID"].Value = highestID;

                cmd.Parameters.Add(new OracleParameter(":ChannelID", OracleDbType.Int32));
                cmd.Parameters[":ChannelID"].Value = ChannelID;

                cmd.Parameters.Add(new OracleParameter(":VidName", OracleDbType.Varchar2));
                cmd.Parameters[":VidName"].Value = vid.VideoName;

                cmd.Parameters.Add(new OracleParameter(":lenght", OracleDbType.Int32));
                cmd.Parameters[":lenght"].Value = vid.Lenght;

                cmd.Parameters.Add(new OracleParameter(":Views", OracleDbType.Int32));
                cmd.Parameters[":Views"].Value = 0;

                cmd.Parameters.Add(new OracleParameter(":FILEPATH", OracleDbType.Varchar2));
                cmd.Parameters[":FILEPATH"].Value = vid.FilePath;
                this.conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                returner = false;
            }
            finally
            {
                this.conn.Close();
            }

            return returner;
        }
    }
}