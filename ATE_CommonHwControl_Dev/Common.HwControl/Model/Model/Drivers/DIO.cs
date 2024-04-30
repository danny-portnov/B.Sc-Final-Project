using Common.HwControl.Model.JsonConfigParser;
using Common.HwControl.Model.JsonConfigParser.DataObjects;
using DriversWrapper.DIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.HwControl.Model.Drivers
{
    public abstract class DIO<TChannel, TInitialValue> : HardwareDevice<TChannel, DriverDIO>, IActivableOnStartUpDevice
        where TChannel : DIOChannelBase<TInitialValue>
    {
        /// <summary>
        /// Holds each signal's last value. Used before setting a line.
        /// </summary>
        private readonly Dictionary<string, bool> _usedLines = new();
        protected DIO(string driversConfigPath, bool isStandAlone)
            : base(driversConfigPath, isStandAlone, DriverDIO.GetInstance)
        { }

        protected bool GetLineValue(string signalName)
        {
            Line signal = GetSignalInstance(signalName).Line;
            try
            {
                signal.Direction = Direction.Input;
                return Convert.ToBoolean(signal.Value);
            }
            catch (Exception ex)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(ex, "check if the line is used by other program (NI MAX...)");
                throw;
            }
        }

        /// <summary>
        /// Finds the corresponding signal element from the collection.
        /// </summary>
        /// <param name="signalName">The name of the signal, as should appear in the dictionary.</param>
        /// <returns>Either an instance of <see cref="RelayChannel"/> or <see cref="DiscreteChannel"/>.</returns>
        private TChannel GetSignalInstance(string signalName)
            => !ChannelsDataCollection.TryGetValue(signalName, out TChannel discreteSignal)
                ? throw new ArgumentException($"couldn't find DIO signal \"{signalName}\" in collection")
                : discreteSignal;

        protected TChannel SetLineValue(string signalName, bool value)
        {
            TChannel signal = GetSignalInstance(signalName);
            if (!_usedLines.TryGetValue(signalName, out bool lastValue) || lastValue != value)
            {
                try
                {
                    signal.Line.Direction = Direction.Output;
                    signal.Line.Value = Convert.ToInt32(value);
                }
                catch (Exception ex)
                {
                    CommonHwExceptionHandler.PrintExceptionMessageToLogger(ex, "check if the line is used by other program (NI MAX...)");
                    throw;
                }
            }
            _usedLines[signalName] = value;
            return signal;
        }

        public void ActivateOnStartUp()
        {
            foreach (KeyValuePair<string, TChannel> signal in ChannelsDataCollection
                .Where(channel => !channel.Value.InitialValue.Equals(default(TInitialValue))))
            {
                ActivateOnStartUp(signal);
            }
        }

        protected abstract void ActivateOnStartUp(KeyValuePair<string, TChannel> channel);
    }
}