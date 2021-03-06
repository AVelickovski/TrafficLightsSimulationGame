﻿using System;
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
            Lights.Add(new Semaphore(405, 150));
            Lights.Add(new Semaphore(808, 150));
            Lights.Add(new Semaphore(405, 490));
            Lights.Add(new Semaphore(808, 490));
        }

        public void Draw(Graphics g)
        {
            foreach (Semaphore s in Lights)
                s.draw(g);
        }
    }
}
