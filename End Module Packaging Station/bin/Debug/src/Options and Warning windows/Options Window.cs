using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using CustomExtensions;

namespace Central_pack_Refactoring
{
    public partial class OptionsMenu : Form
    {
        List<string> Ports = new List<string>();
        SettingsFile settingsFile = new SettingsFile(Declarations.settingsFilePath);
        private static string[] settings;

        public OptionsMenu()
        {
            InitializeComponent();
            LoadSettings();
            listBoxAvailablePorts.DataSource = Ports;
        }

        public void LoadSettings()
        {
            settings = File.ReadAllLines(Declarations.settingsFilePath);

            bool SAPIsUsed = true;
            bool InterruptedProductionIsUsed = true;
            bool LegacyInterruptedProductionMethodIsUsed = false;

            if (settings[9] == "0")
                SAPIsUsed = false;

            if (settings[17] == "0")
                InterruptedProductionIsUsed = false;

            if (settings[21] == "1")
                LegacyInterruptedProductionMethodIsUsed = true;

            textBoxIPFIS.Text = settings[1];
            textBoxPortFIS.Text = settings[3];
            textBoxStationName.Text = settings[5];
            radioSAPCommunicationTrue.Checked = SAPIsUsed;
            radioSAPCommunicationFalse.Checked = !SAPIsUsed;
            textBoxIPSAP.Text = settings[10];
            textBoxPortSAP.Text = settings[11];
            textBoxCOMCartonLabelScanner.Text = settings[13];
            textBoxCOMProductLabelScanner.Text = settings[15];
            textBoxInterruptedProductionFilePath.Text = settings[19];
            radioInterruptedProductionTrue.Checked = InterruptedProductionIsUsed;
            radioInterruptedProductionFalse.Checked = !InterruptedProductionIsUsed;
            radioLegacyInterruptedProductionMethodTrue.Checked = LegacyInterruptedProductionMethodIsUsed;
            radioLegacyInterruptedProductionMethodFalse.Checked = !LegacyInterruptedProductionMethodIsUsed;

            for (int i = 0; i < System.IO.Ports.SerialPort.GetPortNames().Length; i++)
                Ports.Add(System.IO.Ports.SerialPort.GetPortNames()[i]);


        }

        private void SaveSettings()
        {
            string curFile = textBoxInterruptedProductionFilePath.Text;
            if (File.Exists(curFile))
            {
                settings[19] = textBoxInterruptedProductionFilePath.Text;
            }
            else
            {
                MessageBox.Show($"Plik w lokalizacji {textBoxInterruptedProductionFilePath.Text} nie istnieje.'", "Błąd");
            }
            File.WriteAllLines(Declarations.settingsFilePath, settings);
        }

        private void buttonPingSAP_Click(object sender, EventArgs e)
        {
            listBoxPingSAP.Items.Clear();
            listBoxPingSAP.Items.Add(MyExtensions.Ping(textBoxIPSAP.Text));
        }

        private void buttonPingFIS_Click(object sender, EventArgs e)
        {
            listBoxPingFIS.Items.Clear();
            listBoxPingFIS.Items.Add(MyExtensions.Ping(textBoxIPFIS.Text));
        }
        private void RadioSAPKomunikacjaTak_CheckedChanged(object sender, EventArgs e)
        {
            settings[9] = "1";
        }
        private void RadioSAPKomunikacjaNie_CheckedChanged(object sender, EventArgs e)
        {
            settings[9] = "0";
        }
        private void radioCzyPrzerywanaTak_CheckedChanged(object sender, EventArgs e)
        {
            settings[17] = "1";
        }
        private void radioCzyPrzerywanaNie_CheckedChanged(object sender, EventArgs e)
        {
            settings[17] = "0";
        }
        private void TextBoxIPFIS_TextChanged(object sender, EventArgs e)
        {
            settings[1] = textBoxIPFIS.Text;
        }
        private void TextBoxPortFIS_TextChanged(object sender, EventArgs e)
        {
            settings[3] = textBoxPortFIS.Text;
        }
        private void TextBoxNazwaStacji_TextChanged(object sender, EventArgs e)
        {
            settings[5] = textBoxStationName.Text;
        }
        private void TextBoxIPSAP_TextChanged(object sender, EventArgs e)
        {
            settings[10] = textBoxIPSAP.Text;
            string[] sapIpLista = settings[10].Split(' ');
        }
        private void TextBoxPortSAP_TextChanged(object sender, EventArgs e)
        {
            settings[11] = textBoxPortSAP.Text;
        }
        private void TextBoxCOMSkKartonu_TextChanged(object sender, EventArgs e)
        {
            settings[13] = textBoxCOMCartonLabelScanner.Text;
        }
        private void TextBoxCOMSkDetalu_TextChanged(object sender, EventArgs e)
        {
            settings[15] = textBoxCOMProductLabelScanner.Text;
        }
        private void ButtonOpcjeZapisz_Click(object sender, EventArgs e)
        {
            SaveSettings();
            LoadSettings();
        }
        private void ButtonOpcjeZapiszIWyjdz_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Application.Restart();
        }
        private void radioLegacyInterruptedProductionMethodTrue_CheckedChanged(object sender, EventArgs e)
        {
            settings[21] = "1";
        }
        private void radioLegacyInterruptedProductionMethodFalse_CheckedChanged(object sender, EventArgs e)
        {
            settings[21] = "0";
        }
    }
}
