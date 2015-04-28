using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightsSimulationGame.Properties;

namespace TrafficLightsSimulationGame
{
    public class Car
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool isWaiting { get;  private set; }
        public int velocity { get; set; }
        Image car;
        Car inFront;
        public enum Direction
        {
            EAST,
            WEST,
            SOUTH,
            NORTH
        }
        Direction dir;

        public Car(int x, int y,int type,Direction direction,Car last)
        {
            X = x;
            Y = y;
            isWaiting = false;
            if(type == 1)
            {
                car = Resources.CarModel1;
            }
            velocity = 10;
            dir = direction;
            inFront = last;
        }

        public void draw(Graphics g)
        {
            g.DrawImage(car, X, Y);
        }
        public int getWidth()
        {
            return car.Size.Width;
        }
        public int getHeight()
        {
            return car.Size.Height;
        }

        public void moveCar(bool Green)
        {
            switch (dir)
            {
                case Direction.NORTH:
                    if(inFront!= null)
                    {
                        if(Y+car.Size.Height+velocity >= inFront.Y)
                        {
                            velocity = 0;
                            isWaiting = true;
                        }
                    }
                    if (Y+car.Size.Height > 240)
                        Y += velocity;
                    else if (Y+car.Size.Height + velocity >= 240 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((Y+car.Size.Height + velocity >= 240 || velocity==0) && Green)
                    {
                        velocity = 10;
                        Y += velocity;
                        isWaiting = false;
                    }
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
