using System;
using System.Drawing;
using System.Windows.Forms;


namespace Common.HwControl.UI.Utility
{
    public partial class AboutWindow : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                // Shadow on the 
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public AboutWindow(Image img = null) => InitializeComponent();

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            labelCompanyName.Text = CompanyName;
            labelProductVersion.Text = ProductVersion;
            lblInterfaceName.Text = InterfaceName;
            lblCompilationMode.Text = InterfaceCompilationMode;
            labelFilepath.Text = Filepath;
            labelDotnetVersion.Text = DotnetVersion;
        }

        public string InterfaceName { get; set; }
        public string InterfaceCompilationMode { get; set; }
        public string Filepath { get; set; }
        public string DotnetVersion { get; set; }

    }
}