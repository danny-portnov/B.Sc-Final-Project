using DriversWrapper.DIO;
using Newtonsoft.Json;
using System;
using Common.HwControl.Model.Utilities;

namespace Common.HwControl.Model.JsonConfigParser.DataObjects
{
    /// <summary>
    /// A class that represents an electrical discrete signal.
    /// It contains the discrete's port, line, relevant device and card.
    /// </summary>
    public class DiscreteChannel : DIOChannelBase<bool>
    {

        /// <summary>
        /// Initializes a new instance of of the <see cref="DiscreteChannel"/> class.
        /// </summary>
        /// <param name="device">Name of the device's NI model</param>
        /// <param name="port">Number of port</param>
        /// <param name="line">Number of line</param>
        /// <param name="card">Name of the hardware's card</param>
        /// <param name="test">Name of the discrete test</param>
        /// <param name="direction">Input(get) or output(set)</param>
        [JsonConstructor]
        public DiscreteChannel(string device, Direction? direction, int? port = default, int? line = default,
            int? TTL = default, bool initialValue = false)
            : base(device,
                   port,
                   line,
                   TTL,
                   direction ?? throw new ArgumentNullException(nameof(direction)))
            => InitialValue = initialValue;
    }
}