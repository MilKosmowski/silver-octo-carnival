using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using CustomExtensions;

namespace Central_pack
{
    partial class Declarations
    {

        bool Logic1P(string id)
        {
            if (id.Substring(0, 2) != "1P") return false;

            if (!int.TryParse(id.Substring(2, 8), out _)) return false;

            if (!ParseDataFromAPNFile(id.Substring(2))) return false;

            CartonLabelAPN = id.Substring(2);
            return true;
        }

        bool LogicQ(string id)
        {
            if (id.Substring(0, 1) != "Q") return false;

            CartonCapacityQString = id.Substring(1);

            if (!int.TryParse(CartonCapacityQString, out int number) && number>0)
            {
                MsgBoxShow($"Problem z ilością w kodzie Q: {CartonCapacityQString} <- to powinna być liczba naturalna.\n\nКількісна проблема в Q -> {CartonCapacityQString} <- має бути натуральним числом.", Color.Yellow);
                return false;
            }

            CartonCapacityQInteger = number;
            return true;
        }
        
        bool Logic3S(string id)
        {
            if (id.Substring(0, 2) != "3S") return false;

            CartonLabelSerialNumber = id.Substring(2);

            if (!int.TryParse(CartonLabelSerialNumber, out _))
            {
                MsgBoxShow($"Problem z kodem etykiety: {CartonLabelSerialNumber} Kod 3S ma nieprawidłowy format. Pobierz inną etykietę.\n\nКод 3S має неправильний формат. Завантажте іншу етикетку.", Color.Yellow);
                return false;
            }
            string przerywanaWynik;
            przerywanaWynik = InterruptedProduction.SearchInterruptedProduction(CartonLabelAPN, CartonLabelSerialNumber);
            MyExtensions.Log($"Przerywana wynik: {przerywanaWynik}", "Regular");

            StartFISConnection();

            if (id.Contains(przerywanaWynik))
                InterruptedProduction.RemoveFromInterruptedProduction(przerywanaWynik);
            else if (przerywanaWynik != "OK" && przerywanaWynik != "LOAD ERROR")
            {

                string recordStatus = GETCHILDREN(przerywanaWynik);

                if (recordStatus.Contains("NOT EXIST") || recordStatus.Contains("NO CHILDREN"))
                {
                    InterruptedProduction.RemoveFromInterruptedProduction(przerywanaWynik);
                }
                else
                {
                    MsgBoxShow($"Pakujesz PN {CartonLabelAPN}. Został zeskanowany karton {CartonLabelSerialNumber}. Pobierz karton {przerywanaWynik} z produkcji przerywanej.\n\nВи пакуєте PN {CartonLabelAPN}. Картон {CartonLabelSerialNumber} відскановано. Отримайте коробку {CartonLabelAPN} від періодичного виробництва.", Color.Yellow);
                    return false;
                }
            }

            string BCRTCNresponse = BCRTCN(CartonLabelSerialNumber, CartonCapacityQString, CartonLabelAPN, "stworz");

            switch (BCRTCNresponse)
            {
                case "Nieprawidlowy APN":
                    MsgBoxShow("APN wydrukowany na etykiecie nie zgadza się z APN etykiety w FIS. Wybierz inną etykietę.\n\nAPN, надрукований на етикетці, не відповідає APN етикетки у FIS. Виберіть іншу етикетку.", Color.Yellow);
                    StatusFail("Użyj innej etykiety.");
                    return false;
                //////////////////////////////
                case "jest juz zamkniete":
                    MsgBoxShow($"Etykieta {CartonLabelSerialNumber} już użyta i zamknięta. Pobierz nową etykietę.\n\nЕтикетка вже використовується та закрита. Завантажте нову етикетку.", Color.Yellow);
                    StatusFail($"Pobierz nową etykietę.\n\nЗавантажте нову етикетку.");
                    return false;
                //////////////////////////////
                case "PASS":
                    string BCRTCNresponsePassMsg = $"Utworzono etykietę: {id}.";
                    MyExtensions.Log(BCRTCNresponsePassMsg, "Regular");
                    StatusPass(BCRTCNresponsePassMsg);
                    OK3S(CartonLabelAPN, CartonLabelSerialNumber);
                    return true;
                //////////////////////////////
                case "PASS istnieje":
                    string OdpowiedzZFISGetchildren = SendGETCHILDRENQueryAddTProductsInCartonAndReturnResponse(CartonLabelSerialNumber);
                    if (OdpowiedzZFISGetchildren=="PASS")
                    {
                        if (AmountOfProductsInCarton >= CartonCapacityQInteger)
                        {
                            CartonFullSendItToFISAndSAPAndResetProgram(id);
                            return false;
                        }
                        MyExtensions.Log($"Etykieta {CartonLabelSerialNumber} została już użyta, ale nie jest pełna. Wczytywanie danych z FIS...", "Regular");
                        StatusPass($"Etykieta {CartonLabelSerialNumber} została już użyta, ale nie jest pełna. Wczytywanie danych z FIS...\n\n{CartonLabelSerialNumber} вже використано, але не заповнене. Завантаження даних з FIS ...");

                        OK3S(CartonLabelAPN, CartonLabelSerialNumber);
                        return true;
                    }

                    else
                    {
                        OK3S(CartonLabelAPN, CartonLabelSerialNumber);
                        return true;
                    }

                default:
                    MsgBoxShow($"Błędna odpowiedź z FIS dla kartonu. Pobierz inny karton. odpowiedź: {BCRTCNresponse}.\n\nНевірна відповідь FIS для коробки. Отримайте ще одну коробку. відповідь: {BCRTCNresponse}.", Color.GreenYellow);
                    return false;

            }

        }

        bool LogicBezelScan(string id)
        {
            string croppedAPNfromAssemblyLabel = ExtractDataFromProductScanner('S', IfASNAndFormat, id);
            if (CartonLabelAPN.Substring(0, 8) == croppedAPNfromAssemblyLabel)
                return true;
            else
            {
                ErrorTryScanningAnotherBoard($"APN na bezelu ({croppedAPNfromAssemblyLabel}) nie zgadza się z APN produktu ({CartonLabelAPN.Substring(0, 8)}).\n\nAPN на рамці ({croppedAPNfromAssemblyLabel}) не відповідає APN продукту ({CartonLabelAPN.Substring(0, 8)}).", Color.GreenYellow, $"APN na bezelu ({croppedAPNfromAssemblyLabel}) nie zgadza się z APN produktu ({CartonLabelAPN.Substring(0, 8)}).\n\nAPN на рамці ({croppedAPNfromAssemblyLabel}) не відповідає APN продукту ({CartonLabelAPN.Substring(0, 8)}).", Color.GreenYellow);
                return false;
            }

        }

        bool LogicProductScan(string id)
        {
                /////////////////
            if (CartonSerialNumberFormat.Length > id.Length)
            {
                MsgBoxShow($"Zeskanowano nieprawidłową etykietę. Kod powinien mieć {CartonSerialNumberFormat.Length} znaków, a ma {id.Length} znaków. Zeskanowany kod -> {id}.\n\nНедійсний ярлик відскановано. Код повинен містити {CartonSerialNumberFormat.Length} символів. Це символи {id.Length}. Відсканований код -> {id}.", Color.LightCoral);
                return true;
            }
            /////////////////
            APNInProductBarcode = ExtractDataFromProductScanner('D',APNFormat,id);
            id = ExtractDataFromProductScanner('N', CartonSerialNumberFormat, id);
            if (!pictureHasBeenSetUp) pictureHasBeenSetUp = ProductPackPictureSetup(ExtractUK1(id), PackingType, photoFolderPath);
            if (APNInProductBarcode != APNFromAPNFile)
            {
                ErrorTryScanningAnotherBoard($"PN z pliku konfiguracyjnego nie zgadza się z PN na produkcie. PN na produkcie {APNInProductBarcode} PN w pliku config: {APNFromAPNFile}.\n\nPN у файлі конфігурації не відповідає PN на продукті. PN для продукту: {APNInProductBarcode} PN у файлі: {APNFromAPNFile}.", Color.LightCoral, $"PN z pliku konfiguracyjnego nie zgadza się z PN na produkcie. PN na produkcie {APNInProductBarcode} PN w pliku config: {APNFromAPNFile}.\n\nPN у файлі конфігурації не відповідає PN на продукті. PN для продукту: {APNInProductBarcode} PN у файлі: {APNFromAPNFile}.", Color.LightCoral);
                return true;
            }
            /////////////////

            if (productsInCarton != null)
            {
                foreach (string oneid in productsInCarton)
                {
                    if (oneid.Contains(id))
                    {
                        ErrorTryScanningAnotherBoard($"Detal {id} juz spakowany do tego kartonu.\n\n{id} вже упаковано для цієї коробки", Color.Yellow);
                        return true;
                    }
                }
            }

            if (AmountOfProductsInCarton > CartonCapacityQInteger)
            {
                ErrorTryScanningAnotherBoard("Karton Przepełniony! Skontaktuj się z działem jakości.\n\nКартонна коробка повна! Зверніться до відділу якості.", Color.Yellow, "Karton Przepełniony!\n\nSkontaktuj się z działem jakości. Картонна коробка повна! Зверніться до відділу якості.", Color.Yellow);
                return false;
            }

            if (FISCheckBREQResponseIfOK(id)) return true;

            string responseBCMPU = BCMPU(id, CartonLabelSerialNumber, CartonLabelAPN);
            if (responseBCMPU.Contains("PASS"))
            {
                StatusPassPack(id);
                productsInCarton.Add(id);
                AmountPackedThisShift++;
                FromattedValueInCartonPackCounter = Convert.ToString(productsInCarton == null ? 0 : productsInCarton.Count);
                StatusPass(id);
            }
            else
            {
                MyExtensions.Log($"{id} - problem FIS ze spakowaniem produktu.", "Regular");
                StatusFail($"{id} - problem FIS ze spakowaniem produktu.\n\n{id} - Проблема FIS з упаковкою продукції.");
            }


            CommandMsg("Zeskanuj produkt.\n\nВідскануйте виріб.", Color.Aqua);

            UpdateCartonVisualization(AmountOfProductsInCarton);

            return PackFullCarton();
        }

        bool PackFullCarton()
        {
            if (AmountOfProductsInCarton == CartonCapacityQInteger && CartonLabelAPN != "" && CartonLabelSerialNumber != "")
            {
                previousCartonSerialNumber = CartonLabelSerialNumber;
                CartonFullSendItToFISAndSAPAndResetProgram(CartonLabelSerialNumber);
                StatusPassPack(CartonLabelSerialNumber);
                StopFISConnection();

                return false;
            }
            else return true;
        }

        void ErrorTryScanningAnotherBoard(string command,Color kolorResponseMsg)
        {
            ResponseMsg(command, kolorResponseMsg);
            CommandMsg("Zeskanuj produkt./n/nВідскануйте виріб.", Color.Aqua);
            panelCartonContentVisualization[AmountOfProductsInCarton].BackColor = Color.LightCoral;
        }

        void ErrorTryScanningAnotherBoard(string ResponseMsgText, Color kolorResponseMsg, string MsgBoxText, Color kolorMsgBox)
        {
            MsgBoxShow(MsgBoxText, kolorMsgBox);
            ErrorTryScanningAnotherBoard(ResponseMsgText,kolorResponseMsg);
        }

        bool ProductPackPictureSetup(string productFamily, string PackingType, string FilePath)
        {
            List<string> PhotoFileList = new List<string>();

            PhotoFileList = Directory.GetFiles(FilePath).ToList();

            foreach (string file in PhotoFileList)
            {
                string plikNazwa = System.IO.Path.GetFileName(file);
                if (SetPicture($"{productFamily}-{PackingType}", file, FilePath)) return true;
            }

            foreach (var file in PhotoFileList)
            {
                string plikNazwa = System.IO.Path.GetFileName(file);
                if (SetPicture($"{productFamily}{PackingType}", file, FilePath)) return true;
                if (SetPicture($"{productFamily} {PackingType}", file, FilePath)) return true;
                if (SetPicture($"{productFamily}-01", file, FilePath)) return true;
                if (SetPicture($"{productFamily} 01", file, FilePath)) return true;
                if (SetPicture($"{productFamily}01", file, FilePath)) return true;
                if (SetPicture($"{productFamily}", file, FilePath)) return true;
            }
            MyExtensions.Log($"Image for {productFamily}{PackingType} not found");
            return false;
        }

        bool SetPicture(string name, string file, string FilePath)
        {
            string combined = FilePath + $"\\{name}.jpg";
            if (file == combined)
            {
                MyExtensions.Log(combined);
                PackingPictureFilePath = Image.FromFile(combined);
                return true;
            }            return false;
        }

        void CartonFullSendItToFISAndSAPAndResetProgram(string id)
        {
            if (BCRTCN(CartonLabelSerialNumber, CartonCapacityQString, CartonLabelAPN, "zamknij").Contains("zamknieto"))
            {
                InterruptedProduction.RemoveFromInterruptedProduction(id);
                if (settingsFile.Sap == "1")
                {
                    SAPCreateRequest(CartonCapacityQString, CartonLabelAPN, CartonLabelSerialNumber, SAPQueueFilePath);
                    StatusPassPack(CartonLabelSerialNumber);
                    pictureHasBeenSetUp = false;
                }
            }
            MsgBoxShow($"Ilość elementów spakowanych do etykiety: {AmountOfProductsInCarton}. Etykieta jest pełna. Karton zamknięto.\n\nКількість елементів, упакованих для етикетки: {AmountOfProductsInCarton}. Етикетка заповнена. Картонна коробка була закрита.", Color.LightGreen);
            StatusWarning("Etykieta jest pełna. Zostanie zmknięta.\n\nЕтикетка заповнена.Він буде закритий.");
        }

        void UpdateCartonVisualization(int IloscWKartonie)
        {
            for (int i = 0; i < IloscWKartonie; i++)
            {
                panelCartonContentVisualization[i].BackColor = Color.LightGreen;
                panelCartonContentVisualization[i].Text = productsInCarton[i];
            }

        }

        void OK3S(string PN,string SN)
        {
            OneSecondClockOn = false;
            ResponseMsg($"Etykieta kartonu wczytana poprawnie.", Color.LightGreen);
            PingGreen();
            OneSecondClockOn = true;
            FromattedValueInCartonPackCounter = Convert.ToString(productsInCarton == null ? 0 : productsInCarton.Count);
            int[] wynik = MyExtensions.HowManyRowsAndColumns(CartonCapacityQInteger);
            CartonContentVisualization(wynik[0], wynik[1]);
            UpdateCartonVisualization(AmountOfProductsInCarton);
        }

        string ExtractDataFromProductScanner(Char ZnakDoWyciagniecia, string FormatDoWyciecia, string KodDoSkrocenia)
        {
            char[] CodeTypePNSplit = FormatDoWyciecia.ToCharArray();
            char[] PNSplit = KodDoSkrocenia.ToCharArray();
            string PNTemp = "";

            for (int i = 0; i < APNFormat.Length; i++)
            {
                if (CodeTypePNSplit[i].Equals(char.ToUpper(ZnakDoWyciagniecia)) || CodeTypePNSplit[i].Equals(char.ToLower(ZnakDoWyciagniecia)))
                {
                    PNTemp = PNTemp + Char.ToString(PNSplit[i]);
                }
            }
           
            return PNTemp;
        }

        bool FISCheckBREQResponseIfOK(string id)
        {
            string response = BREQUK2(id);

            if (response.Contains("spakowany"))
            {
                ErrorTryScanningAnotherBoard($"Błąd FIS produktu {id}. Detal juz spakowany do innego kartonu. Деталі вже упаковані в іншу коробку.", Color.LightCoral, $"Błąd FIS produktu {id}. Detal juz spakowany do innego kartonu. Деталі вже упаковані в іншу коробку.", Color.Yellow);
                return true;
            }

            if (response.Contains("UNKNOWN error") || response.Contains("archiwum") || response == "null" || string.IsNullOrEmpty(response))
            {
                ErrorTryScanningAnotherBoard($"Błąd FIS produktu {id}. Nie znaleziono produktu w bazie FIS, jest zarchiwizowany lub nie istnieje. Продукт відсутній у базі даних FIS, заархівований або не існує.", Color.Yellow);
                return true;
            }

            string[] fullResponse = response.Split('|', '=');
            string partnumberFis = fullResponse[fullResponse.Length - 2];

            if (partnumberFis != CartonLabelAPN.Substring(0, 8))
            {
                ErrorTryScanningAnotherBoard("Karton i UK2 produktu z FIS są różne", Color.Yellow, $"Karton i UK2 produktu są różne. PN kartonu: {CartonLabelAPN.Substring(0, 8)}. PN UK2 zeskanowanego produktu: {partnumberFis}", Color.Yellow);
                return true;
            }
            if (!response.Contains("PASS"))
            {
                ErrorTryScanningAnotherBoard($"Błąd FIS produktu {id}. Nieprawidłowy krok procesu. Błąd ruty FIS. Недійсний крок процесу. Помилка маршруту FIS.", Color.Yellow);
                return true;
            }
            return false;
        }

        string ExtractUK1(string id)
        {
            string response = BREQUK1(id);

            if (response.Contains("UNKNOWN error") || response.Contains("archiwum") || response == "null" || string.IsNullOrEmpty(response))
            {
                ErrorTryScanningAnotherBoard($"Błąd FIS produktu {id}. Nie znaleziono produktu w bazie FIS, jest zarchiwizowany lub nie istnieje. Продукт відсутній у базі даних FIS, заархівований або не існує.", Color.Yellow);
                return "Error";
            }

            string[] fullResponse = response.Split('|', '=');

            return fullResponse[fullResponse.Length - 2];
        }
    }
}