using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.HwControl.Model;
using Common.HwControl.Model.Drivers;
using Common.HwControl.UI.Panels;
using Common.HwControl.UI.Utility;

namespace Common.HwControl.UI.Controls
{

    /// <summary>
    /// A controller class for an DIO signal.
    /// </summary>
    internal partial class DigitalOutputCtrl : HardwareControl
    {

        internal override bool Checked { get => setToggle.Checked; set => setToggle.Checked = value; }

        public DigitalOutputCtrl(string labelText, HardwarePanel parentPanel) : base(parentPanel)
        {
            InitializeComponent();
            FormatLabel(labelText, ctrlLabel1, setToggle.Location.X - ctrlLabel1.Location.X);
        }

        /// <summary>
        /// <inheritdoc cref="HardwareControl()"/>
        /// </summary>
        protected DigitalOutputCtrl() => InitializeComponent();


        protected virtual void SetToggle_CheckedChanged(object sender, EventArgs e)
            => AppModel.DiscreteDevices.SetDiscrete(ctrlLabel1.Text, setToggle.CheckState == CheckState.Checked);

        internal void UpdateControl(bool isChecked)
        {
            setToggle.CheckedChanged -= SetToggle_CheckedChanged;
            this.InvokeIfNeeded(() =>
            {
                setToggle.Checked = isChecked;
            });
            setToggle.CheckedChanged += SetToggle_CheckedChanged;
        }
    }
}