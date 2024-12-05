using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftDemo_A
{
    internal class IdleState : ILiftState//represents the state when lift is not idle not moving
    {
        public void MovingDown(Lift lift)//rest mode
        {
           //does nothing
        }

        public void MovingUp(Lift lift)
        {
            //does nothing
        }
    }
}
