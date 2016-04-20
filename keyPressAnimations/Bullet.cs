using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace keyPressAnimations
{
    class Bullet
    {
        public int x, y, size, speed;
        public string direction;

        public Bullet (int _x, int _y, int _size, int _speed, string _direction)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            direction = _direction;
        }

        //bullet movement created
        public void move (Bullet b)
        {
            if (b.direction == "up")
            {
                b.y -= b.speed;
            }

            else if (direction == "down")
            {
                b.y += b.speed;
            }
            else if (direction == "left")
            {
                b.x -= b.speed;
            }
            else if (direction == "right")
            {
                b.x += b.speed; 
            }
        }
    }
}
