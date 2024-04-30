using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.Model.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Common.HwControl.Model.Drivers
{
    public class RelayController : DIO<RelayChannel, RelayState>
    {
        private EventHandler<(Location, bool)> _relaysUpdated;
        public event EventHandler<(Location, bool)> RelaysUpdated
        {
            add
            {
                _relaysUpdated += value;
                NotificationPrinter.EventSubsribed(nameof(_relaysUpdated), value);
            }
            remove => _relaysUpdated -= value;
        }
        internal RelayController(string driversConfig, bool isStandAlone) : base(driversConfig, isStandAlone)
        {
        }

        /// <summary>
        /// Gets the value of the desired relay. For testing ONLY
        /// </summary>
        /// <param name="relayName">The name of the signal as appears in the json file</param>
        /// <returns>Relay's state value</returns>
        public RelayState GetRelay(string relayName) => GetLineValue(relayName) ? RelayState.Open : RelayState.Close;

        /// <summary>
        /// Sets the value of the desired relay
        /// </summary>
        /// <param name="relayName">The name of the signal as appears in the json file</param>
        /// <param name="value">Either 1 or 0</param>
        /// <returns>The operation status (either successful or fail)</returns>
        public void SetRelay(string relayName, RelayState value)
        {
            bool isClosed = value == RelayState.Close;
            RelayChannel relay = SetLineValue(relayName, isClosed);
            _relaysUpdated?.Invoke(relayName, (relay.Location, isClosed));
        }

        protected override void ActivateOnStartUp(KeyValuePair<string, RelayChannel> channel)
            => SetRelay(channel.Key, channel.Value.InitialValue);
    }
}