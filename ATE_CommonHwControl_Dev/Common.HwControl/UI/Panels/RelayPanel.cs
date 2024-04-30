using Common.HwControl.Model;
using Common.HwControl.UI.Panels;
using Common.HwControl.UI.Controls;
using Common.HwControl.Model.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using System.Threading.Tasks;

namespace Common.HwControl.UI.Panels
{
    internal class RelayPanel : HardwarePanel
    {
        public RelayPanel() : base()
        { }


        public Location RelaysLocation { get; set; }
        internal override void InitPanelsControls(CommonHwController appModel)
        {
            base.InitPanelsControls(appModel);
            AppModel.Relays.RelaysUpdated += UpdateRelaysCtrls;
        }

        internal override void UnregisterAllEvents() => AppModel.Relays.RelaysUpdated -= UpdateRelaysCtrls;

        private void UpdateRelaysCtrls(object sender, (Location location, bool isSet) args)
        {
            if (args.location != RelaysLocation) //Checks that its the correct panel
            {
                return;
            }
            RelayControl ctrlToAdd = FindControl<RelayControl>((string)sender);
            ctrlToAdd.UpdateControl(args.isSet);
        }

        /// <summary>
        /// Doesn't need to close relays repeatably.
        /// </summary>
        protected override Task UpdateControls() => Task.CompletedTask;
    }
}