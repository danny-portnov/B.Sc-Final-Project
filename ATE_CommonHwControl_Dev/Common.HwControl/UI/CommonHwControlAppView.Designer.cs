using MetroFramework.Controls;
using System.Windows.Forms;

namespace Common.HwControl.UI
{
    partial class CommonHwControlAppView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ControlPanel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelHeaderInterface = new System.Windows.Forms.Label();
            this.panelHelpAbout = new System.Windows.Forms.Panel();
            this.pictureBoxRunMode = new System.Windows.Forms.PictureBox();
            this.pictureBoxAbout = new System.Windows.Forms.PictureBox();
            this.lblRunMode = new System.Windows.Forms.Label();
            this.labelHelpAbout = new System.Windows.Forms.Label();
            this.mainAppPanel = new Common.HwControl.UI.MainAppPanel();
            this.newMuxGrouper1 = new Common.HwControl.UI.Groupers.MuxGrouper();
            this.newAnalogOutputGrouper1 = new Common.HwControl.UI.Groupers.AnalogOutputGrouper();
            this.newPowerSuppliesGrouper1 = new Common.HwControl.UI.Groupers.PowerSuppliesGrouper();
            this.newRelaysGrouper1 = new Common.HwControl.UI.Groupers.RelaysGrouper();
            this.discreteOutputGrouper1 = new Common.HwControl.UI.Groupers.DigitalOutputGrouper();
            this.discreteInputGrouper1 = new Common.HwControl.UI.Groupers.DigitalInputGrouper();
            this.newAnalogInputGrouper1 = new Common.HwControl.UI.Groupers.AnalogInputGrouper();
            this.modernTextBox1 = new Common.HwControl.UI.ModernTextBox();
            this.mainStatusBar1 = new Common.HwControl.UI.MainStatusBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.ControlPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelHelpAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRunMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAbout)).BeginInit();
            this.mainAppPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Simulation";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.ToolTipText = "Driver run in simulation mode";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ControlPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainAppPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mainStatusBar1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1196, 865);
            this.tableLayoutPanel1.TabIndex = 56;
            // 
            // ControlPanel2
            // 
            this.ControlPanel2.BackColor = System.Drawing.Color.Transparent;
            this.ControlPanel2.BackgroundImage = global::Common.HwControl.Properties.Resources.Header;
            this.ControlPanel2.Controls.Add(this.tableLayoutPanel2);
            this.ControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.ControlPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.ControlPanel2.Name = "ControlPanel2";
            this.ControlPanel2.Size = new System.Drawing.Size(1196, 60);
            this.ControlPanel2.TabIndex = 55;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(67)))), ((int)(((byte)(86)))));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Controls.Add(this.labelHeaderInterface, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelHelpAbout, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(67)))), ((int)(((byte)(86)))));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1196, 60);
            this.tableLayoutPanel2.TabIndex = 32;
            // 
            // labelHeaderInterface
            // 
            this.labelHeaderInterface.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(67)))), ((int)(((byte)(86)))));
            this.labelHeaderInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHeaderInterface.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold);
            this.labelHeaderInterface.ForeColor = System.Drawing.Color.White;
            this.labelHeaderInterface.Location = new System.Drawing.Point(215, 0);
            this.labelHeaderInterface.Name = "labelHeaderInterface";
            this.labelHeaderInterface.Size = new System.Drawing.Size(858, 60);
            this.labelHeaderInterface.TabIndex = 31;
            this.labelHeaderInterface.Text = "Common Hardware Control App";
            this.labelHeaderInterface.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelHelpAbout
            // 
            this.panelHelpAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(67)))), ((int)(((byte)(86)))));
            this.panelHelpAbout.Controls.Add(this.pictureBoxRunMode);
            this.panelHelpAbout.Controls.Add(this.pictureBoxAbout);
            this.panelHelpAbout.Controls.Add(this.lblRunMode);
            this.panelHelpAbout.Controls.Add(this.labelHelpAbout);
            this.panelHelpAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHelpAbout.Location = new System.Drawing.Point(1076, 0);
            this.panelHelpAbout.Margin = new System.Windows.Forms.Padding(0);
            this.panelHelpAbout.Name = "panelHelpAbout";
            this.panelHelpAbout.Size = new System.Drawing.Size(120, 60);
            this.panelHelpAbout.TabIndex = 27;
            // 
            // pictureBoxRunMode
            // 
            this.pictureBoxRunMode.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBoxRunMode.Image = global::Common.HwControl.Properties.Resources.runMode;
            this.pictureBoxRunMode.Location = new System.Drawing.Point(17, 7);
            this.pictureBoxRunMode.Name = "pictureBoxRunMode";
            this.pictureBoxRunMode.Size = new System.Drawing.Size(39, 34);
            this.pictureBoxRunMode.TabIndex = 36;
            this.pictureBoxRunMode.TabStop = false;
            // 
            // pictureBoxAbout
            // 
            this.pictureBoxAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAbout.Image = global::Common.HwControl.Properties.Resources.Help_30px;
            this.pictureBoxAbout.Location = new System.Drawing.Point(73, 8);
            this.pictureBoxAbout.Name = "pictureBoxAbout";
            this.pictureBoxAbout.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxAbout.TabIndex = 35;
            this.pictureBoxAbout.TabStop = false;
            this.pictureBoxAbout.Click += new System.EventHandler(this.pictureBoxAbout_Click);
            // 
            // lblRunMode
            // 
            this.lblRunMode.ForeColor = System.Drawing.Color.White;
            this.lblRunMode.Location = new System.Drawing.Point(9, 42);
            this.lblRunMode.Name = "lblRunMode";
            this.lblRunMode.Size = new System.Drawing.Size(57, 12);
            this.lblRunMode.TabIndex = 34;
            this.lblRunMode.Text = "Run";
            this.lblRunMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHelpAbout
            // 
            this.labelHelpAbout.ForeColor = System.Drawing.Color.White;
            this.labelHelpAbout.Location = new System.Drawing.Point(70, 42);
            this.labelHelpAbout.Name = "labelHelpAbout";
            this.labelHelpAbout.Size = new System.Drawing.Size(37, 13);
            this.labelHelpAbout.TabIndex = 31;
            this.labelHelpAbout.Text = "About";
            this.labelHelpAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainAppPanel
            // 
            this.mainAppPanel.BackColor = System.Drawing.SystemColors.Control;
            this.mainAppPanel.Controls.Add(this.newMuxGrouper1);
            this.mainAppPanel.Controls.Add(this.newAnalogOutputGrouper1);
            this.mainAppPanel.Controls.Add(this.newPowerSuppliesGrouper1);
            this.mainAppPanel.Controls.Add(this.newRelaysGrouper1);
            this.mainAppPanel.Controls.Add(this.discreteOutputGrouper1);
            this.mainAppPanel.Controls.Add(this.discreteInputGrouper1);
            this.mainAppPanel.Controls.Add(this.newAnalogInputGrouper1);
            this.mainAppPanel.Controls.Add(this.modernTextBox1);
            this.mainAppPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainAppPanel.Location = new System.Drawing.Point(0, 60);
            this.mainAppPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainAppPanel.Name = "mainAppPanel";
            this.mainAppPanel.Size = new System.Drawing.Size(1196, 785);
            this.mainAppPanel.TabIndex = 57;
            // 
            // newMuxGrouper1
            // 
            this.newMuxGrouper1.Location = new System.Drawing.Point(907, 681);
            this.newMuxGrouper1.Name = "newMuxGrouper1";
            this.newMuxGrouper1.Size = new System.Drawing.Size(151, 101);
            this.newMuxGrouper1.TabIndex = 135;
            // 
            // newAnalogOutputGrouper1
            // 
            this.newAnalogOutputGrouper1.Location = new System.Drawing.Point(802, 528);
            this.newAnalogOutputGrouper1.Name = "newAnalogOutputGrouper1";
            this.newAnalogOutputGrouper1.Size = new System.Drawing.Size(386, 147);
            this.newAnalogOutputGrouper1.TabIndex = 134;
            // 
            // newPowerSuppliesGrouper1
            // 
            this.newPowerSuppliesGrouper1.Location = new System.Drawing.Point(802, 3);
            this.newPowerSuppliesGrouper1.Name = "newPowerSuppliesGrouper1";
            this.newPowerSuppliesGrouper1.Size = new System.Drawing.Size(386, 516);
            this.newPowerSuppliesGrouper1.TabIndex = 133;
            // 
            // newRelaysGrouper1
            // 
            this.newRelaysGrouper1.Location = new System.Drawing.Point(410, 342);
            this.newRelaysGrouper1.Name = "newRelaysGrouper1";
            this.newRelaysGrouper1.Size = new System.Drawing.Size(386, 333);
            this.newRelaysGrouper1.TabIndex = 132;
            // 
            // discreteOutputGrouper1
            // 
            this.discreteOutputGrouper1.Location = new System.Drawing.Point(410, 3);
            this.discreteOutputGrouper1.Name = "discreteOutputGrouper1";
            this.discreteOutputGrouper1.Size = new System.Drawing.Size(386, 333);
            this.discreteOutputGrouper1.TabIndex = 131;
            // 
            // discreteInputGrouper1
            // 
            this.discreteInputGrouper1.Location = new System.Drawing.Point(18, 3);
            this.discreteInputGrouper1.Name = "discreteInputGrouper1";
            this.discreteInputGrouper1.Size = new System.Drawing.Size(386, 333);
            this.discreteInputGrouper1.TabIndex = 130;
            // 
            // newAnalogInputGrouper1
            // 
            this.newAnalogInputGrouper1.Location = new System.Drawing.Point(18, 342);
            this.newAnalogInputGrouper1.Name = "newAnalogInputGrouper1";
            this.newAnalogInputGrouper1.Size = new System.Drawing.Size(386, 333);
            this.newAnalogInputGrouper1.TabIndex = 127;
            // 
            // modernTextBox1
            // 
            this.modernTextBox1.ButtonTextClear = true;
            this.modernTextBox1.Location = new System.Drawing.Point(18, 681);
            this.modernTextBox1.Name = "modernTextBox1";
            this.modernTextBox1.Size = new System.Drawing.Size(883, 101);
            this.modernTextBox1.TabIndex = 125;
            // 
            // mainStatusBar1
            // 
            this.mainStatusBar1.Location = new System.Drawing.Point(3, 848);
            this.mainStatusBar1.Name = "mainStatusBar1";
            this.mainStatusBar1.ShowPanels = true;
            this.mainStatusBar1.Size = new System.Drawing.Size(1190, 14);
            this.mainStatusBar1.TabIndex = 58;
            this.mainStatusBar1.Text = "mainStatusBar1";
            // 
            // CommonHwControlAppView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 865);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CommonHwControlAppView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommonHwControlAppView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CommonHwControlAppView_FormClosing);
            this.Load += new System.EventHandler(this.CommonHwControlAppView_Load);
            this.Shown += new System.EventHandler(this.CommonHwControlAppView_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ControlPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelHelpAbout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRunMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAbout)).EndInit();
            this.mainAppPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel ControlPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Common.HwControl.UI.MainAppPanel mainAppPanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private ModernTextBox modernTextBox1;
        private Panel panelHelpAbout;
        private PictureBox pictureBoxRunMode;
        private PictureBox pictureBoxAbout;
        private Label lblRunMode;
        private Label labelHelpAbout;
        private Label labelHeaderInterface;
        private Groupers.AnalogInputGrouper newAnalogInputGrouper1;
        private Groupers.DigitalInputGrouper discreteInputGrouper1;
        private Groupers.DigitalOutputGrouper discreteOutputGrouper1;
        private Groupers.RelaysGrouper newRelaysGrouper1;
        private Groupers.PowerSuppliesGrouper newPowerSuppliesGrouper1;
        private Groupers.MuxGrouper newMuxGrouper1;
        private Groupers.AnalogOutputGrouper newAnalogOutputGrouper1;
        private MainStatusBar mainStatusBar1;
    }
}