﻿using System;
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
    public partial class NewGame : Form
    {
        Image background;
        Stage stage;
        Random rnd;
        Timer timer1, timer2;
        public NewGame()
        {
            InitializeComponent();
            background = Resources.PlayGround;
            stage = new Stage();
            Width = background.Size.Width;
            Height = background.Size.Height + 10;
            DoubleBuffered = true;
            rnd = new Random();
            timer2 = new Timer();
            timer2.Interval = 2000;
            timer2.Tick += new EventHandler(Timer2_Tick); 
            timer1 = new Timer();
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Start();
            timer2.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (stage.checkCollision())
            {
                timer1.Stop();
                timer2.Stop();
                if (MessageBox.Show("Collision!\nDo you want to play again?", "Game over", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    stage = new Stage();
                    timer1.Start();
                    timer2.Start();
                    Invalidate();
                }
                else
                    this.Close();
            }
            else
            {
                stage.move();
                stage.inCollisionArea();
                Invalidate();
            }
        }

        private void NewGame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(background, 0, 0);
            stage.Draw(e.Graphics);
        }

        private void NewGame_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X >= stage.Lights.Lights[0].X && e.Location.X <= stage.Lights.Lights[0].X + stage.Lights.Lights[0].getWidth() && e.Location.Y >= stage.Lights.Lights[0].Y && e.Location.Y <= stage.Lights.Lights[0].Y + stage.Lights.Lights[0].getHeight())
            {
                stage.Lights.Lights[0].changeLight();
            }
            else if (e.Location.X >= stage.Lights.Lights[1].X && e.Location.X <= stage.Lights.Lights[1].X + stage.Lights.Lights[1].getWidth() && e.Location.Y >= stage.Lights.Lights[1].Y && e.Location.Y <= stage.Lights.Lights[1].Y + stage.Lights.Lights[1].getHeight())
            {
                stage.Lights.Lights[1].changeLight();
            }
            else if (e.Location.X >= stage.Lights.Lights[2].X && e.Location.X <= stage.Lights.Lights[2].X + stage.Lights.Lights[2].getWidth() && e.Location.Y >= stage.Lights.Lights[2].Y && e.Location.Y <= stage.Lights.Lights[2].Y + stage.Lights.Lights[2].getHeight())
            {
                stage.Lights.Lights[2].changeLight();
            }
            else if (e.Location.X >= stage.Lights.Lights[3].X && e.Location.X <= stage.Lights.Lights[3].X + stage.Lights.Lights[3].getWidth() && e.Location.Y >= stage.Lights.Lights[3].Y && e.Location.Y <= stage.Lights.Lights[3].Y + stage.Lights.Lights[3].getHeight())
            {
                stage.Lights.Lights[3].changeLight();
            }
            Invalidate(true);
        }

        private void NewGame_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("X: {0}, Y: {1}",e.Location.X, e.Location.Y);
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            int i = rnd.Next(4);
            stage.add(i);
            if(stage.checkJam())
            {
                timer1.Stop();
                timer2.Stop();
                if (MessageBox.Show("Traffic Jam!\nDo you want to play again?", "Game over", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    stage = new Stage();
                    timer1.Start();
                    timer2.Start();
                    Invalidate();
                }
                else
                    this.Close();
            }
        }
    }
}
