using Common.HwControl.Model.Utilities;
using Common.HwControl.Model;

namespace Common.HwControl.UI
{
    partial class ModernTextBox
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
            CommonHwExceptionHandler.HwExeptionRaised -= (message) => OnPrintToMessagesBox(message, true);
            NotificationPrinter.printNotification -= (message) => OnPrintToMessagesBox(message, false);
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.richMessagesBox = new Common.HwControl.UI.RichMessageBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richMessagesBox);
            this.panel1.Location = new System.Drawing.Point(3, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 82);
            this.panel1.TabIndex = 1;
            // 
            // richMessagesBox
            // 
            this.richMessagesBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richMessagesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richMessagesBox.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.richMessagesBox.Location = new System.Drawing.Point(0, 0);
            this.richMessagesBox.Name = "richMessagesBox";
            this.richMessagesBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richMessagesBox.Size = new System.Drawing.Size(354, 80);
            this.richMessagesBox.TabIndex = 0;
            this.richMessagesBox.Text = "";
            // 
            // ModernTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ModernTextBox";
            this.Size = new System.Drawing.Size(385, 94);
            this.SizeChanged += new System.EventHandler(this.ModernTextBox_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RichMessageBox richMessagesBox;
        private System.Windows.Forms.Panel panel1;
    }
}
