namespace Common.HwControl.UI.Groupers
{
    partial class PowerSuppliesGrouper
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
            this.powersuppliesPanel = new Common.HwControl.UI.Panels.PowersuppliesPanel();
            this.controlsPanel.SuspendLayout();
            this.grouper.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.powersuppliesPanel);
            this.controlsPanel.Size = new System.Drawing.Size(355, 235);
            // 
            // grouper2
            // 
            this.grouper.GroupTitle = "Powersupplies";
            // 
            // periodUpdaterControl1
            // 
            this.periodUpdaterControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.periodUpdaterControl1.Location = new System.Drawing.Point(20, 279);
            this.periodUpdaterControl1.Size = new System.Drawing.Size(346, 34);
            // 
            // rateButton1
            // 
            this.rateButton1.Visible = false;
            // 
            // powersuppliesPanel
            // 
            this.powersuppliesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.powersuppliesPanel.EnableContinuousUpdate = false;
            this.powersuppliesPanel.Location = new System.Drawing.Point(0, 0);
            this.powersuppliesPanel.Margin = new System.Windows.Forms.Padding(21, 9, 21, 9);
            this.powersuppliesPanel.Name = "powersuppliesPanel";
            this.powersuppliesPanel.Size = new System.Drawing.Size(355, 235);
            this.powersuppliesPanel.TabIndex = 1;
            // 
            // NewPowerSuppliesGrouper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "NewPowerSuppliesGrouper";
            this.controlsPanel.ResumeLayout(false);
            this.grouper.ResumeLayout(false);
            this.grouper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.PowersuppliesPanel powersuppliesPanel;
    }
}
