namespace Common.HwControl.UI.Groupers
{
    partial class MuxGrouper
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
            this.unitsMenu = new MetroFramework.Controls.MetroComboBox();
            this.grouper.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlsPanel
            // 
            this.controlsPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // grouper2
            // 
            this.grouper.Controls.Add(this.unitsMenu);
            this.grouper.GroupTitle = "Mux Box 1-5";
            this.grouper.Size = new System.Drawing.Size(151, 96);
            this.grouper.Controls.SetChildIndex(this.rateButton1, 0);
            this.grouper.Controls.SetChildIndex(this.controlsPanel, 0);
            this.grouper.Controls.SetChildIndex(this.periodUpdaterControl1, 0);
            this.grouper.Controls.SetChildIndex(this.unitsMenu, 0);
            // 
            // periodUpdaterControl1
            // 
            this.periodUpdaterControl1.Location = new System.Drawing.Point(-351, -772);
            this.periodUpdaterControl1.Visible = false;
            // 
            // rateButton1
            // 
            this.rateButton1.Location = new System.Drawing.Point(-68, -772);
            this.rateButton1.Visible = false;
            // 
            // unitsMenu
            // 
            this.unitsMenu.FormattingEnabled = true;
            this.unitsMenu.ItemHeight = 23;
            this.unitsMenu.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.unitsMenu.Location = new System.Drawing.Point(23, 43);
            this.unitsMenu.Name = "unitsMenu";
            this.unitsMenu.Size = new System.Drawing.Size(86, 29);
            this.unitsMenu.TabIndex = 134;
            this.unitsMenu.UseSelectable = true;
            this.unitsMenu.SelectedIndexChanged += new System.EventHandler(this.UnitsMenu_SelectedIndexChanged);
            // 
            // NewMuxGrouper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "NewMuxGrouper";
            this.Size = new System.Drawing.Size(151, 96);
            this.grouper.ResumeLayout(false);
            this.grouper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroComboBox unitsMenu;
    }
}
