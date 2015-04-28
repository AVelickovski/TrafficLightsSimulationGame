using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightsSimulationGame.Properties;

namespace TrafficLightsSimulationGame
{
    public class Semaphore
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public bool isGreen { get; set; }

        Image semaphore;

        public Semaphore(int x, int y)
        {
            X = x;
            Y = y;
            isGreen = false;
            semaphore = Resources.RedLight;
        }

        public void draw(Graphics g)
        {
            g.DrawImage(semaphore, X, Y);
        }
        public int getWidth()
        {
            return semaphore.Size.Width;
        }
        public int getHeight()
        {
            return semaphore.Size.Height;
        }
        public void changeLight()
        {
            isGreen = !isGreen;
            if (isGreen)
                semaphore = Resources.GreenLight;
            else
                semaphore = Resources.RedLight;
        }
    }
}
