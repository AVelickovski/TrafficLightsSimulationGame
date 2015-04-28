using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficSimulationGame
{
    public class Car
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool isWaiting { get; set; }
        int velocity;
        Image car;
        public enum Direction
        {
            EAST,
            WEST,
            SOUTH,
            NORTH
        }
        Direction dir;

        public Car(int x, int y, Image car,Direction direction)
        {
            X = x;
            Y = y;
            isWaiting = false;
            this.car = car;
            velocity = 5;
            dir = direction;
        }

        public void draw(Graphics g)
        {
            g.DrawImage(car, X, Y);
        }

        public void moveCar()
        {
            switch (dir)
            {
                case Direction.NORTH:
                    if (Y + velocity >= 200)
                        velocity = 0;
                    else
                        Y += velocity;
                    break;
                case Direction.SOUTH:
                    break;
                case Direction.EAST:
                    break;
                case Direction.WEST:
                    break;
            }
        }
    }
}
