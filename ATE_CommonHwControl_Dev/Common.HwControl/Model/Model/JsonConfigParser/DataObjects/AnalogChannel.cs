using Common.HwControl.Model.Utilities;
using DriversWrapper.AIO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Common.HwControl.Model.JsonConfigParser.DataObjects
{
    /// <summary>
    /// A class that represents an analog signal.
    /// It contains the channel's number and configuration, buffer size, and amount of samples.
    /// </summary>
    public class AnalogChannel : IDaqChannelBase
    {
        public enum AnalogDirection { Input, Output }
        public AOChannels? OutChannelNum { get; init; }
        public AIChannels? InChannelNum { get; init; }
        public int InputChannelNum { get; init; }
        public int BufferSize { get; init; }
        public int SampleRate { get; init; }
        public AnalogDirection Direction { get; init; }
        public int MultiplicationFactor { get; init; }
        public ConfigChannels ChannelConfig { get; init; }
        public string TerminalConfiguration { get; init; }
        public string ActivationRelay { get; }
        public string DeviceName { get; init; }
        public double[] OutputPulseArray { get; }


        [JsonConstructor]
        public AnalogChannel(int? channel, int? buffer, int? SampleRate, ConfigChannels? channelConfig, string deviceName,
            AnalogDirection direction, int? MulFactor, string ActivationRelay, int? arraySize, int? pulseWidth, double? pulseHeight)
            : this(buffer, SampleRate, channelConfig, deviceName, MulFactor, ActivationRelay)
        {
            int channelNum = channel ?? throw new ArgumentNullException(nameof(channel));
            Direction = direction;

            switch (Direction)
            {
                case AnalogDirection.Input:
                    InChannelNum = (AIChannels?)channelNum;
                    InputChannelNum = (int)InChannelNum;
                    break;
                case AnalogDirection.Output:
                    OutChannelNum = (AOChannels?)channelNum;
                    OutputPulseArray = Enumerable.Range(0, arraySize.Value)
                        .Select(i => i < pulseWidth.Value ? pulseHeight.Value : 0).ToArray();
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(Direction));
            }
            TerminalConfiguration = ChannelConfig.ToString();

        }

        private AnalogChannel(int? buffer, int? sampleRate, ConfigChannels? channelConfig, string deviceName, int? mulFactor, string activationRelay)
        {
            BufferSize = buffer ?? Constants.DefaultBufferSize;
            SampleRate = sampleRate ?? Constants.DefaultSamplesRate;
            ChannelConfig = channelConfig ?? Constants.DefaultChannelConfig;
            DeviceName = deviceName ?? throw new ArgumentNullException(nameof(DeviceName));
            MultiplicationFactor = mulFactor ?? 1;
            ActivationRelay = activationRelay;
        }

    }
}