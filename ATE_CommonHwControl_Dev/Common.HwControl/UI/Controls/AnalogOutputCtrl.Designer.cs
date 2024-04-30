using System.Windows.Forms;

namespace Common.HwControl.UI.Controls
{
    internal partial class AnalogOutputCtrl
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.setToggle = new MetroFramework.Controls.MetroToggle();
            this.ctrlLabel1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // setToggle
            // 
            this.setToggle.Location = new System.Drawing.Point(122, 7);
            this.setToggle.Name = "setToggle";
            this.setToggle.Size = new System.Drawing.Size(80, 17);
            this.setToggle.TabIndex = 0;
            this.setToggle.Text = "Off";
            this.setToggle.UseSelectable = true;
            this.setToggle.CheckedChanged += new System.EventHandler(this.SetButton_CheckedChanged);
            // 
            // ctrlLabel1
            // 
            this.ctrlLabel1.AutoSize = true;
            this.ctrlLabel1.Location = new System.Drawing.Point(3, 9);
            this.ctrlLabel1.Name = "ctrlLabel1";
            this.ctrlLabel1.Size = new System.Drawing.Size(67, 13);
            this.ctrlLabel1.TabIndex = 40;
            this.ctrlLabel1.Text = "Signal Name";
            // 
            // AnalogOutputCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlLabel1);
            this.Controls.Add(this.setToggle);
            this.Name = "AnalogOutputCtrl";
            this.Size = new System.Drawing.Size(227, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolTip toolTip1;
        private MetroFramework.Controls.MetroToggle setToggle;
        private Label ctrlLabel1;
    }
}
