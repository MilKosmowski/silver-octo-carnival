using System;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.Sockets;

namespace UniwersalneMetody
{
    public static class MojeMetody
    {
        public static bool IsNullOrEmpty(this Array array)
        {
            return (array == null || array.Length == 0);
        }

        public static string Ping(string address)
        {
            //string to hold our return messge
            string returnMessage = string.Empty;

            //IPAddress instance for holding the returned host
            //IPAddress address = GetIpFromHost(ref host);

            //set the ping options, TTL 128
            PingOptions pingOptions = new PingOptions(128, true);

            //create a new ping instance
            Ping ping = new Ping();

            //32 byte buffer (create empty)
            byte[] buffer = new byte[32];

            try
            {
                //send the ping 4 times to the host and record the returned data.
                //The Send() method expects 4 items:
                //1) The IPAddress we are pinging
                //2) The timeout value
                //3) A buffer (our byte array)
                //4) PingOptions
                PingReply pingReply = ping.Send(address, 1000, buffer, pingOptions);

                //make sure we dont have a null reply
                if (!(pingReply == null))
                {
                    switch (pingReply.Status)
                    {
                        case IPStatus.Success:
                            returnMessage = string.Format("{0} B={1} T={2}ms TTL={3}", pingReply.Address, pingReply.Buffer.Length, pingReply.RoundtripTime, pingReply.Options.Ttl);
                            break;
                        case IPStatus.TimedOut:
                            returnMessage = "Connection has timed out...";
                            break;
                        default:
                            returnMessage = string.Format("Ping failed: {0}", pingReply.Status.ToString());
                            break;
                    }
                }
                else
                    returnMessage = "Connection failed for an unknown reason...";
            }
            catch (PingException ex)
            {
                returnMessage = string.Format("Connection Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                returnMessage = string.Format("Connection Error: {0}", ex.Message);
            }



            //return the message
            return returnMessage;
        }

        public static int[] WymiaryIWyswietl(int Wiersz)
        {
            int Kolumna = 1;
            int[] wynik = new int[] { 1, 1 };

            if (Wiersz <= 0) throw new System.ArgumentException("Wiersz nie może być ujemny ani zerowy", "original");

            if (Wiersz > 200 && Wiersz % 8 == 0)
            {
                Kolumna = 8;
            }
            else if (Wiersz > 120 && Wiersz % 6 == 0)
            {
                Kolumna = 6;
            }
            else if (Wiersz > 100 && Wiersz % 4 == 0)
            {
                Kolumna = 4;
            }
            else if (Wiersz > 60 && Wiersz % 3 == 0)
            {
                Kolumna = 3;
            }
            else if (Wiersz > 50 && Wiersz % 2 == 0)
            {
                Kolumna = 2;
            }
            wynik = new int[] { Wiersz / Kolumna, Kolumna };
            return wynik;
            //WizualizacjaZawartościKartonu(Wiersz, Kolumna);
        }

        public static string CzyszczenieWejsciaZeSmieciZCOM(string id)
        {
            id = Regex.Replace(id, @"[\u0000-\u001F]", string.Empty); //wywalenie kontrolnych znaków

            id = id.Replace("\n", "");
            id = id.Replace("\r", "");
            id = id.Replace(" ", "");
            id = id.ToUpper();

            return id;
        }

        public static void Log(string msg, string logSAPCzyZwykly)
        {
            DateTime time = DateTime.Now;
            msg = msg.Replace("/n", "");
            msg = msg.Replace("\n", "");
            string writeLogPath = Directory.GetCurrentDirectory() + @"\log\" + time.ToString("yyyy-MM-dd") + ".txt";
            string writeLogPathSAP = Directory.GetCurrentDirectory() + @"\logSAP\" + time.ToString("yyyy-MM-dd") + ".txt";
            string directory = writeLogPath;
            if (logSAPCzyZwykly == "SAP")
            {
                directory = writeLogPathSAP;
            }

            if (File.Exists(directory))
            {
                using (StreamWriter writer = new StreamWriter(@directory, true))
                {
                    writer.Write(time.ToString("hh:mm:ss") + " " + msg + Environment.NewLine);
                }
            }
            else
            {
                var myFile = File.CreateText(directory);
                myFile.Close();
                MojeMetody.Log(msg, logSAPCzyZwykly);
            }
        }

        public static NetworkStream UruchomPolaczenie(NetworkStream stream, TcpClient client)
        {
            try
            {
                stream = client.GetStream();
                return stream;
            }
            catch (Exception e)
            {
                MojeMetody.Log($"error {e.ToString()} nieudane połączenie z {client}", "Zwykly");
            }
            return stream;
        }

        public static void ZamknijPolaczenie(ref NetworkStream stream, TcpClient client)
        {
            try { stream.Close(); client.Close(); }
            catch (Exception e) { MojeMetody.Log($"Próba zamknięcia połączenia {client} nie powiodła się:  {e}", "Zwykly"); }
            
        }

        public static bool CzySkładaSieZCyfrISpacjiWTymPrzynajmniejJednejCyfry(string str)
        {
            bool CzyPrzynajmniejJednaCyfra = false;
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && !Char.IsWhiteSpace(c))
                    return false;
                else if ((c > '0' || c < '9'))
                    CzyPrzynajmniejJednaCyfra = true;
            }
            if (CzyPrzynajmniejJednaCyfra)
                return true;
            else
                return false;
        }
    }
}
