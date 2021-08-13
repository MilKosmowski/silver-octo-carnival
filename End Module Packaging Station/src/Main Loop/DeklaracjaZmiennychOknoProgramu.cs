using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using UniwersalneMetody;
using System.IO.Ports;

namespace Central_pack
{
    public partial class Deklaracje : Form
    {
        public Deklaracje()

        {
            InitializeComponent();
            WczytajUstawienia();
        }


        public static TcpClient fisClient = new TcpClient();
        public static NetworkStream streamFIS;
        private static List<string> produktyWKartonie = new List<string>();
        List<string> backFlashKolejkaDanePlik = new List<string>();
        public static PlikUstawienia ustawienia = new PlikUstawienia();
        List<Control> controlGrafika = new List<Control>();
        public List<Label> panelGrafika = new List<Label>();

        private static List<string> przerywanaDanePlik = new List<string>();
        private static string[] settings;
        private string daneZeSkanera = "";
        private static string etapProcesuParowania = "Skanowanie kodu 1P";

        public int wizualizacjaKartonuWysokosc = 0;
        public int WizualizacjaKartonuSzerokosc = 0;
        public string poprzedniSpakowanySN = "";
        public string sapIp;
        public string sapPort;

        public static string[] sapIpLista;
        public static string zdjeciaSciezka = Directory.GetCurrentDirectory() + @"\Central_pack_ustawienia\photos";
        public static string backflashKolejkaPlik = Directory.GetCurrentDirectory() + @"\Central_pack_ustawienia\BackFlashKolejka.txt";
        public static string ustawieniaPlik = Directory.GetCurrentDirectory() + @"\Central_pack_ustawienia\Settings.ini";
        public static string typSciezka = Directory.GetCurrentDirectory() + @"\Typy\";



        //labelPartNumberProduktu.Text

        private void CzyJestPolaczenieZFIS()
        {
            if (!MojeMetody.Ping(ustawienia.ip).Contains(ustawienia.ip))
                MojeMetody.Log($"Problem z połączeniem z serwerem FIS {ustawienia.ip}. Nie można włączyć programu bez połączenia z FIS", "zwykly");
        }
        private void WczytajUstawienia()
        {
            Directory.CreateDirectory("log");
            settings = File.ReadAllLines(ustawieniaPlik);
            ustawienia.ip = settings[1];
            ustawienia.port = settings[3];
            ustawienia.station = settings[5];
            ustawienia.process = settings[7];
            ustawienia.sap = settings[9];
            sapIpLista = settings[10].Split(' ');
            sapIp = sapIpLista[0];
            sapPort = settings[11];
            ustawienia.com = settings[13];
            ustawienia.com2 = settings[15];
            ustawienia.Przerywana = settings[17];
            ustawienia.LokalizacjaPrzerywanej = settings[19];
            serialPortLabelScanner.PortName = ustawienia.com;
            serialPortProductScanner.PortName = ustawienia.com2;
            labelJakaStacja.Text = ustawienia.station.Substring(13);
            CzyJestPolaczenieZFIS();
            CzyJestPrzerywana();
            UruchomienieSkanerowCOM();
            CzyJestPolaczenieZSerweramiSAP();
            ZdefiniujPolaczenieFIS();
            //listBoxWKartonie.DataSource = PlikPartNumber;
        }

        private void CzyJestPrzerywana()
        {
            if (ustawienia.Przerywana == "1")
                labelProdukcjaPrzerywana.BackColor = Color.Lime;
            else
                labelProdukcjaPrzerywana.BackColor = Color.Tomato;
        }

        private void CzyJestPolaczenieZSerweramiSAP()
        {
            bool flagaSAP = false;
            foreach (string adres in sapIpLista)
            {
                if (!MojeMetody.Ping(adres).Contains("timed") || !MojeMetody.Ping(adres).Contains("timed"))
                {
                    flagaSAP = true;
                }
            }
            if ((ustawienia.sap == "1") && flagaSAP)
                labelStatusSap.BackColor = Color.Lime;
            else
                labelStatusSap.BackColor = Color.Tomato;
        }

        private void UruchomienieSkanerowCOM()
        {

            string statusSerialPortLabelScanner = UruchamianieSkanerow.OtwarciePortu(serialPortLabelScanner);
            if (statusSerialPortLabelScanner.Contains("ok"))
            {
                labelLabelScanner.BackColor = Color.Lime;
                serialPortLabelScanner.WriteLine("<T>\r");
            }
            else labelLabelScanner.BackColor = Color.Tomato;
            toolTipSkaner1.SetToolTip(this.labelLabelScanner, statusSerialPortLabelScanner);


            string statusSerialPortProductScanner = UruchamianieSkanerow.OtwarciePortu(serialPortProductScanner);
            if (statusSerialPortProductScanner.Contains("ok")) labelProductScanner.BackColor = Color.Lime;
            else labelProductScanner.BackColor = Color.Tomato;
            toolTipSkaner2.SetToolTip(this.labelProductScanner, statusSerialPortProductScanner);
        }

    }
}
