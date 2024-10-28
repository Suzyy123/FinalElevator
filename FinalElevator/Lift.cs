using Elevator1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace LiftDemo_A
{
    internal class Lift
    {
        public ILiftState _CurrentState;
        private readonly EmergencyAlarm emergencyAlarm;

        public PictureBox MainElevator;
        public Button Btn_1;
        public Button Btn_G;
        public int FormSize;
        public int LiftSpeed;
        public Timer Lifttimerup;
        public Timer Lifttimerdown;

        public Lift(PictureBox mainElevator, Button btn_1, Button btn_G, int formSize, int liftSpeed, Timer lifttimerup, Timer lifttimerdown)
        {
            MainElevator = mainElevator;
            Btn_1 = btn_1;
            Btn_G = btn_G;
            FormSize = formSize;
            LiftSpeed = liftSpeed;
            Lifttimerup = lifttimerup;
            Lifttimerdown = lifttimerdown;
            _CurrentState = new IdleState();
        }
        //public bool HasReachedTargetFloor()
        //{
        //    return CurrentState == TargetFloor;
        //}

        public void SetState(ILiftState state)
        {
            _CurrentState = state;
        }

        public void MovingUp()
        {
            _CurrentState.MovingUp(this);
        }

        public void MovingDown()
        {
            _CurrentState.MovingDown(this);
        }


    }
}
