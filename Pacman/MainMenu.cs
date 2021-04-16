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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void ShowInstrScreen(object sender, EventArgs e)
        {
            var newForm = new InstructionsScreen();
            newForm.Show();
        }

        private void ShowGameScreen(object sender, EventArgs e)
        {
            var newForm = new GameScreen();
            newForm.Show();
        }

        private void StartButton_MouseEnter(object sender, EventArgs e)
        {
            StartButton.ForeColor = Color.Silver;
        }

        private void StartButton_MouseLeave(object sender, EventArgs e)
        {
            StartButton.ForeColor = Color.White;
        }

        private void InstrButton_MouseEnter(object sender, EventArgs e)
        {
            InstructionsButton.ForeColor = Color.Silver;
        }

        private void InstrButton_MouseLeave(object sender, EventArgs e)
        {
            InstructionsButton.ForeColor = Color.White;
        }
    }
}
