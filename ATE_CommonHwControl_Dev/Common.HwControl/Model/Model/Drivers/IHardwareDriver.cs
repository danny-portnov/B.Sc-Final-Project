using DriversWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.HwControl.Model.Model.Drivers
{
    internal interface IHardwareDevice
    {
        CancellationTokenSource CancellationTokenSource { get; }
    }
}
