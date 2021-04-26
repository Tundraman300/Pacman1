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
        bool cangoup;
        bool cangodown;
        bool cangoleft;
        bool cangoright;
        
        int speed;

        int ghostSpeed = 4;

        int score = 0;
        int lives = 3;
        int timeLeft = 8;

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
                pacman.Image = Pacman.Properties.Resources.pacmanLeft;
                goright = goup = godown = false;
                    if(cangoleft == true)
                    {
                        goleft = true;
                    //Portal to the other side
                    if (pacman.Left <= 36)
                    {
                        pacman.Left = 582;
                    }
                }
                    
                }
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                pacman.Image = Pacman.Properties.Resources.pacman;
                goleft = goup = godown = false;
                    if (cangoright)
                    {
                        goright = true;
                    //Portal to the other side
                    if (pacman.Left >= 582)
                    {
                        pacman.Left = 36;
                    }
                }
                }
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                pacman.Image = Pacman.Properties.Resources.pacmanUp;
                goright = goleft = godown = false;
                    if (cangoup)
                    {
                        goup = true;
                    }
                }
                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                pacman.Image = Pacman.Properties.Resources.pacmanDown;
                goright = goleft = goup = false;
                    if (cangodown)
                    {
                        godown = true;
                    }
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
            //redGhost.Image = Pacman.Properties.Resources.redGhost3;
            //orangeGhost.Image = Pacman.Properties.Resources.OrangeGhost;
            //cyanGhost.Image = Pacman.Properties.Resources.CyanGhost;

            //scores and lives
            LivesCounter.Text = "" + lives;
            ScoreCounter.Text = "" + score;

            //Player movements
            if (goleft)
            {
                pacman.Left -= speed;
                cangoup = true;
                cangoright = true;
                cangodown = true;
                cangoleft = true;
            }
            if (goright)
            {
                pacman.Left += speed;
                cangoup = true;
                cangoright = true;
                cangodown = true;
                cangoleft = true;
            }
            if (godown)
            {
                pacman.Top += speed;
                cangoup = true;
                cangoright = true;
                cangodown = true;
                cangoleft = true;
            }
            if (goup)
            {
                pacman.Top -= speed;
                cangoup = true;
                cangoright = true;
                cangodown = true;
                cangoleft = true;
            }

            //Moves ghosts.
            moveGhost(redGhost);
            moveGhost(orangeGhost);
            moveGhost(cyanGhost);

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
                            timeLeft = 8;

                            timer1.Start();

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
                    //Checks if there is a wall and stops Pacman
                    if ((string)x.Tag == "wall")
                    {
                        if (goleft == true && pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            goleft = false;
                            cangoleft = false;

                           
                        }

                        if (goright == true && pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            goright = false;
                            cangoright = false;


                        }

                        if (goup == true && pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            goup = false;
                            cangoup = false;


                        }

                        if (godown == true && pacman.Bounds.IntersectsWith(x.Bounds))
                        {
                            godown = false;
                            cangodown = false;

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

        // Method for moving a ghost towards pacman.
        private void moveGhost (PictureBox ghost) {

            string ghostDirection = findGhostMove(ghost.Location);

            // Move the ghost according to found direction.
                        if (ghostDirection == "left")
                        {
                            ghost.Left -= ghostSpeed;


                        }
                        if (ghostDirection == "right")
                        {
                            ghost.Left += ghostSpeed;

                        }
                        if (ghostDirection == "down")
                        {
                            ghost.Top -= ghostSpeed;


                        }
                        if (ghostDirection == "up")
                        {
                            ghost.Top += ghostSpeed;

                        }
        }

            // Method for finding the direction to move a ghost.
            private string findGhostMove(Point ghostLocation) {
                string direction;
                double xDiff = pacman.Location.X - ghostLocation.X;
                double yDiff = pacman.Location.Y - ghostLocation.Y;

            if (Math.Abs(xDiff) >= Math.Abs(yDiff))
            {
                // Distance to pacman is farther in the x direction than the y direction.
                if (xDiff >= 0)
                {
                    // Pacman is to the right.
                    direction = "right";
                }
                else
                {
                    // Pacman is to the left.
                    direction = "left";
                }
            }
            else {
                if (yDiff >= 0)
                {
                    // Pacman is above.
                    direction = "up";
                }
                else
                {
                    // Pacman is below.
                    direction = "down";
                }
            }

            return direction;
        }

        //A method to reset the game is used to repostion the user and ghosts after having contact the ghost
        private void resetGame()
        {
            timer1.Stop();

            redGhost.Image = Pacman.Properties.Resources.redGhost3;
            orangeGhost.Image = Pacman.Properties.Resources.OrangeGhost;
            cyanGhost.Image = Pacman.Properties.Resources.CyanGhost;

            ScoreCounter.Text = "" + score;
      
            speed = 10;
            ghostSpeed = 4;


            pacman.Left = 301;
            pacman.Top = 535;

            cangoup = true;
            cangodown = true;
            cangoright = true;
            cangoleft = true;

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

            //redGhost.Image = Pacman.Properties.Resources.redGhost3;
            //orangeGhost.Image = Pacman.Properties.Resources.OrangeGhost;
            //cyanGhost.Image = Pacman.Properties.Resources.CyanGhost;

            ScoreCounter.Text = "0" + score;

            score = 0;
            lives = 3;
            speed = 10;
            ghostSpeed = 4;

            pacman.Left = 301;
            pacman.Top = 535;

            cangoup = true;
            cangodown = true;
            cangoright = true;
            cangoleft = true;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            redGhost.Image = Pacman.Properties.Resources.vulnerableGhost;
            orangeGhost.Image = Pacman.Properties.Resources.vulnerableGhost;
            cyanGhost.Image = Pacman.Properties.Resources.vulnerableGhost;

            if(timeLeft > 0)
            {
                
                timeLeft = timeLeft - 1;
                
            }
            else
            {
                redGhost.Image = Pacman.Properties.Resources.redGhost3;
                orangeGhost.Image = Pacman.Properties.Resources.OrangeGhost;
                cyanGhost.Image = Pacman.Properties.Resources.CyanGhost;
            }
        }
    }
}