using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using eFlash.dbAccess;

namespace eFlash.Data
{
	public class eFile
    {
         /**
         * 
         *  This class is used to encapsulate the rawData for an eObject and loading files, not to import the general .txt files 
         *  For importing a general .txt file, a new class has to be created or ...... extended
         * 
         *  Import a new eObject from filesystem to DB --> eFile file = new eFile(path of that file);
         *                                                                                                          file.loadFile();
         *                                                                                                          file.saveObj(val --> cid, side etc....) 
         * 
         * Import a new eObject from a byte[] to DB (example usage: downloading from network) 
         * --> eFile file = new eFile(byte[]);
         *       file.saveObj(val ---> cid, side etc....);
         *                                                                             
         * 
       */

        byte[] _rawData;
		string _fileName;
       

        //Create an eFile object from filesystem file , not loading the file yet
        public eFile(string filename)
        {
            _fileName = filename;
            _rawData = null;
        }

        public eFile(byte[] data)
        {
            _fileName = null;
            _rawData = data;
        }
     
            
        // Load an existing file from fileSystem 
        public void loadFile()
        {
            FileStream file;

            try
            {
                file = new FileStream(Constant.ePath + _fileName, FileMode.Open, FileAccess.Read);
                _rawData = new byte[(int)file.Length];
                file.Read(_rawData, 0, (int)file.Length);
                file.Close();
          
            }
            catch
            {
                MessageBox.Show("Error Loading " + Constant.ePath + _fileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception();
            }
        }

        //  write rawData to a file
		public void writeFile(string file)
		{

			FileStream fs;

			try
			{
				//Create the ePath , won't throw exception even if already existed
				Directory.CreateDirectory(Constant.ePath);
				//FileMode.Create overwrite if existed
				fs = new FileStream(Constant.ePath + file, FileMode.Create, FileAccess.Write);
				fs.Write(_rawData, 0, _rawData.Length);
				fs.Close();

			}
			catch
			{
				MessageBox.Show("Error Writing " + Constant.ePath + file, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				throw new Exception();
			}

		}

        //Delete the file with _fileName from filesystem(Remove DB Tuples FIRST if applicable!!)
        public static void deleteFile(string file)
        {                
            System.IO.File.Delete(Constant.ePath + file);           
            //NO Exception is thrown even file not existed
        }
    
        /*
        //save rawData to a file and update DB
        public void saveObj(string[] val)
        {
            //Using Superkey as filename
            //cid,side,x,y,width,height
            string file = val[0] + val[1] + val[3] + val[4] + val[5] + val[6];

            if (val[2].Equals(Constant.textFile))
				file += Constant.textEXT;
            else if (val[2].Equals(Constant.imageFile))
				file += Constant.imageEXT;
            else if (val[2].Equals(Constant.soundFile))
				file += Constant.soundEXT;

			writeFile(file);
			insertLocalDB.saveToDB(val, file);

		}
        */
        

		#region Accessors

        public int size
        {
            get
            {
                return rawData.Length;
            }
        }

       
		public string fileName
		{
			get
			{
				return _fileName;
			}

			set
			{
				_fileName = value;
			}
		}

		public byte[] rawData
		{
			get
			{
				return _rawData;
			}

			set
			{
				_rawData = value;
			}
		}

		#endregion


	}

}

