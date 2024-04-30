using Common.HwControl.Model;
using Common.HwControl.UI.Controls;
using Common.HwControl.UI.Groupers;
using System;
using System.Threading.Tasks;

namespace Common.HwControl.UI.Panels
{
    internal class AnalogInputPanel : HardwarePanel
    {

        public AnalogInputPanel() : base()
        { }

        internal override void InitPanelsControls(CommonHwController appModel)
        {
            base.InitPanelsControls(appModel);
            AppModel.AnalogDevices.AIControlsUpdated += UpdateAIsCtrls;
            ((AnalogInputGrouper)ParentGrouper).ContinousUpdateDisabled += OnStoppingUpdatingContinuously;
        }
        //continuously 
        private void OnStoppingUpdatingContinuously(object sender, EventArgs e)
            => AppModel.AnalogDevices.OpenClosedActivisionRelays();

        internal override void UnregisterAllEvents()
            => AppModel.AnalogDevices.AIControlsUpdated -= UpdateAIsCtrls;

        private async void UpdateAIsCtrls(object sender, (string signalName, decimal value) args)
        {
            AnalogInputControl ctrlToAdd = FindControlToUpdate<AnalogInputControl>(args.signalName);
            await ctrlToAdd.UpdateControl(args.value);
        }
    }
}