using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace eFlash.Utilities
{
    /// <summary>
    /// Stream redirection enumerator.
    /// </summary>
    public enum Redirector
    {
        none, i, o, e, io, ie, oe, all
    }

    /// <summary>
    /// Provides a front-end to the local MySQL installation.
    /// </summary>
    public static class MySQLServer
    {
        /// <summary>
        /// Path to MySQL bin directory (must be set prior to function calls).
        /// </summary>
        public static string mybin = "";

        /// <summary>
        /// Start the MySQL server.
        /// </summary>
        /// <returns>Handle to the server process.</returns>
        public static Process Start()
        {
            try
            {
                return RunProcess(mybin + "mysqld.exe", "--standalone", false, false);
            }
            catch (FormatException e)
            {
                string s = e.Message;
                return null;
            }
        }

        /// <summary>
        /// Start the MySQL server and wait for it to be ready.
        /// </summary>
        /// <returns>Handle to the server process.</returns>
        public static Process StartAndWait()
        {
            try
            {
                Process p = Start();
                RunProcess(mybin + "mysqladmin.exe", "--user=root --wait ping", false, true);
                return p;
            }
            catch (FormatException e)
            {
                string s = e.Message;
                return null;
            }
        }

        /// <summary>
        /// Stop the MySQL server if it is running.
        /// </summary>
        public static void Stop()
        {
            try
            {
                RunProcess(mybin + "mysqladmin.exe", "--user=root --silent shutdown", false, true);
            }
            catch (FormatException e)
            {
                string s = e.Message;
            }
        }

        /// <summary>
        /// Wait for the MySQL server to stop running.
        /// </summary>
        public static void StopAndWait()
        {
            try
            {
                RunProcess(mybin + "mysqladmin.exe", "--user=root --wait shutdown", false, true);
            }
            catch (FormatException e)
            {
                string s = e.Message;
            }
        }

        /// <summary>
        /// Connect the command-line MySQL client to a running MySQL server.
        /// </summary>
        /// <returns>Handle to the client process.</returns>
        public static Process Connect()
        {
            return Connect(false);
        }

        /// <summary>
        /// Connect the command-line MySQL client to a running MySQL server.
        /// </summary>
        /// <returns>Handle to the client process.</returns>
        public static Process Connect(bool show)
        {
            try
            {
                return RunProcess(mybin + "mysql.exe", "--user=root --no-beep", show, false, Redirector.i);
            }
            catch (FormatException e)
            {
                string s = e.Message;
                return null;
            }
        }

        /// <summary>
        /// Start the MySQL server and connect the command-line client to it.
        /// </summary>
        /// <returns>Handle to the client process.</returns>
        public static Process StartAndConnect()
        {
            try
            {
                StartAndWait();
                return Connect();
            }
            catch (FormatException e)
            {
                string s = e.Message;
                return null;
            }
        }

        /// <summary>
        /// Auxillary function that starts a process with additional options.
        /// </summary>
        /// <param name="cmd">Command to execute.</param>
        /// <param name="args">Arguments to pass to command.</param>
        /// <param name="show">Whether or not the process should be visible.</param>
        /// <param name="waitForExit">Whether or not the process should wait for termination.</param>
        /// <returns>Handle to the newly created process.</returns>
        public static Process RunProcess(string cmd, string args, bool show, bool waitForExit)
        {
            return RunProcess(cmd, args, show, waitForExit, Redirector.none);
        }

        /// <summary>
        /// Auxillary function that starts a process with additional options.
        /// </summary>
        /// <param name="cmd">Command to execute.</param>
        /// <param name="args">Arguments to pass to command.</param>
        /// <param name="show">Whether or not the process should be visible.</param>
        /// <param name="waitForExit">Whether or not the process should wait for termination.</param>
        /// <param name="redirectIO">What I/O should be redirected.</param>
        /// <returns>Handle to the newly created process.</returns>
        public static Process RunProcess(string cmd, string args, bool show, bool waitForExit, Redirector r)
        {
            if (!File.Exists(cmd))
            {
                MessageBox.Show("The database executable file could not be found. Please reinstall eFlash.",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(2);
                return null;
            }
            else
            {
                ProcessStartInfo psi = new ProcessStartInfo(cmd, args);
                Process p = new Process();

                if (!show) // run silently...
                {
                    psi.CreateNoWindow = true;
                    psi.UseShellExecute = false;
                }
                if (r == Redirector.i || r == Redirector.ie || r == Redirector.io || r == Redirector.all) psi.RedirectStandardInput = true;
                if (r == Redirector.o || r == Redirector.oe || r == Redirector.io || r == Redirector.all) psi.RedirectStandardOutput = true;
                if (r == Redirector.e || r == Redirector.ie || r == Redirector.oe || r == Redirector.all) psi.RedirectStandardError = true;

                p.StartInfo = psi;
                p.Start();

                if (waitForExit) p.WaitForExit();

                return p;
            }
        }
    }
}