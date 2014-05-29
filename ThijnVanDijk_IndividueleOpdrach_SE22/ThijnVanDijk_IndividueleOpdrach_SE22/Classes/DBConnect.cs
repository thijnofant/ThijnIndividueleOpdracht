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
      
    }
}