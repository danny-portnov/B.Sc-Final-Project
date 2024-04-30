namespace Common.HwControl.UI.Groupers
{
    partial class RelaysGrouper
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
            this.relaysTabControl = new MetroFramework.Controls.MetroTabControl();
            this.OUTab = new MetroFramework.Controls.MetroTabPage();
            this.OUPanel = new Common.HwControl.UI.Panels.RelayPanel();
            this.ITATab = new MetroFramework.Controls.MetroTabPage();
            this.relayPanel1 = new Common.HwControl.UI.Panels.RelayPanel();
            this.controlsPanel.SuspendLayout();
            this.grouper.SuspendLayout();
            this.relaysTabControl.SuspendLayout();
            this.OUTab.SuspendLayout();
            this.ITATab.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.relaysTabControl);
            // 
            // grouper
            // 
            this.grouper.GroupTitle = "Relays - Outputs";
            // 
            // periodUpdaterControl1
            // 
            this.periodUpdaterControl1.Visible = false;
            // 
            // relaysTabControl
            // 
            this.relaysTabControl.Controls.Add(this.OUTab);
            this.relaysTabControl.Controls.Add(this.ITATab);
            this.relaysTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relaysTabControl.Location = new System.Drawing.Point(0, 0);
            this.relaysTabControl.Name = "relaysTabControl";
            this.relaysTabControl.SelectedIndex = 0;
            this.relaysTabControl.Size = new System.Drawing.Size(352, 254);
            this.relaysTabControl.TabIndex = 0;
            this.relaysTabControl.UseSelectable = true;
            this.relaysTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.RelaysTabControl_Selected);
            // 
            // OUTab
            // 
            this.OUTab.Controls.Add(this.OUPanel);
            this.OUTab.HorizontalScrollbarBarColor = false;
            this.OUTab.HorizontalScrollbarHighlightOnWheel = false;
            this.OUTab.HorizontalScrollbarSize = 0;
            this.OUTab.Location = new System.Drawing.Point(4, 38);
            this.OUTab.Name = "OUTab";
            this.OUTab.Size = new System.Drawing.Size(344, 212);
            this.OUTab.TabIndex = 0;
            this.OUTab.Text = "O.U.";
            this.OUTab.VerticalScrollbarBarColor = false;
            this.OUTab.VerticalScrollbarHighlightOnWheel = false;
            this.OUTab.VerticalScrollbarSize = 0;
            // 
            // OUPanel
            // 
            this.OUPanel.AutoScroll = true;
            this.OUPanel.BackColor = System.Drawing.Color.White;
            this.OUPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OUPanel.EnableContinuousUpdate = false;
            this.OUPanel.Location = new System.Drawing.Point(0, 0);
            this.OUPanel.Margin = new System.Windows.Forms.Padding(4);
            this.OUPanel.Name = "OUPanel";
            this.OUPanel.RelaysLocation = Common.HwControl.Model.JsonConfigParser.DataObjects.Location.OU;
            this.OUPanel.Size = new System.Drawing.Size(344, 212);
            this.OUPanel.TabIndex = 2;
            // 
            // ITATab
            // 
            this.ITATab.BackColor = System.Drawing.Color.White;
            this.ITATab.Controls.Add(this.relayPanel1);
            this.ITATab.HorizontalScrollbarBarColor = false;
            this.ITATab.HorizontalScrollbarHighlightOnWheel = false;
            this.ITATab.HorizontalScrollbarSize = 0;
            this.ITATab.Location = new System.Drawing.Point(4, 38);
            this.ITATab.Name = "ITATab";
            this.ITATab.Size = new System.Drawing.Size(344, 212);
            this.ITATab.TabIndex = 1;
            this.ITATab.Text = "ITA";
            this.ITATab.VerticalScrollbarBarColor = false;
            this.ITATab.VerticalScrollbarHighlightOnWheel = false;
            this.ITATab.VerticalScrollbarSize = 0;
            // 
            // relayPanel1
            // 
            this.relayPanel1.AutoScroll = true;
            this.relayPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.relayPanel1.EnableContinuousUpdate = false;
            this.relayPanel1.Location = new System.Drawing.Point(0, 0);
            this.relayPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.relayPanel1.Name = "relayPanel1";
            this.relayPanel1.RelaysLocation = Common.HwControl.Model.JsonConfigParser.DataObjects.Location.ITA;
            this.relayPanel1.Size = new System.Drawing.Size(344, 212);
            this.relayPanel1.TabIndex = 2;
            // 
            // NewRelaysGrouper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "NewRelaysGrouper";
            this.controlsPanel.ResumeLayout(false);
            this.grouper.ResumeLayout(false);
            this.grouper.PerformLayout();
            this.relaysTabControl.ResumeLayout(false);
            this.OUTab.ResumeLayout(false);
            this.ITATab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl relaysTabControl;
        private MetroFramework.Controls.MetroTabPage OUTab;
        private MetroFramework.Controls.MetroTabPage ITATab;
        private Panels.RelayPanel OUPanel;
        private Panels.RelayPanel relayPanel1;
    }
}
