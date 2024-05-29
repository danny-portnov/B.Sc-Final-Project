using Common.HwControl.Model.JsonConfigParser.DataObjects;
using Common.HwControl.Model.Utilities;
using DriversWrapper.PS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.HwControl.Model.Drivers
{
    /// <summary>
    /// Class for a power supply. Used to turn it on or off, and controlling its voltage or current.
    /// </summary>
    public class PowersupplyController : HardwareDevice<PowerSupplyParams, DriverPS>, IActivableOnStartUpDevice
    {
        private bool _isTurnedOn;
        private EventHandler<string> _powerSupplyUpdated;
        public event EventHandler<string> PowerSupplyUpdated
        {
            add
            {
                _powerSupplyUpdated += value;
                NotificationPrinter.EventSubsribed(nameof(_powerSupplyUpdated), value);
            }
            remove => _powerSupplyUpdated -= value;
        }

        /// <summary>
        /// Initializes a new instance of the power supply unit
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if wasn't able to turn the unit on</exception>
        /// <exception cref="NullReferenceException"></exception>
        internal PowersupplyController(string driversConfig, bool isStandAlone) : base(driversConfig, isStandAlone, DriverPS.GetInstance)
        { }

        /// <summary>
        /// Gets the current through the unit in Ampere units of type <see cref="double"/>.
        /// <br>In case there's an <see cref="Exception"/>, it prints the error to the log. </br>
        /// </summary>
        /// <returns>An <see cref="OperationResult"/> instance which contains the operation info </returns>
        public double GetActualCurrent(string powerSupplyName)
        {
            DriverPS choosenPS = GetDevice(powerSupplyName);
            try
            {
                return choosenPS.Simulation && _isTurnedOn 
                    ? Math.Abs(choosenPS.CurrentLimit * new Random().NextDouble()) 
                    : choosenPS.Current;
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e);
                throw;
            }
        }

        protected override List<string> GetAllDevices() => ChannelsDataCollection.Keys.ToList();

        protected override DriverPS GetDevice(string powerSupplyName)
            => (DriverPS)Devices.DevicesCollection[powerSupplyName];

        /// <summary>
        /// Gets the voltage through the unit in Volt units of type <see cref="double"/>.
        /// <br>In case there's an <see cref="Exception"/>, it prints the error to the log. </br>
        /// </summary>
        /// <returns>An <see cref="OperationResult"/> instance which contains the operation info </returns>
        public double GetActualVoltage(string powerSupplyName)
        {
            DriverPS choosenPS = GetDevice(powerSupplyName);
            try
            {
                return choosenPS.Simulation && _isTurnedOn 
                    ? Math.Abs(choosenPS.Voltage_Programmed) 
                    : choosenPS.Voltage_Actual;
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the power status (on/off) of the unit using the <see cref="PowerSupplyState"/> emum.
        /// </summary>
        /// <returns>An <see cref="OperationResult"/> instance with details of the operation</returns>
        public PowerSupplyState GetPowerState(string powerSupplyName)
        {
            DriverPS choosenPS = GetDevice(powerSupplyName);
            try
            {
                var state = choosenPS.OutputPowerOn.ToPowerState();
                _isTurnedOn = state == PowerSupplyState.On;
                return state;
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e);
                throw;
            }
        }

        /// <summary>
        /// Sets the current limit through the unit in Ampere units of type <see cref="double"/>.
        /// </summary>
        /// <param name="newCurrentLimit">The current limit to be set</param>
        /// <returns>An <see cref="OperationResult"/> instance with details of the operation</returns>
        public void SetCurrentLimit(string powerSupplyName, double newCurrentLimit)
        {
            DriverPS choosenPS = GetDevice(powerSupplyName);
            try
            {
                CheckBounds(newValue: newCurrentLimit,
                    minimumValue: Constants.MinimumVoltageOrCurrent,
                    maximumValue: ChannelsDataCollection[powerSupplyName.ToString()].CurrentLimit,
                    paramName: "Current limit");
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e, "Check bounds in SetCurrentLimit for ps failed");
                throw;
            }
            try
            {
                choosenPS.CurrentLimit = newCurrentLimit;
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e);
                throw;
            }
            _powerSupplyUpdated?.Invoke(default, powerSupplyName);
        }

        private void CheckBounds(double newValue, int minimumValue, double maximumValue, string paramName)
        {
            if (newValue > maximumValue || newValue < minimumValue)
            {
                throw new ArgumentOutOfRangeException($" {paramName} ({newValue}) out of bounds (has to be between" +
                    $" {minimumValue}-{maximumValue}!)");
            }
        }

        /// <summary>
        /// Sets the power status (on/off) of the unit.
        /// </summary>
        /// <returns>An <see cref="OperationResult"/> instance with details of the operation</returns>
        public void SetPowerState(string powerSupplyName, PowerSupplyState state)
        {
            DriverPS choosenPS = GetDevice(powerSupplyName);
            try
            {
                choosenPS.OutputPowerOn = state == PowerSupplyState.On;
            }
            catch (Exception e)
            {
                // Todo: check if addDevice works if ps switch is off
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e, $"Failed set Power to - {state}, Mostly is caused since PS switch is off");
                throw;
            }
            _powerSupplyUpdated?.Invoke(default, powerSupplyName);
        }

        /// <summary>
        /// Sets the voltage through the unit in Volt units
        /// </summary>
        /// <returns>An <see cref="OperationResult"/> instance which contains the operation info </returns>
        public void SetVoltage(string powerSupplyName, double newVoltage)
        {
            DriverPS choosenPS = GetDevice(powerSupplyName);
            try
            {
                CheckBounds(newValue: newVoltage,
                    minimumValue: Constants.MinimumVoltageOrCurrent,
                    maximumValue: ChannelsDataCollection[powerSupplyName.ToString()].VoltageLimit,
                    paramName: "Voltage");
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e);
                throw;
            }
            try
            {
                choosenPS.Voltage_Programmed = newVoltage;
            }
            catch (Exception e)
            {
                CommonHwExceptionHandler.PrintExceptionMessageToLogger(e);
                throw;
            }
            _powerSupplyUpdated?.Invoke(default, powerSupplyName);
        }

        public void ActivateOnStartUp()
        {
            foreach (KeyValuePair<string, PowerSupplyParams> PSparams in ChannelsDataCollection
                .Where(channel => channel.Value.StateOnStartUp.HasValue))
            {
                SetPowerState(PSparams.Key, PSparams.Value.StateOnStartUp.Value);
                SetVoltage(PSparams.Key, PSparams.Value.VoltageOnStartUp);
                SetCurrentLimit(PSparams.Key, PSparams.Value.CurrentLimitOnStartUp);
            }
        }
    }
}