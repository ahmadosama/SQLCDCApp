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

    public partial class TableName : Form
    {
        //   CDCData f1var=new CDCData();
        public string desttable { get; set; }
        private string srctable;
        private string srcdb;
        private string destdb;
       
        public TableName(string _srctable,string _srcdb,string _destdb)
        {
            InitializeComponent();
            srctable = _srctable;
            srcdb=_srcdb;
            destdb = _destdb;
        }

        private void button_Tablename_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox_TableName.Text))
                {
                    MessageBox.Show("Please enter a tablename", "SQLCDCApp Information!!");
                }
                else
                {
                    desttable = textBox_TableName.Text;

                }

                SQLCDCApp obj = new SQLCDCApp();
                obj.fn_copytableschema(srctable, desttable, destdb,srcdb);
                MessageBox.Show("Table Created!!!", "SQLCDCAPP Information!!!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SQLCDCApp Error !!!");
            }
        }

    }
}
