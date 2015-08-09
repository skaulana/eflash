using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

using eFlash.Data;

namespace eFlash.GUI.Creator
{
	public partial class CreatorObject : UserControl
	{
		public const int NEW_OBJECT = -100;

		private LayoutEditor creator;
		public Control ctlObject;

		public bool isDefaultImage;

		// Data
		private eObject obj;

		// Position and size
		private int[] coords;
		private const int COORDS_ULX = 0;
		private const int COORDS_ULY = 1;
		private const int COORDS_BRX = 2;
		private const int COORDS_BRY = 3;
		
		// Dragging and resizing
		private bool resizing;
		private bool dragging;
		private int origMouseX, origMouseY;
		private const int RESIZE = 0;
		private const int MOVE = 1;
		
		private const int MIN_WIDTH = 35;
		private const int MIN_HEIGHT= 35;

		#region Initialization

		public CreatorObject() { /* Should not be used */ }

		public CreatorObject(LayoutEditor newCreator, eObject newObj)
		{
			if (newObj == null)
			{
				throw new ArgumentException("eObject argument to CreatorObject constructor cannot be null");
			}
			
			creator = newCreator;
			obj = newObj;
			
			InitializeComponent();

			switch (obj.type)
			{
				case Constant.textFile:
					initTextBox();
					break;
				case Constant.imageFile:
					initImage();
					break;
				case Constant.soundFile:
					initAudio();
					break;
				default:
					throw new ArgumentException("Invalid CreatorObject type: " + obj.type);
			}

			bool canEdit = (creator.deck.type == Constant.noQuizDeck);
			deleteToolStripMenuItem.Enabled = canEdit;
			
			this.Leave += new System.EventHandler(this.ctlObject_Leave);
			this.Enter += new System.EventHandler(this.ctlObject_Enter);
			ctlObject.MouseDown += new MouseEventHandler(ctlObject_MouseDown);

			ctlObject.ContextMenuStrip = menuContext;

			if (obj.quizType == Constant.answerPrefix)
			{
				this.BackColor = Color.FromArgb(40, Color.Green);
			}
			else if (obj.quizType == Constant.questionPrefix)
			{
				this.BackColor = Color.FromArgb(40, Color.Red);
			}
		}

		public void initialize()
		{
			dragging = false;
			resizing = false;
			origMouseX = 0;
			origMouseY = 0;

			coords = new int[4];
			coords[COORDS_ULX] = this.Location.X;
			coords[COORDS_ULY] = this.Location.Y;
			coords[COORDS_BRX] = this.Location.X + this.Size.Width;
			coords[COORDS_BRY] = this.Location.Y + this.Size.Height;

			positionControls(false);
			showControls(false);
		}

		private void initTextBox()
		{
			RichTextBox txtText = new RichTextBox();

			ctlObject = txtText;

			txtText.BackColor = System.Drawing.Color.White;
			txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			txtText.DetectUrls = false;
			txtText.Location = new System.Drawing.Point(31, 35);
			txtText.Name = "txtText";
			txtText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			txtText.Size = new System.Drawing.Size(75 + 26, 23 + 26);
			txtText.TabIndex = this.TabIndex + 1;
			txtText.TabStop = false;
			txtText.SelectionChanged += new System.EventHandler(this.txtText_SelectionChanged);
			txtText.BackColorChanged += new EventHandler(contentChangedHandler);
			txtText.ClientSizeChanged += new EventHandler(contentChangedHandler);
			txtText.FontChanged += new EventHandler(contentChangedHandler);
			txtText.ForeColorChanged += new EventHandler(contentChangedHandler);
			txtText.LocationChanged += new EventHandler(contentChangedHandler);
			txtText.SizeChanged += new EventHandler(contentChangedHandler);
			txtText.StyleChanged += new EventHandler(contentChangedHandler);
			txtText.TextChanged += new EventHandler(contentChangedHandler);
			
			FileInfo file = new FileInfo(Constant.ePath + obj.actualFilename);
			if (file.Exists)
			{
				try
				{
					txtText.LoadFile(Constant.ePath + obj.actualFilename, RichTextBoxStreamType.RichText);
				}
				catch (Exception e)
				{
					txtText.Text = "";
				}
			}
			else
			{
				txtText.Text = "";
			}

			Controls.Add(txtText);

			if (txtText.Rtf == "" && creator != null && creator.currentFont != null)
			{
				txtText.Font = creator.currentFont;
			}
		}

		private void initImage()
		{
			PictureBox picBox = new PictureBox();

			ctlObject = picBox;

			picBox.BackColor = System.Drawing.Color.White;
			picBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			picBox.Location = new System.Drawing.Point(31, 35);
			picBox.Name = "picBox";
			picBox.Size = new System.Drawing.Size(91, 85);
			picBox.TabIndex = this.TabIndex + 1;
			picBox.TabStop = false;
			picBox.BackColorChanged += new EventHandler(contentChangedHandler);
			picBox.ClientSizeChanged += new EventHandler(contentChangedHandler);
			picBox.ForeColorChanged += new EventHandler(contentChangedHandler);
			picBox.LocationChanged += new EventHandler(contentChangedHandler);
			picBox.SizeChanged += new EventHandler(contentChangedHandler);
			picBox.StyleChanged += new EventHandler(contentChangedHandler);

			setImage(Constant.ePath + obj.actualFilename);

			Controls.Add(picBox);
		}

		private void initAudio()
		{
			PlayerControl player = new PlayerControl(creator);

			ctlObject = player;

			player.BackColor = System.Drawing.Color.White;
			player.BorderStyle = System.Windows.Forms.BorderStyle.None;
			player.Location = new System.Drawing.Point(31, 35);
			player.Name = "player";
			player.Size = new System.Drawing.Size(91, 85);
			player.TabIndex = this.TabIndex + 1;
			player.TabStop = false;
			player.BackColorChanged += new EventHandler(contentChangedHandler);
			player.ClientSizeChanged += new EventHandler(contentChangedHandler);
			player.ForeColorChanged += new EventHandler(contentChangedHandler);
			player.LocationChanged += new EventHandler(contentChangedHandler);
			player.SizeChanged += new EventHandler(contentChangedHandler);
			player.StyleChanged += new EventHandler(contentChangedHandler);

			player.setFile(Constant.ePath + obj.actualFilename);

			Controls.Add(player);
		}

		#endregion

		#region Edit event handlers

		private void contentChangedHandler(object sender, EventArgs e)
		{
			creator.changed = true;
		}

		#endregion

		#region Selection Event Handlers

		private void txtText_SelectionChanged(object sender, EventArgs e)
		{
			if (this.Focused || ctlObject.Focused)
			{
				if (type == Constant.textFile)
				{
					creator.setCurrentFont(textbox.SelectionFont, false);
					creator.setCurrentColor(textbox.SelectionColor, false);
					creator.setCurrentAlignment(textbox.SelectionAlignment, false);
				}
				else if (type == Constant.imageFile)
				{
					// TODO: Get browser here
				}
			}
		}

		#endregion

		#region Focus Event Handlers

		void ctlObject_MouseDown(object sender, MouseEventArgs e)
		{
			if (obj.type == Constant.imageFile || obj.type == Constant.soundFile)
			{
				this.Focus();
			}
		}

		private void ctlObject_Enter(object sender, EventArgs e)
		{
			creator.selectObject(this);

			if (obj.type == Constant.textFile)
			{
				creator.setCurrentFont(textbox.SelectionFont, false);
				creator.setCurrentColor(textbox.SelectionColor, false);
				creator.setCurrentAlignment(textbox.SelectionAlignment, false);
			}
			else
			{
				creator.fChooser.attachTo(this);
			}

			showControls(true);
		}

		private void ctlObject_Leave(object sender, EventArgs e)
		{
			if (creator.fChooser.isAttachedTo(this))
			{
				creator.fChooser.TabStop = false;
				creator.fChooser.Visible = false;
				showControls(false);
			}
			else
			{
				if (creator.focusedOnCanvas())
				{
					textbox.HideSelection = true;
					creator.selectObject(null);
				}
				else
				{
					textbox.HideSelection = false;
				}

				showControls(false);
			}
		}

		#endregion

		#region Dragging and resizing

		#region Resizing

		private void imgResize_MouseDown(object sender, MouseEventArgs e)
		{
			resizing = true;

			origMouseX = MousePosition.X;
			origMouseY = MousePosition.Y;
			
			clipCursor((Control) sender, e, RESIZE);
		}

		private void imgTopLeft_MouseMove(object sender, MouseEventArgs e)
		{
			resize(e, true, true, false, false);
		}

		private void imgTopMiddle_MouseMove(object sender, MouseEventArgs e)
		{
			resize(e, false, true, false, false);
		}

		private void imgTopRight_MouseMove(object sender, MouseEventArgs e)
		{
			resize(e, false, true, true, false);
		}

		private void imgMiddleRight_MouseMove(object sender, MouseEventArgs e)
		{
			resize(e, false, false, true, false);
		}

		private void imgBottomRight_MouseMove(object sender, MouseEventArgs e)
		{
			resize(e, false, false, true, true);
		}

		private void imgBottomMiddle_MouseMove(object sender, MouseEventArgs e)
		{
			resize(e, false, false, false, true);
		}

		private void imgBottomLeft_MouseMove(object sender, MouseEventArgs e)
		{
			resize(e, true, false, false, true);
		}

		private void imgMiddleLeft_MouseMove(object sender, MouseEventArgs e)
		{
			resize(e, true, false, false, false);
		}

		private void imgResize_MouseUp(object sender, MouseEventArgs e)
		{
			resizing = false;
			unclipCursor();
		}

		private void resize(MouseEventArgs e, bool doULX, bool doULY, bool doBRX, bool doBRY)
		{
			if (true)
			{
				if (resizing)
				{
					changeCoords(e, doULX, doULY, doBRX, doBRY);
				}
			}
		}

		#endregion

		#region Dragging

		private void imgMove_MouseDown(object sender, MouseEventArgs e)
		{
			dragging = true;

			origMouseX = MousePosition.X;
			origMouseY = MousePosition.Y;

			clipCursor((Control) sender, e, MOVE);
		}

		private void imgMove_MouseMove(object sender, MouseEventArgs e)
		{
			if (dragging)
			{
				changeCoords(e, true, true, true, true);
			}
		}

		private void imgMove_MouseUp(object sender, MouseEventArgs e)
		{
			dragging = false;
			unclipCursor();
		}

		#endregion

		#region Initial Dragging

		public void beginInitialDragging()
		{
			ctlObject.Visible = false;
		}

		public void endInitialDragging()
		{
			ctlObject.Visible = true;
			ctlObject.Focus();
		}

		#endregion

		private void changeCoords(MouseEventArgs e, bool doULX, bool doULY, bool doBRX, bool doBRY)
		{
			int newMouseX = MousePosition.X;
			int newMouseY = MousePosition.Y;

			int dx = newMouseX - origMouseX;
			int dy = newMouseY - origMouseY;

			int topBound = 0;
			int bottomBound = Parent.Size.Height - Parent.Margin.Bottom;
			int leftBound = 0;
			int rightBound = Parent.Width - Parent.Margin.Right;

			int[] oldCoords = new int[4];
			coords.CopyTo(oldCoords, 0);

			if (doULX)
			{
				coords[COORDS_ULX] += dx;
			}

			if (doULY)
			{
				coords[COORDS_ULY] += dy;
			}

			if (doBRX)
			{
				coords[COORDS_BRX] += dx;
			}
			
			if (doBRY)
			{
				coords[COORDS_BRY] += dy;
			}

			// Check bounds
			if (coords[COORDS_ULX] < leftBound)
			{
				coords[COORDS_ULX] = leftBound;

				if (coords[COORDS_BRX] != oldCoords[COORDS_BRX])
				{
					coords[COORDS_BRX] = oldCoords[COORDS_BRX] + (coords[COORDS_ULX] - oldCoords[COORDS_ULX]);
				}
			}
			else if (coords[COORDS_BRX] > rightBound)
			{
				coords[COORDS_BRX] = rightBound;

				if (coords[COORDS_ULX] != oldCoords[COORDS_ULX])
				{
					coords[COORDS_ULX] = oldCoords[COORDS_ULX] + (coords[COORDS_BRX] - oldCoords[COORDS_BRX]); ;
				}
			}
			else if (coords[COORDS_ULX] > coords[COORDS_BRX] - MIN_WIDTH)
			{
				coords[COORDS_ULX] = coords[COORDS_BRX] - MIN_WIDTH;
			}

			if (coords[COORDS_ULY] < topBound)
			{
				coords[COORDS_ULY] = topBound;

				if (coords[COORDS_BRY] != oldCoords[COORDS_BRY])
				{
					coords[COORDS_BRY] = oldCoords[COORDS_BRY] + (coords[COORDS_ULY] - oldCoords[COORDS_ULY]);
				}
			}
			else if (coords[COORDS_BRY] > bottomBound)
			{
				coords[COORDS_BRY] = bottomBound;

				if (coords[COORDS_ULY] != oldCoords[COORDS_ULY])
				{
					coords[COORDS_ULY] = oldCoords[COORDS_ULY] + (coords[COORDS_BRY] - oldCoords[COORDS_BRY]);
				}
			}
			else if (coords[COORDS_ULY] > coords[COORDS_BRY] - MIN_HEIGHT)
			{
				coords[COORDS_ULY] = coords[COORDS_BRY] - MIN_HEIGHT;
			}

			positionControls(true);

			origMouseX = newMouseX;
			origMouseY = newMouseY;

			creator.changed = true;
			creator.fChooser.objectMovedHandler(this);
		}

		private void setCoords(int x1, int y1, int x2, int y2)
		{
			coords[COORDS_ULX] = Convert.ToInt32(x1 / 100.0 * LayoutEditor.CANVAS_WIDTH);
			coords[COORDS_ULY] = Convert.ToInt32(y1 / 100.0 * LayoutEditor.CANVAS_HEIGHT);
			coords[COORDS_BRX] = Convert.ToInt32(x2 / 100.0 * LayoutEditor.CANVAS_WIDTH);
			coords[COORDS_BRY] = Convert.ToInt32(y2 / 100.0 * LayoutEditor.CANVAS_HEIGHT);
			
			positionControls(true);
		}

		#endregion

		#region Cursor

		private void clipCursor(Control sender, MouseEventArgs e, int clipType)
		{
			// Set x and y to location of the canvas on the screen
			int x = RectangleToScreen(ClientRectangle).Location.X - Location.X;
			int y = RectangleToScreen(ClientRectangle).Location.Y - Location.Y;

			// Set width and height to that of the canvas
			int width = Parent.Width;
			int height = Parent.Height;

			switch (clipType)
			{
				case MOVE:
					// Offset by clicked point within this CreatorObject
					x = x + e.X + sender.Location.X;
					y = y + e.Y + sender.Location.Y;

					// and modify width and height the same way
					width = width - (e.X + sender.Location.X);
					height = height - (e.Y + sender.Location.Y);

					// Offset width and height by clicked point within this CreatorObject
					width = width - (this.Width - sender.Location.X - e.X);
					height = height - (this.Height - sender.Location.Y - e.Y);
					break;
				case RESIZE:

					break;
				default:
					throw new ArgumentException("Invalid resize type");
			}

			Cursor.Clip = new Rectangle(x, y, width, height);
		}

		private void unclipCursor()
		{
			Cursor.Clip = Screen.PrimaryScreen.Bounds;
		}

		#endregion

		#region Controls

		public void showControls(bool show)
		{
			imgTopLeft.Visible = show;
			imgTopMiddle.Visible = show;
			imgTopRight.Visible = show;

			imgMiddleLeft.Visible = show;
			imgMiddleRight.Visible = show;

			imgBottomLeft.Visible = show;
			imgBottomMiddle.Visible = show;
			imgBottomRight.Visible = show;

			imgTop1.Visible = show;
			imgBottom1.Visible = show;
			imgLeft1.Visible = show;
			imgRight1.Visible = show;
		}

		private void positionControls(bool check)
		{
			if (obj.type == Constant.soundFile)
			{
				coords[COORDS_BRX] = coords[COORDS_ULX] + ctlObject.Width + 26;
				coords[COORDS_BRY] = coords[COORDS_ULY] + ctlObject.Height + 26;
			}

			// We can't set the location and size of the CreatorObject before
			// setting those of its children, or else it will appear shaky,
			// so we first calculate and store the values here, and set
			// them at the bottom.
			int locationX = coords[COORDS_ULX];
			int locationY = coords[COORDS_ULY];
			int sizeWidth = coords[COORDS_BRX] - coords[COORDS_ULX];
			int sizeHeight = coords[COORDS_BRY] - coords[COORDS_ULY];

			int left = 0;
			int right = sizeWidth - 10;
			int xMiddle = right / 2;

			int top = 0;
			int bottom = sizeHeight - 10;
			int yMiddle = bottom / 2;

			// Outter border
			imgTopLeft.Location = new Point(left, top);
			imgTopMiddle.Location = new Point(xMiddle, top);
			imgTopRight.Location = new Point(right, top);

			imgMiddleLeft.Location = new Point(left, yMiddle);
			imgMiddleRight.Location = new Point(right, yMiddle);

			imgBottomLeft.Location = new Point(left, bottom);
			imgBottomMiddle.Location = new Point(xMiddle, bottom);
			imgBottomRight.Location = new Point(right, bottom);


			imgTop1.Location = new Point(left + 10, top);
			imgTop1.Size = new Size(right - left - 10, 10);

			imgBottom1.Location = new Point(left + 10, bottom);
			imgBottom1.Size = imgTop1.Size;

			imgLeft1.Location = new Point(left, top + 10);
			imgLeft1.Size = new Size(10, bottom - top - 10);

			imgRight1.Location = new Point(right, top + 10);
			imgRight1.Size = imgLeft1.Size;


			// Inner border
			imgBorderTop.Location = new Point(left + 10, top + 10);
			imgBorderTop.Size = new Size(right - left - 10 - 3, 3);
			imgBorderBottom.Location = new Point(left + 10, bottom - 3);
			imgBorderBottom.Size = imgBorderTop.Size;

			imgBorderLeft.Location = new Point(left + 10, top + 10);
			imgBorderLeft.Size = new Size(3, bottom - top - 10 - 3);
			imgBorderRight.Location = new Point(right - 3, top + 10);
			imgBorderRight.Size = imgBorderLeft.Size;


			// Object
			ctlObject.Location = new Point(left + 10 + 3, top + 10 + 3);
			ctlObject.Size = new Size(right - left - 10 - 3, bottom - top - 10 - 3);


			// Focus thing
			//txtFocus.Location = new Point(right + 500, bottom + 500);

			this.Size = new Size(sizeWidth, sizeHeight);
			this.Location = new Point(locationX, locationY);
		}

		#endregion

		#region Context Menu

		private void bringToFrontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.BringToFront();
		}

		private void sendToBackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SendToBack();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete this object?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.delete();
			}
		}

		#endregion

		#region Delete

		private void delete()
		{
			creator.currentCard.objects.Remove(this);
			creator.removeObject(this);
			playerControl.close();
			creator.fChooser.detachFrom(this);
			this.Dispose();
		}

		#endregion

		#region eObject

		public static CreatorObject newFromEObject(LayoutEditor newCreator, eObject newObj, int tabStop)
		{
			CreatorObject curNewObj = new CreatorObject(newCreator, newObj);

			curNewObj.Name = "creatorObject";
			curNewObj.TabIndex = tabStop;
			curNewObj.TabStop = true;

			curNewObj.initialize();

			curNewObj.setCoords(newObj.x1, newObj.y1, newObj.x2, newObj.y2);

			return curNewObj;
		}

		public eObject toEObject()
		{
			obj.x1 = Convert.ToInt32(coords[COORDS_ULX] * 100.0 / LayoutEditor.CANVAS_WIDTH);
			obj.y1 = Convert.ToInt32(coords[COORDS_ULY] * 100.0 / LayoutEditor.CANVAS_HEIGHT);
			obj.x2 = Convert.ToInt32(coords[COORDS_BRX] * 100.0 / LayoutEditor.CANVAS_WIDTH);
			obj.y2 = Convert.ToInt32(coords[COORDS_BRY] * 100.0 / LayoutEditor.CANVAS_HEIGHT);

			string fileName = obj.generateFileName();

			obj = new eObject(cid, side, type, obj.x1, obj.x2, obj.y1, obj.y2, fileName);
			return obj;
		}

		#endregion

		#region Image

		public void resetImage()
		{
			setImage(global::eFlash.Properties.Resources.defaultImage);
			imageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			isDefaultImage = true;
		}

		public bool setImage(string path)
		{
			try
			{
				FileInfo file = new FileInfo(path);

				if (file.Exists)
				{
					Image bgImage = new Bitmap(path);
					setImage(bgImage);
					imageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
					isDefaultImage = false;
					return true;
				}
				else
				{
					resetImage();
					return false;
				}
			}
			catch (Exception e)
			{
				resetImage();
				return false;
			}
		}

		private void setImage(Image img)
		{
			imageBox.BackgroundImage = new Bitmap(img);
			img.Dispose();
		}

		#endregion

		#region Accessors

		public string type
		{
			get { return obj.type; }
			set { obj.type = value; }
		}

		public RichTextBox textbox
		{
			get
			{
				if (type.Equals(Constant.textFile))
				{
					return (RichTextBox) ctlObject;
				}
				else
				{
					return new RichTextBox();
				}
			}
		}

		public PictureBox imageBox
		{
			get
			{
				if (type.Equals(Constant.imageFile))
				{
					return (PictureBox) ctlObject;
				}
				else
				{
					return new PictureBox();
				}
			}
		}

		public PlayerControl playerControl
		{
			get
			{
				if (type.Equals(Constant.soundFile))
				{
					return (PlayerControl) ctlObject;
				}
				else
				{
					return new PlayerControl();
				}
			}
		}

		public int cid
		{
			get { return obj.cid; }
			set { obj.cid = value; }
		}

		public int side
		{
			get { return obj.side; }
			set { obj.side = value; }
		}

		public eObject eObj
		{
			get 
			{
				return obj;
			}

			set
			{
				obj = value;
			}
		}

		#endregion

		private void CreatorObject_Enter(object sender, EventArgs e)
		{
			if (type == Constant.textFile)
			{
				ctlObject.Focus();
			}
		}
	}
}
