using CustomExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;

namespace Central_pack
{
    partial class Declarations
    {

        string SendToSAP(String server, String message, Int32 portNumber, bool closeSocket = false)
        {
            string error;
            try
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                TcpClient client = new TcpClient(server, portNumber);
                NetworkStream streamSAP = client.GetStream();
                streamSAP.ReadTimeout = 10000;
                streamSAP.WriteTimeout = 10000;
                streamSAP.Write(data, 0, data.Length);
                if (closeSocket)
                {
                    streamSAP.Close();
                    client.Close();
                    return "Done. Closed socket";
                }
                String responseData = String.Empty;
                data = new Byte[256];
                Int32 bytes = streamSAP.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                streamSAP.Close();
                client.Close();
                bytes = 0;
                return responseData;
            }
            catch (Exception e)
            {
                error = "Problem z wysyłką , " + e.ToString();
                return error;
            }
        }

        public void SapRequestSendFromQueue(string SAPQueueFilePath)
        {
            if (!File.Exists(SAPQueueFilePath)) return;

            if (new FileInfo(SAPQueueFilePath).Length == 0)
            {
                File.Delete(SAPQueueFilePath);
                return;
            }

            QueueSAPFile = new List<string>(File.ReadAllLines(SAPQueueFilePath));

            for (int i = 0; i < QueueSAPFile.Count; i++)
            {
                string msg = QueueSAPFile[i];
                if (msg.Contains("<REQUEST>PACK<WHSECODE>PL02</WHSECODE><SERIALNUM>"))
                {
                    string[] backFlashKolejkaDanePlikArray = QueueSAPFile.ToArray();
                    File.WriteAllLines(SAPQueueFilePath, backFlashKolejkaDanePlikArray);
                    string response="Pusty";
                    MyExtensions.Log($"Proba wysylki z pliku: {msg} {settingsFile.PrimarySAPIp} {settingsFile.SapPort}", "SAP");
                    response = SendToSAP(settingsFile.PrimarySAPIp, msg, int.Parse(settingsFile.SapPort));
                    if (response.Contains("OK"))
                    {
                        var lines = File.ReadAllLines(SAPQueueFilePath).Where(line => line.Trim() != msg).ToArray();
                        File.WriteAllLines(SAPQueueFilePath, lines);

                        SapChangeState(1);
                        MyExtensions.Log($"Response from SAP: {response}", "SAP");
                    }
                    else
                    {
                        SapChangeState(0);
                    }
                }
            }
        }

        void SaveToSAPQueue(string plikKolejka, string msg)
        {
            SapChangeState(0);
            using (StreamWriter sw = File.AppendText(plikKolejka))
                sw.WriteLine(msg);
            MyExtensions.Log("Wpisano do pliku", "SAP");
        }

        public bool SAPCreateRequest(string qty, string pn, string sn, string plikKolejka)
        {
            if (settingsFile.Sap == "0") return false;

            DateTime time = DateTime.Now;
            string standardFormat = "yyyy-MM-dd-HH.mm.ss.000000";
            string msg = $"<REQUEST>PACK<WHSECODE>PL02</WHSECODE><SERIALNUM>{sn}</SERIALNUM><DEPTNO>{pn}</DEPTNO><QTY>{qty}</QTY><CARTONTMSTMP>{time.ToString(standardFormat)}</CARTONTMSTMP><DESTCD>UNKNOWN</DESTCD></REQUEST>";
            //MyExtensions.Log(msg, "SAP");
            try
            {
                string response = "";
                MyExtensions.Log($"{msg}", "SAP");
                response = SendToSAP(settingsFile.PrimarySAPIp, msg, int.Parse(settingsFile.SapPort));
                MyExtensions.Log($"{response}", "SAP");
                if (response.Contains("OK"))
                {
                    SapChangeState(1);
                    return true;
                }

                SaveToSAPQueue(plikKolejka, msg);
                MyExtensions.Log($"Problem z połączeniem z serwerami SAP. Wiadomosc do wysłania {msg}. Wiadomosc zapisano do pliku {plikKolejka} do powtórnej wysyłki.", "SAP");
                return false;
            }
            catch (Exception e)
            {
                SaveToSAPQueue(plikKolejka, msg);
                MyExtensions.Log($"Przy wysyłce do SAP wystąpił błąd: {e}. Wiadomosc do wysłania {msg}. Wiadomosc zapisano do pliku {plikKolejka} do powtórnej wysyłki.", "SAP");
                return false;
            }
        }

        public static void StartFISConnection()
        {
            try
            {
                fisClient = new TcpClient(settingsFile.FisIp, int.Parse(settingsFile.FisPort));
                streamFIS = fisClient.GetStream();
            }
            catch (Exception e)
            {
                MyExtensions.Log($"error {e.ToString()} nieudane połączenie z FIS", "Regular");
            }
        }

        public static void StopFISConnection()
        {
            try
            {
                streamFIS.Close();
                fisClient.Close();
            }
            catch (Exception e)
            {
                MyExtensions.Log($"error {e.ToString()} nieudane połączenie z FIS", "Regular");

            }
        }

    }   
}
