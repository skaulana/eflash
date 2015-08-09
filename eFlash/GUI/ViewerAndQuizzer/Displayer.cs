using System;
using System.Collections.Generic;
using System.Text;
using eFlash.Data;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;




namespace eFlash.GUI.ViewerAndQuizzer
{
    class Displayer
    {

        public static void display(eObject obj, Panel panel)
        {
            switch (obj.type)
            {
                case Constant.textFile:
                    initText(obj, panel);
                    break;
                case Constant.imageFile:
                    initImage(obj, panel);
                    break;
                case Constant.soundFile:
                    initSound(obj, panel);
                    break;
                default:
                    throw new ArgumentException("Invalid CreatorObject type: " + obj.type);
            }
        }

        public static void initText(eObject obj, Panel panel)
        {

            int Left = obj.x1*Constant.cardWidth/100;
            int Top = obj.y1*Constant.cardHeight/100;
            int Width = (obj.x2-obj.x1)* Constant.cardWidth/100;
            int Height = (obj.y2-obj.y1)*Constant.cardHeight/100;
           
            string textToDisplay = obj.data;
            RichTextBox txtText=new RichTextBox();
            try
            {
                txtText.LoadFile(Constant.ePath + textToDisplay, RichTextBoxStreamType.RichText);
            }
            catch (Exception e)
            {
                MessageBox.Show("file not found");
            }
            txtText.Location = new System.Drawing.Point(Left, Top);
            txtText.ReadOnly = true;
            txtText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            txtText.Size = new System.Drawing.Size(Width, Height);
            txtText.TabStop = false;
            txtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtText.BackColor = System.Drawing.Color.White;
            txtText.DetectUrls = false;

            panel.Controls.Add(txtText);

        }

        
        public static void initImage(eObject obj, Panel panel )
        {
            int Left = obj.x1 * Constant.cardWidth / 100;
            int Top = obj.y1 * Constant.cardHeight / 100;
            int Width = (obj.x2 - obj.x1) * Constant.cardWidth / 100;
            int Height = (obj.y2 - obj.y1) * Constant.cardHeight / 100;
           
            string fileToDisplay = obj.data;
            PictureBox pictureBox = new PictureBox();

            //set up picturebox
            pictureBox.Location = new System.Drawing.Point(Left, Top);
            pictureBox.Size = new System.Drawing.Size(Width, Height);
            pictureBox.TabStop = false;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BorderStyle = BorderStyle.None;
            pictureBox.Visible = true;
            panel.Controls.Add(pictureBox);
            //pictureBox.Show();

            

            try
            {
                // Stretches the image to fit the pictureBox.
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                Bitmap MyImage = new Bitmap(Constant.ePath+fileToDisplay);
                pictureBox.ClientSize = new Size(Width, Height);
                pictureBox.Image = (Image)MyImage;
            }
            catch (Exception exc)
            {
                //MessageBox.Show("Cannot Open");

               
            }

        }

        public static void initSound(eObject obj, Panel panel)
        {

            int Left = obj.x1 * Constant.cardWidth / 100;
            int Top = obj.y1 * Constant.cardHeight / 100;
            int Width = (obj.x2 - obj.x1) * Constant.cardWidth / 100;
            int Height = (obj.y2 - obj.y1) * Constant.cardHeight / 100;

            string fileToPlay = obj.data;
            Player player = new Player();
            PlayButton newButton = new PlayButton(fileToPlay,player,fileToPlay);


            newButton.Text = "PLAY";
            newButton.Location = new System.Drawing.Point(Left, Top);
            newButton.Size = new System.Drawing.Size(Height, Width);
            panel.Controls.Add(newButton);
            newButton.Click += new EventHandler(newButton_Click);

        }

        static void newButton_Click(object sender, EventArgs e)
        {
            Player player = ((PlayButton) sender).player;
            if (((PlayButton) sender).isPlaying)
            { 
                ((PlayButton) sender).isPlaying = false;
                player.Close(((PlayButton)sender).alias);
                ((PlayButton)sender).Text = "PLAY";
                
            }
            else
            {
                player.Open(Constant.ePath + ((PlayButton)sender).fileToPlay, ((PlayButton)sender).alias);
                player.Play(true, ((PlayButton)sender).alias);
                ((PlayButton) sender).isPlaying = true;
                ((PlayButton) sender).Text = "STOP";
            }
        }

        static void Displayer_ControlRemoved(object sender, ControlEventArgs e)
        {
            ((PlayButton)sender).isPlaying = false;
            ((PlayButton)sender).player.Close(((PlayButton)sender).alias);
        }

            

    }
}
