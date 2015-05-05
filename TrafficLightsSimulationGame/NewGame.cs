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
    public partial class NewGame : Form
    {
        Image background;
        Stage stage;
        Random rnd;
        Point p;
        Timer timer1, timer2,timer3;
        public SoundPlayer kopce;

        public NewGame()
        {
            InitializeComponent();
            background = Resources.PlayGround;
            stage = new Stage();
            Width = background.Size.Width;
            Height = background.Size.Height + 10;
            DoubleBuffered = true;
            rnd = new Random();
            timer3 = new Timer();
            timer3.Tick += new EventHandler(Timer3_Tick);
            timer3.Interval = 2000;
            timer2 = new Timer();
            timer2.Interval = 2000;
            timer2.Tick += new EventHandler(Timer2_Tick); 
            timer1 = new Timer();
            timer1.Interval = 40;
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Start();
            timer2.Start();
        }

        private void Timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
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

        private void Timer1_Tick(object sender, EventArgs e)
        {
            p = stage.checkCollision();
            if (!p.IsEmpty)
            {
                timer1.Stop();
                timer2.Stop();
                Graphics g = CreateGraphics();
                stage.drawBam(p, g);
                timer3.Start();
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
            kopce = new SoundPlayer(Resources.kopce);
            if (e.X >= stage.Lights.Lights[0].X && e.X <= stage.Lights.Lights[0].X + stage.Lights.Lights[0].getWidth() + 20 && e.Y >= stage.Lights.Lights[0].Y && e.Y <= stage.Lights.Lights[0].Y + stage.Lights.Lights[0].getHeight() + 20)
            {                
                kopce.Play();
                stage.Lights.Lights[0].changeLight();
            }
            else if (e.X >= stage.Lights.Lights[1].X && e.X <= stage.Lights.Lights[1].X + stage.Lights.Lights[1].getWidth() + 20 && e.Y >= stage.Lights.Lights[1].Y && e.Y <= stage.Lights.Lights[1].Y + stage.Lights.Lights[1].getHeight() + 20)
            {
                kopce.Play();
                stage.Lights.Lights[1].changeLight();
            }
            else if (e.X >= stage.Lights.Lights[2].X && e.X <= stage.Lights.Lights[2].X + stage.Lights.Lights[2].getWidth() + 20 && e.Y >= stage.Lights.Lights[2].Y && e.Y <= stage.Lights.Lights[2].Y + stage.Lights.Lights[2].getHeight() + 20)
            {
                kopce.Play();
                stage.Lights.Lights[2].changeLight();
            }
            else if (e.X >= stage.Lights.Lights[3].X && e.X <= stage.Lights.Lights[3].X + stage.Lights.Lights[3].getWidth() + 20 && e.Y >= stage.Lights.Lights[3].Y && e.Y <= stage.Lights.Lights[3].Y + stage.Lights.Lights[3].getHeight() + 20)
            {
                kopce.Play();
                stage.Lights.Lights[3].changeLight();
            }
            Invalidate(true);
        }

        private void NewGame_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("X: {0}, Y: {1}",e.Location.X, e.Location.Y);
            if(e.X >= stage.Lights.Lights[0].X && e.X <= stage.Lights.Lights[0].X + stage.Lights.Lights[0].getWidth() + 20 && e.Y >= stage.Lights.Lights[0].Y && e.Y <= stage.Lights.Lights[0].Y + stage.Lights.Lights[0].getHeight() + 20)
            {
                this.Cursor = Cursors.Hand;
            }
            else if(e.X >= stage.Lights.Lights[1].X && e.X <= stage.Lights.Lights[1].X + stage.Lights.Lights[1].getWidth() + 20 && e.Y >= stage.Lights.Lights[1].Y && e.Y <= stage.Lights.Lights[1].Y + stage.Lights.Lights[1].getHeight() + 20)
            {
                this.Cursor = Cursors.Hand;
            }
            else if (e.X >= stage.Lights.Lights[2].X && e.X <= stage.Lights.Lights[2].X + stage.Lights.Lights[2].getWidth() + 20 && e.Y >= stage.Lights.Lights[2].Y && e.Y <= stage.Lights.Lights[2].Y + stage.Lights.Lights[2].getHeight() + 20)
            {
                this.Cursor = Cursors.Hand;
            }
            else if (e.X >= stage.Lights.Lights[3].X && e.X <= stage.Lights.Lights[3].X + stage.Lights.Lights[3].getWidth() + 20 && e.Y >= stage.Lights.Lights[3].Y && e.Y <= stage.Lights.Lights[3].Y + stage.Lights.Lights[3].getHeight() + 20)
            {
                this.Cursor = Cursors.Hand;
            }
            else {
                this.Cursor = Cursors.Default;
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            stage.add(rnd.Next(4), rnd.Next(8));
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

        private void NewGame_Load(object sender, EventArgs e)
        {
        }
    }
}
