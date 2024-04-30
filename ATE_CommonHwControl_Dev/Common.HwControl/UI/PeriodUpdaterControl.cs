using Common.HwControl.Model.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Common.HwControl.UI
{
    public partial class PeriodUpdaterControl : UserControl
    {
        private string _lastText;
        public PeriodUpdaterControl()
        {
            InitializeComponent();
            // Registers in case an enter is pressed on the interval box
            intervalNumericBox.EnterPressed += IntervalNumericBox_EnterPressed;
            intervalNumericBox.IntervalUpdated += IntervalNumericBox_IntervalUpdated;
            _lastText = intervalNumericBox.Text;
        }

        private void IntervalNumericBox_IntervalUpdated(object sender, string value)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                _lastText = value;
            }
            intervalNumericBox.Text = _lastText;
        }

        private int _minimum = Constants.LowestUpdateInterval;
        public event EventHandler ValueChanged
        {
            add => intervalNumericBox.ValueChanged += value; remove => intervalNumericBox.ValueChanged -= value;
        }
        public event EventHandler CheckedChanged
        {
            add => isPeriodicCheckBox.CheckedChanged += value; remove => isPeriodicCheckBox.CheckedChanged -= value;
        }

        private void IntervalNumericBox_EnterPressed(object sender, KeyEventArgs e) => isPeriodicCheckBox.Checked = true;

        public bool Checked { get => isPeriodicCheckBox.Checked; set => isPeriodicCheckBox.Checked = value; }

        public decimal IntervalValue { get => intervalNumericBox.Value; set => intervalNumericBox.Value = value; }

        [Description("Indicates the minimum value for the control. Has to be greater than 1."), Category("Data")]
        public int Minimum
        {
            get => _minimum;
            set
            {
                if (value >= Constants.LowestUpdateInterval)
                {
                    _minimum = value;
                }
            }
        }
        private void PeriodUpdater_Load(object sender, EventArgs e)
        {
            if (DesignMode) // Used in designer mode
            {
                intervalNumericBox.Value = _minimum;
            }
        }

        private void IntervalNumericBox_ValueChanged(object sender, EventArgs e) => isPeriodicCheckBox.Checked = false;

        private void IsPeriodicCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (decimal.Parse(intervalNumericBox.Text) < Constants.LowestUpdateInterval)
            {
                isPeriodicCheckBox.Checked = false;
            }
        }
    }
}
