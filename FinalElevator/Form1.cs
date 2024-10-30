using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using LiftDemo_A;
using Elevator1;

namespace FinalElevator
{
    public partial class Form1 : Form
    {
        private readonly EmergencyAlarm _emergencyAlarm;
        bool isClosing = false;
        bool isOpening = false;
        int doorMaxOpenWidth;
        int doorSpeed = 10;
        int liftSpeed = 10;
        string alarmSoundPath = @"C:\Users\suzu\Downloads\mixkit-classic-alarm-995.wav";
        private Lift lift;
        private int maxLiftHeight = 148;
        DataTable dt = new DataTable();
        Database db = new Database();
        public Form1()
        {
            InitializeComponent();
            mainElevator.Top = (this.ClientSize.Height - mainElevator.Height);
            lift = new Lift(mainElevator, btn_1, btn_G, this.ClientSize.Height, liftSpeed, lifttimerup, lifttimerdown);
            doorMaxOpenWidth = mainElevator.Width + 1465;

            datagridviewlogs.ColumnCount = 2;
            datagridviewlogs.Columns[0].Name = "Time";
            datagridviewlogs.Columns[1].Name = "Events";
            _emergencyAlarm = new EmergencyAlarm(alarmSoundPath);

            dt.Columns.Add("LogTime");
            dt.Columns.Add("EventDescription");
            db.loadLogsFromDB(dt, datagridviewlogs);

        }
  

        private void logEvents(string message)
        {

            string currentTime = DateTime.Now.ToString("hh:mm:ss");
            dt.Rows.Add(currentTime, message);
            db.InsertLogsIntoDB(dt); // Save log to DB
            db.loadLogsFromDB(dt, datagridviewlogs);

        }
        private void Form1_Load(object sender, EventArgs e)

        {
            db.loadLogsFromDB(dt, datagridviewlogs);
        }
        public void btn_1_click(object sender, EventArgs e)
        {
            //lift.SetState(new MovingUpState());
            //lift.Lifttimerup.Start();
            //btn_G.Enabled = false;

            //logEvents("Lift going up!!!");
            //btnColorUp.BackColor = Color.Black;
            //btnColorDown.BackColor = Color.Green;
            //liftDisplayDoing.Text = "Coming in 1st floor";
            if (isOpening)
            {
                isOpening = false;
                isClosing = true;
                doortimer.Start();
                btnclose.Enabled = false;
                doortimer.Tick += onDoorClose;
                logEvents("Lift going up!!!");

            }
            else
            {
                MoveLiftUp();
            }

        }
        private void onDoorClose(object sender, EventArgs e)
        {
            if (!isOpening && !isClosing)
            {
                MoveLiftUp();
                doortimer.Tick -= onDoorClose;
            }
            //else
            //{
            //    MoveLiftUp();
            //}

        }
        private void MoveLiftUp()
        {
            lift.SetState(new MovingUpState());
            lift.Lifttimerup.Start();
            btn_G.Enabled = false;

            //logEvents("Lift going up!!!");
            btnColorUp.BackColor = Color.Black;
            btnColorDown.BackColor = Color.Green;
            liftDisplayDoing.Text = "Coming in 1st floor";

        }

        public void btn_G_click(object sender, EventArgs e)
        {
            //lift.SetState(new MovingDownState());
            //lift.Lifttimerdown.Start();

            //btnColorUp.BackColor = Color.Green;
            //btnColorDown.BackColor = Color.Black;
            //logEvents("Lift going down");
            //liftDisplayDoing.Text = "Coming in Ground floor";
            if (isOpening)
            {
                isOpening = false;
                isClosing = true;
                doortimer.Start();
                btnclose.Enabled = false;
                doortimer.Tick += onDoorClose;

            }
            else
            {
                MoveLiftDown();
            }

        }
        //private void onDoorOpen(object sender, EventArgs e)
        //{
        //    if (!isOpening && !isClosing)
        //    {
        //        MoveLiftUp();
        //        doortimer.Tick += onDoorClose;
        //    }

        //}
        private void MoveLiftDown()
        {
            lift.SetState(new MovingDownState());
            lift.Lifttimerdown.Start();

            btnColorUp.BackColor = Color.Green;
            btnColorDown.BackColor = Color.Black;
            logEvents("Lift going down");
            liftDisplayDoing.Text = "Coming in Ground floor";
        }
        public void btn_up_click(object sender, EventArgs e)
        {

        }
        public void btn_down_click(object sender, EventArgs e)
        {

        }
        public void liftTimerUp_Tick(object sender, EventArgs e)
        {
            //mainElevator.Top -= liftSpeed;
            //lift.Lifttimerup.Enabled = mainElevator.Top > maxLiftHeight;

            lift.MovingUp();
            StopLiftAtTop();//new



        }

        public void liftTimerDown_Tick(object sender, EventArgs e)
        {
            lift.MovingDown();



        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            isOpening = true;
            isClosing = false;
            doortimer.Start();
            btnopen.Enabled = false;

            logEvents("Lift Opening");
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            isOpening = false;
            isClosing = true;
            doortimer.Start();
            logEvents("Lift is Closing!!!");
        }
        private void btn_ClearLog_Click(object sender, EventArgs e)
        {
            dt.Clear();
            datagridviewlogs.Rows.Clear();
            db.ClearLogsFromDB();
        }


        private void EmergencyAlarm_Click(object sender, EventArgs e)
        {
            if (!_emergencyAlarm.IsActive)
            {
                _emergencyAlarm.Activate();
                logEvents("Alarm was activated");
            }
            else
            {
                _emergencyAlarm.Deactivate();
                logEvents("Alarm was inactivated");
            }

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //private void StopLiftAtTop()
        //{

        //}

        private void door_Timer_Tick(object sender, EventArgs e)

        {
            if (mainElevator.Top == (this.ClientSize.Height - mainElevator.Height))
            {
                if (isOpening)
                {
                    if (doorleft.Left > doorMaxOpenWidth / 2 - 800)
                    {
                        doorleft.Left -= doorSpeed;
                        doorright.Left += doorSpeed;
                    }
                    else
                    {
                        doortimer.Stop();
                        btnopen.Enabled = true;
                    }
                }

                if (isClosing)
                {
                    if (doorleft.Right < mainElevator.Width + doorMaxOpenWidth / 2 - 815)
                    {
                        doorleft.Left += doorSpeed;
                        doorright.Left -= doorSpeed;
                    }
                    else
                    {
                        doortimer.Stop();

                    }
                }
            }

            else if (mainElevator.Top == 0)
            {

                if (isOpening)
                {
                    if (doorleft1.Left > doorMaxOpenWidth / 2 - 800 )
                    {
                        doorleft1.Left -= doorSpeed;
                        doorright1.Left += doorSpeed;
                    }
                    else
                    {
                        doortimer.Stop();
                        btnopen.Enabled = true;
                    }
                }

                if (isClosing)
                {
                    if (doorleft1.Right < mainElevator.Width + doorMaxOpenWidth / 2 - 815)
                    {
                        doorleft1.Left += doorSpeed;
                        doorright1.Left -= doorSpeed;
                    }
                    else
                    {
                        doortimer.Stop();

                    }
                }
            }
        }
        private void StopLiftAtTop()//new
        {
            isOpening = true;
            isClosing = false;
            doortimer.Start();
            btnopen.Enabled = false;
            lift.MovingUp();
            if (isClosing)
            {
                isOpening = true;
                isClosing = false;
                doortimer.Start();


            }


        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            lift.MovingUp();
        }

       
    }
}