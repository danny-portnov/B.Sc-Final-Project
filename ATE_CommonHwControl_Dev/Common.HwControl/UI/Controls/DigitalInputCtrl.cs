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

        internal Task UpdateControl(Color? ledColor)
        {
            bool? value;
            if (ledColor == default)
            {
                try
                {
                    value = AppModel.DiscreteDevices.GetDiscrete(ctrlLabel1.Text);
                }
                catch
                {
                    return Task.CompletedTask; // Exception already printed at driver level.
                }
                ledColor = value.Value ? Color.LightGreen : Color.Black;
            }
            ledDisplay.InvokeIfNeeded(() => ledDisplay.Color = ledColor.Value);
            return Task.CompletedTask;
        }

        internal override Task UpdateControl() => UpdateControl(default);

        protected void GetButton_CheckedChanged(object sender, EventArgs e)
            => UpdateControl(getButton.CheckState == CheckState.Checked ? default : Color.LightGray);
    }
}
