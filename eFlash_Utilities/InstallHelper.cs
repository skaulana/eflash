using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Configuration.Install;

namespace eFlash.Utilities
{
    /// <summary>
    /// Class to facilitate installation tasks.
    /// </summary>
    [RunInstaller(true)]
    public class InstallHelper : Installer
    {
        public InstallHelper()
        {
        }

        /// <summary>
        /// Generates the MySQL configuration file.
        /// </summary>
        /// <param name="savedState">Installer state parameter.</param>
        public override void Install(System.Collections.IDictionary savedState)
        {
            base.Install(savedState);

            try
            {
                // Grab the relevant CustomActionData from the installer
                string installPath = Context.Parameters["eflashpath"];
                string myini = installPath + "Data\\MySQL\\my.ini";

                string myport = eFlash.Constant.localPort;
                string mysocket = eFlash.Constant.localSocket;

                // Set up some file IO
                FileStream file = new FileStream(myini, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(file);

                // Write the MySQL configuration file my.ini
                sw.WriteLine("# MySQL Server Instance Configuration File");
                sw.WriteLine("# ----------------------------------------");
                sw.WriteLine("# Configured for eFlash - do NOT edit!" + sw.NewLine);

                sw.WriteLine("[client]" + sw.NewLine);
                sw.WriteLine("port=" + myport);
                //sw.WriteLine("pipe");
                //sw.WriteLine("socket=" + mysocket + sw.NewLine);
                sw.WriteLine("[mysql]" + sw.NewLine);
                sw.WriteLine("default-character-set=utf8" + sw.NewLine);
                sw.WriteLine("[mysqld]" + sw.NewLine);
                sw.WriteLine("port=" + myport);
                //sw.WriteLine("enable-named-pipe");
                //sw.WriteLine("socket=" + mysocket + sw.NewLine);

                // Use forward slashes for the path
                string fsInstallPath = AppHelper.StringReplace("\\", "/", installPath);

                sw.WriteLine("basedir=\"" + fsInstallPath + "Data/MySQL/\"");
                sw.WriteLine("datadir=\"" + fsInstallPath + "Data/MySQL/data/\"" + sw.NewLine);
                sw.WriteLine("default-character-set=utf8");
                sw.WriteLine("default-storage-engine=INNODB");
                sw.WriteLine("sql-mode=\"STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION\"" + sw.NewLine);

                sw.WriteLine("max_connections=100");
                sw.WriteLine("query_cache_size=0");
                sw.WriteLine("table_cache=256");
                sw.WriteLine("tmp_table_size=7M" + sw.NewLine);

                sw.WriteLine("#*** MyISAM Specific options");
                sw.WriteLine("myisam_max_sort_file_size=100G");
                sw.WriteLine("myisam_max_extra_sort_file_size=100G");
                sw.WriteLine("myisam_sort_buffer_size=12M");
                sw.WriteLine("key_buffer_size=8M");
                sw.WriteLine("read_buffer_size=64K");
                sw.WriteLine("read_rnd_buffer_size=256K");
                sw.WriteLine("sort_buffer_size=256K" + sw.NewLine);

                sw.WriteLine("#*** INNODB Specific options ***");
                sw.WriteLine("innodb_additional_mem_pool_size=2M");
                sw.WriteLine("innodb_flush_log_at_trx_commit=1");
                sw.WriteLine("innodb_log_buffer_size=1M");
                sw.WriteLine("innodb_buffer_pool_size=10M");
                sw.WriteLine("innodb_log_file_size=10M");
                sw.WriteLine("innodb_thread_concurrency=8");

                // Finish file IO
                sw.Close(); file.Close();

                MySQLServer.mybin = installPath + "Data\\MySQL\\bin\\";

                // Start the MySQL server (and client)
                Process p = MySQLServer.StartAndConnect();
                sw = p.StandardInput;

                // Create the default schema
                file = new FileStream(installPath + "Data\\MySQL\\scripts\\install.sql", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);
                
                while (!sr.EndOfStream) sw.WriteLine(sr.ReadLine());
                sw.WriteLine("exit");
                
                sw.Close(); sr.Close(); file.Close();

                // Stop the MySQL server (and client)
                p.WaitForExit();
                MySQLServer.StopAndWait();
            }
            catch (FormatException e)
            {
                string s = e.Message;
            }
        }
        
        /// <summary>
        /// Removes the MySQL configuration file.
        /// </summary>
        /// <param name="savedState">Installer state parameter.</param>
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            string installPath = Context.Parameters["eflashpath"];

            /*try
            {
                string myini = installPath + "Data\\MySQL\\my.ini";
                File.Delete(myini);
            }
            catch (FormatException e)
            {
                string s = e.Message;
            }*/

            MySQLServer.mybin = installPath + "Data\\MySQL\\bin\\";
            MySQLServer.Stop();

            base.Uninstall(savedState);

            try
            {
                File.Delete(installPath + "Data\\MySQL\\my.ini");
                (new DirectoryInfo(installPath + "Data")).Delete(true);
            }
            catch (FormatException e)
            {
                string s = e.Message;
            }
        }
    }
}