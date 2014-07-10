namespace SQLCDCApp
{
    partial class CaptureInstances
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_selectall = new System.Windows.Forms.Button();
            this.button_deselectall = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Capture instances to disable ";
            // 
            // button_selectall
            // 
            this.button_selectall.Location = new System.Drawing.Point(16, 261);
            this.button_selectall.Name = "button_selectall";
            this.button_selectall.Size = new System.Drawing.Size(75, 23);
            this.button_selectall.TabIndex = 2;
            this.button_selectall.Text = "Select all";
            this.button_selectall.UseVisualStyleBackColor = true;
            // 
            // button_deselectall
            // 
            this.button_deselectall.Location = new System.Drawing.Point(98, 261);
            this.button_deselectall.Name = "button_deselectall";
            this.button_deselectall.Size = new System.Drawing.Size(75, 23);
            this.button_deselectall.TabIndex = 3;
            this.button_deselectall.Text = "Deselect all";
            this.button_deselectall.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(180, 261);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 4;
            this.button_ok.Text = "OK";
            this.button_ok.UseVisualStyleBackColor = true;
            // 
            // CaptureInstances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 296);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.button_deselectall);
            this.Controls.Add(this.button_selectall);
            this.Controls.Add(this.label1);
            this.Name = "CaptureInstances";
            this.Text = "CaptureInstances";
            this.Load += new System.EventHandler(this.CaptureInstances_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_selectall;
        private System.Windows.Forms.Button button_deselectall;
        private System.Windows.Forms.Button button_ok;
    }
}