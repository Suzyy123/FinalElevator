﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftDemo_A
{
    internal class MovingDownState : ILiftState//implements the interface called ILiftState
    {
        public void MovingDown(Lift lift)
        {
            //checks if lift is at top or still above the bottom boundary
            if (lift.MainElevator.Top == lift.LeftTopDoor.Location.Y || lift.MainElevator.Bottom < lift.FormSize)
            {
                //increment lift position downward
                lift.MainElevator.Top += lift.LiftSpeed + 10;
            }
            else
            {
                // Once it reaches the bottom, transition to StoppedState
                lift.SetState(new IdleState());
                lift.MainElevator.Top = lift.FormSize - lift.MainElevator.Height;//set lift postion at bottom
                lift.Btn_1.BackColor = Color.White;
                lift.Lifttimerdown.Stop();  // Stop the timer when it reaches the bottom
                lift.Btn_1.Enabled = true;  // Re-enable the 1st floor button
                lift.Btn_G.Enabled = true;  // Enable other controls
                                            // Update level
                lift.UpdateLevel(0); // Set level to 0
            }
        }

        public void MovingUp(Lift lift)
        {
            /* Do Nothing */
        }
    }
}
