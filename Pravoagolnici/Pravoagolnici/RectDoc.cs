using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pravoagolnici
{
    public class RectDoc
    {
        public List<Rectangle> pravoagolnici;
        public Color currentColor { get; set; }

        public RectDoc()
        {
            pravoagolnici = new List<Rectangle>();
            currentColor = Color.Red;
        }

        public void AddRectangle(Point position)
        {
            pravoagolnici.Add(new Rectangle(position, currentColor));
        }

        public void Draw(Graphics g)
        {
            foreach (Rectangle p in pravoagolnici)
                p.Draw(g);
        }

        public void Move()
        {
            foreach(Rectangle p in pravoagolnici)
            {
                if (p.isMoving)
                    p.Move();
            }
        }

        public void Rotate()
        {
            foreach (Rectangle p in pravoagolnici)
            {
                if (p.isRotating)
                    p.Rotate();
            }
        }

        public void Select(Point loc, int type)
        {
            if (type == 1)
            {
                foreach (Rectangle p in pravoagolnici)
                {
                    if (p.isSelected(loc))
                    {
                        if (!p.isRotating)
                        {
                            p.isMoving = true;
                            break;
                        }
                    }
                }  
            }
            else
            {
                foreach (Rectangle p in pravoagolnici)
                {
                    if (p.isSelected(loc))
                    {
                        if (!p.isMoving)
                        {
                            p.isRotating = true;
                            break;
                        }
                    }
                }
            }
            
        }

        public void CheckOutOfBounds(int width, int height)
        {
            Rectangle temp = null;
            foreach(Rectangle p in pravoagolnici)
            {
                if (p.isMoving)
                {
                    if (p.Location.Y - p.height >= height)
                        temp = p;
                }
                else if (p.isRotating)
                {
                    if (p.Location.X - p.width >= width)
                        temp = p;
                }
            }
            pravoagolnici.Remove(temp);
        }
    }
}
