using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficLightsSimulationGame.Properties;

namespace TrafficLightsSimulationGame
{
    public partial class Options : Form
    {
        public bool sound { get; set; }
        public bool easy { get; set; }
        public SoundPlayer kopce;
        public Options()
        {
            sound = true;
            easy = true;
            kopce = new SoundPlayer(Resources.kopce);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sound == true)
                kopce.Play();
            sound = true;
            label4.Text = "ON";
            button1.BackColor = Color.FromArgb(0, 192, 0);
            button2.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sound == true)
                kopce.Play();
            sound = false;
            label4.Text = "OFF";
            button2.BackColor = Color.FromArgb(0, 192, 0);
            button1.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sound == true)
                kopce.Play();
            label3.Text = "EASY";
            easy = true;
            button4.BackColor = Color.FromArgb(0, 192, 0);
            button3.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sound == true)
                kopce.Play();
            easy = false;
            label3.Text = "HARD";
            button3.BackColor = Color.FromArgb(0, 192, 0);
            button4.BackColor = Color.FromArgb(192, 192, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button5_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
    }
}
