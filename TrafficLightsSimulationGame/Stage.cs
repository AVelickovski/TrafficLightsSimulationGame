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
        List<Man> manNorth, manSouth, manWest, manEast;
        List<Vehicle> collisionAreaCars;
        List<ObjectType> collisionNorth, collisionSouth, collisionWest, collisionEast;
        public TrafficLights Lights;
        public SoundPlayer sudar;
        public Stage()
        {
            carsEast = new List<Vehicle>();
            carsNorth = new List<Vehicle>();
            carsWest = new List<Vehicle>();
            carsSouth = new List<Vehicle>();
            manEast = new List<Man>();
            manNorth = new List<Man>();
            manSouth = new List<Man>();
            manWest = new List<Man>();
            collisionNorth = new List<ObjectType>();
            collisionSouth = new List<ObjectType>();
            collisionWest = new List<ObjectType>();
            collisionEast = new List<ObjectType>();
            collisionAreaCars = new List<Vehicle>();
            Lights = new TrafficLights();
        }
        public void addCar(int direction, int type)
        {
            if(direction == 0)
            {
                if (carsNorth.Count == 0)
                    carsNorth.Add(new Vehicle(590, -60, type, Vehicle.Direction.NORTH, null));
                else
                    carsNorth.Add(new Vehicle(590, -60, type, Vehicle.Direction.NORTH, carsNorth[carsNorth.Count-1]));
            }
            else if(direction == 1)
            {
                if (carsEast.Count == 0)
                    carsEast.Add(new Vehicle(1343, 300, type, Vehicle.Direction.EAST, null));
                else
                    carsEast.Add(new Vehicle(1343, 300, type, Vehicle.Direction.EAST, carsEast[carsEast.Count - 1]));
            }
            else if (direction == 2)
            {
                if (carsWest.Count == 0)
                    carsWest.Add(new Vehicle(-60, 380, type, Vehicle.Direction.WEST, null));
                else
                    carsWest.Add(new Vehicle(-60, 380, type, Vehicle.Direction.WEST, carsWest[carsWest.Count - 1]));
            }
            else
            {
                if (carsSouth.Count == 0)
                    carsSouth.Add(new Vehicle(676, 678, type, Vehicle.Direction.SOUTH, null));
                else
                    carsSouth.Add(new Vehicle(676, 678, type, Vehicle.Direction.SOUTH, carsSouth[carsSouth.Count - 1]));
            }
        }
        public void addMan(int from,int pointFrom, int to, int pointTo, int type)
        {
            switch (from)
            {
                case 0:
                    if (to == 0 && pointFrom == 0)
                        manNorth.Add(new Man(531, -10,type, ObjectType.Direction.WEST, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    else if(to == 0 && pointFrom == 1)
                        manNorth.Add(new Man(750, -10, type, ObjectType.Direction.WEST, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    if (to == 1 && pointFrom == 0)
                        manNorth.Add(new Man(531, -10, type, ObjectType.Direction.SOUTH, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    else if (to == 0 && pointFrom == 1)
                        manNorth.Add(new Man(750, -10, type, ObjectType.Direction.SOUTH, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    if (to == 2 && pointFrom == 0)
                        manNorth.Add(new Man(531, -10, type, ObjectType.Direction.EAST, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    else if (to == 2 && pointFrom == 1)
                        manNorth.Add(new Man(750, -10, type, ObjectType.Direction.EAST, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    break;
                case 1:
                    if (to == 0 && pointFrom == 0)
                        manNorth.Add(new Man(1293, 250, type, ObjectType.Direction.WEST, ObjectType.Direction.EAST, pointFrom, pointTo));
                    else if (to == 0 && pointFrom == 1)
                        manNorth.Add(new Man(1293, 444, type, ObjectType.Direction.WEST, ObjectType.Direction.EAST, pointFrom, pointTo));
                    if (to == 1 && pointFrom == 0)
                        manNorth.Add(new Man(1293, 250, type, ObjectType.Direction.SOUTH, ObjectType.Direction.EAST, pointFrom, pointTo));
                    else if (to == 0 && pointFrom == 1)
                        manNorth.Add(new Man(1293, 444, type, ObjectType.Direction.SOUTH, ObjectType.Direction.EAST, pointFrom, pointTo));
                    if (to == 2 && pointFrom == 0)
                        manNorth.Add(new Man(1293, 250, type, ObjectType.Direction.NORTH, ObjectType.Direction.EAST, pointFrom, pointTo));
                    else if (to == 2 && pointFrom == 1)
                        manNorth.Add(new Man(1293, 444, type, ObjectType.Direction.NORTH, ObjectType.Direction.EAST, pointFrom, pointTo));
                    break;
                case 2:
                    if (to == 0 && pointFrom == 0)
                        manNorth.Add(new Man(750, 658, type, ObjectType.Direction.WEST, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    else if (to == 0 && pointFrom == 1)
                        manNorth.Add(new Man(531, 658, type, ObjectType.Direction.WEST, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    if (to == 1 && pointFrom == 0)
                        manNorth.Add(new Man(750, 658, type, ObjectType.Direction.NORTH, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    else if (to == 0 && pointFrom == 1)
                        manNorth.Add(new Man(531, 658, type, ObjectType.Direction.NORTH, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    if (to == 2 && pointFrom == 0)
                        manNorth.Add(new Man(750, 658, type, ObjectType.Direction.EAST, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    else if (to == 2 && pointFrom == 1)
                        manNorth.Add(new Man(531, 658, type, ObjectType.Direction.EAST, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    break;
                case 3:
                    if (to == 0 && pointFrom == 0)
                        manNorth.Add(new Man(-10, 444, type, ObjectType.Direction.NORTH, ObjectType.Direction.WEST, pointFrom, pointTo));
                    else if (to == 0 && pointFrom == 1)
                        manNorth.Add(new Man(-10, 250, type, ObjectType.Direction.NORTH, ObjectType.Direction.WEST, pointFrom, pointTo));
                    if (to == 1 && pointFrom == 0)
                        manNorth.Add(new Man(-10, 444, type, ObjectType.Direction.SOUTH, ObjectType.Direction.WEST, pointFrom, pointTo));
                    else if (to == 0 && pointFrom == 1)
                        manNorth.Add(new Man(-10, 250, type, ObjectType.Direction.SOUTH, ObjectType.Direction.WEST, pointFrom, pointTo));
                    if (to == 2 && pointFrom == 0)
                        manNorth.Add(new Man(-10, 444, type, ObjectType.Direction.EAST, ObjectType.Direction.WEST, pointFrom, pointTo));
                    else if (to == 2 && pointFrom == 1)
                        manNorth.Add(new Man(-10, 250, type, ObjectType.Direction.EAST, ObjectType.Direction.WEST, pointFrom, pointTo));
                    break;
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
            foreach (Man m in manNorth)
                m.draw(g);
            foreach(Man m in manEast)
                m.draw(g);
            foreach (Man m in manSouth)
                m.draw(g);
            foreach (Man m in manWest)
                m.draw(g);
            Lights.Draw(g);
        }
        private void removeCar()
        {
            if(carsNorth.Count != 0)
            {
                if (carsNorth[0].done)
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
                if (carsEast[0].done)
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
                if (carsSouth[0].done)
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
                if (carsWest[0].done)
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
        private void removeMan()
        {
            if (manEast.Count != 0)
                if (manEast[0].done)
                    manEast.RemoveAt(0);
            if(manNorth.Count !=0)
                if (manNorth[0].done)
                    manNorth.RemoveAt(0);
            if(manSouth.Count != 0)
                if (manSouth[0].done)
                    manSouth.RemoveAt(0);
            if(manWest.Count != 0)
                if (manWest[0].done)
                    manWest.RemoveAt(0);
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
            foreach (Man m in manNorth)
                m.move();
            foreach (Man m in manEast)
                m.move();
            foreach (Man m in manSouth)
                m.move();
            foreach (Man m in manWest)
                m.move();
            removeCar();
            removeMan();
        }
        public void inCollisionArea()
        {
            foreach (Vehicle c in carsEast)
            {
                if (collisionAreaCars.IndexOf(c) != -1)
                {
                    if (c.X + c.getWidth() <= 560)
                        collisionAreaCars.Remove(c);
                }
                else
                {
                    if (c.X <= 742 && c.X > 560)
                        collisionAreaCars.Add(c);
                }
            }
            foreach (Vehicle c in carsNorth)
            {
                if (collisionAreaCars.IndexOf(c) != -1)
                {
                    if (c.Y >= 430)
                        collisionAreaCars.Remove(c);
                }
                else
                {
                    if (c.Y + c.getHeight()>= 280 && c.Y < 430)
                        collisionAreaCars.Add(c);
                }
            }
           foreach (Vehicle c in carsWest)
            {
                if (collisionAreaCars.IndexOf(c) != -1)
                {
                    if (c.X > 742)
                        collisionAreaCars.Remove(c);
                }
                else
                {
                    if (c.X + c.getWidth() >= 560 && c.X < 742)
                        collisionAreaCars.Add(c);
                }
            }
            foreach (Vehicle c in carsSouth)
                if (collisionAreaCars.IndexOf(c) != -1)
                {
                    if (c.Y + c.getHeight() <= 280)
                        collisionAreaCars.Remove(c);
                }
                else
                {
                    if (c.Y <= 430 && c.Y > 280 )
                        collisionAreaCars.Add(c);
                }
                
        }
        public Point checkCollision()
        {
            foreach(Vehicle c in collisionAreaCars)
            {
                foreach(Vehicle car in collisionAreaCars)
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
            if (i == 9)
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
            if (i == 9)
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
