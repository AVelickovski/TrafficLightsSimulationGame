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
    public partial class Form1 : Form
    {
        Image background;
        TrafficLights Semaphores;
        List<Car> carsNorth;
        Timer timer1,timer2;
        public Form1()
        {
            InitializeComponent();
<<<<<<< HEAD
            background = Resources.PlayGround;
            Semaphores = new TrafficLights();
            Width = background.Size.Width;
            Height = background.Size.Height+10;
            DoubleBuffered = true;
            carsNorth = new List<Car>();
            timer2 = new Timer();
            timer2.Interval = 2000;
            timer2.Tick += new EventHandler(Timer2_Tick);
            timer1 = new Timer();
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Start();
            timer2.Start();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (carsNorth.Count == 0)
                carsNorth.Add(new Car(540, -20, 1, Car.Direction.NORTH, null));
            else
                carsNorth.Add(new Car(540, -20, 1, Car.Direction.NORTH, carsNorth[carsNorth.Count - 1]));
            if (timer2.Interval != 500)
                timer2.Interval -= 100;
            else
                timer2.Stop();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach (Car c in carsNorth)
                c.moveCar(Semaphores.Lights[0].isGreen);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(background, 0, 0);
            Semaphores.Draw(e.Graphics);
            foreach (Car c in carsNorth)
                c.draw(e.Graphics);
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X >= Semaphores.Lights[0].X && e.Location.X <= Semaphores.Lights[0].X + Semaphores.Lights[0].getWidth() && e.Location.Y >= Semaphores.Lights[0].Y && e.Location.Y <= Semaphores.Lights[0].Y + Semaphores.Lights[0].getHeight())
            {
                Semaphores.Lights[0].changeLight();
            }
            else if (e.Location.X >= Semaphores.Lights[1].X && e.Location.X <= Semaphores.Lights[1].X + Semaphores.Lights[1].getWidth() && e.Location.Y >= Semaphores.Lights[1].Y && e.Location.Y <= Semaphores.Lights[1].Y + Semaphores.Lights[1].getHeight())
            {
                Semaphores.Lights[1].changeLight();
            }
            else if (e.Location.X >= Semaphores.Lights[2].X && e.Location.X <= Semaphores.Lights[2].X + Semaphores.Lights[2].getWidth() && e.Location.Y >= Semaphores.Lights[2].Y && e.Location.Y <= Semaphores.Lights[2].Y + Semaphores.Lights[2].getHeight())
            {
                Semaphores.Lights[2].changeLight();
            }
            else if (e.Location.X >= Semaphores.Lights[3].X && e.Location.X <= Semaphores.Lights[3].X + Semaphores.Lights[3].getWidth() && e.Location.Y >= Semaphores.Lights[3].Y && e.Location.Y <= Semaphores.Lights[3].Y + Semaphores.Lights[3].getHeight())
            {
                Semaphores.Lights[3].changeLight();
            }
            Invalidate(true);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("X: {0} Y: {1}", e.Location.X, e.Location.Y);
=======
            this.BackgroundImage = Properties.Resources.TrafficJam;
            this.Width = Properties.Resources.TrafficJam.Width;
            this.Height = Properties.Resources.TrafficJam.Height;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            NewGame ng = new NewGame();
            this.Visible = false;
            ng.ShowDialog();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            Instructions ins = new Instructions();
             ins.ShowDialog();
>>>>>>> 90cc3fe41764232b2ff3596ddc9fede12fdd466d
        }
    }
}
