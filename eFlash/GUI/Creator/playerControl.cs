using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;

using eFlash.GUI.ViewerAndQuizzer;

namespace eFlash.GUI.Creator
{
	public partial class PlayerControl : UserControl
	{
		private const string ALIAS_BASE = "MediaFile";
		private static int aliasNum = 0;

		LayoutEditor creator;

		public Player player;
		public string filePath;

		public string alias;

		private bool isOpen, isPlaying;

		public PlayerControl() : this(null) { }

		public PlayerControl(LayoutEditor newCreator)
		{
			InitializeComponent();
			
			creator = newCreator;
			player = new Player();
			filePath = "";
			alias = "";
			isOpen = false;
			isPlaying = false;

			positionControls();
			updateButtonStates();
		}

		private void positionControls()
		{
			btnPlay.Location = new Point(0, 0);
			btnStop.Location = new Point(0, 0);
		}

		#region File

		public void close()
		{
			if (isOpen)
			{
				player.Stop(alias);
				player.Close(alias);
				isOpen = false;
				isPlaying = false;
				filePath = "";
				alias = "";
				updateButtonStates();
			}
		}

		public void resetFile()
		{
			if (isOpen)
			{
				player.Close(alias);
			}

			filePath = "";
			alias = "";
			isOpen = false;
			isPlaying = false;
			updateButtonStates();
		}

		public bool setFile(string path)
		{
			try
			{
				FileInfo file = new FileInfo(path);

				if (file.Exists)
				{
					if (isOpen)
					{
						player.Close(alias);
					}

					filePath = path;
					alias = nextAlias;
					if (player.Open(filePath, alias))
					{
						isOpen = true;
						isPlaying = false;
						updateButtonStates();
						return true;
					}
					else
					{
						resetFile();
						return false;
					}
				}
				else
				{
					resetFile();
					return false;
				}
			}
			catch (Exception e)
			{
				resetFile();
				return false;
			}
		}

		#endregion

		private void updateButtonStates()
		{
			if (isOpen)
			{
				btnPlay.Enabled = true;
				btnStop.Enabled = true;
			}
			else
			{
				btnPlay.Enabled = false;
				btnStop.Enabled = false;
			}

			if (isPlaying)
			{
				btnPlay.Visible = false;
				btnStop.Visible = true;
			}
			else
			{
				btnPlay.Visible = true;
				btnStop.Visible = false;
			}
		}

		#region Events

		private void btnPlay_Click(object sender, EventArgs e)
		{
			if (isOpen)
			{
				player.Play(0, false, alias);
				isPlaying = true;
				updateButtonStates();
			}
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			if (isOpen)
			{
				player.Stop(alias);
				isPlaying = false;
				updateButtonStates();
			}
		}

		private void button_Resize(object sender, EventArgs e)
		{
			btnPlay.Size = button.Size;
			btnStop.Size = button.Size;
			this.Size = button.Size;

			positionControls();
		}

		private void PlayerControl_Resize(object sender, EventArgs e)
		{
			this.Size = button.Size;
		}

		#endregion

		#region Accessors

		public string nextAlias
		{
			get
			{
				string str = ALIAS_BASE + aliasNum.ToString();
				aliasNum++;
				return str;
			}
		}

		#endregion
	}
}
