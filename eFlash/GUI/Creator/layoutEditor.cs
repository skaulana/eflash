using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using System.IO;

using eFlash.Profile;
using eFlash.Data;
using eFlash.GUI.ViewerAndQuizzer;
using eFlash.GUI.Templates;

namespace eFlash.GUI.Creator
{
	public partial class LayoutEditor : Form
	{
		private static Type CREATOR_OBJECT_TYPE = (new CreatorObject()).GetType();

		private const int NEW_TEMPLATE_CARD = -2;

		public const int CANVAS_WIDTH = 600;
		public const int CANVAS_HEIGHT = 400;

		private eFlash.Data.Deck _deck;
		private CreatorCard _currentCard;

		public CreatorObject selectedObject;

		private CreatorObject draggingObj;

		private ColorDialog colorDialog;
		private FontDialog fontDialog;
		public FileChooser fChooser;

		public TemplateSelector templateSelector;

		public Font currentFont;
		public Color currentColor;
		public float currentSize;
		public HorizontalAlignment currentAlignment;

		// Side control
		protected int currentSideIndex;
		public TabPage canvas;

		// Save on exit confirmation
		public bool changed;
		public bool templateChanged;
		public bool promptAtTemplateChange;

		private bool useHandlers = true;

		main prevWindow;

		#region Initialization

		public LayoutEditor(main newPrevWindow, eFlash.Data.Deck newDeck) : this(newPrevWindow, newDeck, false) { }

		public LayoutEditor(main newPrevWindow, eFlash.Data.Deck newDeck, bool makeCopy)
		{
			InitializeComponent();

			prevWindow = newPrevWindow;

			if (makeCopy)
			{
				deck = deepCopy(newDeck);
			}
			else
			{
				deck = newDeck;
			}

			initialize();
		}

		private void initialize()
		{
			alignmentSelector.setCreator(this);
			alignmentSelector.alignmentChangedHandler = new AlignmentSelector.creatorEventHandler(alignmentChanged);

			selectedObject = null;

			initializeDialogs();

			populateFonts();
			populateSizes();

			setCurrentFont(fontDialog.Font, true);
			setCurrentColor(colorDialog.Color, true);
			setCurrentAlignment(alignmentSelector.alignment, true);

			updateSides();

			fChooser = new FileChooser(this);
			Controls.Add(fChooser);

			changed = false;
			templateChanged = false;
			promptAtTemplateChange = true;
		}

		private void LayoutEditor_Shown(object sender, EventArgs e)
		{
			if (deck == null)
			{
				deck = new eFlash.Data.Deck();
				deck.uid = ProfileManager.getCurrentUserID();

				if (!showDeckPropertiesDialog(true))
				{
					changed = false;
					templateChanged = false;
					this.Close();
					return;
				}
				
				if (deck.cardList.Count == 0)
				{
					promptAtTemplateChange = false;
				}
			}

			changed = false;

			if (deck.cardList.Count == 0)
			{
				promptAtTemplateChange = false;
			}

			if (deck.type == Constant.noQuizDeck)
			{
				deleteSideToolStripMenuItem1.Enabled = true;
				addNewSideToolStripMenuItem.Enabled = true;
			}
			else if (deck.type == Constant.textDeck || deck.type == Constant.imageDeck || deck.type == Constant.soundDeck)
			{
				tsObjects.Visible = false;
				templateSelector = new TemplateSelector(this, deck.type);
				templateSelector.Location = tsObjects.Location;

				this.Controls.Add(templateSelector);

				deleteSideToolStripMenuItem1.Enabled = false;
				addNewSideToolStripMenuItem.Enabled = false;
			}
			else
			{
				throw new Exception("Invalid deck type");
			}
		}

		#endregion

		#region Tab control

		#region Side creation

		/// <summary>
		/// Creates a new side at the end of the side list.
		/// </summary>
		private void createNewSide()
		{
			TabPage newTab = new System.Windows.Forms.TabPage();

			newTab.AllowDrop = true;
			newTab.Location = new System.Drawing.Point(4, 22);
			newTab.Name = "tabPage";
			newTab.Padding = new System.Windows.Forms.Padding(3);
			newTab.Size = new System.Drawing.Size(600, 400);
			newTab.TabIndex = 1;
			newTab.Text = "Side " + (tabSides.TabCount + 1).ToString();
			newTab.UseVisualStyleBackColor = true;
			newTab.DragOver += new System.Windows.Forms.DragEventHandler(this.canvas_DragOver);
			newTab.Click += new System.EventHandler(this.canvas_Click);
			newTab.DragDrop += new System.Windows.Forms.DragEventHandler(this.canvas_DragDrop);
			newTab.DragEnter += new System.Windows.Forms.DragEventHandler(this.canvas_DragEnter);
			newTab.DragLeave += new System.EventHandler(this.canvas_DragLeave);

			tabSides.Controls.Add(newTab);
		}

		#endregion

		#region Side removal

		/// <summary>
		/// Removes all sides from the current view. 
		/// 
		/// NOTE: You MUST add a side after calling this function to make
		/// sure that the card has at least one side.
		/// </summary>
		private void clearAllSides()
		{
			deleteObjects();
			tabSides.Controls.Clear();
		}

		#endregion

		#region Event handlers

		private void tabChanged(object sender, EventArgs e)
		{
			updateSides();
			updateButtonStates();
		}

		private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (tabSides.TabPages.Count < 5)
			{
				createNewSide();
				setSide(tabSides.TabPages.Count - 1);
				changed = true;
			}
			else
			{
				MessageBox.Show("You may only have a maximum of 5 sides per flashcard.");
			}
		}

		private void deleteSideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (tabSides.TabCount <= 1)
			{
				MessageBox.Show("A flashcard must have at least one side.", "Unable to delete side", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				if (MessageBox.Show("Are you sure you want to delete the current side?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					CreatorObject curObj;

					// Remove all objects
					foreach (Control curControl in tabSides.SelectedTab.Controls)
					{
						curObj = (CreatorObject) curControl;

						currentCard.objects.Remove(curObj);
					}
					
					int i = 0;

					// Update side number both on GUI and in objects
					foreach (TabPage curSide in tabSides.TabPages)
					{
						if (curSide != tabSides.SelectedTab)
						{
							foreach (Control curControl in curSide.Controls)
							{
								curObj = (CreatorObject) curControl;

								curObj.side = i;
							}

							curSide.Text = "Side " + (i + 1);

							i++;
						}
					}

					// Delete the side
					tabSides.TabPages.Remove(tabSides.SelectedTab);

					updateSides();
					changed = true;
				}
			}
		}

		#endregion

		private void updateSides()
		{
			canvas = tabSides.SelectedTab;
			currentSideIndex = tabSides.SelectedIndex;
		}

		/// <summary>
		/// Sets the currently displayed side to i.
		/// </summary>
		/// <param name="i">Index of side (starting at 0)</param>
		private void setSide(int i)
		{
			if (i >= tabSides.TabCount)
			{
				throw new ArgumentException("Invalid tab index");
			}
			else
			{
				tabSides.SelectedIndex = i;
				updateSides();
			}
		}

		#endregion

		#region Text (Fonts, styles, etc.)

		#region Initialization

		private void populateFonts()
		{
			InstalledFontCollection fonts = new InstalledFontCollection();
			FontFamily[] families = fonts.Families;

			ddlFont.BeginUpdate();

			foreach (FontFamily curFamily in families)
			{
				ddlFont.Items.Add(curFamily.Name);
			}

			ddlFont.EndUpdate();
		}

		private void populateSizes()
		{
			ddlSize.BeginUpdate();

			for (int i = 8; i <= 28; i += 2)
			{
				ddlSize.Items.Add(i);
			}

			ddlSize.Items.Add(36);
			ddlSize.Items.Add(48);
			ddlSize.Items.Add(72);

			ddlSize.EndUpdate();
		}

		private void initializeDialogs()
		{
			fontDialog = new FontDialog();
			colorDialog = new ColorDialog();

			fontDialog.ShowColor = false;
			fontDialog.ShowEffects = true;
			fontDialog.ShowApply = false;
			fontDialog.ShowHelp = true;
			fontDialog.FontMustExist = true;

			colorDialog.ShowHelp = true;
			colorDialog.SolidColorOnly = false;
		}

		#endregion

		#region Setters

		public void setCurrentFont(Font newFont, bool applyToSelection)
		{
			if (newFont != null)
			{
				currentFont = newFont;
				fontDialog.Font = newFont;
				useHandlers = false;
				ddlFont.SelectedItem = newFont.FontFamily.Name;
				useHandlers = true;

				setCurrentSize((float) Math.Round(newFont.SizeInPoints));

				if (applyToSelection && selectedObject != null)
				{
					selectedObject.textbox.SelectionFont = currentFont;
				}
			}
			else
			{
				fontDialog.Font = null;
				ddlFont.SelectedItem = null;
			}
		}

		// Should only be called from setCurrentFont()
		private void setCurrentSize(float newSize)
		{
			currentSize = newSize;
			
			int sizeIndex = ddlSize.FindString(newSize.ToString());

			useHandlers = false;

			if (sizeIndex != -1)
			{
				ddlSize.SelectedIndex = sizeIndex;
			}
			else
			{
				ddlSize.SelectedItem = null;
				ddlSize.Text = newSize.ToString();
			}

			useHandlers = true;
		}

		public void setCurrentColor(Color newColor, bool applyToSelection)
		{
			currentColor = newColor;
			colorDialog.Color = newColor;

			if (applyToSelection && selectedObject != null)
			{
				selectedObject.textbox.SelectionColor = currentColor;
			}
		}

		public void setCurrentAlignment(HorizontalAlignment newAlignment, bool applyToSelection)
		{
			currentAlignment = newAlignment;
			useHandlers = false;
			alignmentSelector.alignment = newAlignment;
			useHandlers = true;

			if (applyToSelection && selectedObject != null)
			{
				selectedObject.textbox.SelectionAlignment = currentAlignment;
			}
		}

		#endregion

		#region Changed handlers

		private void alignmentChanged()
		{
			if (useHandlers)
			{
				setCurrentAlignment(alignmentSelector.alignment, true);
			}
		}

		private void fontSelectionChanged(object sender, EventArgs e)
		{
			if (useHandlers)
			{
				if (ddlFont.SelectedItem != null)
				{
					float size = currentFont.Size;

					if (!ddlSize.Text.Equals(""))
					{
						try
						{
							size = Convert.ToInt32(ddlSize.Text);
						}
						catch (Exception ex)
						{
							size = currentFont.Size;
						}
					}

					Font newFont;

					try
					{
						newFont = new Font(ddlFont.SelectedItem.ToString(), size);
					}
					catch (Exception ex)
					{
						newFont = currentFont;
					}

					setCurrentFont(newFont, true);
				}
				else
				{
					
				}
			}
		}

		#endregion

		private void ddlFont_Leave(object sender, EventArgs e)
		{
			if (ddlFont.FindString(ddlFont.Text) == -1)
			{
				ddlFont.SelectedItem = currentFont.FontFamily.Name;
			}
		}

		#region Font/color button click handlers

		private void btnFont_Click(object sender, EventArgs e)
		{
			try
			{
				if (fontDialog.ShowDialog() != DialogResult.Cancel)
				{
					setCurrentFont(fontDialog.Font, true);
				}
			}
			catch (Exception ex)
			{
				
			}
		}

		private void btnColor_Click(object sender, EventArgs e)
		{
			if (colorDialog.ShowDialog() != DialogResult.Cancel)
			{
				setCurrentColor(colorDialog.Color, true);
			}
		}

		#endregion

		#endregion

		#region Object creation

		private void btnTextbox_MouseDown(object sender, MouseEventArgs e)
		{
			eObject eObj = new eObject();
			eObj.type = Constant.textFile;
			eObj.side = currentSideIndex;
			eObj.quizType = Constant.nonePrefix;
			eObj.actualFilename = "[n]noFile.txt";
			eObj.data = eObj.quizType + eObj.actualFilename;
			CreatorObject draggingObj = new CreatorObject(this, eObj);
			btnTextbox.DoDragDrop(draggingObj, DragDropEffects.Move);
		}

		private void btnImage_MouseDown(object sender, MouseEventArgs e)
		{
			eObject eObj = new eObject();
			eObj.type = Constant.imageFile;
			eObj.side = currentSideIndex;
			eObj.quizType = Constant.nonePrefix;
			eObj.actualFilename = "[n]noFile.txt";
			eObj.data = eObj.quizType + eObj.actualFilename;
			CreatorObject draggingObj = new CreatorObject(this, eObj);
			btnTextbox.DoDragDrop(draggingObj, DragDropEffects.Move);
		}
				
		private void btnAudio_MouseDown(object sender, MouseEventArgs e)
		{
			eObject eObj = new eObject();
			eObj.type = Constant.soundFile;
			eObj.side = currentSideIndex;
			eObj.data = "[n]noFile.txt";
			CreatorObject draggingObj = new CreatorObject(this, eObj);
			btnTextbox.DoDragDrop(draggingObj, DragDropEffects.Move);
		}

		private void canvas_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(CREATOR_OBJECT_TYPE))
			{
				e.Effect = DragDropEffects.Move;
				
				draggingObj = (CreatorObject) (e.Data.GetData(CREATOR_OBJECT_TYPE));
				draggingObj.Name = "draggingObj";
				if (draggingObj.eObj.quizType == Constant.soundFile)
				{
					draggingObj.Size = new System.Drawing.Size(100, 100);
				}
				else
				{
					draggingObj.Size = new System.Drawing.Size(100, 100);
				}
				draggingObj.TabIndex = (currentCard.objects.Count * 2) + 10;
				draggingObj.TabStop = true;

				draggingObj.initialize();
				draggingObj.beginInitialDragging();
				((TabPage) sender).Controls.Add(draggingObj);
			}
		}

		private void canvas_DragOver(object sender, DragEventArgs e)
		{
			if (draggingObj != null)
			{
				Point mousePoint = PointToClient(MousePosition);
				int mouseX = mousePoint.X - ((TabPage) sender).Location.X - tabSides.Location.X;
				int mouseY = mousePoint.Y - ((TabPage) sender).Location.Y - tabSides.Location.Y;

				draggingObj.Location = new System.Drawing.Point(mouseX - (draggingObj.Size.Width / 2), mouseY - (draggingObj.Size.Height / 2));
			}
		}

		private void canvas_DragDrop(object sender, DragEventArgs e)
		{
			if (draggingObj != null)
			{
				if (((TabPage) sender).Controls.Count >= 6)
				{
					canvas_DragLeave(sender, e);
					MessageBox.Show("You may have at most 5 objects per side.");
				}
				else
				{
					draggingObj.initialize();
					draggingObj.endInitialDragging();
					currentCard.objects.Add(draggingObj);
					draggingObj = null;
				}
			}
		}

		private void canvas_DragLeave(object sender, EventArgs e)
		{
			if (draggingObj != null)
			{
				((TabPage) sender).Controls.Remove(draggingObj);
				draggingObj = null;
			}
		}

		#endregion

		#region Flashcard navigation

		#region Button event handlers

		private void btnSaveAndNext_Click(object sender, EventArgs e)
		{
			if (save(true))
			{
				nextCanvas();
			}
		}

		private void btnPrev_Click(object sender, EventArgs e)
		{
			if (saveAndCloseFlashcard())
			{
				prevFlashcard();
			}
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			if (saveAndCloseFlashcard())
			{
				nextFlashcard();
			}
		}

		private void btnFront_Click(object sender, EventArgs e)
		{
			if (saveAndCloseFlashcard())
			{
				goToFront();
			}
		}

		private void btnEnd_Click(object sender, EventArgs e)
		{
			if (saveAndCloseFlashcard())
			{
				goToEnd();
			}
		}

		private void btnNewCard_Click(object sender, EventArgs e)
		{
			if (saveAndCloseFlashcard())
			{
				setFlashcard(newCard(), -1);
			}
		}

		#endregion

		private void nextCanvas()
		{
			if (currentSideIndex < tabSides.TabCount - 1)
			{
				setSide(currentSideIndex + 1);
			}
			else
			{
				nextFlashcard();
			}

			if (currentCard.objects.Count > 0)
			{
				currentCard.objects[0].Focus();
			}
		}

		private void prevFlashcard()
		{
			int index = currentCard.index;

			if (index == -1)
			{
				goToEnd();
			}
			else if (index == 0)
			{
				goToFront();
			}
			else
			{
				setFlashcard(deck.cardList[index - 1], index - 1);
			}
		}

		private void nextFlashcard()
		{
			int index = currentCard.index;

			if (index == -1 || index == deck.cardList.Count - 1)
			{
				setFlashcard(newCard(), -1);
			}
			else
			{
				setFlashcard(deck.cardList[index + 1], index + 1);
			}
		}

		private void goToFront()
		{
			setFlashcard(deck.cardList[0], 0);
		}

		private void goToEnd()
		{
			setFlashcard(deck.cardList[deck.cardList.Count - 1], deck.cardList.Count - 1);
		}

		private void setFlashcard(Card newCard, int index)
		{
			stopAllSounds();

			_currentCard = new CreatorCard(this, newCard, index);

			if (newCard.cardID == -1)
			{
				// If card is new, then fill its objects with the
				// objects currently on the canvas
				currentCard.loadObjects(tabSides);
				changed = true;
			}
			else
			{
				// If card is not new, then load its objects onto the canvas
				loadObjects(currentCard.objects);
				changed = false;

				if (newCard.cardID == NEW_TEMPLATE_CARD)
				{
					newCard.cardID = -1;
					currentCard.cardID = -1;
					changed = true;
				}
			}

			setSide(0);

			updateButtonStates();
			updateCurCard();

			promptAtTemplateChange = true;
			templateChanged = false;
		}

		#endregion

		#region Canvas objects

		/// <summary>
		/// Erases all object values in all canvases
		/// </summary>
		private void clearObjects()
		{
			foreach (TabPage curTab in tabSides.TabPages)
			{
				foreach (CreatorObject curObj in curTab.Controls)
				{
					curObj.textbox.Text = "";
				}
			}
		}

		/// <summary>
		/// Applies a template into this flashcard
		/// </summary>
		/// <param name="template">Template to use</param>
		public void loadTemplate(Template template)
		{
			Card card = new Card("", ProfileManager.getCurrentUserID());
			
			if (currentCard.cardID == -1)
			{
				card.cardID = NEW_TEMPLATE_CARD;
			}
			else
			{
				card.cardID = currentCard.cardID;
			}

			eObject curEObj;
			TemplateObject curObj;
			// Fill the sides with objects
			for (int i = 0; i < template.objects.Count; i++)
			{
				curObj = template.objects[i];
				curEObj = new eObject(-1, curObj.side, curObj.type, curObj.x1, curObj.x2, curObj.y1, curObj.y2, curObj.quizType + "noFile.txt");
				card.eObjectList.Add(curEObj);
			}

			if (deck.cardList.Count == 0)
			{
				deck.cardList.Add(card);
				setFlashcard(card, 0);
			}
			else if (currentCard.index == -1)
			{
				deck.cardList.Add(card);
				setFlashcard(card, deck.cardList.Count - 1);
			}
			else
			{
				//deck.cardList[currentCard.index] = card;
				setFlashcard(card, currentCard.index);
			}

			templateChanged = true;
			changed = false;
			promptAtTemplateChange = false;
		}

		/// <summary>
		/// Load canvas objects with list of objects
		/// </summary>
		/// <param name="objects">Objects to load</param>
		private void loadObjects(List<CreatorObject> objects)
		{
			clearAllSides();
			
			int numSides = 0;
			
			// Find the total number of sides
			foreach (CreatorObject curObj in objects)
			{
				if (curObj.side + 1 > numSides)
				{
					numSides = curObj.side + 1;
				}
			}

			// If this flashcard is blank, default it to 2 sides
			if (numSides == 0)
			{
				numSides = 2;
			}

			// Create the sides
			for (int i = 0; i < numSides; i++)
			{
				createNewSide();
			}

			// Fill the sides with objects
			foreach (CreatorObject curObj in objects)
			{
				tabSides.TabPages[curObj.side].Controls.Add(curObj);
			}
		}

		/// <summary>
		/// Clears all canvases
		/// </summary>
		private void deleteObjects()
		{
			foreach (TabPage curTab in tabSides.TabPages)
			{
				curTab.Controls.Clear();
			}
		}

		public void removeObject(CreatorObject obj)
		{
			foreach (TabPage curTab in tabSides.TabPages)
			{
				if (curTab.Controls.Contains(obj))
				{
					curTab.Controls.Remove(obj);
				}
			}
		}

		#endregion

		#region Saving and exiting

		#region Saving

		private bool save()
		{
			return save(false);
		}

		/// <summary>
		/// Saves the current flashcard.
		/// </summary>
		/// <returns>Whether or not save was successful.</returns>
		private bool save(bool checkSavePreview)
		{
			if (deck.id == -1)
			{
				throw new Exception("Trying to save flashcard before deck is saved");
			}
			
			if (!canSave())
			{
				return false;
			}

			// Save the card
			Card savedCard = saveCard();
			
			currentCard.cardID = savedCard.cardID;

			// Update the deck's list
			if (currentCard.index == -1)
			{
				currentCard.index = deck.cardList.Count;
				currentCard.originalCard = savedCard;
				currentCard.cardID = savedCard.cardID;
				deck.cardList.Add(savedCard);
			}
			else
			{
				if (currentCard.cardID != savedCard.cardID)
				{
					throw new Exception("Saved card's Id and original ID do not match");
				}

				currentCard.originalCard = savedCard;
				deck.cardList[currentCard.index] = savedCard;
			}

			// Clean out existing objects
			dbAccess.deleteLocalDB.deleteObjects(currentCard.cardID);
			
			CreatorObject curObj;
			eObject savedObj;

			savedCard.eObjectList.Clear();

			// And insert the new ones
			for(int i = 0; i < currentCard.objects.Count; i++)
			{
				curObj = currentCard.objects[i];
				curObj.cid = currentCard.cardID;
				savedObj = saveObject(curObj);
				savedCard.eObjectList.Add(savedObj);
			}

			// Save preview if necessary
			if (currentCard.index == 0)
			{
				int originalSide = tabSides.SelectedIndex;
				if ((!checkSavePreview) || (originalSide == 0) || (originalSide == tabSides.TabCount - 1))
				{
					setSide(0);
					tabSides.TabPages[0].Focus();
					this.Refresh();
					deck.savePreview(tabSides.TabPages[0]);
					setSide(originalSide);
				}
			}
			
			changed = false;
			templateChanged = false;

			return true;
		}

		/// <summary>
		/// Saves obj to DB and file. Obj MUST have its cid set to a valid value. 
		/// </summary>
		/// <param name="obj">Object to save</param>
		private eObject saveObject(CreatorObject obj)
		{
			string originalSoundFileName = "";
			byte[] data = null;

			if (obj.cid == -1)
			{
				throw new Exception("Trying to save object without first setting cid");
			}

			// Kill off the old bmp file so it doesnt hog the file
			// while we try to delete and overwrite
			if (obj.type == Constant.imageFile)
			{
				Image originalBmp = obj.imageBox.BackgroundImage;
				obj.imageBox.BackgroundImage = new Bitmap(obj.imageBox.BackgroundImage);
				originalBmp.Dispose();
			}
			else if (obj.type == Constant.soundFile)
			{
				originalSoundFileName = obj.playerControl.filePath;
				obj.playerControl.close();

				FileStream userFile = new FileStream(originalSoundFileName, FileMode.Open, FileAccess.Read);
				data = new byte[userFile.Length];
				userFile.Read(data, 0, Convert.ToInt32(userFile.Length));
				userFile.Close();
			}

			// Delete existing file
			FileInfo file = new FileInfo(Constant.ePath + obj.eObj.actualFilename);
			if (file.Exists)
			{
				try
				{
					file.Delete();
				}
				catch (Exception e)
				{
					MessageBox.Show("Unable to write to file. It is being used by another application.\n\n" + e.ToString(), "File I/O error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Close();
				}
			}

			eObject eObj = obj.toEObject();

			// Insert into DB
			dbAccess.insertLocalDB.insertToObjects(eObj);

			// Save file
			FileStream fs = new FileStream(Constant.ePath + eObj.actualFilename, FileMode.Create, FileAccess.ReadWrite);
			switch (eObj.type)
			{
				case Constant.textFile:
					obj.textbox.SaveFile(fs, RichTextBoxStreamType.RichText);
					break;
				case Constant.imageFile:
					if (obj.imageBox.BackgroundImage != null && obj.imageBox.BackgroundImage != global::eFlash.Properties.Resources.defaultImage)
					{
						obj.imageBox.BackgroundImage.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
					}
					break;
				case Constant.soundFile:
					fs.Write(data, 0, data.Length);
					obj.playerControl.setFile(Constant.ePath + eObj.actualFilename);
					break;
				default:
					throw new Exception("Invalid object type");
			}
			fs.Flush();
			fs.Close();
			fs.Dispose();

			return eObj;
		}

		/// <summary>
		/// Saves the current card. Card might not have a card ID yet. 
		/// </summary>
		/// <returns>Card ID</returns>
		private Card saveCard()
		{
			Card card = currentCard.originalCard;

			if (currentCard.cardID == -1)
			{
				card.cardID = dbAccess.insertLocalDB.insertToCards(card);
				dbAccess.insertLocalDB.insertToCDRelations(deck.id, card.cardID);
			}
			else
			{
				dbAccess.updateLocalDB.updateCards(card);
			}

			return card;
		}

		/// <summary>
		/// Saves a deck, inserting it into the DB if it doesnt already exist,
		/// or updating the DB row if it does.
		/// </summary>
		private void saveDeck()
		{
			if (deck.id == -1)
			{
				deck.id = dbAccess.insertLocalDB.insertToDecks(deck);
				if (deck.id == -1)
				{
					error("DB error: Failed to save deck");
				}
			}
			else	
			{
				dbAccess.updateLocalDB.updateDeck(deck);
			}
		}

		private bool saveAndCloseFlashcard()
		{
			if (changed || templateChanged)
			{
				string msg;

				if (currentCard.cardID == -1)
				{
					msg = "Do you want to save this new flashcard?";
				}
				else
				{
					msg = "Do you want to save the changes you made to the current flashcard?";
				}

				DialogResult result = MessageBox.Show(msg, "Save?", MessageBoxButtons.YesNoCancel);

				switch (result)
				{
					case DialogResult.Yes:
						return save();
					case DialogResult.No:
						return true;
					case DialogResult.Cancel:
						return false;
					default:
						throw new Exception("Unexpected dialog result");
				}
			}
			else
			{
				return true;
			}
		}

		private bool canSave()
		{
			foreach (CreatorObject curObj in currentCard.objects)
			{
				if (curObj.type == Constant.imageFile)
				{
					if (curObj.isDefaultImage)
					{
						MessageBox.Show("You must specify a valid image file for every image object.", "Choose an image", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						curObj.Focus();
						return false;
					}
				}
				else if (curObj.type == Constant.soundFile)
				{
					if (curObj.playerControl.filePath == "")
					{
						MessageBox.Show("You must specify a valid audio file for every audio object", "Choose an image", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						curObj.Focus();
						return false;
					}
				}
			}

			return true;
		}

		#endregion

		#region Exiting

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void LayoutEditor_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!saveAndCloseFlashcard())
			{
				e.Cancel = true;
			}
			else
			{
				e.Cancel = false;
			}
		}

		private void LayoutEditor_FormClosed(object sender, FormClosedEventArgs e)
		{
			stopAllSounds();

			if (prevWindow != null)
			{
				prevWindow.Visible = true;
			}
		}

		private void stopAllSounds()
		{
			foreach (TabPage curPage in tabSides.TabPages)
			{
				foreach (Control curControl in curPage.Controls)
				{
					((CreatorObject)curControl).playerControl.close();
				}
			}
		}

		#endregion

		#endregion

		#region Menu

		private void deleteFlashcardToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void editPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			showDeckPropertiesDialog(false);
		}

		private void tagsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			showFlashcardTagsDialog();
		}

		private void importFromFileToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		#endregion

		#region Dialogs

		private bool showDeckPropertiesDialog(bool changeType)
		{
			DeckPropertiesDialog dialog = new DeckPropertiesDialog(deck, changeType);
			dialog.ShowDialog(this);

			if (dialog.saved)
			{
				saveDeck();
				dialog.Close();
				return true;
			}
			else
			{
				dialog.Close();
				return false;
			}
		}

		private void showFlashcardTagsDialog()
		{
			(new FlashcardTagsDialog(this)).ShowDialog(this);
		}

		private void howToUseTheCreatorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string helpMsg = "";
			helpMsg += "This creator displays the cards in the current deck.\n";

			helpMsg += "\n";
			helpMsg += "Adding Content to a flashcard:\n";

			switch (deck.type)
			{
				case Constant.noQuizDeck:
					helpMsg += "To add content to the currently displayed flashcard, click and drag objects from the toolbox on the left into the flashcard. ";
					break;
				default:
					helpMsg += "To add content to the currently displayed flashcard, select a template from the list of templates on the left. This will add and position objects on the flashcard according to the template you chose. ";
					break;
			}

			helpMsg += "You can then resize and reposition these objects by clicking and dragging their borders.\n";
			helpMsg += "\n";
			helpMsg += "Navigating through the deck:\n";
			helpMsg += "You can use the navigation buttons below the flashcard to move to the previous or next flashcard, or jump to the beginning or end of the deck.\n";
			helpMsg += "To switch between displaying different sides of the flashcard, use the tabs at the top.\n";
			helpMsg += "\n";
			helpMsg += "Adding flashcards to this deck:\n";
			helpMsg += "To add new flashcards, you can use the \"Create new card\" button below the flashcard. This will create a new flashcard with the same objects as the currently displayed flashcard. ";
			helpMsg += "Additionally, you can use the \"Save and Next\" button to input data one side at a time, creating new flashcards if appropriate.\n";

			MessageBox.Show(helpMsg, "How to use the creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion

		#region Error

		private void error(string msg)
		{
			MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			this.Close();
		}

		#endregion

		#region Misc.

		/// <summary>
		/// Makes a deep copy of deck, duplicating all its cards,
		/// objects, and files, and sets it to be the current deck. 
		/// </summary>
		/// <param name="otherDeck">Deck to copy</param>
		/// <returns>Deck object of copy of deck</returns>
		private eFlash.Data.Deck deepCopy(eFlash.Data.Deck otherDeck)
		{
			otherDeck.load();

			_deck = new eFlash.Data.Deck(-1, otherDeck.type, otherDeck.category, otherDeck.subcategory, otherDeck.title, ProfileManager.getCurrentUserID(), ProfileManager.getCurrentNetID());

			// Put deck entry into DB
			saveDeck();

			Card newCard;
			eObject newObj;
			CreatorObject newCreatorObj;

			foreach (Card curCard in otherDeck.cardList)
			{
				newCard = new Card(curCard.tag, ProfileManager.getCurrentUserID());

				// Add each card to the DB
				newCard.cardID = dbAccess.insertLocalDB.insertToCards(newCard);
				dbAccess.insertLocalDB.insertToCDRelations(deck.id, newCard.cardID);

				foreach (eObject curObj in curCard.eObjectList)
				{
					newObj = new eObject(newCard.cardID, curObj.side, curObj.type, curObj.x1, curObj.x2, curObj.y1, curObj.y2, curObj.data);
					
					// Make a CreatorObject to let it load up the data file
					newCreatorObj = CreatorObject.newFromEObject(this, newObj, 0);
					newCreatorObj.initialize();
					newObj.actualFilename = newObj.generateFileName();

					// Save each object to DB and file
					saveObject(newCreatorObj);
				}
			}

			return deck;
		}

		private void updateCurCard()
		{
			int totalCards = deck.cardList.Count;
			int curCardIndex = currentCard.index;

			if (curCardIndex == -1)
			{
				lblCurCard.Text = (totalCards + 1) + " / " + totalCards + " (new)";
			}
			else
			{
				lblCurCard.Text = (curCardIndex + 1) + " / " + totalCards;
			}
		}

		public bool changingFont()
		{
			return ddlFont.Focused || ddlSize.Focused;
		}

		public bool focusedOnCanvas()
		{
			foreach (CreatorObject curObj in currentCard.objects)
			{
				if (curObj.Focused || curObj.ctlObject.Focused)
				{
					return true;
				}
			}

			return canvas.Focused;
		}

		public void selectObject(CreatorObject newObj)
		{
			selectedObject = newObj;
		}

		private void canvas_Click(object sender, EventArgs e)
		{
			canvas.Focus();
			foreach (CreatorObject curObj in currentCard.objects)
			{
				if (curObj.type == Constant.textFile)
				{
					curObj.textbox.Select(curObj.textbox.Text.Length, 0);
				}
			}
		}

		private void updateButtonStates()
		{
			if (currentCard.index == 0 || deck.cardList.Count == 0)
			{
				btnPrev.Enabled = false;
				btnFront.Enabled = false;
			}
			else
			{
				btnPrev.Enabled = true;
				btnFront.Enabled = true;
			}

			if (currentCard.index == -1 || currentCard.index == deck.cardList.Count - 1)
			{
				btnNext.Enabled = false;
				btnEnd.Enabled = false;
				
				if (currentSideIndex < tabSides.TabCount - 1)
				{
					btnSaveAndNext.Text = "Save and next side";
				}
				else	
				{
					btnSaveAndNext.Text = "Save and new flashcard";
				}
			}
			else
			{
				btnNext.Enabled = true;
				btnEnd.Enabled = true;

				if (currentSideIndex < tabSides.TabCount - 1)
				{
					btnSaveAndNext.Text = "Save and next side";
				}
				else
				{
					btnSaveAndNext.Text = "Save and next flashcard";
				}
			}
		}

		/// <summary>
		/// Creates a new Card for the current deck. Deck must already be set.
		/// </summary>
		/// <returns>A new card</returns>
		private Card newCard()
		{
			if (deck == null)
			{
				throw new Exception("Tried to create new card without specifying deck");
			}

			Card newCard = new Card("", ProfileManager.getCurrentUserID());

			return newCard;
		}

		#endregion

		#region Accessors

		public eFlash.Data.Deck deck
		{
			get
			{
				return _deck;
			}

			set
			{
				_deck = value;

				if (deck != null)
				{
					deck.load();

					if (deck.cardList.Count > 0)
					{
						setFlashcard(deck.cardList[0], 0);
					}
					else
					{
						setFlashcard(newCard(), -1);
					}
				}
			}
		}

		public CreatorCard currentCard
		{
			get
			{
				return _currentCard;
			}
		}

		#endregion

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			save();
		}
	}
}