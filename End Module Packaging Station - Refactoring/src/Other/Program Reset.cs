using System;
using System.Windows.Forms;
using CustomExtensions;
using System.Drawing;

namespace Central_pack_Refactoring
{
    partial class Declarations : Form
    {
        void ResetProgram()
        {
            MyExtensions.Log("Reset","Regular");
            if (!MyExtensions.IsNullOrEmpty(APNFileData)) Array.Clear(APNFileData,0, APNFileData.Length);
            if (productsInCarton != null) productsInCarton.Clear();
            timer600ms.Enabled = true;
            PackingPictureFilePath = Properties.Resources.aptiv_logo;
            PackingType = "-";
            CartonSerialNumberFormat = "-";
            APNInProductBarcode = "-";
            IfASNAndFormat = "";
            APNFormat = "-";
            LastInput = "-";
            CartonLabelAPN = "-";
            CartonLabelSerialNumber = "";
            CartonCapacityQString = "0";
            CartonCapacityQInteger = 0;
            FromattedValueInCartonPackCounter = "0";
            PackingProcessStep = "Skanowanie kodu 1P";
            CommandMsg("Skanowanie etykiety kartonu. Сканування етикетки з картону.", Color.Aqua);
            MyExtensions.Log("Zeskanuj kod 1P","Regular");
            BoxCartonFillVisualization.Visible = true;
            CzyszczenieGrafiki();
            BoxPackingPicture.Visible = true;
            StopFISConnection();
        }
        void CzyszczenieGrafiki()
        {
            foreach (Label onepanel in panelCartonContentVisualization)
            {
                onepanel.Dispose();
            }
        }
    }
}
