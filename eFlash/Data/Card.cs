using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using eFlash.dbAccess;

namespace eFlash.Data
{
	public class Card
    {
		int _uid;
        int _cardID;
        string _tag;
        List<eObject> _eObjectList;

        public Card( string tag, int uid) : this(-1, tag, uid) { }

        public Card(int cid, string tag, int uid)
        {
            this._cardID = cid;
            this._tag = tag;
            this._uid = uid;
            _eObjectList = new List<eObject>();
        }

        

        public void addObject(eObject obj)
        {
            _eObjectList.Add(obj);
        }

       

        //Load eObjects belonging to this card (not loading in data) from local DB
        // To load data for an eObject a, use a.loadData() 
        public void loadObjectList()
        {
            _eObjectList = selectLocalDB.getObjects(_cardID);
        }

        public eObject getObj(int x1, int y1, int x2, int y2, int side)
        {
           
           IEnumerator list = _eObjectList.GetEnumerator();

            //Search for the specific object
           while(list.MoveNext()) 
            {
                if (((eObject)list.Current).x1== x1 
                    && ((eObject)list.Current).y1 == y1
                    && ((eObject)list.Current).x2 == x2
                    && ((eObject)list.Current).y2== y2
                    && ((eObject)list.Current).side == side)
                    return (eObject)list.Current;                
            }
            return null;
        }


        /**
         * Insert Card to Cards Table. 
         * If this card is not associated with any deck, pass did = -1 as argument
         * Otherwise it will also associate this card with the given did in CDRelation Table
        */
        public int saveToDB(int did)
        {
          
            // Create the value string for database
            string[] values = new string[2];
            values[0] = this._tag;
            values[1] = Convert.ToString(this._uid);

            try
            {
                // Insert to Card Table and get the card ID
                _cardID = insertLocalDB.insertToCards(values);

                if (did != -1)
                {
                    // Insert to CDRelations Table 
                    insertLocalDB.insertToCDRelations(did, _cardID);
                }
                return _cardID;
            }
            catch 
            {
                if (did != -1)
                {
                    //Delete the deck and card just inserted, CDRelations should be cascade deleted
                    deleteLocalDB.deleteDeck(did);
                }
                else
                {
                    //Delete the card ONLY !!
                    deleteLocalDB.deleteCard(_cardID);
                }
                throw new Exception();
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

        public List<eObject> eObjectList
		{
			get
			{
				return _eObjectList;
			}
		}


		#endregion
	}
}
