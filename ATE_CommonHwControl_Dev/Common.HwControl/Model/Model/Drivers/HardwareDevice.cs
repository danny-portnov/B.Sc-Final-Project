using Common.HwControl.Model.JsonConfigParser;
using Common.HwControl.Model.Utilities;
using DriversWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Common.HwControl.Model.Drivers
{
    /// <summary>
    /// Base class for HW classes
    /// </summary>
    public class HardwareDevice<TChannel, TDevice>
        where TChannel : class, IDaqChannelBase
        where TDevice : IDriverBase
    {
        /// <summary>
        /// Holds all the relevant signals from the json file which are associated with this instance.
        /// </summary>
        public Dictionary<string, TChannel> ChannelsDataCollection { get; private init; }

        protected string _driversConfigPath;
        protected bool _isStandAlone;

        internal HardwareDevice(string driversConfigPath, bool isStandAlone, Func<string, TDevice> GetInstance)
        {
            _driversConfigPath = driversConfigPath;
            _isStandAlone = isStandAlone;
            ChannelsDataCollection = JsonDesirializer.ParseSignals<TChannel>() ?? new();
            InitializeDeviceDrivers(GetInstance, GetAllDevices());
        }

        protected void InitializeDeviceDrivers(Func<string, TDevice> getInstance, List<string> devicesNames)
        {
            foreach (string device in devicesNames)
            {
                IDriverBase deviceInstance = getInstance(device);
                if (_isStandAlone)
                {
                    try
                    {
                        deviceInstance.AddDevice(_driversConfigPath);
                        NotificationPrinter.UpdateStatus($"{deviceInstance.DeviceName} was added successfully");
                    }
                    catch (AddDeviceException e)
                    {
                        CommonHwExceptionHandler.PrintExceptionMessageToLogger(e, $"Driver failed to add device {deviceInstance.DeviceName}");
                        throw;
                    }

                }
                if (!Devices.DevicesCollection.Keys.Contains(device))
                {
                    Devices.DevicesCollection.Add(device, (TDevice)deviceInstance);
                }
            }
        }

        // Get all possible devices
        protected virtual List<string> GetAllDevices()
            => ChannelsDataCollection.Select(signal => signal.Value.DeviceName).Distinct().ToList();

        protected virtual TDevice GetDevice(string signalName)
        {
            try
            {
                TChannel Channel = ChannelsDataCollection[signalName];
                return (TDevice)Devices.DevicesCollection[Channel.DeviceName];
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e, $"Signal name - {signalName} was not found");
                throw;
            }
        }
    }
}