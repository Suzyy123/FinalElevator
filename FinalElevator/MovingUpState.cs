using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftDemo_A
{
    internal class MovingUpState : ILiftState
    {
       

        public void MovingUp(Lift lift)
        {

            if (lift.MainElevator.Top > lift.LeftTopDoor.Location.Y)//current position is at the top or not
            {
                lift.MainElevator.Top -= lift.LiftSpeed;//move lift upward
            }
            else
            {
                // Once it reaches the top, transition to StoppedState
                lift.SetState(new IdleState());//trasition to idle state
                lift.MainElevator.Top = lift.LeftTopDoor.Location.Y;
                lift.Btn_G.BackColor = Color.White;
                lift.Lifttimerup.Stop();  // Stop the timer when it reaches the top
                lift.Btn_G.Enabled = true;  // Re-enable the G button
                lift.Btn_1.Enabled = true;  // Enable other controls
                                            // Update level
                lift.UpdateLevel(1); // Set level to 0
            }
        }
        public void MovingDown(Lift lift)
        {
            /* Do Nothing */
        }
    }
}
