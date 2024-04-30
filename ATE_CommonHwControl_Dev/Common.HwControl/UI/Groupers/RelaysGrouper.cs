using Common.HwControl.Model;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.Model.Utilities;
using Common.HwControl.UI.Panels;
using Common.HwControl.UI.Utility;
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
    public partial class RelaysGrouper : GrouperBase
    {
        private readonly List<bool> _buttonStates = new();
        public RelaysGrouper() : base(Set, DriverDIO.SetMainPanelState)
        {
            InitializeComponent();
            _buttonStates.AddRange(Enumerable.Repeat(false, relaysTabControl.TabPages.Count));
        }

        internal override void Initialize(CommonHwController appModel)
        {
            Dictionary<string, RelayChannel> relaysData = appModel.Relays.ChannelsDataCollection;
            if (!CheckIfPanelNeeded(relaysData))
            {
                return;
            }
            List<RelayPanel> panels = ControlsExtractor.GetAllCtrlsOfTypeT(this, new List<RelayPanel>()); // get all relays panels 
            foreach (KeyValuePair<string, RelayChannel> relay in relaysData)
            {
                RelayPanel relayPanel = panels.First(panel => panel.RelaysLocation == relay.Value.Location);
                _ = new RelayControl(relay.Key, relayPanel);
            }
        }

        protected override void RateButton1_CheckedChanged(object sender, EventArgs e)
        {
            RelayPanel selectedPanel = relaysTabControl.SelectedTab.Controls.OfType<RelayPanel>().ElementAt(0);
            _buttonStates[relaysTabControl.SelectedIndex] = rateButton1.Checked;
            selectedPanel.CheckAllControls(((CheckBox)sender).Checked);
        }

        private void RelaysTabControl_Selected(object sender, TabControlEventArgs e)
        {
            rateButton1.CheckedChanged -= RateButton1_CheckedChanged;
            rateButton1.Checked = _buttonStates[relaysTabControl.SelectedIndex];
            rateButton1.CheckedChanged += RateButton1_CheckedChanged;
        }
    }
}
