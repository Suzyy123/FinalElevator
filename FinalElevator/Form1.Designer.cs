namespace FinalElevator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            datagridviewlogs = new DataGridView();
            mainElevator = new PictureBox();
            doorleft1 = new PictureBox();
            panel1 = new Panel();
            pic2 = new PictureBox();
            pic3 = new PictureBox();
            emergency = new Button();
            btnopen = new Button();
            pic1 = new PictureBox();
            btnclose = new Button();
            btn_G = new Button();
            btn_1 = new Button();
            doorright1 = new PictureBox();
            doorleft = new PictureBox();
            doorright = new PictureBox();
            doortimer = new System.Windows.Forms.Timer(components);
            lifttimerup = new System.Windows.Forms.Timer(components);
            lifttimerdown = new System.Windows.Forms.Timer(components);
            ClearLogs = new Button();
            Exit = new Button();
            btnColorDown = new Button();
            btnColorUp = new Button();
            label2 = new Label();
            btndown = new Button();
            btnUp = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            DoorClosetimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)datagridviewlogs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mainElevator).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doorleft1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pic2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pic1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doorright1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doorleft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)doorright).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // datagridviewlogs
            // 
            datagridviewlogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            datagridviewlogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datagridviewlogs.BackgroundColor = SystemColors.ButtonHighlight;
            datagridviewlogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridviewlogs.Location = new Point(1240, 175);
            datagridviewlogs.Name = "datagridviewlogs";
            datagridviewlogs.RowHeadersWidth = 72;
            datagridviewlogs.Size = new Size(807, 529);
            datagridviewlogs.TabIndex = 0;
            datagridviewlogs.Click += Form1_Load;
            // 
            // mainElevator
            // 
            mainElevator.BackgroundImage = (Image)resources.GetObject("mainElevator.BackgroundImage");
            mainElevator.BackgroundImageLayout = ImageLayout.Stretch;
            mainElevator.Location = new Point(239, 608);
            mainElevator.Name = "mainElevator";
            mainElevator.Size = new Size(314, 361);
            mainElevator.TabIndex = 1;
            mainElevator.TabStop = false;
            // 
            // doorleft1
            // 
            doorleft1.BackgroundImage = (Image)resources.GetObject("doorleft1.BackgroundImage");
            doorleft1.BackgroundImageLayout = ImageLayout.Stretch;
            doorleft1.Location = new Point(239, 121);
            doorleft1.Name = "doorleft1";
            doorleft1.Size = new Size(158, 357);
            doorleft1.TabIndex = 2;
            doorleft1.TabStop = false;
            doorleft1.Click += btn_1_click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(pic2);
            panel1.Controls.Add(pic3);
            panel1.Controls.Add(emergency);
            panel1.Controls.Add(btnopen);
            panel1.Controls.Add(pic1);
            panel1.Controls.Add(btnclose);
            panel1.Controls.Add(btn_G);
            panel1.Controls.Add(btn_1);
            panel1.Location = new Point(881, 85);
            panel1.Name = "panel1";
            panel1.Size = new Size(258, 825);
            panel1.TabIndex = 3;
            // 
            // pic2
            // 
            pic2.BackColor = SystemColors.ActiveCaptionText;
            pic2.BackgroundImage = (Image)resources.GetObject("pic2.BackgroundImage");
            pic2.BackgroundImageLayout = ImageLayout.Stretch;
            pic2.Location = new Point(40, 32);
            pic2.Name = "pic2";
            pic2.Size = new Size(182, 181);
            pic2.TabIndex = 18;
            pic2.TabStop = false;
            // 
            // pic3
            // 
            pic3.BackColor = SystemColors.ActiveCaptionText;
            pic3.BackgroundImage = (Image)resources.GetObject("pic3.BackgroundImage");
            pic3.BackgroundImageLayout = ImageLayout.Stretch;
            pic3.Location = new Point(40, 32);
            pic3.Name = "pic3";
            pic3.Size = new Size(182, 181);
            pic3.TabIndex = 19;
            pic3.TabStop = false;
            // 
            // emergency
            // 
            emergency.BackgroundImage = (Image)resources.GetObject("emergency.BackgroundImage");
            emergency.BackgroundImageLayout = ImageLayout.Stretch;
            emergency.Location = new Point(92, 710);
            emergency.Name = "emergency";
            emergency.Size = new Size(73, 66);
            emergency.TabIndex = 9;
            emergency.UseVisualStyleBackColor = true;
            emergency.Click += EmergencyAlarm_Click;
            // 
            // btnopen
            // 
            btnopen.BackgroundImage = (Image)resources.GetObject("btnopen.BackgroundImage");
            btnopen.BackgroundImageLayout = ImageLayout.Stretch;
            btnopen.Location = new Point(21, 579);
            btnopen.Name = "btnopen";
            btnopen.Size = new Size(83, 78);
            btnopen.TabIndex = 7;
            btnopen.UseVisualStyleBackColor = true;
            btnopen.Click += btn_Open_Click;
            // 
            // pic1
            // 
            pic1.BackColor = SystemColors.ActiveCaptionText;
            pic1.Location = new Point(3, 0);
            pic1.Name = "pic1";
            pic1.Size = new Size(255, 249);
            pic1.TabIndex = 17;
            pic1.TabStop = false;
            // 
            // btnclose
            // 
            btnclose.BackgroundImage = (Image)resources.GetObject("btnclose.BackgroundImage");
            btnclose.BackgroundImageLayout = ImageLayout.Stretch;
            btnclose.Location = new Point(147, 579);
            btnclose.Name = "btnclose";
            btnclose.Size = new Size(83, 78);
            btnclose.TabIndex = 6;
            btnclose.UseVisualStyleBackColor = true;
            btnclose.Click += btn_Close_Click;
            // 
            // btn_G
            // 
            btn_G.BackgroundImage = (Image)resources.GetObject("btn_G.BackgroundImage");
            btn_G.BackgroundImageLayout = ImageLayout.Stretch;
            btn_G.Location = new Point(80, 410);
            btn_G.Name = "btn_G";
            btn_G.Size = new Size(113, 106);
            btn_G.TabIndex = 5;
            btn_G.UseVisualStyleBackColor = true;
            btn_G.Click += btn_G_click;
            // 
            // btn_1
            // 
            btn_1.BackgroundImage = (Image)resources.GetObject("btn_1.BackgroundImage");
            btn_1.BackgroundImageLayout = ImageLayout.Stretch;
            btn_1.Location = new Point(80, 288);
            btn_1.Name = "btn_1";
            btn_1.Size = new Size(113, 112);
            btn_1.TabIndex = 4;
            btn_1.UseVisualStyleBackColor = true;
            btn_1.Click += btn_1_click;
            // 
            // doorright1
            // 
            doorright1.BackgroundImage = (Image)resources.GetObject("doorright1.BackgroundImage");
            doorright1.BackgroundImageLayout = ImageLayout.Stretch;
            doorright1.Location = new Point(395, 121);
            doorright1.Name = "doorright1";
            doorright1.Size = new Size(158, 357);
            doorright1.TabIndex = 4;
            doorright1.TabStop = false;
            doorright1.Click += btn_1_click;
            // 
            // doorleft
            // 
            doorleft.BackgroundImage = (Image)resources.GetObject("doorleft.BackgroundImage");
            doorleft.BackgroundImageLayout = ImageLayout.Stretch;
            doorleft.Location = new Point(239, 608);
            doorleft.Name = "doorleft";
            doorleft.Size = new Size(158, 357);
            doorleft.TabIndex = 5;
            doorleft.TabStop = false;
            doorleft.Click += btn_G_click;
            // 
            // doorright
            // 
            doorright.BackgroundImage = (Image)resources.GetObject("doorright.BackgroundImage");
            doorright.BackgroundImageLayout = ImageLayout.Stretch;
            doorright.Location = new Point(395, 608);
            doorright.Name = "doorright";
            doorright.Size = new Size(158, 357);
            doorright.TabIndex = 6;
            doorright.TabStop = false;
            doorright.Click += btn_G_click;
            // 
            // doortimer
            // 
            doortimer.Tick += door_Timer_Tick;
            // 
            // lifttimerup
            // 
            lifttimerup.Tick += liftTimerUp_Tick;
            // 
            // lifttimerdown
            // 
            lifttimerdown.Tick += liftTimerDown_Tick;
            // 
            // ClearLogs
            // 
            ClearLogs.Location = new Point(1240, 722);
            ClearLogs.Name = "ClearLogs";
            ClearLogs.Size = new Size(162, 86);
            ClearLogs.TabIndex = 7;
            ClearLogs.Text = "ClearLogs";
            ClearLogs.UseVisualStyleBackColor = true;
            ClearLogs.Click += btn_ClearLog_Click;
            // 
            // Exit
            // 
            Exit.Location = new Point(1858, 722);
            Exit.Name = "Exit";
            Exit.Size = new Size(162, 86);
            Exit.TabIndex = 8;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += btn_Exit_Click;
            // 
            // btnColorDown
            // 
            btnColorDown.BackColor = SystemColors.ActiveCaptionText;
            btnColorDown.Location = new Point(365, 85);
            btnColorDown.Name = "btnColorDown";
            btnColorDown.Size = new Size(59, 30);
            btnColorDown.TabIndex = 10;
            btnColorDown.UseVisualStyleBackColor = false;
            // 
            // btnColorUp
            // 
            btnColorUp.BackColor = SystemColors.ActiveCaptionText;
            btnColorUp.Location = new Point(365, 571);
            btnColorUp.Name = "btnColorUp";
            btnColorUp.Size = new Size(59, 31);
            btnColorUp.TabIndex = 11;
            btnColorUp.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1601, 85);
            label2.Name = "label2";
            label2.Size = new Size(179, 57);
            label2.TabIndex = 12;
            label2.Text = "History";
            // 
            // btndown
            // 
            btndown.BackColor = SystemColors.ActiveCaptionText;
            btndown.BackgroundImage = (Image)resources.GetObject("btndown.BackgroundImage");
            btndown.BackgroundImageLayout = ImageLayout.Stretch;
            btndown.Location = new Point(621, 722);
            btndown.Name = "btndown";
            btndown.Size = new Size(56, 58);
            btndown.TabIndex = 13;
            btndown.UseVisualStyleBackColor = false;
            btndown.Click += btndown_Click;
            // 
            // btnUp
            // 
            btnUp.BackColor = SystemColors.ActiveCaptionText;
            btnUp.BackgroundImage = (Image)resources.GetObject("btnUp.BackgroundImage");
            btnUp.BackgroundImageLayout = ImageLayout.Stretch;
            btnUp.Location = new Point(621, 218);
            btnUp.Name = "btnUp";
            btnUp.Size = new Size(56, 54);
            btnUp.TabIndex = 14;
            btnUp.UseVisualStyleBackColor = false;
            btnUp.Click += btnUp_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(783, 491);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(-1, 488);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(783, 477);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 15.8571434F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(867, 0);
            label1.Name = "label1";
            label1.Size = new Size(312, 50);
            label1.TabIndex = 17;
            label1.Text = "Elevator System";
            // 
            // DoorClosetimer
            // 
            DoorClosetimer.Interval = 5000;
            DoorClosetimer.Tick += DoorClosetimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2191, 967);
            Controls.Add(label1);
            Controls.Add(btndown);
            Controls.Add(label2);
            Controls.Add(btnColorUp);
            Controls.Add(btnColorDown);
            Controls.Add(Exit);
            Controls.Add(ClearLogs);
            Controls.Add(doorright);
            Controls.Add(datagridviewlogs);
            Controls.Add(doorleft);
            Controls.Add(doorright1);
            Controls.Add(panel1);
            Controls.Add(doorleft1);
            Controls.Add(mainElevator);
            Controls.Add(pictureBox2);
            Controls.Add(btnUp);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)datagridviewlogs).EndInit();
            ((System.ComponentModel.ISupportInitialize)mainElevator).EndInit();
            ((System.ComponentModel.ISupportInitialize)doorleft1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pic2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pic1).EndInit();
            ((System.ComponentModel.ISupportInitialize)doorright1).EndInit();
            ((System.ComponentModel.ISupportInitialize)doorleft).EndInit();
            ((System.ComponentModel.ISupportInitialize)doorright).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView datagridviewlogs; 
        private PictureBox mainElevator;
        private PictureBox doorleft1;
        private Panel panel1;
        private Button btnopen;
        private Button btnclose;
        private Button btn_G;
        private Button btn_1;
        private PictureBox doorright1;
        private PictureBox doorleft;
        private PictureBox doorright;
        private System.Windows.Forms.Timer doortimer;
        private System.Windows.Forms.Timer lifttimerup;
        private System.Windows.Forms.Timer lifttimerdown;
        private Button ClearLogs;
        private Button Exit;
        private Button emergency;
        private Button btnColorDown;
        private Button btnColorUp;
        private Label label2;
        private Button btndown;
        private Button btnUp;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pic1;
        private Label label1;
        private PictureBox pic2;
        private PictureBox pic3;
        private System.Windows.Forms.Timer DoorClosetimer;
    }
}
