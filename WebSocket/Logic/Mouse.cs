﻿using System;
using System.Windows.Forms;
using System.Threading;
using Logic;

namespace MouseControl
{
    public class Mouse
    {
        public void MoveCursor(MouseParameter parameters)
        {
            Form1 cursor = new Form1();

            double xPos = Cursor.Position.X + parameters.xDiff;
            double yPos = Cursor.Position.Y + parameters.YDiff; 

            cursor.Move(xPos, yPos, parameters.XVelocity, parameters.YVelocity);
            Thread.Sleep(100);
        }
    }
}
