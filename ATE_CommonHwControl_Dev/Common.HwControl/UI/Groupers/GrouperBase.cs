using AppInterfaces;
using CodeVendor.Controls;
using Common.HwControl.Model;
using Common.HwControl.Model.JsonConfigParser;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.UI.Controls;
using Common.HwControl.UI.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using DriversWrapper.DIO;
using DriversWrapper.PS;
using DriversWrapper.AIO;
using Common.HwControl.UI.Utility;

namespace Common.HwControl.UI.Groupers
{
    public partial class GrouperBase : UserControl
    {
        protected const string Get = "Get All";
        protected const string Set = "Set All";
        private readonly Action<int> _driverAction;
        protected bool IsUpdating { get => periodUpdaterControl1.Checked; }
        private HardwarePanel _hardwarePanel;
        protected HardwarePanel HardwarePanel => _hardwarePanel;
        protected GrouperBase() => InitializeComponent();

        protected GrouperBase(string buttonText, Action<int> driverAction) : this()
        {
            rateButton1.Text = buttonText;
            _driverAction = driverAction;
        }

        internal virtual void Initialize(CommonHwController appModel)
            => throw new NotImplementedException();

        protected void Initialize<TChannel, TControl>(Dictionary<string, TChannel> channelsDataCollection)
            where TChannel : class, IDaqChannelBase
            where TControl : HardwareControl
        {
            if (!CheckIfPanelNeeded(channelsDataCollection))
            {
                return;
            }
            _hardwarePanel = (HardwarePanel)controlsPanel.Controls[0]; // Has to be after constructor
            HardwarePanel.ParentGrouper = this;
            foreach (KeyValuePair<string, TChannel> control in channelsDataCollection)
            {
                CreateControl<TChannel, TControl>(control);
            }
        }

        protected bool CheckIfPanelNeeded<TChannel>(Dictionary<string, TChannel> channelsDataCollection)
            where TChannel : class, IDaqChannelBase
        {
            if (channelsDataCollection.Any())
            {
                grouper.Enabled = true;
                return true;
            }
            Hide();
            return false;
        }

        protected virtual void CreateControl<TChannel, TControl>(KeyValuePair<string, TChannel> control)
            where TChannel : class, IDaqChannelBase
            where TControl : HardwareControl
            => Activator.CreateInstance(typeof(TControl), control.Key, HardwarePanel);

        private void DriverPanelBox_Click(object sender, EventArgs e)
            => _driverAction((int)DriverPanelUiState.GUI_STATE_NORMAL);

        protected virtual void PeriodUpdaterControl1_CheckedChanged(object sender, EventArgs e)
        {
            HardwarePanel.EnableContinuousUpdate = periodUpdaterControl1.Checked;
            HardwarePanel.UpdateInternal = periodUpdaterControl1.IntervalValue;
        }

        protected virtual void RateButton1_CheckedChanged(object sender, EventArgs e)
            => HardwarePanel.CheckAllControls(((CheckBox)sender).Checked);
    }


}
