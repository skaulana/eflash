using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;
using MySql.Data.MySqlClient;
using eFlash.Data;

namespace eFlash.dbAccess
{
    class deleteLocalDB:localDB
    {

        /**
         *  Note that this POWERFUL method will perform all necessary DB operations for deleting a deck
         * All associated tuples in Decks, CDRelations and Cards table get removed !!!
         * 
         */
        public static void deleteDeck(int did)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "DELETE  Cards, CDRelations FROM  Cards,CDRelations WHERE CDRelations.did = " + Convert.ToString(did) +
                    " AND Cards.cid = CDRelations.cid;" + "DELETE FROM Decks WHERE Decks.did = " + Convert.ToString(did) ;        
            
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

        //deletes entry for a ranked deck in unranked table
        public static void deleteUnRanked(int ldid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "DELETE  FROM  unranked WHERE ldid = " + Convert.ToString(ldid);  
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

        /**
        *  A function to remove entry from Card table ALONE !!!
         * Note that this means WE ASSUME IT IS NOT YET ASSOCIATED WITH ANY DECK
         * Pre:  Card ID
         * Post: Corresponding card entry is removed from only Card Table in local database        
        */
        public static void deleteCard(int cid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "DELETE  FROM  Cards WHERE cid = " + Convert.ToString(cid);                  

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

         /**
        *  A function to remove entry from Object table ALONE !!!         
         * Pre:  Given the superkey of the object
         * Post: Corresponding Object entry is removed from only Object Table in local database        
        */
        public static void deleteObject(int cid, int side, int x1, int x2, int y1, int y2)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();           
            
            connect();

            try
            {
                SQL = "DELETE  FROM  Objects WHERE cid = ?cid AND side = ?side" +
                    " AND x1 = ?x1 AND x2 = ?x2 AND y1 = ?y1 AND y2 = ?y2";
                
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?cid", cid);
                cmd.Parameters.Add("?side", side);
                cmd.Parameters.Add("?x1", x1);
                cmd.Parameters.Add("?x2", x2);
                cmd.Parameters.Add("?y1", y1);
                cmd.Parameters.Add("?y2", y2);
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

		/// <summary>
		/// Deletes all objects associated with the given card ID
		/// </summary>
		/// <param name="cid">ID of card of objects to delete</param>
		public static void deleteObjects(int cid)
		{
			string SQL;
			MySqlCommand cmd = new MySqlCommand();

			connect();

			try
			{
				SQL = "DELETE FROM Objects WHERE cid = ?cid";

				cmd.Connection = conn;
				cmd.CommandText = SQL;
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

        /**
	     *	Delete a Statistics from a user (also cascade delete QuizDeckRelation)
	     */
        public void deleteStatistics(int qid, int uid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "DELETE  FROM  Statistics WHERE qid = ?qid AND uid = ?uid";

                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?qid", qid);
                cmd.Parameters.Add("?uid", uid);
              
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


        public static void deleteUser(int uid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();

            connect();

            try
            {
                SQL = "DELETE  Users FROM  Users WHERE Users.uid = " + Convert.ToString(uid);

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
    }
}
