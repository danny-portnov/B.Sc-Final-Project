using Common.HwControl.UI.Groupers;
using Common.HwControl.UI.Panels;
using Common.HwControl.UI.Utility;
using System;
using System.Threading.Tasks;

namespace Common.HwControl.UI.Controls
{
    /// <summary>
    /// A controller class for an AIO signal.
    /// </summary>
    internal partial class AnalogInputControl : HardwareControl
    {
        internal override bool Checked { get => getButton.Checked; set => getButton.Checked = value; }


        public AnalogInputControl(string labelText, AnalogInputPanel parentPanel) : base(parentPanel)
        {
            InitializeComponent();
            FormatLabel(labelText, ctrlLabel1, displayValueBox.Location.X - ctrlLabel1.Location.X);
        }

        internal async Task UpdateControl(decimal? value)
        {
            if (!value.HasValue)
            {
                try
                {
                    value = await AppModel.AnalogDevices.GetSignalAveregeValueAsync(ctrlLabel1.Text,
                    ParentPanel.EnableContinuousUpdate);
                }
                catch { }
            }
            displayValueBox.InvokeIfNeeded(() => { displayValueBox.Value = value.Value; });
        }

        internal override async Task UpdateControl()
            => await UpdateControl(default);

        protected async void GetButton_CheckedChanged(object sender, EventArgs e)
        {
            if (getButton.Checked)
            {
                await UpdateControl();
            }
            else
            {
                AppModel.AnalogDevices.OpenActivationRelay(ctrlLabel1.Text);
                await UpdateControl(default);
            }
            displayValueBox.Enabled = getButton.Checked;
        }
    }
}