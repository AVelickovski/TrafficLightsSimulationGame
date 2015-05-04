using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightsSimulationGame.Properties;

namespace TrafficLightsSimulationGame
{
    public class Vehicle : ObjectType
    {
        public bool isWaiting { get;  private set; }
        Image car;
        public Vehicle inFront { get; set; }
        public Vehicle(int x, int y,int type,Direction direction,Vehicle last) : base(x,y,direction)
        {
            isWaiting = false;
            if (type == 1)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.CarModel1;
                        car.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        car = Resources.CarModel1;
                        car.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        car = Resources.CarModel1;
                        break;
                    case Direction.WEST:
                        car = Resources.CarModel1;
                        car.RotateFlip(RotateFlipType.Rotate90FlipNone);
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
                    if (Y+car.Size.Height > 215)
                        Y += velocity;
                    else if (Y+car.Size.Height + velocity >= 215 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((Y+car.Size.Height + velocity >= 215 || velocity==0) && Green)
                    {
                        velocity = 5;
                        Y += velocity;
                        isWaiting = false;
                    }
                    else
                        Y += velocity;
                    if (Y >= 648)
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
                    if (Y < 498)
                        Y -= velocity;
                    else if (Y - velocity <= 498 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((Y - velocity <= 498 || velocity == 0) && Green)
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
                    if (X  < 690)
                        X -= velocity;
                    else if (X - velocity <= 690 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((X - velocity <= 690 || velocity == 0) && Green)
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
                    if (X + car.Size.Width > 405)
                        X += velocity;
                    else if (X + car.Size.Width + velocity >= 405 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((X + velocity >= 405 || velocity == 0) && Green)
                    {
                        velocity = 5;
                        X += velocity;
                        isWaiting = false;
                    }
                    else
                        X += velocity;
                    if (X >= 1078)
                        done = true;
                    break;
            }
        }
    }
}
