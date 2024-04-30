using System;
using System.Collections.Generic;
using Common.HwControl.Model.Utilities;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.HwControl.Model;
using DriversWrapper.AIO;
using DriversWrapper.PS;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.UI.Panels;

namespace Common.HwControl.UI.Groupers
{
    public partial class PowerSuppliesGrouper : GrouperBase
    {
        public PowerSuppliesGrouper() : base(Get,
            _ => DriverPS.SetMainPanelState(_))
            => InitializeComponent();

        internal override void Initialize(CommonHwController appModel)
            => Initialize<PowerSupplyParams, PowersupplyControl>(
                appModel.PowerSupplies.ChannelsDataCollection);

        protected override void CreateControl<TChannel, TControl>(KeyValuePair<string, TChannel> control)
            => Activator.CreateInstance(typeof(TControl), control.Key, HardwarePanel, control.Value);
    }
}
