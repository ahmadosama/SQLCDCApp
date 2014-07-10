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
    public partial class CaptureInstances : Form
    {
        private string database = "", table = "";
        public CaptureInstances()
        {
            InitializeComponent();
        }

        public CaptureInstances(string _db,string _tb)
        {
            database = _db;
            table = _tb;
            InitializeComponent();

        }


        private void CaptureInstances_Load(object sender, EventArgs e)
        {
            //SQLCDCApp _obj = new SQLCDCApp();
            //DataTable _dt = _obj.fn_Getcaptureinstances(database, table);
            //foreach(DataRow _dr in _dt.Rows)
            //{
            //    checkedListBox_captureinstance.Items.Add(_dr[0].ToString());
            //}
            
            
        }
    }
}
