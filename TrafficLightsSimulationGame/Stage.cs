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
        List<Man> manList;
        List<Vehicle> collisionAreaCars;
        List<ObjectType> collisionNorth, collisionSouth, collisionWest, collisionEast;
        public TrafficLights Lights;
        public SoundPlayer sudar;
        public Options def;
        public int score { get; set; }
        public Stage(Options o)
        {
            sudar = new SoundPlayer(Resources.sudar);
            def = o;
            score = 0;
            carsEast = new List<Vehicle>();
            carsNorth = new List<Vehicle>();
            carsWest = new List<Vehicle>();
            carsSouth = new List<Vehicle>();
            manList = new List<Man>();
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
                        manList.Add(new Man(531, -10,type, ObjectType.Direction.WEST, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    else if(to == 0 && pointFrom == 1)
                        manList.Add(new Man(755, -10, type, ObjectType.Direction.WEST, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    if (to == 1 && pointFrom == 0)
                        manList.Add(new Man(531, -10, type, ObjectType.Direction.SOUTH, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    else if (to == 1 && pointFrom == 1)
                        manList.Add(new Man(755, -10, type, ObjectType.Direction.SOUTH, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    if (to == 2 && pointFrom == 0)
                        manList.Add(new Man(531, -10, type, ObjectType.Direction.EAST, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    else if (to == 2 && pointFrom == 1)
                        manList.Add(new Man(755, -10, type, ObjectType.Direction.EAST, ObjectType.Direction.NORTH, pointFrom, pointTo));
                    break;
                case 1:
                    if (to == 0 && pointFrom == 0)
                        manList.Add(new Man(1293, 247, type, ObjectType.Direction.WEST, ObjectType.Direction.EAST, pointFrom, pointTo));
                    else if (to == 0 && pointFrom == 1)
                        manList.Add(new Man(1293, 444, type, ObjectType.Direction.WEST, ObjectType.Direction.EAST, pointFrom, pointTo));
                    if (to == 1 && pointFrom == 0)
                        manList.Add(new Man(1293, 247, type, ObjectType.Direction.SOUTH, ObjectType.Direction.EAST, pointFrom, pointTo));
                    else if (to == 1 && pointFrom == 1)
                        manList.Add(new Man(1293, 444, type, ObjectType.Direction.SOUTH, ObjectType.Direction.EAST, pointFrom, pointTo));
                    if (to == 2 && pointFrom == 0)
                        manList.Add(new Man(1293, 247, type, ObjectType.Direction.NORTH, ObjectType.Direction.EAST, pointFrom, pointTo));
                    else if (to == 2 && pointFrom == 1)
                        manList.Add(new Man(1293, 444, type, ObjectType.Direction.NORTH, ObjectType.Direction.EAST, pointFrom, pointTo));
                    break;
                case 2:
                    if (to == 0 && pointFrom == 0)
                        manList.Add(new Man(755, 658, type, ObjectType.Direction.WEST, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    else if (to == 0 && pointFrom == 1)
                        manList.Add(new Man(531, 658, type, ObjectType.Direction.WEST, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    if (to == 1 && pointFrom == 0)
                        manList.Add(new Man(755, 658, type, ObjectType.Direction.NORTH, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    else if (to == 1 && pointFrom == 1)
                        manList.Add(new Man(531, 658, type, ObjectType.Direction.NORTH, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    if (to == 2 && pointFrom == 0)
                        manList.Add(new Man(755, 658, type, ObjectType.Direction.EAST, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    else if (to == 2 && pointFrom == 1)
                        manList.Add(new Man(531, 658, type, ObjectType.Direction.EAST, ObjectType.Direction.SOUTH, pointFrom, pointTo));
                    break;
                case 3:
                    if (to == 0 && pointFrom == 0)
                        manList.Add(new Man(-10, 444, type, ObjectType.Direction.NORTH, ObjectType.Direction.WEST, pointFrom, pointTo));
                    else if (to == 0 && pointFrom == 1)
                        manList.Add(new Man(-10, 247, type, ObjectType.Direction.NORTH, ObjectType.Direction.WEST, pointFrom, pointTo));
                    if (to == 1 && pointFrom == 0)
                        manList.Add(new Man(-10, 444, type, ObjectType.Direction.SOUTH, ObjectType.Direction.WEST, pointFrom, pointTo));
                    else if (to == 1 && pointFrom == 1)
                        manList.Add(new Man(-10, 247, type, ObjectType.Direction.SOUTH, ObjectType.Direction.WEST, pointFrom, pointTo));
                    if (to == 2 && pointFrom == 0)
                        manList.Add(new Man(-10, 444, type, ObjectType.Direction.EAST, ObjectType.Direction.WEST, pointFrom, pointTo));
                    else if (to == 2 && pointFrom == 1)
                        manList.Add(new Man(-10, 247, type, ObjectType.Direction.EAST, ObjectType.Direction.WEST, pointFrom, pointTo));
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
            foreach (Man m in manList)
                m.draw(g);
            Lights.Draw(g);
        }
        public void selected(Point p)
        {
            foreach(Man m in manList)
            {
                if (p.X >= m.X && p.X <= m.X + m.getWidth() && p.Y >= m.Y && p.Y <= m.Y + m.getHeight())
                    m.isSelected = true;
                else
                    m.isSelected = false;
            }
        }
        private void removeCarAndMan()
        {
            if(carsNorth.Count != 0)
            {
                if (carsNorth[0].done)
                {
                    score+=10;
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
                    score+=10;
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
                    score+=10;
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
                    score+=10;
                    if (carsWest.Count == 1)
                        carsWest.RemoveAt(0);
                    else
                    {
                        carsWest[1].inFront = null;
                        carsWest.RemoveAt(0);
                    }
                }
            }
            if(manList.Count != 0)
            {
                if (manList[0].done)
                    manList.RemoveAt(0);
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
            foreach (Man m in manList)
                m.move();
            removeCarAndMan();
        }
        public void inCollisionArea()
        {
            foreach (Vehicle c in carsEast)
            {
                if (collisionAreaCars.Contains(c))
                {
                    if (c.X + c.getWidth() <= 560)
                        collisionAreaCars.Remove(c);
                }
                else
                {
                    if (c.X <= 742 && c.X > 560)
                        collisionAreaCars.Add(c);
                }
                if (collisionEast.Contains(c))
                {
                    if (c.X + c.getWidth() <= 740)
                        collisionEast.Remove(c);
                }
                else
                {
                    if (c.X <= 820 && c.X > 740)
                        collisionEast.Add(c);
                }
                if (collisionWest.Contains(c))
                {
                    if (c.X + c.getWidth() <= 482)
                        collisionWest.Remove(c);
                }
                else
                {
                    if (c.X <= 560 && c.X > 482)
                        collisionWest.Add(c);
                }
            }
            foreach (Vehicle c in carsNorth)
            {
                if (collisionAreaCars.Contains(c))
                {
                    if (c.Y >= 430)
                        collisionAreaCars.Remove(c);
                }
                else
                {
                    if (c.Y + c.getHeight() >= 280 && c.Y < 430)
                        collisionAreaCars.Add(c);
                }
                if (collisionNorth.Contains(c))
                {
                    if (c.Y >= 280)
                        collisionNorth.Remove(c);
                }
                else
                {
                    if (c.Y >= 215 && c.Y < 280)
                        collisionNorth.Add(c);
                }
                if (collisionSouth.Contains(c))
                {
                    if (c.Y >= 498)
                        collisionSouth.Remove(c);
                }
                else
                {
                    if (c.Y + c.getHeight() >= 482 && c.Y < 560)
                        collisionSouth.Add(c);
                }
            }
           foreach (Vehicle c in carsWest)
            {
                if (collisionAreaCars.Contains(c))
                {
                    if (c.X > 742)
                        collisionAreaCars.Remove(c);
                }
                else
                {
                    if (c.X + c.getWidth() >= 560 && c.X < 742)
                        collisionAreaCars.Add(c);
                }
                if (collisionWest.Contains(c))
                {
                    if (c.X >= 560)
                        collisionWest.Remove(c);
                }
                else
                {
                    if (c.X + c.getWidth() >= 482  && c.X < 560)
                        collisionWest.Add(c);
                }
                if (collisionEast.Contains(c))
                {
                    if (c.X >= 820)
                        collisionEast.Remove(c);
                }
                else
                {
                    if (c.X + c.getWidth() >= 740 && c.X < 820)
                        collisionEast.Add(c);
                }
            }
            foreach (Vehicle c in carsSouth)
            {
                if (collisionAreaCars.Contains(c))
                {
                    if (c.Y + c.getHeight() <= 280)
                        collisionAreaCars.Remove(c);
                }
                else
                {
                    if (c.Y <= 430 && c.Y > 280)
                        collisionAreaCars.Add(c);
                }
                if (collisionSouth.Contains(c))
                {
                    if (c.Y + c.getHeight() <= 431)
                        collisionSouth.Remove(c);
                }
                else
                {
                    if (c.Y <=498 && c.Y > 431)
                        collisionSouth.Add(c);
                }
                if (collisionNorth.Contains(c))
                {
                    if (c.Y + c.getHeight() <= 215)
                        collisionNorth.Remove(c);
                }
                else
                {
                    if (c.Y <= 280 && c.Y > 215)
                        collisionNorth.Add(c);
                }
            }
            foreach(Man m in manList)
            {
                if (collisionNorth.Contains(m))
                {
                    if (m.X + m.getWidth() / 2 <= 560 || m.X + m.getWidth() / 2 >= 740)
                        collisionNorth.Remove(m);
                    continue;
                }
                else
                {
                    if (m.X + m.getWidth() / 2 >= 560 && m.X + m.getWidth() / 2 < 740 && m.Y + m.getHeight() / 2 > 215 && m.Y + m.getHeight() / 2 < 280)
                    {
                        collisionNorth.Add(m);
                        continue;
                    }
                        
                }
                if (collisionEast.Contains(m))
                {
                    if (m.Y + m.getHeight() / 2 <= 280 || m.Y + m.getHeight() / 2 >= 431)
                        collisionEast.Remove(m);
                    continue;
                }
                else
                {
                    if (m.X + m.getWidth() / 2 >= 740 && m.X + m.getWidth() / 2 < 820 && m.Y + m.getHeight() / 2 > 280 && m.Y + m.getHeight() / 2 < 431)
                    {
                        collisionEast.Add(m);
                        continue;
                    }
                        
                }
                if (collisionSouth.Contains(m))
                {
                    if (m.X + m.getWidth() / 2 <= 560 || m.X + m.getWidth() / 2 >= 740)
                        collisionNorth.Remove(m);
                }
                else
                {
                    if (m.X + m.getWidth() / 2 >= 560 && m.X + m.getWidth() / 2 < 740 && m.Y + m.getHeight() / 2 > 431 && m.Y + m.getHeight() / 2 < 498)
                    {
                        collisionSouth.Add(m);
                        continue;
                    }
                }
                if (collisionWest.Contains(m))
                {
                    if (m.Y + m.getHeight() / 2 <= 280 || m.Y + m.getHeight() / 2 >= 431)
                        collisionWest.Remove(m);
                    continue;
                }
                else
                {
                    if (m.X + m.getWidth() / 2 >= 482 && m.X + m.getWidth() / 2 < 560 && m.Y + m.getHeight() / 2 > 280 && m.Y + m.getHeight() / 2 < 431)
                    {
                        collisionWest.Add(m);
                        continue;
                    }

                }
            }
                
        }
        public Point checkCollisionCars()
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
        public Point checkCollisionMan()
        {
            foreach(ObjectType v in collisionNorth)
            {
                if(v is Vehicle)
                foreach(ObjectType m in collisionNorth)
                {
                        if (m is Man)
                        {
                            if ((m.X + 10 > v.X && m.X + 10 <= v.X + v.getWidth() && m.Y + 10 > v.Y && m.Y + 10 < v.Y + v.getHeight()) || (m.X + 10 > v.X && m.X + 10 <= v.X + v.getWidth() && m.Y - 10 + m.getHeight() >= v.Y && m.Y - 10 + m.getHeight() < v.Y + v.getHeight()))
                                return new Point(m.X - 10, m.Y - 10);
                            else if ((m.X - 10 + m.getWidth() >= v.X && m.X - 10 + m.getWidth() < v.X + v.getWidth() && m.Y + 10 > v.Y && m.Y + 10 < v.Y + v.getHeight()) || (m.X - 10 + m.getWidth() >= v.X && m.X - 10 + m.getWidth() < v.X + v.getWidth() && m.Y - 10 + m.getHeight() >= v.Y && m.Y - 10 + m.getHeight() < v.Y + v.getHeight()))
                                return new Point(m.X - 10, m.Y - 10);
                        }
                }
            }
            foreach (ObjectType v in collisionEast)
            {
                if (v is Vehicle)
                    foreach (ObjectType m in collisionEast)
                    {
                        if (m is Man)
                        {
                            if ((m.X + 10 >= v.X && m.X + 10 < v.X + v.getWidth() && m.Y + 10 > v.Y && m.Y - 10 <= v.Y + v.getHeight()) || (m.X - 10 + m.getWidth() >= v.X && m.X - 10 + m.getWidth() < v.X + v.getWidth() && m.Y + 10 > v.Y && m.Y + 10 <= v.Y + v.getHeight()))
                                return new Point(m.X - 10, m.Y - 10);
                            else if ((m.X + 10 >= v.X && m.X + 10 < v.X + v.getWidth() && m.Y - 10 + m.getHeight() >= v.Y && m.Y - 10 + m.getHeight() < v.Y + v.getHeight()) || (m.X - 10 + m.getWidth() >= v.X && m.X - 10 + m.getWidth() < v.X + v.getWidth() && m.Y - 10 + m.getHeight() >= v.Y && m.Y - 10 + m.getHeight() < v.Y + v.getHeight()))
                                return new Point(m.X - 10, m.Y - 10);
                        }
                    }
            }
            foreach (ObjectType v in collisionSouth)
            {
                if (v is Vehicle)
                    foreach (ObjectType m in collisionSouth)
                    {
                        if (m is Man)
                        {
                            if ((m.X + 10 > v.X && m.X + 10 <= v.X + v.getWidth() && m.Y + 10 > v.Y && m.Y + 10 < v.Y + v.getHeight()) || (m.X + 10 > v.X && m.X + 10 <= v.X + v.getWidth() && m.Y - 10 + m.getHeight() >= v.Y && m.Y - 10 + m.getHeight() < v.Y + v.getHeight()))
                                return new Point(m.X - 10, m.Y - 10);
                            else if ((m.X - 10 + m.getWidth() >= v.X && m.X - 10 + m.getWidth() < v.X + v.getWidth() && m.Y + 10 > v.Y && m.Y + 10 < v.Y + v.getHeight()) || (m.X - 10 + m.getWidth() >= v.X && m.X - 10 + m.getWidth() < v.X + v.getWidth() && m.Y - 10 + m.getHeight() >= v.Y && m.Y - 10 + m.getHeight() < v.Y + v.getHeight()))
                                return new Point(m.X - 10, m.Y - 10);
                        }
                    }
            }
            foreach (ObjectType v in collisionWest)
            {
                if (v is Vehicle)
                    foreach (ObjectType m in collisionWest)
                    {
                        if (m is Man)
                        {
                            if ((m.X + 10 >= v.X && m.X + 10 < v.X + v.getWidth() && m.Y + 10 > v.Y && m.Y - 10 <= v.Y + v.getHeight()) || (m.X - 10 + m.getWidth() >= v.X && m.X - 10 + m.getWidth() < v.X + v.getWidth() && m.Y + 10 > v.Y && m.Y + 10 <= v.Y + v.getHeight()))
                                return new Point(m.X - 10, m.Y - 10);
                            else if ((m.X + 10 >= v.X && m.X + 10 < v.X + v.getWidth() && m.Y - 10 + m.getHeight() >= v.Y && m.Y - 10 + m.getHeight() < v.Y + v.getHeight()) || (m.X - 10 + m.getWidth() >= v.X && m.X - 10 + m.getWidth() < v.X + v.getWidth() && m.Y - 10 + m.getHeight() >= v.Y && m.Y - 10 + m.getHeight() < v.Y + v.getHeight()))
                                return new Point(m.X - 10, m.Y - 10);
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
            if (i == 4)
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
            if(def.sound == true)
                sudar.Play();
            g.DrawImage(Resources.BAM, loc.X, loc.Y);
        }
    }
}
