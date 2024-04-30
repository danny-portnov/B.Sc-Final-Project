using Common.HwControl.Model;
using Common.HwControl.UI.Panels;
using Common.HwControl.UI.Controls;
using Common.HwControl.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Common.HwControl.UI.Panels
{
    internal class DigitalOutputPanel : HardwarePanel
    {
        public DigitalOutputPanel() : base()
        { }

        internal override void InitPanelsControls(CommonHwController appModel)
        {
            base.InitPanelsControls(appModel);
            AppModel.DiscreteDevices.DOsUpdated += UpdateDOsCtrls;
        }

        internal override void UnregisterAllEvents() => AppModel.DiscreteDevices.DOsUpdated -= UpdateDOsCtrls;

        private void UpdateDOsCtrls(object sender, (string signalName, bool isSet) args)
        {
            DigitalOutputCtrl ctrlToAdd = FindControlToUpdate<DigitalOutputCtrl>(args.signalName);
            ctrlToAdd.UpdateControl(args.isSet);
        }

        /// <summary>
        /// Does nothing (no need to activate output signals more than once)
        /// </summary>
        protected override Task UpdateControls() => Task.CompletedTask;
    }
}