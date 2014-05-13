namespace SQLCDCApp
{
    partial class Form1
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
            this.groupBox_SqlCon = new System.Windows.Forms.GroupBox();
            this.button_disablecdc = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_selectdb = new System.Windows.Forms.Button();
            this.dataGridView_Databases = new System.Windows.Forms.DataGridView();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.comboBox_Authentication = new System.Windows.Forms.ComboBox();
            this.label_Auth = new System.Windows.Forms.Label();
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.label_Server = new System.Windows.Forms.Label();
            this.dataGridView_tables = new System.Windows.Forms.DataGridView();
            this.button_cdctable = new System.Windows.Forms.Button();
            this.groupBox_cdctableoption = new System.Windows.Forms.GroupBox();
            this.textBox_filegroupname = new System.Windows.Forms.TextBox();
            this.label_filegroup_name = new System.Windows.Forms.Label();
            this.textBox_capturedcollist = new System.Windows.Forms.TextBox();
            this.label_captured_column_list = new System.Windows.Forms.Label();
            this.textBox_indexname = new System.Windows.Forms.TextBox();
            this.label_indexname = new System.Windows.Forms.Label();
            this.checkBox_netchanges = new System.Windows.Forms.CheckBox();
            this.textBox_captureinstance = new System.Windows.Forms.TextBox();
            this.label_captureinstance = new System.Windows.Forms.Label();
            this.textBox_rolename = new System.Windows.Forms.TextBox();
            this.label_rolename = new System.Windows.Forms.Label();
            this.checkBox_allowpartitionswitch = new System.Windows.Forms.CheckBox();
            this.button_Disablecdctable = new System.Windows.Forms.Button();
            this.groupBox_SqlCon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Databases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tables)).BeginInit();
            this.groupBox_cdctableoption.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_SqlCon
            // 
            this.groupBox_SqlCon.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox_SqlCon.Controls.Add(this.button_disablecdc);
            this.groupBox_SqlCon.Controls.Add(this.button1);
            this.groupBox_SqlCon.Controls.Add(this.button_selectdb);
            this.groupBox_SqlCon.Controls.Add(this.dataGridView_Databases);
            this.groupBox_SqlCon.Controls.Add(this.button_connect);
            this.groupBox_SqlCon.Controls.Add(this.textBox_password);
            this.groupBox_SqlCon.Controls.Add(this.textBox_User);
            this.groupBox_SqlCon.Controls.Add(this.label_Password);
            this.groupBox_SqlCon.Controls.Add(this.label_user);
            this.groupBox_SqlCon.Controls.Add(this.comboBox_Authentication);
            this.groupBox_SqlCon.Controls.Add(this.label_Auth);
            this.groupBox_SqlCon.Controls.Add(this.textBox_Server);
            this.groupBox_SqlCon.Controls.Add(this.label_Server);
            this.groupBox_SqlCon.Location = new System.Drawing.Point(12, 23);
            this.groupBox_SqlCon.Name = "groupBox_SqlCon";
            this.groupBox_SqlCon.Size = new System.Drawing.Size(334, 432);
            this.groupBox_SqlCon.TabIndex = 0;
            this.groupBox_SqlCon.TabStop = false;
            this.groupBox_SqlCon.Text = "Connect To Server";
            // 
            // button_disablecdc
            // 
            this.button_disablecdc.Location = new System.Drawing.Point(130, 403);
            this.button_disablecdc.Name = "button_disablecdc";
            this.button_disablecdc.Size = new System.Drawing.Size(75, 23);
            this.button_disablecdc.TabIndex = 12;
            this.button_disablecdc.Text = "Disable CDC";
            this.button_disablecdc.UseVisualStyleBackColor = true;
            this.button_disablecdc.Click += new System.EventHandler(this.button_disablecdc_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(236, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Get Tables";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_selectdb
            // 
            this.button_selectdb.Location = new System.Drawing.Point(18, 403);
            this.button_selectdb.Name = "button_selectdb";
            this.button_selectdb.Size = new System.Drawing.Size(82, 23);
            this.button_selectdb.TabIndex = 10;
            this.button_selectdb.Text = "Enable CDC";
            this.button_selectdb.UseVisualStyleBackColor = true;
            this.button_selectdb.Click += new System.EventHandler(this.button_selectdb_Click);
            // 
            // dataGridView_Databases
            // 
            this.dataGridView_Databases.AllowUserToAddRows = false;
            this.dataGridView_Databases.AllowUserToDeleteRows = false;
            this.dataGridView_Databases.AllowUserToOrderColumns = true;
            this.dataGridView_Databases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Databases.Location = new System.Drawing.Point(18, 169);
            this.dataGridView_Databases.Name = "dataGridView_Databases";
            this.dataGridView_Databases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Databases.Size = new System.Drawing.Size(293, 221);
            this.dataGridView_Databases.TabIndex = 9;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(18, 140);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(94, 23);
            this.button_connect.TabIndex = 8;
            this.button_connect.Text = "Get Databases";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(105, 113);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(100, 20);
            this.textBox_password.TabIndex = 7;
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(105, 87);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(100, 20);
            this.textBox_User.TabIndex = 6;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(25, 120);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Password";
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(25, 90);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(29, 13);
            this.label_user.TabIndex = 4;
            this.label_user.Text = "User";
            // 
            // comboBox_Authentication
            // 
            this.comboBox_Authentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Authentication.FormattingEnabled = true;
            this.comboBox_Authentication.Items.AddRange(new object[] {
            "Windows",
            "SQL"});
            this.comboBox_Authentication.Location = new System.Drawing.Point(105, 60);
            this.comboBox_Authentication.Name = "comboBox_Authentication";
            this.comboBox_Authentication.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Authentication.TabIndex = 3;
            this.comboBox_Authentication.SelectedIndexChanged += new System.EventHandler(this.comboBox_Authentication_SelectedIndexChanged);
            // 
            // label_Auth
            // 
            this.label_Auth.AutoSize = true;
            this.label_Auth.Location = new System.Drawing.Point(25, 63);
            this.label_Auth.Name = "label_Auth";
            this.label_Auth.Size = new System.Drawing.Size(75, 13);
            this.label_Auth.TabIndex = 2;
            this.label_Auth.Text = "Authentication";
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(105, 34);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(100, 20);
            this.textBox_Server.TabIndex = 1;
            this.textBox_Server.Text = ".\\sqlserver2012";
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Location = new System.Drawing.Point(25, 37);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(38, 13);
            this.label_Server.TabIndex = 0;
            this.label_Server.Text = "Server";
            // 
            // dataGridView_tables
            // 
            this.dataGridView_tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tables.Location = new System.Drawing.Point(352, 35);
            this.dataGridView_tables.Name = "dataGridView_tables";
            this.dataGridView_tables.Size = new System.Drawing.Size(416, 193);
            this.dataGridView_tables.TabIndex = 1;
            // 
            // button_cdctable
            // 
            this.button_cdctable.Location = new System.Drawing.Point(11, 176);
            this.button_cdctable.Name = "button_cdctable";
            this.button_cdctable.Size = new System.Drawing.Size(98, 23);
            this.button_cdctable.TabIndex = 2;
            this.button_cdctable.Text = "Capture Table";
            this.button_cdctable.UseVisualStyleBackColor = true;
            this.button_cdctable.Click += new System.EventHandler(this.button_cdctable_Click);
            // 
            // groupBox_cdctableoption
            // 
            this.groupBox_cdctableoption.Controls.Add(this.button_Disablecdctable);
            this.groupBox_cdctableoption.Controls.Add(this.button_cdctable);
            this.groupBox_cdctableoption.Controls.Add(this.checkBox_allowpartitionswitch);
            this.groupBox_cdctableoption.Controls.Add(this.textBox_filegroupname);
            this.groupBox_cdctableoption.Controls.Add(this.label_filegroup_name);
            this.groupBox_cdctableoption.Controls.Add(this.textBox_capturedcollist);
            this.groupBox_cdctableoption.Controls.Add(this.label_captured_column_list);
            this.groupBox_cdctableoption.Controls.Add(this.textBox_indexname);
            this.groupBox_cdctableoption.Controls.Add(this.label_indexname);
            this.groupBox_cdctableoption.Controls.Add(this.checkBox_netchanges);
            this.groupBox_cdctableoption.Controls.Add(this.textBox_captureinstance);
            this.groupBox_cdctableoption.Controls.Add(this.label_captureinstance);
            this.groupBox_cdctableoption.Controls.Add(this.textBox_rolename);
            this.groupBox_cdctableoption.Controls.Add(this.label_rolename);
            this.groupBox_cdctableoption.Location = new System.Drawing.Point(352, 234);
            this.groupBox_cdctableoption.Name = "groupBox_cdctableoption";
            this.groupBox_cdctableoption.Size = new System.Drawing.Size(416, 221);
            this.groupBox_cdctableoption.TabIndex = 3;
            this.groupBox_cdctableoption.TabStop = false;
            this.groupBox_cdctableoption.Text = "Table CDC Options";
            // 
            // textBox_filegroupname
            // 
            this.textBox_filegroupname.Location = new System.Drawing.Point(118, 132);
            this.textBox_filegroupname.Name = "textBox_filegroupname";
            this.textBox_filegroupname.Size = new System.Drawing.Size(100, 20);
            this.textBox_filegroupname.TabIndex = 10;
            // 
            // label_filegroup_name
            // 
            this.label_filegroup_name.AutoSize = true;
            this.label_filegroup_name.Location = new System.Drawing.Point(33, 139);
            this.label_filegroup_name.Name = "label_filegroup_name";
            this.label_filegroup_name.Size = new System.Drawing.Size(76, 13);
            this.label_filegroup_name.TabIndex = 9;
            this.label_filegroup_name.Text = "filegroup name";
            // 
            // textBox_capturedcollist
            // 
            this.textBox_capturedcollist.Location = new System.Drawing.Point(118, 106);
            this.textBox_capturedcollist.Name = "textBox_capturedcollist";
            this.textBox_capturedcollist.Size = new System.Drawing.Size(100, 20);
            this.textBox_capturedcollist.TabIndex = 8;
            // 
            // label_captured_column_list
            // 
            this.label_captured_column_list.AutoSize = true;
            this.label_captured_column_list.Location = new System.Drawing.Point(8, 113);
            this.label_captured_column_list.Name = "label_captured_column_list";
            this.label_captured_column_list.Size = new System.Drawing.Size(101, 13);
            this.label_captured_column_list.TabIndex = 7;
            this.label_captured_column_list.Text = "captured column list";
            // 
            // textBox_indexname
            // 
            this.textBox_indexname.Location = new System.Drawing.Point(118, 80);
            this.textBox_indexname.Name = "textBox_indexname";
            this.textBox_indexname.Size = new System.Drawing.Size(100, 20);
            this.textBox_indexname.TabIndex = 6;
            // 
            // label_indexname
            // 
            this.label_indexname.AutoSize = true;
            this.label_indexname.Location = new System.Drawing.Point(45, 83);
            this.label_indexname.Name = "label_indexname";
            this.label_indexname.Size = new System.Drawing.Size(64, 13);
            this.label_indexname.TabIndex = 5;
            this.label_indexname.Text = "Index Name";
            // 
            // checkBox_netchanges
            // 
            this.checkBox_netchanges.AutoSize = true;
            this.checkBox_netchanges.Location = new System.Drawing.Point(251, 27);
            this.checkBox_netchanges.Name = "checkBox_netchanges";
            this.checkBox_netchanges.Size = new System.Drawing.Size(128, 17);
            this.checkBox_netchanges.TabIndex = 4;
            this.checkBox_netchanges.Text = "Support Net Changes";
            this.checkBox_netchanges.UseVisualStyleBackColor = true;
            // 
            // textBox_captureinstance
            // 
            this.textBox_captureinstance.Location = new System.Drawing.Point(118, 50);
            this.textBox_captureinstance.Name = "textBox_captureinstance";
            this.textBox_captureinstance.Size = new System.Drawing.Size(100, 20);
            this.textBox_captureinstance.TabIndex = 3;
            // 
            // label_captureinstance
            // 
            this.label_captureinstance.AutoSize = true;
            this.label_captureinstance.Location = new System.Drawing.Point(21, 57);
            this.label_captureinstance.Name = "label_captureinstance";
            this.label_captureinstance.Size = new System.Drawing.Size(88, 13);
            this.label_captureinstance.TabIndex = 2;
            this.label_captureinstance.Text = "Capture Instance";
            // 
            // textBox_rolename
            // 
            this.textBox_rolename.Location = new System.Drawing.Point(118, 24);
            this.textBox_rolename.Name = "textBox_rolename";
            this.textBox_rolename.Size = new System.Drawing.Size(100, 20);
            this.textBox_rolename.TabIndex = 1;
            // 
            // label_rolename
            // 
            this.label_rolename.AutoSize = true;
            this.label_rolename.Location = new System.Drawing.Point(45, 27);
            this.label_rolename.Name = "label_rolename";
            this.label_rolename.Size = new System.Drawing.Size(60, 13);
            this.label_rolename.TabIndex = 0;
            this.label_rolename.Text = "Role Name";
            // 
            // checkBox_allowpartitionswitch
            // 
            this.checkBox_allowpartitionswitch.AutoSize = true;
            this.checkBox_allowpartitionswitch.Location = new System.Drawing.Point(251, 57);
            this.checkBox_allowpartitionswitch.Name = "checkBox_allowpartitionswitch";
            this.checkBox_allowpartitionswitch.Size = new System.Drawing.Size(127, 17);
            this.checkBox_allowpartitionswitch.TabIndex = 11;
            this.checkBox_allowpartitionswitch.Text = "Allow Partition Switch";
            this.checkBox_allowpartitionswitch.UseVisualStyleBackColor = true;
            // 
            // button_Disablecdctable
            // 
            this.button_Disablecdctable.Location = new System.Drawing.Point(118, 176);
            this.button_Disablecdctable.Name = "button_Disablecdctable";
            this.button_Disablecdctable.Size = new System.Drawing.Size(75, 23);
            this.button_Disablecdctable.TabIndex = 12;
            this.button_Disablecdctable.Text = "Disable CDC";
            this.button_Disablecdctable.UseVisualStyleBackColor = true;
            this.button_Disablecdctable.Click += new System.EventHandler(this.button_Disablecdctable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 602);
            this.Controls.Add(this.groupBox_cdctableoption);
            this.Controls.Add(this.dataGridView_tables);
            this.Controls.Add(this.groupBox_SqlCon);
            this.Name = "Form1";
            this.Text = "SQLCDCApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_SqlCon.ResumeLayout(false);
            this.groupBox_SqlCon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Databases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tables)).EndInit();
            this.groupBox_cdctableoption.ResumeLayout(false);
            this.groupBox_cdctableoption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_SqlCon;
        private System.Windows.Forms.ComboBox comboBox_Authentication;
        private System.Windows.Forms.Label label_Auth;
        private System.Windows.Forms.TextBox textBox_Server;
        private System.Windows.Forms.Label label_Server;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.DataGridView dataGridView_Databases;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_selectdb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_disablecdc;
        private System.Windows.Forms.DataGridView dataGridView_tables;
        private System.Windows.Forms.Button button_cdctable;
        private System.Windows.Forms.GroupBox groupBox_cdctableoption;
        private System.Windows.Forms.TextBox textBox_filegroupname;
        private System.Windows.Forms.Label label_filegroup_name;
        private System.Windows.Forms.TextBox textBox_capturedcollist;
        private System.Windows.Forms.Label label_captured_column_list;
        private System.Windows.Forms.TextBox textBox_indexname;
        private System.Windows.Forms.Label label_indexname;
        private System.Windows.Forms.CheckBox checkBox_netchanges;
        private System.Windows.Forms.TextBox textBox_captureinstance;
        private System.Windows.Forms.Label label_captureinstance;
        private System.Windows.Forms.TextBox textBox_rolename;
        private System.Windows.Forms.Label label_rolename;
        private System.Windows.Forms.CheckBox checkBox_allowpartitionswitch;
        private System.Windows.Forms.Button button_Disablecdctable;

    }
}

