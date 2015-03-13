using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using System.Configuration;

namespace AplikasiPayrollDAO
{
    public class DBConnection
    {
        private MySqlConnection conn = null;
        private static DBConnection dbConn = null;

        //constructor
        private DBConnection()
        {
            if (conn == null)
            {         
                    //Baca informasi yang ada pada file xml(App.config)
                    string server = ConfigurationSettings.AppSettings["Server"];
                    string database = ConfigurationSettings.AppSettings["Database"];

                    string user = "APPPYRL";
                    string password = "1q2w3e4r";

                    string strConn = "SERVER=" + server + "; DATABASE=" + database + "; UID=" + user + "; PASSWORD=" + password;

                    conn = new MySqlConnection(strConn);
                    conn.Open();                               
            }
        }

        public static DBConnection GetInstance()
        {
            if (dbConn == null)
            {
                dbConn = new DBConnection();
            }

            return dbConn;
        }

        public MySqlConnection GetConnection()
        {
            return this.conn;
        }
    }
}
