using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using CustomExtensions;

namespace Central_pack
{
    partial class Declarations : Form
    {
        private void CartonLabelScannerParseAndPack(object sender, EventArgs e)
        {
            LastInput = MyExtensions.SerialPortOutputCleanup(LastInput);
            var barcodesSplitAndSorted = new List<string>();
            barcodesSplitAndSorted = CartonLabelScannerSeparateBarcodesFromReceivedDataPacketAndSort(LastInput);
            if (!barcodesSplitAndSorted.Contains("3S" + previousCartonSerialNumber) && (CartonLabelSerialNumber == ""))
            {
                foreach (var sorted in barcodesSplitAndSorted)
                {
                    if (!sorted.Contains("NOREAD") && sorted != "")
                    {
                        MyExtensions.Log("ACS: " + sorted.ToString(), "Regular");
                        PACK(sorted);
                    }
                }
            }
            else if (barcodesSplitAndSorted.FirstOrDefault(stringToCheck => stringToCheck.Contains("3S")) != null && !barcodesSplitAndSorted.Contains("3S" + CartonLabelSerialNumber) && CartonLabelSerialNumber != "")
            {
                MsgBoxShow($"Na stanowisku powinien znajdować się karton: {CartonLabelSerialNumber}. {(CartonCapacityQInteger == 0 ? $"Dodaje karton {CartonLabelSerialNumber} do produkcji przerywanej i r" : "R")}esetuje program.\n\nNa stendi povynna buty kartonna korobka: {CartonLabelSerialNumber}. {(CartonCapacityQInteger == 0 ? $"Додає коробку {CartonLabelSerialNumber} для перервного виробництва." : "")} Скидання програми.", Color.LightCoral);

                if (CartonLabelAPN != "" && CartonLabelSerialNumber != "" && CartonCapacityQInteger != 0 && AmountOfProductsInCarton != 0)
                    InterruptedProduction.SaveOneRecordToInterruptedProductionFile(CartonLabelAPN, CartonLabelSerialNumber, PackingType, CartonCapacityQInteger, AmountOfProductsInCarton);
                ResetProgram();
            }
        }

        public void TextBoxManualInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PACK(KeyboardWedgeScannerData);
                KeyboardWedgeScannerData = "";
            }
        }

        private void CartonLabelScannerSendScanRequestAndGetDataFromScannerEvery600ms(object sender, EventArgs e)
        {
            int loopLabelCount = 0;
            if (SerialPortScannerCarton.IsOpen)
            {
                if (SerialPortScannerCarton.BytesToRead > 21)
                {
                    LastInput = SerialPortScannerCarton.ReadExisting();
                    if (!string.IsNullOrEmpty(LastInput))
                    {
                        try
                        {
                            SerialPortScannerCarton.DiscardOutBuffer();
                            SerialPortScannerCarton.DiscardInBuffer();
                        }
                        catch { }

                        if (PackingProcessStep != "Skan Produktu")
                            if (LastInput != "-brak odczytu-") MyExtensions.Log("Skan: " + LastInput, "Regular");

                        this.Invoke(new EventHandler(CartonLabelScannerParseAndPack));

                        return;
                    }
                }

                if (loopLabelCount == 0)// && PackingProcessStep != "Skan Produktu")
                {
                    var buforByte = new byte[] { 0x02, 0x32, 0x31, 0x03 };
                    string buforString = Encoding.ASCII.GetString(buforByte, 0, buforByte.Length);

                    try
                    {
                        SerialPortScannerCarton.Write(buforString);
                    }
                    catch (Exception) { }
                }

                if (loopLabelCount == 5)
                {
                    loopLabelCount = 0;
                }

                loopLabelCount = loopLabelCount + 1;
            }
        }

        private List<string> CartonLabelScannerSeparateBarcodesFromReceivedDataPacketAndSort(string receivedDataPacketFromScanner)
        {
            var barcodesSplitAndSorted = new List<string>(3) { "", "", "" };

            if (receivedDataPacketFromScanner.Contains("1P") || receivedDataPacketFromScanner.Contains("Q") || receivedDataPacketFromScanner.Contains("3S"))
            {
                string[] dataPacketSeparatedIntoBarcodes = receivedDataPacketFromScanner.Split(';');
                foreach (string code in dataPacketSeparatedIntoBarcodes)
                {
                    if (code.Contains("1P"))
                    {
                        barcodesSplitAndSorted[0] = code.Substring(code.IndexOf("1P"));
                    }
                    else if (code.Contains("Q"))
                    {
                        barcodesSplitAndSorted[1] = code.Substring(code.IndexOf("Q"));
                    }
                    else if (code.Contains("3S"))
                    {
                        barcodesSplitAndSorted[2] = code.Substring(code.IndexOf("3S"));
                    }
                }
            }
            return barcodesSplitAndSorted;
        }

        private void SerialPortProductScanner_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(5);

            ScannerData += SerialPortScannerProduct.ReadExisting().Replace("\0", string.Empty);
            if (SerialPortScannerProduct.BytesToRead == 0)
            {
                ScannerData = MyExtensions.SerialPortOutputCleanup(ScannerData);
                MyExtensions.Log($"MPS {ScannerData}", "Regular");
                this.Invoke(new EventHandler(DisplayTextProductScanner));
            }

            SerialPortScannerProduct.DiscardOutBuffer();
            SerialPortScannerProduct.DiscardInBuffer();
        }

        private void DisplayTextProductScanner(object sender, EventArgs e)
        {
            LastInput = ScannerData;
            if (PackingProcessStep == "Skan Produktu")
            {
                textBoxProductScanner.Text = ScannerData;
                PACK(ScannerData);
                Refresh();
                Application.DoEvents();
                ScannerData = "";
                SerialPortScannerProduct.DiscardOutBuffer();
                SerialPortScannerProduct.DiscardInBuffer();
            }
        }
    }
}