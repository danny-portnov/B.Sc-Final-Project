using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppInterfaces;
using Common.HwControl.Model;
using Common.HwControl.Model.Drivers;
using Common.HwControl.UI.Panels;
using Common.HwControl.UI.Utility;
using Newtonsoft.Json.Linq;

namespace Common.HwControl.UI.Controls
{

    /// <summary>
    /// A controller class for an DIO signal.
    /// </summary>
    internal partial class DigitalInputCtrl : HardwareControl
    {

        internal override bool Checked { get => getButton.Checked; set => getButton.Checked = value; }

        public DigitalInputCtrl(string labelText, DigitalInputPanel parentPanel) : base(parentPanel)
        {
            InitializeComponent();
            FormatLabel(labelText, ctrlLabel1, ledDisplay.Location.X - ctrlLabel1.Location.X + ledDisplay.Size.Width - 50);
        }

        private void UpdateControl(Color ledColor) 
            => ledDisplay.InvokeIfNeeded(() => ledDisplay.Color = ledColor);

        internal override void UpdateControl(object value)
            => UpdateControl((bool)value ? Color.LightGreen : Color.Black);

        internal override Task UpdateControl()
        {
            AppModel.DiscreteDevices.GetDiscrete(ctrlLabel1.Text);
            return Task.CompletedTask;
        }

        protected async void GetButton_CheckedChanged(object sender, EventArgs e)
        {
            if (getButton.Checked)
            {
                await UpdateControl();
            }
            else
            {
                UpdateControl(Color.LightGray);
            }
        }
    }
}
