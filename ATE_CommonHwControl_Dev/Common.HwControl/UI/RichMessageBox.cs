using DriversWrapper.Gps;
using LoggerClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Common.HwControl.UI
{
    internal class RichMessageBox : RichTextBox
    {

        //// see http://social.msdn.microsoft.com/Forums/vstudio/en-US/ba339154-95b7-4e13-a2c0-32593cadb984/richtextbox-vscrollbar?forum=vbgeneral
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        private const uint WM_VSCROLL = 0x115;
        private const uint SB_LINEUP = 0;
        private const uint SB_LINEDOWN = 1;
        public const string DisplayText = "This box displays notifications and errors.";
        public bool Selectable { get; set; }

        //private const uint SB_PAGEUP = 2;
        //private const uint SB_PAGEDOWN = 3;
        //private const uint SB_TOP = 6;
        //private const uint SB_BOTTOM = 7;
        //private const uint SB_ENDSCROLL = 8;
        public RichMessageBox()
        {
            InitializeComponent();
            MouseWheel += RichMessagesBox_MouseWheel;
            Text = DisplayText;
            ResetText();
        }

        public bool IsEmpty() => Text == DisplayText || string.IsNullOrEmpty(Text);

        public override void ResetText()
        {
            Text = DisplayText;
            ForeColor = SystemColors.GrayText;
            Font = new Font(Font, FontStyle.Italic);
            Selectable = false;
            HideSelection = true;
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            if (Selectable)
            {
                base.OnSelectionChanged(e);
            }
            else
            {
                SelectionLength = 0;
            }
        }

        private void RichMessagesBox_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                SendMessage(Handle, WM_VSCROLL, (IntPtr)(e.Delta < 0 ? SB_LINEDOWN : SB_LINEUP), IntPtr.Zero);
                //if (e.Delta < 0)
                //{
                //    // Scrolls down
                //    SendMessage(Handle, WM_VSCROLL, (IntPtr)SB_LINEDOWN, IntPtr.Zero);
                //}
                //else
                //{
                //    // Scrolls up
                //    SendMessage(Handle, WM_VSCROLL, (IntPtr)SB_LINEUP, IntPtr.Zero);
                //}
            }
            catch { }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RichMessageBox
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ReadOnly = true;
            this.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.ResumeLayout(false);

        }
    }
}