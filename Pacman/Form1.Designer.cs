
namespace Pacman
{
    partial class Form1
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
            this.wall_1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.wall_1)).BeginInit();
            this.SuspendLayout();
            // 
            // wall_1
            // 
            this.wall_1.BackColor = System.Drawing.Color.Blue;
            this.wall_1.Location = new System.Drawing.Point(178, 58);
            this.wall_1.Name = "wall_1";
            this.wall_1.Size = new System.Drawing.Size(100, 50);
            this.wall_1.TabIndex = 0;
            this.wall_1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.wall_1);
            this.Name = "Form1";
            this.Text = "Pacman";
            ((System.ComponentModel.ISupportInitialize)(this.wall_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox wall_1;
    }
}

