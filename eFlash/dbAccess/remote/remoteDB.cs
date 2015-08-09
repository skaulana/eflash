using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using eFlash.Data;

namespace eFlash.dbAccess
{
    public class remoteDB
    {

        private static MySqlConnection conn;

        private static void connect()
        {
            connect(Constant.serverLogin, Constant.serverPass);
        }

        private static void connect(string uid, string password)
        {
            if (conn != null)
                conn.Close();

            string connStr = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false",
                            Constant.serverAddress,
                            uid,
                            password,
                             Constant.serverDB);

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

        public static List<netDeck> searchDeck(string[] searchStr, string opt)
        {
            string SQL;
            List<netDeck> deckList = new List<netDeck>();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {
                SQL = "SELECT ndid,cat,subcat,title,date,rat,num_v,nuid FROM networkdecks WHERE 0 ";
                switch(opt)
                {
                    case("Category"):                        
                        foreach (string s in searchStr)
                            SQL += " OR LOWER(cat) LIKE " + "'%" + s.ToLower() + "%'";
                        break;
                    case("Title"):
                        foreach (string s in searchStr)
                            SQL += " OR LOWER(title) LIKE " + "'%" + s.ToLower() + "%'";
                        break;
                    case ("Sub-Category"):
                        foreach (string s in searchStr)
                            SQL += " OR LOWER(subcat) LIKE " + "'%" + s.ToLower() + "%'";
                        break;           
                    default:
                        SQL = "SELECT nd.ndid,cat,subcat,title,date,rat,num_v,nd.nuid FROM networkdecks nd, networkusers nu WHERE nu.nuid = nd.nuid AND (0";                    
                        foreach (string s in searchStr)
                            SQL += " OR LOWER(nu.nname) LIKE " + "'%" + s.ToLower() + "%'";
                        SQL += ")";
                        break;
                }

                SQL += " ORDER BY cat, title";
                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    netDeck deck = new netDeck(myData.GetInt32(myData.GetOrdinal("ndid")),
                                                                myData.GetString(myData.GetOrdinal("cat")),
                                                                myData.GetString(myData.GetOrdinal("subcat")),
                                                                myData.GetString(myData.GetOrdinal("title")),
                                                                myData.GetString(myData.GetOrdinal("date")),
                                                                myData.GetFloat(myData.GetOrdinal("rat")),
                                                                myData.GetInt32(myData.GetOrdinal("num_v")),
                                                                myData.GetInt32(myData.GetOrdinal("nuid")));
                    deckList.Add(deck);
                }
                myData.Close();
                conn.Close();
                return deckList;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();

            }     

        }
        //updates a network deck's average rank
        public static void updateDeckRankAve(int ndid, double ave)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            connect();
            try
            {
                SQL = "UPDATE networkdecks SET rat = ?ave WHERE ndid = ?ndid";
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?ave", ave);
                cmd.Parameters.Add("?ndid", ndid);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occured: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();
            }
        }
        //calculates average for a network deck rank
        public static double getRemoteDeckRankAve(int ndid) 
        {
            string SQL;
            double ave = 0;
            int total = 0;
            int count = 0;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;
            
            connect();

            try
            {
                SQL = "SELECT rank FROM networkratings WHERE ndid = " + Convert.ToString(ndid);

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    count++;
                    total += myData.GetInt32(myData.GetOrdinal("rank"));
                }
                ave = 1.0 * total / count;
                myData.Close();
                conn.Close();
                return ave;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                conn.Close();
                throw new Exception();

            }
        }

        //inserts rank into ranks table
        public static void insertRank(int ndid, int nuid, int rank)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "INSERT INTO networkratings VALUES (?ndid, ?nuid, ?rank)";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?ndid", ndid);
                cmd.Parameters.Add("?nuid", nuid);
                cmd.Parameters.Add("?rank", rank);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();

            }     
        }

        //IF nuid == 0, getAllDecks belonging to all users
        public static List<netDeck> getDecks(int nuid)
        {
            string SQL;
            List<netDeck> deckList = new List<netDeck>();            
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;
            
            connect();

            try
            {
                if (nuid == 0)
                    SQL = "SELECT ndid,cat,subcat,title,date,rat,num_v,nuid FROM networkdecks WHERE 1" + " ORDER BY cat, title" ;
                else
                    SQL = "SELECT ndid,cat,subcat,title,date,rat,num_v,nuid FROM networkdecks WHERE nuid = " + Convert.ToString(nuid) + " ORDER BY cat, title";

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {                    
                    netDeck deck = new netDeck(myData.GetInt32(myData.GetOrdinal("ndid")),
                                                                myData.GetString(myData.GetOrdinal("cat")),
                                                                myData.GetString(myData.GetOrdinal("subcat")),
                                                                myData.GetString(myData.GetOrdinal("title")),
                                                                myData.GetString(myData.GetOrdinal("date")),
                                                                myData.GetFloat(myData.GetOrdinal("rat")),
                                                                myData.GetInt32(myData.GetOrdinal("num_v")),
                                                                myData.GetInt32(myData.GetOrdinal("nuid")));
                    deckList.Add(deck);
                }
                myData.Close();
                conn.Close();
                return deckList;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();

            }     

        }

        public static netDeck getSpecificDeck(int ndid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;
            netDeck deck = null;

            connect();

            try
            {
                SQL = "SELECT ndid,cat,subcat,title,date,rat,num_v,nuid FROM networkdecks WHERE ndid = " + Convert.ToString(ndid);

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    deck = new netDeck(myData.GetInt32(myData.GetOrdinal("ndid")),
                                                                myData.GetString(myData.GetOrdinal("cat")),
                                                                myData.GetString(myData.GetOrdinal("subcat")),
                                                                myData.GetString(myData.GetOrdinal("title")),
                                                                myData.GetString(myData.GetOrdinal("date")),
                                                                myData.GetFloat(myData.GetOrdinal("rat")),
                                                                myData.GetInt32(myData.GetOrdinal("num_v")),
                                                                myData.GetInt32(myData.GetOrdinal("nuid")));
                }
                myData.Close();
                conn.Close();
                return deck;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();

            }

        }
      
        //get the network blob object from remoteDB given network deck id
        public static byte[] loadNetDeck(int ndid)
        {
            string SQL;
            int FileSize;
            byte[] rawData = null;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {
                SQL = "SELECT deck,size FROM networkdecks WHERE ndid = " + Convert.ToString(ndid);

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                //BEware of not able to find the deck when owner remove it during the time.
                if (!myData.HasRows)
                    throw new Exception("BLOB not found !!!");

                myData.Read();
                FileSize = myData.GetInt32(myData.GetOrdinal("size"));

                //If FileSize == 0, myData.GetBytes will be unhappy :)
                if (FileSize == 0)
                     throw new Exception("Malformed Network Deck !!!");
                
                rawData = new byte[FileSize];
                myData.GetBytes(myData.GetOrdinal("deck"), 0, rawData, 0, FileSize);

                myData.Close();
                conn.Close();
                return rawData;
               
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();
            }

        }

        //get the network blob object from remoteDB given network deck id
        public static byte[] getPreview(int ndid)
        {
            string SQL;
            int FileSize;
            byte[] rawData = null;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {
                SQL = "SELECT preview,psize FROM networkdecks WHERE ndid = " + Convert.ToString(ndid);

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                //BEware of not able to find the deck when owner remove it during the time.
                if (!myData.HasRows)
                    throw new Exception("BLOB not found !!!");

                myData.Read();
                FileSize = myData.GetInt32(myData.GetOrdinal("psize"));

                //If FileSize == 0, myData.GetBytes will be unhappy :)
                if (FileSize == 0)
                    throw new Exception("Malformed Network Preview !!!");

                rawData = new byte[FileSize];
                myData.GetBytes(myData.GetOrdinal("preview"), 0, rawData, 0, FileSize);

                myData.Close();
                conn.Close();
                return rawData;

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();
            }

        }


        // If userName is NULL, return MAX userID
        public static int getUserID(string userName)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;
            int id = -1;

            connect();
      
                 try
                {
                     if(userName == null)
                        SQL = "SELECT MAX(nuid ) AS id FROM networkusers";
                     else
                        SQL = "SELECT nuid AS id FROM networkusers WHERE nname = ?userName";

                    cmd.Connection = conn;
                    cmd.CommandText = SQL;
                    cmd.Parameters.Add("?userName", userName);
                    myData = cmd.ExecuteReader();

                    if (myData.HasRows)
                    {
                        myData.Read();
                        id = myData.GetInt32(myData.GetOrdinal("id"));
                        myData.Close();                      
                    }

                    myData.Close(); 
                    conn.Close();
                    return id;
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    conn.Close();
                    throw new Exception();
                
                }
  
        }

        public static void saveToDB(byte[] rawData, string[] values, byte[] preview)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "INSERT INTO networkdecks ( ndid , cat , subcat , title , date , rat , num_v , nuid , deck , size, preview, psize) " +
                            " VALUES ('',?cat , ?subcat , ?title ,  CURDATE() , ?rat , ?num_v , ?nuid , ?deck, ?size, ?preview, ?psize)";
                    
                  
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?cat", values[0]);
                cmd.Parameters.Add("?subcat", values[1]);
                cmd.Parameters.Add("?title", values[2]);
                //HOW TO USE CURDATE() ?
               // cmd.Parameters.Add("?date", values[3]);
                
                cmd.Parameters.Add("?rat", values[4]);
                cmd.Parameters.Add("?num_v", values[5]);
                cmd.Parameters.Add("?nuid", values[6]);
                cmd.Parameters.Add("?deck", rawData);
                cmd.Parameters.Add("?size", rawData.Length);
                cmd.Parameters.Add("?preview", preview);
                cmd.Parameters.Add("?psize", preview == null? 0:preview.Length);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();
            }

        }

        /**
         * Given a username, a nuid is return
         * Return: network user id (integer) or -1 to indicate error
         */
        public static int insertNewUser(string name)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;
            int last_insert_id = -1;

            connect();

            try
            {
                SQL = "INSERT INTO networkusers (nname) VALUES (?nname)";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?nname", name);

                cmd.ExecuteNonQuery();

                // Get back the last insert id
                cmd.CommandText = "SELECT LAST_INSERT_ID()";
                cmd.ExecuteNonQuery();
                myData = cmd.ExecuteReader();

                if (myData.Read())
                {
                    last_insert_id = myData.GetInt32(myData.GetOrdinal("last_insert_id()"));
                }
                myData.Close();
                conn.Close();
                return last_insert_id;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                conn.Close();
                throw new Exception();
            }
        }

        public static void deleteDeck(int ndid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "DELETE FROM networkdecks WHERE ndid = " + Convert.ToString(ndid); 

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();
            }

        }


        public static void test()
        {
           
            int id = remoteDB.getUserID("pat");
            MessageBox.Show(Convert.ToString(id));
        }

    }
}