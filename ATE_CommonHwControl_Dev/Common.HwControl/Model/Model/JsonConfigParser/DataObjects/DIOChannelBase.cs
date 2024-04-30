using Common.HwControl.Model.Utilities;
using DriversWrapper.DIO;
using System;

namespace Common.HwControl.Model.JsonConfigParser.DataObjects
{
    public class DIOChannelBase<T> : IDaqChannelBase
    {
        /// <summary>
        /// <see cref="Direction.Output"/> means set, <see cref="Direction.Input"/> means get.
        /// </summary>
        public Direction Direction { get; init; }
        /// <summary>
        /// Contains the relevant information for the port and line
        /// </summary>
        public Line Line { get; init; }
        public T InitialValue { get; init; }

        string IDaqChannelBase.DeviceName => Line.DeviceName;

        protected DIOChannelBase(string device, int? port, int? line, int? TTL, Direction direction)
        {
            Direction = direction;
            const string arguments = $"{nameof(TTL)}, {nameof(line)}, {nameof(port)}";
            if (TTL == null == (line == null || port == null))
            {
                throw new ArgumentNullException(
                    arguments,
                    $"Either {nameof(TTL)} or {nameof(line)} and {nameof(port)} must be specified.");
            }
            if (TTL != null && line != null && port != null)
            {
                throw new ArgumentNullException(
                    arguments,
                    $"All 3 parameters can't be specified simultaneously");
            }
            port ??= (int)Math.Floor((decimal)((TTL - 1) / Constants.LinesPerPort));
            Line = new Line(device
                    ?? throw new ArgumentNullException(
                        nameof(device)),
                        port.Value,
                        line ?? TTL.Value - port.Value * Constants.LinesPerPort - 1);
        }
    }
}