using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;
using MySql.Data.MySqlClient;
using eFlash.Data;

namespace eFlash.dbAccess
{
    class insertLocalDB:localDB
    {
		public static void insertToObjects(eObject obj)
		{
			insertToObjects(obj.cid, obj.side, obj.type, obj.x1, obj.x2, obj.y1, obj.y2, obj.data);
		}

		public static void insertToObjects(int cid, int side, string type, int x1, int x2, int y1, int y2, string data)
		{
			string[] args = {cid.ToString(), side.ToString(), type, x1.ToString(), x2.ToString(), y1.ToString(), y2.ToString(), data };
			insertToObjects(args);
		}

        /**
         * A function to insert object to Objects table in the local database
         */
        public static void insertToObjects(string[] values)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "INSERT INTO Objects (cid,side,type,x1,x2,y1,y2,data) VALUES (?cid,?side,?type,?x1,?x2,?y1,?y2,?data)";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?cid", values[0]);
                cmd.Parameters.Add("?side", values[1]);
                cmd.Parameters.Add("?type", values[2]);
                cmd.Parameters.Add("?x1", values[3]);
                cmd.Parameters.Add("?x2", values[4]);
                cmd.Parameters.Add("?y1", values[5]);
                cmd.Parameters.Add("?y2", values[6]);
                cmd.Parameters.Add("?data", values[7]);

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

        //inserts entry into unranked table for a unranked deck
        public static void insertToUnranked(int ldid, int rdid, int lnuid, int rnuid )
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "INSERT INTO unranked (ldid,rdid,lnuid,rnuid) VALUES (?ldid,?rdid,?lnuid,?rnuid)";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?ldid", ldid);
                cmd.Parameters.Add("?rdid", rdid);
                cmd.Parameters.Add("?lnuid", lnuid);
                cmd.Parameters.Add("?rnuid", rnuid);
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

		public static int insertToDecks(eFlash.Data.Deck d)
		{
			return insertToDecks(d.category, d.subcategory, d.title, d.type, d.uid, d.netID);
		}

		public static int insertToDecks(string cat, string subcat, string title, string type, int uid, int nuid)
		{
			string[] args = { cat, subcat, title, type, uid.ToString(), nuid.ToString() };
			return insertToDecks(args);
		}

        /**
        * A function to insert entry to Decks table in local database
        * Pre: Array of strings in the order of did, cat, subcat, title, uid, nuid
        * Post: Appropiate entry is created in Decks table in local database
        * Return: current deck id or -1 for error
        */
        public static int insertToDecks(string[] values)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;
            int last_insert_id = -1;

            connect();

            try
            {
                SQL = "INSERT INTO Decks (cat,subcat,title,type,uid,nuid) VALUES (?cat,?subcat,?title,?type,?uid,?nuid)";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?cat", values[0]);
                cmd.Parameters.Add("?subcat", values[1]);
                cmd.Parameters.Add("?title", values[2]);
                cmd.Parameters.Add("?type", values[3]);
                cmd.Parameters.Add("?uid", values[4]);
                cmd.Parameters.Add("?nuid", values[5]);

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

		public static int insertToCards(eFlash.Data.Card c)
		{
			if (c.cardID != -1)
			{
				throw new ArgumentException("Trying to create a new card that already exists");
			}

			c.cardID = insertToCards(c.tag, c.uid);
			return c.cardID;
		}

		public static int insertToCards(string tag, int uid)
		{
			string[] args = {tag, uid.ToString() };
			return insertToCards(args);
		}

        /**
       * A function to insert entry to Cards table in local database
       * Pre: Array of strings in the order of cid, tag, uid
       * Post: Appropriate entry is inserted to Cards table of local database
       * Return: Current card id or -1 for error
       */
        public static int insertToCards(string[] values)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;
            int last_insert_id = -1;

            connect();

            try
            {
                SQL = "INSERT INTO Cards (tag,uid) VALUES (?tag,?uid)";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?tag", values[0]);
                cmd.Parameters.Add("?uid", values[1]);

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

        /**
         * A function to insert entry to CDRelations table in local database
         * Pre:  did, cid
         * Post: Appropriate entry is inserted to CDRelations table in local database
         */
        public static void insertToCDRelations(int did, int cid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "INSERT INTO CDRelations (did,cid) VALUES (?did,?cid)";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?did", did);
                cmd.Parameters.Add("?cid", cid);

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

        public static void insertToUser(string name, string pw)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "INSERT INTO Users (name,pw) VALUES (?name,?pw)";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?name", name);
                cmd.Parameters.Add("?pw", pw);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                conn.Close();

                if(ex.Number == 1062)
                    MessageBox.Show("The profile name: \'" + name + "\' already exists.\nPlease login or choose another name.",
                    "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception();  //this exception thrown to signfiy larger error than duplicate profile name
                }
            }
        }


	    /**
	     *	Insert user into QuizDeckRelations table (qid, did)
	     */
        public static void insertToQDRelations(int qid, int did)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "INSERT INTO QDRelations (qid,did) VALUES (?qid,?did)";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?qid", qid);
                cmd.Parameters.Add("?did", did);

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
         *	Insert user into Statistics table (int uid, string type, int score)
         */
        public static void insertToStatistics(int uid, string type, int score)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "INSERT INTO Statistics (uid, type, score) VALUES (?uid,?type,?score)";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?uid", uid);
                cmd.Parameters.Add("?type", type);
                cmd.Parameters.Add("?score", score);

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

    }
}
