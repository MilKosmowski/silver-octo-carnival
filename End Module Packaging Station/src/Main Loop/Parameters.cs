using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using CustomExtensions;
using System.IO.Ports;

namespace Central_pack
{
    partial class Declarations : Form

    {
        private void Application_Idle(Object sender, EventArgs e)
        {

            MessageBox.Show("You are in the Application.Idle event.");
        }
        public List<string> QueueSAPFile { get; set; }
        public string ScannerData { get; set; }
        public static List<string> InterruptedProductionFile { get; set; }
        public string CartonCapacityQString { get; set; }
        public int CartonCapacityQInteger { get; set; }
        public string[] APNFileData { get; set; }
        public string APNFromAPNFile { get; set; }
        public string APNFormat { get; set; }
        public string IfASNAndFormat { get; set; }
        public string CartonSerialNumberFormat { get; set; }
        public string CartonLabelSerialNumber
        {
            get
            {
                return cartonLabelSerialNumber;
            }
            set
            {
                cartonLabelSerialNumber = value;
                if (string.IsNullOrEmpty(value))
                    labelCartonNumber.Text = "-";
                else
                    labelCartonNumber.Text = $"Karton: {value}";
            }
        }
        public string PackingType { get; set; }
        public bool BezelScanned { get; set; }
        public string CommandForUser
        {
            get { return labelCommandForUser.Text; }
            set { labelCommandForUser.Text = value; }
        }
        public static string PackingProcessStep
        {
            get
            {
                return packingProcessStep;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    packingProcessStep = "Skanowanie kodu 1P";
                else
                    packingProcessStep = value;
            }
        }
        public string LastInput
        {
            get { return textBoxLastInput.Text; }
            set 
            { 
                if (!value.Contains("NOREAD") && value!="")
                    try
                    {
                        textBoxLastInput.Text = value.Substring(value.IndexOf("1P"));
                    }

                    catch
                    {
                        textBoxLastInput.Text = "-brak odczytu-";
                    }

                else
                    textBoxLastInput.Text = "-brak odczytu-";
            }
        }
        public string KeyboardWedgeScannerData
        {
            get { return textBoxKeyboardWedgeScannerData.Text; }
            set { textBoxKeyboardWedgeScannerData.Text = value; }
        }
        public string CartonLabelAPN
        {
            get { return labelCartonLabelAPN.Text; }
            set { labelCartonLabelAPN.Text = value; }
        }
        public Image PackingPictureFilePath
        {
            get { return BoxPackingPicture.Image; }
            set { BoxPackingPicture.Image = value; }
        }
        public int AmountOfProductsInCarton
        {
            get {
                    return productsInCarton.Count;
                }
        }
        public bool OneSecondClockOn
        {
            get { return timer1000ms.Enabled; }
            set { timer1000ms.Enabled = value; }
        }
        public string FromattedValueInCartonPackCounter
        {
            get { return labelCartonPackCounter.Text; }
            set { labelCartonPackCounter.Text = value + "/" + CartonCapacityQInteger; }
        }
        public string ResponseForUser
        {
            get { return labelResponseForUser.Text; }
            set
            {
                if (labelResponseForUser.Text != value)
                labelResponseForUser.Text = value;
            }
        }
        public Color BackgroundColor
        {
            get { return BackColor; }
            set
            {
                if (value == Color.LightGreen)
                {
                    BackColor = value;
                    timer1000ms.Enabled = true;
                }
            }
        }
        public Color ReponseForUserColor
        {
            get { return labelResponseForUser.BackColor; }
            set
            {
                if (labelResponseForUser.BackColor != value)
                    labelResponseForUser.BackColor = value;
            }
        }
        public string APNInProductBarcode{ get; set; }
        public SerialPort SerialPortScannerProduct
        {
            get { return serialPortScannerProduct; }
            set { serialPortScannerProduct = value; }
        }
        public SerialPort SerialPortScannerCarton
        {
            get { return serialPortScannerCarton; }
            set { serialPortScannerCarton = value; }
        }
        public int AmountPackedThisShift
        {
            get { return amountPackedThisShift; }
            set
            {
                amountPackedThisShift = value;
                labelAMountPackedThisShift.Text = $"Spakowano: {amountPackedThisShift}";

                string[] shiftAmountPackedFile = new string[] { AmountPackedThisShift.ToString(), CurrentShift.ToString() } ;
                File.WriteAllLines(shiftAmountPackedPath, shiftAmountPackedFile);
            }
        }
        public int CurrentShift
        {
            get { return currentShift; }
            set
            {
                if (value == 1 || value == 2 || value == 3) 
                {
                    if (currentShift != value)
                    {
                        currentShift = value;
                        labelShift.Text = $"Zmiana: {value}";
                        AmountPackedThisShift = 0;
                    }
                }
            }
        }
    } 
}
