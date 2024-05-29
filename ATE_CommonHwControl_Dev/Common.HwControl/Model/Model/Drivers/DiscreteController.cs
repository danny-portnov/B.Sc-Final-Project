using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.HwControl.Model.Drivers
{
    /// <summary>
    /// Class for a DIO device. Also used to turn on relays.
    /// </summary>
    public class DiscreteController : DIO<DiscreteChannel, bool>
    {
        private Random random = new();

        private EventHandler<(string, bool)> _DOsUpdated;
        public event EventHandler<(string, bool)> DOsUpdated
        {
            add
            {
                _DOsUpdated += value;
                NotificationPrinter.EventSubsribed(nameof(_DOsUpdated), value);
            }
            remove => _DOsUpdated -= value;
        }
        private EventHandler<(string, bool)> _DIsUpdated;
        public event EventHandler<(string, bool)> DIsUpdated
        {
            add
            {
                _DIsUpdated += value;
                NotificationPrinter.EventSubsribed(nameof(_DIsUpdated), value);
            }
            remove => _DIsUpdated -= value;
        }

        /// <summary>
        /// Initializes 2 instances of the DIO driver
        /// </summary>
        /// <param name="driversConfig">The path for the Drivers.ini file</param>
        /// <param name="isStandAlone">flag </param>
        /// <exception cref="NullReferenceException"></exception>
        internal DiscreteController(string driversConfig, bool isStandAlone) : base(driversConfig, isStandAlone) { }

        /// <summary>
        /// Gets whether the discrete is on or off.
        /// </summary>
        /// <param name="signalName">The name of the signal as appears in the json file</param>
        /// <returns><see langword="true"/> if discrete is set, <see langword="false"/> otherwise.</returns>
        public bool GetDiscrete(string signalName)
        {
            bool value = GetLineValue(signalName);
            //bool value = random.Next(2) == 0;
            _DIsUpdated?.Invoke(default, (signalName, value));
            return value;
        }

        /// <summary>
        /// Sets the value of the desired signal.
        /// </summary>
        /// <param name="signalName">The name of the signal as appears in the json file</param>
        /// <param name="value"><see langword="true"/> to set the discrete, else <see langword="false"/>.</param>
        public void SetDiscrete(string signalName, bool value)
        {
            SetLineValue(signalName, value);
            _DOsUpdated?.Invoke(default, (signalName, value));
        }

        protected override void ActivateOnStartUp(KeyValuePair<string, DiscreteChannel> channel)
            => SetDiscrete(channel.Key, channel.Value.InitialValue);
    }
}