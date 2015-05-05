using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsSimulationGame
{
    public abstract class  ObjectType
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int velocity { get; set; }
        public bool done { get; set; }
        public enum Direction
        {
            EAST,
            WEST,
            SOUTH,
            NORTH
        }
        public Direction dir;
        public ObjectType(int x, int y, Direction d)
        {
            X = x;
            Y = y;
            done = false;
            velocity = 6;
            dir = d;
        }
        public abstract void draw(Graphics g);
        //public abstract void move(bool Green);
    }
}
