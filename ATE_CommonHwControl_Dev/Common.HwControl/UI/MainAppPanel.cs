using AppInterfaces;
using Common.HwControl.Model;
using Common.HwControl.Model.Utilities;
using Common.HwControl.UI.Panels;
using Common.HwControl.UI.Groupers;
using Common.HwControl.UI.Utility;
using DriversWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.HwControl.Model.Drivers;

namespace Common.HwControl.UI
{
    public class MainAppPanel : Panel
    {
        internal CommonHwController AppModel { get; private set; } = CommonHwController.GetInstance();
        private List<HardwarePanel> PanelsList { get; set; }

        public MainAppPanel() : base()
        {
            AppModel.ModelDoneEvent += OnModelDone;
            Disposed += OnDispose;
        }

        private void OnDispose(object sender, EventArgs e)
            => PanelsList?.ForEach(panel => panel.UnregisterAllEvents());

        internal async void OnModelDone(object sender, EventArgs e)
        {
            await Task.Run(AppModel.InitializeDevices);
            NotificationPrinter.UpdateStatus("Loading controls dynamically...");
            this.InvokeIfNeeded(() =>
            {
                IEnumerable<GrouperBase> groupers
                    = ControlsExtractor.GetAllCtrlsOfTypeT(this,
                                                           new List<UserControl>(),
                                                           true).OfType<GrouperBase>();

                foreach (GrouperBase grouper in groupers) //Adds to each grouper its controls
                {
                    grouper.Initialize(AppModel);
                }
                PanelsList = ControlsExtractor.GetAllCtrlsOfTypeT(this, new List<HardwarePanel>(), true);
                foreach (HardwarePanel panel in PanelsList) // Has to be after initializing all controls in the groupers!
                {
                    panel.InitPanelsControls(AppModel);
                }
                Devices.ActivateOnStartUp();
                foreach (IDriverBase device in Devices.DevicesCollection.Values) //Prints mode of each device
                {
                    string mode = device.Simulation ? "simulation" : "operational";
                    NotificationPrinter.Print($"{device.DeviceName} is in {mode} mode");
                }
                NotificationPrinter.Print($"MuxBox is {(AppModel.IsMuxBoxEnabled ? "enabled" : "disabled")}");
                NotificationPrinter.UpdateStatus("Application is ready to use.");
            });
        }
    }

}
