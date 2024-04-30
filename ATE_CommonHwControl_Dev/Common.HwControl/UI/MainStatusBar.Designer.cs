namespace Common.HwControl.UI
{
    partial class MainStatusBar
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
            this.statusPanel = new System.Windows.Forms.StatusBarPanel();
            this.datetimePanel = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.statusPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datetimePanel)).BeginInit();
            this.SuspendLayout();
            // 
            // statusPanel
            // 
            this.statusPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Text = "Application started. Loading devices...";
            this.statusPanel.ToolTipText = "Last Activity";
            this.statusPanel.Width = 73;
            // 
            // datetimePanel
            // 
            this.datetimePanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            this.datetimePanel.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
            this.datetimePanel.Name = "datetimePanel";
            this.datetimePanel.ToolTipText = "Shows current date";
            this.datetimePanel.Width = 10;
            // 
            // MainStatusBar
            // 
            this.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusPanel,
            this.datetimePanel});
            this.ShowPanels = true;
            this.Text = "Application started. No action yet";
            ((System.ComponentModel.ISupportInitialize)(this.statusPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datetimePanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusBarPanel statusPanel;
        private System.Windows.Forms.StatusBarPanel datetimePanel;
    }
}
