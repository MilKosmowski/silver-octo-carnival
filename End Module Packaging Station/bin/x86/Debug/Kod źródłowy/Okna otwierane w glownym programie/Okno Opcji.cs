using System;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;


namespace Central_pack
{
    public partial class MenuOpcji : Form
    {
        List<string> Porty = new List<string>();
        public static ConnectParam cfg = new ConnectParam();
        public static string[] ustawienia;


        public MenuOpcji()
        {
            InitializeComponent();
            WczytajWszystko();
            listBoxDostepnePorty.DataSource = Porty;
        }

        public bool SAPrequestCustom(string qty, string pn)
        {
            DateTime time = DateTime.Now;
            string standardFormat = "yyyy-MM-dd-HH.mm.ss.000000";
            string msg = "<REQUEST>NOSERI<WHSECODE>PL02</WHSECODE><SERIALNUM></SERIALNUM><DEPTNO>" + pn + "</DEPTNO><QTY>" + qty + "</QTY><CARTONTMSTMP>" + time.ToString(standardFormat) + "</CARTONTMSTMP><DESTCD>UNKOWN</DESTCD></REQUEST>";
            GlownaPetlaProgramu.WriteLog(msg, "SAP");
            //string ip = "144.250.122.140";
            //int port = 49201;
            string response = Connect(textBoxIPSAP.Text, msg, int.Parse(ustawienia[11]));
            textResponseSAP.Text = "Odpowiedź SAP:  " + response;
            GlownaPetlaProgramu.WriteLog(response, "SAP");
            if (response.Contains("OK"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string Connect(String server, String message, Int32 portNumber, bool closeSocket = false)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                Int32 port = portNumber;
                TcpClient client = new TcpClient(server, port);
                //client.ConnectAsync(server, port);

                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                NetworkStream stream = client.GetStream();
                stream.ReadTimeout = 5000;
                stream.WriteTimeout = 5000;
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);

                //Console.WriteLine("Sent: {0}", message);
                if (closeSocket)
                {
                    stream.Close();
                    client.Close();
                    return "Done. Closed socket";
                }
                // Receive the TcpServer.response.
                //System.Threading.Thread.Sleep(500);
                // Buffer to store the response bytes.


                // String to store the response ASCII representation.
                String responseData = String.Empty;
                data = new Byte[256];
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                //string response = Console.ReadLine();
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                //Console.WriteLine("Received: {0}", responseData);

                // Close everything.
                stream.Close();
                client.Close();
                bytes = 0;


                return responseData;
            }
            catch (IOException)
            {

                return "IOException";
            }
            catch (ArgumentNullException)
            { 
            
                return "ArgumentNullException";
            }
            catch (SocketException)
            {

                return "SocketException";
            }
        }

        private void RadioSAPKomunikacjaTak_CheckedChanged(object sender, EventArgs e)
        {
            ustawienia[9] = "1";
        }

        private void RadioSAPKomunikacjaNie_CheckedChanged(object sender, EventArgs e)
        {
            ustawienia[9] = "0";
        }

        private void radioCzyPrzerywanaTak_CheckedChanged(object sender, EventArgs e)
        {
            ustawienia[17] = "1";
        }

        private void radioCzyPrzerywanaNie_CheckedChanged(object sender, EventArgs e)
        {
            ustawienia[17] = "0";
        }

        private void TextBoxIPFIS_TextChanged(object sender, EventArgs e)
        {
            ustawienia[1] = textBoxIPFIS.Text;
        }

        private void TextBoxPortFIS_TextChanged(object sender, EventArgs e)
        {
            ustawienia[3] = textBoxPortFIS.Text;
        }

        private void TextBoxNazwaStacji_TextChanged(object sender, EventArgs e)
        {
            ustawienia[5] = textBoxNazwaStacji.Text;
        }

        private void TextBoxIPSAP_TextChanged(object sender, EventArgs e)
        {
            ustawienia[10] = textBoxIPSAP.Text;
        }

        private void TextBoxPortSAP_TextChanged(object sender, EventArgs e)
        {
            ustawienia[11] = textBoxPortSAP.Text;
        }

        private void TextBoxCOMSkKartonu_TextChanged(object sender, EventArgs e)
        {
            ustawienia[13] = textBoxCOMSkKartonu.Text;
        }

        private void TextBoxCOMSkDetalu_TextChanged(object sender, EventArgs e)
        {
            ustawienia[15] = textBoxCOMSkDetalu.Text;
        }

        private void ButtonOpcjeZapisz_Click(object sender, EventArgs e)
        {
            string curFile = @textBoxLokalizacjaPrzerywanej.Text;
            if (File.Exists(curFile))
            {
                ustawienia[19] = textBoxLokalizacjaPrzerywanej.Text;
                File.WriteAllLines(GlownaPetlaProgramu.USTAWIENIAPATH, ustawienia);
            }
            else
            {
                MessageBox.Show("Plik w lokalizacji '" + textBoxLokalizacjaPrzerywanej.Text + "' nie istnieje. Nie zapisano zmain dla pola 'PLIK PRZERYWANA'", "Błąd");
            }
            WczytajWszystko();
        }

        private void ButtonOpcjeZapiszIWyjdz_Click(object sender, EventArgs e)
        {
            string curFile = @textBoxLokalizacjaPrzerywanej.Text;
            if (File.Exists(curFile))
            {
                ustawienia[19] = textBoxLokalizacjaPrzerywanej.Text;
                File.WriteAllLines(GlownaPetlaProgramu.USTAWIENIAPATH, ustawienia);
                Application.Restart();
            }
            else
            {
                MessageBox.Show("Plik w lokalizacji '" + textBoxLokalizacjaPrzerywanej.Text + "' nie istnieje. Nie zapisano zmain dla pola 'PLIK PRZERYWANA'", "Błąd");
                Application.Restart();
            }

        }

        public void ButtonRequestSAP_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxqty.Text) && string.IsNullOrEmpty(textBoxpn.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Czy na pewno wysłać dane do SAP? Pomyłka oznacza ręczne usuwanie danych z SAP i bieganie po ludziach pół dnia.", "SAP request", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SAPrequestCustom(textBoxqty.Text, textBoxpn.Text);
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        public void WczytajWszystko()
        {
            ustawienia = File.ReadAllLines(GlownaPetlaProgramu.USTAWIENIAPATH);

            bool CzySAP = true;
            bool CzyPrzerywana = true;


            textBoxIPFIS.Text = ustawienia[1];
            textBoxPortFIS.Text = ustawienia[3];
            textBoxNazwaStacji.Text = ustawienia[5];

            if (ustawienia[9] == "0")
            {
                CzySAP = false;

            }
            radioSAPKomunikacjaTak.Checked = CzySAP;
            radioSAPKomunikacjaNie.Checked = !CzySAP;
            textBoxIPSAP.Text = ustawienia[10];
            textBoxPortSAP.Text = ustawienia[11];
            textBoxCOMSkKartonu.Text = ustawienia[13];
            textBoxCOMSkDetalu.Text = ustawienia[15];
            textBoxLokalizacjaPrzerywanej.Text = ustawienia[19];

            if (ustawienia[17] == "0")
            {
                CzyPrzerywana = false;

            }
            radioCzyPrzerywanaTak.Checked = CzyPrzerywana;
            radioCzyPrzerywanaNie.Checked = !CzyPrzerywana;

            for (int i = 0; i < System.IO.Ports.SerialPort.GetPortNames().Length; i++)
            {
                Porty.Add(System.IO.Ports.SerialPort.GetPortNames()[i]);
            }
        }

        private void buttonPingSAP_Click(object sender, EventArgs e)
        {
            listBoxPingSAP.Items.Clear();
            foreach (string adres in GlownaPetlaProgramu.sapIpLista)
            {
                listBoxPingSAP.Items.Add(GlownaPetlaProgramu.Ping(adres));
            }
        }

        private void buttonPingFIS_Click(object sender, EventArgs e)
        {
            listBoxPingFIS.Items.Clear();
            listBoxPingFIS.Items.Add(GlownaPetlaProgramu.Ping(textBoxIPFIS.Text));
        }
    }
}
