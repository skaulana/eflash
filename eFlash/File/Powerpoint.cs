using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Graph = Microsoft.Office.Interop.Graph;
using System.Runtime.InteropServices;
using eFlash.Data;

namespace eFlash.File
{
    class Powerpoint
    {
        PowerPoint.Application objApp;
        PowerPoint.Presentations objPresSet;
        PowerPoint._Presentation objPres;
        PowerPoint.Slides objSlides;
        PowerPoint._Slide objSlide;
        PowerPoint.TextRange objTextRng;
        //PowerPoint.Shapes objShapes;
        //PowerPoint.Shape objShape;
        //PowerPoint.SlideShowWindows objSSWs;
        //PowerPoint.SlideShowTransition objSST;
        //PowerPoint.SlideShowSettings objSSS;
        //PowerPoint.SlideRange objSldRng;
        bool bAssistantOn;
        int sCount;
        int oCount;
        
        /// <summary>
        /// Constructor that creates the PowerPoint object, so that we can add slides to it
        /// </summary>
        public Powerpoint()
        {
            String strTemplate;
            strTemplate = Constant.ePath + "eFlash.pot";
            //strTemplate = "C:\\Program Files\\eFlash\\Data\\Media\\" + "blank.pot";
            
            //Create a new presentation based on a template.
            objApp = new PowerPoint.Application();
            objApp.Visible = MsoTriState.msoTrue;
            objPresSet = objApp.Presentations;
            objPres = objPresSet.Open(strTemplate,
                MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            objSlides = objPres.Slides;

            //Prevent Office Assistant from displaying alert messages:
            bAssistantOn = objApp.Assistant.On;
            objApp.Assistant.On = false;

            //start sCount at 1
            sCount = 1;
            oCount = 1;
        }

        /// <summary>
        /// Class Destructor - turns assistant on if was on
        /// </summary>
        ~Powerpoint()
        {
            if (bAssistantOn)
            {
                objApp.Assistant.On = true;
                objApp.Assistant.Visible = false;
            }
        }

        /// <summary>
        /// Adds a new slide to presentation.
        /// </summary>
        public void AddSlide()
        {
            oCount = 1;
            objSlide = objSlides.Add(sCount++, PowerPoint.PpSlideLayout.ppLayoutBlank);
        }

        /// <summary>
        /// This method adds a Picture Object into the current slide
        /// </summary>
        /// <param name="picPath"></param>
        /// <param name="LinkToFile"></param>
        /// <param name="saveWithDocument"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void AddPic(String picPath, MsoTriState LinkToFile,
            MsoTriState saveWithDocument, float left, float top,
            float width, float height)
        {
            objSlide.Shapes.AddPicture(picPath, LinkToFile, saveWithDocument,
                left, top, width, height);
            oCount++;
        }

        /// <summary>
        /// Add text to the slide, change the font
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="fontName"></param>
        /// <param name="fontSize"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void AddText(String Text, String fontName, float fontSize, MsoTriState isBold, MsoTriState isItalic, MsoTriState isUnderlined, float left, float top,
            float width, float height)
        {
            //Add text to the slide, change the font
            objSlide.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationHorizontal, left, top, width, height);
            objTextRng = objSlide.Shapes[oCount++].TextFrame.TextRange;
            objTextRng.Text = Text;
            objTextRng.Font.Name = fontName;
            objTextRng.Font.Size = fontSize;
            objTextRng.Font.Bold = isBold;
            objTextRng.Font.Italic = isItalic;
            objTextRng.Font.Underline = isUnderlined;
        }

        /// <summary>
        /// Adds sound file
        /// </summary>
        /// <param name="soundPath"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void AddSound(String soundPath, float left, float top,
            float width, float height)
        {
            objSlide.Shapes.AddMediaObject(soundPath, left, top, width, height);
            oCount++;
        }

        /// <summary>
        /// Finishes off the Presentation (fills extra page)
        /// </summary>
        public void FinishPres()
        {
            objSlide = (Microsoft.Office.Interop.PowerPoint._Slide) objSlides._Index(sCount);
            oCount = 1;
            AddText("This deck generated by eFlash", "Comic Sans MS", 40, MsoTriState.msoTrue, MsoTriState.msoFalse, MsoTriState.msoFalse, 50, 50, 800, 150);
            AddPic(Constant.ePath + "About.png", MsoTriState.msoFalse, MsoTriState.msoTrue, 200, 200, 350, 250);
            //AddPic("C:\\Program Files\\eFlash\\Data\\Media\\About.png", MsoTriState.msoFalse, MsoTriState.msoTrue, 200, 200, 350, 250);
        }

        /// <summary>
        /// This method saves and closes the powerpoint
        /// </summary>
        /// <param name="FileName"></param>
        public void SaveAs(String FileName)
        {
            objPres.SaveAs(FileName, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsPowerPoint7, MsoTriState.msoFalse);
            objPres.Close();
            objApp.Quit();
        }

        /// <summary>
        /// This method saves and closes the powerpoint (overload 1)
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="FileFormat"></param>
        /// <param name="EmbedTrueTypeFonts"></param>
        public void SaveAs(String FileName, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType FileFormat, MsoTriState EmbedTrueTypeFonts)
        {
            objPres.SaveAs(FileName, FileFormat, EmbedTrueTypeFonts);
            objPres.Close();
            objApp.Quit();
        }
    }
}
