using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using eFlash.Data;


namespace eFlash.dbAccess
{
    public abstract class localDB
    {
        protected static MySqlConnection conn;       

        protected static void connect()
        {
            connect(Constant.localLogin, Constant.localPass);          
        }
        protected static void connect(string uid, string password)
        {
            if (conn != null)
                conn.Close();

            string connStr = String.Format("server={0};user id={1}; password={2}; database={3}; port = {4}; pooling=false",
                         Constant.localAddress,
                            uid,
                            password,                        
                             Constant.localDB, 
                             Constant.localPort
                             );
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error connecting to the server: " + ex.Message);
                throw new Exception();
            }
        }
    }
}