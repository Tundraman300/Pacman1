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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
