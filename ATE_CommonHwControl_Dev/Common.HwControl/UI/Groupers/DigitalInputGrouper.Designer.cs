namespace Common.HwControl.UI.Groupers
{
    partial class DigitalInputGrouper
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
            this.digitalInputPanel1 = new Common.HwControl.UI.Panels.DigitalInputPanel();
            this.controlsPanel.SuspendLayout();
            this.grouper.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.digitalInputPanel1);
            // 
            // grouper2
            // 
            this.grouper.GroupTitle = "Disretes - Input";
            // 
            // digitalInputPanel1
            // 
            this.digitalInputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.digitalInputPanel1.EnableContinuousUpdate = false;
            this.digitalInputPanel1.Location = new System.Drawing.Point(0, 0);
            this.digitalInputPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.digitalInputPanel1.Name = "digitalInputPanel1";
            this.digitalInputPanel1.Size = new System.Drawing.Size(352, 254);
            this.digitalInputPanel1.TabIndex = 0;
            // 
            // DiscreteInputGrouper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DiscreteInputGrouper";
            this.controlsPanel.ResumeLayout(false);
            this.grouper.ResumeLayout(false);
            this.grouper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.DigitalInputPanel digitalInputPanel1;
    }
}
