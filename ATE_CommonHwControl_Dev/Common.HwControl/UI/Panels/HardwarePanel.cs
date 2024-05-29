using AppInterfaces;
using Common.HwControl.Model;
using Common.HwControl.Model.Utilities;
using Common.HwControl.UI.Controls;
using Common.HwControl.UI.Groupers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Common.HwControl.UI.Panels
{
    public partial class HardwarePanel : UserControl
    {
        public event EventHandler EnableUpdateChanged;
        public bool EnableContinuousUpdate
        {
            set
            {
                scanTimer.Enabled = value;
                EnableUpdateChanged?.Invoke(this, EventArgs.Empty);
            }
            get => scanTimer.Enabled;
        }
        internal decimal UpdateInternal { set => scanTimer.Interval = (int)value; get => scanTimer.Interval; }
        internal CommonHwController AppModel { get; private set; }
        protected Timer ScanTimer { get => scanTimer; }
        protected HashSet<HardwareControl> CtrlsToBeUpdated { get; } = new();
        internal GrouperBase ParentGrouper { get; set; }
        internal HashSet<HardwareControl> HardwareControls { get; private set; }

        public HardwarePanel()
        {
            InitializeComponent();
            HorizontalScroll.Enabled = false;
            HorizontalScroll.Visible = false;
            HorizontalScroll.Maximum = 0;
            AutoScroll = true;
        }

        internal virtual void InitPanelsControls(CommonHwController appModel)
        {
            AppModel = appModel;
            HardwareControls = new HashSet<HardwareControl>(Controls.Cast<HardwareControl>());
            if (Controls.Count > 0)
            {
                SortControlsByAlphabet();
            }
        }

        /// <summary>
        /// By default does nothing. If an inherited class registers to an event, it has to override it.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        internal virtual void UnregisterAllEvents()
        { }

        /// <summary>
        /// Adds a <see cref="Control"/> to the panel.
        /// </summary>
        protected void AddToPanel(int spacing)
        {
            Controls.Clear();
            int verticalSpace = 0;
            foreach (Control ctrl in HardwareControls.OrderBy(x => x.ControlName))
            {
                Controls.Add(ctrl);
                //after the first control, every other control will be spaced evenly
                verticalSpace = Controls.Count == 1 ? verticalSpace : verticalSpace + spacing;
                ctrl.Location = new Point(1, verticalSpace);
            }
        }

        //Todo: make this regex generic (i.e. arrange by numbers if contained)
        protected virtual void SortControlsByAlphabet()
            => AddToPanel(Constants.Spacing);

        private void MyPanel_Paint(object sender, PaintEventArgs e)
            => ControlPaint.DrawBorder(e.Graphics,
                                       ClientRectangle,
                                       Color.LightGray,
                                       ButtonBorderStyle.Solid);

        protected virtual async Task UpdateControls()
        {
            foreach (HardwareControl ctrl in CtrlsToBeUpdated.ToHashSet())
            {
                if (string.IsNullOrEmpty(ctrl.ControlName))
                {
                    return;
                }
                if (!ctrl.Checked)
                {
                    CtrlsToBeUpdated.Remove(ctrl);
                    continue;
                }
                try //Only remove after updateing gui!
                {
                    await ctrl.UpdateControl();
                }
                catch { return; }
            }
        }

        internal void CheckAllControls(bool isChecked)
        {
            foreach (HardwareControl control in HardwareControls)
            {
                control.Checked = isChecked;
            }
        }

        private async void OnTimerTick(object sender, EventArgs e)
        {
            try
            {
                await UpdateControls();
            }
            catch
            {
                scanTimer.Enabled = false;
                throw;
            }
        }
        /// <summary>
        /// Finds control to be updated and adds it to <see cref="CtrlsToBeUpdated"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="signalName"></param>
        /// <returns></returns>
        protected T FindControlToUpdate<T>(string signalName) where T : HardwareControl
        {
            T ctrlToAdd = FindControl<T>(signalName);
            CtrlsToBeUpdated.Add(ctrlToAdd);
            return ctrlToAdd;
        }

        protected void FindAndUpdate<TControl, TValue>(string signalName, TValue value)
            where TControl : HardwareControl
        {
            TControl ctrlToAdd = FindControlToUpdate<TControl>(signalName);
            ctrlToAdd.UpdateControl(value);
        }

        protected void FindAndUpdate<TControl>(string signalName)
            where TControl : HardwareControl
        {
            TControl ctrlToAdd = FindControlToUpdate<TControl>(signalName);
            ctrlToAdd.UpdateControl();
        }

        protected T FindControl<T>(string signalName) where T : HardwareControl
            => (T)HardwareControls.First(ctrl => ctrl.ControlName == signalName);
    }
}