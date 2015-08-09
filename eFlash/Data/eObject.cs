using System;
using System.Collections.Generic;
using System.Text;
using eFlash.dbAccess;

namespace eFlash.Data
{
	public class eObject
	{
		int _cid;
        int _x1;
		int _y1;
		int _x2;
		int _y2;
		int _side;		
        eFile _efile;
		string _type;
        string _data;
		string _actualFilename;
		string _quizType;

		public eObject() : this(-1, -1, Constant.textFile, -1, -1, -1, -1, Constant.nonePrefix) { }

        /***********
         *     For ALL constructors, must accept cid as argument since we don't allow orphan objects
         * 
         */

		public eObject(int cid, int side, string type, int x1, int x2, int y1, int y2)
        {
            this._cid = cid;
            this._x1 = x1;
            this._x2 = x2;
            this._y1 = y1;
            this._y2 = y2;
            this._side = side;
            this._type = type;
			data = "[n]noFile";

        }
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		/// <param name="that">eObject to copy</param>
		public eObject(eObject that)
			: this(that.cid, that.side, that.type, that.x1, that.x2, that.y1, that.y2, that.data) { }
       
        public eObject(int cid, int side, string type, int x1, int x2, int y1, int y2, string fileName)
        {
            this._cid = cid;
            this._x1 = x1;
            this._x2 = x2;
            this._y1 = y1;
            this._y2 = y2;
            this._side = side;
            this._type = type;
			this._data = fileName;
			this._quizType = data.Substring(0, 3);
			this._actualFilename = data;
            _efile = new eFile(fileName);
        }

        public eObject(string viewer, int cid, int side, string type, int x1, int x2, int y1, int y2, string fileName)
        {
            this._cid = cid;
            this._x1 = x1;
            this._x2 = x2;
            this._y1 = y1;
            this._y2 = y2;
            this._side = side;
            this._type = type;
            this._data = fileName;
            _efile = new eFile(fileName);
        }
        
        
        /**
         * _efile must have been previously assigned 
         * Will throw Exception if error reading file
         */
        public void loadData()
        {
                _efile.loadFile();     
        }


        /**
         *  This method will 
         * 1.Store the (byte[]) rawData of an eFile associated with this Object
         *     into a file using the superkey of this Object as filename
         * 2. Insert the Object into local DB
         */

        public void save()
        {
            string[] values = new string[12];
            values[0] = Convert.ToString(_cid);
            values[1] = Convert.ToString(_side);
            values[2] = _type;
            values[3] = Convert.ToString(_x1);
            values[4] = Convert.ToString(_x2);
            values[5] = Convert.ToString(_y1);
            values[6] = Convert.ToString(_y2);           
            values[7] = this.ToString();

            try
            {
                //Save to File System
                _efile.writeFile(this.ToString());
                //Save to Local DB
                insertLocalDB.insertToObjects(values);
            }
            catch
            {               
                /**
                 *   Note that No rollback for Deck, Card, CDRelation even fail to insert Object
                 *   Cuz this may be only one of the so many objects being inserted, we better keep other objects
                 */
                //Remove the Object from Local DB
                deleteLocalDB.deleteObject(_cid, _side, _x1, _x2, _y1, _y2);
                //Remove from File System
                eFile.deleteFile(this.ToString());               
                throw new Exception();
            }
        }

        public override String ToString()
        {
            string eName = Convert.ToString(quizType) + Convert.ToString(cid) + "_" + Convert.ToString(side) + "_" + Convert.ToString(x1) + "_" +
                Convert.ToString(x2) + "_" + Convert.ToString(y1) + "_" + Convert.ToString(y2);
            if (type.Equals(Constant.textFile))
                eName += Constant.textEXT;
            else if (type.Equals(Constant.imageFile))
                eName += Constant.imageEXT;
            else if (type.Equals(Constant.soundFile))
                eName += Constant.soundEXT;
            return eName;
        }
    
        public string generateFileName()
		{
			return this.ToString();
		}

		#region Accessors

		public int cid
		{
			get
			{
				return _cid;
			}

			set
			{
				_cid = value;
			}
		}

		public int x1
		{
			get
			{
				return _x1;
			}

			set
			{
				_x1 = value;
			}
		}

		public int y1
		{
			get
			{
				return _y1;
			}

			set
			{
				_y1 = value;
			}
		}

		public int x2
		{
			get
			{
				return _x2;
			}

			set
			{
				_x2 = value;
			}
		}

		public int y2
		{
			get
			{
				return _y2;
			}

			set
			{
				_y2 = value;
			}
		}

		public int side
		{
			get
			{
				return _side;
			}

			set
			{
				_side = value;
			}
		}

		

        public eFile efile
		{
			get
			{
				return _efile;
			}

			set
			{
                _efile = value;
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

		public string data
		{
			get
			{
				return _data;
			}

			set
			{
				_data = value;
				_quizType = data.Substring(0, 3);
				_actualFilename = data;
			}
		}

		public string actualFilename
		{
			get
			{
				return _actualFilename;
			}

			set
			{
				data = value;
			}
		}

		public string quizType
		{
			get
			{
				return _quizType;
			}

			set
			{
				data = value + data.Substring(3);
			}
		}

		

		#endregion
	}
}
