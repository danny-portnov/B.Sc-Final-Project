using Common.HwControl.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HwControl.Model.Utilities
{
    public class ProcessExtended : Process
    {
        public const string LoggerAppName = "LoggerServer";
        public const string LoggerAppPath = @"C:\ATEs\VPSD_CommonCode\CommonCode\Bin";

        /// <summary>
        /// Opens the desired process if it wasn't already open and creates its instance.
        /// <br>Handles an <see cref="Exception"/> if one occurs. </br>
        /// </summary>
        /// <param name="name">Name of the process (without .exe)</param>
        /// <param name="path">Full path of the .exe file, with  \\</param>
        /// <returns></returns>
        public static Process OpenProcess(string name, string path)
        {
            path = Path.Combine(path, $"{name}.exe");
            return GetProcessesByName(name).Length == 0 ? Start(path) : GetProcessesByName(name)[0];
        }

        /// <summary>
        /// Tries to close a process if it's open.<br/> Otherwise does nothing.
        /// </summary>
        internal static void CloseProcess(Process process)
        {
            if (process == null)
            {
                return;
            }
            try
            {
                process.CloseMainWindow();
            }
            catch
            {
                //left empty on purpose
            }
        }


    }
}