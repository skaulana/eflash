using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using eFlash.dbAccess;
using eFlash.Data;


namespace eFlash.GUI.ViewerAndQuizzer
{
    class Quiz
    {
        public static List<string> getAnswer(List<Card> cardList)
        {
            List<string> ansList = new List<string>();
            foreach (Card card in cardList)
            {
                int cid = card.cardID;
                List<eObject> objList = selectLocalDB.getViewerObjects(cid);
                foreach (eObject obj in objList)
                {
                    if ((obj.data).IndexOf("[a]") != -1)
                    {
                        ansList.Add(obj.data);
                    }
                    else
                    {
                    }
                }
            }
            return ansList;
        }

        public static List<string> getQuestion(List<Card> cardList)
        {
            List<string> questionList = new List<string>();
            foreach (Card card in cardList)
            {
                int cid = card.cardID;
                List<eObject> objList = selectLocalDB.getViewerObjects(cid);
                foreach (eObject obj in objList)
                {
                    if ((obj.data).IndexOf("[q]") != -1)
                    {
                        questionList.Add(obj.data);
                    }
                    else
                    {
                    }
                }
            }
            return questionList;
        }

        public static string getType(List<Card> cardList)
        {
            List<string> questionList = new List<string>();
            foreach (Card card in cardList)
            {
                int cid = card.cardID;
                List<eObject> objList = selectLocalDB.getViewerObjects(cid);
                foreach (eObject obj in objList)
                {
                    if ((obj.data).IndexOf("[q]") != -1)
                    {
                        return obj.type;
                    }
                    else
                    {
                    }
                }
            }
            return "error";
        }




        public static List<List<string>> shuffle(List<string> oldArray1, List<string> oldArray2)
        {
            
            int arraySize = oldArray1.Count;
            List<string> newArray1 = new List<string>(); 
            List<string> newArray2 = new List<string>();
            bool[] used = new bool[arraySize];
            List<List<string>> results = new List<List<string>>();

            for (int j = 0; j < arraySize; j++)
            {
                used[j] = false;
            }

            Random rnd = new Random();
            int iCount = 0;
            int iNum;


            while (iCount < arraySize)
            {
                iNum = rnd.Next(0, arraySize); // between 0 and arraySize

                if (used[iNum] == false)
                {
                    newArray1.Add(oldArray1[iNum]);
                    newArray2.Add(oldArray2[iNum]);
                    used[iNum] = true;
                    iCount++;
                }
            }

            results.Add(newArray1);
            results.Add(newArray2);
            return results;
        }




    }



}
