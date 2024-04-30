using Common.HwControl.Model.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.HwControl.UI
{
    public partial class MainStatusBar : StatusBar
    {
        public MainStatusBar()
        {
            InitializeComponent();
            NotificationPrinter.StatusUpdated += OnStatusUpdate;
        }

        private void OnStatusUpdate(string status)
            => this.InvokeIfNeeded(() => statusPanel.Text = status);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            datetimePanel.Text = DateTime.Now.Date.ToString().Split(' ').First();
        }
    }
}
