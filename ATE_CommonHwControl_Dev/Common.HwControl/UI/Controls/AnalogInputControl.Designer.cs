
using System.Windows.Forms;

namespace Common.HwControl.UI.Controls
{
    internal partial class AnalogInputControl
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
            this.displayValueBox = new Common.HwControl.UI.NumericTextBox();
            this.getButton = new System.Windows.Forms.CheckBox();
            this.ctrlLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // displayValueBox
            // 
            this.displayValueBox.DecimalPlaces = 0;
            this.displayValueBox.Enabled = false;
            this.displayValueBox.Location = new System.Drawing.Point(134, 3);
            this.displayValueBox.Minimum = 0;
            this.displayValueBox.Name = "displayValueBox";
            this.displayValueBox.ReadOnly = true;
            this.displayValueBox.Size = new System.Drawing.Size(53, 30);
            this.displayValueBox.TabIndex = 45;
            this.displayValueBox.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // getButton
            // 
            this.getButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.getButton.AutoSize = true;
            this.getButton.Location = new System.Drawing.Point(187, 5);
            this.getButton.Name = "getButton";
            this.getButton.Size = new System.Drawing.Size(34, 23);
            this.getButton.TabIndex = 44;
            this.getButton.Text = "Get";
            this.getButton.UseVisualStyleBackColor = true;
            this.getButton.CheckedChanged += new System.EventHandler(this.GetButton_CheckedChanged);
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.AutoSize = true;
            this.ctrlLabel1.Location = new System.Drawing.Point(3, 10);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(67, 13);
            this.ctrlLabel1.TabIndex = 46;
            this.ctrlLabel1.Text = "Signal Name";
            // 
            // AnalogInputControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlLabel1);
            this.Controls.Add(this.displayValueBox);
            this.Controls.Add(this.getButton);
            this.Name = "AnalogInputControl";
            this.Size = new System.Drawing.Size(229, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private NumericTextBox displayValueBox;
        private System.Windows.Forms.CheckBox getButton;
        private Label ctrlLabel1;
    }
}
