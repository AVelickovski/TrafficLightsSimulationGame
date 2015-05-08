using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightsSimulationGame.Properties;

namespace TrafficLightsSimulationGame
{
    public class Man : ObjectType
    {
        private int pointFrom;
        private int pointTo;
        private bool flip;
        public bool isSelected { get; set; }
        Direction to;
        public Man(int x,int y,int type, Direction To,Direction from, int pointFrom,int pointTo) : base(x, y, from)
        {
            to = To;
            flip = false;
            this.type = type;
            this.pointFrom = pointFrom;
            this.pointTo = pointTo;
            if (type == 0)
            {
                velocity = 5;
                switch (dir)
                {
                    case Direction.NORTH:
                        Model = Resources.covek_dole;
                        break;
                    case Direction.EAST:
                        Model = Resources.covek_levo;
                        break;
                    case Direction.WEST:
                        Model = Resources.covek_desno;
                        break;
                    case Direction.SOUTH:
                        Model = Resources.covek_gore;
                        break;
                }
            }
            if (type == 1)
            {
                velocity = 5;
                switch (dir)
                {
                    case Direction.NORTH:
                        Model = Resources.dete_dole;
                        break;
                    case Direction.EAST:
                        Model = Resources.dete_levo;
                        break;
                    case Direction.WEST:
                        Model = Resources.dete_desno;
                        break;
                    case Direction.SOUTH:
                        Model = Resources.dete_gore;
                        break;
                }
            }
            if (type == 2)
            {
                velocity = 4;
                switch (dir)
                {
                    case Direction.NORTH:
                        Model = Resources.starce_dole;
                        break;
                    case Direction.EAST:
                        Model = Resources.starce_levo;
                        break;
                    case Direction.WEST:
                        Model = Resources.starce_desno;
                        break;
                    case Direction.SOUTH:
                        Model = Resources.starce_gore;
                        break;
                }
            }
        }
        public override void draw(Graphics g)
        {
            if (isSelected)
                drawPath(g);
            g.DrawImage(Model, X, Y);

        }
        private void drawPath(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 10);
            switch (dir)
            {
                case Direction.NORTH:
                    switch (to)
                    {
                        case Direction.WEST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(540, 0), new Point(540, 265), new Point(0, 265) };
                                g.DrawLines(pen, lines);

                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(540, 0), new Point(540, 444), new Point(0, 444) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(755, 0), new Point(755, 444), new Point(0, 444) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(755, 0), new Point(755, 265), new Point(0, 265) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                        case Direction.EAST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(540, 0), new Point(540, 444), new Point(1283, 444) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(540, 0), new Point(540, 265), new Point(1283, 265) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(755, 0), new Point(755, 265), new Point(1283, 265) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(755, 0), new Point(755, 444), new Point(1283, 444) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                        case Direction.SOUTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[2] { new Point(540, 0), new Point(540, 658) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[4] { new Point(540, 0), new Point(540, 444), new Point(755, 444), new Point(755,658) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[2] { new Point(755, 0), new Point(755, 658) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[4] { new Point(755, 0), new Point(755, 444), new Point(540, 444), new Point(540, 658) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                    }
                    break;
                case Direction.EAST:
                    switch (to)
                    {
                        case Direction.WEST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[2] { new Point(1283, 265), new Point(0, 265) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[4] { new Point(1283, 265), new Point(540, 265), new Point(540, 444), new Point(0, 444) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[2] { new Point(1283, 444), new Point(0, 444) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[4] { new Point(1283, 444), new Point(540, 444), new Point(540, 265), new Point(0, 265) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                        case Direction.NORTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(1283, 265), new Point(755, 265), new Point(755, 0) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(1283, 265), new Point(540, 265), new Point(540, 0) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(1283, 444), new Point(540, 444), new Point(540, 0) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(1283, 444), new Point(755, 444), new Point(755, 0) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                        case Direction.SOUTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(1283, 265), new Point(540, 265), new Point(540, 658) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(1283, 265), new Point(755, 265), new Point(755, 658) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(1283, 444), new Point(755, 444), new Point(755, 658) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(1283, 444), new Point(540, 444), new Point(540, 658) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                    }
                    break;
                case Direction.WEST:
                    switch (to)
                    {
                        case Direction.EAST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[2] { new Point(0, 444), new Point(1283, 444) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[4] { new Point(0, 444), new Point(755, 444), new Point(755, 265), new Point(1283,265) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[2] { new Point(0, 265), new Point(1283, 265)};
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[4] { new Point(0, 265), new Point(755, 265), new Point(755, 444), new Point(1283, 444) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                        case Direction.NORTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(0, 444), new Point(755, 444), new Point(755, 0) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(0, 444), new Point(540, 444), new Point(540, 0) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(0, 265), new Point(540, 265), new Point(540, 0) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(0, 265), new Point(755, 265), new Point(755, 0) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                        case Direction.SOUTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(0, 444), new Point(540, 444), new Point(540, 658) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(0, 444), new Point(755, 444), new Point(755, 658) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(0, 265), new Point(755, 265), new Point(755, 658) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(0, 265), new Point(540, 265), new Point(540, 658) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                    }
                    break;
                case Direction.SOUTH:
                    switch (to)
                    {
                        case Direction.WEST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(755, 658), new Point(755, 265), new Point(0, 265) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(755, 658), new Point(755, 444), new Point(0, 444) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(540, 658), new Point(540, 444), new Point(0, 444) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(540, 658), new Point(540, 265), new Point(0, 265) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                        case Direction.EAST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(755, 658), new Point(755, 444), new Point(1283, 444) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(755, 658), new Point(755, 265), new Point(1283, 265) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[3] { new Point(540, 658), new Point(540, 265), new Point(1283, 265) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[3] { new Point(540, 658), new Point(540, 444), new Point(1283, 444) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                        case Direction.NORTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Point[] lines = new Point[2] { new Point(755, 658), new Point(755, 0) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                Point[] lines = new Point[4] { new Point(755, 658), new Point(755, 265), new Point(540, 268), new Point(540,0) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Point[] lines = new Point[2] { new Point(540, 658), new Point(540, 0) };
                                g.DrawLines(pen, lines);
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                Point[] lines = new Point[4] { new Point(540, 658), new Point(540, 265), new Point(755, 268), new Point(755, 0) };
                                g.DrawLines(pen, lines);
                            }
                            break;
                    }
                    break;
            }
            pen.Dispose();
        }
    
        private void flipModelUp()
        {
            if (!flip)
            {
                if (type == 0)
                    Model = Resources.covek_gore;
                if (type == 1)
                    Model = Resources.dete_gore;
                if (type == 2)
                    Model = Resources.starce_gore;
                flip = true;
            }
            
        }
        private void flipModelDown()
        {
            if (!flip)
            {
                if (type == 0)
                    Model = Resources.covek_dole;
                if (type == 1)
                    Model = Resources.dete_dole;
                if (type == 2)
                    Model = Resources.starce_dole;
                flip = true;
            }

        }
        private void flipModelLeft()
        {
            if (!flip)
            {
                if (type == 0)
                    Model = Resources.covek_levo;
                if (type == 1)
                    Model = Resources.dete_levo;
                if (type == 2)
                    Model = Resources.starce_levo;
                flip = true;
            }

        }
        private void flipModelRight()
        {
            if (!flip)
            {
                if (type == 0)
                    Model = Resources.covek_desno;
                if (type == 1)
                    Model = Resources.dete_desno;
                if (type == 2)
                    Model = Resources.starce_desno;
                flip = true;
            }

        }
        public void move()
        {
            switch (dir)
            {
                case Direction.NORTH:
                    switch (to)
                    {
                        case Direction.WEST:
                            if(pointFrom == 0 && pointTo == 1)
                            {
                                if (Y + Model.Size.Height / 2 >= 247 && X == 531)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_levo;
                                    if(type == 1)
                                        Model = Resources.dete_levo;
                                    if (type == 2)
                                        Model = Resources.starce_levo;
                                    X -= velocity;
                                }
                                else if (Y + Model.Size.Height / 2 >= 247 && X < 531)
                                    X -= velocity;
                                else
                                    Y += velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            else if(pointFrom == 0 && pointTo == 0)
                            {
                                if (Y + Model.Size.Height / 2 >= 444 && X == 531)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_levo;
                                    if (type == 1)
                                        Model = Resources.dete_levo;
                                    if (type == 2)
                                        Model = Resources.starce_levo;
                                    X -= velocity;
                                }
                                else if (Y + Model.Size.Height / 2 >= 444 && X < 531)
                                    X -= velocity;
                                else
                                    Y += velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                if (Y + Model.Size.Height / 2 >= 444 && X == 755)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_levo;
                                    if (type == 1)
                                        Model = Resources.dete_levo;
                                    if (type == 2)
                                        Model = Resources.starce_levo;
                                    X -= velocity;
                                }
                                else if (Y + Model.Size.Height / 2 >= 444 && X < 755)
                                    X -= velocity;
                                else
                                    Y += velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (Y + Model.Size.Height / 2 >= 247 && X == 755)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_levo;
                                    if (type == 1)
                                        Model = Resources.dete_levo;
                                    if (type == 2)
                                        Model = Resources.starce_levo;
                                    X -= velocity;
                                }
                                else if (Y + Model.Size.Height / 2 >= 247 && X < 755)
                                    X -= velocity;
                                else
                                    Y += velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            break;
                        case Direction.EAST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                if (Y + Model.Size.Height / 2 >= 444 && X == 531)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_desno;
                                    if (type == 1)
                                        Model = Resources.dete_desno;
                                    if (type == 2)
                                        Model = Resources.starce_desno;
                                    X += velocity;
                                }
                                else if (Y + Model.Size.Height / 2 >= 444 && X > 531)
                                    X += velocity;
                                else
                                    Y += velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (Y + Model.Size.Height / 2 >= 247 && X == 531)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_desno;
                                    if (type == 1)
                                        Model = Resources.dete_desno;
                                    if (type == 2)
                                        Model = Resources.starce_desno;
                                    X += velocity;
                                }
                                else if (Y + Model.Size.Height / 2 >= 247 && X > 531)
                                    X += velocity;
                                else
                                    Y += velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                if (Y + Model.Size.Height / 2 >= 247 && X == 755)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_desno;
                                    if (type == 1)
                                        Model = Resources.dete_desno;
                                    if (type == 2)
                                        Model = Resources.starce_desno;
                                    X += velocity;
                                }
                                else if (Y + Model.Size.Height / 2 >= 247 && X > 755)
                                    X += velocity;
                                else
                                    Y += velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (Y + Model.Size.Height / 2 >= 444 && X == 755)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_desno;
                                    if (type == 1)
                                        Model = Resources.dete_desno;
                                    if (type == 2)
                                        Model = Resources.starce_desno;
                                    X += velocity;
                                }
                                else if (Y + Model.Size.Height / 2 >= 444 && X > 755)
                                    X += velocity;
                                else
                                    Y += velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            break;
                        case Direction.SOUTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Y += velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (Y + Model.Size.Height / 2 >= 444 && X == 531)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_desno;
                                    if (type == 1)
                                        Model = Resources.dete_desno;
                                    if (type == 2)
                                        Model = Resources.starce_desno;
                                    X += velocity;
                                }
                                else if (Y + Model.Size.Height / 2 >= 444 && X + Model.Size.Width / 2 < 755)
                                    X += velocity;
                                else if (X + Model.Size.Width / 2 >= 755)
                                {
                                    flipModelDown();
                                    Y += velocity;
                                }
                                else
                                    Y += velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Y += velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (Y + Model.Size.Height / 2 >= 444 && X == 755)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_levo;
                                    if (type == 1)
                                        Model = Resources.dete_levo;
                                    if (type == 2)
                                        Model = Resources.starce_levo;
                                    X -= velocity;
                                }
                                else if (Y + Model.Size.Height / 2 >= 444 && X + Model.Size.Width / 2 > 531)
                                    X -= velocity;
                                else if (X + Model.Size.Width / 2 <= 531)
                                {
                                    flipModelDown();
                                    Y += velocity;
                                }
                                else
                                    Y += velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            break;
                    }
                    break;
                case Direction.EAST:
                    switch (to)
                    {
                        case Direction.WEST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                X -= velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (X + Model.Size.Width / 2 <= 540 && Y == 247)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_dole;
                                    if (type == 1)
                                        Model = Resources.dete_dole;
                                    if (type == 2)
                                        Model = Resources.starce_dole;
                                    Y += velocity;
                                }
                                else if (X + Model.Size.Width / 2 <= 540 && Y < 444)
                                    Y += velocity;
                                else if (Y + Model.Size.Height / 2 >= 444)
                                {
                                    flipModelLeft();
                                    X -= velocity;
                                }
                                else
                                    X -= velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                X -= velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (X + Model.Size.Width / 2 <= 540 && Y == 444)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_gore;
                                    if (type == 1)
                                        Model = Resources.dete_gore;
                                    if (type == 2)
                                        Model = Resources.starce_gore;
                                    Y -= velocity;
                                }
                                else if (X + Model.Size.Width / 2 <= 540 && Y > 247)
                                    Y -= velocity;
                                else if (Y + Model.Size.Height / 2 <= 444)
                                {
                                    flipModelLeft();
                                    X -= velocity;
                                }
                                else
                                    X -= velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            break;
                        case Direction.NORTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                if (X + Model.Size.Width / 2 <= 755 && Y == 247)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_gore;
                                    if (type == 1)
                                        Model = Resources.dete_gore;
                                    if (type == 2)
                                        Model = Resources.starce_gore;
                                    Y -= velocity;
                                }
                                else if (X + Model.Size.Width / 2 <= 755 && Y < 247)
                                    Y -= velocity;
                                else
                                    X -= velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (X + Model.Size.Width / 2 <= 540 && Y == 247)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_gore;
                                    if (type == 1)
                                        Model = Resources.dete_gore;
                                    if (type == 2)
                                        Model = Resources.starce_gore;
                                    Y -= velocity;
                                }
                                else if (X + Model.Size.Width / 2 <= 540 && Y < 247)
                                    Y -= velocity;
                                else
                                    X -= velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                if (X + Model.Size.Width / 2 <= 540 && Y == 444)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_gore;
                                    if (type == 1)
                                        Model = Resources.dete_gore;
                                    if (type == 2)
                                        Model = Resources.starce_gore;
                                    Y -= velocity;
                                }
                                else if (X + Model.Size.Width / 2 <= 540 && Y < 444)
                                    Y -= velocity;
                                else
                                    X -= velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (X + Model.Size.Width / 2 <= 755 && Y == 444)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_gore;
                                    if (type == 1)
                                        Model = Resources.dete_gore;
                                    if (type == 2)
                                        Model = Resources.starce_gore;
                                    Y -= velocity;
                                }
                                else if (X + Model.Size.Width / 2 <= 755 && Y < 444)
                                    Y -= velocity;
                                else
                                    X -= velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            break;
                        case Direction.SOUTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                if (X + Model.Size.Width / 2 <= 540 && Y == 247)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_dole;
                                    if (type == 1)
                                        Model = Resources.dete_dole;
                                    if (type == 2)
                                        Model = Resources.starce_dole;
                                    Y += velocity;
                                }
                                else if (X + Model.Size.Width / 2 <= 540 && Y > 247)
                                    Y += velocity;
                                else
                                    X -= velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (X + Model.Size.Width / 2 <= 755 && Y == 247)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_dole;
                                    if (type == 1)
                                        Model = Resources.dete_dole;
                                    if (type == 2)
                                        Model = Resources.starce_dole;
                                    Y += velocity;
                                }
                                else if (X + Model.Size.Width / 2 <= 755 && Y > 247)
                                    Y += velocity;
                                else
                                    X -= velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                if (X + Model.Size.Width / 2 <= 755 && Y == 444)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_dole;
                                    if (type == 1)
                                        Model = Resources.dete_dole;
                                    if (type == 2)
                                        Model = Resources.starce_dole;
                                    Y += velocity;
                                }
                                else if (X + Model.Size.Width / 2 <= 755 && Y > 444)
                                    Y += velocity;
                                else
                                    X -= velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (X + Model.Size.Width / 2 <= 540 && Y == 444)
                                {
                                    if(type == 0)
                                        Model = Resources.covek_dole;
                                    if (type == 1)
                                        Model = Resources.dete_dole;
                                    if (type == 2)
                                        Model = Resources.starce_dole;
                                    Y += velocity;
                                }
                                else if (X + Model.Size.Width / 2 <= 540 && Y > 444)
                                    Y += velocity;
                                else
                                    X -= velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            break;
                    }
                    break;
                case Direction.WEST:
                    switch (to)
                    {
                        case Direction.EAST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                X += velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (X + Model.Size.Width / 2 >= 755 && Y == 444)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_gore;
                                    if (type == 1)
                                        Model = Resources.dete_gore;
                                    if (type == 2)
                                        Model = Resources.starce_gore;
                                    Y -= velocity;
                                }
                                else if (X + Model.Size.Width / 2 >= 755 && Y > 247)
                                    Y -= velocity;
                                else if (Y <= 247)
                                {
                                    flipModelRight();
                                    X += velocity;
                                }
                                else
                                    X += velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                X += velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (X + Model.Size.Width / 2 >= 755 && Y == 247)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_dole;
                                    if (type == 1)
                                        Model = Resources.dete_dole;
                                    if (type == 2)
                                        Model = Resources.starce_dole;
                                    Y += velocity;
                                }
                                else if (X + Model.Size.Width / 2 >= 755 && Y < 444)
                                    Y += velocity;
                                else if (Y + Model.Size.Height / 2 >= 444)
                                {
                                    flipModelRight();
                                    X += velocity;
                                }
                                else
                                    X += velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            break;
                        case Direction.NORTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                if (X + Model.Size.Width / 2 >= 755 && Y == 444)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_gore;
                                    if (type == 1)
                                        Model = Resources.dete_gore;
                                    if (type == 2)
                                        Model = Resources.starce_gore;
                                    Y -= velocity;
                                }
                                else if (X + Model.Size.Width / 2 >= 755 && Y < 444)
                                    Y -= velocity;
                                else
                                    X += velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (X + Model.Size.Width / 2 >= 540 && Y == 444)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_gore;
                                    if (type == 1)
                                        Model = Resources.dete_gore;
                                    if (type == 2)
                                        Model = Resources.starce_gore;
                                    Y -= velocity;
                                }
                                else if (X + Model.Size.Width / 2 >= 540 && Y < 444)
                                    Y -= velocity;
                                else
                                    X += velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                if (X + Model.Size.Width / 2 >= 540 && Y == 247)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_gore;
                                    if (type == 1)
                                        Model = Resources.dete_gore;
                                    if (type == 2)
                                        Model = Resources.starce_gore;
                                    Y -= velocity;
                                }
                                else if (X + Model.Size.Width / 2 >= 540 && Y < 247)
                                    Y -= velocity;
                                else
                                    X += velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (X + Model.Size.Width / 2 >= 755 && Y == 247)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_gore;
                                    if (type == 1)
                                        Model = Resources.dete_gore;
                                    if (type == 2)
                                        Model = Resources.starce_gore;
                                    Y -= velocity;
                                }
                                else if (X + Model.Size.Width / 2 >= 755 && Y < 247)
                                    Y -= velocity;
                                else
                                    X += velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            break;
                        case Direction.SOUTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                if (X + Model.Size.Width / 2 >= 540 && Y == 444)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_dole;
                                    if (type == 1)
                                        Model = Resources.dete_dole;
                                    if (type == 2)
                                        Model = Resources.starce_dole;
                                    Y += velocity;
                                }
                                else if (X + Model.Size.Width / 2 >= 540 && Y > 444)
                                    Y += velocity;
                                else
                                    X += velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (X + Model.Size.Width / 2 >= 755 && Y == 444)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_dole;
                                    if (type == 1)
                                        Model = Resources.dete_dole;
                                    if (type == 2)
                                        Model = Resources.starce_dole;
                                    Y += velocity;
                                }
                                else if (X + Model.Size.Width / 2 >= 755 && Y > 444)
                                    Y += velocity;
                                else
                                    X += velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                if (X + Model.Size.Width / 2 >= 755 && Y == 247)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_dole;
                                    if (type == 1)
                                        Model = Resources.dete_dole;
                                    if (type == 2)
                                        Model = Resources.starce_dole;
                                    Y += velocity;
                                }
                                else if (X + Model.Size.Width / 2 >= 755 && Y > 247)
                                    Y += velocity;
                                else
                                    X += velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (X + Model.Size.Width / 2 >= 540 && Y == 247)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_dole;
                                    if (type == 1)
                                        Model = Resources.dete_dole;
                                    if (type == 2)
                                        Model = Resources.starce_dole;
                                    Y += velocity;
                                }
                                else if (X + Model.Size.Width / 2 >= 540 && Y > 247)
                                    Y += velocity;
                                else
                                    X += velocity;
                                if (Y >= 648)
                                    done = true;
                            }
                            break;
                    }
                    break;
                case Direction.SOUTH:
                    switch (to)
                    {
                        case Direction.WEST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                if (Y + Model.Size.Height / 2 <= 247 && X == 755)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_levo;
                                    if (type == 1)
                                        Model = Resources.dete_levo;
                                    if (type == 2)
                                        Model = Resources.starce_levo;
                                    X -= velocity;
                                }
                                else if (Y + Model.Size.Height / 2 <= 247 && X < 755)
                                    X -= velocity;
                                else
                                    Y -= velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (Y + Model.Size.Height / 2 <= 444 && X == 755)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_levo;
                                    if (type == 1)
                                        Model = Resources.dete_levo;
                                    if (type == 2)
                                        Model = Resources.starce_levo;
                                    X -= velocity;
                                }
                                else if (Y + Model.Size.Height / 2 <= 444 && X < 755)
                                    X -= velocity;
                                else
                                    Y -= velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                if (Y + Model.Size.Height / 2 <= 444 && X == 531)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_levo;
                                    if (type == 1)
                                        Model = Resources.dete_levo;
                                    if (type == 2)
                                        Model = Resources.starce_levo;
                                    X -= velocity;
                                }
                                else if (Y + Model.Size.Height / 2 <= 444 && X < 531)
                                    X -= velocity;
                                else
                                    Y -= velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (Y + Model.Size.Height / 2 <= 247 && X == 531)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_levo;
                                    if (type == 1)
                                        Model = Resources.dete_levo;
                                    if (type == 2)
                                        Model = Resources.starce_levo;
                                    X -= velocity;
                                }
                                else if (Y + Model.Size.Height / 2 <= 247 && X < 531)
                                    X -= velocity;
                                else
                                    Y -= velocity;
                                if (X + Model.Size.Width <= 0)
                                    done = true;
                            }
                            break;
                        case Direction.EAST:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                if (Y + Model.Size.Height / 2 <= 444 && X == 755)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_desno;
                                    if (type == 1)
                                        Model = Resources.dete_desno;
                                    if (type == 2)
                                        Model = Resources.starce_desno;
                                    X += velocity;
                                }
                                else if (Y + Model.Size.Height / 2 <= 444 && X > 755)
                                    X += velocity;
                                else
                                    Y -= velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (Y + Model.Size.Height / 2 <= 247 && X == 755)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_desno;
                                    if (type == 1)
                                        Model = Resources.dete_desno;
                                    if (type == 2)
                                        Model = Resources.starce_desno;
                                    X += velocity;
                                }
                                else if (Y + Model.Size.Height / 2 <= 247 && X > 755)
                                    X += velocity;
                                else
                                    Y -= velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                if (Y + Model.Size.Height / 2 <= 247 && X == 531)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_desno;
                                    if (type == 1)
                                        Model = Resources.dete_desno;
                                    if (type == 2)
                                        Model = Resources.starce_desno;
                                    X += velocity;
                                }
                                else if (Y + Model.Size.Height / 2 <= 247 && X > 531)
                                    X += velocity;
                                else
                                    Y -= velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (Y + Model.Size.Height / 2 <= 444 && X == 531)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_desno;
                                    if (type == 1)
                                        Model = Resources.dete_desno;
                                    if (type == 2)
                                        Model = Resources.starce_desno;
                                    X += velocity;
                                }
                                else if (Y + Model.Size.Height / 2 <= 444 && X > 531)
                                    X += velocity;
                                else
                                    Y += velocity;
                                if (X >= 1283)
                                    done = true;
                            }
                            break;
                        case Direction.NORTH:
                            if (pointFrom == 0 && pointTo == 1)
                            {
                                Y -= velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 0 && pointTo == 0)
                            {
                                if (Y + Model.Size.Height / 2 <= 247 && X == 755)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_levo;
                                    if (type == 1)
                                        Model = Resources.dete_levo;
                                    if (type == 2)
                                        Model = Resources.starce_levo;
                                    X -= velocity;
                                }
                                else if (Y + Model.Size.Height / 2 <= 247 && X + Model.Size.Width / 2 > 531)
                                    X -= velocity;
                                else if (X <= 531)
                                {
                                    flipModelUp();
                                    Y -= velocity;
                                }
                                else
                                    Y -= velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 0)
                            {
                                Y -= velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            else if (pointFrom == 1 && pointTo == 1)
                            {
                                if (Y + Model.Size.Height / 2 <= 247 && X == 531)
                                {
                                    if (type == 0)
                                        Model = Resources.covek_desno;
                                    if (type == 1)
                                        Model = Resources.dete_desno;
                                    if (type == 2)
                                        Model = Resources.starce_desno;
                                    X += velocity;
                                }
                                else if (Y + Model.Size.Height / 2 <= 247 && X + Model.Size.Width / 2 < 755)
                                    X += velocity;
                                else if (X + Model.Size.Width / 2 >= 755)
                                {
                                    flipModelUp();
                                    Y -= velocity;
                                }
                                else
                                    Y -= velocity;
                                if (Y + Model.Size.Height <= 0)
                                    done = true;
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
