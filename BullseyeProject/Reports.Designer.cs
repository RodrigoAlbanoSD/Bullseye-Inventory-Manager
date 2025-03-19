
namespace BullseyeProject
{
    partial class Reports
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
            this.cboReportsTypes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSeach = new System.Windows.Forms.Button();
            this.grpAvailableStores = new System.Windows.Forms.GroupBox();
            this.cboAvailableStores = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstReports = new System.Windows.Forms.ListBox();
            this.grpWeekDays = new System.Windows.Forms.GroupBox();
            this.cboWeekDay = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpAvailableStores.SuspendLayout();
            this.grpWeekDays.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose the type of reports you want";
            // 
            // cboReportsTypes
            // 
            this.cboReportsTypes.FormattingEnabled = true;
            this.cboReportsTypes.Items.AddRange(new object[] {
            "Delivery Report",
            "Store Order",
            "Shipping Receipt",
            "Inventory",
            "Sale",
            "Orders",
            "Emergency Orders",
            "Users",
            "Backorders",
            "Supplier Order"});
            this.cboReportsTypes.Location = new System.Drawing.Point(395, 25);
            this.cboReportsTypes.Name = "cboReportsTypes";
            this.cboReportsTypes.Size = new System.Drawing.Size(187, 32);
            this.cboReportsTypes.TabIndex = 1;
            this.cboReportsTypes.SelectedIndexChanged += new System.EventHandler(this.cboReportsTypes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "And the date range";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1106, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(821, 25);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(253, 27);
            this.dtpFrom.TabIndex = 5;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(1158, 25);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(253, 27);
            this.dtpTo.TabIndex = 6;
            // 
            // btnSeach
            // 
            this.btnSeach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(190)))), ((int)(((byte)(255)))));
            this.btnSeach.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSeach.Location = new System.Drawing.Point(1311, 574);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(173, 125);
            this.btnSeach.TabIndex = 8;
            this.btnSeach.Text = "Search";
            this.btnSeach.UseVisualStyleBackColor = false;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // grpAvailableStores
            // 
            this.grpAvailableStores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.grpAvailableStores.Controls.Add(this.cboAvailableStores);
            this.grpAvailableStores.Controls.Add(this.label8);
            this.grpAvailableStores.Location = new System.Drawing.Point(1008, 93);
            this.grpAvailableStores.Name = "grpAvailableStores";
            this.grpAvailableStores.Size = new System.Drawing.Size(445, 100);
            this.grpAvailableStores.TabIndex = 11;
            this.grpAvailableStores.TabStop = false;
            this.grpAvailableStores.Text = "Options";
            this.grpAvailableStores.Visible = false;
            // 
            // cboAvailableStores
            // 
            this.cboAvailableStores.FormattingEnabled = true;
            this.cboAvailableStores.Location = new System.Drawing.Point(214, 43);
            this.cboAvailableStores.Name = "cboAvailableStores";
            this.cboAvailableStores.Size = new System.Drawing.Size(202, 32);
            this.cboAvailableStores.TabIndex = 2;
            this.cboAvailableStores.SelectedIndexChanged += new System.EventHandler(this.cboAvailableStores_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Available Stores";
            // 
            // lstReports
            // 
            this.lstReports.FormattingEnabled = true;
            this.lstReports.ItemHeight = 24;
            this.lstReports.Location = new System.Drawing.Point(35, 93);
            this.lstReports.Name = "lstReports";
            this.lstReports.Size = new System.Drawing.Size(921, 580);
            this.lstReports.TabIndex = 13;
            // 
            // grpWeekDays
            // 
            this.grpWeekDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(145)))), ((int)(((byte)(0)))));
            this.grpWeekDays.Controls.Add(this.cboWeekDay);
            this.grpWeekDays.Controls.Add(this.label4);
            this.grpWeekDays.Location = new System.Drawing.Point(1008, 216);
            this.grpWeekDays.Name = "grpWeekDays";
            this.grpWeekDays.Size = new System.Drawing.Size(445, 100);
            this.grpWeekDays.TabIndex = 14;
            this.grpWeekDays.TabStop = false;
            this.grpWeekDays.Text = "Options";
            this.grpWeekDays.Visible = false;
            // 
            // cboWeekDay
            // 
            this.cboWeekDay.FormattingEnabled = true;
            this.cboWeekDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.cboWeekDay.Location = new System.Drawing.Point(214, 43);
            this.cboWeekDay.Name = "cboWeekDay";
            this.cboWeekDay.Size = new System.Drawing.Size(202, 32);
            this.cboWeekDay.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Choose day";
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1496, 711);
            this.Controls.Add(this.grpWeekDays);
            this.Controls.Add(this.lstReports);
            this.Controls.Add(this.grpAvailableStores);
            this.Controls.Add(this.btnSeach);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboReportsTypes);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Helvetica LT Pro", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Reports_Load);
            this.grpAvailableStores.ResumeLayout(false);
            this.grpAvailableStores.PerformLayout();
            this.grpWeekDays.ResumeLayout(false);
            this.grpWeekDays.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboReportsTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSeach;
        private System.Windows.Forms.GroupBox grpAvailableStores;
        private System.Windows.Forms.ComboBox cboAvailableStores;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstReports;
        private System.Windows.Forms.GroupBox grpWeekDays;
        private System.Windows.Forms.ComboBox cboWeekDay;
        private System.Windows.Forms.Label label4;
    }
}