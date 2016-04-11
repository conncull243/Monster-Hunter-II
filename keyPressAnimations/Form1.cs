﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* Created by Mr. T
 * to demonstrate how to use key presses to control the animation
 * of an object on screen
 */

namespace keyPressAnimations
{
    public partial class Form1 : Form
    {
        //initial starting points for black rectangle
        //int drawX = 100;
        //int drawY = 200;

        //determines whether a key is being pressed or not
        //Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        //create graphic objects
        //SolidBrush drawBrush = new SolidBrush(Color.Black);

        //create image array


        //int direction = 0;
            
        public Form1()
        {
            InitializeComponent();

       //     GameScreen gs = new GameScreen();
         //   this.Controls.Add(gs);

            //create elements of image array
            //hero[0] = Properties.Resources.RedGuyDown;
            //hero[1] = Properties.Resources.RedGuyRight;
            //hero[2] = Properties.Resources.RedGuyUp;
            //hero[3] = Properties.Resources.RedGuyLeft;

            //start the timer when the program starts
            //gameTimer.Enabled = true;
            //gameTimer.Start();
        }

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //check to see if a key is pressed and set is KeyDown value to true if it has
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Left:
        //            leftArrowDown = true;
        //            break;
        //        case Keys.Down:
        //            downArrowDown = true;
        //            break;
        //        case Keys.Right:
        //            rightArrowDown = true;
        //            break;
        //        case Keys.Up:
        //            upArrowDown = true;
        //            break;
        //        default:
        //            break;
        //    }

        //}

        private void newButton_Click(object sender, EventArgs e)
        {
            //Form f = this.FindForm();
            //f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            this.Controls.Add(gs);
            gs.BringToFront();

            newButton.Enabled = false;
            quitButton.Enabled = false;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //private void Form1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //check to see if a key has been released and set its KeyDown value to false if it has
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Left:
        //            leftArrowDown = false;
        //            break;
        //        case Keys.Down:
        //            downArrowDown = false;
        //            break;
        //        case Keys.Right:
        //            rightArrowDown = false;
        //            break;
        //        case Keys.Up:
        //            upArrowDown = false;
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //private void gameTimer_Tick(object sender, EventArgs e)
        //{
            //checks to see if any keys have been pressed and adjusts the X or Y value
            //for the rectangle appropriately
            //if (leftArrowDown == true)
            //{
            //    direction = 3;
            //    drawX--;
            //}
            //if (downArrowDown == true)
            //{
            //    direction = 0;
            //    drawY++;
            //}
            //if (rightArrowDown == true)
            //{
            //    direction = 1;
            //    drawX++;
            //}
            //if (upArrowDown == true)
            //{
            //    direction = 2;
            //    drawY--;
            //}

            //refresh the screen, which causes the Form1_Paint method to run
            //Refresh();

        //}


        //private void Form1_Paint(object sender, PaintEventArgs e)
        //{
            //draw character to screen
            //  e.Graphics.DrawImage(drawX, drawY);
        //}

    }

}
