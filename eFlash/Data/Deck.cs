using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using eFlash.dbAccess;
using eFlash.Utilities;
using System.Drawing;
using System.Drawing.Imaging;
namespace eFlash.Data
{
    public class Deck
    {
        int _id;
        string _category;
        string _subcategory;
        string _title;
		string _type;
        int _uid;
        int _netID;
        List<Card> _cardList;

		public Deck()
		{
			_id = -1;
			_category = null;
			_subcategory = null;
			_title = null;
			_type = null;
			_uid = 0;
			_netID = 0;
			_cardList = new List<Card>();
		}

        public Deck(string category, string subcategory, string title, string type, int netID, int uid)
        {
            this._uid = uid;
            this._netID = netID;
            this._category = category;
            this._subcategory = subcategory;
			this._title = title;
            this._type = type;
            _cardList = new List<Card>();     
        }

		// WARNING: This constructor doesn't take a "Type" argument,
		// and is currently setting type to null. This can result in 
		// exceptions when trying to insert this deck bacx into the DB
        public Deck(int deckID, string category, string subcategory, string title) : this(deckID, null, category, subcategory, title, 0, 0) { }

		public Deck(int newID, string newType, string newCat, string newSubcat, string newTitle, int newUID, int newNetID)
		{
			id = newID;
			_type = newType;
			_category = newCat;
			_subcategory = newSubcat;
			_title = newTitle;
			_uid = newUID;
			_netID = newNetID;
			_cardList = new List<Card>();
		}

		/// <summary>
		/// Loads all cards and their objects belonging to this deck.
		/// </summary>
		public void load()
		{
			loadCards();

			foreach (Card curCard in cardList)
			{
				curCard.loadObjectList();
			}
		}

        // Load flashcards belonging to this deck into the Card List from Local DB
        public void loadCards()
        {
            _cardList = selectLocalDB.getCards(id);
        }
        

        public int saveToDB()
        {
            int curDid;
            // Create the value string for the database
            string[] values = new string[6];
            values[0] = this._category;
            values[1] = this._subcategory;
            values[2] = this._title;
            values[3] = this._type;
            values[4] = Convert.ToString(this._uid);
            values[5] = Convert.ToString(this._netID);

            // Use insert function the DBAccess
            curDid = insertLocalDB.insertToDecks(values);


            return curDid;
		}


        //For Creator
        public void savePreview(System.Windows.Forms.Control ctl)
        {
            try
            {
				Bitmap preview = Capture.Control(ctl, true, false);
				preview.Save(Constant.ePath + this._id + Constant.imageEXT, ImageFormat.Jpeg);
				preview.Dispose();
            }
            catch
            {
                //Failure saving preview, IGNORE !
                return;
            }
        }


        // For network Upload
        public Bitmap loadPreview()
        {
            try
            {   
                return  new Bitmap(Constant.ePath + this._id + Constant.imageEXT);
            }           
            catch
            {                
                //Failure loading preview, IGNORE !
                return null;
            }
        }

		#region Accessors

		public int id
		{
			get
			{
				return _id;
			}

			set
			{
				_id = value;
			}
		}

		public string type
		{
			get 
			{
				return _type;
			}

			set
			{
				_type = value;
			}
		}

		public string category
		{
			get
			{
				return _category;
			}

			set
			{
				_category = value;
			}
		}

		public string subcategory
		{
			get
			{
				return _subcategory;
			}

			set
			{
				_subcategory = value;
			}
		}

		public string title
		{
			get
			{
				return _title;
			}

			set
			{
				_title = value;
			}
		}

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

		public int netID
		{
			get
			{
				return _netID;
			}

			set
			{
				_netID = value;
			}
		}

        public List<Card> cardList
		{
			get
			{
                return _cardList;
			}

			set
			{
                _cardList = value;
			}
		}


		#endregion
	}
}
