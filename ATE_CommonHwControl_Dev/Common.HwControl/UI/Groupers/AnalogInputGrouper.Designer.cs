namespace Common.HwControl.UI.Groupers
{
    partial class AnalogInputGrouper
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
            this.analogInputPanel = new Common.HwControl.UI.Panels.AnalogInputPanel();
            this.controlsPanel.SuspendLayout();
            this.grouper.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.analogInputPanel);
            this.controlsPanel.Location = new System.Drawing.Point(11, 36);
            // 
            // grouper2
            // 
            this.grouper.GroupTitle = "Analogs - Input";
            // 
            // analogInputPanel1
            // 
            this.analogInputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.analogInputPanel.EnableContinuousUpdate = false;
            this.analogInputPanel.Location = new System.Drawing.Point(0, 0);
            this.analogInputPanel.Margin = new System.Windows.Forms.Padding(9, 6, 9, 6);
            this.analogInputPanel.Name = "analogInputPanel1";
            this.analogInputPanel.Size = new System.Drawing.Size(352, 254);
            this.analogInputPanel.TabIndex = 0;
            // 
            // NewAnalogInputGrouper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "NewAnalogInputGrouper";
            this.controlsPanel.ResumeLayout(false);
            this.grouper.ResumeLayout(false);
            this.grouper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.AnalogInputPanel analogInputPanel;
    }
}
