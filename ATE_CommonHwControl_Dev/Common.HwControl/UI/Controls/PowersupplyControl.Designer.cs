
namespace Common.HwControl.UI.Groupers
{
    partial class PowersupplyControl
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
            this.components = new System.ComponentModel.Container();
            this.psGrouper = new CodeVendor.Controls.Grouper();
            this.getCurrent = new System.Windows.Forms.Label();
            this.getVoltage = new System.Windows.Forms.Label();
            this.toggleOutput = new MetroFramework.Controls.MetroToggle();
            this.setCurrentLimit = new System.Windows.Forms.NumericUpDown();
            this.setVoltage = new System.Windows.Forms.NumericUpDown();
            this.getOutput = new Bulb.LedBulb();
            this.currentLabel = new System.Windows.Forms.Label();
            this.voltageLabel = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.psGrouper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setCurrentLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.setVoltage)).BeginInit();
            this.SuspendLayout();
            // 
            // psGrouper
            // 
            this.psGrouper.BackgroundColor = System.Drawing.Color.White;
            this.psGrouper.BackgroundGradientColor = System.Drawing.Color.White;
            this.psGrouper.BackgroundGradientMode = CodeVendor.Controls.Grouper.GroupBoxGradientMode.None;
            this.psGrouper.BorderColor = System.Drawing.Color.Black;
            this.psGrouper.BorderThickness = 3F;
            this.psGrouper.Controls.Add(this.getCurrent);
            this.psGrouper.Controls.Add(this.getVoltage);
            this.psGrouper.Controls.Add(this.toggleOutput);
            this.psGrouper.Controls.Add(this.setCurrentLimit);
            this.psGrouper.Controls.Add(this.setVoltage);
            this.psGrouper.Controls.Add(this.getOutput);
            this.psGrouper.Controls.Add(this.currentLabel);
            this.psGrouper.Controls.Add(this.voltageLabel);
            this.psGrouper.Controls.Add(this.label);
            this.psGrouper.CustomGroupBoxColor = System.Drawing.Color.White;
            this.psGrouper.GroupImage = null;
            this.psGrouper.GroupTitle = "Title";
            this.psGrouper.Location = new System.Drawing.Point(3, 3);
            this.psGrouper.Name = "psGrouper";
            this.psGrouper.Padding = new System.Windows.Forms.Padding(20);
            this.psGrouper.PaintGroupBox = false;
            this.psGrouper.RoundCorners = 20;
            this.psGrouper.ShadowColor = System.Drawing.Color.DarkGray;
            this.psGrouper.ShadowControl = true;
            this.psGrouper.ShadowThickness = 3;
            this.psGrouper.Size = new System.Drawing.Size(187, 138);
            this.psGrouper.TabIndex = 93;
            // 
            // getCurrent
            // 
            this.getCurrent.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.getCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.getCurrent.ForeColor = System.Drawing.Color.Lime;
            this.getCurrent.Location = new System.Drawing.Point(83, 52);
            this.getCurrent.Name = "getCurrent";
            this.getCurrent.Size = new System.Drawing.Size(102, 25);
            this.getCurrent.TabIndex = 66;
            this.getCurrent.Text = "00.0A";
            this.getCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // getVoltage
            // 
            this.getVoltage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.getVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.getVoltage.ForeColor = System.Drawing.Color.Lime;
            this.getVoltage.Location = new System.Drawing.Point(-7, 52);
            this.getVoltage.Name = "getVoltage";
            this.getVoltage.Size = new System.Drawing.Size(99, 25);
            this.getVoltage.TabIndex = 65;
            this.getVoltage.Text = "00.0V";
            this.getVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toggleOutput
            // 
            this.toggleOutput.AutoSize = true;
            this.toggleOutput.DisplayStatus = false;
            this.toggleOutput.Location = new System.Drawing.Point(135, 28);
            this.toggleOutput.Name = "toggleOutput";
            this.toggleOutput.Size = new System.Drawing.Size(50, 17);
            this.toggleOutput.TabIndex = 64;
            this.toggleOutput.Text = "Off";
            this.toggleOutput.UseSelectable = true;
            this.toggleOutput.CheckedChanged += new System.EventHandler(this.ToggleOutput_CheckedChanged);
            // 
            // setCurrentLimit
            // 
            this.setCurrentLimit.DecimalPlaces = 2;
            this.setCurrentLimit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.setCurrentLimit.Location = new System.Drawing.Point(135, 108);
            this.setCurrentLimit.Name = "setCurrentLimit";
            this.setCurrentLimit.Size = new System.Drawing.Size(39, 20);
            this.setCurrentLimit.TabIndex = 63;
            this.setCurrentLimit.ValueChanged += new System.EventHandler(this.SetCurrent_ValueChanged);
            // 
            // setVoltage
            // 
            this.setVoltage.DecimalPlaces = 2;
            this.setVoltage.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.setVoltage.Location = new System.Drawing.Point(135, 82);
            this.setVoltage.Name = "setVoltage";
            this.setVoltage.Size = new System.Drawing.Size(39, 20);
            this.setVoltage.TabIndex = 62;
            this.setVoltage.ValueChanged += new System.EventHandler(this.SetVoltage_ValueChanged);
            // 
            // getOutput
            // 
            this.getOutput.Color = System.Drawing.Color.LightGray;
            this.getOutput.Location = new System.Drawing.Point(83, 25);
            this.getOutput.Name = "getOutput";
            this.getOutput.On = true;
            this.getOutput.Size = new System.Drawing.Size(23, 23);
            this.getOutput.TabIndex = 61;
            this.getOutput.Text = "ledBulb1";
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.Location = new System.Drawing.Point(8, 112);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(65, 13);
            this.currentLabel.TabIndex = 60;
            this.currentLabel.Text = "Current Limit";
            // 
            // voltageLabel
            // 
            this.voltageLabel.AutoSize = true;
            this.voltageLabel.Location = new System.Drawing.Point(8, 89);
            this.voltageLabel.Name = "voltageLabel";
            this.voltageLabel.Size = new System.Drawing.Size(43, 13);
            this.voltageLabel.TabIndex = 59;
            this.voltageLabel.Text = "Voltage";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(8, 30);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(67, 13);
            this.label.TabIndex = 58;
            this.label.Text = "Output State";
            // 
            // PowersupplyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.psGrouper);
            this.Name = "PowersupplyControl";
            this.Size = new System.Drawing.Size(194, 141);
            this.psGrouper.ResumeLayout(false);
            this.psGrouper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setCurrentLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.setVoltage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CodeVendor.Controls.Grouper psGrouper;
        private MetroFramework.Controls.MetroToggle toggleOutput;
        public System.Windows.Forms.NumericUpDown setCurrentLimit;
        public System.Windows.Forms.NumericUpDown setVoltage;
        private Bulb.LedBulb getOutput;
        public System.Windows.Forms.Label currentLabel;
        public System.Windows.Forms.Label voltageLabel;
        public System.Windows.Forms.Label label;
        public System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label getCurrent;
        private System.Windows.Forms.Label getVoltage;
    }
}
