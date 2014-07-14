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
    public partial class SQLAgentJobSchedule : Form
    {
        private string _sqljobserver;
        private string _sqluser;
        private string _sqlpwd;
        private string _header;

        public SQLAgentJobSchedule()
        {
            InitializeComponent();
        }
        
        public SQLAgentJobSchedule(string sqljobserver,string sqluser,string sqlpwd,string header)
        {
            InitializeComponent();
            _sqljobserver = sqljobserver;
            _sqluser = sqluser;
            _sqlpwd = sqlpwd;
            _header = header;
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ScheduleIDL_Load(object sender, EventArgs e)
        {
            label_info.Text = " Configure Incremental data load for: " +  _header;
            comboBox_scheduletype.Text = comboBox_scheduletype.Items[0].ToString();
            comboBox_frequency.Text = comboBox_frequency.Items[0].ToString();
        }

        private void comboBox_scheduletype_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (comboBox_scheduletype.Text)
	        {
                case "One time":
                    groupBox_dailyfrequency.Enabled = false;
                    groupBox_duration.Enabled = false;
                    groupBox_frequency.Enabled = false;
                    groupBox_onetime.Enabled = true;
                    break;
                case "Recurring":
                    groupBox_onetime.Enabled = false;
                    groupBox_dailyfrequency.Enabled = true;
                    groupBox_duration.Enabled = true;
                    groupBox_frequency.Enabled = true;
                    break;
                   
		        default:
                break;
	        }
            
        }

        private void comboBox_frequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_frequency.Text)
            {
                case "Daily":
                    panel_weekly.Visible = false;
                    label_recursevery.Text = " day(s) ";
                    break;
                case "Weekly":
                    panel_weekly.Visible = true;
                    label_recursevery.Text = " week(s) ";
                    break;
                default:
                    break;
            }
        }

        private void radioButton_occursonce_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_occursonce.Checked)
            {
                textBox_occursevery.Enabled = false;
                comboBox_occursevery.Enabled = false;
                dateTimePicker_starttime.Enabled = false;
                dateTimePicker_endtime.Enabled = false;
                dateTimePicker_oncetime.Enabled = true;
            }
        }

        private void radioButton_occursevery_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_occursevery.Checked)
            {

                textBox_occursevery.Enabled = true;
                comboBox_occursevery.Enabled = true;
                dateTimePicker_starttime.Enabled = true;
                dateTimePicker_endtime.Enabled = true;
                dateTimePicker_oncetime.Enabled = false;
            }
        }

        private void radioButton_noenddate_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_noenddate.Checked)
            {
                dateTimePicker_enddate.Enabled = false;
            }else
                if(!radioButton_noenddate.Checked)
                {
                    dateTimePicker_enddate.Enabled = true;
                }
        }
    }
}
