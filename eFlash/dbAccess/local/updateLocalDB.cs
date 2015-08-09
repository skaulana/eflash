using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Text;
using MySql.Data.MySqlClient;
using eFlash.Data;

namespace eFlash.dbAccess
{
    class updateLocalDB:localDB
    {
        /**
         * A function to update initial profile settings (save pw, auto-log) for current user
         */
        public static void updateLoginSettings(bool savePW, bool autolog)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            connect();

            try
            {
                int uid = eFlash.Profile.ProfileManager.getCurrentUserID();
                SQL = "UPDATE Users SET login_setting = ?login_setting WHERE uid = ?uid";
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                if (savePW)
                {
                    cmd.Parameters.Add("?login_setting", 2);
                }
                else if(autolog)
                {
                    cmd.Parameters.Add("?login_setting", 3);
                }else
                {
                    cmd.Parameters.Add("?login_setting", 1);
                }
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

        /**
         * A function to update the user's name,pw,login_setting, and or nuid defined by uid in local profile
         */
        public static void updateUsers(int uid, string name, string pw, string loginSetting, int nuid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            connect();
            try{
                SQL = "UPDATE Users SET name = ?name, pw = ?pw, login_setting = ?login_setting, nuid = ?nuid WHERE uid = ?uid";
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?name", name);
                cmd.Parameters.Add("?pw",pw);
                cmd.Parameters.Add("?login_setting",loginSetting);
                cmd.Parameters.Add("?nuid",nuid);
                cmd.Parameters.Add("?uid",uid);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(MySql.Data.MySqlClient.MySqlException ex){
                MessageBox.Show("Error " + ex.Number + " has occured: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                throw new Exception();
            }

        }

        /**
         * A function to update the user's nuid
         */
        public static void updateUserNUID(int uid, int nuid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            connect();
            try
            {
                SQL = "UPDATE Users SET nuid = ?nuid WHERE uid = ?uid";
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?nuid", nuid);
                cmd.Parameters.Add("?uid", uid);
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

		public static void updateDeck(eFlash.Data.Deck d)
		{
			updateDecks(d.id, d.type, d.category, d.subcategory, d.title, d.uid, d.netID);
		}

	    /**
	      * update a deck defined by did from a user
	      */
		public static void updateDecks(int did, string type, string cat, string subcat, string title, int uid, int nuid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            connect();
            try
            {
                SQL = "UPDATE decks SET type = ?type, cat = ?cat, subcat = ?subcat, title = ?title, uid = ?uid, nuid = ?nuid WHERE did = ?did";
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?type",type);
                cmd.Parameters.Add("?cat",cat);
                cmd.Parameters.Add("?subcat",subcat);
                cmd.Parameters.Add("?title",title);
                cmd.Parameters.Add("?uid",uid);
                cmd.Parameters.Add("?nuid",nuid);
                cmd.Parameters.Add("?did",did);
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

		public static void updateCards(eFlash.Data.Card card)
		{
			updateCards(card.cardID, card.tag, card.uid);
		}

	    /**
	      * update a card from a user
	      */
		public static void updateCards(int cid, string tag, int uid)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            connect();
            try
            {
                SQL = "UPDATE cards SET tag = ?tag, uid = ?uid WHERE cid = ?cid";
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?tag",tag);
                cmd.Parameters.Add("?uid",uid);
                cmd.Parameters.Add("?cid",cid);
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

	    /**
	      * update an object's type and/or data for a card
          * NOTE: if user is moving the object's location, use delete and insert combination
	      */
		public static void updateObjects(int cid, int side, string type, int x1, int x2, int y1, int y2, string data)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            connect();
            try
            {
                SQL = "UPDATE objects SET type = ?type, data = ?data WHERE cid = ?cid AND side = ?side AND x1 = ?x1 AND x2 = ?x2 AND y1 = ?y1 AND y2 = ?y2;";
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?type",type);
                cmd.Parameters.Add("?data",data);
                cmd.Parameters.Add("?cid",cid);
                cmd.Parameters.Add("?side",side);
                cmd.Parameters.Add("?x1",x1);
                cmd.Parameters.Add("?x2", x2);
                cmd.Parameters.Add("?y1", y1);
                cmd.Parameters.Add("?y2", y2);
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

	    /**
	      * update statistics type and/or score for a certain quiz and user
	      */
		public static void updateStatistics(int qid, int uid, int type, int score)
        {
            string SQL;
            MySqlCommand cmd = new MySqlCommand();
            connect();
            try
            {
                SQL = "UPDATE statistics SET type = ?type, score = ?score WHERE qid = ?qid AND uid = ?uid";
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                cmd.Parameters.Add("?type",type);
                cmd.Parameters.Add("?score",score);
                cmd.Parameters.Add("?qid",qid);
                cmd.Parameters.Add("?uid",uid);
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

    }
}
