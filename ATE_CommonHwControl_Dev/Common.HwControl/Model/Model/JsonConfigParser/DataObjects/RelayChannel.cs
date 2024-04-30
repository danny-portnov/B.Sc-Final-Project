using Common.HwControl.Model.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HwControl.Model.JsonConfigParser.DataObjects
{
    /// <summary>
    /// Describes the relay's locations.
    /// </summary>
    public enum Location
    {
        ITA,
        OU
    }
    public class RelayChannel : DIOChannelBase<RelayState>
    {
        /// <summary>
        /// Relay's location
        /// </summary>
        public Location Location { get; private set; }
        /// <summary>
        /// Creates a new instance which describes a certain relay's properties and relevant information to turn it on.
        /// </summary>
        /// <param name="device"></param>
        /// <param name="port"></param>
        /// <param name="line"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// 
        [JsonConstructor]
        public RelayChannel(string device, Location? location, int? port = default, int? line = default,
            int? TTL = default, RelayState initialState = default)
            : base(device, port, line, TTL, DriversWrapper.DIO.Direction.Output)
        {
            Location = location ?? throw new ArgumentNullException(nameof(location));
            InitialValue = initialState;
        }
    }
}