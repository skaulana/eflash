using System;
using System.IO;

namespace eFlash.Utilities
{
    /// <summary>
    /// Class to faciliate main program tasks.
    /// </summary>
    public static class AppHelper
    {
        /// <summary>
        /// Get the current working directory of the executing program.
        /// </summary>
        /// <returns>Path to the current working directory.</returns>
        public static String GetPresentWorkingDirectory()
        {
            // Note: this is a bit inelegant
            FileInfo f = new FileInfo("junk");
            return f.Directory.ToString();
        }

        /// <summary>
        /// Replace occurences of one string in another.
        /// </summary>
        /// <param name="strFind">Text to replace (match this).</param>
        /// <param name="strReplace">Replacement text (use to replace match).</param>
        /// <param name="strText">String to perform replacement on.</param>
        /// <returns>String with replacements.</returns>
        public static String StringReplace(String strFind, String strReplace, String strText)
        {
            int iPos = strText.IndexOf(strFind);
            String strReturn = "";
            while (iPos != -1)
            {
                strReturn += strText.Substring(0, iPos) + strReplace;
                strText = strText.Substring(iPos + strFind.Length);
                iPos = strText.IndexOf(strFind);
            }
            if (strText.Length > 0) strReturn += strText;
            return strReturn;
        }
    }
}
