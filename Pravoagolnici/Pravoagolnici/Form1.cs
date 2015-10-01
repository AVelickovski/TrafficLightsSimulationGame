using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pravoagolnici
{
    public partial class Form1 : Form
    {
        private RectDoc Document;
        Timer timer;
        public Form1()
        {
            InitializeComponent();
            Document = new RectDoc();
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += new  EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Document.Move();
            Document.Rotate();
            Document.CheckOutOfBounds(this.Width, this.Height);
            Invalidate();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Document.AddRectangle(e.Location);
            Invalidate(true);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Document.Select(e.Location, 1);
            else if (e.Button == MouseButtons.Right)
                Document.Select(e.Location, 2);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Document.Draw(e.Graphics);
            lbTotal.Text = String.Format("R: {0}", Document.pravoagolnici.Count);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog d = new ColorDialog();
            if (d.ShowDialog() == DialogResult.OK)
                Document.currentColor = d.Color;
        }
    }
}
