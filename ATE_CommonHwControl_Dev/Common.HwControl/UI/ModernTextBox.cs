using Common.HwControl.Model;
using Common.HwControl.Model.Utilities;
using DriversWrapper.Gps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.HwControl.UI
{
    public partial class ModernTextBox : UserControl
    {
        [Description("Show 'X' button to clear the text box")]
        public bool ButtonTextClear { get; set; } = true;
        private readonly Label xLabel;
        public ModernTextBox()
        {
            InitializeComponent();
            Resize += PositionX;
            richMessagesBox.TextChanged += ShowHideX;

            xLabel = new Label()
            {
                AutoSize = true,
                Text = "X",
                ForeColor = Color.Gray,
                Visible = false,
                Font = new Font("Tahoma", 10F),
                //BackColor = Color.White,
                Cursor = Cursors.Arrow
            };

            Controls.Add(xLabel);
            xLabel.Click += OnClearTextBox;
            xLabel.BringToFront();
            CommonHwExceptionHandler.HwExeptionRaised += (message) => OnPrintToMessagesBox(message, true);
            NotificationPrinter.printNotification += (message) => OnPrintToMessagesBox(message, false);
            NotificationPrinter.clearTextBox += OnClearTextBox;
        }

        private void OnClearTextBox(object sender, EventArgs e)
        {
            xLabel.Visible = false;
            richMessagesBox.ResetText();
        }

        private void OnPrintToMessagesBox(string message, bool isException)
        {
            this.InvokeIfNeeded(() =>
            {
                if (!IsDisposed)
                {
                    AppendColoredText(message, isException ? Color.Red : Color.Black);
                }
                if (isException && !Visible) // If form isn't visible, show messages about exceptions
                {                            // In addition to printing to the screen.
                    MessageBox.Show(message);
                }
            });
        }

        private void ShowHideX(object sender, EventArgs e)
            => xLabel.Visible = ButtonTextClear && !richMessagesBox.IsEmpty();
        private void PositionX(object sender, EventArgs e)
            => xLabel.Location = new Point(Width - 19, (Height - xLabel.Height) / 2 - 3);

        private void ModernTextBox_SizeChanged(object sender, EventArgs e)
        {

        }

        internal void AppendColoredText(string text, Color color)
        {
            if (richMessagesBox.Text == RichMessageBox.DisplayText)
            {
                richMessagesBox.Text = string.Empty;
            }
            int startIndex = richMessagesBox.TextLength;
            richMessagesBox.Font = new Font(richMessagesBox.Font, FontStyle.Regular);
            richMessagesBox.Selectable = true;
            richMessagesBox.HideSelection = false;
            richMessagesBox.ForeColor = Color.Black;
            richMessagesBox.AppendText(text);
            richMessagesBox.SelectionStart = startIndex;
            richMessagesBox.SelectionLength = text.Length;
            richMessagesBox.SelectionColor = color;
            richMessagesBox.SelectionStart = richMessagesBox.TextLength;
            richMessagesBox.SelectionLength = 0;
        }
    }
}
