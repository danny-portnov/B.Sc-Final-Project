using Common.HwControl.Model;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.Model.Utilities;
using Common.HwControl.UI.Controls;
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
using static Common.HwControl.Model.JsonConfigParser.DataObjects.AnalogChannel;

namespace Common.HwControl.UI.Groupers
{
    public partial class AnalogOutputGrouper : GrouperBase//, IGrouperControl
    {
        public AnalogOutputGrouper() : base(Set, DriverAIO.SetMainPanelState)
            => InitializeComponent();

        internal override void Initialize(CommonHwController appModel)
            => Initialize<AnalogChannel, AnalogOutputCtrl>(
                appModel.AnalogDevices.ChannelsDataCollection.Where(
                    channel => channel.Direction == AnalogDirection.Output
                        && channel.OutChannelNum.HasValue));
    }
}
