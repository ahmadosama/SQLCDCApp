using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLCDCApp
{
    public partial class Form1 : Form
    {
        DataTable dtdblist = new DataTable();
        DataTable dttablelist = new DataTable();
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
                Cursor.Current = Cursors.WaitCursor;
                // check sqlagent status. Exit if not running.
                

                if(!fn_ListDatabases())
                {
                    Cursor.Current = Cursors.Arrow;
                    return;
                }
                
                Cursor.Current = Cursors.Arrow;
                button_EnableCDCDB.Enabled = true;
                button_disablecdc.Enabled = true;
                button_getables.Enabled = true;
                textBox_searchdb.Text = "";
            }
            catch(Exception  ex)
            {
                
                MessageBox.Show(ex.Message.ToString(), "SQLCDCAPP Error !!!");
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

        public bool fn_ListDatabases()
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
                    MessageBox.Show("Server name can't be blank", "SQLCDCAPP Error !!!");
                }

                if (comboBox_Authentication.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(textBox_User.Text))
                    {
                        MessageBox.Show("User can't be blank", "SQLCDCAPP Error !!!");
                    }
                    if (string.IsNullOrEmpty(textBox_password.Text))
                    {
                        MessageBox.Show("Password can't be blank", "SQLCDCAPP Error !!!");
                    }
                }

                if (!obj.fn_SQLAgentStatusCheck())
                {
                    MessageBox.Show("SQL Agent is not running.Please start SQL Agent to use application", "SQLCDCApp Info!!!");
                    return false;
                }


                 dtdblist = obj.fn_GetDatabases();
                //BindingList<SQLCDCApp> bindlist = new BindingList<SQLCDCApp>(_listdatabases);



                dataGridView_Databases.DataSource = dtdblist;

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
                textBox_databasecount.Text = " Total records: " + dtdblist.Rows.Count.ToString();
                return true;
            }

            catch (Exception)
            {
                throw;
            }
        }
        private void button_selectdb_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string returnmsg = fn_ConfigureCDC(true);
                if(!string.IsNullOrEmpty(returnmsg))
                {
                    MessageBox.Show(returnmsg,"SQLCDCApp Info !!!");
                }
                Cursor.Current = Cursors.Arrow;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "SQLCDCAPP Error !!!");
            }
            
        }

        private string fn_ConfigureCDC(bool Enable)
        {
             // get checked rows
            List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();
            List<string> lstdbcdc = new List<string>();
            SQLCDCApp obj = new SQLCDCApp();
            string msgoutput="", returnmsg="";
            try
            {

                foreach (DataGridViewRow row in dataGridView_Databases.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        rows_with_checked_column.Add(row);
                    }
                }

                if (rows_with_checked_column.Count == 0)
                {
                    returnmsg = "Please select a database.";
                    return returnmsg;
                }



               
                bool output = false;
                if (Enable)
                {
                    
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
                        returnmsg = "CDC Enabled on selected Databases!!!";

                    }
                }
                else
                {
                    
                    foreach (DataGridViewRow dgvr in rows_with_checked_column)
                    {

                        if (dgvr.Cells[2].Value.ToString() == "True")
                        {
                            lstdbcdc.Add(dgvr.Cells[1].Value.ToString());

                        }
                    }
                    msgoutput = MessageBox.Show("Disable CDC on selected databases?", "SQLCDCAPP Info !!!", MessageBoxButtons.YesNo).ToString();

                    if (msgoutput == "Yes")
                    {
                        output = obj.fn_ConfigureCDC(lstdbcdc, false);
                        returnmsg = "CDC Disabled on selected Databases!!!";
                    }
                }

                if(output==true)
                {
                   
                    fn_ListDatabases();
                }

                return returnmsg;
                
            }
            catch (Exception)
            {
                throw;
            }
   
        }
        private void button_disablecdc_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string returnmsg = fn_ConfigureCDC(false);
                if (!string.IsNullOrEmpty(returnmsg))
                {
                    MessageBox.Show(returnmsg, "SQLCDCApp Info !!!");
                }
                Cursor.Current = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "SQLCDCAPP Error !!!");
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                fn_ListTables();
                button_enabletablecdc.Enabled = true;
                button_Disablecdctable.Enabled = true;
                button_getchangeddata.Enabled = true;
                Cursor.Current = Cursors.Arrow;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "SQLCDCAPP Error !!!");
            }
        }
        
        private void fn_ListTables()
        {
            try
            {
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

                DataSet ds = obj.fn_GetTables(dblist);
                //tablelist = obj.fn_GetTables(dblist);
                DataTable dtAll = ds.Tables[0].Copy();
                for (var i = 1; i < ds.Tables.Count; i++)
                {
                    dtAll.Merge(ds.Tables[i]);
                }
                dataGridView_tables.AutoGenerateColumns = true;
                dataGridView_tables.DataSource = dtAll;
                dttablelist = dtAll;

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
                textBox_tablecount.Text = " Total records: " + dtAll.Rows.Count.ToString();
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void button_cdctable_Click(object sender, EventArgs e)
        {
            try
            {
                string msgoutput = MessageBox.Show("Enable CDC on selected table?", "SQLCDCApp Info !!!",MessageBoxButtons.YesNo).ToString();
                if(msgoutput=="No")
                {
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;

                SQLCDCApp scdc = new SQLCDCApp();
                List<CDC> cdclist = new List<CDC>();


                List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in dataGridView_tables.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        rows_with_checked_column.Add(row);
                    }
                }

                if (rows_with_checked_column.Count == 0)
                {
                    MessageBox.Show("Please select a table.", "SQLCDCApp Info !!!");
                    return;
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
                    if (checkBox_netchanges.Checked == true)
                    {
                        cdcobj.supports_net_changes = 1;
                    }
                    if (checkBox_netchanges.Checked == false)
                    {
                        cdcobj.supports_net_changes = 0;
                    }
                    if (checkBox_allowpartitionswitch.Checked == true)
                    {
                        cdcobj.allow_partition_switch = 1;
                    }
                    if (checkBox_allowpartitionswitch.Checked == false)
                    {
                        cdcobj.allow_partition_switch = 0;
                    }

                    cdclist.Add(cdcobj);

                }

                MessageBox.Show(scdc.fn_EnableCDCOnTable(cdclist, true).ToString(), "SQLCDCApp Info !!!");
                fn_ListTables();
                Cursor.Current = Cursors.Arrow;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "SQLCDCApp Error !!!");
            }
        }

        private void button_Disablecdctable_Click(object sender, EventArgs e)
        {
            try
            {
                string msgoutput = MessageBox.Show("Disable CDC on selected table?", "SQLCDCApp Info !!!", MessageBoxButtons.YesNo).ToString();
                if (msgoutput == "No")
                {
                    return;
                }
                
                Cursor.Current = Cursors.WaitCursor;

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

                if (rows_with_checked_column.Count == 0)
                {

                    MessageBox.Show("Please select a table.", "SQLCDCApp Info !!!");
                    return;
                }

                foreach (DataGridViewRow dgvr in rows_with_checked_column)
                {
                    CDC cdcobj = new CDC();

                    if (dgvr.Cells[4].Value.ToString() == "True")
                    {
                        cdcobj.Databasename = dgvr.Cells[1].Value.ToString().Trim();
                        cdcobj.source_schema = dgvr.Cells[2].Value.ToString().Trim();
                        cdcobj.source_name = dgvr.Cells[3].Value.ToString().Trim();
                        //cdcobj.capture_instance = textBox_captureinstance.Text.Trim();
                        cdclist.Add(cdcobj);
                    }
                }

                MessageBox.Show(scdc.fn_EnableCDCOnTable(cdclist, false).ToString(), "SQLCDCApp Info !!!");
                fn_ListTables();
                Cursor.Current = Cursors.Arrow;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "SQLCDCApp Error !!!");
            }
        }

        public List<CDC> fn_getselectedtables()
        {
            try
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

                return cdclist;
            }catch(Exception)
            {
                throw;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                SQLCDCApp scdc = new SQLCDCApp();
                List<DataGridViewRow> rows_with_checked_column = new List<DataGridViewRow>();


                foreach (DataGridViewRow row in dataGridView_tables.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        rows_with_checked_column.Add(row);
                    }
                }

                if (rows_with_checked_column.Count == 0)
                {
                    MessageBox.Show("Please select a table.", "SQLCDCApp Info !!!");
                    return;
                }

                if (rows_with_checked_column.Count > 1)
                {
                    MessageBox.Show("Please select single table only.", "SQLCDCApp Info !!!");
                    return;
                }

                List<CDC> cdclist = new List<CDC>();
                cdclist = fn_getselectedtables();
                List<string> lst = new List<string>();
                lst = scdc.fn_CaptureInstance(cdclist);

                Form nf = new CDCData(lst);
                nf.ShowDialog();
                Cursor.Current = Cursors.Arrow;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "SQLCDCApp Error !!!");
            }
        }

        private void dataGridView_Databases_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            fn_GridSort(dataGridView_Databases, e);
          
        }

        public void fn_GridSort(DataGridView dgv,DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = dgv.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dgv.SortedColumn;
            ListSortDirection direction;

            // If oldColumn is null, then the DataGridView is not sorted. 
            if (oldColumn != null)
            {
                // Sort the same column again, reversing the SortOrder. 
                if (oldColumn == newColumn &&
                    dgv.SortOrder == SortOrder.Ascending)
                {
                    direction = ListSortDirection.Descending;
                }
                else
                {
                    // Sort a new column and remove the old SortGlyph.
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
            {
                direction = ListSortDirection.Ascending;
            }

            // Sort the selected column.
            dgv.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;
        }

        private void dataGridView_Databases_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Put each of the columns into programmatic sort mode. 
            foreach (DataGridViewColumn column in dataGridView_Databases.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void dataGridView_tables_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            fn_GridSort(dataGridView_tables, e);
        }

        private void dataGridView_tables_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView_tables.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void textBox_searchdb_TextChanged(object sender, EventArgs e)
        {
            DataTable filteredtable = new DataTable();
            var filteredresults = dtdblist.AsEnumerable()
                                .Where(r => r.Field<string>("name").Contains(textBox_searchdb.Text));
            if(filteredresults.Any())
            {
                filteredtable = filteredresults.CopyToDataTable();
            }
            dataGridView_Databases.DataSource = filteredtable;
            textBox_databasecount.Text = "Total Records : " + filteredtable.Rows.Count.ToString();
        }

        private void dataGridView_Databases_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            textBox_searchdb.Enabled = true;
        }

        private void textBox_Searchdbtables_TextChanged(object sender, EventArgs e)
        {
            DataTable filteredtable = new DataTable();
            var filteredresults = dttablelist.AsEnumerable()
                                .Where(r => r.Field<string>("Databasename").Contains(textBox_Searchdbtables.Text));
            if (filteredresults.Any())
            {
                filteredtable = filteredresults.CopyToDataTable();
            }
            dataGridView_tables.DataSource = filteredtable;
            textBox_tablecount.Text = "Total Records : " + filteredtable.Rows.Count.ToString();
        }

        private void textBox_Searchtb_TextChanged(object sender, EventArgs e)
        {
            DataTable filteredtable = new DataTable();
            var filteredresults = dttablelist.AsEnumerable()
                                .Where(r => r.Field<string>("name").Contains(textBox_Searchtb.Text));
            if (filteredresults.Any())
            {
                filteredtable = filteredresults.CopyToDataTable();
            }
            dataGridView_tables.DataSource = filteredtable;
            textBox_tablecount.Text = "Total Records : " + filteredtable.Rows.Count.ToString();
        }

        private void dataGridView_tables_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            textBox_Searchdbtables.Enabled = true;
            textBox_Searchtb.Enabled = true;
        }

    }
}
