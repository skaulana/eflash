using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace eFlash.Profile
{
    class ProfileManager
    {
        private static int uid = -1;
        private static string userName = "";
        private static int nuid = -1;

        public static void setCurrentUser(int id, string name)
        {
            uid = id;
            userName = name;
            nuid = dbAccess.selectLocalDB.getNetID(uid);

            if (nuid == 0)
                nuid = -1;
        }

        public static int getCurrentUserID()
        {
            return uid;
        }

        /**
         * 
         * Patrick added stub for network, should query local DB 
         */
        public static int getCurrentNetID()
        {
            return nuid;
        }

        public static string getCurrentUserName()
        {
            return userName;
        }

        public static List<string> getUsers()
        {
            List<string> users;

            try
            {
                users = eFlash.dbAccess.selectLocalDB.getProfileList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has occurred: " + ex.Message,
                       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                users = new List<string>();
            }

            return users;
        }

        public static void generateNewNUID()
        {
            //insert new user into network table
            nuid = dbAccess.remoteDB.insertNewUser(userName);
            //update local user table
            dbAccess.updateLocalDB.updateUserNUID(uid, nuid);
        }
    }
}
