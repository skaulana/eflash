using System;
using System.Collections.Generic;
using System.Text;
using eFlash.dbAccess;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using eFlash.Data;
using System.Drawing;



namespace eFlash.Network
{
    class Browser
    {
        private int uid;
        private int netID;
      
        private List<Deck> localDecks;
        private List<netDeck> remoteDecks;


        public Browser(int uid, int netID)
        {
            this.uid = uid;
            this.netID = netID;
                 
        }

        public Browser(int uid)
        {
            this.uid = uid;
            this.netID = -1;
        }

        private TreeNode buildTree(TreeNode root, IEnumerator deckEnum)
        {
            int index = 0;
            TreeNode categories = null;
            string cat = "";
            
            while (deckEnum.MoveNext())
            {
                Deck curDeck = (Deck)deckEnum.Current;

                if (curDeck.category.Equals(cat) == false)
                {
                    cat = ((Deck)deckEnum.Current).category;
                    categories = new TreeNode();
                    categories.Text = cat;
                    root.Nodes.Add(categories);
                }

                //Categories must not be null now
                TreeNode title = new TreeNode();
                title.Text = curDeck.title;
                //Index is used to locate the user selected deck element later
                title.Name = Convert.ToString(index);
                categories.Nodes.Add(title);
                index++;
            }
            return root;
        }


        //GET Remote Decks belonging to current net user
        public TreeNode getUserRemoteDeckTree()
        {
            remoteDecks = remoteDB.getDecks(netID);
            TreeNode root = new TreeNode("Remote Decks");
            buildTree(root, remoteDecks.GetEnumerator());

            return root;
        }

        //GET Remote Decks belonging to all users
        public TreeNode getRemoteDeckTree()
        {            
            remoteDecks = remoteDB.getDecks(0);
            TreeNode root = new TreeNode("eFlash Network");
            buildTree(root, remoteDecks.GetEnumerator());

            return root;
        }

        public TreeNode getLocalDeckTree()
        {
            //Set localDecks FIRST !!          
            localDecks = selectLocalDB.getDecks(uid);           
            TreeNode root = new TreeNode("Local Storage");
            buildTree(root, localDecks.GetEnumerator());

            return root;           
        }
        //Ken Made -- Get Decks that are unranked
        public TreeNode getLocalUnrankedDeckTree()
        {
            //Set localDecks FIRST !!          
            localDecks = selectLocalDB.getUnrankedDecks(netID);
            TreeNode root = new TreeNode("UnRanked Decks");
            buildTree(root, localDecks.GetEnumerator());

            return root;
        }

        //Daniel made a copy of the above function to get all decks (not just uid-specific)
        public TreeNode getLocalDeckTree(int uid, int order)
        {
            TreeNode root = new TreeNode("Available Decks");

            switch (order)
            {
                case 0:
                    localDecks = selectLocalDB.getDecksOrdered(0);    //hardwired to retrieve all decks, categorically
                    buildTreeCat(root, localDecks.GetEnumerator(), uid);
                    break;
                case 1:
                    localDecks = selectLocalDB.getDecksOrdered(1);    //hardwired to retrieve all decks, alphabetically
                    buildTreeAlphaTime(root, localDecks.GetEnumerator(), uid);
                    break;
                case 2:
                    localDecks = selectLocalDB.getDecksOrdered(2);    //hardwired to retrieve all decks, timestamp
                    buildTreeAlphaTime(root, localDecks.GetEnumerator(), uid);
                    break;
                default:
                    MessageBox.Show("ListSet corrupted");
                    break;
            }

            return root;
        }

        private TreeNode buildTreeCat(TreeNode root, IEnumerator deckEnum, int id)
        {
            int index = 0;
            TreeNode categories = null;
            string cat = "";

            while (deckEnum.MoveNext())
            {
                Deck curDeck = (Deck)deckEnum.Current;

                if (curDeck.category.Equals(cat) == false)
                {
                    cat = ((Deck)deckEnum.Current).category;
                    categories = new TreeNode();
                    categories.Text = cat;
                    root.Nodes.Add(categories);
                }

                //Categories must not be null now
                TreeNode title = new TreeNode();
                title.Text = curDeck.title;
                if (id != selectLocalDB.getOwnerID(curDeck.id))
                    title.ForeColor = Color.Gray;

                //Index is used to locate the user selected deck element later
                title.Name = Convert.ToString(index);
                categories.Nodes.Add(title);
                index++;
            }
            return root;
        }

        private TreeNode buildTreeAlphaTime(TreeNode root, IEnumerator deckEnum, int id)
        {
            int index = 0;

            while (deckEnum.MoveNext())
            {
                Deck curDeck = (Deck)deckEnum.Current;

                TreeNode title = new TreeNode();
                title.Text = curDeck.title;
                if (id != curDeck.id)
                    title.ForeColor = Color.Gray;

                //Index is used to locate the user selected deck element later
                title.Name = Convert.ToString(index);
                root.Nodes.Add(title);
                index++;
            }
            return root;
        }

        //This function helps for the main menu
        //Assumption: index should be valid
        public int getDeckOwnerID(int index)
        {
            Deck deck = (Deck)localDecks[index];
            try
            {
                return selectLocalDB.getOwnerID(deck.id);
            }
            catch
            {
                MessageBox.Show("Error Retrieving Owner for " + deck.title + "!!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public void uploadRank(int index, int rank)
        {
            Deck deck;
            int remoteDeck;
            double remoteDeckAve;
            try
            {

                deck = (Deck)localDecks[index];
                remoteDeck = selectLocalDB.getRemoteDeck(deck.id);
                remoteDB.insertRank(remoteDeck, netID, rank);
                remoteDeckAve = remoteDB.getRemoteDeckRankAve(remoteDeck);
                remoteDB.updateDeckRankAve(remoteDeck,remoteDeckAve);
                deleteLocalDB.deleteUnRanked(deck.id);
            }
            catch
            {
                MessageBox.Show("Failure Ranking Deck !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(deck.title + " Ranked Successfully !!!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Assumption: index should be valid
        public void upload(int index)
        {
           
            Deck deck;
            byte[] netBLOB;
            Card curCard;
            eObject curObj;
            List<Card> cardList;
            List<eObject> eObjectList;
            IEnumerator cardEnum;
            IEnumerator objEnum;

            try
            {
                //Load the selected deck
                deck = (Deck)localDecks[index]; deck.loadCards();
                cardList = deck.cardList;
                cardEnum = cardList.GetEnumerator();


                while (cardEnum.MoveNext())
                {
                    //Load the cards belonging to this deck
                    curCard = (Card)cardEnum.Current; curCard.loadObjectList();
                    eObjectList = curCard.eObjectList;
                    objEnum = eObjectList.GetEnumerator();
                    while (objEnum.MoveNext())
                    {
                        //Load the objects belonging to this card
                        curObj = (eObject)objEnum.Current;
                     
                            curObj.loadData();
                                      
                    }
                }

           
                //Build the net BLOB object, we don't need to undo anything if exception occurs cuz everything is working in Memory
                netBLOB = Util.buildNetBLOB(deck, netID);

                //Save to remote DB
                // cat , subcat , title , date , rat , num_v , nuid
                string[] val = new string[7];
                val[0] = deck.category;
                val[1] = deck.subcategory;
                val[2] = deck.title;
                val[6] = Convert.ToString(netID);
                /******** HARD CODED FOR NOW *********/
                val[3] = "CURDATE( )";
                val[4] = "0";
                val[5] = "0";
                /**********************************************/
                //If Exception occurs, saveToDB will throw an exception
                remoteDB.saveToDB(netBLOB, val, Util.bmpTobin(deck.loadPreview()));
            }
            catch
            {
                MessageBox.Show("Failure Uploading Deck !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(deck.title + " Uploaded Successfully !!!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Assumption: index should be valid
        public void download(int index)
        {
            int curDid;
            netDeck deck = (netDeck)remoteDecks[index];
            try
            {                
                deck.loadBLOB();                
            }
            catch
            {
                MessageBox.Show("Failure Downloading Deck !!!", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                curDid = Util.parseBLOB(deck.getBLOB(), uid);
                insertLocalDB.insertToUnranked(curDid,deck.id,netID,deck.netID);
                deck.savePreview(curDid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Reading Malformed Deck !!!" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            MessageBox.Show(deck.title + " Downloaded Successfully !!!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Assumption: index should be valid
        public netDeck downloadPreview(int index)
        {
            netDeck deck = (netDeck)remoteDecks[index];
            try
            {
                deck.loadPreview();
                return deck;
            }
            catch
            {
                return null;
            }
        }

        public netDeck downloadRankerPreview(int index)
        {
            Deck deck = (Deck)localDecks[index];
            int remoteDeck = selectLocalDB.getRemoteDeck(deck.id);
            netDeck ndeck = remoteDB.getSpecificDeck(remoteDeck);
            try
            {
                ndeck.loadPreview();
                return ndeck;
            }
            catch
            {
                return null;
            }
        }

        //Assumption: index should be valid
        public void delRemote(int index)
        {
            netDeck deck = (netDeck)remoteDecks[index];
            try
            {
                remoteDB.deleteDeck(deck.id);
            }
            catch
            {
                MessageBox.Show("Error Deleting " +deck.title + "!!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(deck.title+ " Deleted Successfully !!!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Assumption: index should be valid
        public void delLocal(int index)
        {
            Deck deck = (Deck)localDecks[index];
            List<eFile> eFileList;
            try
            {
                //Load File List first
                eFileList = selectLocalDB.loadFileName(deck.id);
                //Delete DB enties
                deleteLocalDB.deleteDeck(deck.id);
                foreach (eFile file in eFileList)
                    eFile.deleteFile(file.fileName);
                               
            }
            catch
            {
                MessageBox.Show("Error Deleting " + deck.title + "!!!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(deck.title + " Deleted Successfully !!!", "Success",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		//Assumption: index should be valid
		public eFlash.Data.Deck getDeck(int index)
		{
			return localDecks[index];
		}


        public TreeNode search(string str, string opt)
        {
            string[] searchStr = str.Split(Constant.delimiter, StringSplitOptions.RemoveEmptyEntries);

            if (searchStr.Length == 0)
                return getRemoteDeckTree();

            remoteDecks = remoteDB.searchDeck(searchStr, opt);
            TreeNode root = new TreeNode("Matched Decks");
            buildTree(root, remoteDecks.GetEnumerator());
            
            return root;
        }
    }
}
