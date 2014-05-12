using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLCDCApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox_Authentication.SelectedIndex = 0;
            textBox_User.Enabled = false;
            textBox_password.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Connect to SQL Server
        /// populate listbox_databases with databases
        /// highlight cdc enabled databases
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_connect_Click(object sender, EventArgs e)
        {
            SQLCDCApp obj = new SQLCDCApp();
            List<SQLCDCApp> _listdatabases = new List<SQLCDCApp>();

            try
            {
                if (string.IsNullOrEmpty(textBox_Server.Text))
                {
                    MessageBox.Show("Server name can't be blank", "SQLCDCApp Error");
                }

                if (comboBox_Authentication.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(textBox_User.Text))
                    {
                        MessageBox.Show("User can't be blank", "SQLCDCApp Error");
                    }
                    if (string.IsNullOrEmpty(textBox_password.Text))
                    {
                        MessageBox.Show("Password can't be blank", "SQLCDCApp Error");
                    }
                }

                obj.ServerName = textBox_Server.Text;
                obj.UserName = textBox_User.Text;
                obj.Password = textBox_password.Text;
                obj.AuthenticationType = comboBox_Authentication.Text;
                _listdatabases = obj.fn_GetDatabases();

                dataGridView_Databases.DataSource = _listdatabases;

                DataGridViewCheckBoxColumn cb = new DataGridViewCheckBoxColumn();
                cb.Frozen = true;

                cb.Name = "Select";
                cb.Width = 40;

                dataGridView_Databases.Columns.Insert(0, cb);
                cb.TrueValue = 1;
                cb.FalseValue = 0;
                dataGridView_Databases.Columns[1].ReadOnly = true;
                dataGridView_Databases.Columns[2].ReadOnly = true;

            }

            catch (Exception)
            {
                throw;
            }
        }

        private void comboBox_Authentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Authentication.SelectedIndex == 1)
            {
                textBox_User.Enabled = true;
                textBox_password.Enabled = true;
            }
            else if (comboBox_Authentication.SelectedIndex == 0)
            {
                textBox_User.Enabled = false;
                textBox_password.Enabled = false;
            }
        }

        private void button_selectdb_Click(object sender, EventArgs e)
        {
            // get checked rows
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            List<string> lstdbcdc = new List<string>();
            SQLCDCApp obj = new SQLCDCApp();

            try
            {
                foreach (DataGridViewRow row in dataGridView_Databases.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        rows_with_checked_column.Add(row);
                    }
                }

                foreach (DataGridViewRow dgvr in rows_with_checked_column)
                {

                    //MessageBox.Show(dgvr.Cells[1].Value.ToString());
                    //MessageBox.Show(dgvr.Cells[2].Value.ToString());
                    if (dgvr.Cells[2].Value.ToString() == "False")
                    {
                        lstdbcdc.Add(dgvr.Cells[1].Value.ToString());

                    }
                }

                // confirm and enable cdc
                string msgoutput;
                msgoutput = MessageBox.Show("Enable CDC on selected databases", "SQLCDCAPP Info", MessageBoxButtons.YesNo).ToString();
                if (msgoutput == "Yes")
                {
                    obj.fn_EnableCDC(lstdbcdc);
                }

            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
