using Common.HwControl.Model;
using System;
using System.Windows.Forms;
using Common.HwControl.UI.Panels;
using Common.HwControl.UI.Utility;
using System.ComponentModel;
using Common.HwControl.UI.Groupers;
using MetroFramework.Drawing.Html;
using System.Threading.Tasks;

namespace Common.HwControl.UI.Controls
{
    /// <summary>
    /// An abstract control base-class for all dynamic controls.
    /// </summary>
    public partial class HardwareControl : UserControl
    {
        protected CommonHwController AppModel { get; private set; } = CommonHwController.GetInstance();

        internal protected virtual string ControlName { get; protected set; }
        /// <summary>
        /// Abstract control, MUST be implemented
        /// </summary>
        internal virtual bool Checked
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        internal HardwareControl(HardwarePanel parentPanel) : this()
        {
            ParentPanel = parentPanel;
            ParentPanel.Controls.Add(this); //todo: maybe move inside grouper
        }

        protected HardwarePanel ParentPanel { get; }

        internal void FormatLabel(string labelText, Label ctrlLabel, float textWidth)
        {
            ctrlLabel.Text = labelText;
            ControlName = labelText;
            ctrlLabel.AutoSizeFont(textWidth);
        }

        /// <summary>
        /// This constructor is used by the designer to render the controls
        /// </summary>
        protected HardwareControl() => InitializeComponent();

        internal virtual Task UpdateControl() => Task.CompletedTask;
        internal virtual void UpdateControl(object value) => throw new NotImplementedException();
    }
}