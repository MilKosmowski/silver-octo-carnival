using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using CustomExtensions;
using System;

namespace Central_pack
{
    partial class Declarations : Form
    {
        public Declarations()
        {
            InitializeComponent();
            LoadSettings();
        }
        private void LoadSettings()
        {
            Directory.CreateDirectory("log");
            Directory.CreateDirectory("logSAP");
            Directory.CreateDirectory("Central_pack_ustawienia/photos");
            serialPortScannerCarton.PortName = settingsFile.CartonScannerPort;
            serialPortScannerProduct.PortName = settingsFile.ProductScannerPort;
            labelStationNumber.Text = settingsFile.Station.Substring(13);
            CheckForFISConnection();
            SetupInterruptedProductionBlinker();
            COMScannerOn();
            CheckForSAPConnection(settingsFile.PrimarySAPIp);

            if (File.Exists(shiftAmountPackedPath))
            {
                string[] shiftAmountPackedFile = File.ReadAllLines(shiftAmountPackedPath);
                Int32.TryParse(shiftAmountPackedFile[0], out int tempAmountPackedThisShift);
                amountPackedThisShift = tempAmountPackedThisShift;
                labelAMountPackedThisShift.Text = $"Spakowano: {amountPackedThisShift}";
                Int32.TryParse(shiftAmountPackedFile[1], out int tempCurrentShift);
                currentShift = tempCurrentShift;
                labelShift.Text = $"Zmiana: {tempCurrentShift}";
            }

            Int32.TryParse(DateTime.Now.ToString("HH"), out int currentHour);
            if (6 <= currentHour && currentHour < 14)
                CurrentShift = 1;
            if (14 <= currentHour && currentHour < 22)
                CurrentShift = 2;
            if (22 <= currentHour && currentHour < 6)
                CurrentShift = 3;
        }
        private void CheckForFISConnection()
        {
            if (!MyExtensions.Ping(settingsFile.FisIp).Contains(settingsFile.FisIp))
                MyExtensions.Log($"Problem z połączeniem z serwerem FIS {settingsFile.FisIp} {settingsFile.FisPort}. Nie można włączyć programu bez połączenia z FIS", "Regular");
        }
        private void SetupInterruptedProductionBlinker()
        {
            toolTipInterruptedProduction.SetToolTip(this.labelInterruptedProductionBool, settingsFile.ActualInterruptedProductionFileLocation);

            if (settingsFile.InterruptedProduction == "1")
            {
                if (settingsFile.LegacyInterruptedProductionMethodOn == "1")
                    labelInterruptedProductionBool.BackColor = Color.Orange;
                else
                    labelInterruptedProductionBool.BackColor = Color.LightGreen;
            }
            else
                labelInterruptedProductionBool.BackColor = Color.LightCoral;
        }
        private void COMScannerOn()
        {
            string statusSerialPortLabelScanner = OpenCOMPort(serialPortScannerCarton);
            if (statusSerialPortLabelScanner.Contains("port otwarto"))
            {

                serialPortScannerCarton.WriteLine("<T>\r");
                MyExtensions.Log("<T>", "Regular");
                timer600ms.Enabled = true;
            }
            string statusSerialPortProductScanner = OpenCOMPort(serialPortScannerProduct);
        }
        private void CheckForSAPConnection(string PrimarySAPIp)
        {
            bool flagaSAP = false;
            if (!MyExtensions.Ping(PrimarySAPIp).Contains("timed"))
            {
                flagaSAP = true;
            }
            if ((settingsFile.Sap == "1") && flagaSAP)
                labelStatusSap.BackColor = Color.LightGreen;
            else
                labelStatusSap.BackColor = Color.LightCoral;
        }

        private static string packingProcessStep = "Skanowanie kodu 1P";
        public int cartonHeightVisualization = 0;
        public int cartonWidthVisualization = 0;
        public string previousCartonSerialNumber = "";
        private string cartonLabelSerialNumber = "";
        private int amountPackedThisShift;
        private int currentShift = 0;
        private bool pictureHasBeenSetUp = false;
        public static readonly string photoFolderPath = Directory.GetCurrentDirectory() + @"\Central_pack_ustawienia\photos";
        public static readonly string SAPQueueFilePath = Directory.GetCurrentDirectory() + @"\Central_pack_ustawienia\BackFlashKolejka.txt";
        public static readonly string settingsFilePath = Directory.GetCurrentDirectory() + @"\Central_pack_ustawienia\Settings.ini";
        public static readonly string APNFileFolderPath = Directory.GetCurrentDirectory() + @"\Typy\";
        public static readonly string shiftAmountPackedPath = Directory.GetCurrentDirectory() + @"\AmountPackedThisShift.txt";

        public static List<string> productsInCarton = new List<string>();
        public static SettingsFile settingsFile = new SettingsFile(settingsFilePath);
        public List<Label> panelCartonContentVisualization = new List<Label>();
        List<string> queueSAPFile = new List<string>();
        List<Control> controlCartonContentVisualization = new List<Control>();
        public static TcpClient fisClient;
        public static NetworkStream streamFIS;

        private void TimerResetCounter_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            if (time == "06:00:00")
                currentShift = 1;
            if (time == "14:00:00")
                currentShift = 2;
            if (time == "22:00:00")
                currentShift = 3;
        }

    }
}
