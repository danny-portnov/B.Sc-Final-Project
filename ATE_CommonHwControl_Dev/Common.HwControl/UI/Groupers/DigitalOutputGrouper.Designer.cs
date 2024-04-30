namespace Common.HwControl.UI.Groupers
{
    partial class DigitalOutputGrouper
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
            this.digitalOutputPanel1 = new Common.HwControl.UI.Panels.DigitalOutputPanel();
            this.controlsPanel.SuspendLayout();
            this.grouper.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.digitalOutputPanel1);
            // 
            // grouper2
            // 
            this.grouper.GroupTitle = "Discrete - Outputs";
            // 
            // periodUpdaterControl1
            // 
            this.periodUpdaterControl1.Visible = false;
            // 
            // digitalOutputPanel1
            // 
            this.digitalOutputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.digitalOutputPanel1.EnableContinuousUpdate = false;
            this.digitalOutputPanel1.Location = new System.Drawing.Point(0, 0);
            this.digitalOutputPanel1.Margin = new System.Windows.Forms.Padding(9, 6, 9, 6);
            this.digitalOutputPanel1.Name = "digitalOutputPanel1";
            this.digitalOutputPanel1.Size = new System.Drawing.Size(352, 254);
            this.digitalOutputPanel1.TabIndex = 0;
            // 
            // DiscreteOutputGrouper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DiscreteOutputGrouper";
            this.controlsPanel.ResumeLayout(false);
            this.grouper.ResumeLayout(false);
            this.grouper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.DigitalOutputPanel digitalOutputPanel1;
    }
}
