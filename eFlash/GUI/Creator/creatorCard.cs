using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using eFlash.Data;

namespace eFlash.GUI.Creator
{
	public class CreatorCard
	{
		public LayoutEditor creator;

		private int _cardID;
		private int _uid;
		private string _tag;
		private List<CreatorObject> _objects;
		public int index;

		public Card originalCard;

		#region Constructors

		public CreatorCard(LayoutEditor newCreator, Card card, int newIndex)
			: this(newCreator, card.cardID, card.uid, card.tag, card.eObjectList, newIndex)
		{
			originalCard = card;
		}

		private CreatorCard(LayoutEditor newCreator, int newCardID, int newUID, string newTag, List<eObject> newObjects, int newIndex)
		{
			_cardID = newCardID;
			_uid = newUID;
			_tag = newTag;
			_objects = new List<CreatorObject>();
			index = newIndex;
			creator = newCreator;

			originalCard = null;

			CreatorObject curNewObj;

			foreach (eObject curEObj in newObjects)
			{
				curNewObj = CreatorObject.newFromEObject(creator, curEObj, (objects.Count * 2) + 10);

				objects.Add(curNewObj);
			}
		}

		#endregion

		public void loadObjects(TabControl tabs)
		{
			CreatorObject curObj;
			HorizontalAlignment alignment;
			System.Drawing.Color color;
			Font font;

			objects.Clear();

			foreach (TabPage curPage in tabs.TabPages)
			{
				foreach (Control curControl in curPage.Controls)
				{
					curObj = (CreatorObject) curControl;

					if (curObj.type == Constant.textFile)
					{
						curObj.textbox.Select(0, 0);

						alignment = curObj.textbox.SelectionAlignment;
						color = curObj.textbox.SelectionColor;
						font = curObj.textbox.SelectionFont;

						curObj.textbox.Clear();

						curObj.textbox.SelectionAlignment = alignment;
						curObj.textbox.SelectionColor = color;
						curObj.textbox.SelectionFont = font;
						curObj.textbox.Font = font;
					}
					else if (curObj.type == Constant.imageFile)
					{
						curObj.resetImage();
					}
					else if (curObj.type == Constant.soundFile)
					{
						curObj.playerControl.resetFile();
					}

					curObj.eObj = new eObject(cardID, curObj.eObj.side, curObj.eObj.type, curObj.eObj.x1, curObj.eObj.x2, curObj.eObj.y1, curObj.eObj.y2, curObj.eObj.quizType);
					
					objects.Add(curObj);
				}
			}
		}

		#region Accessors

		public int uid
		{
			get
			{
				return _uid;
			}

			set
			{
				_uid = value;
			}
		}

		public int cardID
		{
			get
			{
				return _cardID;
			}

			set
			{
				_cardID = value;
			}
		}

		public string tag
		{
			get
			{
				return _tag;
			}

			set
			{
				_tag = value;
			}
		}

		public List<CreatorObject> objects
		{
			get
			{
				return _objects;
			}
		}
		
		#endregion
	}
}
