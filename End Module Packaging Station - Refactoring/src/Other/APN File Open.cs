using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using CustomExtensions;

namespace Central_pack_Refactoring
{
    partial class Declarations : Form
    {
        public bool ParseDataFromAPNFile(string id)      /////znalezienie i przeparsowanie pliku konfiguracyjnego
        {
            string PN = id.Substring(0, 8);
            APNFileData = LoadAPNFIle(PN);
            if (APNFileData == null)
                return false;

            if (id.Length == 11)
                PackingType = id.Substring(9, 2);
            else
                PackingType = "";
            string result;
            try
            {
                result = APNFileData.FirstOrDefault(l => l.StartsWith("CodeTypeSN"));
            }
            catch(Exception)
            {
                MyExtensions.Log($"Nieprawidłowy format pliku typu {APNFileData}, nie znaleziono linii z danymi -CodeTypeSN-","Regular");
                return false;
            }

            string path = string.Empty;

            IfASNAndFormat = APNFileData.FirstOrDefault(l => l.StartsWith("CodeTypeASN="));
            CartonSerialNumberFormat = result.Replace("CodeTypeSN=", "");
            result = APNFileData.FirstOrDefault(l => l.StartsWith("CodeTypeDPN"));
            APNFormat = result.Replace("CodeTypeDPN=", "");
            result = APNFileData.FirstOrDefault(l => l.StartsWith("DPN="));
            APNFromAPNFile = result.Replace("DPN=", "");

            for (int i = 0; i < APNFileData.Length; i++)
            {
                if (!APNFileData[i].Contains($"CartonType= {PackingType}"))   //Szukaj wymiarów pod typ pakowania w pliku typu PN
                    continue;

                for (int n = i; n < APNFileData.Length; n++)
                {
                    if (!APNFileData[n].Contains("Layout="))
                        continue;

                    string wymiaryTemp = APNFileData[n].Replace("Layout=", "");
                    string[] wymiaryTempTablica = wymiaryTemp.Split('x');

                    Int32.TryParse(wymiaryTempTablica[0], out cartonWidthVisualization);
                    Int32.TryParse(wymiaryTempTablica[1], out cartonHeightVisualization);

                    cartonHeightVisualization = 0;
                    cartonWidthVisualization = 0;

                    break;
                }

                break;
                
            }

            if (cartonWidthVisualization == 0 && cartonHeightVisualization == 0)
            {
                try
                {
                    string wymiaryTemp = APNFileData.FirstOrDefault(l => l.StartsWith("Layout="));
                    wymiaryTemp = result.Replace("Layout=", "");                                
                    string[] wymiaryTempTablica = wymiaryTemp.Split('x');                       
                                                                                                
                    if (!Int32.TryParse(wymiaryTempTablica[0], out cartonWidthVisualization))   
                        cartonWidthVisualization = 0;                                           
                                                                                                
                    if (!Int32.TryParse(wymiaryTempTablica[1], out cartonHeightVisualization))                                                                      
                        cartonHeightVisualization = 0;                                          

                }
                catch (Exception)
                {
                    cartonWidthVisualization = 0;
                    cartonHeightVisualization = 0;
                }
            }


            if (CartonSerialNumberFormat == "")
            {
                MsgBoxShow($"Problem z plikiem konfiguracyjnym {PN} zmienna CodeTypeSN jest pusta", Color.Yellow);
                return false;
            }
            else if (APNFormat == "")
            {
                MsgBoxShow($"Problem z plikiem konfiguracyjnym {PN} zmienna CodeTypeDPN jest pusta", Color.Yellow);
                return false;
            }
            else if (APNFromAPNFile == "")
            {
                MsgBoxShow($"Problem z plikiem konfiguracyjnym {PN} zmienna CodeDPN jest pusta", Color.Yellow);
                return false;
            }
            else
                return true;

        }

        private string[] LoadAPNFIle(string PN)
        {

            try
            {
                return File.ReadAllLines(APNFileFolderPath + PN + ".txt");
            }
            catch (FileNotFoundException)
            {
                ResponseMsg($"Nie znaleziono pliku konfiguracyjnego: {PN}", Color.Yellow);
                return null;
            }
            catch (Exception e)
            {
                MsgBoxShow($"Niespodziewany problem z wczytaniem pliku typu: {e}", Color.Yellow);
                return null;
            }

        }
    }
}