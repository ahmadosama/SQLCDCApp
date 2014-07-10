namespace SQLCDCApp
{
    partial class ScheduleIDL
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
            this.dataGridView_scheduleresult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_scheduleresult)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_scheduleresult
            // 
            this.dataGridView_scheduleresult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_scheduleresult.Location = new System.Drawing.Point(28, 49);
            this.dataGridView_scheduleresult.Name = "dataGridView_scheduleresult";
            this.dataGridView_scheduleresult.Size = new System.Drawing.Size(496, 150);
            this.dataGridView_scheduleresult.TabIndex = 0;
            // 
            // ScheduleIDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 290);
            this.Controls.Add(this.dataGridView_scheduleresult);
            this.Name = "ScheduleIDL";
            this.Text = "ScheduleIDL";
            this.Load += new System.EventHandler(this.ScheduleIDL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_scheduleresult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_scheduleresult;
    }
}