using AppInterfaces;
using Common.HwControl.Model.Utilities;
using IniParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Common.HwControl.Model.JsonConfigParser;
using Common.HwControl.Model.Drivers;
using DriversWrapper;
using System.Linq;
using MuxBox1_5App.Model;
using Constants = Common.HwControl.Model.Utilities.Constants;
using System.Threading.Tasks;

namespace Common.HwControl.Model
{
    public partial class CommonHwController : IAppModel, IDisposable
    {
        private static readonly object _syncInstance = new();
        private static readonly Dictionary<string, CommonHwController> InstancesDic = new();
        public Action InitializeDevices { get; private set; }
        public AIO AnalogDevices { get => Devices.AnalogDevices; }
        public DiscreteController DiscreteDevices { get => Devices.DiscreteDevices; }
        public RelayController Relays { get => Devices.Relays; }

        public PowersupplyController PowerSupplies { get => Devices.PowerSupplies; } // This doesn't work { get; set; } = Devices.PowerSupplies;
        public MuxBox1_5AppModel MuxBoxModel { get; private set; }

        public static CommonHwController GetInstance(string instanceName)
        {
            lock (_syncInstance)
            {
                if (!InstancesDic.ContainsKey(instanceName))
                {
                    InstancesDic[instanceName] = new CommonHwController() { InstanceName = instanceName };
                }
            }

            return InstancesDic[instanceName];
        }
        /// <summary>
        /// If only one instance (already) exists, returns it. Else creates a new one with empty string.
        /// </summary>
        /// <returns></returns>
        public static CommonHwController GetInstance()
            => GetInstance(InstancesDic.Keys.Count == 1 ? InstancesDic.Keys.First() : string.Empty);

        public event EventHandler<bool> SimulationModeEvent;

        /// <summary>
        /// Turns on power-supplies
        /// </summary>
        public event EventHandler ModelDoneEvent;

        public string InstanceName { get; protected set; }
        public bool Simulation { get; protected set; }
        public bool IsMuxBoxEnabled { get; protected set; }
        public bool IsStandAlone { get; protected set; }

        protected CommonHwController()
        { }

        public int InitAppModel(bool isStandAlone, string appConfig, string driversConfig)
        {
            if (InstancesDic.Count > 1)
            {
                NotificationPrinter.Print($"More than one instance of Model was created! {InstancesDic.Keys}");
            }
            IsStandAlone = isStandAlone;
            try
            {
                ReadParamsFromConfigFile(appConfig);
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e);
                throw;
            }
            SimulationModeEvent?.Invoke(this, Simulation);
            if (isStandAlone) //open logger only when standalone
            {
                ProcessExtended.OpenProcess(Constants.LoggerAppName, Constants.LoggerAppPath);
            }
            InitializeDevices = new(() =>
            {
                Devices.InitDevices(driversConfig, isStandAlone, this);
                if (IsMuxBoxEnabled)
                {
                    MuxBoxModel = MuxBox1_5AppModel.GetInstance(Constants.MuxboxInstanceName);
                    try
                    {
                        MuxBoxModel.InitAppModel(true, Constants.MuxboxInterfaces, Constants.MuxboxDrivers);
                    }
                    catch (Exception ex)
                    {
                        CommonHwExceptionHandler.PrintExceptionMessageToLogger(ex);
                        throw;
                    }
                }
            });
            ModelDoneEvent?.Invoke(this, EventArgs.Empty);
            return default;
        }

        private void ReadParamsFromConfigFile(string appConfig)
        {
            // parsing Interfaces.ini
            string section = string.IsNullOrEmpty(InstanceName) ? throw new ArgumentNullException(nameof(InstanceName)) : $"{InstanceName}.App.{InstanceName}";
            FileIniDataParser parser = new();
            IniParser.Model.IniData iniData = parser.ReadFile(appConfig);
            if (!iniData.Sections.ContainsSection(section))
            {
                throw new IniParser.Exceptions.ParsingException($"Section {section} not found in the appConfig {appConfig}");
            }
            IniParser.Model.KeyDataCollection interfaceSection = iniData[section];

            //Simulation = true;
            //Simulation = interfaceSection.ContainsKey("bSimulation") && int.Parse(interfaceSection["bSimulation"], System.Globalization.NumberStyles.Any) != 0;
            Simulation = ParseValue(Constants.SimulationKeyName, interfaceSection, appConfig, Convert.ToBoolean, section);
            IsMuxBoxEnabled = ParseValue(Constants.IsMuxBoxEnabledKeyName, interfaceSection, appConfig, Convert.ToBoolean, section);
            JsonDesirializer.SignalsJsonPath = Path.GetDirectoryName(appConfig);
        }
        /// <summary>
        /// Tries to parse <paramref name="key"/>'s value in the <paramref name="appConfig"/> file. 
        /// If successful returns the parsed value, else throws appropriate exception with detailed explanation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="interfaceSection"></param>
        /// <param name="appConfig"></param>
        /// <returns></returns>
        /// <exception cref="IniParser.Exceptions.ParsingException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <param name="ConvertToT"></param>
        /// <param name="sectionName"></param>
        private T ParseValue<T>(string key,
                                IniParser.Model.KeyDataCollection interfaceSection,
                                string appConfig,
                                Func<int, T> ConvertToT,
                                string sectionName)
        {
            if (!interfaceSection.ContainsKey(key))
            {
                throw new FormatException(
                    $"couldn't find key {key} in {Path.GetFileName(appConfig)} section {sectionName}," +
                    $" please add it. Full path: {appConfig}.");
            }
            if (!int.TryParse(interfaceSection[key], out int result))
            {
                throw new FormatException($"{key}'s value should be a valid number (1 or 0 for boolean), please fix that in the file {appConfig}");
            }
            return ConvertToT(result);
        }

        public int CloseAppModel()
        {
            Dispose();
            return default;
        }

        public void Dispose()
        {
            if (IsStandAlone)
            {
                Devices.Dispose();
            }
            if (IsMuxBoxEnabled)
            {
                MuxBoxModel.Dispose();
            }
        }
    }
}