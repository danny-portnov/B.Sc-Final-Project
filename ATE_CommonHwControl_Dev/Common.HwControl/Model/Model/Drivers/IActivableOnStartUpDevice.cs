using Common.HwControl.Model.JsonConfigParser;
using DriversWrapper;
using System;

namespace Common.HwControl.Model.Drivers
{
    public interface IActivableOnStartUpDevice
    {
        public void ActivateOnStartUp();
    }
}