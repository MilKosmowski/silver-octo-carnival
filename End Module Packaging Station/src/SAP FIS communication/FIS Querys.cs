using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using CustomExtensions;

namespace Central_pack
{
    partial class Declarations
    {
        private static string SendToFIS(String message, NetworkStream stream)
        {
            try
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                data = new Byte[4056];
                stream.ReadTimeout = 5000;
                stream.WriteTimeout = 5000;
                string Wynik = System.Text.Encoding.ASCII.GetString(data, 0, stream.Read(data, 0, data.Length));
                return Wynik;
            }

            catch (Exception e)
            {
                string error = $"error {e.ToString()}";
                stream.Close();
                return error;
            }
        }

        public static string SendToFISLogAndReturnResponseFromFIS (string msg)
        {
            MyExtensions.Log($"Zapytanie FIS: {msg}", "Regular");
            msg = SendToFIS(msg, streamFIS);
            MyExtensions.Log($"Odpowiedz FIS: {msg}", "Regular");
            return msg;
        }

        public static string BREQUK1(string id) 
        {
            string msg = $"BREQ|id={id}|station={settingsFile.Station}|process={settingsFile.Process}|status=PASS|get=uk1\n";
            return SendToFISLogAndReturnResponseFromFIS(msg);
        }

        public static string BREQUK2(string id)
        {
            string msg = $"BREQ|id={id}|station={settingsFile.Station}|process={settingsFile.Process}|status=PASS|get=uk2\n";
            msg = SendToFISLogAndReturnResponseFromFIS(msg);
            return BREQResponse(msg, id);
        }

        public static string BREQResponse(string msg, string id)
        {
            if (msg.Contains("BCNF") && msg.Contains(id) && msg.Contains("PASS"))
            {
                return msg;
            }
            else
            {
                return CheckForResponseInCaseOfMissingSymbols(msg);
            }
        }                                                         

        public static string GETCHILDREN(string id) // Check if product label had children paired to it
        {
            string msg = "GETCHILDREN|id=" + id + "\n";
            return SendToFISLogAndReturnResponseFromFIS(msg);
        }

        public static string SendGETCHILDRENQueryAddTProductsInCartonAndReturnResponse(string id)
        {
            string msg = GETCHILDREN(id);
            char[] separator = new char[] { ' ' };
            if (!msg.Contains("NOT EXIST") && !msg.Contains("NO CHILDREN") && !string.IsNullOrEmpty(msg))
            {
                productsInCarton.Clear();

                string [] productsInCartonString = msg.Split(separator, StringSplitOptions.None);
                foreach (string arrItem in productsInCartonString)
                {
                    productsInCarton.Add(arrItem.Replace("\n",""));
                }
                return "PASS";
            }
            else
            {
                return msg;
            }
        }

        public static string BCMPU(string id, string lot, string partnumber) //Pair product to carton
        {
            string msg = "BCMPU|id=" + id + "|station=" + settingsFile.Station + "|lot=" + lot + "|process=" + settingsFile.Process + "|delphipartnumber=" + partnumber.Substring(0, 8) + "|status=FINISHED\n";
            msg = SendToFISLogAndReturnResponseFromFIS(msg);

            return BCMPUResponse(msg, id);
        }

        public static string BCMPUResponse(string msg, string id)
        {
            if (msg.Contains("BCMPUACK") && msg.Contains(id) && msg.Contains("PASS"))
            {
                return "PASS";
            }
            else
            {
                return CheckForResponseInCaseOfMissingSymbols(msg);
            }
        }

        public static string BCRTCN(string lot, string qty, string partnumber, string polecenie) //Create new carton label/ check label status / close carton label
        {
            if (qty == "0") { qty = ""; }

            string msg = "BCRTCN|lot=" + lot + "|process=" + settingsFile.Process + "|station=" + settingsFile.Station + "|qty=" + qty + "|delphipartnumber=" + partnumber.Substring(0, 8) + "|status=PASS\n"; /////PASS - czy istnieje, jak nie to stworz

            if (polecenie.Contains("zamknij"))
            {
                msg = "BCRTCN|lot=" + lot + "|process=" + settingsFile.Process + "|station=" + settingsFile.Station + "|qty=" + qty + "|delphipartnumber=" + partnumber.Substring(0, 8) + "|status=FINISHED\n"; /////// FINISHED - zamknij opakowanie
            }
            msg = SendToFISLogAndReturnResponseFromFIS(msg);

            return BCRTCNResponse(msg, lot);
        }

        public static string BCRTCNResponse(string msg, string lot)
        {

            if (msg.Contains("Blad zapisu do bazy danych dla opakowania") && msg.Contains(lot)) //Sending reply: BCRTCNACK|lot=123123121|status=FAIL|msg=Utowrzenie opakowania; Blad zapisu do bazy danych dla opakowania o numerze partii: 123123121
            {
                return "Blad zapisu";
            }

            if (msg.Contains("BCRTCNACK") && msg.Contains(lot) && msg.Contains("PASS") && msg.Contains("zamkniete - Dane wprowadzone do bazy danych")) //Sending reply: BCRTCNACK|lot=xxxxxxxxx|status=PASS|msg=Opakowanie xxxxxxxxx zamkniete - Dane wprowadzone do bazy danych
            {
                return "zamknieto";
            }

            if (msg.Contains("BCRTCNACK") && msg.Contains(lot) && msg.Contains("PASS") && msg.Contains("przygotowane od zaladunku")) //Sending reply: BCRTCNACK|lot=xxxxxxxxx|status=PASS|msg=Opakowanie: xxxxxxxxx przygotowane od zaladunku
            {
                return "PASS";
            }

            if (msg.Contains("PASS") && msg.Contains("istnieje") && msg.Contains(lot)) //Sending reply: BCRTCNACK|lot=xxxxxxxxx|status=PASS|msg=nr partii: xxxxxxxxx, istnieje juz w bazie FIS-QTS
            {
                return "PASS istnieje";
            }

            if (msg.Contains("jest juz zamkniete") && msg.Contains(lot)) //Sending reply: BCRTCNACK|lot=xxxxxxxxx|status=FAIL|msg=Opakowanie xxxxxxxxx jest juz zamkniete
            {
                return "jest juz zamkniete";
            }

            if (msg.Contains("Nieprawidlowy numer (DPN)") && msg.Contains(lot)) //Sending reply: BCRTCNACK|lot=xxxxxxxxx|status=FAIL|msg=Opakowanie xxxxxxxxx jest juz zamkniete
            {
                return "Nieprawidlowy APN";
            }

            return "ERROR" + CheckForResponseInCaseOfMissingSymbols(msg);
        }

        private static string CheckForResponseInCaseOfMissingSymbols(string msg) //Przeszuaknie komunikatu jak nic nie znajdzie 
        {
            string[] response = msg.Split('|', '=');
            if (response.Contains("msg"))
            {
                int findmsg = Array.IndexOf(response, "msg");
                if (response[findmsg + 1] != "")
                {
                    return response[findmsg + 1];
                }
                else
                {
                    return "UNKNOWN error";
                }
            }
            else
            {
                return "UNKNOWN error";
            }
        }
    }
}
