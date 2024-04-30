using Common.HwControl.Model;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.UI.Controls;
using Common.HwControl.Model.Utilities;
using DriversWrapper.AIO;
using DriversWrapper.DIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.HwControl.UI.Groupers
{
    public partial class DigitalOutputGrouper : GrouperBase
    {
        public DigitalOutputGrouper() : base(Set, DriverDIO.SetMainPanelState)
            => InitializeComponent();

        internal override void Initialize(CommonHwController appModel)
            => Initialize<DiscreteChannel, DigitalOutputCtrl>(
                appModel.DiscreteDevices.ChannelsDataCollection
                    .Where(channel => channel.Direction == Direction.Output));
    }
}
