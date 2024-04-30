using Common.HwControl.Model;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.Model.Utilities;
using Common.HwControl.UI.Panels;
using System.Drawing;
using System;
using System.Windows.Forms;
using Common.HwControl.UI.Controls;
using System.Threading.Tasks;

namespace Common.HwControl.UI.Groupers
{
    internal partial class PowersupplyControl : HardwareControl
    {
        internal int PowersupplyControlHeight { get => Height; }

        internal override bool Checked { get => toggleOutput.Checked; set => toggleOutput.Checked = value; }
        public PowersupplyControl(string powersupplyName, HardwarePanel parentPanel, PowerSupplyParams psParams)
            : base(parentPanel)
        {
            InitializeComponent();
            ControlName = powersupplyName;
            psGrouper.GroupTitle = powersupplyName;
            setCurrentLimit.Maximum = psParams.CurrentLimit;
            setVoltage.Maximum = psParams.VoltageLimit;
            UpdateControl();
        }

        internal override Task UpdateControl()
        {
            if (!string.IsNullOrEmpty(Parent?.Name))
            {
                this.InvokeIfNeeded(() =>
                {
                    PowerSupplyState state = AppModel.PowerSupplies.GetPowerState(ControlName);
                    getOutput.Color = state == PowerSupplyState.On ? Color.LightGreen : Color.Black;
                    toggleOutput.CheckedChanged -= ToggleOutput_CheckedChanged; // Update appearance
                    toggleOutput.Checked = state == PowerSupplyState.On;
                    toggleOutput.CheckedChanged += ToggleOutput_CheckedChanged;
                    getVoltage.Text = $"{AppModel.PowerSupplies.GetActualVoltage(ControlName):00.00}V";
                    getCurrent.Text = $"{AppModel.PowerSupplies.GetActualCurrent(ControlName):00.00}A";
                });
            }
            return Task.CompletedTask;
        }

        private void ToggleOutput_CheckedChanged(object sender, EventArgs e)
            => AppModel.PowerSupplies.SetPowerState(ControlName, ((CheckBox)sender).Checked.ToPowerState());

        private void SetVoltage_ValueChanged(object sender, EventArgs e)
            => AppModel.PowerSupplies.SetVoltage(ControlName, (double)((NumericUpDown)sender).Value);

        private void SetCurrent_ValueChanged(object sender, EventArgs e)
            => AppModel.PowerSupplies.SetCurrentLimit(ControlName, (double)((NumericUpDown)sender).Value);

        //void IGrouperControl.UnregisterAllEvents()
        //{
        //    powersupplyPanel.UnregisterAllEvents();
        //    //Powersupply.PowersupplyCtrlInitialized -= OnPsInitDone;
        //}
    }
}