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
        protected Image Model;
        protected int type;
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
            velocity = 8;
            dir = d;
            Model = null;
        }
        public abstract void draw(Graphics g);
        public int getHeight()
        {
            return Model.Size.Height;
        }
        public int getWidth()
        {
            return Model.Size.Width;
        }
    }
}
