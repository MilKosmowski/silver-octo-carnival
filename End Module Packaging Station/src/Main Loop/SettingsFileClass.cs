using System;
using System.IO;
using System.Net;

using CustomExtensions;

namespace Central_pack
{
    public class SettingsFile
    {
        public SettingsFile(string settingsFilePath)
        {
            if (string.IsNullOrEmpty(settingsFilePath))
            {
                throw new ArgumentException($"'{nameof(settingsFilePath)}' cannot be null or empty", nameof(settingsFilePath));
            }
            string[] SettingsFile = File.ReadAllLines(settingsFilePath);

            FisIp = SettingsFile[1];
            FisPort = SettingsFile[3];

            try
            {
                MyExtensions.Log(MyExtensions.Ping(FisIp), "Regular");
            }
            catch (Exception e)
            {
                MyExtensions.Log($"Problem z adresem ip/hostame serwera FIS. Sprawdź poprawność nazwy w pliku konfiguracyjnym: {e}", "Regular");
            }

            Station = SettingsFile[5];
            Process = SettingsFile[7];
            Sap = SettingsFile[9];
            SapIpList = SettingsFile[10].Split(' ');

            bool ValidateIP = IPAddress.TryParse(SettingsFile[10], out _);
            if (ValidateIP)
                PrimarySAPIp = SettingsFile[10];
            else
            {
                string hostname = SettingsFile[10];
                IPAddress[] SapIP = Dns.GetHostAddresses(hostname);
                PrimarySAPIp = SapIP[0].ToString();
                ValidateIP = IPAddress.TryParse(PrimarySAPIp, out _);
                if (!ValidateIP)
                    throw new Exception($"Invalid ip: {SapIP[0]}, or invalid hostname: {hostname}.");
                MyExtensions.Log(MyExtensions.Ping(PrimarySAPIp), "Regular");
            }

            SapPort = SettingsFile[11];
            CartonScannerPort = SettingsFile[13];
            ProductScannerPort = SettingsFile[15];
            InterruptedProduction = SettingsFile[17];
            string InterruptedProductionFileLocation = SettingsFile[19];
            LegacyInterruptedProductionMethodOn = SettingsFile[21];
            string LegacyInterruptedProductionFileLocation = SettingsFile[23];
            ActualInterruptedProductionFileLocation = LegacyInterruptedProductionMethodOn == "1" ? LegacyInterruptedProductionFileLocation : InterruptedProductionFileLocation;
        }

        public string FisIp { get; set; }

        public string[] SapIpList { get; set; }

        public string PrimarySAPIp { get; set; }

        public string FisPort { get; set; }

        public string SapPort { get; set; }

        public string Station { get; set; }

        public string Process { get; set; }

        public string Sap { get; set; }

        public string CartonScannerPort { get; set; }

        public string ProductScannerPort { get; set; }

        public string InterruptedProduction { get; set; }

        public string LegacyInterruptedProductionMethodOn { get; set; }

        public string ActualInterruptedProductionFileLocation { get; set; }
    }
}