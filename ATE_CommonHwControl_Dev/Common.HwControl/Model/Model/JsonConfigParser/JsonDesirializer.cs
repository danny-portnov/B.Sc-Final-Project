using Common.HwControl.Model.Drivers;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.Model.Utilities;
using DriversWrapper.AIO;
using DriversWrapper.DIO;
using DriversWrapper.PS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Common.HwControl.Model.JsonConfigParser
{
    /// <summary>
    /// Static class for parsing a json file.
    /// </summary>
    public static class JsonDesirializer
    {
        /// <summary>
        /// Parses the relevant signals file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>An <see cref="OperationResult"/> instance which contains <see cref="Dictionary{TKey, TValue}"/>
        /// (or <see cref="List{T}"/> for power supplies) that has every discrete signal in the json file.
        /// <br>The key is signal's name and of type <see cref="string"/>, the value contains the rest.</br>
        /// </returns>

        internal static string SignalsJsonPath
        {
            private get => _signalsJsonPath;
            set
            {
                _signalsJsonPath = value;
                DevicesToInit.Filter(RelevantFilesPredicate());
                DriversToInit.Filter(RelevantFilesPredicate());
            }
        }

        private static Func<string, bool> RelevantFilesPredicate()
            => signalsFileName => Directory.GetFiles(SignalsJsonPath, "*.json", SearchOption.TopDirectoryOnly).Contains(signalsFileName);

        private static readonly Dictionary<Type, string> _jsonFileNames = new()
        {
            { typeof(AnalogChannel), Constants.NameOfAnalogsFile},
            { typeof(DiscreteChannel), Constants.NameOfDiscretesFile},
            { typeof(RelayChannel), Constants.NameOfRelaysFile},
            { typeof(PowerSupplyParams), Constants.NameOfPsFile},
        };

        internal static Dictionary<string, Type> DevicesToInit { get; private set; } = new()
        {
            { Constants.NameOfAnalogsFile, typeof(AIO)},
            { Constants.NameOfDiscretesFile , typeof(DiscreteController)},
            { Constants.NameOfRelaysFile , typeof(RelayController)},
            { Constants.NameOfPsFile , typeof(PowersupplyController)},
        };

        internal static Dictionary<string, Action<string>> DriversToInit { get; private set; } = new()
        {
            { Constants.NameOfAnalogsFile, DriverAIO.InitDriver},
            { Constants.NameOfDiscretesFile , DriverDIO.InitDriver},
            { Constants.NameOfRelaysFile , DriverDIO.InitDriver},
            { Constants.NameOfPsFile , DriverPS.InitDriver},
        };

        private static string _signalsJsonPath;

        internal static Dictionary<string, T> ParseSignals<T>() where T : IDaqChannelBase
        {
            var filePath = Path.Combine(SignalsJsonPath, _jsonFileNames[typeof(T)]);
            try
            {
                using StreamReader sr = new(filePath);
                using var jsonReader = new JsonTextReader(sr);
                return new JsonSerializer().Deserialize<Dictionary<string, T>>(jsonReader);
            }
            catch (FileNotFoundException e)
            {
                NotificationPrinter.Print($"{e.Message} If you need to display {Path.GetFileNameWithoutExtension(filePath).ToLower()}, add the file to the specific path.");
                return null;
            }
        }
    }
}