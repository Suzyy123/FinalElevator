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
        private readonly EmergencyAlarm _emergencyAlarm;// readonly instance for handling emergency alarms
        bool isClosing = false;// state for whether the door is closing 
        bool isOpening = false;//oepning is false
        bool isMovingUp = false;//moving up is false
        bool isMovingDown = false;//moving down is false
        int doorMaxOpenWidth;//door's maximum width
        int doorSpeed = 10;// speed oft the door is 10
        int liftSpeed = 10;//speed of the lift is 10

        string alarmSoundPath = @"C:\Users\suzu\Downloads\mixkit-classic-alarm-995.wav";//alarm sound path
        private Lift lift;//lift object

        private bool moveDownAfterClose = false; // Flag to move the lift down after door closes
        DataTable dt = new DataTable();//object creation of datatable
        Database db = new Database();//object creation of database
        public Form1()//form 1 load
        {
            InitializeComponent();//component initialize
            pic1.BackColor = Color.Black;//black color picture
            pic2.Enabled = false;//enabling false
            pic3.Enabled = false;// enabling false
            pic2.Visible = false;// enabling false
            pic3.Visible = false;// enabling false
            mainElevator.Top = (this.ClientSize.Height - mainElevator.Height);//elevator's top
            lift = new Lift(mainElevator, btn_1, btn_G, this.ClientSize.Height, liftSpeed, lifttimerup, lifttimerdown, doorleft1);
            doorMaxOpenWidth = mainElevator.Width + 1465;

            datagridviewlogs.ColumnCount = 2;// configures it has two columns
            datagridviewlogs.Columns[0].Name = "Time";//setting name of the column1
            datagridviewlogs.Columns[1].Name = "Events";//setting name for 2
            _emergencyAlarm = new EmergencyAlarm(alarmSoundPath);//instantiates an 'EmergencyAlarm' object

            dt.Columns.Add("LogTime");//Adds a logtime column to the datatable
            dt.Columns.Add("EventDescription");
            db.loadLogsFromDB(dt, datagridviewlogs);

        }

        private void logEvents(string message)
        {

            string currentTime = DateTime.Now.ToString("hh:mm:ss");//gets the current timee as astrig
            dt.Rows.Add(currentTime, message);//add a new row to data table
            db.InsertLogsIntoDB(dt); // Save log to DB
            db.loadLogsFromDB(dt, datagridviewlogs);//reload logs into datagridview

        }
        private void Form1_Load(object sender, EventArgs e)

        {
            db.loadLogsFromDB(dt, datagridviewlogs); //databases records in the logs at first
        }
        public void btn_1_click(object sender, EventArgs e)
        {

            if (!isClosing)//if door is not closed
            {
                isClosing = true;//starts closing
                isOpening = false;//donot open
                doortimer.Start();//starts door timer

            }
            else
            {
                MoveElevatorUp();//move lift up code
                DoorClosetimer.Start();//automatic door closing start after 5 seconds
            }


        }

        public void btn_G_click(object sender, EventArgs e)//going to gorund button 
        {

            isClosing = true;//closing start
            isOpening = false;//opening false
            doortimer.Start();//starts door timer
            MoveElevatorDown();//move the elevator down
            DoorClosetimer.Start();//Starts automatic closing of door

        }
        public void MoveElevatorUp()// Moving elevator up
        {
            lift.SetState(new MovingUpState()); // Sets the lift's state to "MovingUp"
            lift.Lifttimerup.Start(); // Starts the timer for moving the lift up
            btn_G.Enabled = false; // Disables the ground button
            logEvents("Lift going up!!!"); // Logs the event
            btnColorUp.BackColor = Color.Black; // Changes button color
            btnColorDown.BackColor = Color.Green; // Changes button color
            isClosing = true; // Sets the closing state
            isOpening = false; // Clears the opening state
            doortimer.Start(); // Starts the door timer
            pic2.Visible = true; // Shows `pic2`
            pic2.Enabled = true; // Enables `pic2`
            pic3.Visible = false; // Hides `pic3`

            }
        public void MoveElevatorDown()// going down code
        {
            lift.SetState(new MovingDownState()); // Sets the lift's state to "MovingDown"
            lift.Lifttimerdown.Start(); // Starts the timer for moving the lift down
            btnColorUp.BackColor = Color.Green; // Changes button color
            btnColorDown.BackColor = Color.Black; // Changes button color
            logEvents("Lift going down"); // Logs the event
            pic3.Visible = true; // Shows `pic3`
            pic3.Enabled = true; // Enables `pic3`
            pic2.Visible = false; // Hides `pic2`
            pic2.Enabled = false; // Disables `pic2`



        }
        public void liftTimerUp_Tick(object sender, EventArgs e)//lift timer up timer
        {
            lift.MovingUp();
            if (mainElevator.Top == doorleft1.Location.Y)//if lift is at top
            {
                isOpening = true; // Set opening state
                isClosing = false; //  closing state is false

                
                doortimer.Start(); // Start the door opening timer
                btnclose.Enabled = false; // Disable the close button


            }


        }
        public void liftTimerDown_Tick(object sender, EventArgs e)
        {
            lift.MovingDown();
            if (mainElevator.Top != doorleft1.Location.Y)//if lift is not at top
            {
                isOpening = true; // Start opening
                isClosing = false; // Ensure closing state is false

                doortimer.Start(); // Start the door opening timer
                btnclose.Enabled = false; // Disable the close button

            }

        }

        private void btn_Open_Click(object sender, EventArgs e)//opening door logic
        {
            isOpening = true;
            isClosing = false;
            doortimer.Start();
            btnclose.Enabled = false;
            //btnopen.Enabled = true;

            logEvents("Lift Opening");//log events
        }

        private void btn_Close_Click(object sender, EventArgs e)//closing door logic
        {
            isOpening = false;
            isClosing = true;
            doortimer.Start();
            logEvents("Lift is Closing!!!");
        }
        private void btn_ClearLog_Click(object sender, EventArgs e)//clearing logs
        {
            dt.Clear();
            datagridviewlogs.Rows.Clear();
            db.ClearLogsFromDB();
        }


        private void EmergencyAlarm_Click(object sender, EventArgs e)//emergency alarm
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

        private void btn_Exit_Click(object sender, EventArgs e)//exit button
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);//question mark icon
            if (result == DialogResult.Yes)//using dialogresult
            {
                Application.Exit();//exit the application
            }
        }

        private void door_Timer_Tick(object sender, EventArgs e)

        {
            if (mainElevator.Top == lift.FormSize - lift.MainElevator.Height)//checks if lift is at bottom
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
                        btnclose.Enabled = true;
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

            else if (mainElevator.Top == doorleft1.Location.Y)//checks if lift is at the top
            {

                if (isOpening)
                {
                    if (doorleft1.Left > doorMaxOpenWidth / 2 - 800)
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
        private void btnUp_Click(object sender, EventArgs e)//to request elevator in first floor
        {
            if (mainElevator.Top == doorleft1.Location.Y)// if elevator is at top
            {
                isClosing = false;//closing false
                isOpening = true;// door will starts opening automatically
                doortimer.Start();//by starting door timer

                DoorClosetimer.Start();//automatic door closing after 10 seconds if nothing is done

            }
            else//if elevator is not at requested floor
            {

                MoveElevatorUp();//elevator will go up
                DoorClosetimer.Stop();//automatic door closing after 10 seconds

            }
        }

        private void btndown_Click(object sender, EventArgs e)
        {
            if (mainElevator.Top != doorleft1.Location.Y)//if it is not at top
            {
                isClosing = false;//dont close
                isOpening = true;//oepn the door automatically
                doortimer.Start();//by using door timer

                DoorClosetimer.Start();//automatic door closing after 10 seconds if nothing is done


            }
            else if (mainElevator.Top == doorleft1.Location.Y)//if it is at top then
            {

                doortimer.Start();// door timer starts
                MoveElevatorDown();// lift will come down
                DoorClosetimer.Start();//automatic door closing after 10 seconds if nothing is done

            }


        }
        private void DoorClosetimer_Tick(object sender, EventArgs e)
        {
            if (isOpening) // Only attempt to close if the door is open
            {
                isOpening = false; // Set opening to false
                isClosing = true; // Set the closing state
                doortimer.Start(); // Start closing the door
                btnopen.Enabled = true; // enabling button to let user go if their plan changes
                logEvents("Automatically closing door after 5 seconds.");
                //DoorClosetimer.Start();
            }

            DoorClosetimer.Stop();// Stop the timer after closing the door
        }

    }

}
 
