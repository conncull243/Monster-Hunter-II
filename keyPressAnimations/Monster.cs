using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace keyPressAnimations
{
    class Monster
    {
        public int x, y, size, speed;
        public Image[] monster = new Image[4];

        /// <summary>
        /// Monster constructor method
        /// </summary>
        /// <param name="_x">start x location of monster</param>
        /// <param name="_y">start y location of montster</param>
        /// <param name="_size">start size of monster</param>
        /// <param name="_speed">start speed of monster</param>
        /// <param name="_monster">images to be used for drawing monster</param>
        public Monster (int _x, int _y, int _size, int _speed, Image[] _monster)
        {   
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            monster = _monster;
        }

        //monster movement created
        public void move (Monster m, string direction)
        {
            if (direction == "up")
            {
                m.y -= m.speed;
            }
            
            else if (direction == "down")
            {
                m.y += m.speed;
            }

            else if (direction == "left")
            {
                m.x -= m.speed;
            }
            
            else if (direction == "right")
            {
                m.x += m.speed;
            }
        }

        //checks for collision between monster and bullets
        public bool collision (Monster m, Bullet b)
        {
            Rectangle mRec = new Rectangle(m.x, m.y, m.size, m.size);
            Rectangle bRec = new Rectangle(b.x, b.y, b.size, b.size);

            if (mRec.IntersectsWith(bRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            
    }
}
