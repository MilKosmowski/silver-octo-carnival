using System;
using System.IO.Ports;
using System.Linq;

using CustomExtensions;

namespace Central_pack
{
    partial class Declarations
    {
        private static bool IsPortAvailable(SerialPort PortToBeCheckedForAvailability)
        {
            var portExists = false;
            try
            {
                portExists = System.IO.Ports.SerialPort.GetPortNames().Any(x => x == PortToBeCheckedForAvailability.PortName);
            }
            catch (Exception e)
            {
                MyExtensions.Log($"Problem z dostępem do portu {PortToBeCheckedForAvailability.PortName} : {e}", "Regular");
            }
            return portExists;
        }

        public static string OpenCOMPort(SerialPort PortToBeOpened)
        {
            if (!IsPortAvailable(PortToBeOpened))
            {
                return $"port {PortToBeOpened.PortName} nie istnieje, nie otwarto portu";
            }

            if (PortToBeOpened.IsOpen) return "port otwarto";

            try
            {
                PortToBeOpened.Open();
                return "port otwarto";
            }
            catch (Exception)
            {
                return $"problem z otwarciem portu {PortToBeOpened.PortName}. Port istnieje ale nie można go otworzyć.";
            }
        }
    }
}