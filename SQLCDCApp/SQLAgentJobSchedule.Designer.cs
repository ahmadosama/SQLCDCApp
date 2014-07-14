namespace SQLCDCApp
{
    partial class SQLAgentJobSchedule
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox_onetime = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker_onetimestarttime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_onetimestartdate = new System.Windows.Forms.DateTimePicker();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_Ok = new System.Windows.Forms.Button();
            this.groupBox_duration = new System.Windows.Forms.GroupBox();
            this.radioButton_noenddate = new System.Windows.Forms.RadioButton();
            this.dateTimePicker_enddate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker_Startdate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox_dailyfrequency = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_endtime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker_starttime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton_occursevery = new System.Windows.Forms.RadioButton();
            this.radioButton_occursonce = new System.Windows.Forms.RadioButton();
            this.comboBox_occursevery = new System.Windows.Forms.ComboBox();
            this.textBox_occursevery = new System.Windows.Forms.TextBox();
            this.dateTimePicker_oncetime = new System.Windows.Forms.DateTimePicker();
            this.groupBox_frequency = new System.Windows.Forms.GroupBox();
            this.label_recursevery = new System.Windows.Forms.Label();
            this.panel_weekly = new System.Windows.Forms.Panel();
            this.checkBox_Tuesday = new System.Windows.Forms.CheckBox();
            this.checkBox_Saturday = new System.Windows.Forms.CheckBox();
            this.checkBox_Wednesday = new System.Windows.Forms.CheckBox();
            this.checkBox_Monday = new System.Windows.Forms.CheckBox();
            this.checkBox_thursday = new System.Windows.Forms.CheckBox();
            this.checkBox_Sunday = new System.Windows.Forms.CheckBox();
            this.checkBox_friday = new System.Windows.Forms.CheckBox();
            this.label_recurfreq = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_frequency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_scheduletype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_info = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox_onetime.SuspendLayout();
            this.groupBox_duration.SuspendLayout();
            this.groupBox_dailyfrequency.SuspendLayout();
            this.groupBox_frequency.SuspendLayout();
            this.panel_weekly.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox_onetime);
            this.groupBox1.Controls.Add(this.button_cancel);
            this.groupBox1.Controls.Add(this.button_Ok);
            this.groupBox1.Controls.Add(this.groupBox_duration);
            this.groupBox1.Controls.Add(this.groupBox_dailyfrequency);
            this.groupBox1.Controls.Add(this.groupBox_frequency);
            this.groupBox1.Controls.Add(this.comboBox_scheduletype);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(22, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 516);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scheldule SQL Agent Job";
            // 
            // groupBox_onetime
            // 
            this.groupBox_onetime.Controls.Add(this.label9);
            this.groupBox_onetime.Controls.Add(this.label8);
            this.groupBox_onetime.Controls.Add(this.dateTimePicker_onetimestarttime);
            this.groupBox_onetime.Controls.Add(this.dateTimePicker_onetimestartdate);
            this.groupBox_onetime.Location = new System.Drawing.Point(9, 51);
            this.groupBox_onetime.Name = "groupBox_onetime";
            this.groupBox_onetime.Size = new System.Drawing.Size(400, 39);
            this.groupBox_onetime.TabIndex = 7;
            this.groupBox_onetime.TabStop = false;
            this.groupBox_onetime.Text = "One time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Start Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Time";
            // 
            // dateTimePicker_onetimestarttime
            // 
            this.dateTimePicker_onetimestarttime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_onetimestarttime.Location = new System.Drawing.Point(264, 12);
            this.dateTimePicker_onetimestarttime.Name = "dateTimePicker_onetimestarttime";
            this.dateTimePicker_onetimestarttime.Size = new System.Drawing.Size(93, 20);
            this.dateTimePicker_onetimestarttime.TabIndex = 14;
            // 
            // dateTimePicker_onetimestartdate
            // 
            this.dateTimePicker_onetimestartdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_onetimestartdate.Location = new System.Drawing.Point(101, 12);
            this.dateTimePicker_onetimestartdate.Name = "dateTimePicker_onetimestartdate";
            this.dateTimePicker_onetimestartdate.Size = new System.Drawing.Size(90, 20);
            this.dateTimePicker_onetimestartdate.TabIndex = 2;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(99, 477);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 6;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(9, 477);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 5;
            this.button_Ok.Text = "OK";
            this.button_Ok.UseVisualStyleBackColor = true;
            // 
            // groupBox_duration
            // 
            this.groupBox_duration.Controls.Add(this.radioButton_noenddate);
            this.groupBox_duration.Controls.Add(this.dateTimePicker_enddate);
            this.groupBox_duration.Controls.Add(this.label7);
            this.groupBox_duration.Controls.Add(this.dateTimePicker_Startdate);
            this.groupBox_duration.Controls.Add(this.label6);
            this.groupBox_duration.Location = new System.Drawing.Point(9, 392);
            this.groupBox_duration.Name = "groupBox_duration";
            this.groupBox_duration.Size = new System.Drawing.Size(400, 79);
            this.groupBox_duration.TabIndex = 4;
            this.groupBox_duration.TabStop = false;
            this.groupBox_duration.Text = "Duration";
            // 
            // radioButton_noenddate
            // 
            this.radioButton_noenddate.AutoSize = true;
            this.radioButton_noenddate.Location = new System.Drawing.Point(199, 51);
            this.radioButton_noenddate.Name = "radioButton_noenddate";
            this.radioButton_noenddate.Size = new System.Drawing.Size(85, 17);
            this.radioButton_noenddate.TabIndex = 4;
            this.radioButton_noenddate.TabStop = true;
            this.radioButton_noenddate.Text = "No End date";
            this.radioButton_noenddate.UseVisualStyleBackColor = true;
            this.radioButton_noenddate.CheckedChanged += new System.EventHandler(this.radioButton_noenddate_CheckedChanged);
            // 
            // dateTimePicker_enddate
            // 
            this.dateTimePicker_enddate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_enddate.Location = new System.Drawing.Point(267, 25);
            this.dateTimePicker_enddate.Name = "dateTimePicker_enddate";
            this.dateTimePicker_enddate.Size = new System.Drawing.Size(90, 20);
            this.dateTimePicker_enddate.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "End date";
            // 
            // dateTimePicker_Startdate
            // 
            this.dateTimePicker_Startdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Startdate.Location = new System.Drawing.Point(90, 26);
            this.dateTimePicker_Startdate.Name = "dateTimePicker_Startdate";
            this.dateTimePicker_Startdate.Size = new System.Drawing.Size(90, 20);
            this.dateTimePicker_Startdate.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Start date";
            // 
            // groupBox_dailyfrequency
            // 
            this.groupBox_dailyfrequency.Controls.Add(this.dateTimePicker_endtime);
            this.groupBox_dailyfrequency.Controls.Add(this.label5);
            this.groupBox_dailyfrequency.Controls.Add(this.dateTimePicker_starttime);
            this.groupBox_dailyfrequency.Controls.Add(this.label4);
            this.groupBox_dailyfrequency.Controls.Add(this.radioButton_occursevery);
            this.groupBox_dailyfrequency.Controls.Add(this.radioButton_occursonce);
            this.groupBox_dailyfrequency.Controls.Add(this.comboBox_occursevery);
            this.groupBox_dailyfrequency.Controls.Add(this.textBox_occursevery);
            this.groupBox_dailyfrequency.Controls.Add(this.dateTimePicker_oncetime);
            this.groupBox_dailyfrequency.Location = new System.Drawing.Point(9, 262);
            this.groupBox_dailyfrequency.Name = "groupBox_dailyfrequency";
            this.groupBox_dailyfrequency.Size = new System.Drawing.Size(400, 124);
            this.groupBox_dailyfrequency.TabIndex = 3;
            this.groupBox_dailyfrequency.TabStop = false;
            this.groupBox_dailyfrequency.Text = "Daily Frequency";
            // 
            // dateTimePicker_endtime
            // 
            this.dateTimePicker_endtime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_endtime.Location = new System.Drawing.Point(264, 91);
            this.dateTimePicker_endtime.Name = "dateTimePicker_endtime";
            this.dateTimePicker_endtime.Size = new System.Drawing.Size(93, 20);
            this.dateTimePicker_endtime.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Ending at";
            // 
            // dateTimePicker_starttime
            // 
            this.dateTimePicker_starttime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_starttime.Location = new System.Drawing.Point(101, 91);
            this.dateTimePicker_starttime.Name = "dateTimePicker_starttime";
            this.dateTimePicker_starttime.Size = new System.Drawing.Size(93, 20);
            this.dateTimePicker_starttime.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Starting at";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // radioButton_occursevery
            // 
            this.radioButton_occursevery.AutoSize = true;
            this.radioButton_occursevery.Location = new System.Drawing.Point(7, 58);
            this.radioButton_occursevery.Name = "radioButton_occursevery";
            this.radioButton_occursevery.Size = new System.Drawing.Size(88, 17);
            this.radioButton_occursevery.TabIndex = 9;
            this.radioButton_occursevery.TabStop = true;
            this.radioButton_occursevery.Text = "Occurs every";
            this.radioButton_occursevery.UseVisualStyleBackColor = true;
            this.radioButton_occursevery.CheckedChanged += new System.EventHandler(this.radioButton_occursevery_CheckedChanged);
            // 
            // radioButton_occursonce
            // 
            this.radioButton_occursonce.AutoSize = true;
            this.radioButton_occursonce.Location = new System.Drawing.Point(7, 31);
            this.radioButton_occursonce.Name = "radioButton_occursonce";
            this.radioButton_occursonce.Size = new System.Drawing.Size(86, 17);
            this.radioButton_occursonce.TabIndex = 8;
            this.radioButton_occursonce.TabStop = true;
            this.radioButton_occursonce.Text = "Occurs once";
            this.radioButton_occursonce.UseVisualStyleBackColor = true;
            this.radioButton_occursonce.CheckedChanged += new System.EventHandler(this.radioButton_occursonce_CheckedChanged);
            // 
            // comboBox_occursevery
            // 
            this.comboBox_occursevery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_occursevery.FormattingEnabled = true;
            this.comboBox_occursevery.Items.AddRange(new object[] {
            "Hour",
            "Minute",
            "Second"});
            this.comboBox_occursevery.Location = new System.Drawing.Point(159, 57);
            this.comboBox_occursevery.Name = "comboBox_occursevery";
            this.comboBox_occursevery.Size = new System.Drawing.Size(77, 21);
            this.comboBox_occursevery.TabIndex = 7;
            // 
            // textBox_occursevery
            // 
            this.textBox_occursevery.Location = new System.Drawing.Point(98, 57);
            this.textBox_occursevery.Name = "textBox_occursevery";
            this.textBox_occursevery.Size = new System.Drawing.Size(55, 20);
            this.textBox_occursevery.TabIndex = 6;
            this.textBox_occursevery.Text = "1";
            // 
            // dateTimePicker_oncetime
            // 
            this.dateTimePicker_oncetime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_oncetime.Location = new System.Drawing.Point(98, 30);
            this.dateTimePicker_oncetime.Name = "dateTimePicker_oncetime";
            this.dateTimePicker_oncetime.Size = new System.Drawing.Size(93, 20);
            this.dateTimePicker_oncetime.TabIndex = 1;
            // 
            // groupBox_frequency
            // 
            this.groupBox_frequency.Controls.Add(this.label_recursevery);
            this.groupBox_frequency.Controls.Add(this.panel_weekly);
            this.groupBox_frequency.Controls.Add(this.label_recurfreq);
            this.groupBox_frequency.Controls.Add(this.textBox1);
            this.groupBox_frequency.Controls.Add(this.label3);
            this.groupBox_frequency.Controls.Add(this.comboBox_frequency);
            this.groupBox_frequency.Controls.Add(this.label2);
            this.groupBox_frequency.Location = new System.Drawing.Point(9, 96);
            this.groupBox_frequency.Name = "groupBox_frequency";
            this.groupBox_frequency.Size = new System.Drawing.Size(400, 160);
            this.groupBox_frequency.TabIndex = 2;
            this.groupBox_frequency.TabStop = false;
            this.groupBox_frequency.Text = "Frequency";
            // 
            // label_recursevery
            // 
            this.label_recursevery.AutoSize = true;
            this.label_recursevery.Location = new System.Drawing.Point(217, 63);
            this.label_recursevery.Name = "label_recursevery";
            this.label_recursevery.Size = new System.Drawing.Size(0, 13);
            this.label_recursevery.TabIndex = 14;
            // 
            // panel_weekly
            // 
            this.panel_weekly.Controls.Add(this.checkBox_Tuesday);
            this.panel_weekly.Controls.Add(this.checkBox_Saturday);
            this.panel_weekly.Controls.Add(this.checkBox_Wednesday);
            this.panel_weekly.Controls.Add(this.checkBox_Monday);
            this.panel_weekly.Controls.Add(this.checkBox_thursday);
            this.panel_weekly.Controls.Add(this.checkBox_Sunday);
            this.panel_weekly.Controls.Add(this.checkBox_friday);
            this.panel_weekly.Location = new System.Drawing.Point(22, 86);
            this.panel_weekly.Name = "panel_weekly";
            this.panel_weekly.Size = new System.Drawing.Size(355, 65);
            this.panel_weekly.TabIndex = 13;
            // 
            // checkBox_Tuesday
            // 
            this.checkBox_Tuesday.AutoSize = true;
            this.checkBox_Tuesday.Location = new System.Drawing.Point(2, 36);
            this.checkBox_Tuesday.Name = "checkBox_Tuesday";
            this.checkBox_Tuesday.Size = new System.Drawing.Size(67, 17);
            this.checkBox_Tuesday.TabIndex = 12;
            this.checkBox_Tuesday.Text = "Tuesday";
            this.checkBox_Tuesday.UseVisualStyleBackColor = true;
            // 
            // checkBox_Saturday
            // 
            this.checkBox_Saturday.AutoSize = true;
            this.checkBox_Saturday.Location = new System.Drawing.Point(177, 36);
            this.checkBox_Saturday.Name = "checkBox_Saturday";
            this.checkBox_Saturday.Size = new System.Drawing.Size(68, 17);
            this.checkBox_Saturday.TabIndex = 8;
            this.checkBox_Saturday.Text = "Saturday";
            this.checkBox_Saturday.UseVisualStyleBackColor = true;
            // 
            // checkBox_Wednesday
            // 
            this.checkBox_Wednesday.AutoSize = true;
            this.checkBox_Wednesday.Location = new System.Drawing.Point(91, 13);
            this.checkBox_Wednesday.Name = "checkBox_Wednesday";
            this.checkBox_Wednesday.Size = new System.Drawing.Size(83, 17);
            this.checkBox_Wednesday.TabIndex = 11;
            this.checkBox_Wednesday.Text = "Wednesday";
            this.checkBox_Wednesday.UseVisualStyleBackColor = true;
            // 
            // checkBox_Monday
            // 
            this.checkBox_Monday.AutoSize = true;
            this.checkBox_Monday.Location = new System.Drawing.Point(2, 13);
            this.checkBox_Monday.Name = "checkBox_Monday";
            this.checkBox_Monday.Size = new System.Drawing.Size(64, 17);
            this.checkBox_Monday.TabIndex = 6;
            this.checkBox_Monday.Text = "Monday";
            this.checkBox_Monday.UseVisualStyleBackColor = true;
            // 
            // checkBox_thursday
            // 
            this.checkBox_thursday.AutoSize = true;
            this.checkBox_thursday.Location = new System.Drawing.Point(91, 36);
            this.checkBox_thursday.Name = "checkBox_thursday";
            this.checkBox_thursday.Size = new System.Drawing.Size(70, 17);
            this.checkBox_thursday.TabIndex = 10;
            this.checkBox_thursday.Text = "Thursday";
            this.checkBox_thursday.UseVisualStyleBackColor = true;
            // 
            // checkBox_Sunday
            // 
            this.checkBox_Sunday.AutoSize = true;
            this.checkBox_Sunday.Location = new System.Drawing.Point(263, 13);
            this.checkBox_Sunday.Name = "checkBox_Sunday";
            this.checkBox_Sunday.Size = new System.Drawing.Size(62, 17);
            this.checkBox_Sunday.TabIndex = 7;
            this.checkBox_Sunday.Text = "Sunday";
            this.checkBox_Sunday.UseVisualStyleBackColor = true;
            // 
            // checkBox_friday
            // 
            this.checkBox_friday.AutoSize = true;
            this.checkBox_friday.Location = new System.Drawing.Point(177, 13);
            this.checkBox_friday.Name = "checkBox_friday";
            this.checkBox_friday.Size = new System.Drawing.Size(54, 17);
            this.checkBox_friday.TabIndex = 9;
            this.checkBox_friday.Text = "Friday";
            this.checkBox_friday.UseVisualStyleBackColor = true;
            // 
            // label_recurfreq
            // 
            this.label_recurfreq.AutoSize = true;
            this.label_recurfreq.Location = new System.Drawing.Point(227, 63);
            this.label_recurfreq.Name = "label_recurfreq";
            this.label_recurfreq.Size = new System.Drawing.Size(0, 13);
            this.label_recurfreq.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Recurrs every";
            // 
            // comboBox_frequency
            // 
            this.comboBox_frequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_frequency.FormattingEnabled = true;
            this.comboBox_frequency.Items.AddRange(new object[] {
            "Daily",
            "Weekly"});
            this.comboBox_frequency.Location = new System.Drawing.Point(111, 26);
            this.comboBox_frequency.Name = "comboBox_frequency";
            this.comboBox_frequency.Size = new System.Drawing.Size(266, 21);
            this.comboBox_frequency.TabIndex = 2;
            this.comboBox_frequency.SelectedIndexChanged += new System.EventHandler(this.comboBox_frequency_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Occurs";
            // 
            // comboBox_scheduletype
            // 
            this.comboBox_scheduletype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_scheduletype.FormattingEnabled = true;
            this.comboBox_scheduletype.Items.AddRange(new object[] {
            "Recurring",
            "One time"});
            this.comboBox_scheduletype.Location = new System.Drawing.Point(122, 21);
            this.comboBox_scheduletype.Name = "comboBox_scheduletype";
            this.comboBox_scheduletype.Size = new System.Drawing.Size(266, 21);
            this.comboBox_scheduletype.TabIndex = 1;
            this.comboBox_scheduletype.SelectedIndexChanged += new System.EventHandler(this.comboBox_scheduletype_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Schedule Type";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_info);
            this.panel1.Location = new System.Drawing.Point(22, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 40);
            this.panel1.TabIndex = 1;
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(4, 4);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(0, 13);
            this.label_info.TabIndex = 0;
            // 
            // SQLAgentJobSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 576);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "SQLAgentJobSchedule";
            this.Text = "ScheduleIDL";
            this.Load += new System.EventHandler(this.ScheduleIDL_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_onetime.ResumeLayout(false);
            this.groupBox_onetime.PerformLayout();
            this.groupBox_duration.ResumeLayout(false);
            this.groupBox_duration.PerformLayout();
            this.groupBox_dailyfrequency.ResumeLayout(false);
            this.groupBox_dailyfrequency.PerformLayout();
            this.groupBox_frequency.ResumeLayout(false);
            this.groupBox_frequency.PerformLayout();
            this.panel_weekly.ResumeLayout(false);
            this.panel_weekly.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox_frequency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_frequency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_scheduletype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label_recurfreq;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel_weekly;
        private System.Windows.Forms.CheckBox checkBox_Tuesday;
        private System.Windows.Forms.CheckBox checkBox_Saturday;
        private System.Windows.Forms.CheckBox checkBox_Wednesday;
        private System.Windows.Forms.CheckBox checkBox_Monday;
        private System.Windows.Forms.CheckBox checkBox_thursday;
        private System.Windows.Forms.CheckBox checkBox_Sunday;
        private System.Windows.Forms.CheckBox checkBox_friday;
        private System.Windows.Forms.GroupBox groupBox_dailyfrequency;
        private System.Windows.Forms.DateTimePicker dateTimePicker_oncetime;
        private System.Windows.Forms.RadioButton radioButton_occursevery;
        private System.Windows.Forms.RadioButton radioButton_occursonce;
        private System.Windows.Forms.ComboBox comboBox_occursevery;
        private System.Windows.Forms.TextBox textBox_occursevery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox_duration;
        private System.Windows.Forms.DateTimePicker dateTimePicker_enddate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Startdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endtime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_starttime;
        private System.Windows.Forms.RadioButton radioButton_noenddate;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.GroupBox groupBox_onetime;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker_onetimestarttime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_onetimestartdate;
        private System.Windows.Forms.Label label_recursevery;

    }
}