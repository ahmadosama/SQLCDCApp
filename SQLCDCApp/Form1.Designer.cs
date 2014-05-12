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
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_user = new System.Windows.Forms.Label();
            this.comboBox_Authentication = new System.Windows.Forms.ComboBox();
            this.label_Auth = new System.Windows.Forms.Label();
            this.textBox_Server = new System.Windows.Forms.TextBox();
            this.label_Server = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.dataGridView_Databases = new System.Windows.Forms.DataGridView();
            this.button_selectdb = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_SqlCon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Databases)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_SqlCon
            // 
            this.groupBox_SqlCon.BackColor = System.Drawing.SystemColors.ButtonFace;
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
            this.groupBox_SqlCon.Size = new System.Drawing.Size(278, 432);
            this.groupBox_SqlCon.TabIndex = 0;
            this.groupBox_SqlCon.TabStop = false;
            this.groupBox_SqlCon.Text = "Connect To Server";
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(105, 113);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(100, 20);
            this.textBox_password.TabIndex = 7;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
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
            // dataGridView_Databases
            // 
            this.dataGridView_Databases.AllowUserToAddRows = false;
            this.dataGridView_Databases.AllowUserToDeleteRows = false;
            this.dataGridView_Databases.AllowUserToOrderColumns = true;
            this.dataGridView_Databases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Databases.Location = new System.Drawing.Point(18, 169);
            this.dataGridView_Databases.Name = "dataGridView_Databases";
            this.dataGridView_Databases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Databases.Size = new System.Drawing.Size(227, 221);
            this.dataGridView_Databases.TabIndex = 9;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Get Tables";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 520);
            this.Controls.Add(this.groupBox_SqlCon);
            this.Name = "Form1";
            this.Text = "SQLCDCApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_SqlCon.ResumeLayout(false);
            this.groupBox_SqlCon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Databases)).EndInit();
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

    }
}

