using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using eFlash.GUI.ViewerAndQuizzer;

namespace eFlash.GUI.ViewerAndQuizzer
{
    public partial class VisualViewer : Form
    {
        int count=0;
        private Bitmap MyImage;        
        public PictureBox pictureBox1;
        string imagelocation;
        string[] testing = new string[10];
        PictureBox[] pictures = new PictureBox[10];
        public Player test = new Player();
      //  PictureBox pictureBox2;
        
        public VisualViewer()


        {
            InitializeComponent();
            imagelocation="c:\\1.JPG";
            Play.Visible = false;
            Stop.Visible = false;
            label1.Text = "name = !@!#@#12#!@$@!#%$%#$@%$#@%";
            test.Open("c:\\1.mp3");
            //pictures.add(new PictureBox());


            //pictures[1] = new PictureBox();
            //pictures[1].ImageLocation=imagelocation;
            ///pictures[1].Show();
            //pictures[1].Visible = true;
            //pictures[1].Location = new Point(1, 1);
            //pictureBox2 = new PictureBox();
           // MessageBox.Show(" i am here");
            
           // pictureBox2.ImageLocation= imagelocation;
            //pictureBox2.Image = System.Drawing.Image.FromFile(imagelocation);
            
            

        }

        private void VisualViewer_Load(object sender, EventArgs e)
        {

        }













        public void ShowMyImage(String fileToDisplay, int xSize, int ySize , PictureBox PB)
        {
            if (MyImage != null)
            {
                MyImage.Dispose();
            }
            try
            {
                // Stretches the image to fit the pictureBox.
                PB.SizeMode = PictureBoxSizeMode.StretchImage;
                MyImage = new Bitmap(fileToDisplay);
                PB.ClientSize = new Size(xSize, ySize);
                //pictureBox2.Image = System.Drawing.Image.FromFile(imagelocation);
                PB.Image = (Image)MyImage;
                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Cannot open ." );

                return;
            }


        }

        private void Next_Click(object sender, EventArgs e)
        {

            ShowMyImage(imagelocation, 200, 200, pictureBox2);
                Stop.Visible = true;
                Play.Visible = true;

                ShowMyImage("c:\\2.jpg", 200, 200, pictureBox3);



            this.pictureBox3.Location = new System.Drawing.Point(307, 94);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(111, 90);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;



        }


        private void flip_Click(object sender, EventArgs e)
        {   
            count++;
            
            if (count == 1)
                ShowMyImage(imagelocation, 200, 200,pictureBox2);
            if (count == 2)
            {
                Stop.Visible = true;
                Play.Visible = true;
            }
            if (count == 3)
                ShowMyImage("c:\\2.jpg", 200, 200, pictureBox3);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {   
            
        }

        private void Play_Click(object sender, EventArgs e)
        {


            test.Open("c:\\1.mp3");
            test.Play(true);
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            test.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

    }




}