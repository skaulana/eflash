using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;
using eFlash.Data;

namespace eFlash.dbAccess
{
    class selectLocalDB:localDB
    {      

        /**
         *  A function to retrieve all the decks belonging to a user from the deck table in local database
         * Pre: local user id
         * Post: List of corresponding Decks
         */
        public static List<Deck> getDecks(int uid)
        {
            List<Deck> deckList = new List<Deck>();
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {
				SQL = "SELECT did,type,cat,subcat,title,uid,nuid FROM decks WHERE uid = " + Convert.ToString(uid) + " ORDER BY cat, title";

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
					Deck deck = new Deck(myData.GetInt32(myData.GetOrdinal("did")),
										 myData.GetString(myData.GetOrdinal("type")),
										 myData.GetString(myData.GetOrdinal("cat")),
										 myData.GetString(myData.GetOrdinal("subcat")),
										 myData.GetString(myData.GetOrdinal("title")),
										 myData.GetInt32(myData.GetOrdinal("uid")),
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

        /**
         *  A function to retrieve all the decks in the local database, ordered by input specification
         * Pre: order (0 = cat, 1 = alphabetical, 2 = time)
         * Post: List of corresponding Decks
         */
        public static List<Deck> getDecksOrdered(int order)
        {
            List<Deck> deckList = new List<Deck>();
            deckList.Clear();
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {
                //the if statement spliced in by Daniel for main menu selecting all decks
                switch (order)
                {
                    case 0: 
                        SQL = "SELECT did,type,cat,subcat,title,uid,nuid FROM decks ORDER BY cat, title";
                        break;
                    case 1: 
                        SQL = "SELECT did,type,cat,subcat,title,uid,nuid FROM decks ORDER BY title";
                        break;
                    case 2: 
                        SQL = "SELECT did,type,cat,subcat,title,uid,nuid FROM decks ORDER BY cat, title";
                        break;//change this case when timestamp implemented
                    default: 
                        MessageBox.Show("Error: corrupted order input to getDecksOrdered");
                        SQL = "SELECT did,type,cat,subcat,title,uid,nuid FROM decks ORDER BY cat, title";
                        break;
                }

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    Deck deck = new Deck(myData.GetInt32(myData.GetOrdinal("did")),
                                         myData.GetString(myData.GetOrdinal("type")),
                                         myData.GetString(myData.GetOrdinal("cat")),
                                         myData.GetString(myData.GetOrdinal("subcat")),
                                         myData.GetString(myData.GetOrdinal("title")),
                                         myData.GetInt32(myData.GetOrdinal("uid")),
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

        /**
        *  A function to retrieve a remote deck id for the downloaded unranked deck
        * Pre: local user id
        * Post: List of corresponding Decks
        */
        public static int getRemoteDeck(int deckID)
        {
            string SQL;
            int rdid=0;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {

                SQL = "SELECT unranked.rdid FROM unranked WHERE unranked.ldid = " + Convert.ToString(deckID);

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    rdid = myData.GetInt32(myData.GetOrdinal("rdid"));
                }
                myData.Close();
                conn.Close();
                return rdid;
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
        *  A function to retrieve all unranked decks belonging to a user in the local database
        * Pre: local network user id
        * Post: List of corresponding Decks
        */
        public static List<Deck> getUnrankedDecks(int netID)
        {
            List<Deck> deckList = new List<Deck>();
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {

                SQL = "SELECT decks.did, decks.cat, decks.subcat, decks.title FROM unranked, decks WHERE unranked.lnuid = " + Convert.ToString(netID) + " AND unranked.ldid = decks.did  ORDER BY cat, title";
               
                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    Deck deck = new Deck(myData.GetInt32(myData.GetOrdinal("did")),
                                                                myData.GetString(myData.GetOrdinal("cat")),
                                                                myData.GetString(myData.GetOrdinal("subcat")),
                                                                myData.GetString(myData.GetOrdinal("title")));
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

        /**
         *  A function to retrieve all the cards belonging to a deck from the card and cdrelation table in local database
         * Pre: local deck id
         * Post: List of corresponding Cards
         */
        public static List<Card> getCards(int did)
        {
            List<Card> cardList = new List<Card>();
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {
                SQL = "SELECT Cards.cid,tag,uid FROM CDRelations,Cards WHERE CDRelations.did = "
                    + Convert.ToString(did) + " AND CDRelations.cid = Cards.cid";

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    Card card = new Card(myData.GetInt32(myData.GetOrdinal("cid")),
                                                                myData.GetString(myData.GetOrdinal("tag")),
                                                                myData.GetInt32(myData.GetOrdinal("uid")));
                    cardList.Add(card);
                }
                myData.Close();
                conn.Close();
                return cardList;
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
         *  A function to retrieve all the objects belonging to a card from the objects table in local database
         * Pre: local card id
         * Post: List of corresponding objects
         */
        public static List<eObject> getObjects(int cid)
        {
            List<eObject> eObjectList = new List<eObject>();
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {
                SQL = "SELECT cid,side,type,x1,x2,y1,y2,data FROM Objects WHERE cid = " + Convert.ToString(cid);

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    eObject obj = new eObject(myData.GetInt32(myData.GetOrdinal("cid")),
                                              myData.GetInt32(myData.GetOrdinal("side")),
                                              myData.GetString(myData.GetOrdinal("type")),
                                              myData.GetInt32(myData.GetOrdinal("x1")),
                                              myData.GetInt32(myData.GetOrdinal("x2")),
                                              myData.GetInt32(myData.GetOrdinal("y1")),
                                              myData.GetInt32(myData.GetOrdinal("y2")),                                                                     
                                              myData.GetString(myData.GetOrdinal("data"))
                                             );
                    eObjectList.Add(obj);
                }
                myData.Close();
                conn.Close();
                return eObjectList;
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
	     * Retrieve all objects belonging to a card from the object table in the local database
	     * Pre: local card id
	     * Post: List of corresponding viewer objects (no binary data)
	     */
	    public static List<eObject> getViewerObjects(int cid)
        {
            List<eObject> eObjectList = new List<eObject>();
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {
                SQL = "SELECT cid,side,type,x1,x2,y1,y2,data FROM Objects WHERE cid = " + Convert.ToString(cid);

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    eObject obj = new eObject("viewer", myData.GetInt32(myData.GetOrdinal("cid")),
                                                                     myData.GetInt32(myData.GetOrdinal("side")),
                                                                     myData.GetString(myData.GetOrdinal("type")),
                                                                     myData.GetInt32(myData.GetOrdinal("x1")),
                                                                     myData.GetInt32(myData.GetOrdinal("x2")),
                                                                     myData.GetInt32(myData.GetOrdinal("y1")),
                                                                     myData.GetInt32(myData.GetOrdinal("y2")),
                                                                     myData.GetString(myData.GetOrdinal("data"))
                                                                );
                    eObjectList.Add(obj);
                }
                myData.Close();
                conn.Close();
                return eObjectList;
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
         *  A function to retrieve the name of all files belonging to a deck  in local database
         * Pre: local deck id
         * Post: List of corresponding eFile Objects
         */
        public static List<eFile> loadFileName(int did)
        {
            List<eFile> eFileList = new List<eFile>();
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {
                SQL = "SELECT data FROM Objects,CDRelations WHERE CDRelations.did = "  
                    + Convert.ToString(did) + " AND CDRelations.cid = Objects.cid";

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    eFile file = new eFile(myData.GetString(myData.GetOrdinal("data")));
                    eFileList.Add(file);
                }
                myData.Close();
                conn.Close();
                return eFileList;
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
		 * Verifies existence of user name and password in local database
		 * Pre: User Name and User Password
		 * Post: Returns uid if user and password are correct.  Otherwise -1
		 */
		public static int getAuthdUserID(string name, string pw)
		{
			/* THIS IS ACTUAL, STUB BELOW */
			int uid = -1;
			string password = "";
			string SQL;
			MySqlCommand cmd = new MySqlCommand();
			MySqlDataReader myData;

			connect();


			try
			{
				SQL = "SELECT uid, pw FROM Users WHERE name = ?name";

				cmd.Connection = conn;
				cmd.CommandText = SQL;
                cmd.Parameters.Add("?name", name);
				myData = cmd.ExecuteReader();

				while (myData.Read())
				{
					uid = myData.GetInt32(myData.GetOrdinal("uid"));
					password = myData.GetString(myData.GetOrdinal("pw"));
				}
				myData.Close();
				conn.Close();

				if (password == pw || (password == null && pw == ""))
					return uid;
				else
					return -1;
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				conn.Close();
				throw new Exception();
			}

			//return 1;
		}

		/// <summary>
		/// Gets the user name from the database.
		/// </summary>
		/// <param name="uid">User ID</param>
		/// <returns>Corresponding user name</returns>
		public static string getUserName(int uid)
		{
			string name = "";
			string SQL;
			MySqlCommand cmd = new MySqlCommand();
			MySqlDataReader myData;

			connect();

			try
			{
				SQL = "SELECT name FROM Users WHERE uid = " + uid;

				cmd.Connection = conn;
				cmd.CommandText = SQL;

				myData = cmd.ExecuteReader();

				while (myData.Read())
				{
					name = myData.GetString(myData.GetOrdinal("name"));
				}

				myData.Close();
				conn.Close();

				return name;
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				conn.Close();
				throw new Exception();
			}

			//return 1;
		}

        public static List<string> getProfileList()
        {
            List<string> profiles = new List<string>();
            /* THIS IS ACTUAL, STUB BELOW */
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;
                                             
            connect();

       
            try
            {
                SQL = "SELECT name FROM Users";

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    profiles.Add(myData.GetString(myData.GetOrdinal("name")));
                }
                myData.Close();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();
            }
            
            //profiles.Add("Benny");
            //profiles.Add("Clandestine");
            //profiles.Add("Subaru");

            return profiles;
        }


        //For testing purpose only
        public static int test()
        {
            string SQL;
            int count = 0;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

            connect();

            try
            {

                SQL = "SELECT cid FROM Objects";
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                myData = cmd.ExecuteReader();

                while (myData.Read())
                    count++;

                myData.Close();
                conn.Close();
                return count;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                conn.Close();
                throw new Exception();
            }
        }


        public static string getPW(string name)
        {
            string password = "";
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

     
           connect();

           
            try
            {
                SQL = "SELECT pw FROM Users WHERE name = ?name";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?name",name);
                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    password = myData.GetString(myData.GetOrdinal("pw"));
                }
                myData.Close();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();
                                  
            }

            return password;
        }

        public static string getSettings(string name)
        {
            string settings = "";
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

           connect();

   
            try
            {
                SQL = "SELECT login_setting FROM Users WHERE name = ?name";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?name", name);
                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    settings = myData.GetString(myData.GetOrdinal("login_setting"));
                }
                myData.Close();
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                 throw new Exception();
            }

            return settings;
        }

        public static int getOwnerID(int did)
        {
            /* THIS IS ACTUAL, STUB BELOW */
            int uid = -1;

            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;

           
                connect();

           
            try
            {
                SQL = "SELECT uid FROM Decks WHERE did = " + Convert.ToString(did);

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    uid = myData.GetInt32(myData.GetOrdinal("uid"));
                }
                myData.Close();
                conn.Close();

                return uid;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();
            }
        }

        public static int getNetID(int uid)
        {
            int nuid = -1;

            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataReader myData;


            connect();


            try
            {
                SQL = "SELECT nuid FROM Users WHERE uid = " + Convert.ToString(uid);

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                while (myData.Read())
                {
                    nuid = myData.GetInt32(myData.GetOrdinal("nuid"));
                }
                myData.Close();
                conn.Close();
                
                return nuid;
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
