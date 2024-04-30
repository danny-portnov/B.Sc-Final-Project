using Common.HwControl.Model.JsonConfigParser.DataObjects;
using DriversWrapper.AIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HwControl.Model.Utilities
{
    public class Constants
    {
        /// <summary>
        /// The path to the folder with the json files which contain all the signals
        /// </summary>
        public const int Spacing = 40;
        public const int MinimumVoltageOrCurrent = 0;
        public const string MuxboxInterfaces = "C:\\ATEs\\MuxBox1_5\\ATE_MuxBox1_5\\Config\\Interfaces.ini";
        public const string MuxboxDrivers = "C:\\ATEs\\MuxBox1_5\\ATE_MuxBox1_5\\Config\\Drivers.ini";
        public const string MuxboxInstanceName = "MuxBox1_5App";


        //public const string SolutionName = "CommonHwControl";

        public const string NameOfAnalogsFile = "Analogs.json";
        public const string NameOfDiscretesFile = "Discretes.json";
        public const string NameOfRelaysFile = "Relays.json";
        public const string NameOfPsFile = "Powersupplies.json";

        internal const string SimulationKeyName = "bSimulation";
        internal const string IsMuxBoxEnabledKeyName = "isMuxBoxEnabled";

        internal const string GeneralSectionName = "General";


        public const string LoggerAppName = "LoggerServer";
        public const string LoggerAppPath = @"C:\ATEs\VPSD_CommonCode\CommonCode\Bin";

        public static readonly string[] RequiredPaths = {@"C:\ATEs\VPSD_CommonCode\CommonCode\Bin", @"C:\ATEs\VPSD_CommonCode\CommonCode\Bin\Dependencies",
        @"C:\ATEs\RATE3\RATE\Bin", @"C:\ATEs\RATE3\RATE\Bin\Dependencies", @"C:\ATEs\Drivers\Bin", @"C:\ATEs\Drivers\Bin\Dependencies" };
        internal const int DefaultBufferSize = 250;
        internal const int DefaultSamplesRate = 250;
        internal const ConfigChannels DefaultChannelConfig = ConfigChannels.RSE;

        internal const int LinesPerPort = 8;
        /// <summary>
        /// The minimal time allowed between hardware sampling.
        /// </summary>
        internal const int LowestUpdateInterval = 200;

        /// <summary>
        /// Space between each dynamic control
        /// </summary>

    }
}