using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightsSimulationGame
{
    public class Man : ObjectType
    {
        public bool leftLeg { get; set; }
        Image person;
        Direction to;
        public Man(int x,int y, Direction To,Direction from) : base(x, y, from)
        {
            leftLeg = false;
            to = To;
        }
        public override void draw(Graphics g)
        {
            
        }
        public void move()
        {

        }
    }
}
