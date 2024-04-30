using DriversWrapper.Gps;
using MetroFramework.Controls;
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
    public class CustomMetroTextBox : MetroTextBox
    {
        private readonly Label xLabel;
        public bool ButtonTextClear { get; set; } = true;

        public CustomMetroTextBox()
        {
            Resize += PositionX;

            TextChanged += ShowHideX;

            xLabel = new Label()
            {
                AutoSize = true,
                Text = "X",
                ForeColor = Color.Gray,
                Visible = false,
                Font = new Font("Tahoma", 10F),
                Cursor = Cursors.Arrow,
                BackColor = Color.White
            };

            Controls.Add(xLabel);
            xLabel.Click += (ss, ee) => { ((Label)ss).Visible = false; Text = string.Empty; };
            xLabel.BringToFront();
        }
        private void ShowHideX(object sender, EventArgs e) 
            => xLabel.Visible = ButtonTextClear && !string.IsNullOrEmpty(Text);
        private void PositionX(object sender, EventArgs e)
            => xLabel.Location = new Point(Width - 19, ((Height - xLabel.Height) / 2) - 3);
    }
}
