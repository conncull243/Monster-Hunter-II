using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace keyPressAnimations
{
    public partial class GameScreen : UserControl
    {

        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown, spaceBarDown;

        int direction = 0;

        Pen drawPen = new Pen(Color.Black);


        List<Monster> monsterList = new List<Monster>();


        List<Bullet> bulletList = new List<Bullet>();


        Player character;
        Monster enemy;
            
        public GameScreen()
        {
            InitializeComponent();

            Image[] hero = new Image[4];
            Image[] monster = new Image[1];

            hero[0] = Properties.Resources.RedGuyDown;
            hero[1] = Properties.Resources.RedGuyRight;
            hero[2] = Properties.Resources.RedGuyUp;
            hero[3] = Properties.Resources.RedGuyLeft;
            monster[0] = Properties.Resources.happymonster;

            gameTimer.Enabled = true;
            gameTimer.Start();

            character = new Player(40, 50, 20, 4, hero);
            Monster enemy = new Monster(100, 200, 50, 1, monster);
            monsterList.Add(enemy);

            this.Focus();

        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //check to see if a key is pressed and set is KeyDown value to true if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Space:
                    spaceBarDown = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ////check to see if a key is pressed and set is KeyDown value to true if it has
            //switch (e.KeyCode)
            //{
            //    case Keys.Left:
            //        leftArrowDown = true;
            //        break;
            //    case Keys.Down:
            //        downArrowDown = true;
            //        break;
            //    case Keys.Right:
            //        rightArrowDown = true;
            //        break;
            //    case Keys.Up:
            //        upArrowDown = true;
            //        break;
            //    case Keys.Space:
            //        spaceBarDown = true;
            //        break;
            //    default:
            //        break;
            //}

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //check to see if a key has been released and set its KeyDown value to false if it has
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Space:
                    spaceBarDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //checks to see if any keys have been pressed and adjusts the X or Y value
            //for the character appropriately
            if (leftArrowDown == true)
            {
                character.move(character, "left");
                direction = 3;
            }
            else if (downArrowDown == true)
            {
                character.move(character, "down");
                direction = 0;
            }
            else if (rightArrowDown == true)
            {
                character.move(character, "right");
                direction = 1;
            }
            else if (upArrowDown == true)
            {
                character.move(character, "up");
                direction = 2;
            }
            if (spaceBarDown == true && direction == 0)
            {
                Bullet b = new Bullet(character.x + (1/2 * character.size), character.y + (1/2 * character.size), 10, 15, "down");
                bulletList.Add(b);
            }
            if (spaceBarDown == true && direction == 1)
            {
                Bullet b = new Bullet(character.x + (1 / 2 * character.size), character.y + (1 / 2 * character.size), 10, 15, "right");
                bulletList.Add(b);
            }
            if (spaceBarDown == true && direction == 2)
            {
                Bullet b = new Bullet(character.x + (1 / 2 * character.size), character.y + (1 / 2 * character.size), 10, 15, "up");
                bulletList.Add(b);
            }
            if (spaceBarDown == true && direction == 3)
            {
                Bullet b = new Bullet(character.x + (1 / 2 * character.size), character.y + (1 / 2 * character.size), 10, 15, "left");
                bulletList.Add(b);
            }

            //monster movement
            foreach (Monster m in monsterList)
            {
                if (character.x > m.x)
                {
                    m.move(m, "right");
                }
                else if (character.x < m.x)
                {
                    m.move(m, "left");
                }
                if (character.y > m.y)
                {
                    m.move(m, "down");
                }
                else if (character.y < m.y)
                {
                    m.move(m, "up");
                }
            }

            //bullet movement
            foreach (Bullet b in bulletList)
            {
                if (b.direction == "up")
                {
                    b.move(b);
                }
                if (b.direction == "down")
                {
                    b.move(b);
                }
                if (b.direction == "left")
                {
                    b.move(b);
                }
                if (b.direction == "right")
                {
                    b.move(b);
                }
            }
            //check for collision, end program if it happens between player + monster
            foreach (Monster m in monsterList)
            {
                if (character.collision(character, m))
                {
                    gameTimer.Stop();
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    EndScreen es = new EndScreen();
                    f.Controls.Add(es);
                    es.BringToFront();
                    break;
                }
            }

            //bullet and monster collision... work in progress
            //foreach (Bullet b in bulletList)
            //{
            //    if (enemy.collision(m:enemy, b:b))
            //    {
            //        monsterList.Remove(enemy);
            //        monsterList.Add(enemy);
            //    }
            //}


            //refresh the screen, which causes the Form1_Paint method to run
            Refresh();

        }

        //paints all objects to screen
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw character to screen
            e.Graphics.DrawImage(character.hero[direction], character.x, character.y);
            
            foreach (Monster m in monsterList)
            {
                e.Graphics.DrawImage(m.monster[0], m.x, m.y, m.size, m.size);
            }

            foreach (Bullet b in bulletList)
            {
                e.Graphics.DrawRectangle(drawPen, b.x, b.y, 5, 5);
            }
        }
    }
}
