using Common.HwControl.Model;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.UI.Controls;
using Common.HwControl.Model.Utilities;
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
using static Common.HwControl.Model.JsonConfigParser.DataObjects.AnalogChannel;
using DriversWrapper.AIO;

namespace Common.HwControl.UI.Groupers
{
    public partial class DigitalInputGrouper : GrouperBase//, IGrouperControl
    {
        public DigitalInputGrouper() : base(Get, DriverDIO.SetMainPanelState)
            => InitializeComponent();

        internal override void Initialize(CommonHwController appModel)
            => Initialize<DiscreteChannel, DigitalInputCtrl>(
                appModel.DiscreteDevices.ChannelsDataCollection
                    .Where(channel => channel.Direction == Direction.Input));
    }
}
