using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace CustomExtensions
{
    public static class MyExtensions
    {
        public static bool IsNullOrEmpty(this Array array)
        {
            return (array == null || array.Length == 0);
        }

        public static bool IsEmpty<T>(List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return list.FirstOrDefault() != null;
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

        public static int[] HowManyRowsAndColumns(int Row)
        {
            int Column = 1;
            int[] result = new int[] { 1, 1 };

            if (Row <= 0) throw new System.ArgumentException("Wiersz nie może być ujemny ani zerowy", "original");

            if (Row > 200 && Row % 8 == 0)
            {
                Column = 8;
            }
            else if (Row > 120 && Row % 6 == 0)
            {
                Column = 6;
            }
            else if (Row > 100 && Row % 4 == 0)
            {
                Column = 4;
            }
            else if (Row > 60 && Row % 3 == 0)
            {
                Column = 3;
            }
            else if (Row > 50 && Row % 2 == 0)
            {
                Column = 2;
            }
            result = new int[] { Row / Column, Column };
            return result;
        }

        public static string SerialPortOutputCleanup(string id)
        {
            id = Regex.Replace(id, @"[\u0000-\u001F]", string.Empty); //remove ETX STX

            id = id.Replace("\n", "");
            id = id.Replace("\r", "");
            id = id.Replace(" ", "");
            id = id.ToUpper();

            return id;
        }

        public static void Log(string msg, string logSAPOrRegular)
        {
            DateTime time = DateTime.Now;
            msg = msg.Replace("/n", "");
            msg = msg.Replace("\n", "");
            string writeLogPathFile = Directory.GetCurrentDirectory() + @"\log\" + time.ToString("yyyy-MM-dd") + ".txt";
            string writeLogPathDirectory = Directory.GetCurrentDirectory() + @"\log\";
            string writeLogPathSAPFile = Directory.GetCurrentDirectory() + @"\logSAP\" + time.ToString("yyyy-MM-dd") + ".txt";
            string writeLogPathSAPDirectory = Directory.GetCurrentDirectory() + @"\logSAP";
            string file = writeLogPathFile;
            string directory = writeLogPathDirectory;
            if (logSAPOrRegular == "SAP")
            {
                file = writeLogPathSAPFile;
                directory = writeLogPathSAPDirectory;
            }
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (File.Exists(file))
            {
                using (StreamWriter writer = new StreamWriter(file, true))
                {
                    writer.Write(time.ToString("hh:mm:ss") + " " + msg + Environment.NewLine);
                }
            }
            else
            {
                var myFile = File.CreateText(file);
                myFile.Close();
                MyExtensions.Log(msg, logSAPOrRegular);
            }
        }

        public static void Log(string msg)
        {
            Log(msg, "Regular");
        }

        public static void StartConnection(ref NetworkStream stream, TcpClient client)
        {
            try
            {
                stream = client.GetStream();
            }
            catch (Exception e)
            {
                MyExtensions.Log($"error {e} nieudane połączenie z {client}", "Regular");
            }

        }

        public static void CloseConnection(ref NetworkStream stream, TcpClient client)
        {
            try { stream.Close(); client.Close(); }
            catch (NullReferenceException e) { MyExtensions.Log($"Próba zamknięcia połączenia {client} nie powiodła się:  {e}", "Regular"); }
            catch (Exception e) { MyExtensions.Log($"Próba zamknięcia połączenia {client} nie powiodła się:  {e}", "Regular"); }
            
        }

        public static bool MadeOfAtLeastOneNumberAndSpaces(string str)
        {
            bool AtLeastOneNumber = false;
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && !Char.IsWhiteSpace(c))
                    return false;
                else if ((c > '0' || c < '9'))
                    AtLeastOneNumber = true;
            }
            if (AtLeastOneNumber)
                return true;
            else
                return false;
        }

        public static bool IsValidDomainName(string name)
        {
            return Uri.CheckHostName(name) != UriHostNameType.Unknown;
        }
    }
}
