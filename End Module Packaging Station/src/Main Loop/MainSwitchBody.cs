using System;
using System.Drawing;

namespace Central_pack
{
    partial class Declarations
    {
        public void PACK(string id)
        {
            switch (PackingProcessStep)
            {
                case "Skanowanie kodu 1P": //Skan 1P

                    if (Logic1P(id))
                    {
                        CommandMsg("Zeskanuj kod Q", Color.Aqua);
                        PackingProcessStep = "Skanowanie kodu Q";
                        ResponseMsg("", Color.Gainsboro);
                    }
                    else ResetProgram();
                    break;

                case "Skanowanie kodu Q":

                    if (LogicQ(id))
                    {
                        CommandMsg("Zeskanuj kod 3S", Color.Aqua);
                        PackingProcessStep = "Skanowanie kodu 3S";
                    }
                    else ResetProgram();
                    break;

                case "Skanowanie kodu 3S": //skan 3S
                    if (Logic3S(id))
                    {
                        if (String.IsNullOrEmpty(IfASNAndFormat))
                            CommandMsg("Zeskanuj produkt. Відскануйте виріб.", Color.Violet);
                        else
                            CommandMsg("Zeskanuj kod na bezelu. Відскануйте код на рамці.", Color.Violet);

                        PackingProcessStep = "Skan Produktu";
                    }
                    else ResetProgram();
                    break;

                case "Skan Produktu": //skan produkt

                    if (!String.IsNullOrEmpty(IfASNAndFormat) && !BezelScanned)
                    {
                        if (LogicBezelScan(id)) BezelScanned = true;
                        CommandMsg("Zeskanuj produkt. Відскануйте виріб.", Color.Violet);
                        break;
                    }

                    if (LogicProductScan(id))
                    {
                        PackingProcessStep = "Skan Produktu";
                    }
                    else ResetProgram();

                    break;

                default:
                    ResponseMsg("Nieznany krok", Color.Yellow);
                    break;
            }
        }
    }
}