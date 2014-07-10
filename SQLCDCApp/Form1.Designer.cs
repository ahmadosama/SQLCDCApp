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
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.comboBox_Authentication = new System.Windows.Forms.ComboBox();
            this.label_Auth = new System.Windows.Forms.Label();
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.label_Server = new System.Windows.Forms.Label();
            this.button_disablecdc = new System.Windows.Forms.Button();
            this.button_getables = new System.Windows.Forms.Button();
            this.button_EnableCDCDB = new System.Windows.Forms.Button();
            this.dataGridView_Databases = new System.Windows.Forms.DataGridView();
            this.dataGridView_tables = new System.Windows.Forms.DataGridView();
            this.button_enabletablecdc = new System.Windows.Forms.Button();
            this.groupBox_cdctableoption = new System.Windows.Forms.GroupBox();
            this.button_getchangeddata = new System.Windows.Forms.Button();
            this.button_Disablecdctable = new System.Windows.Forms.Button();
            this.checkBox_allowpartitionswitch = new System.Windows.Forms.CheckBox();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_searchdb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_databasecount = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Searchdbtables = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Searchtb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_tablecount = new System.Windows.Forms.TextBox();
            this.groupBox_SqlCon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Databases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tables)).BeginInit();
            this.groupBox_cdctableoption.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_SqlCon
            // 
            this.groupBox_SqlCon.BackColor = System.Drawing.SystemColors.ButtonFace;
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
            this.groupBox_SqlCon.Size = new System.Drawing.Size(402, 134);
            this.groupBox_SqlCon.TabIndex = 0;
            this.groupBox_SqlCon.TabStop = false;
            this.groupBox_SqlCon.Text = "Connect To Server";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(9, 91);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(94, 23);
            this.button_connect.TabIndex = 8;
            this.button_connect.Text = "Get Databases";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(258, 63);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(100, 20);
            this.textBox_password.TabIndex = 7;
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(258, 30);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(100, 20);
            this.textBox_User.TabIndex = 6;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(199, 66);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Password";
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(223, 30);
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
            this.comboBox_Authentication.Location = new System.Drawing.Point(82, 55);
            this.comboBox_Authentication.Name = "comboBox_Authentication";
            this.comboBox_Authentication.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Authentication.TabIndex = 3;
            this.comboBox_Authentication.SelectedIndexChanged += new System.EventHandler(this.comboBox_Authentication_SelectedIndexChanged);
            // 
            // label_Auth
            // 
            this.label_Auth.AutoSize = true;
            this.label_Auth.Location = new System.Drawing.Point(6, 63);
            this.label_Auth.Name = "label_Auth";
            this.label_Auth.Size = new System.Drawing.Size(75, 13);
            this.label_Auth.TabIndex = 2;
            this.label_Auth.Text = "Authentication";
            // 
            // textBox_Server
            // 
            this.textBox_Server.Location = new System.Drawing.Point(82, 26);
            this.textBox_Server.Name = "textBox_Server";
            this.textBox_Server.Size = new System.Drawing.Size(100, 20);
            this.textBox_Server.TabIndex = 1;
            this.textBox_Server.Text = ".\\sql2014";
            // 
            // label_Server
            // 
            this.label_Server.AutoSize = true;
            this.label_Server.Location = new System.Drawing.Point(6, 33);
            this.label_Server.Name = "label_Server";
            this.label_Server.Size = new System.Drawing.Size(38, 13);
            this.label_Server.TabIndex = 0;
            this.label_Server.Text = "Server";
            // 
            // button_disablecdc
            // 
            this.button_disablecdc.Enabled = false;
            this.button_disablecdc.Location = new System.Drawing.Point(148, 296);
            this.button_disablecdc.Name = "button_disablecdc";
            this.button_disablecdc.Size = new System.Drawing.Size(75, 23);
            this.button_disablecdc.TabIndex = 12;
            this.button_disablecdc.Text = "Disable CDC";
            this.button_disablecdc.UseVisualStyleBackColor = true;
            this.button_disablecdc.Click += new System.EventHandler(this.button_disablecdc_Click);
            // 
            // button_getables
            // 
            this.button_getables.Enabled = false;
            this.button_getables.Location = new System.Drawing.Point(281, 296);
            this.button_getables.Name = "button_getables";
            this.button_getables.Size = new System.Drawing.Size(75, 23);
            this.button_getables.TabIndex = 11;
            this.button_getables.Text = "Get Tables";
            this.button_getables.UseVisualStyleBackColor = true;
            this.button_getables.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_EnableCDCDB
            // 
            this.button_EnableCDCDB.Enabled = false;
            this.button_EnableCDCDB.Location = new System.Drawing.Point(18, 296);
            this.button_EnableCDCDB.Name = "button_EnableCDCDB";
            this.button_EnableCDCDB.Size = new System.Drawing.Size(82, 23);
            this.button_EnableCDCDB.TabIndex = 10;
            this.button_EnableCDCDB.Text = "Enable CDC";
            this.button_EnableCDCDB.UseVisualStyleBackColor = true;
            this.button_EnableCDCDB.Click += new System.EventHandler(this.button_selectdb_Click);
            // 
            // dataGridView_Databases
            // 
            this.dataGridView_Databases.AllowUserToAddRows = false;
            this.dataGridView_Databases.AllowUserToDeleteRows = false;
            this.dataGridView_Databases.AllowUserToOrderColumns = true;
            this.dataGridView_Databases.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_Databases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Databases.Location = new System.Drawing.Point(18, 45);
            this.dataGridView_Databases.Name = "dataGridView_Databases";
            this.dataGridView_Databases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Databases.Size = new System.Drawing.Size(338, 221);
            this.dataGridView_Databases.TabIndex = 9;
            this.dataGridView_Databases.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Databases_ColumnHeaderMouseClick);
            this.dataGridView_Databases.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_Databases_DataBindingComplete);
            this.dataGridView_Databases.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_Databases_RowsAdded);
            // 
            // dataGridView_tables
            // 
            this.dataGridView_tables.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_tables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tables.Location = new System.Drawing.Point(28, 48);
            this.dataGridView_tables.Name = "dataGridView_tables";
            this.dataGridView_tables.Size = new System.Drawing.Size(469, 193);
            this.dataGridView_tables.TabIndex = 1;
            this.dataGridView_tables.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_tables_ColumnHeaderMouseClick);
            this.dataGridView_tables.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_tables_DataBindingComplete);
            this.dataGridView_tables.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_tables_RowsAdded);
            // 
            // button_enabletablecdc
            // 
            this.button_enabletablecdc.Enabled = false;
            this.button_enabletablecdc.Location = new System.Drawing.Point(11, 204);
            this.button_enabletablecdc.Name = "button_enabletablecdc";
            this.button_enabletablecdc.Size = new System.Drawing.Size(98, 23);
            this.button_enabletablecdc.TabIndex = 2;
            this.button_enabletablecdc.Text = "Capture Table";
            this.button_enabletablecdc.UseVisualStyleBackColor = true;
            this.button_enabletablecdc.Click += new System.EventHandler(this.button_cdctable_Click);
            // 
            // groupBox_cdctableoption
            // 
            this.groupBox_cdctableoption.Controls.Add(this.button_getchangeddata);
            this.groupBox_cdctableoption.Controls.Add(this.button_Disablecdctable);
            this.groupBox_cdctableoption.Controls.Add(this.button_enabletablecdc);
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
            this.groupBox_cdctableoption.Location = new System.Drawing.Point(28, 266);
            this.groupBox_cdctableoption.Name = "groupBox_cdctableoption";
            this.groupBox_cdctableoption.Size = new System.Drawing.Size(469, 233);
            this.groupBox_cdctableoption.TabIndex = 3;
            this.groupBox_cdctableoption.TabStop = false;
            this.groupBox_cdctableoption.Text = "Table CDC Options";
            // 
            // button_getchangeddata
            // 
            this.button_getchangeddata.Enabled = false;
            this.button_getchangeddata.Location = new System.Drawing.Point(209, 204);
            this.button_getchangeddata.Name = "button_getchangeddata";
            this.button_getchangeddata.Size = new System.Drawing.Size(111, 23);
            this.button_getchangeddata.TabIndex = 13;
            this.button_getchangeddata.Text = "Get Changed Data";
            this.button_getchangeddata.UseVisualStyleBackColor = true;
            this.button_getchangeddata.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_Disablecdctable
            // 
            this.button_Disablecdctable.Enabled = false;
            this.button_Disablecdctable.Location = new System.Drawing.Point(118, 204);
            this.button_Disablecdctable.Name = "button_Disablecdctable";
            this.button_Disablecdctable.Size = new System.Drawing.Size(75, 23);
            this.button_Disablecdctable.TabIndex = 12;
            this.button_Disablecdctable.Text = "Disable CDC";
            this.button_Disablecdctable.UseVisualStyleBackColor = true;
            this.button_Disablecdctable.Click += new System.EventHandler(this.button_Disablecdctable_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_searchdb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_databasecount);
            this.groupBox1.Controls.Add(this.dataGridView_Databases);
            this.groupBox1.Controls.Add(this.button_disablecdc);
            this.groupBox1.Controls.Add(this.button_getables);
            this.groupBox1.Controls.Add(this.button_EnableCDCDB);
            this.groupBox1.Location = new System.Drawing.Point(12, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 348);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Databases";
            // 
            // textBox_searchdb
            // 
            this.textBox_searchdb.Enabled = false;
            this.textBox_searchdb.Location = new System.Drawing.Point(106, 19);
            this.textBox_searchdb.Name = "textBox_searchdb";
            this.textBox_searchdb.Size = new System.Drawing.Size(100, 20);
            this.textBox_searchdb.TabIndex = 15;
            this.textBox_searchdb.TextChanged += new System.EventHandler(this.textBox_searchdb_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search Database";
            // 
            // textBox_databasecount
            // 
            this.textBox_databasecount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_databasecount.Location = new System.Drawing.Point(18, 276);
            this.textBox_databasecount.Name = "textBox_databasecount";
            this.textBox_databasecount.ReadOnly = true;
            this.textBox_databasecount.Size = new System.Drawing.Size(188, 13);
            this.textBox_databasecount.TabIndex = 13;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Searchdbtables);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox_Searchtb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_tablecount);
            this.groupBox2.Controls.Add(this.groupBox_cdctableoption);
            this.groupBox2.Controls.Add(this.dataGridView_tables);
            this.groupBox2.Location = new System.Drawing.Point(420, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 510);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tables";
            // 
            // textBox_Searchdbtables
            // 
            this.textBox_Searchdbtables.Enabled = false;
            this.textBox_Searchdbtables.Location = new System.Drawing.Point(116, 26);
            this.textBox_Searchdbtables.Name = "textBox_Searchdbtables";
            this.textBox_Searchdbtables.Size = new System.Drawing.Size(100, 20);
            this.textBox_Searchdbtables.TabIndex = 17;
            this.textBox_Searchdbtables.TextChanged += new System.EventHandler(this.textBox_Searchdbtables_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Search Database";
            // 
            // textBox_Searchtb
            // 
            this.textBox_Searchtb.Enabled = false;
            this.textBox_Searchtb.Location = new System.Drawing.Point(311, 26);
            this.textBox_Searchtb.Name = "textBox_Searchtb";
            this.textBox_Searchtb.Size = new System.Drawing.Size(100, 20);
            this.textBox_Searchtb.TabIndex = 17;
            this.textBox_Searchtb.TextChanged += new System.EventHandler(this.textBox_Searchtb_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Search Table";
            // 
            // textBox_tablecount
            // 
            this.textBox_tablecount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_tablecount.Location = new System.Drawing.Point(28, 247);
            this.textBox_tablecount.Name = "textBox_tablecount";
            this.textBox_tablecount.ReadOnly = true;
            this.textBox_tablecount.Size = new System.Drawing.Size(188, 13);
            this.textBox_tablecount.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_SqlCon);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SQLCDCApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_SqlCon.ResumeLayout(false);
            this.groupBox_SqlCon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Databases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tables)).EndInit();
            this.groupBox_cdctableoption.ResumeLayout(false);
            this.groupBox_cdctableoption.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button button_EnableCDCDB;
        private System.Windows.Forms.Button button_getables;
        private System.Windows.Forms.Button button_disablecdc;
        private System.Windows.Forms.DataGridView dataGridView_tables;
        private System.Windows.Forms.Button button_enabletablecdc;
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
        private System.Windows.Forms.Button button_getchangeddata;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_databasecount;
        private System.Windows.Forms.TextBox textBox_tablecount;
        private System.Windows.Forms.TextBox textBox_searchdb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Searchtb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Searchdbtables;
        private System.Windows.Forms.Label label3;

    }
}

