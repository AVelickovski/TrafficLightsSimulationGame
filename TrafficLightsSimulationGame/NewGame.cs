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
        Point pCars,pMan;
        Timer NextMove, CarSpawn,Delay,ManSpawn;
        public SoundPlayer kopce;
        public SoundPlayer scream;
        public Options defOptions;

        public NewGame(Options def)
        {            
            InitializeComponent();
            defOptions = def;
            lblDifficulty.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            if (defOptions.easy == true)
                lblDifficulty.Text = "EASY";
            else
                lblDifficulty.Text = "HARD";
            background = Resources.PlayGround;
            stage = new Stage(defOptions);
            lblScore.BackColor = System.Drawing.Color.Transparent;
            label1.BackColor = System.Drawing.Color.Transparent;
            Width = background.Size.Width;
            Height = background.Size.Height+20;
            DoubleBuffered = true;
            kopce = new SoundPlayer(Resources.kopce);
            rnd = new Random();
            ManSpawn = new Timer();
            ManSpawn.Tick += new EventHandler(ManSpawn_Tick);
            Delay = new Timer();
            Delay.Tick += new EventHandler(Delay_Tick);
            Delay.Interval = 2000;
            CarSpawn = new Timer();
            if (defOptions.easy == true)
            {
                CarSpawn.Interval = 2000;
                ManSpawn.Interval = 7000;
            }

            else
            {
                CarSpawn.Interval = 1500;
                ManSpawn.Interval = 5000;
            }
                
            CarSpawn.Tick += new EventHandler(CarSpawn_Tick); 
            NextMove = new Timer();
            NextMove.Interval = 50;
            NextMove.Tick += new EventHandler(NextMove_Tick);
            NextMove.Start();
            CarSpawn.Start();
            ManSpawn.Start();
        }

        private void ManSpawn_Tick(object sender, EventArgs e)
        {
            stage.addMan(rnd.Next(4), rnd.Next(2), rnd.Next(3), rnd.Next(2), rnd.Next(3));
        }

        private void Delay_Tick(object sender, EventArgs e)
        {
            Delay.Stop();
            GameOver go = new GameOver(defOptions, "COLLISION");
            go.StartPosition = FormStartPosition.CenterScreen;
            go.ShowDialog();
            if (go.nova == true)
            {
                stage = new Stage(defOptions);
                NextMove.Start();
                CarSpawn.Start();
                ManSpawn.Start();
                Invalidate();
            }
            else
            {
                this.Close();
            }
        }

        private void NextMove_Tick(object sender, EventArgs e)
        {
            lblScore.Text = Stage.score.ToString();
            pCars = stage.checkCollisionCars();
            pMan = stage.checkCollisionMan();
            if (!pCars.IsEmpty)
            {
                NextMove.Stop();
                CarSpawn.Stop();
                ManSpawn.Stop();
                Delay.Start();
                Graphics g = CreateGraphics();
                stage.drawBam(pCars, g);
            }
            else if (!pMan.IsEmpty)
            {
                NextMove.Stop();
                CarSpawn.Stop();
                ManSpawn.Stop();
                Delay.Start();
                if(defOptions.sound == true)
                    scream.Play();
                Graphics g = CreateGraphics();
                Image blood = (Bitmap)Resources.tomato.Clone();
                g.DrawImage(blood, pMan.X - 10, pMan.Y - 10, blood.Width / 3, blood.Height / 3);
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
            stage.checkDanger(e.Graphics);
            stage.Draw(e.Graphics);
        }

        private void NewGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            NextMove.Stop();
            CarSpawn.Stop();
            ManSpawn.Stop();
        }

        private void NewGame_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X >= stage.Lights.Lights[0].X && e.X <= stage.Lights.Lights[0].X + stage.Lights.Lights[0].getWidth() + 20 && e.Y >= stage.Lights.Lights[0].Y && e.Y <= stage.Lights.Lights[0].Y + stage.Lights.Lights[0].getHeight() + 20)
            {
                if (defOptions.sound == true)
                    kopce.Play();
                stage.Lights.Lights[0].changeLight();
                Invalidate();
            }
            else if (e.X >= stage.Lights.Lights[1].X && e.X <= stage.Lights.Lights[1].X + stage.Lights.Lights[1].getWidth() + 20 && e.Y >= stage.Lights.Lights[1].Y && e.Y <= stage.Lights.Lights[1].Y + stage.Lights.Lights[1].getHeight() + 20)
            {
                if (defOptions.sound == true)
                    kopce.Play();
                stage.Lights.Lights[1].changeLight();
                Invalidate();
            }
            else if (e.X >= stage.Lights.Lights[2].X && e.X <= stage.Lights.Lights[2].X + stage.Lights.Lights[2].getWidth() + 20 && e.Y >= stage.Lights.Lights[2].Y && e.Y <= stage.Lights.Lights[2].Y + stage.Lights.Lights[2].getHeight() + 20)
            {
                if (defOptions.sound == true)
                    kopce.Play();
                stage.Lights.Lights[2].changeLight();
                Invalidate();
            }
            else if (e.X >= stage.Lights.Lights[3].X && e.X <= stage.Lights.Lights[3].X + stage.Lights.Lights[3].getWidth() + 20 && e.Y >= stage.Lights.Lights[3].Y && e.Y <= stage.Lights.Lights[3].Y + stage.Lights.Lights[3].getHeight() + 20)
            {
                if (defOptions.sound == true)
                    kopce.Play();
                stage.Lights.Lights[3].changeLight();
                Invalidate();
            }
        }

        private void NewGame_MouseMove(object sender, MouseEventArgs e)
        {
            stage.selected(e.Location);
            if (e.X >= stage.Lights.Lights[0].X && e.X <= stage.Lights.Lights[0].X + stage.Lights.Lights[0].getWidth() + 20 && e.Y >= stage.Lights.Lights[0].Y && e.Y <= stage.Lights.Lights[0].Y + stage.Lights.Lights[0].getHeight() + 20)
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

        private void CarSpawn_Tick(object sender, EventArgs e)
        {
            stage.addCar(rnd.Next(4), rnd.Next(8));
            if(stage.checkJam())
            {
                NextMove.Stop();
                CarSpawn.Stop();
                ManSpawn.Stop();
                GameOver go = new GameOver(defOptions, "TRAFFIC JAM");
                go.StartPosition = FormStartPosition.CenterScreen;
                go.ShowDialog();
                if (go.nova == true)
                {
                    stage = new Stage(defOptions);
                    NextMove.Start();
                    CarSpawn.Start();
                    ManSpawn.Start();
                    Invalidate();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void NewGame_Load(object sender, EventArgs e)
        {
            scream = new SoundPlayer(Resources.scream);            
        }
    }
}
