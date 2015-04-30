using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightsSimulationGame.Properties;

namespace TrafficLightsSimulationGame
{
    public class Stage
    {
        List<Car> carsNorth, carsSouth, carsWest, carsEast;
        List<Car> collisionArea;
        public TrafficLights Lights;
        public Stage()
        {
            carsEast = new List<Car>();
            carsNorth = new List<Car>();
            carsWest = new List<Car>();
            carsSouth = new List<Car>();
            collisionArea = new List<Car>();
            Lights = new TrafficLights();
        }
        public void add(int direction)
        {
            if(direction == 0)
            {
                if (carsNorth.Count == 0)
                    carsNorth.Add(new Car(560, -30, 1, Car.Direction.NORTH, null));
                else
                    carsNorth.Add(new Car(560, -30, 1, Car.Direction.NORTH, carsNorth[carsNorth.Count-1]));
            }
            else if(direction == 1)
            {
                if (carsEast.Count == 0)
                    carsEast.Add(new Car(1353, 280, 1, Car.Direction.EAST, null));
                else
                    carsEast.Add(new Car(1353, 280, 1, Car.Direction.EAST, carsEast[carsEast.Count - 1]));
            }
            else if (direction == 2)
            {
                if (carsWest.Count == 0)
                    carsWest.Add(new Car(-30, 350, 1, Car.Direction.WEST, null));
                else
                    carsWest.Add(new Car(-30, 350, 1, Car.Direction.WEST, carsWest[carsWest.Count - 1]));
            }
            else
            {
                if (carsSouth.Count == 0)
                    carsSouth.Add(new Car(660, 595, 1, Car.Direction.SOUTH, null));
                else
                    carsSouth.Add(new Car(660, 595, 1, Car.Direction.SOUTH, carsSouth[carsSouth.Count - 1]));
            }
        }

        public void Draw(Graphics g)
        {
            foreach (Car c in carsEast)
                c.draw(g);
            foreach (Car c in carsNorth)
                c.draw(g);
            foreach (Car c in carsWest)
                c.draw(g);
            foreach (Car c in carsSouth)
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
            foreach (Car c in carsEast)
                c.move(Lights.Lights[1].isGreen);
            foreach (Car c in carsNorth)
                c.move(Lights.Lights[0].isGreen);
            foreach (Car c in carsWest)
                c.move(Lights.Lights[2].isGreen);
            foreach (Car c in carsSouth)
                c.move(Lights.Lights[3].isGreen);
            removeCar();
        }
        public void inCollisionArea()
        {
            foreach (Car c in carsEast)
            {
                if (collisionArea.IndexOf(c) != -1)
                {
                    if (c.X + c.getWidth() <= 510)
                        collisionArea.Remove(c);
                }
                else
                {
                    if (c.X < 715 && c.X > 510)
                        collisionArea.Add(c);
                }
            }
            foreach (Car c in carsNorth)
            {
                if (collisionArea.IndexOf(c) != -1)
                {
                    if (c.Y >= 388)
                        collisionArea.Remove(c);
                }
                else
                {
                    if (c.Y > 240 && c.Y < 388)
                        collisionArea.Add(c);
                }
            }
           foreach (Car c in carsWest)
            {
                if (collisionArea.IndexOf(c) != -1)
                {
                    if (c.X > 715)
                        collisionArea.Remove(c);
                }
                else
                {
                    if (c.X > 510 && c.X < 715)
                        collisionArea.Add(c);
                }
            }
            foreach (Car c in carsSouth)
                if (collisionArea.IndexOf(c) != -1)
                {
                    if (c.Y + c.getHeight() <= 240)
                        collisionArea.Remove(c);
                }
                else
                {
                    if (c.Y < 388 && c.Y > 240 )
                        collisionArea.Add(c);
                }
                
        }
        public Point checkCollision()
        {
            foreach(Car c in collisionArea)
            {
                foreach(Car car in collisionArea)
                {
                    if (c.dir == Car.Direction.EAST)
                    {
                        switch (car.dir)
                        {
                            case Car.Direction.NORTH:
                                if ((c.X <= car.X + car.getWidth() && c.X > car.X && c.Y <= car.Y + car.getHeight() && c.Y > car.Y) || (c.X <= car.X + car.getWidth() && c.X > car.X && c.Y + c.getHeight() < car.Y + car.getHeight() && c.Y + c.getHeight() > car.Y))
                                    return new Point(c.X - 20,c.Y);
                                break;
                            case Car.Direction.SOUTH:
                                if ((c.X <= car.X + car.getWidth() && c.X > car.X && c.Y <= car.Y + car.getHeight() && c.Y > car.Y) || (c.X <= car.X + car.getWidth() && c.X > car.X && c.Y + c.getHeight() < car.Y + car.getHeight() && c.Y + c.getHeight() > car.Y))
                                    return new Point(c.X - 20, c.Y); ;
                                break;
                        }
                    }
                    else if(c.dir == Car.Direction.NORTH)
                    {
                        switch (car.dir)
                        {
                            case Car.Direction.EAST:
                                if ((c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()) || (c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X, c.Y + 30); ;
                                break;
                            case Car.Direction.WEST:
                                if ((c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()) || (c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X, c.Y + 30); ;
                                break;
                        }
                    }
                    else if(c.dir == Car.Direction.WEST)
                    {
                        switch (car.dir)
                        {
                            case Car.Direction.NORTH:
                                if ((c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y >= car.Y && c.Y <= car.Y + car.getHeight()) || (c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y + c.getHeight() > car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X + 20, c.Y); ;
                                break;
                            case Car.Direction.SOUTH:
                                if ((c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y >= car.Y && c.Y <= car.Y + car.getHeight()) || (c.X + c.getWidth() >= car.X && c.X + c.getWidth() <= car.X + car.getWidth() && c.Y + c.getHeight() > car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X + 20, c.Y); ;
                                break;
                        }
                    }
                    else if(c.dir == Car.Direction.SOUTH)
                    {
                        switch (car.dir)
                        {
                            case Car.Direction.WEST:
                                if ((c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y >= car.Y && c.Y <= car.Y + car.getHeight()) || (c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X, c.Y - 20); ;
                                break;
                            case Car.Direction.EAST:
                                if ((c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y >= car.Y && c.Y <= car.Y + car.getHeight()) || (c.X >= car.X && c.X <= car.X + car.getWidth() && c.Y + c.getHeight() >= car.Y && c.Y + c.getHeight() < car.Y + car.getHeight()))
                                    return new Point(c.X, c.Y -20); ;
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
            foreach(Car c in carsNorth)
            {
                if (c.isWaiting)
                    i ++;
            }
            if (i == 5)
                return true;
            else
                i = 0;
            foreach (Car c in carsWest)
            {
                if (c.isWaiting)
                    i++;
            }
            if (i == 6)
                return true;
            else
                i = 0;
            foreach (Car c in carsSouth)
            {
                if (c.isWaiting)
                    i++;
            }
            if (i == 5)
                return true;
            else
                i = 0;
            foreach (Car c in carsEast)
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
            g.DrawImage(Resources.BAM, loc.X, loc.Y);
        }
    }
}
