using Common.HwControl.UI.Controls;
using Common.HwControl.Model;
using Common.HwControl.UI.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace Common.HwControl.UI.Panels
{
    internal class DigitalInputPanel : HardwarePanel
    {
        public DigitalInputPanel() : base()
        { }

        internal override void InitPanelsControls(CommonHwController appModel)
        {
            base.InitPanelsControls(appModel);
            AppModel.DiscreteDevices.DIsUpdated += UpdateDIsCtrls;
        }

        internal override void UnregisterAllEvents() => AppModel.DiscreteDevices.DIsUpdated -= UpdateDIsCtrls;

        private void UpdateDIsCtrls(object sender, (string signalName, bool value) args)
            => FindAndUpdate<DigitalInputCtrl, bool>(args.signalName, args.value);
    }
}