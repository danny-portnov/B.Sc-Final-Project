using System;

namespace Common.HwControl.Model.Utilities
{
    public static class MyConvertions
    {
        public static PowerSupplyState ToPowerState(this bool isOn)
            => isOn ? PowerSupplyState.On : PowerSupplyState.Off;

        //public static PowersupplyNames ToPowersupplyName(this string powersupplyName) 
        //    => (PowersupplyNames)Enum.Parse(typeof(PowersupplyNames), powersupplyName);

        //public static SampleMode ToSampleMode(this string sampleMode)
        //    => (SampleMode)Enum.Parse(typeof(SampleMode), sampleMode);

        //public static bool ToBoolean<TEnum>(this TEnum state) where TEnum : Enum
        //    => Convert.ToBoolean(state); //todo: check this

        public static RelayState ToRelayState(this bool relayState)
            => relayState ? RelayState.Close : RelayState.Open;


    }
}