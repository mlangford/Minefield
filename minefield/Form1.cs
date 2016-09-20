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
        }

        int atX = 10;
        int atY = 20;

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
    }
}
