using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrafficLightsSimulationGame.Properties;

namespace TrafficLightsSimulationGame
{
    public partial class Instructions : Form
    {  
        public Instructions()
        {
            InitializeComponent(); 
        }

        private void btnBack1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void btnNext2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true; 
        }

        private void btnBack3_Click(object sender, EventArgs e)
        {
            
            panel3.Visible = false;
            panel2.Visible = true;

        }

        private void btnNext3_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void btnBack4_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel3.Visible = true;
        }

        private void btnNext4_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void btnNext5_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
        }

        private void btnBack5_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel4.Visible = true;
        }

        private void btnBack6_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;
            panel5.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
    }
}
