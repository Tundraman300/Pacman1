using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class GameScreen : Form
    {
        bool goup;
        bool godown;
        bool goleft;
        bool goright;

        int speed = 5;
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        private void wall22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        //Used to move pacman when a key is pressed down
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
        }

        //Used to stop pacman when a key is let up
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
        }

        //game timer
        private void gametimer_Tick(object sender, EventArgs e)
        {

            //Player movements
            if (goleft)
            {
                Pacman.Left -= speed;
            }
            if (goright)
            {
                Pacman.Left += speed;
            }
            if (godown)
            {
                Pacman.Top += speed;
            }
            if (goup)
            {
                Pacman.Top -= speed;
            }

            //adding wall functionality
            foreach (Control x in this.Controls)
            {
                if ( x is PictureBox && x.Tag == "wall")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(Pacman.Bounds))
                    {
                        goleft = false;
                        goright = false;
                        goup = false;
                        godown = false;
                    }

                }
            }
        }
    }
}
