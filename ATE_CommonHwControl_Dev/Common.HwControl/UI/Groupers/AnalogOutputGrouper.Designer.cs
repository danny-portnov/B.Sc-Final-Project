namespace Common.HwControl.UI.Groupers
{
    partial class AnalogOutputGrouper
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
            this.analogOutputPanel1 = new Common.HwControl.UI.Panels.AnalogOutputPanel();
            this.controlsPanel.SuspendLayout();
            this.grouper.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.analogOutputPanel1);
            // 
            // grouper2
            // 
            this.grouper.GroupTitle = "Analog - Output";
            // 
            // periodUpdaterControl1
            // 
            this.periodUpdaterControl1.Visible = false;
            // 
            // rateButton1
            // 
            this.rateButton1.Visible = false;
            // 
            // analogOutputPanel1
            // 
            this.analogOutputPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analogOutputPanel1.EnableContinuousUpdate = false;
            this.analogOutputPanel1.Location = new System.Drawing.Point(0, 0);
            this.analogOutputPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.analogOutputPanel1.Name = "analogOutputPanel1";
            this.analogOutputPanel1.Size = new System.Drawing.Size(352, 254);
            this.analogOutputPanel1.TabIndex = 0;
            // 
            // NewAnalogOutputGrouper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "NewAnalogOutputGrouper";
            this.controlsPanel.ResumeLayout(false);
            this.grouper.ResumeLayout(false);
            this.grouper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.AnalogOutputPanel analogOutputPanel1;
    }
}
