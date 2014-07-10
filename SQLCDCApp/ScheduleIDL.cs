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
    public partial class ScheduleIDL : Form
    {
        public ScheduleIDL()
        {
            InitializeComponent();
            SQLCDCApp obj = new SQLCDCApp();
           // dataGridView_scheduleresult.DataSource = obj.fn_getexportrecord();
        }

        private void ScheduleIDL_Load(object sender, EventArgs e)
        {

        }
    }
}
