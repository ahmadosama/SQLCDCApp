namespace SQLCDCApp
{
    partial class CDCData
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_capturedinstances = new System.Windows.Forms.ComboBox();
            this.button_Getdata = new System.Windows.Forms.Button();
            this.dataGridView_showresults = new System.Windows.Forms.DataGridView();
            this.radioButton_alldata = new System.Windows.Forms.RadioButton();
            this.radioButton_netdata = new System.Windows.Forms.RadioButton();
            this.radioButton_Timewise = new System.Windows.Forms.RadioButton();
            this.dateTimePicker_FromDataTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_ToDateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox_ViewData = new System.Windows.Forms.GroupBox();
            this.groupBox_ExportData = new System.Windows.Forms.GroupBox();
            this.button_scheduleIDL = new System.Windows.Forms.Button();
            this.panel_dbconnection = new System.Windows.Forms.Panel();
            this.button_Connect = new System.Windows.Forms.Button();
            this.comboBox_Tables = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Database = new System.Windows.Forms.ComboBox();
            this.label_Databases = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_Auth = new System.Windows.Forms.Label();
            this.comboBox_Authentication = new System.Windows.Forms.ComboBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.label_user = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_Server = new System.Windows.Forms.Label();
            this.button_InitialSync = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_updatecount = new System.Windows.Forms.TextBox();
            this.textBox_Deletecount = new System.Windows.Forms.TextBox();
            this.textBox_Insertcount = new System.Windows.Forms.TextBox();
            this.textBox_datacount = new System.Windows.Forms.TextBox();
            this.button_exporttofile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_showresults)).BeginInit();
            this.groupBox_ViewData.SuspendLayout();
            this.groupBox_ExportData.SuspendLayout();
            this.panel_dbconnection.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Captured Instances";
            // 
            // comboBox_capturedinstances
            // 
            this.comboBox_capturedinstances.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_capturedinstances.FormattingEnabled = true;
            this.comboBox_capturedinstances.Location = new System.Drawing.Point(122, 22);
            this.comboBox_capturedinstances.Name = "comboBox_capturedinstances";
            this.comboBox_capturedinstances.Size = new System.Drawing.Size(124, 21);
            this.comboBox_capturedinstances.TabIndex = 4;
            // 
            // button_Getdata
            // 
            this.button_Getdata.Location = new System.Drawing.Point(265, 20);
            this.button_Getdata.Name = "button_Getdata";
            this.button_Getdata.Size = new System.Drawing.Size(40, 23);
            this.button_Getdata.TabIndex = 5;
            this.button_Getdata.Text = "GO";
            this.button_Getdata.UseVisualStyleBackColor = true;
            this.button_Getdata.Click += new System.EventHandler(this.button_Getdata_Click);
            // 
            // dataGridView_showresults
            // 
            this.dataGridView_showresults.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_showresults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_showresults.Location = new System.Drawing.Point(12, 319);
            this.dataGridView_showresults.Name = "dataGridView_showresults";
            this.dataGridView_showresults.Size = new System.Drawing.Size(783, 202);
            this.dataGridView_showresults.TabIndex = 6;
            //this.dataGridView_showresults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_showresults_CellContentClick);
            this.dataGridView_showresults.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_showresults_ColumnHeaderMouseClick);
            this.dataGridView_showresults.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_showresults_DataBindingComplete);
            // 
            // radioButton_alldata
            // 
            this.radioButton_alldata.AutoSize = true;
            this.radioButton_alldata.Location = new System.Drawing.Point(20, 56);
            this.radioButton_alldata.Name = "radioButton_alldata";
            this.radioButton_alldata.Size = new System.Drawing.Size(138, 17);
            this.radioButton_alldata.TabIndex = 7;
            this.radioButton_alldata.TabStop = true;
            this.radioButton_alldata.Text = "Get all changed records";
            this.radioButton_alldata.UseVisualStyleBackColor = true;
            // 
            // radioButton_netdata
            // 
            this.radioButton_netdata.AutoSize = true;
            this.radioButton_netdata.Location = new System.Drawing.Point(20, 80);
            this.radioButton_netdata.Name = "radioButton_netdata";
            this.radioButton_netdata.Size = new System.Drawing.Size(143, 17);
            this.radioButton_netdata.TabIndex = 8;
            this.radioButton_netdata.TabStop = true;
            this.radioButton_netdata.Text = "Get net changed records";
            this.radioButton_netdata.UseVisualStyleBackColor = true;
            // 
            // radioButton_Timewise
            // 
            this.radioButton_Timewise.AutoSize = true;
            this.radioButton_Timewise.Location = new System.Drawing.Point(20, 104);
            this.radioButton_Timewise.Name = "radioButton_Timewise";
            this.radioButton_Timewise.Size = new System.Drawing.Size(144, 17);
            this.radioButton_Timewise.TabIndex = 9;
            this.radioButton_Timewise.TabStop = true;
            this.radioButton_Timewise.Text = "Get Data Between Dates";
            this.radioButton_Timewise.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker_FromDataTime
            // 
            this.dateTimePicker_FromDataTime.Location = new System.Drawing.Point(57, 127);
            this.dateTimePicker_FromDataTime.Name = "dateTimePicker_FromDataTime";
            this.dateTimePicker_FromDataTime.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_FromDataTime.TabIndex = 10;
            // 
            // dateTimePicker_ToDateTime
            // 
            this.dateTimePicker_ToDateTime.Location = new System.Drawing.Point(57, 153);
            this.dateTimePicker_ToDateTime.Name = "dateTimePicker_ToDateTime";
            this.dateTimePicker_ToDateTime.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_ToDateTime.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "To";
            // 
            // groupBox_ViewData
            // 
            this.groupBox_ViewData.Controls.Add(this.radioButton_netdata);
            this.groupBox_ViewData.Controls.Add(this.label3);
            this.groupBox_ViewData.Controls.Add(this.label1);
            this.groupBox_ViewData.Controls.Add(this.label2);
            this.groupBox_ViewData.Controls.Add(this.comboBox_capturedinstances);
            this.groupBox_ViewData.Controls.Add(this.dateTimePicker_ToDateTime);
            this.groupBox_ViewData.Controls.Add(this.button_Getdata);
            this.groupBox_ViewData.Controls.Add(this.dateTimePicker_FromDataTime);
            this.groupBox_ViewData.Controls.Add(this.radioButton_alldata);
            this.groupBox_ViewData.Controls.Add(this.radioButton_Timewise);
            this.groupBox_ViewData.Location = new System.Drawing.Point(12, 13);
            this.groupBox_ViewData.Name = "groupBox_ViewData";
            this.groupBox_ViewData.Size = new System.Drawing.Size(314, 177);
            this.groupBox_ViewData.TabIndex = 14;
            this.groupBox_ViewData.TabStop = false;
            this.groupBox_ViewData.Text = "View Change Data";
            // 
            // groupBox_ExportData
            // 
            this.groupBox_ExportData.Controls.Add(this.button_scheduleIDL);
            this.groupBox_ExportData.Controls.Add(this.panel_dbconnection);
            this.groupBox_ExportData.Controls.Add(this.button_InitialSync);
            this.groupBox_ExportData.Location = new System.Drawing.Point(341, 13);
            this.groupBox_ExportData.Name = "groupBox_ExportData";
            this.groupBox_ExportData.Size = new System.Drawing.Size(454, 271);
            this.groupBox_ExportData.TabIndex = 15;
            this.groupBox_ExportData.TabStop = false;
            this.groupBox_ExportData.Text = "Increment Data Load";
            // 
            // button_scheduleIDL
            // 
            this.button_scheduleIDL.Location = new System.Drawing.Point(92, 190);
            this.button_scheduleIDL.Name = "button_scheduleIDL";
            this.button_scheduleIDL.Size = new System.Drawing.Size(75, 23);
            this.button_scheduleIDL.TabIndex = 17;
            this.button_scheduleIDL.Text = "Schedule ";
            this.button_scheduleIDL.UseVisualStyleBackColor = true;
            this.button_scheduleIDL.Click += new System.EventHandler(this.button_scheduleIDL_Click);
            // 
            // panel_dbconnection
            // 
            this.panel_dbconnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_dbconnection.Controls.Add(this.button_Connect);
            this.panel_dbconnection.Controls.Add(this.comboBox_Tables);
            this.panel_dbconnection.Controls.Add(this.label4);
            this.panel_dbconnection.Controls.Add(this.comboBox_Database);
            this.panel_dbconnection.Controls.Add(this.label_Databases);
            this.panel_dbconnection.Controls.Add(this.textBox_password);
            this.panel_dbconnection.Controls.Add(this.label_Auth);
            this.panel_dbconnection.Controls.Add(this.comboBox_Authentication);
            this.panel_dbconnection.Controls.Add(this.textBox_User);
            this.panel_dbconnection.Controls.Add(this.textBox_Server);
            this.panel_dbconnection.Controls.Add(this.label_user);
            this.panel_dbconnection.Controls.Add(this.label_Password);
            this.panel_dbconnection.Controls.Add(this.label_Server);
            this.panel_dbconnection.Location = new System.Drawing.Point(6, 25);
            this.panel_dbconnection.Name = "panel_dbconnection";
            this.panel_dbconnection.Size = new System.Drawing.Size(426, 152);
            this.panel_dbconnection.TabIndex = 16;
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(85, 71);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(63, 23);
            this.button_Connect.TabIndex = 17;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // comboBox_Tables
            // 
            this.comboBox_Tables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tables.FormattingEnabled = true;
            this.comboBox_Tables.Location = new System.Drawing.Point(252, 109);
            this.comboBox_Tables.Name = "comboBox_Tables";
            this.comboBox_Tables.Size = new System.Drawing.Size(145, 21);
            this.comboBox_Tables.TabIndex = 11;
            this.comboBox_Tables.SelectedIndexChanged += new System.EventHandler(this.comboBox_Tables_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Table";
            // 
            // comboBox_Database
            // 
            this.comboBox_Database.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Database.FormattingEnabled = true;
            this.comboBox_Database.Location = new System.Drawing.Point(85, 109);
            this.comboBox_Database.Name = "comboBox_Database";
            this.comboBox_Database.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Database.TabIndex = 9;
            this.comboBox_Database.SelectedIndexChanged += new System.EventHandler(this.comboBox_Database_SelectedIndexChanged);
            // 
            // label_Databases
            // 
            this.label_Databases.AutoSize = true;
            this.label_Databases.Location = new System.Drawing.Point(26, 117);
            this.label_Databases.Name = "label_Databases";
            this.label_Databases.Size = new System.Drawing.Size(53, 13);
            this.label_Databases.TabIndex = 8;
            this.label_Databases.Text = "Database";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(252, 47);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(100, 20);
            this.textBox_password.TabIndex = 7;
            // 
            // label_Auth
            // 
            this.label_Auth.AutoSize = true;
            this.label_Auth.Location = new System.Drawing.Point(9, 47);
            this.label_Auth.Name = "label_Auth";
            this.label_Auth.Size = new System.Drawing.Size(75, 13);
            this.label_Auth.TabIndex = 2;
            this.label_Auth.Text = "Authentication";
            // 
            // comboBox_Authentication
            // 
            this.comboBox_Authentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Authentication.FormattingEnabled = true;
            this.comboBox_Authentication.Items.AddRange(new object[] {
            "Windows",
            "SQL"});
            this.comboBox_Authentication.Location = new System.Drawing.Point(85, 44);
            this.comboBox_Authentication.Name = "comboBox_Authentication";
            this.comboBox_Authentication.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Authentication.TabIndex = 3;
           // this.comboBox_Authentication.SelectedIndexChanged += new System.EventHandler(this.comboBox_Authentication_SelectedIndexChanged);
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(252, 17);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(100, 20);
            this.textBox_User.TabIndex = 6;
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(85, 17);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(100, 20);
            this.textBox_Server.TabIndex = 1;
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(217, 20);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(29, 13);
            this.label_user.TabIndex = 4;
            this.label_user.Text = "User";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(193, 49);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Password";
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Location = new System.Drawing.Point(41, 20);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(38, 13);
            this.label_Server.TabIndex = 0;
            this.label_Server.Text = "Server";
            // 
            // button_InitialSync
            // 
            this.button_InitialSync.Location = new System.Drawing.Point(6, 190);
            this.button_InitialSync.Name = "button_InitialSync";
            this.button_InitialSync.Size = new System.Drawing.Size(75, 23);
            this.button_InitialSync.TabIndex = 2;
            this.button_InitialSync.Text = "Initial Sync";
            this.button_InitialSync.UseVisualStyleBackColor = true;
            this.button_InitialSync.Click += new System.EventHandler(this.button_InitialSync_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_updatecount);
            this.panel1.Controls.Add(this.textBox_Deletecount);
            this.panel1.Controls.Add(this.textBox_Insertcount);
            this.panel1.Controls.Add(this.textBox_datacount);
            this.panel1.Location = new System.Drawing.Point(12, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 88);
            this.panel1.TabIndex = 16;
            // 
            // textBox_updatecount
            // 
            this.textBox_updatecount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_updatecount.Location = new System.Drawing.Point(3, 64);
            this.textBox_updatecount.Name = "textBox_updatecount";
            this.textBox_updatecount.ReadOnly = true;
            this.textBox_updatecount.Size = new System.Drawing.Size(304, 13);
            this.textBox_updatecount.TabIndex = 3;
            // 
            // textBox_Deletecount
            // 
            this.textBox_Deletecount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Deletecount.Location = new System.Drawing.Point(3, 45);
            this.textBox_Deletecount.Name = "textBox_Deletecount";
            this.textBox_Deletecount.ReadOnly = true;
            this.textBox_Deletecount.Size = new System.Drawing.Size(302, 13);
            this.textBox_Deletecount.TabIndex = 2;
            this.textBox_Deletecount.Text = " ";
            // 
            // textBox_Insertcount
            // 
            this.textBox_Insertcount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Insertcount.Location = new System.Drawing.Point(3, 26);
            this.textBox_Insertcount.Name = "textBox_Insertcount";
            this.textBox_Insertcount.ReadOnly = true;
            this.textBox_Insertcount.Size = new System.Drawing.Size(302, 13);
            this.textBox_Insertcount.TabIndex = 1;
            this.textBox_Insertcount.Text = " ";
            // 
            // textBox_datacount
            // 
            this.textBox_datacount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_datacount.Location = new System.Drawing.Point(3, 7);
            this.textBox_datacount.Name = "textBox_datacount";
            this.textBox_datacount.ReadOnly = true;
            this.textBox_datacount.Size = new System.Drawing.Size(302, 13);
            this.textBox_datacount.TabIndex = 0;
            this.textBox_datacount.Text = " ";
            // 
            // button_exporttofile
            // 
            this.button_exporttofile.Location = new System.Drawing.Point(12, 290);
            this.button_exporttofile.Name = "button_exporttofile";
            this.button_exporttofile.Size = new System.Drawing.Size(87, 23);
            this.button_exporttofile.TabIndex = 17;
            this.button_exporttofile.Text = "Export to file";
            this.button_exporttofile.UseVisualStyleBackColor = true;
            this.button_exporttofile.Click += new System.EventHandler(this.button_exporttofile_Click);
            // 
            // CDCData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 533);
            this.Controls.Add(this.button_exporttofile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox_ExportData);
            this.Controls.Add(this.groupBox_ViewData);
            this.Controls.Add(this.dataGridView_showresults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "CDCData";
            this.Text = "ViewData";
            this.Load += new System.EventHandler(this.CDCData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_showresults)).EndInit();
            this.groupBox_ViewData.ResumeLayout(false);
            this.groupBox_ViewData.PerformLayout();
            this.groupBox_ExportData.ResumeLayout(false);
            this.panel_dbconnection.ResumeLayout(false);
            this.panel_dbconnection.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_capturedinstances;
        private System.Windows.Forms.Button button_Getdata;
        private System.Windows.Forms.DataGridView dataGridView_showresults;
        private System.Windows.Forms.RadioButton radioButton_alldata;
        private System.Windows.Forms.RadioButton radioButton_netdata;
        private System.Windows.Forms.RadioButton radioButton_Timewise;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FromDataTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ToDateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox_ViewData;
        private System.Windows.Forms.GroupBox groupBox_ExportData;
        private System.Windows.Forms.Button button_InitialSync;
        private System.Windows.Forms.Panel panel_dbconnection;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_Auth;
        private System.Windows.Forms.ComboBox comboBox_Authentication;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.TextBox textBox_Server;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.ComboBox comboBox_Tables;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Database;
        private System.Windows.Forms.Label label_Databases;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_datacount;
        private System.Windows.Forms.TextBox textBox_updatecount;
        private System.Windows.Forms.TextBox textBox_Deletecount;
        private System.Windows.Forms.TextBox textBox_Insertcount;
        private System.Windows.Forms.Button button_scheduleIDL;
        private System.Windows.Forms.Button button_exporttofile;
    }
}