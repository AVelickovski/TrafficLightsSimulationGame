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
    public partial class GameOver : Form
    {
        public bool nova { get; set; }
        public GameOver()
        {
            InitializeComponent();
            nova = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.BackColor = Color.Gray;
            this.TransparencyKey = Color.Gray;
        }

        private void GameOver_Load(object sender, EventArgs e)
        {            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nova = true;
            this.Close();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
