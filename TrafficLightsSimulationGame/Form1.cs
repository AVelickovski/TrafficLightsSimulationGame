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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.TrafficJam;
            this.Width = Properties.Resources.TrafficJam.Width;
            this.Height = Properties.Resources.TrafficJam.Height;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            Instructions ins = new Instructions();
             ins.ShowDialog();
        }
    }
}
