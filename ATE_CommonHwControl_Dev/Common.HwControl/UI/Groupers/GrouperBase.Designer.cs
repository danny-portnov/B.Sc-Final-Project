namespace Common.HwControl.UI.Groupers
{
    partial class GrouperBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grouper = new CodeVendor.Controls.Grouper();
            this.periodUpdaterControl1 = new Common.HwControl.UI.PeriodUpdaterControl();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.rateButton1 = new Common.HwControl.UI.Utility.RATEButton();
            this.driverPanelBox = new System.Windows.Forms.PictureBox();
            this.grouper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.driverPanelBox)).BeginInit();
            this.SuspendLayout();
            // 
            // grouper
            // 
            this.grouper.BackgroundColor = System.Drawing.Color.White;
            this.grouper.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouper.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouper.BorderColor = System.Drawing.Color.Black;
            this.grouper.BorderThickness = 1F;
            this.grouper.Controls.Add(this.periodUpdaterControl1);
            this.grouper.Controls.Add(this.controlsPanel);
            this.grouper.Controls.Add(this.rateButton1);
            this.grouper.Controls.Add(this.driverPanelBox);
            this.grouper.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grouper.Enabled = false;
            this.grouper.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.grouper.GroupImage = null;
            this.grouper.GroupTitle = "Title";
            this.grouper.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grouper.Location = new System.Drawing.Point(0, 0);
            this.grouper.Name = "grouper";
            this.grouper.Padding = new System.Windows.Forms.Padding(20);
            this.grouper.PaintGroupBox = true;
            this.grouper.RoundCorners = 5;
            this.grouper.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouper.ShadowControl = true;
            this.grouper.ShadowThickness = 2;
            this.grouper.Size = new System.Drawing.Size(386, 333);
            this.grouper.TabIndex = 79;
            // 
            // periodUpdaterControl1
            // 
            this.periodUpdaterControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.periodUpdaterControl1.Checked = false;
            this.periodUpdaterControl1.IntervalValue = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.periodUpdaterControl1.Location = new System.Drawing.Point(11, 295);
            this.periodUpdaterControl1.Margin = new System.Windows.Forms.Padding(4);
            this.periodUpdaterControl1.Minimum = 200;
            this.periodUpdaterControl1.Name = "periodUpdaterControl1";
            this.periodUpdaterControl1.Size = new System.Drawing.Size(253, 34);
            this.periodUpdaterControl1.TabIndex = 133;
            this.periodUpdaterControl1.CheckedChanged += new System.EventHandler(this.PeriodUpdaterControl1_CheckedChanged);
            // 
            // controlsPanel
            // 
            this.controlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsPanel.AutoScroll = true;
            this.controlsPanel.Location = new System.Drawing.Point(11, 38);
            this.controlsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(352, 254);
            this.controlsPanel.TabIndex = 132;
            // 
            // rateButton1
            // 
            this.rateButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rateButton1.Appearance = System.Windows.Forms.Appearance.Button;
            this.rateButton1.AutoSize = true;
            this.rateButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(97)))), ((int)(((byte)(115)))));
            this.rateButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rateButton1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.rateButton1.ForeColor = System.Drawing.Color.White;
            this.rateButton1.Location = new System.Drawing.Point(294, 295);
            this.rateButton1.Name = "rateButton1";
            this.rateButton1.Size = new System.Drawing.Size(59, 26);
            this.rateButton1.TabIndex = 130;
            this.rateButton1.Text = "Action";
            this.rateButton1.UseVisualStyleBackColor = false;
            this.rateButton1.CheckedChanged += new System.EventHandler(this.RateButton1_CheckedChanged);
            // 
            // driverPanelBox
            // 
            this.driverPanelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.driverPanelBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.driverPanelBox.Image = global::Common.HwControl.Properties.Resources.DriverIcon;
            this.driverPanelBox.Location = new System.Drawing.Point(327, 12);
            this.driverPanelBox.Name = "driverPanelBox";
            this.driverPanelBox.Size = new System.Drawing.Size(26, 23);
            this.driverPanelBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.driverPanelBox.TabIndex = 92;
            this.driverPanelBox.TabStop = false;
            this.driverPanelBox.Click += new System.EventHandler(this.DriverPanelBox_Click);
            // 
            // GrouperBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grouper);
            this.Name = "GrouperBase";
            this.Size = new System.Drawing.Size(386, 333);
            this.grouper.ResumeLayout(false);
            this.grouper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.driverPanelBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox driverPanelBox;
        protected System.Windows.Forms.Panel controlsPanel;
        protected CodeVendor.Controls.Grouper grouper;
        protected PeriodUpdaterControl periodUpdaterControl1;
        protected Utility.RATEButton rateButton1;
    }
}
