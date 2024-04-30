using Common.HwControl.Model;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.Model.Utilities;
using Common.HwControl.UI.Controls;
using DriversWrapper.AIO;
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
    public partial class AnalogInputGrouper : GrouperBase//, IGrouperControl
    {
        public event EventHandler ContinousUpdateDisabled;

        public AnalogInputGrouper() : base(Get, DriverAIO.SetMainPanelState)
            => InitializeComponent();

        internal override void Initialize(CommonHwController appModel)
            => Initialize<AnalogChannel, AnalogInputControl>(
                appModel.AnalogDevices.ChannelsDataCollection
                    .Where(channel
                        => channel.Direction == AnalogDirection.Input && channel.InChannelNum.HasValue));

        protected override void PeriodUpdaterControl1_CheckedChanged(object sender, EventArgs e)
        {
            base.PeriodUpdaterControl1_CheckedChanged(sender, e);
            if (!IsUpdating)
            {
                ContinousUpdateDisabled?.Invoke(default, EventArgs.Empty);
            }
        }

    }
}
