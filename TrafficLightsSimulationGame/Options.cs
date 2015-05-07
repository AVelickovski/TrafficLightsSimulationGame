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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sound == true)
                kopce.Play();
            sound = false;
            label4.Text = "OFF";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sound == true)
                kopce.Play();
            label3.Text = "EASY";
            easy = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sound == true)
                kopce.Play();
            easy = false;
            label3.Text = "HARD";
        }
    }
}
