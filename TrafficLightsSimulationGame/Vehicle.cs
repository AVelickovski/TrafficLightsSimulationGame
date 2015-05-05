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
            if (type == 0)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.audi;
                        car.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        car = Resources.audi;
                        car.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        car = Resources.audi;
                        break;
                    case Direction.WEST:
                        car = Resources.audi;
                        car.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if(type == 1)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.ford;
                        car.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        car = Resources.ford;
                        car.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        car = Resources.ford;
                        break;
                    case Direction.WEST:
                        car = Resources.ford;
                        car.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if(type == 2)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.kamion;
                        car.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        car = Resources.kamion;
                        car.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        car = Resources.kamion;
                        break;
                    case Direction.WEST:
                        car = Resources.kamion;
                        car.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 3)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.ambulanta;
                        car.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        car = Resources.ambulanta;
                        car.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        car = Resources.ambulanta;
                        break;
                    case Direction.WEST:
                        car = Resources.ambulanta;
                        car.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 4)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.karavan;
                        car.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        car = Resources.karavan;
                        car.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        car = Resources.karavan;
                        break;
                    case Direction.WEST:
                        car = Resources.karavan;
                        car.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 5)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.kola;
                        car.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        car = Resources.kola;
                        car.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        car = Resources.kola;
                        break;
                    case Direction.WEST:
                        car = Resources.kola;
                        car.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 6)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.kombe;
                        car.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        car = Resources.kombe;
                        car.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        car = Resources.kombe;
                        break;
                    case Direction.WEST:
                        car = Resources.kombe;
                        car.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 7)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.policija;
                        car.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        car = Resources.policija;
                        car.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        car = Resources.policija;
                        break;
                    case Direction.WEST:
                        car = Resources.policija;
                        car.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 8)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        car = Resources.taxi;
                        car.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        car = Resources.taxi;
                        car.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        car = Resources.taxi;
                        break;
                    case Direction.WEST:
                        car = Resources.taxi;
                        car.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            inFront = last;
        }

        public override void draw(Graphics g)
        {
            Image image = (Bitmap)car.Clone();
            g.DrawImage(image, X, Y, image.Width, image.Height);
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
                    if (X  < 820)
                        X -= velocity;
                    else if (X - velocity <= 820 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((X - velocity <= 820 || velocity == 0) && Green)
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
                    if (X + car.Size.Width > 482)
                        X += velocity;
                    else if (X + car.Size.Width + velocity >= 482 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((X + velocity >= 482 || velocity == 0) && Green)
                    {
                        velocity = 5;
                        X += velocity;
                        isWaiting = false;
                    }
                    else
                        X += velocity;
                    if (X >= 1283)
                        done = true;
                    break;
            }
        }
    }
}
