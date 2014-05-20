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

      
        /// <summary>
        /// Connect to SQL Server
        /// populate listbox_databases with databases
        /// highlight cdc enabled databases
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_connect_Click(object sender, EventArgs e)
        {
            try
            {
                fn_ListDatabases();
            }
            catch(Exception  ex)
            {
                MessageBox.Show(ex.Message.ToString(), "SQLCDCAPP Error");
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

        public void fn_ListDatabases()
        {
            
            SQLCDCApp obj = new SQLCDCApp();
            List<SQLCDCApp> _listdatabases = new List<SQLCDCApp>();

            Settings1.Default.Server = textBox_Server.Text;
            Settings1.Default.Password = textBox_password.Text;
            Settings1.Default.User = textBox_User.Text;
            Settings1.Default.AuthenticationType = comboBox_Authentication.Text;

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

                _listdatabases = obj.fn_GetDatabases();

                dataGridView_Databases.DataSource = _listdatabases;
                if (dataGridView_Databases.ColumnCount < 3)
                {
                    DataGridViewCheckBoxColumn cb = new DataGridViewCheckBoxColumn();
                    cb.Frozen = true;

                    cb.Name = "Select";
                    cb.Width = 40;

                    dataGridView_Databases.Columns.Insert(0, cb);
                    cb.TrueValue = 1;
                    cb.FalseValue = 0;
                }
                
                dataGridView_Databases.Columns[1].ReadOnly = true;
                dataGridView_Databases.Columns[2].ReadOnly = true;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void button_selectdb_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(fn_ConfigureCDC(true).ToString());
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "SQLCDCAPP Error");
            }
            
        }

        private string fn_ConfigureCDC(bool Enable)
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

               
                string msgoutput,returnmsg;
                bool output = false;
                if (Enable)
                {
                    returnmsg = "CDC Enabled on selected Databases!!!";
                    foreach (DataGridViewRow dgvr in rows_with_checked_column)
                    {

                        if (dgvr.Cells[2].Value.ToString() == "False")
                        {
                            lstdbcdc.Add(dgvr.Cells[1].Value.ToString());

                        }
                    }
                    msgoutput = MessageBox.Show("Enable CDC on selected databases?", "SQLCDCAPP Info", MessageBoxButtons.YesNo).ToString();

                    if (msgoutput == "Yes")
                    {
                        output = obj.fn_ConfigureCDC(lstdbcdc, true);
                    }
                }
                else
                {
                    returnmsg = "CDC Disabled on selected Databases!!!";
                    foreach (DataGridViewRow dgvr in rows_with_checked_column)
                    {

                        if (dgvr.Cells[2].Value.ToString() == "True")
                        {
                            lstdbcdc.Add(dgvr.Cells[1].Value.ToString());

                        }
                    }
                    msgoutput = MessageBox.Show("Disable CDC on selected databases?", "SQLCDCAPP Info", MessageBoxButtons.YesNo).ToString();

                    if (msgoutput == "Yes")
                    {
                        output = obj.fn_ConfigureCDC(lstdbcdc, false);
                    }
                }

                if(output==true)
                {
                    fn_ListDatabases();
                }

                return returnmsg;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
   
        }
        private void button_disablecdc_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(fn_ConfigureCDC(false).ToString());
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),"SQLCDCAPP Error");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                fn_ListTables();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "SQLCDCAPP Error");
            }
        }
        
        private void fn_ListTables()
        {
            List<Tables> tablelist = new List<Tables>();
            SQLCDCApp obj = new SQLCDCApp();
            List<string> dblist = new List<string>();
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView_Databases.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    rows_with_checked_column.Add(row);
                }
            }

            foreach (DataGridViewRow dgvr in rows_with_checked_column)
            {

                if (dgvr.Cells[2].Value.ToString() == "True")
                {
                    dblist.Add(dgvr.Cells[1].Value.ToString());

                }
            }

            tablelist = obj.fn_GetTables(dblist);

            dataGridView_tables.DataSource = tablelist;

            if (dataGridView_tables.ColumnCount < 5)
            {
                DataGridViewCheckBoxColumn cb = new DataGridViewCheckBoxColumn();
                cb.Frozen = true;

                cb.Name = "Select";
                cb.Width = 40;

                dataGridView_tables.Columns.Insert(0, cb);
                cb.TrueValue = 1;
                cb.FalseValue = 0;
            }

        }

        private void button_cdctable_Click(object sender, EventArgs e)
        {
            SQLCDCApp scdc = new SQLCDCApp();
            List<CDC> cdclist = new List<CDC>();

            /*if(string.IsNullOrEmpty(textBox_rolename.Text))
            {
                MessageBox.Show("Role Name can't be blank", "Information");
                return;
            }*/

           // CDC cdcobj = new CDC();

            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in dataGridView_tables.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    rows_with_checked_column.Add(row);
                }
            }

            foreach (DataGridViewRow dgvr in rows_with_checked_column)
            {
                CDC cdcobj = new CDC();
              
               // if(dgvr.Cells[4].Value.ToString()=="False")
              //  {
                    cdcobj.Databasename = dgvr.Cells[1].Value.ToString().Trim();
                    cdcobj.source_schema = dgvr.Cells[2].Value.ToString().Trim();
                    cdcobj.source_name = dgvr.Cells[3].Value.ToString().Trim();
                    cdcobj.role_name = textBox_rolename.Text.Trim(); ;
                    cdcobj.capture_instance = textBox_captureinstance.Text.Trim();
                    cdcobj.index_name = textBox_indexname.Text.Trim();
                    cdcobj.captured_column_list = textBox_capturedcollist.Text.Trim();
                    cdcobj.filegroup_name = textBox_filegroupname.Text.Trim();
                    if(checkBox_netchanges.Checked==true)
                    {
                        cdcobj.supports_net_changes=1;
                    }
                    else
                    {
                        cdcobj.supports_net_changes = 0;
                    }
                    if(checkBox_allowpartitionswitch.Checked==true)
                    {
                        cdcobj.allow_partition_switch = 1;
                    }
                    else
                    {
                        cdcobj.allow_partition_switch = 0;
                    }

                    cdclist.Add(cdcobj);
               // }
            }

            MessageBox.Show(scdc.fn_EnableCDCOnTable(cdclist,true).ToString(),"SQLCDCAPP Information");
            fn_ListTables();
        }

        private void button_Disablecdctable_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            SQLCDCApp scdc = new SQLCDCApp();
            List<CDC> cdclist = new List<CDC>();

            foreach (DataGridViewRow row in dataGridView_tables.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    rows_with_checked_column.Add(row);
                }
            }

            foreach (DataGridViewRow dgvr in rows_with_checked_column)
            {
                CDC cdcobj = new CDC();

                if (dgvr.Cells[4].Value.ToString() == "True")
                {
                    cdcobj.Databasename = dgvr.Cells[1].Value.ToString().Trim();
                    cdcobj.source_schema = dgvr.Cells[2].Value.ToString().Trim();
                    cdcobj.source_name = dgvr.Cells[3].Value.ToString().Trim();
                    cdcobj.capture_instance = textBox_captureinstance.Text.Trim();
                    cdclist.Add(cdcobj);
                }
            }

            MessageBox.Show(scdc.fn_EnableCDCOnTable(cdclist, false).ToString(), "SQLCDCAPP Information");
            fn_ListTables();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
