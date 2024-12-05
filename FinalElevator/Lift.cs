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
        public PictureBox LeftTopDoor;
        public int CurrentLevel { get; private set; } = 0;//current floor initialize to 0

        public Lift(PictureBox mainElevator, Button btn_1, Button btn_G, int formSize, int liftSpeed, Timer lifttimerup, Timer lifttimerdown, PictureBox leftTopDoor)//polymorphism
        {
            MainElevator = mainElevator;
            Btn_1 = btn_1;
            Btn_G = btn_G;
            FormSize = formSize;
            LiftSpeed = liftSpeed;
            Lifttimerup = lifttimerup;
            Lifttimerdown = lifttimerdown;
            LeftTopDoor = leftTopDoor;
            _CurrentState = new IdleState();
        }
       
        //sets current state to the specified state
        public void SetState(ILiftState state)
        {
            _CurrentState = state;
        }
        //method to handle upward movement
        public void MovingUp()
        {
            MainElevator.Top -= LiftSpeed;
            _CurrentState.MovingUp(this);
        }

        public void MovingDown()
        {
            MainElevator.Top += LiftSpeed;//passing lift instance
            _CurrentState.MovingDown(this);
        }
        public void UpdateLevel(int newLevel)//new to change current level
        {
            CurrentLevel = newLevel;
        }


    }
}
