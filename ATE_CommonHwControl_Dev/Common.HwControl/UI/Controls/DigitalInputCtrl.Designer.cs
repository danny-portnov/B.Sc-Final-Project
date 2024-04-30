using System.Windows.Forms;

namespace Common.HwControl.UI.Controls
{
    internal partial class DigitalInputCtrl
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
        protected void InitializeComponent()
        {
            this.ledDisplay = new Bulb.LedBulb();
            this.getButton = new System.Windows.Forms.CheckBox();
            this.ctrlLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ledDisplay
            // 
            this.ledDisplay.Color = System.Drawing.Color.LightGray;
            this.ledDisplay.Location = new System.Drawing.Point(156, 5);
            this.ledDisplay.Name = "ledDisplay";
            this.ledDisplay.On = true;
            this.ledDisplay.Size = new System.Drawing.Size(27, 23);
            this.ledDisplay.TabIndex = 45;
            // 
            // getButton
            // 
            this.getButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.getButton.AutoSize = true;
            this.getButton.Location = new System.Drawing.Point(185, 5);
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
            // DigitalInputCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlLabel1);
            this.Controls.Add(this.ledDisplay);
            this.Controls.Add(this.getButton);
            this.Name = "DigitalInputCtrl";
            this.Size = new System.Drawing.Size(222, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bulb.LedBulb ledDisplay;
        private System.Windows.Forms.CheckBox getButton;
        private Label ctrlLabel1;
    }
}
