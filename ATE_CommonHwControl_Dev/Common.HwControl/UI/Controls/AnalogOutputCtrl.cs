using System;
using System.Windows.Forms;
using AppInterfaces;
using Common.HwControl.Model;
using Common.HwControl.UI.Panels;
using Common.HwControl.UI.Utility;

namespace Common.HwControl.UI.Controls
{
    /// <summary>
    /// A controller class for an DIO signal.
    /// </summary>
    internal partial class AnalogOutputCtrl : HardwareControl
    {

        internal override bool Checked { get => setToggle.Checked; set => setToggle.Checked = value; }

        public AnalogOutputCtrl(string labelText, AnalogOutputPanel parentPanel) : base(parentPanel)
        {
            InitializeComponent();
            FormatLabel(labelText, ctrlLabel1, setToggle.Location.X - ctrlLabel1.Location.X);
        }

        protected async void SetButton_CheckedChanged(object sender, EventArgs e)
            => await AppModel.AnalogDevices.SetDACVoltageAsync(ControlName,
                                                               ((CheckBox)sender).Checked);
    }
}