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
    public partial class StartInterface : Form
    {
        Image bcground;
        public SoundPlayer kopce;

        public StartInterface()
        {
            InitializeComponent();
            bcground = Resources.TrafficJam;
            Width = bcground.Size.Width-25;
            Height =3* bcground.Size.Height/4;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            kopce.Play();
            NewGame ng = new NewGame();
            ng.StartPosition = FormStartPosition.CenterScreen;
            this.Visible = false;
            ng.ShowDialog();
            this.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            kopce.Play();            
            Application.Exit();
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            kopce.Play();
            Instructions ins = new Instructions();
            ins.StartPosition = FormStartPosition.CenterScreen;
            ins.ShowDialog();
        }

        private void StartInterface_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(bcground, 0, 0);
        }

        private void StartInterface_Load(object sender, EventArgs e)
        {
            kopce = new SoundPlayer(Resources.kopce);
        }
    }
}
