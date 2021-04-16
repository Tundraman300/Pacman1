
namespace Pacman
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartButton = new System.Windows.Forms.Button();
            this.InstructionsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.AutoSize = true;
            this.StartButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.ForeColor = System.Drawing.Color.White;
            this.StartButton.Location = new System.Drawing.Point(348, 523);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(135, 65);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.ShowGameScreen);
            this.StartButton.MouseEnter += new System.EventHandler(this.StartButton_MouseEnter);
            this.StartButton.MouseLeave += new System.EventHandler(this.StartButton_MouseLeave);
            // 
            // InstructionsButton
            // 
            this.InstructionsButton.AutoSize = true;
            this.InstructionsButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InstructionsButton.FlatAppearance.BorderSize = 0;
            this.InstructionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstructionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionsButton.ForeColor = System.Drawing.Color.White;
            this.InstructionsButton.Location = new System.Drawing.Point(261, 616);
            this.InstructionsButton.Name = "InstructionsButton";
            this.InstructionsButton.Size = new System.Drawing.Size(306, 65);
            this.InstructionsButton.TabIndex = 1;
            this.InstructionsButton.Text = "How To Play";
            this.InstructionsButton.UseVisualStyleBackColor = true;
            this.InstructionsButton.Click += new System.EventHandler(this.ShowInstrScreen);
            this.InstructionsButton.MouseEnter += new System.EventHandler(this.InstrButton_MouseEnter);
            this.InstructionsButton.MouseLeave += new System.EventHandler(this.InstrButton_MouseLeave);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::Pacman.Properties.Resources.Main_Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(845, 875);
            this.Controls.Add(this.InstructionsButton);
            this.Controls.Add(this.StartButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button InstructionsButton;
    }
}

