using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightsSimulationGame.Properties;

namespace TrafficLightsSimulationGame
{
    public class Car : ObjectType
    {
        public bool isWaiting { get;  private set; }
        Image car;
        public Car inFront { get; set; }
        public Car(int x, int y,int type,Direction direction,Car last) : base(x,y,direction)
        {
            isWaiting = false;
            if (type == 1)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.CarModel1E;
                        break;
                    case Direction.NORTH:
                        car = Resources.CarModel1N;
                        break;
                    case Direction.SOUTH:
                        car = Resources.CarModel1S;
                        break;
                    case Direction.WEST:
                        car = Resources.CarModel1W;
                        break;
                }
            }
            inFront = last;
        }

        public override void draw(Graphics g)
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

        public void move(bool Green)
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
                        velocity = 5;
                        Y += velocity;
                        isWaiting = false;
                    }
                    else
                        Y += velocity;
                    if (Y >= 575)
                        done = true;
                    break;
                case Direction.SOUTH:
                    if (inFront != null)
                    {
                        if (Y - velocity <= inFront.Y + inFront.car.Size.Height)
                        {
                            velocity = 0;
                            isWaiting = true;
                        }
                    }
                    if (Y < 388)
                        Y -= velocity;
                    else if (Y - velocity <= 388 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((Y - velocity <= 388 || velocity == 0) && Green)
                    {
                        velocity = 5;
                        Y -= velocity;
                        isWaiting = false;
                    }
                    else
                        Y -= velocity;
                    if (Y + car.Size.Height <= 0)
                        done = true;
                    break;
                case Direction.EAST:
                    if (inFront != null)
                    {
                        if (X - velocity <= inFront.X + inFront.car.Size.Width)
                        {
                            velocity = 0;
                            isWaiting = true;
                        }
                        else
                            isWaiting = false;
                    }
                    if (X  < 715)
                        X -= velocity;
                    else if (X - velocity <= 715 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((X - velocity <= 715 || velocity == 0) && Green)
                    {
                        velocity = 5;
                        X -= velocity;
                        isWaiting = false;
                    }
                    else
                        X -= velocity;
                    if (X + car.Size.Width <= 0)
                        done = true;
                    break;
                case Direction.WEST:
                    if (inFront != null)
                    {
                        if (X + car.Size.Width + velocity >= inFront.X)
                        {
                            velocity = 0;
                            isWaiting = true;
                        }
                        else
                            isWaiting = false;
                    }
                    if (X + car.Size.Width > 510)
                        X += velocity;
                    else if (X + car.Size.Width + velocity >= 510 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((X + velocity >= 510 || velocity == 0) && Green)
                    {
                        velocity = 5;
                        X += velocity;
                        isWaiting = false;
                    }
                    else
                        X += velocity;
                    if (X >= 1343)
                        done = true;
                    break;
            }
        }
    }
}
