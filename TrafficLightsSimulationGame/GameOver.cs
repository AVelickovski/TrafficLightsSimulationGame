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
        Timer t;
        public GameOver(Options d, int score, string message)
        {
            InitializeComponent();
            def = d;
            lblScore.Text = score.ToString();
            lblMessage.Text = message;
            kopce = new SoundPlayer(Resources.kopce);
            panel1.BackgroundImage = Resources.y_u_do_dis;
            nova = false;
            t = new Timer();
            t.Interval = 1500;
            t.Tick += new EventHandler(T_Tick);
            t.Start();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.BackColor = Color.Gray;
            this.TransparencyKey = Color.Gray;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            panel1.Visible = false;
            t.Stop();
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

        private void GameOver_Load(object sender, EventArgs e)
        {

        }
    }
}
