using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Dynamic;
using Scheduler;
namespace SQLCDCApp
{
    public partial class CDCData : Form
    {
        
        public CDCData(List<string> lst)
        {
            InitializeComponent();
            _lst = lst;
        }
        public CDCData(string _tablename)
        {
            InitializeComponent();
            
        }

        DataTable srctable = new DataTable();
        List<string> _lst = new List<string>();
        string Databasename = "",tablename="",desttable="";
        
        private void CDCData_Load(object sender, EventArgs e)
        {
            try
            {
                SQLCDCApp scdc = new SQLCDCApp();
                Databasename = _lst[_lst.Count - 1];
                tablename = _lst[_lst.Count - 2];

                _lst.RemoveAt(_lst.Count - 1);
                _lst.RemoveAt(_lst.Count - 1);

                dateTimePicker_FromDataTime.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
                dateTimePicker_FromDataTime.Format = DateTimePickerFormat.Custom;
                dateTimePicker_ToDateTime.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
                dateTimePicker_ToDateTime.Format = DateTimePickerFormat.Custom;
                comboBox_capturedinstances.DataSource = _lst;
                comboBox_Authentication.Text = comboBox_Authentication.Items[0].ToString();
         
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "SQLCDCApp Error!!!");
            }
        }

        private void button_Getdata_Click(object sender, EventArgs e)
        {
            
            int ChangeDataType = 0;
            
            try
            {
                Cursor.Current = Cursors.WaitCursor;
            if (radioButton_alldata.Checked == false && radioButton_netdata.Checked == false && radioButton_Timewise.Checked == false)
            {
                MessageBox.Show("Please select an option!!!", "SQLCDCApp Info !!!");
                return;
            }

            if (radioButton_alldata.Checked==true)
            {
                ChangeDataType = 1;
                fn_GetChangedData(ChangeDataType);
                return;
            }
            
                if (radioButton_netdata.Checked==true)
                {
                    ChangeDataType = 2;
                    fn_GetChangedData(ChangeDataType);
                    return;
                }

                if (radioButton_Timewise.Checked == true)
                {

                    if (dateTimePicker_FromDataTime.Value > DateTime.Now)
                    {
                        MessageBox.Show("From date time can't be greater than current date.", "SQLCDCApp Info !!!");
                        dateTimePicker_FromDataTime.Focus();
                        return;
                    }
                    if (dateTimePicker_FromDataTime.Value > dateTimePicker_ToDateTime.Value)
                    {
                        MessageBox.Show("From date time can't be greater than to date.", "SQLCDCApp Info !!!");
                        dateTimePicker_FromDataTime.Focus();
                        return;
                    }


                    ChangeDataType = 3;
                    fn_GetChangedData(ChangeDataType);
                    Cursor.Current = Cursors.Arrow;
                    return;
                }
            }catch(Exception ex)
            {
                    MessageBox.Show(ex.Message,"SQLCDCApp Error !!!");
                }
       
       
            
    }   
        

        /// <summary>
        /// Get change data from the table.
        /// </summary>
        /// <param name="ChangeDataType"></param>
        private void fn_GetChangedData(int ChangeDataType)
        {
            
            SQLCDCApp cdcobj = new SQLCDCApp();
            int insertcount=0, deletecount=0, updatecount=0;
           
           try
           {
               DataTable result = new DataTable();
               
              
                   result = cdcobj.fn_GetChangeData(ChangeDataType, Databasename, tablename, 
                       comboBox_capturedinstances.Text, dateTimePicker_FromDataTime.Value, dateTimePicker_ToDateTime.Value);
                   srctable = result;
               
               if(result.Columns.Count==1)
               {
                   groupBox_ExportData.Enabled = false;
                   MessageBox.Show(result.Rows[0][0].ToString(), "SQLCDCApp Info!!!");
                   return;
               }
               groupBox_ExportData.Enabled = true;
                if (result.Columns.Contains("__$start_lsn") == true)
                {
                    result.Columns.Remove("__$start_lsn");
                }
                if (result.Columns.Contains("__$seqval") == true)
                {
                    result.Columns.Remove("__$seqval");
                }
                if (result.Columns.Contains("__$operation") == true)
                {
                    result.Columns.Remove("__$operation");
                }
                if (result.Columns.Contains("__$update_mask") == true)
                {
                    result.Columns.Remove("__$update_mask");
                }

                if (result.Columns.Contains("Operation") == true)
                {
                    MorphBinaryColumns(result);
                    dataGridView_showresults.DataSource = result;
                    textBox_datacount.Text = "Total Records: " + (dataGridView_showresults.Rows.Count - 1).ToString();
                    insertcount = result.AsEnumerable()
                    .Count(row => row.Field<string>("Operation") == "INSERT");
                    deletecount = result.AsEnumerable()
                    .Count(row => row.Field<string>("Operation") == "DELETE");
                    updatecount = result.AsEnumerable()
                    .Count(row => row.Field<string>("Operation") == "UPDATE AFTER" || row.Field<string>("Operation") == "UPDATE BEFORE");
                    textBox_Insertcount.Text = "Total Inserts : " + insertcount.ToString();
                    textBox_Deletecount.Text = "Total Deletes : " + deletecount.ToString();
                    textBox_updatecount.Text = "Total Updates : " + updatecount.ToString();
                }
               
           }
           catch(SqlException)
           {
               throw;
           }
           
           

        }

        /// <summary>
        /// parse binary cols to grid type
        /// </summary>
        /// <param name="table"></param>
        private void MorphBinaryColumns(DataTable table)
        {
            try
            {


                var targetNames = table.Columns.Cast<DataColumn>()
                  .Where(col => col.DataType.Equals(typeof(byte[])))
                  .Select(col => col.ColumnName).ToList();
                foreach (string colName in targetNames)
                {
                    // add new column and put it where the old column was
                    var tmpName = "new";
                    table.Columns.Add(new DataColumn(tmpName, typeof(string)));
                    table.Columns[tmpName].SetOrdinal(table.Columns[colName].Ordinal);

                    // fill in values in new column for every row
                    foreach (DataRow row in table.Rows)
                    {
                        byte[] bt = row[colName] as byte[];

                        if (null != bt && bt.Length > 0)
                        {
                            row[tmpName] = "0x" + string.Join("",
                              ((byte[])row[colName]).Select(b => b.ToString("X2")).ToArray());
                        }
                        else
                        {
                            row[tmpName] = "NULL";
                        }
                    }

                    // cleanup
                    table.Columns.Remove(colName);
                    table.Columns[tmpName].ColumnName = colName;

                }
             }catch(Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// initial sync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_InitialSync_Click(object sender, EventArgs e)
        {
            
            try
            {
                SQLCDCApp obj = new SQLCDCApp();
                
                Cursor.Current = Cursors.WaitCursor;
                    srctable.TableName = tablename.ReplaceFirstOccurrance("_",".");
                    int _recordcount = obj.fn_ExportToDB(srctable, desttable,comboBox_Database.Text.ToString(), "false", 
                        Databasename, comboBox_Database.Text);
                    MessageBox.Show("Number of Records Exported:" + _recordcount.ToString());
            
                Cursor.Current = Cursors.Arrow;
            }catch(Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(),"SQLCDCApp Error !!!");
            }
        }

       
        /// <summary>
        /// export grid data to file
        /// </summary>
        /// <param name="filepath"></param>
        private void fn_ExportGridtoFile(string filepath)
        {

            try
            {
                
                    
                StringBuilder sb = new StringBuilder();
                // Column headers
                string columnsHeader = "";
                for (int i = 0; i < dataGridView_showresults.Columns.Count; i++)
                {
                    columnsHeader += dataGridView_showresults.Columns[i].Name + ",";
                }
                sb.Append(columnsHeader + Environment.NewLine);
                // Go through each cell in the datagridview
                foreach (DataGridViewRow dgvRow in dataGridView_showresults.Rows)
                {
                    // Make sure it's not an empty row.
                    if (!dgvRow.IsNewRow)
                    {
                        for (int c = 0; c < dgvRow.Cells.Count; c++)
                        {
                            // Append the cells data followed by a comma to delimit.

                            sb.Append(dgvRow.Cells[c].Value + ",");
                        }
                        // Add a new line in the text file.
                        sb.Append(Environment.NewLine);
                    }
                }

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filepath, false))
                {
                    // Write the stringbuilder text to the the file.
                    sw.WriteLine(sb.ToString());
                }
                // Confirm to the user it has been completed.
                MessageBox.Show("Data export complete", "SQLCDCApp Info !!!");
             }catch(Exception)
            {
                throw;
            }
        }

   

        private void button_Connect_Click(object sender, EventArgs e)
        {
             SQLCDCApp obj = new SQLCDCApp();
             List<SQLCDCApp> _listdatabases = new List<SQLCDCApp>();

             comboBox_Database.Items.Clear();
             
             try
             {
                 if (string.IsNullOrEmpty(textBox_Server.Text))
                 {
                     MessageBox.Show("Server name can't be blank", "SQLCDCAPP Error !!!");
                     return;
                 }

                 if (comboBox_Authentication.SelectedIndex == 1)
                 {
                     if (string.IsNullOrEmpty(textBox_User.Text))
                     {
                         MessageBox.Show("User can't be blank", "SQLCDCAPP Error !!!");
                         textBox_User.Focus();
                         return;
                     }
                     if (string.IsNullOrEmpty(textBox_password.Text))
                     {
                         MessageBox.Show("Password can't be blank", "SQLCDCAPP Error !!!");
                         textBox_password.Focus();
                         return;
                     }
                 }

                 // save dest connection details
                 Settings1.Default.Destserver = textBox_Server.Text;
                 Settings1.Default.Destuser = textBox_User.Text;
                 Settings1.Default.Destpassword = Crypto.Crypto.Encrypt(textBox_password.Text,true);
                 Settings1.Default.Destauthtype = comboBox_Authentication.Text;

                 DataTable dtdblist = obj.fn_GetDatabases("destination");
                 if(dtdblist.Rows.Count == 0)
                 {
                     MessageBox.Show("No user database is available!!!","SQLCDCApp Info!!!");
                     button_InitialSync.Enabled = false;
                     button_scheduleIDL.Enabled = false;
                     return;
                 }
                 button_InitialSync.Enabled = true;
                 button_scheduleIDL.Enabled = true;
                 
                 foreach(DataRow rw in dtdblist.Rows)
                 {
                     comboBox_Database.Items.Add(rw["name"]);
                 }
                 
           /*     foreach(SQLCDCApp item in _listdatabases)
                {
                    comboBox_Database.Items.Add(item.DatabaseName);
                }
             */   
                 comboBox_Database.Text = comboBox_Database.Items[0].ToString();
                 
             }catch(Exception ex)
             {
                 MessageBox.Show(ex.Message, "SQLCDCApp Error!!!");
             }
           
        }

        private void radioButton_ExportoDatabase_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if(radioButton_ExportoDatabase.Checked==true)
            {
                panel_dbconnection.Enabled = true;
            }
            if(radioButton_ExportoDatabase.Checked==false)
            {
                panel_dbconnection.Enabled = false;
            }
           */
        }

        private void comboBox_Database_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { 
            
            SQLCDCApp obj = new SQLCDCApp();
            List<string> dblist = new List<string>();
            
            comboBox_Tables.Items.Clear();
            dblist.Add(comboBox_Database.Text.ToString());

            DataSet dstables = obj.fn_GetTables(dblist, "Destination");
            DataTable dt = dstables.Tables[0];
            if(dt.Rows.Count==0)
            {
                comboBox_Tables.Items.Insert(0, "Create New");
                
                return;
            }
            foreach(DataRow rw in dt.Rows)
            {
                comboBox_Tables.Items.Add(rw[1] + "." + rw[2]);
                //comboBox_Tables.Items.Add(item.schema + "." + item.name);
            }
            comboBox_Tables.Items.Insert(0, "Create New");
            comboBox_Tables.Text = comboBox_Tables.Items[1].ToString();
              
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void comboBox_Tables_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             
            if(comboBox_Tables.Text=="Create New")
            {
                  
                    TableName tnf = new TableName(tablename.ReplaceFirstOccurrance("_","."),Databasename,comboBox_Database.Text);
                    tnf.ShowDialog();
                    comboBox_Tables.Items.Add(tnf.desttable);
                    comboBox_Tables.Text = tnf.desttable;
                   // createtable = true;

            }
                desttable = comboBox_Tables.Text;
       
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void dataGridView_showresults_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.fn_GridSort(dataGridView_showresults, e);
        }

        private void dataGridView_showresults_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView_showresults.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

        }


        /// <summary>
        /// schedule increment data load 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_scheduleIDL_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            Tables tbl = new Tables(Databasename, tablename.Substring(tablename.IndexOf("_")+1));
            if (!tbl._primary_key_enabled)
            {
                MessageBox.Show("Increment load can be done on tables with primary key constraint.", "SQLCDCApp Info!!!");
                return;
            }
               
            if(string.IsNullOrEmpty(textBox_Server.Text))
            {
                MessageBox.Show("Destination server can't be empty", "SQLCDCApp Info!!!");
                textBox_Server.Focus();
                return;
            }
            if(string.IsNullOrEmpty(comboBox_Database.Text))
            {
                MessageBox.Show("Destination Database can't be empty", "SQLCDCApp Info!!!");
                comboBox_Database.Focus();
                return;
            }
            if (string.IsNullOrEmpty(comboBox_Tables.Text))
            {
                MessageBox.Show("Destination table can't be empty", "SQLCDCApp Info!!!");
                comboBox_Tables.Focus();
                return;
            }

            try
            {
                // make an entry in meta tables
                
            //    obj.fn_Updatemetatables(Settings1.Default.Server.ToString(), textBox_Server.Text, Databasename, comboBox_Database.Text, tablename, desttable, comboBox_capturedinstances.Text, textBox_User.Text, Crypto.Crypto.Encrypt(textBox_password.Text, true));
                
                string _sqljobname = "SQLCDCApp_IDL_" + Databasename + "_" + tablename + "_"+ comboBox_capturedinstances.Text;
                SQLAgentJob _sajob = new SQLAgentJob(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Encrypt(Settings1.Default.Password, true), Settings1.Default.AuthenticationType);
                _sajob.SQLJob(_sqljobname);
                string userid=Settings1.Default.User,password=Crypto.Crypto.Encrypt(Settings1.Default.Password,true);
                Guid _sqljobid = _sajob.SQLJobID;
                SQLCDCApp _obj = new SQLCDCApp();
              
                _obj.fn_Updatemetatables(Settings1.Default.Server.ToString(), textBox_Server.Text, Databasename,
                    comboBox_Database.Text, tablename, desttable, comboBox_capturedinstances.Text, textBox_User.Text,
                    Crypto.Crypto.Encrypt(textBox_password.Text, true));
                 _obj.fn_setsqljobid(_sqljobid, comboBox_capturedinstances.Text, Databasename, tablename,desttable,comboBox_Database.Text,textBox_Server.Text);  
                if(string.IsNullOrEmpty(Settings1.Default.User) || Settings1.Default.AuthenticationType=="Windows")
                {
                    userid="$$@#$$";
                }
                
                string _cmd = Directory.GetCurrentDirectory() + "//" + "SQLCDCIDLoader.exe " + _sqljobid + " " + 
                    Settings1.Default.Server + " " + userid + " " + password;
                _sajob.SQLJobStep(_cmd, _sqljobname);
                
                MessageBox.Show(_sqljobname + " created on " + Settings1.Default.Server + ". Schedule accordingly from SQL Server Agent.", "SQLCDCApp");
                
                Cursor.Current = Cursors.Arrow;
            }catch(Exception ex)
            {
                
                MessageBox.Show(ex.Message, "SQLCDCApp Error!!!");
            }
            // update meta tables with sql job id.
            
             
        }

        
        private void button_exporttofile_Click(object sender, EventArgs e)
        {
            if (dataGridView_showresults.Rows.Count == 1)
            {
                MessageBox.Show ("No data to export!!!","SQLCDCApp Info!!!");
                return;

            }
            SaveFileDialog filedialog = new SaveFileDialog();
            filedialog.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv|All files (*.*)|*.*";
            if (filedialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = filedialog.FileName.ToString();
                
                // Export grid data to file.
                fn_ExportGridtoFile(filepath);
                
            }
        }

    }
}
