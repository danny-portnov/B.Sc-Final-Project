using Common.HwControl.Model.JsonConfigParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HwControl.Model.JsonConfigParser
{
    /// <summary>
    /// Abstract parent class for all derived signal classes.
    /// </summary>
    public interface IDaqChannelBase
    {
        /// <summary>
        /// The name given to the specific card(is unique, e.g.DIO1 or ADC)
        /// </summary>
        public string DeviceName { get; }
    }
}