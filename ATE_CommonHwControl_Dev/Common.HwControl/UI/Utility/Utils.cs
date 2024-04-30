using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;
using Common.HwControl.UI.Utility;

namespace Common.HwControl.UI
{
    public static class Utils
    {
        /// <summary>
        /// If an attempt to check if invoke required is needed was issued before the control component has been shown for the first time. 
        /// This may cause a cross-thread operation later on. 
        /// To be on the safe side create UI controls after the control has been show for the first time or make sure you are in the same thread that the c'tor called. 
        /// if you know you are in the correct thread just skip the use of the function  InvokeIfNeeded(action). 
        /// you can also force the show of the window before you check if invoke needed.
        /// </summary>
        public static void InvokeIfNeeded(this Control con, Action action)
        {
            if (con == null)
                throw new ArgumentNullException(nameof(con));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (con.InvokeRequired)
            {
                con.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public static void GetAppViewDetails(out string interfaceName, out string interfaceVersion, out string interfaceComplationMode,
        out string productVersion, out string companyName, out string filepath, out string dotnetVersion)
        {
            string fullPath = Assembly.GetAssembly(typeof(CommonHwControlAppView)).Location;
            interfaceName = Assembly.GetExecutingAssembly().GetName().Name;
            interfaceVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            productVersion = FileVersionInfo.GetVersionInfo(fullPath).FileVersion;
            filepath = fullPath;
            dotnetVersion = typeof(CommonHwControlAppView).Assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkDisplayName;
            var FileInfo = FileVersionInfo.GetVersionInfo(fullPath);
            companyName = FileInfo.CompanyName;
#if DEBUG
            interfaceComplationMode = "Debug";
#else
        interfaceComplationMode = "Release";
#endif
        }

        public static void ShowAboutBox()
        {
            GetAppViewDetails(out string InterfaceName, out string InterfaceVersion, out string InterfaceCompilationMode, out string ProductVersion,
                out string CompanyName, out string Filepath, out string DotnetVersion);

            using AboutWindow splashForm = new(null)
            {
                InterfaceCompilationMode = InterfaceCompilationMode,
                InterfaceName = InterfaceName,
                Filepath = Filepath,
                DotnetVersion = DotnetVersion
            };
            splashForm.ShowDialog();
        }
    }
}