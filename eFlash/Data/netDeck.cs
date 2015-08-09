using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using eFlash.dbAccess;
using System.Drawing;
using System.Drawing.Imaging;
namespace eFlash.Data
{
	public class netDeck : Deck
    {
        byte[] _blob;
        float _rat;
        int _num_v;
        string _date;
        Bitmap _preview;

        public netDeck(int deckID, string category, string subcategory, string title, string date, float rat, int num_v, int nuid) : base(deckID, category, subcategory, title)
        {
            this._date = date;
            this._rat = rat;
            this._num_v = num_v;
            netID = nuid;
        }

        public void loadBLOB()
        {
            _blob = remoteDB.loadNetDeck(this.id);
        }

        public byte[] getBLOB()
        {
            return _blob;
		}

        //For Download
        public void savePreview(int id)
        {
            try
            {
                _preview.Save(Constant.ePath + id + Constant.imageEXT, ImageFormat.Jpeg);
            }
            catch
            {
                //Failure saving preview, IGNORE !
                return;
            }
        }

        // For Browser Preview
        public new void loadPreview()
        {
            byte[] blob_jpg;
            MemoryStream ms;
            try
            {
                blob_jpg = remoteDB.getPreview(this.id);
                ms = new MemoryStream(blob_jpg);
                this._preview = new Bitmap(ms);
            }
            catch
            {
                //Failure loading preview, IGNORE !
                return;
            }
        }

		#region Accessors

		public byte[] blob
		{
			get
			{
				return _blob;
			}

			set
			{
				_blob = value;
			}
		}

		public float rat
		{
			get
			{
				return _rat;
			}

			set
			{
				_rat = value;
			}
		}

		public int num_v
		{
			get
			{
				return _num_v;
			}

			set
			{
				_num_v = value;
			}
		}

		public string date
		{
			get
			{
				return _date;
			}

			set
			{
				_date = value;
			}
		}

        public Bitmap preview
        {
            get
            {
                return _preview;
            }

            set
            {
                _preview = value;
            }
        }

		#endregion
	}
}
