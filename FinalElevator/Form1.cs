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
using System.Data;
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
        private int maxLiftHeight = 100;
        DataTable dt = new DataTable();
        Database db = new Database();



        public Form1()
        {
            InitializeComponent();
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
            lift.SetState(new MovingUpState());
            lift.Lifttimerup.Start();
            btn_G.Enabled = false;

            logEvents("Lift going up!!!");
            btnColorUp.BackColor = Color.Black;
            btnColorDown.BackColor = Color.Green;
            liftDisplayDoing.Text = "Coming in 1st floor";

        }
        public void btn_G_click(object sender, EventArgs e)
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
            lift.MovingUp();

        }

        public void liftTimerDown_Tick(object sender, EventArgs e)
        {
            //if (mainElevator.Top < this.ClientSize.Height - mainElevator.Height)
            //{
            //    lift.MovingDown();
            //    liftDisplayDoing.Text = "↓";  
            //}
            //else
            //{
            //    lift.Lifttimerdown.Stop();
            //    liftDisplayDoing.Text = "G"; 
            //    logEvents("Lift reached ground floor!");
            //    btn_1.Enabled = true; 
            //}

            lift.MovingDown();



        }


        private void OpenAndCloseDoorAutomatically()
        {
            isOpening = true;
            isClosing = false;
            doortimer.Start();           
            logEvents("Lift door opening automatically");
            Task.Delay(3000).ContinueWith(_ =>
            {
                isOpening = false;
                isClosing = true;
                doortimer.Start(); // Start the door closing process

                logEvents("Lift door closing automatically");
            });
        }


        private void btn_Open_Click(object sender, EventArgs e)
        {
            isOpening = true;
            isClosing = false;
            doortimer.Start();
            btnclose.Enabled = false;

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
            //logEvents("All logs cleared.");
        }


        private void EmergencyAlarm_Click(object sender, EventArgs e)
        {
            if (!_emergencyAlarm.IsActive)
            {
                _emergencyAlarm.Activate();
            }
            else
            {
                _emergencyAlarm.Deactivate();
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

        private void door_Timer_Tick(object sender, EventArgs e)

        {
            if (mainElevator.Top != 0)
            {
                if (isOpening)
                {
                    if (doorleft.Left > doorMaxOpenWidth / 2 - 250)
                    {
                        doorleft.Left -= doorSpeed;
                        doorright.Left += doorSpeed;
                    }
                    else
                    {
                        doortimer.Stop();
                        btnclose.Enabled = true;
                    }
                }

                if (isClosing)
                {
                    if (doorleft.Right < mainElevator.Width + doorMaxOpenWidth / 2 - 250)
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

            else
            {

                if (isOpening)
                {
                    if (doorleft1.Left > doorMaxOpenWidth / 2 - 250)
                    {
                        doorleft1.Left -= doorSpeed;
                        doorright1.Left += doorSpeed;
                    }
                    else
                    {
                        doortimer.Stop();
                        btnclose.Enabled = true;
                    }
                }

                if (isClosing)
                {
                    if (doorleft1.Right < mainElevator.Width + doorMaxOpenWidth / 2 - 250)
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

        private void btnUp_Click(object sender, EventArgs e)
        {
            lift.MovingUp();
        }
    }
}