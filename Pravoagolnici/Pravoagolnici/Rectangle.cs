using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pravoagolnici
{
    public class Rectangle
    {
        public Point Location { get; set; }
        public int width;
        public int height;
        public bool isMoving;
        public bool isRotating;
        Color color;
        int turn;

        public Rectangle(Point l, Color c)
        {
            Location = l;
            color = c;
            width = 100;
            height = 50;
            isMoving = false;
            isRotating = false;
            turn = 1;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(color);
            g.FillRectangle(b, Location.X - width / 2, Location.Y - height / 2, width, height);
            b.Dispose();
        }

        public void Move()
        {
            Location = new Point(Location.X, Location.Y + height);
        }

        public void Rotate()
        {
            int temp = width;
            width = height;
            height = width;
            if(turn == 1)
            {
                Location = new Point(Location.X + height / 2, Location.Y + width / 2);
                turn = 2;
            }
            else
            {
                Location = new Point(Location.X + width / 2, Location.Y - height / 2);
                turn = 1;
            }
        }
        
        public bool isSelected(Point position)
        {
            if (position.X >= Location.X - width / 2 && position.X <= Location.X + width / 2 && position.Y >= Location.Y - height / 2 && position.Y <= Location.Y + height / 2)
                return true;
            return false;
        }

    }
}
