using AppInterfaces;
using Common.HwControl.Model;
using Common.HwControl.Model.Utilities;
using Common.HwControl.Properties;
using Common.HwControl.UI.Groupers;
using Common.HwControl.UI.Panels;
using Common.HwControl.UI.Utility;
using DriversWrapper;
using DriversWrapper.DIO;
using MuxBox1_5App.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Common.HwControl.UI
{
    public partial class CommonHwControlAppView : Form, IAppView
    {
        public CommonHwController AppModel { get; }
        private AppWindowState windowState;
        public bool MinimizeOnCloseButton { get; }
        protected bool VisibleWindow { get; }
        //public IEnumerable<IGrouperControl> GroupersList { get; private set; }

        public AppWindowState AppWndState
        {
            get { return windowState; }
            set
            {
                windowState = value;
                this.InvokeIfNeeded(() =>
                {
                    Visible = (value == AppWindowState.Normal || value == AppWindowState.Maximized || value == AppWindowState.Minimized);
                });
            }
        }

        public CommonHwControlAppView(CommonHwController model, bool visibleWindow, bool minimizeOnCloseButton)
        {
            #region Projectbuilder code

            InitializeComponent();

            AppModel = model;
            MinimizeOnCloseButton = minimizeOnCloseButton;
            VisibleWindow = visibleWindow;
            labelHeaderInterface.Text = AppModel.InstanceName;
            RegisterAllEvents();

            #endregion Projectbuilder code

        }

        #region Projectbuilder functions

        protected void RegisterAllEvents()
        {
            /*add all events you need to know about in your view*/
            AppModel.SimulationModeEvent += SetSimulationMode;
            //AppModel.DevicesDoneEvent += OnDevicesInitializationDoneEvent;//Todo - event not needed
            AppModel.ModelDoneEvent += AppModel_ModelDoneEvent;
        }

        protected void UnregisterAllEvents()
        {
            /*remove all events you need to know about in your view*/
            AppModel.SimulationModeEvent -= SetSimulationMode;
            AppModel.ModelDoneEvent -= AppModel_ModelDoneEvent;
        }

        private void AppModel_ModelDoneEvent(object sender, EventArgs e)
        {
        }

        private void CommonHwControlAppView_Load(object sender, EventArgs e)
        {
            this.InvokeIfNeeded(() =>
                Text += $"     Version: {FileVersionInfo.GetVersionInfo(
                    Assembly.GetAssembly(GetType()).Location).FileVersion}"
            );
        }

        private void CommonHwControlAppView_Shown(object sender, EventArgs e)
            => AppWndState = (VisibleWindow ? AppWindowState.Normal : AppWindowState.Hidden);

        private void CommonHwControlAppView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = MinimizeOnCloseButton;

            if (MinimizeOnCloseButton)
            {
                AppWndState = AppWindowState.Hidden;
            }
            else
            {
                UnregisterAllEvents();
            }
        }

        private void pictureBoxAbout_Click(object sender, EventArgs e) => Utils.ShowAboutBox();

        protected void SetSimulationMode(object sender, bool SimMode)
        {
            this.InvokeIfNeeded(() =>
            {
                pictureBoxRunMode.Image = SimMode ? Resources.simulationMode : Resources.runMode;
                lblRunMode.Text = SimMode ? Resources.SimulatorModeStr : Resources.RunModeStr;
                lblRunMode.ForeColor = SimMode ? Color.Red : Color.Black;
            });
        }

        #endregion Projectbuilder functions
    }
}