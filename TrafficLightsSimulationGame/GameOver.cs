using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using TrafficLightsSimulationGame.Properties;

namespace TrafficLightsSimulationGame
{
    public partial class GameOver : Form
    {
        public bool nova { get; set; }
        public Options def { get; set; }
        public SoundPlayer kopce;
        public GameOver(Options d, string message)
        {
            InitializeComponent();
            def = d;
            lblScore.Text = Stage.score.ToString();
            lblMessage.Text = message;
            kopce = new SoundPlayer(Resources.kopce);
            nova = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.BackColor = Color.Gray;
            this.TransparencyKey = Color.Gray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (def.sound == true)
                kopce.Play();
            nova = true;
            this.Close();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (def.sound == true)
                kopce.Play();
            this.Close();
        }
    }
}
