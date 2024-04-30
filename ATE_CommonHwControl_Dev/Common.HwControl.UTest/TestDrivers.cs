using Microsoft.VisualStudio.TestTools.UnitTesting;
using DriversWrapper.AIO;
using Common.HwControl.Model;
using DriversWrapper.DIO;

namespace Common.HwControl.UnitTest
{



    [TestClass]
    public class TestDrivers
    {
        private const string _electUnitDriversIni = @"C:\ATEs\IronDome\ElectUnit\ATE_ElectUnit\Config\Drivers.ini";
        private const string _commonDriversIni = @"C:\ATEs\CommonHwControl\ATE_CommonHwControl\Config\Drivers.ini";
        private const string _deviceNameAdc = "ADC";
        private const string _deviceNameDac = "DAC";
        private const string _deviceNameDIO1 = "DIO1";
        private const string _deviceNameDIO2 = "DIO2";
        private const string _elecUnitInstanceName = "ElectUnitHwControl";

        //[TestMethod]
        //public void TestCounter()
        //{
        //    DriverCounter.InitDriver(_commonDriversIni);
        //    DriverCounter drvCounter = DriverCounter.GetInstance(_deviceNameAdc);
        //    drvCounter.AddDevice(_commonDriversIni);
            
        //    drvCounter.EdgeCountStart(0, new EdgeCountStruct() { eActiveEdge = ActiveEdge.Rising, sInputTerminal = "" });
        //    int CountValue = 0;
        //    drvCounter.EdgeCountGetValue(0, ref CountValue);
        //    drvCounter.EdgeCountStop();
        //    TimeMeasurement tm = new TimeMeasurement() { dMaxSec =  100, dMinSec = 0, dTimeBaseHz = 2000, eEdge = ActiveEdge.Rising , iNumberOfMeasurements = 1, sInputTerminal = "" };
        //    double[] measurments = new double[1];
        //    drvCounter.PulseWidthMeasure(0, tm, ref measurments, 1000);

        //}

        [TestMethod]
        public void AnalogDriverShouldAddDevice()
        {
            DriverAIO.InitDriver(_commonDriversIni);
            DriverAIO drvAioADC = DriverAIO.GetInstance(_deviceNameAdc);

            drvAioADC.AddDevice(_electUnitDriversIni);
            drvAioADC.InputChannels[AIChannels.CH2].ConfigAIOChannel(ConfigChannels.DIFF, 1000, 1000);
            drvAioADC.InputChannels[AIChannels.CH2].StartInput();
            drvAioADC.InputChannels[AIChannels.CH3].ConfigAIOChannel(ConfigChannels.DIFF, 1000, 1000);
            drvAioADC.InputChannels[AIChannels.CH3].StartInput();
            

            var buff1 = drvAioADC.InputChannels[AIChannels.CH2].Buffer;
            var buff2 = drvAioADC.InputChannels[AIChannels.CH3].Buffer;

            drvAioADC.CloseDevice();
            
            DriverAIO.CloseDriver();
        }

        [TestMethod]
        public void TestAnalogGetSignal()
        {
            CommonHwController hwController = CommonHwController.GetInstance("ElectUnitHwControl");
            hwController.InitAppModel(true, @"C:\ATEs\CommonHwControl\ATE_CommonHwControl\Config\Interfaces.ini", @"C:\ATEs\IronDome\ElectUnit\ATE_ElectUnit\Config\Drivers.ini");
            hwController.AnalogDevices.GetSignalAveregeValueAsync("MLL_L").Wait();
        }

        [TestMethod]
        public void TestGetInstance()
        {
            CommonHwController hwController = CommonHwController.GetInstance(_elecUnitInstanceName);
            hwController.InitAppModel(true, @"C:\ATEs\IronDome\ElectUnit\ATE_ElectUnit\Config\Interfaces.ini", _electUnitDriversIni);
        }

        [TestMethod]
        public void DiscreteLineShouldChangeValue()
        {
            DriverDIO.InitDriver(_commonDriversIni);
            DriverDIO dio1 = DriverDIO.GetInstance(_deviceNameDIO1);
            DriverDIO dio2 = DriverDIO.GetInstance(_deviceNameDIO2);

            dio1.AddDevice(_commonDriversIni);
            dio2.AddDevice(_commonDriversIni);

            Assert.AreEqual(dio2.Ports[0].Lines[0].Value, 0);

            dio1.Ports[0].Lines[0].Direction = Direction.Output;
            dio2.Ports[0].Lines[0].Value = 1;

            Assert.AreEqual(dio2.Ports[0].Lines[0].Value, 1);

            dio1.CloseDevice();
            dio2.CloseDevice();
            DriverDIO.CloseDriver();
        }
    }
}