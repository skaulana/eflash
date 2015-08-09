using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace eFlash.GUI.Creator
{
	public partial class FileChooser : UserControl
	{
		private LayoutEditor creator;
		private CreatorObject obj;

		public FileChooser() : this(null) { }

		public FileChooser(LayoutEditor newCreator)
		{
			creator = newCreator;

			InitializeComponent();

			this.Visible = false;
			this.TabStop = false;
			this.TabIndex = 99999;
		}

		#region File Path

		private void applyPath()
		{
			if (obj != null && !path.Equals(""))
			{
				if (obj.type == Constant.imageFile)
				{
					obj.setImage(path);
					creator.changed = true;
				}
				else if (obj.type == Constant.soundFile)
				{
					obj.playerControl.setFile(path);
					creator.changed = true;
				}
			}
		}

		#endregion

		#region CreatorObject tracking

		public void attachTo(CreatorObject newObj)
		{
			path = "";
			obj = newObj;
			trackObj();
			this.show();
			this.Focus();
		}

		public void detachFrom(CreatorObject detachee)
		{
			if (detachee == obj)
			{
				obj = null;
				this.hide();
			}
		}

		public void detach()
		{
			detachFrom(obj);
		}

		public bool isAttachedTo(CreatorObject that)
		{
			return that == obj;
		}

		public void objectMovedHandler(CreatorObject movedObj)
		{
			if (movedObj == obj)
			{
				trackObj();
			}
		}

		private void trackObj()
		{
			if (obj != null)
			{
				Point l1 = obj.Location;
				Point l2 = creator.canvas.Parent.Location;
				int x = l1.X + l2.X + (obj.Width / 2) - (this.Width / 2);
				int y = l1.Y + l2.Y;// - this.Height;

				if (x < 0)
				{
					x = 0;
				}
				else if (x + this.Width > creator.Width)
				{
					x = creator.Width - this.Width;
				}

				if (y < 0)
				{
					y = 0;
				}
				else if (y + this.Height > creator.Height)
				{
					y = creator.Height - this.Height;
				}

				this.Location = new Point(x, y);
			}
		}

		#endregion

		#region Show/Hide

		public void show()
		{
			this.Visible = true;
			this.BringToFront();
			this.TabStop = true;
			
			if (obj != null)
			{
				this.TabIndex = obj.TabIndex;
			}
		}

		public void hide()
		{
			this.Visible = false;
			this.TabStop = false;
			this.SendToBack();
		}

		#endregion

		#region Events

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.CheckPathExists = true;
			dialog.FileName = path;
			dialog.Multiselect = false;
			dialog.ValidateNames = true;

			if (dialog.ShowDialog(creator) == DialogResult.OK)
			{
				path = dialog.FileName;
			}

			applyPath();
		}

		private void FileChooser_Enter(object sender, EventArgs e)
		{
			if (obj != null)
			{
				this.show();
				obj.showControls(true);
			}
		}

		private void FileChooser_Leave(object sender, EventArgs e)
		{
			if (obj != null)
			{
				this.hide();
				obj.showControls(false);
			}

			applyPath();
		}

		#endregion

		#region Accessors

		public string path
		{
			get
			{
				return txtPath.Text;
			}

			set
			{
				txtPath.Text = value;
			}
		}

		#endregion
	}
}
