using Common.HwControl.Model;
using DriversWrapper.DIO;
using DriversWrapper.Rly;
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
    public partial class MuxGrouper : GrouperBase
    {
        private CommonHwController _appModel;
        public MuxGrouper() : base()
            => InitializeComponent();

        internal override void Initialize(CommonHwController appModel)
        {
            _appModel = appModel;
            if (!_appModel.IsMuxBoxEnabled)
            {
                Hide();
            }
        }

        private void UnitsMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            _appModel.MuxBoxModel.SetUnit(unitsMenu.SelectedIndex + 1, out string message);
            if (message != string.Empty)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(new Exception(message));
            }
        }
    }
}
