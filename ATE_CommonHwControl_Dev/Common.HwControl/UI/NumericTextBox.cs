using Common.HwControl.Model.Utilities;
using Newtonsoft.Json.Linq;
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
    public partial class NumericTextBox : UserControl
    {
        public NumericTextBox() => InitializeComponent();

        public event EventHandler ValueChanged { add => textBox.TextChanged += value; remove => textBox.TextChanged -= value; }

        public event KeyEventHandler EnterPressed;

        public event EventHandler<string> IntervalUpdated;
        public new string Text { get => textBox.Text; set => textBox.Text = value; }

        [Description("The numeric value to be displayed"), Category("Data")]
        public decimal Value
        {
            get => Math.Round(decimal.Parse(textBox.Text), DecimalPlaces);// TODO: updates interval, turns on and off periodic updating
            set => textBox.Text = Math.Round(value, DecimalPlaces).ToString();
        }

        [Description("Number of digits to display after the decimal point."), Category("Data")]
        public int DecimalPlaces { get; set; } = 0;

        [Description("Weather the control accepts input or not."), Category("Data")]
        public bool ReadOnly { get => textBox.ReadOnly; set => textBox.ReadOnly = value; }

        public int Minimum { get; set; }

        private void TextBox_TextChanged(object sender, EventArgs e) => IntervalUpdated?.Invoke(this, textBox.Text);

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterPressed?.Invoke(this, e); // Bubble up the event to PeriodUpdater
            }
        }
    }
}