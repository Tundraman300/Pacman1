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
        
        int speed;

        int redGhostSpeed;
        int orangeGhostSpeed;
        int cyanGhostSpeed;

        int score = 0;
        int lives = 3;

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
            //scores and lives
            LivesCounter.Text = "" + lives;
            ScoreCounter.Text = "" + score;

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

            //for loop to check the picture boxes
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    //checks for string data and each if statement has their own conditions
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

                            lives = lives - 1;
                            resetGame();
                        }
                    }
                    if ((string)x.Tag == "wall")
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

            //winning and losing conditions
            if (score == 1060)
            {
                youWin();
            }
            if (lives < 0)
            {
                gameOver();
            }
        }

        //A method to reset the game is used to repostion the user and ghosts after having contact the ghost
        private void resetGame()
        {
            ScoreCounter.Text = "" + score;
      
            speed = 10;

            pacman.Left = 107;
            pacman.Top = 408;

            redGhost.Left = 261;
            redGhost.Top = 375;

            cyanGhost.Left = 298;
            cyanGhost.Top = 375;

            orangeGhost.Left = 334;
            orangeGhost.Top = 375;

            //starts game
            gametimer.Start();

        }

        //A method to completely reset that game is used (once the user has used all of their lives) to reset the score, reset lives, make the pellets appear again, and reposition all characters
        private void totalResetGame()
        {
            ScoreCounter.Text = "0" + score;

            score = 0;
            lives = 3;
            speed = 10;

            pacman.Left = 107;
            pacman.Top = 408;

            redGhost.Left = 261;
            redGhost.Top = 375;

            cyanGhost.Left = 298;
            cyanGhost.Top = 375;

            orangeGhost.Left = 334;
            orangeGhost.Top = 375;

            //makes the pellets visible again
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            //starts game
            gametimer.Start();

        }

        //method for the losing condition
        private void gameOver()
        {
            gametimer.Stop();
            var theSelectedOption = MessageBox.Show("The Ghosts got you, You Lose!\n\nWould you like to try again?", "Game Over", MessageBoxButtons.YesNo);
            if(theSelectedOption == DialogResult.Yes)
            {
                totalResetGame();
            }
            if(theSelectedOption == DialogResult.No)
            {
                this.Close();
            }
        }

        //method for the winning condition
        private void youWin()
        {
            gametimer.Stop();
            var selectedOption = MessageBox.Show("Congratulations! You have collected all the pellets.\n\nWould you like to try again?", "You Win!", MessageBoxButtons.YesNo);
            if(selectedOption == DialogResult.Yes)
            {
                totalResetGame();
            }
            if(selectedOption == DialogResult.No)
            {
                this.Close();
            }
           
        }
    }
}