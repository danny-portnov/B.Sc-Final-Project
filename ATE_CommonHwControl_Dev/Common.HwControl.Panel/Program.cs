using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using Common.HwControl.Model;
using Common.HwControl.UI;

namespace Common.HwControl.Panel
{
    //[CommonHwException/*(Message = "from other methods")*/]
    public static partial class Program
    {

        /*[CommonHwException(Message = "Inside Main",  AttributeReplace = true)]*/ // This way, only this attributes applies to this method
                                                                                   // and not also the 'outer' attribute
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ProgramArgs programArgs = ParseArguments(args);
            using CommonHwController appModel = CommonHwController.GetInstance(programArgs.InstanceName);
            CommonHwControlAppView appView = new(appModel, true, false);
            appModel.InitAppModel(isStandAlone: true, appConfig: programArgs.InterfaceIniName, driversConfig: programArgs.DriversIniName);
            Application.Run(appView);
        }

        private static ProgramArgs ParseArguments(string[] args)
        {
            string instanceName;
            string driversIniName;
            string interfaceIniName;
            if (args.Length == 3) //3 parameters instaceName Drivers.ini & Interfaces.ini
            {
                //Take the commands line args
                instanceName = args[2];
                interfaceIniName = args[0];
                driversIniName = args[1];
            }
            else
            {
                //take from App.Config 
                instanceName = args.Length == 1 ? args[0] : ConfigurationManager.AppSettings["Instance Name"];
                interfaceIniName = ConfigurationManager.AppSettings["Interface INI Path"];
                driversIniName = ConfigurationManager.AppSettings["Drivers INI Path"];
            }

            if (instanceName == null)
            {
                throw new ArgumentNullException(nameof(instanceName));
            }
            if (interfaceIniName == null)
            {
                throw new ArgumentNullException(nameof(interfaceIniName));
            }
            if (driversIniName == null)
            {
                throw new ArgumentNullException(nameof(driversIniName));
            }

            if (!File.Exists(interfaceIniName))
            {
                throw new ArgumentNullException("the file interface INI file not found");
            }

            if (!File.Exists(driversIniName))
            {
                throw new ArgumentNullException("the file drivers INI file not found");
            }

            return new ProgramArgs(instanceName, driversIniName, interfaceIniName);
        }
    }
}