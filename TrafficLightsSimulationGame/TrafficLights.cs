using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsSimulationGame
{
    public class TrafficLights
    {
        public List<Semaphore> Lights;

        public TrafficLights()
        {
            Lights = new List<Semaphore>(4);
            Lights.Add(new Semaphore(354, 158));
            Lights.Add(new Semaphore(679, 158));
            Lights.Add(new Semaphore(354, 483));
            Lights.Add(new Semaphore(679, 483));
        }

        public void Draw(Graphics g)
        {
            foreach (Semaphore s in Lights)
                s.draw(g);
        }
    }
}
