using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace eFlash.GUI.ViewerAndQuizzer
{
    public class Player
    {

        private string Pcommand;
        private bool isOpen;

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public Player()
        {

        }

		public void Close()
		{
			Close("MediaFile");
		}

        public void Close(string alias)
        {
            Pcommand = "close " + alias;
            mciSendString(Pcommand, null, 0, IntPtr.Zero);
            isOpen = false;
        }

		public void Pause()
		{
			if (isOpen)
			{
				Pcommand = "pause MediaFile";
				mciSendString(Pcommand, null, 0, IntPtr.Zero);
			}
		}

		public void Stop()
		{
			Stop("MediaFile");
		}

		public void Stop(string alias)
		{
			if (isOpen)
			{
				Pcommand = "stop " + alias;
				mciSendString(Pcommand, null, 0, IntPtr.Zero);
			}
		}

		public bool Open(string sFileName)
		{
			return Open(sFileName, "MediaFile");
		}

        public bool Open(string sFileName, string alias)
        {
            Pcommand = "open \"" + sFileName + "\" type mpegvideo alias " + alias;
            try
            {
                mciSendString(Pcommand, null, 0, IntPtr.Zero);
				isOpen = true;
				return true;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
				isOpen = false;
				return false;
            }
		}

        public void Play(bool loop, string alias)
        {
            Play(0, loop, alias);
        }


		public void Play(bool loop)
		{
			Play(0, loop);
		}

		public void Play(int startPosition, bool loop, string alias)
		{
			if (isOpen)
			{
				Pcommand = "play " + alias + " from " + startPosition;
				if (loop)
					Pcommand += " REPEAT";
				mciSendString(Pcommand, null, 0, IntPtr.Zero);
			}
		}

		/// <summary>
		/// Play the open file starting from the specified position
		/// </summary>
		/// <param name="startPosition">Start position</param>
		/// <param name="loop">Whether or not to loop</param>
		public void Play(int startPosition, bool loop)
		{
			Play(startPosition, loop, "MediaFile");
		}

		public long fileLength()
		{
			if (isOpen)
			{
				StringBuilder retVal = new StringBuilder(255);
				Pcommand = "status MediaFile length";
				long retLong = mciSendString(Pcommand, retVal, 255, IntPtr.Zero);
				string retString = retVal.ToString();
			}

			return 0;
		}
    }
}
