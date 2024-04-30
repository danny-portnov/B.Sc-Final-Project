namespace Common.HwControl.UI
{
    partial class PeriodUpdaterControl
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
            this.isPeriodicCheckBox = new System.Windows.Forms.CheckBox();
            this.intervalNumericBox = new Common.HwControl.UI.NumericTextBox();
            this.SuspendLayout();
            // 
            // isPeriodicCheckBox
            // 
            this.isPeriodicCheckBox.AutoSize = true;
            this.isPeriodicCheckBox.Location = new System.Drawing.Point(45, 2);
            this.isPeriodicCheckBox.Name = "isPeriodicCheckBox";
            this.isPeriodicCheckBox.Size = new System.Drawing.Size(122, 17);
            this.isPeriodicCheckBox.TabIndex = 130;
            this.isPeriodicCheckBox.Text = "Sample periodically?";
            this.isPeriodicCheckBox.UseVisualStyleBackColor = true;
            this.isPeriodicCheckBox.CheckedChanged += new System.EventHandler(this.IsPeriodicCheckBox_CheckedChanged);
            // 
            // intervalNumericBox
            // 
            this.intervalNumericBox.DecimalPlaces = 0;
            this.intervalNumericBox.Location = new System.Drawing.Point(0, 0);
            this.intervalNumericBox.Margin = new System.Windows.Forms.Padding(5);
            this.intervalNumericBox.Minimum = 200;
            this.intervalNumericBox.Name = "intervalNumericBox";
            this.intervalNumericBox.ReadOnly = false;
            this.intervalNumericBox.Size = new System.Drawing.Size(50, 25);
            this.intervalNumericBox.TabIndex = 129;
            this.intervalNumericBox.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.intervalNumericBox.ValueChanged += new System.EventHandler(this.IntervalNumericBox_ValueChanged);
            // 
            // PeriodUpdaterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.isPeriodicCheckBox);
            this.Controls.Add(this.intervalNumericBox);
            this.Name = "PeriodUpdaterControl";
            this.Size = new System.Drawing.Size(168, 20);
            this.Load += new System.EventHandler(this.PeriodUpdater_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox isPeriodicCheckBox;
        private NumericTextBox intervalNumericBox;
    }
}
