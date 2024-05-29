using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.Model.Utilities;
using DriversWrapper;
using DriversWrapper.AIO;
using LoggerClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Common.HwControl.Model.Drivers
{
    /// <summary>
    /// Class for a AIO device.
    /// </summary>
    public class AIO : HardwareDevice<AnalogChannel, DriverAIO>
    {
        private EventHandler<(string, decimal)> _AIControlsUpdated;
        private readonly Random _random = new();
        public event EventHandler<(string, decimal)> AIControlsUpdated
        {
            add
            {
                _AIControlsUpdated += value;
                NotificationPrinter.EventSubsribed(nameof(_AIControlsUpdated), value);
            }
            remove => _AIControlsUpdated -= value;
        }
        private readonly List<string> _relaysToOpen = new();

        /// <summary>
        /// Initializes a new instance of the AIO driver
        /// </summary>
        /// <param name="driversConfig">The path for the Drivers.ini file</param>
        /// <param name="isStandAlone">Was the app activated by itself or by another customer?</param>
        /// <exception cref="NullReferenceException"></exception>
        internal AIO(string driversConfig, bool isStandAlone) : base(driversConfig, isStandAlone, DriverAIO.GetInstance)
        {

        }

        internal void OpenClosedActivisionRelays()
        {
            foreach (string relayName in _relaysToOpen)
            {
                Devices.Relays.SetRelay(relayName, RelayState.Open);
            }
            _relaysToOpen.Clear();
        }

        internal void OpenActivationRelay(string signalName)
            => CheckBeforeSetRelay(GetSignalConfigData(signalName), RelayState.Open);

        public async Task<double[]> GetAnalogSignal(string signalName, bool isPeriodic = false)
        {
            AnalogChannel signal = GetSignalConfigData(signalName);
            Input channel = GetInputChannel(signalName);
            double[] buffer;
            CheckBeforeSetRelay(signal, RelayState.Close);
            if (isPeriodic && signal.ActivationRelay != null)
            {
                _relaysToOpen.Add(signal.ActivationRelay);
            }
            try
            {
                buffer = await Task.Run(() =>
                    channel.GetAsyncBuffer(signal.ChannelConfig, signal.SampleRate, signal.BufferSize));
            }
            catch (DriverException e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e, "Failed to read AI data");
                throw;
            }
            if (!isPeriodic)
            {
                CheckBeforeSetRelay(signal, RelayState.Open);
            }
            //return await Task.FromResult(channel);
            return buffer;
        }

        /// <summary>
        /// From signal name
        /// </summary>
        /// <param name="signalName"></param>
        /// <returns></returns>
        private Input GetInputChannel(string signalName)
            => GetInputChannel(GetDevice(signalName), GetSignalConfigData(signalName));

        /// <summary>
        /// From <seealso cref="DriverAIO"/> instance and <see cref="AnalogChannel"/>
        /// </summary>
        /// <param name="choosenAio"></param>
        /// <param name="analogSignal"></param>
        /// <returns></returns>
        private Input GetInputChannel(DriverAIO choosenAio, AnalogChannel analogSignal)
            => choosenAio.InputChannels[(AIChannels)analogSignal.InChannelNum];

        /// <summary>
        /// Gets the signal's numerical value from the associated AIO card.
        /// </summary>
        /// <param name="signalName">The name of the signal as appears in the json file.</param>
        /// <returns>The buffer's average as a <see cref="decimal"/>.</returns>
        public async Task<decimal> GetSignalAveregeValueAsync(string signalName, bool isPeriodic = false)
        {
            DriverAIO choosenAio = GetDevice(signalName);
            AnalogChannel analogSignal = GetSignalConfigData(signalName);
            try
            {
                decimal value = await CalculateBuffersAverage(choosenAio,
                                                              await GetAnalogSignal(signalName, isPeriodic));
                value *= analogSignal.MultiplicationFactor;
                _AIControlsUpdated?.Invoke(signalName, (signalName, value));
                return value;
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e);
                throw;
            }

            Task<decimal> CalculateBuffersAverage(DriverAIO choosenAio, IEnumerable<double> buffer) //this way, the exception thrown is handled
                => Task.FromResult((decimal)Math.Round(choosenAio.Simulation ? _random.NextDouble() * 5 : buffer.Average(), 2));
        }

        private void CheckBeforeSetRelay(AnalogChannel analogSignal, RelayState relayState)
        {
            if (analogSignal.ActivationRelay != null)
            {
                Devices.Relays.SetRelay(analogSignal.ActivationRelay, relayState);
                if (relayState == RelayState.Close)
                {
                    _relaysToOpen.Remove(analogSignal.ActivationRelay);
                }
            }
        }

        public AnalogChannel GetSignalConfigData(string signalName)
        {
            AnalogChannel configData;
            try
            {
                configData = ChannelsDataCollection[signalName];
            }
            catch
            {
                throw new ArgumentException($"couldn't find analog signal \"{signalName}\" in collection");
            }
            return configData;
        }

        public async Task SetDACVoltageAsync(string signalName, bool outputState)    //amit dac
        {
            DriverAIO choosenAio = GetDevice(signalName);
            AnalogChannel channel = ChannelsDataCollection[signalName];
            Output ch0 = new(choosenAio.DeviceName, channel.OutChannelNum.Value);
            try
            {
                ch0.ConfigAOChannel(channel.OutputPulseArray,
                                    channel.OutputPulseArray.Length,
                                    channel.OutputPulseArray.Length * channel.PulsesPerSec,
                                    SampleMode.Cont);
                //1st param:Array which contains the wave, 2nd param: size of the array mentioned, 3rd: frequency (number of times the array's repeated in a sec)
                //4th param: number of times the wave repeats: infinite (cont) , finite (1?), or something else dunno
                ch0.Ouptut = outputState;  //start the wave signal!
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e);
                throw;
            }
            await Task.Delay(1000); //wait for the configs to update
        }
    }
}