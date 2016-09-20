using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minefield
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //place the sprite at its start-up location
            drawspite(atX, atY);

            //make bombs
            placeBombs(80);
        }

        //global variables traking current position of sprite
        int atX = 10;
        int atY = 20;

        //a Boolean array that indicates where the mines are!
        bool[,] bombs = new bool[21, 21];

        //function to return the Label at location (x,y)
        private Label getLabel(int x, int y)
        {
            int k = (y - 1) * 20 + x;
            string s = "label" + k.ToString();

            foreach (Control c in panel1.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.Label))
                {
                    if (c.Name == s)
                    {
                        return (Label)c;
                    }
                }
            }
            return null;
        }

        //function to draw the sprite at location (x,y)
        private void drawspite(int x, int y)
        {
            Label lbl = getLabel(atX, atY);
            lbl.BackColor = Color.White;
            lbl.Image = Properties.Resources.w;
        }

        //function to undraw the sprite at location (x,y)
        private void wipespite(int x, int y)
        {
            Label lbl = getLabel(atX, atY);
            lbl.Image = null;
        }


        private void btnUp_Click(object sender, EventArgs e)
        {
            //if allowed, update location
            if (atY > 1)
            {
                //delete sprite at current location
                wipespite(atX, atY);
                //move up by one row
                atY--;
                //draw sprite at current location
                drawspite(atX, atY);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //if allowed, update location
            if (atY < 20 )
            {
                //delete sprite at current location
                wipespite(atX, atY);
                //move up by one row
                atY++;
                //draw sprite at current location
                drawspite(atX, atY);
            }
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            //if allowed, update location
            if (atX < 20)
            {
                //delete sprite at current location
                wipespite(atX, atY);
                //move up by one row
                atX++;
                //draw sprite at current location
                drawspite(atX, atY);
            }
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            //if allowed, update location
            if (atX > 1)
            {
                //delete sprite at current location
                wipespite(atX, atY);
                //move up by one row
                atX--;
                //draw sprite at current location
                drawspite(atX, atY);
            }
        }

        private void btnFlash_Click(object sender, EventArgs e)
        {
            showBombs();
        }

        //place those mines
        private void placeBombs(int target)
        {
            //create a random number generator
            Random r = new Random();

            //set up variables
            int x;
            int y;
            int k = target;

            //clear the current mines list
            Array.Clear(bombs, 0, bombs.Length);

            //loop to fill with desired number of mines
            do
            {
                x = r.Next(1, 20);
                y = r.Next(1, 20);
                if (!bombs[x, y])
                {
                    bombs[x, y] = true;
                    k--;
                }
            } while (k > 0);
        }

        //show the bombs!!
        private void showBombs()
        {
            Label lbl;
            for (int y = 1; y < 21; y++)
            {
                for (int x = 1; x < 21; x++)
                {
                    lbl = getLabel(x,y);
                    if (bombs[x, y])
                    {
                        lbl.BackColor = Color.Yellow;
                    }
                    else
                    {
                        lbl.BackColor = Color.DarkGray;
                    }
                }
            }
        }

    }
}
