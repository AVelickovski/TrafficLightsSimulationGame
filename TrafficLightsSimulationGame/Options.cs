using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficLightsSimulationGame
{
    public partial class Options : Form
    {
        public bool sound { get; set; }
        public bool easy { get; set; }
        public Options()
        {
            sound = true;
            easy = true;
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sound = true;
            label4.Text = "ON";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sound = false;
            label4.Text = "OFF";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = "EASY";
            easy = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            easy = false;
            label3.Text = "HARD";
        }
    }
}
