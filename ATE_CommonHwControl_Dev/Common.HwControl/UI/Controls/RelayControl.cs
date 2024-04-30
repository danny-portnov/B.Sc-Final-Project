using System;
using System.Windows.Forms;
using Common.HwControl.Model;
using Common.HwControl.Model.Drivers;
using Common.HwControl.UI.Controls;
using Common.HwControl.UI.Panels;
using Common.HwControl.Model.Utilities;

namespace Common.HwControl.UI
{
    /// <summary>
    /// A controller for a relay.
    /// </summary>
    internal class RelayControl : DigitalOutputCtrl
    {
        public RelayControl(string labelText, RelayPanel parentPanel)
            : base(labelText, parentPanel) { }


        protected override void SetToggle_CheckedChanged(object sender, EventArgs e)
            => AppModel.Relays.SetRelay(ControlName, Checked.ToRelayState());
    }
}