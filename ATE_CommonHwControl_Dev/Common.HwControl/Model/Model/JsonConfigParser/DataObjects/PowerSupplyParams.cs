using Common.HwControl.Model.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.HwControl.Model.JsonConfigParser.DataObjects
{
    public class PowerSupplyParams : IDaqChannelBase
    {
        public int VoltageLimit { get; }
        public int CurrentLimit { get; }
        public PowerSupplyState? StateOnStartUp { get; }
        public int VoltageOnStartUp { get; }
        public int CurrentLimitOnStartUp { get; }
        public string DeviceName
        {
            get => throw new InvalidOperationException($"{nameof(PowerSupplyParams)} doesn't store the power supply's name");
        }

        [JsonConstructor]
        public PowerSupplyParams(int? voltageLimit, int? currentLimit,
            int? voltageOnStartUp = default, int? currentLimitOnStartUp = default, PowerSupplyState? stateOnStartUp = default)
        {
            ArgumentValidator.ThrowIfAnyNull(voltageLimit, currentLimit);
            VoltageLimit = voltageLimit.Value;
            CurrentLimit = currentLimit.Value;
            VoltageOnStartUp = voltageOnStartUp ?? VoltageLimit;
            CurrentLimitOnStartUp = currentLimitOnStartUp ?? CurrentLimit;
            StateOnStartUp = stateOnStartUp;
        }
    }
}