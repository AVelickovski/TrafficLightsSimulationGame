namespace TrafficLightsSimulationGame
{
    partial class NewGame
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
            this.SuspendLayout();
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(687, 350);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "NewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewGame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewGame_FormClosing);
            this.Load += new System.EventHandler(this.NewGame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewGame_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NewGame_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NewGame_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

    }
}