using System;

namespace Common.HwControl.Panel
{
    [Serializable]
    public class ProgramArgs
    {
        public ProgramArgs(string instanceName, string driversIniName, string interfaceIniName)
        {
            InstanceName = instanceName ?? throw new ArgumentNullException(nameof(instanceName));
            DriversIniName = driversIniName ?? throw new ArgumentNullException(nameof(driversIniName));
            InterfaceIniName = interfaceIniName ?? throw new ArgumentNullException(nameof(interfaceIniName));
        }

        public string InstanceName { get; private set; }
        public string DriversIniName { get; private set; }
        public string InterfaceIniName { get; private set; }
    }
}