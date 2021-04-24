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
        bool theGameIsOver;

        int speed;

        int redGhostSpeed = 8;
        int orangeGhostSpeed = 8;
        int cyanGhostSpeed = 8;

        int score = 0;

        public GameScreen()
        {
            InitializeComponent();
            resetGame();
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

            ScoreCounter.Text = "" + score;

            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goright = true;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                godown = true;
            }

            //Player movements
            if (goleft)
            {
                pacman.Left -= speed;
            }
            if (goright)
            {
                pacman.Left += speed;
            }
            if (godown)
            {
                pacman.Top += speed;
            }
            if (goup)
            {
                pacman.Top -= speed;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "pellet" && x.Visible == true)
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score = score + 10;
                            x.Visible = false;

                        }
                    }
                    if ((string)x.Tag == "superPellet" && x.Visible == true)
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            score = score + 50;
                            x.Visible = false;

                        }
                    }

                    if ((string)x.Tag == "ghost")
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))
                        {

                            gameOver();
                        }
                    }
                }
            }
            if (score == 1080)
            {
                youWin();
            }

        }

        //Used to stop pacman when a key is let up
        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                godown = false;
            }
        }


        //game timer
        private void gametimer_Tick(object sender, EventArgs e)
        {


            //adding wall functionality
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "wall")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                        {
                        goleft = false;
                        goright = false;
                        goup = false;
                        godown = false;
                    }
                }
            }
        }

        private void resetGame()
        {
            ScoreCounter.Text = "0" + score;

            score = 0;

            speed = 5;

            theGameIsOver = false;


            pacman.Left = 107;
            pacman.Top = 408;

            redGhost.Left = 261;
            redGhost.Top = 375;

            cyanGhost.Left = 298;
            cyanGhost.Top = 375;

            orangeGhost.Left = 334;
            orangeGhost.Top = 375;

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            gametimer.Start();

        }

        private void gameOver()
        {
            theGameIsOver = true;
            gametimer.Stop();
            MessageBox.Show("The Ghosts got you, You Lose!", "Game Over");
        }

        private void youWin()
        {
            theGameIsOver = true;
            gametimer.Stop();
            MessageBox.Show("Congratulations! You have collected all the pellets.", "You Win!");
           
        }
    }
}