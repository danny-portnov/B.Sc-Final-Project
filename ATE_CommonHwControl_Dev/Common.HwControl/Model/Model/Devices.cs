using Common.HwControl.Model.Drivers;
using Common.HwControl.Model.JsonConfigParser;
using Common.HwControl.Model.Utilities;
using DriversWrapper;
using DriversWrapper.AIO;
using DriversWrapper.DIO;
using DriversWrapper.PS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.HwControl.Model
{
    internal static class Devices
    {
        internal static AIO AnalogDevices { get; private set; }
        internal static PowersupplyController PowerSupplies { get; private set; }
        internal static DiscreteController DiscreteDevices { get; private set; }
        internal static RelayController Relays { get; private set; }
        internal static CommonHwController AppModel { get; private set; }
        internal static Dictionary<string, IDriverBase> DevicesCollection { get; } = new();
        internal static HashSet<IActivableOnStartUpDevice> ActivableOnStartUpDevices { get; private set; }

        /// <summary>
        /// Initializes all the devices' instances.
        /// <br>They both contain instances of their respective drivers</br>
        /// </summary>
        /// <param name="driversConfig">The path for the Drivers.ini file</param>
        /// <param name="isStandAlone">Indicates if a consumer called the app (or RATE)</param>
        /// <exception cref="NullReferenceException"></exception>
        /// <param name="appModel"></param>
        internal static void InitDevices(string driversConfig, bool isStandAlone, CommonHwController appModel)
        {
            CheckPathVariable();
            AppModel = appModel;
            InitializeRelevantDrivers(driversConfig, isStandAlone);
            // Initialize all devices

            AnalogDevices = JsonDesirializer.DevicesToInit.ContainsValue(
                typeof(AIO)) ? new(driversConfig, isStandAlone) : default;
            Relays = JsonDesirializer.DevicesToInit.ContainsValue(
                typeof(RelayController)) ? new(driversConfig, isStandAlone) : default;
            DiscreteDevices = JsonDesirializer.DevicesToInit.ContainsValue(
                typeof(DiscreteController)) ? new(driversConfig, isStandAlone) : default;
            PowerSupplies = JsonDesirializer.DevicesToInit.ContainsValue(
                typeof(PowersupplyController)) ? new(driversConfig, isStandAlone) : default;
            ActivableOnStartUpDevices = new()
            {
                DiscreteDevices, Relays,PowerSupplies
            };
        }

        internal static void ActivateOnStartUp()
        {
            foreach (IActivableOnStartUpDevice device in ActivableOnStartUpDevices)
            {
                device.ActivateOnStartUp();
            }
        }

        private static void InitializeRelevantDrivers(string driversConfig, bool isStandAlone)
        {
            try
            {
                if (isStandAlone)
                {
                    foreach (Action<string> InitDriver in JsonDesirializer.DriversToInit.Values.Distinct())
                    {
                        InitDriver(driversConfig);
                        NotificationPrinter.UpdateStatus($"{InitDriver.Method.ReflectedType.Name} initialized successful");
                    }
                }
            }
            catch (BadImageFormatException e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(
                    e,
                    "change platform to x86 : Panel -> Properties -> Debug -> Platform target to x86)");
                throw;
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e, "check simulation mode in Drivers.ini");
                throw;
            }
        }

        private static void CheckPathVariable()
        {
            //foreach (var _ in Constants.RequiredPaths.Where(path => !Environment.GetEnvironmentVariable("Path")
            //    .Contains(path)).Select(path => new { }))
            //{
            //    throw new InvalidOperationException("Please add required paths to environment variables");
            //}
        }

        /// <summary>
        /// Safely closes the device and then the driver.
        /// </summary>
        internal static void Dispose()
        {
            foreach (IDriverBase device in DevicesCollection.Values)
            {
                try
                {
                    device.CloseDevice();
                }
                catch (DriverException e)
                {
                    CommonHwExceptionHandler.PrintExceptionMessageToLogger(e, $"couldn't close {device.DeviceName}");
                    throw;
                }
            }

            foreach (Action CloseDriverMethod in new List<Action> { DriverPS.CloseDriver, DriverAIO.CloseDriver, DriverDIO.CloseDriver })
            {
                try
                {
                    CloseDriverMethod();
                }
                catch (DriverException e)
                {
                    CommonHwExceptionHandler.PrintExceptionMessageToLogger(e, $"couldn't close {CloseDriverMethod.Method.DeclaringType.Name}");
                }
            }
        }
    }
}