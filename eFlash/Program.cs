using System;
using System.Configuration;
using System.Collections.Generic;
using System.Windows.Forms;

using eFlash.GUI;
using eFlash.File;
using eFlash.Utilities;

namespace eFlash
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            /*********** 
             * Debug w/o eFlash MySQL: set localDB = useDB.none; start your own server
             *   Debug w/eFlash MySQL: install eFlash; set localDB = useDB.debug; change path below
             *       Production build: set localDB = useDB.release; build installer
             ***********/
            useMySQL localDB = useMySQL.release;

            if (localDB != useMySQL.none)
            {
                Form loadScreen = new eFlash.GUI.Loading();
                loadScreen.Visible = true;

                string pwd = AppHelper.GetPresentWorkingDirectory();

                if (localDB == useMySQL.debug)
                {
                    // Path to your MySQL bin directory, i.e.:
                    pwd = "C:\\Program Files\\eFlash\\Data\\MySQL\\bin\\";
                }
                else if (localDB == useMySQL.release)
                {
                    pwd = AppHelper.GetPresentWorkingDirectory() + "\\Data\\MySQL\\bin\\";
                }
                MySQLServer.mybin = pwd;
                MySQLServer.StartAndWait();

                loadScreen.Visible = false;
            }

            Application.Run(new eFlash.GUI.Profile.profile_selector());
            //Application.Run(new main());           
            //Application.Run(new eFlash.GUI.File.importScreen());
			//Application.Run(new eFlash.GUI.File.exportScreen());
			//Application.Run(new eFlash.GUI.Network.welcome());
			//Application.Run(new eFlash.GUI.Creator.LayoutEditor(null, null));
            //Application.Run(new eFlash.GUI.Network.browser());
            //eFlash.dbAccess.remoteDB.test();
            
            if (localDB != useMySQL.none)
            {
                MySQLServer.StopAndWait();
            }
        }

        /// <summary>
        /// Specify how the database should be used.
        /// </summary>
        enum useMySQL { none, debug, release }
    }
}
