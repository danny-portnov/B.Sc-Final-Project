using AppInterfaces;
using Common.HwControl.Model;
using Common.HwControl.Model.Utilities;
using Common.HwControl.UI.Controls;
using Common.HwControl.UI.Groupers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.HwControl.UI.Panels
{
    internal class PowersuppliesPanel : HardwarePanel
    {
        public event EventHandler InitPanelsFinished;
        public PowersuppliesPanel() : base()
        { }

        internal override void InitPanelsControls(CommonHwController appModel)
        {
            base.InitPanelsControls(appModel);
            AppModel.PowerSupplies.PowerSupplyUpdated += OnPowerSupplyUpdate;
            InitPanelsFinished?.Invoke(this, EventArgs.Empty);
        }

        internal override void UnregisterAllEvents() => AppModel.PowerSupplies.PowerSupplyUpdated -= OnPowerSupplyUpdate;

        private void OnPowerSupplyUpdate(object sender, string powersupplyName)
            => FindAndUpdate<PowersupplyControl>(powersupplyName);

        protected override void SortControlsByAlphabet()
            => AddToPanel(((PowersupplyControl)HardwareControls.First()).PowersupplyControlHeight);
    }
}