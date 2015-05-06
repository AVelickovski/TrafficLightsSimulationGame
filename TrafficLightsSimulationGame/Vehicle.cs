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
        public Vehicle inFront { get; set; }
        public Vehicle(int x, int y,int type,Direction direction,Vehicle last) : base(x,y,direction)
        {
            isWaiting = false;
            if (type == 0)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        Model = Resources.audi;
                        Model.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        Model = Resources.audi;
                        Model.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        Model = Resources.audi;
                        break;
                    case Direction.WEST:
                        Model = Resources.audi;
                        Model.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if(type == 1)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        Model = Resources.ford;
                        Model.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        Model = Resources.ford;
                        Model.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        Model = Resources.ford;
                        break;
                    case Direction.WEST:
                        Model = Resources.ford;
                        Model.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 2)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        Model = Resources.ambulanta;
                        Model.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        Model = Resources.ambulanta;
                        Model.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        Model = Resources.ambulanta;
                        break;
                    case Direction.WEST:
                        Model = Resources.ambulanta;
                        Model.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 3)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        Model = Resources.karavan;
                        Model.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        Model = Resources.karavan;
                        Model.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        Model = Resources.karavan;
                        break;
                    case Direction.WEST:
                        Model = Resources.karavan;
                        Model.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 4)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        Model = Resources.kola;
                        Model.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        Model = Resources.kola;
                        Model.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        Model = Resources.kola;
                        break;
                    case Direction.WEST:
                        Model = Resources.kola;
                        Model.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 5)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        Model = Resources.kombe;
                        Model.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        Model = Resources.kombe;
                        Model.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        Model = Resources.kombe;
                        break;
                    case Direction.WEST:
                        Model = Resources.kombe;
                        Model.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 6)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        Model = Resources.policija;
                        Model.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        Model = Resources.policija;
                        Model.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        Model = Resources.policija;
                        break;
                    case Direction.WEST:
                        Model = Resources.policija;
                        Model.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            else if (type == 7)
            {
                switch (dir)
                {
                    case Direction.EAST:
                        Model = Resources.taxi;
                        Model.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    case Direction.NORTH:
                        Model = Resources.taxi;
                        Model.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Direction.SOUTH:
                        Model = Resources.taxi;
                        break;
                    case Direction.WEST:
                        Model = Resources.taxi;
                        Model.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                }
            }
            inFront = last;
        }

        public override void draw(Graphics g)
        {
            Image image = (Bitmap)Model.Clone();
            g.DrawImage(image, X, Y, image.Width, image.Height);
        }
        public void move(bool Green)
        {
            switch (dir)
            {
                case Direction.NORTH:
                    if(inFront!= null)
                    {
                        if(Y+Model.Size.Height+velocity >= inFront.Y)
                        {
                            velocity = 0;
                            isWaiting = true;
                        }
                    }
                    if (Y+Model.Size.Height > 215)
                        Y += velocity;
                    else if (Y+Model.Size.Height + velocity >= 215 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((Y+Model.Size.Height + velocity >= 215 || velocity==0) && Green)
                    {
                        velocity = 8;
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
                        if (Y - velocity <= inFront.Y + inFront.Model.Size.Height)
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
                        velocity = 8;
                        Y -= velocity;
                        isWaiting = false;
                    }
                    else
                        Y -= velocity;
                    if (Y + Model.Size.Height <= 0)
                        done = true;
                    break;
                case Direction.EAST:
                    if (inFront != null)
                    {
                        if (X - velocity <= inFront.X + inFront.Model.Size.Width)
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
                        velocity = 8;
                        X -= velocity;
                        isWaiting = false;
                    }
                    else
                        X -= velocity;
                    if (X + Model.Size.Width <= 0)
                        done = true;
                    break;
                case Direction.WEST:
                    if (inFront != null)
                    {
                        if (X + Model.Size.Width + velocity >= inFront.X)
                        {
                            velocity = 0;
                            isWaiting = true;
                        }
                        else
                            isWaiting = false;
                    }
                    if (X + Model.Size.Width > 482)
                        X += velocity;
                    else if (X + Model.Size.Width + velocity >= 482 && !Green)
                    {
                        velocity = 0;
                        isWaiting = true;
                    }
                    else if ((X + velocity >= 482 || velocity == 0) && Green)
                    {
                        velocity = 8;
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
