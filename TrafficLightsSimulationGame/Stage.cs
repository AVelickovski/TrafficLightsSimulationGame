using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using TrafficLightsSimulationGame.Properties;

namespace TrafficLightsSimulationGame
{
    public class Stage
    {
        List<Vehicle> carsNorth, carsSouth, carsWest, carsEast;
        List<Vehicle> collisionArea;
        public TrafficLights Lights;
        public SoundPlayer sudar;
        public Stage()
        {
            carsEast = new List<Vehicle>();
            carsNorth = new List<Vehicle>();
            carsWest = new List<Vehicle>();
            carsSouth = new List<Vehicle>();
            collisionArea = new List<Vehicle>();
            Lights = new TrafficLights();
        }
        public void add(int direction, int type)
        {
            if(direction == 0)
            {
                if (carsNorth.Count == 0)
                    carsNorth.Add(new Vehicle(580, -30, type, Vehicle.Direction.NORTH, null));
                else
                    carsNorth.Add(new Vehicle(580, -30, type, Vehicle.Direction.NORTH, carsNorth[carsNorth.Count-1]));
            }
            else if(direction == 1)
            {
                if (carsEast.Count == 0)
                    carsEast.Add(new Vehicle(1313, 300, type, Vehicle.Direction.EAST, null));
                else
                    carsEast.Add(new Vehicle(1313, 300, type, Vehicle.Direction.EAST, carsEast[carsEast.Count - 1]));
            }
            else if (direction == 2)
            {
                if (carsWest.Count == 0)
                    carsWest.Add(new Vehicle(-30, 380, type, Vehicle.Direction.WEST, null));
                else
                    carsWest.Add(new Vehicle(-30, 380, type, Vehicle.Direction.WEST, carsWest[carsWest.Count - 1]));
            }
            else
            {
                if (carsSouth.Count == 0)
                    carsSouth.Add(new Vehicle(676, 678, type, Vehicle.Direction.SOUTH, null));
                else
                    carsSouth.Add(new Vehicle(676, 678, type, Vehicle.Direction.SOUTH, carsSouth[carsSouth.Count - 1]));
            }
        }

        public void Draw(Graphics g)
        {
            foreach (Vehicle c in carsEast)
                c.draw(g);
            foreach (Vehicle c in carsNorth)
                c.draw(g);
            foreach (Vehicle c in carsWest)
                c.draw(g);
            foreach (Vehicle c in carsSouth)
                c.draw(g);
            Lights.Draw(g);
        }
        private void removeCar()
        {
            if(carsNorth.Count != 0)
            {
                if (carsNorth[0].Y > 595)
                {
                    if(carsNorth.Count == 1)
                        carsNorth.RemoveAt(0);
                    else
                    {
                        carsNorth[1].inFront = null;
                        carsNorth.RemoveAt(0);
                    }
                }
                    
            }
            if (carsEast.Count != 0)
            {
                if (carsEast[0].X + carsEast[0].getWidth()< 0)
                {
                    if (carsEast.Count == 1)
                        carsEast.RemoveAt(0);
                    else
                    {
                        carsEast[1].inFront = null;
                        carsEast.RemoveAt(0);
                    }
                }
            }
            if (carsSouth.Count != 0)
            {
                if (carsSouth[0].Y + carsSouth[0].getHeight() < 0)
                {
                    if (carsSouth.Count == 1)
                        carsSouth.RemoveAt(0);
                    else
                    {
                        carsSouth[1].inFront = null;
                        carsSouth.RemoveAt(0);
                    }
                }
            }
            if (carsWest.Count != 0)
            {
                if (carsWest[0].X > 1353)
                {
                    if (carsWest.Count == 1)
                        carsWest.RemoveAt(0);
                    else
                    {
                        carsWest[1].inFront = null;
                        carsWest.RemoveAt(0);
                    }
                }
            }
        }
        public void move()
        {
            foreach (Vehicle c in carsEast)
                c.move(Lights.Lights[1].isGreen);
            foreach (Vehicle c in carsNorth)
                c.move(Lights.Lights[0].isGreen);
            foreach (Vehicle c in carsWest)
                c.move(Lights.Lights[2].isGreen);
            foreach (Vehicle c in carsSouth)
                c.move(Lights.Lights[3].isGreen);
            removeCar();
        }
        public void inCollisionArea()
        {
            foreach (Vehicle c in carsEast)
            {
                if (collisionArea.IndexOf(c) != -1)
                {
                    if (c.X + c.getWidth() <= 560)
                        collisionArea.Remove(c);
                }
                else
                {
                    if (c.X <= 742 && c.X > 560)
                        collisionArea.Add(c);
                }
            }
            foreach (Vehicle c in carsNorth)
            {
                if (collisionArea.IndexOf(c) != -1)
                {
                    if (c.Y >= 430)
                        collisionArea.Remove(c);
                }
                else
                {
                    if (c.Y + c.getHeight()>= 280 && c.Y < 430)
                        collisionArea.Add(c);
                }
            }
           foreach (Vehicle c in carsWest)
            {
                if (collisionArea.IndexOf(c) != -1)
                {
                    if (c.X > 742)
                        collisionArea.Remove(c);
                }
                else
                {
                    if (c.X + c.getWidth() >= 560 && c.X < 742)
                        collisionArea.Add(c);
                }
            }
            foreach (Vehicle c in carsSouth)
                if (collisionArea.IndexOf(c) != -1)
                {
                    if (c.Y + c.getHeight() <= 280)
                        collisionArea.Remove(c);
                }
                else
                {
                    if (c.Y <= 430 && c.Y > 280 )
                        collisionArea.Add(c);
                }
                
        }
        public Point checkCollision()
        {
            foreach(Vehicle c in collisionArea)
            {
                foreach(Vehicle car in collisionArea)
                {
                    if (c.dir == Vehicle.Direction.EAST)
                    {
                        switch (car.dir)
                        {
                            case Vehicle.Direction.NORTH:
                                if ((c.X <= car.X + car.getWidth() && c.X > car.X && c.Y <= car.Y + car.getHeight() && c.Y > car.Y) || (c.X <= car.X + car.getWidth() && c.X > car.X && c.Y + c.getHeight() < car.Y + car.getHeight() && c.Y + c.getHeight() > car.Y))
                                    return new Point(c.X ,c.Y);
                                break;
                            case Vehicle.Direction.SOUTH:
                                if ((c.X <= car.X + car.getWidth() && c.X > car.X && c.Y <= car.Y + car.getHeight() && c.Y > car.Y) || (c.X <= car.X + car.getWidth() && c.X > car.X && c.Y + c.getHeight() < car.Y + car.getHeight() && c.Y + c.getHeight() > car.Y))
                                    return new Point(c.X, c.Y); ;
                                break;
                        }
                    }
                    else if(c.dir == Vehicle.Direction.NORTH)
                    {
                        switch (car.dir)
                        {
                            case Vehicle.Direction.EAST:
                                if ((c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()) || (c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X, c.Y); ;
                                break;
                            case Vehicle.Direction.WEST:
                                if ((c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()) || (c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X, c.Y); ;
                                break;
                        }
                    }
                    else if(c.dir == Vehicle.Direction.WEST)
                    {
                        switch (car.dir)
                        {
                            case Vehicle.Direction.NORTH:
                                if ((c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y >= car.Y && c.Y <= car.Y + car.getHeight()) || (c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y + c.getHeight() > car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X , c.Y); ;
                                break;
                            case Vehicle.Direction.SOUTH:
                                if ((c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y >= car.Y && c.Y <= car.Y + car.getHeight()) || (c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y + c.getHeight() > car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X , c.Y); ;
                                break;
                        }
                    }
                    else if(c.dir == Vehicle.Direction.SOUTH)
                    {
                        switch (car.dir)
                        {
                            case Vehicle.Direction.WEST:
                                if ((c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y >= car.Y && c.Y <= car.Y + car.getHeight()) || (c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X, c.Y); ;
                                break;
                            case Vehicle.Direction.EAST:
                                if ((c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y >= car.Y && c.Y <= car.Y + car.getHeight()) || (c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X, c.Y); ;
                                break;
                        }
                    }
                }
            }
            return Point.Empty;
        }
        public bool checkJam()
        {
            int i = 0;
            foreach(Vehicle c in carsNorth)
            {
                if (c.isWaiting)
                    i ++;
            }
            if (i == 5)
                return true;
            else
                i = 0;
            foreach (Vehicle c in carsWest)
            {
                if (c.isWaiting)
                    i++;
            }
            if (i == 6)
                return true;
            else
                i = 0;
            foreach (Vehicle c in carsSouth)
            {
                if (c.isWaiting)
                    i++;
            }
            if (i == 5)
                return true;
            else
                i = 0;
            foreach (Vehicle c in carsEast)
            {
                if (c.isWaiting)
                    i++;
            }
            if (i == 8)
                return true;
            else
                i = 0;
            return false;
        }
        public void drawBam(Point loc, Graphics g)
        {
            sudar = new SoundPlayer(Resources.sudar);
            sudar.Play();
            g.DrawImage(Resources.BAM, loc.X, loc.Y);
        }
    }
}
