using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

using CustomExtensions;

namespace Central_pack
{
    partial class InterruptedProduction : Declarations
    {
        public static void SaveWholeInterruptedProductionFile()
        {
            if (settingsFile.LegacyInterruptedProductionMethodOn == "1") return;
            Thread.Sleep(5);
            bool isNotEmpty = InterruptedProductionFile.Any();
            if (!String.IsNullOrEmpty(settingsFile.ActualInterruptedProductionFileLocation) && isNotEmpty)
                File.WriteAllLines(settingsFile.ActualInterruptedProductionFileLocation, InterruptedProductionFile.ToArray());
        }

        public static bool LoadInterruptedProductionFile()
        {
            try
            {
                InterruptedProductionFile = new List<string>(File.ReadAllLines(settingsFile.ActualInterruptedProductionFileLocation));
            }
            catch (FileNotFoundException)
            {
                //SaveWholeInterruptedProductionFile();
                MyExtensions.Log($"Plik przerywanej produkcji nie istnieje. Kontynuuję pracę.", "Regular");
                return false;
            }
            catch (Exception)
            {
                MyExtensions.Log($"Problem z dostepem do pliku przerywanej produkcji.", "Regular");
                return false;
            }
            MyExtensions.Log($"LoadPrzerywana OK {settingsFile.ActualInterruptedProductionFileLocation}", "Regular");
            return true;
        }

        public static string SaveOneRecordToInterruptedProductionFile(string PN, string SN, string packingType, int cartonCapacity, int productsInCarton)
        {
            if (!LoadInterruptedProductionFile())
                return "LOAD ERROR";

            if (settingsFile.LegacyInterruptedProductionMethodOn == "1")
            {
                return LegacySaveOneRecordToInterruptedProductionFile(PN, SN, packingType, cartonCapacity, productsInCarton);
            }
            else
            {
                return RegularSaveOneRecordToInterruptedProductionFile(PN, SN);
            }
        }

        private static string RegularSaveOneRecordToInterruptedProductionFile(string PN, string SN)
        {
            foreach (string line in InterruptedProductionFile)
            {
                if (line == $"{PN} {SN}")
                {
                    MyExtensions.Log($"SavePrzerywana |{PN} {SN}| JUZ JEST", "Regular");
                    return "JUZ JEST";
                }
            }

            for (int attempts = 0; attempts < 3; attempts++)
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(settingsFile.ActualInterruptedProductionFileLocation))
                        sw.WriteLine(PN + " " + SN);

                    MyExtensions.Log($"SavePrzerywana |{PN} {SN}| OK", "Regular");
                    return "OK";
                }
                catch (Exception)
                {
                    Thread.Sleep(5);
                }
            }
            return "SAVE ERROR";
        }

        private static string LegacySaveOneRecordToInterruptedProductionFile(string PN, string SN, string packingType, int cartonCapacity, int productsInCarton)
        {
            foreach (string line in InterruptedProductionFile)
            {
                if (line == $"[{SN}]")
                {
                    MyExtensions.Log($"LegacySavePrzerywana |[{SN}]| JUZ JEST", "Regular");
                    return "JUZ JEST";
                }
            }

            for (int attempts = 0; attempts < 3; attempts++)
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(settingsFile.ActualInterruptedProductionFileLocation))
                    {
                        sw.WriteLine($"[{SN}]");
                        sw.WriteLine($"Date={DateTime.Now.ToString("yyyy-MM-dd hh:mm:tt:ss")}");
                        sw.WriteLine($"ProdOrder={SN}");
                        sw.WriteLine($"CartonLabel={PN}");
                        sw.WriteLine($"CartonFillQty={cartonCapacity}");
                        sw.WriteLine($"CartonCurrentQty={productsInCarton}");
                        sw.WriteLine($"LOT={SN}");
                        sw.WriteLine($"DPN={PN.Substring(0, 8)}");
                        sw.WriteLine(packingType == "-" ? $"CartonType=01" : $"CartonType={packingType}");
                        sw.WriteLine($"CartonSN={SN}");
                    }
                    MyExtensions.Log($"LegacySavePrzerywana {PN} {SN} OK", "Regular");
                    return "OK";
                }
                catch (Exception)
                {
                    Thread.Sleep(5);
                }
            }

            return "SAVE ERROR";
        }

        public static bool RemoveFromInterruptedProduction(string SN)
        {
            if (!LoadInterruptedProductionFile())
                return false;
            if (settingsFile.LegacyInterruptedProductionMethodOn == "1")
            {
                return LegacyRemoveFromInterruptedProduction(SN);
            }
            else
            {
                return RegularRemoveFromInterruptedProduction(SN);
            }
        }

        private static bool RegularRemoveFromInterruptedProduction(string SN)
        {
            if (InterruptedProductionFile.RemoveAll(u => u.Contains(SN)) > 0) //usun z listy wszystko co zawiera SN i sprawdz czy zostala usunieta wieksza niz 0 ilosc elementow
            {
                try
                {
                    File.WriteAllLines(settingsFile.ActualInterruptedProductionFileLocation, InterruptedProductionFile.ToArray());
                    MyExtensions.Log($"RegularRemoveFromInterruptedProduction |{SN}| OK", "Regular");
                    return true;
                }
                catch (Exception)
                {
                    MyExtensions.Log($"RegularRemoveFromInterruptedProduction |{SN}| FAIL", "Regular");
                }
            }
            return false;
        }

        private static bool LegacyRemoveFromInterruptedProduction(string SN)
        {
            int indexToDelete = InterruptedProductionFile.IndexOf($"[{SN.Replace("3S", "")}]");

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    InterruptedProductionFile.RemoveAt(indexToDelete);
                }
                File.WriteAllLines(settingsFile.ActualInterruptedProductionFileLocation, InterruptedProductionFile.ToArray());
                MyExtensions.Log($"LegacyRemoveFromInterruptedProduction |{SN}| OK", "Regular");
                return true;
            }
            catch (Exception)
            {
                MyExtensions.Log($"LegacyRemoveFromInterruptedProduction |{SN}|, failed to delete index from list: InterruptedProductionFile", "Regular");
            }
            return false;
        }

        public static string SearchInterruptedProduction(string pn, string sn)
        {
            if (!LoadInterruptedProductionFile())
                return "LOAD ERROR";

            var returnValue = settingsFile.LegacyInterruptedProductionMethodOn == "1" ? LegacySearchInterruptedProduction(pn) : RegularSearchInterruptedProduction(pn);
            return returnValue;
        }

        private static string RegularSearchInterruptedProduction(string pn)
        {
            string result = InterruptedProductionFile.FirstOrDefault(l => l.StartsWith(pn));
            if (string.IsNullOrEmpty(result))
                return "OK";
            return result.Replace(pn, "").Trim();

            //if (id == sn)
            //{
            //    MyExtensions.Log($"PrzeszukajPrzerywana |{id}|", "Regular");
            //    return id;
            //}
            //
            //string response = BCRTCN(id, "0", pn, "sprawdz");
            //if (!(id == "" || response.Contains("jest juz zamkniete") || response.Contains("ERROR")))  //sprawdzenie czy karton z przerywanej dla tego numeru nie jest juz zamkniety w fis, jak tak to do usuniecia z przerywanej
            //{
            //    MyExtensions.Log($"PrzeszukajPrzerywana |{id}|", "Regular");
            //    return id;
            //}
            //
            //if (RemoveFromInterruptedProduction(id))
            //{
            //    MyExtensions.Log($"Pętla PrzeszukajPrzerywana |{pn}|", "Regular");
            //    return SearchInterruptedProduction(pn, sn); //Pętla; szukaj póki string.IsNullOrEmpty(result) będzie true albo znajdziesz SN który nie jest zamkniety w FIS.
            //}
            //else
            //{
            //    MyExtensions.Log("PrzeszukajPrzerywana LOAD ERROR", "Regular");
            //    return "LOAD ERROR";
            //}
        }

        private static string LegacySearchInterruptedProduction(string pn)
        {
            string cartonLabelString = $"CartonLabel={pn}";
            string result = InterruptedProductionFile.FirstOrDefault(l => l.StartsWith(cartonLabelString));
            if (string.IsNullOrEmpty(result))
                return "OK";

            string id = InterruptedProductionFile[InterruptedProductionFile.IndexOf(cartonLabelString) - 1].Replace("ProdOrder=", "");
            MyExtensions.Log($"Id z przerywanej:  {id}", "Regular");
            return id;

            //if (RemoveFromInterruptedProduction(id))
            //{
            //    MyExtensions.Log($"Pętla PrzeszukajPrzerywana {pn}", "Regular");
            //    return id; //Pętla; szukaj póki string.IsNullOrEmpty(result) będzie true albo znajdziesz SN który nie jest zamkniety w FIS.
            //}
            //else
            //{
            //    MyExtensions.Log("PrzeszukajPrzerywana LOAD ERROR", "Regular");
            //    return "LOAD ERROR";
            //}
        }

        public bool CleanupInterruptedProduction()
        {
            if (LoadInterruptedProductionFile())
            {
                string record;
                for (var i = 0; i < InterruptedProductionFile.Count; i++)
                {
                    if (InterruptedProductionFile[i] == "")
                    {
                        RemoveFromInterruptedProduction(InterruptedProductionFile[i]);
                    }

                    if ((InterruptedProductionFile[i].Length != 18) && !MyExtensions.MadeOfAtLeastOneNumberAndSpaces(InterruptedProductionFile[i]))
                    {
                        RemoveFromInterruptedProduction(InterruptedProductionFile[i]);
                    }

                    record = InterruptedProductionFile[i].Substring(9, InterruptedProductionFile[i].Length - 9);
                    //MessageBox.Show(rekord);
                    string recordStatus = GETCHILDREN(record);
                    Thread.Sleep(5);

                    if (recordStatus.Contains("NOT EXIST") || recordStatus.Contains("NO CHILDREN"))
                    {
                        RemoveFromInterruptedProduction(record);
                    }
                }
                return true;
            }
            return false;
        }
    }
}