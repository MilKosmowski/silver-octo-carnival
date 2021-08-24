using System;
using System.ComponentModel;
using System.Windows.Forms;

using CustomExtensions;

namespace Central_pack
{
    partial class Declarations : Form
    {
        private void ButtonOptions_Click(object sender, EventArgs e)
        {
            Form fo = Application.OpenForms["Menu Opcji"];
            if (fo == null)
            {
                var form = new OptionsMenu();
                form.Show(this);
            }
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            TurnOffCOMPorts();
            Close();
        }

        private void TurnOffCOMPorts()
        {
            if (serialPortScannerCarton.IsOpen)
                serialPortScannerCarton.Close();

            if (serialPortScannerProduct.IsOpen)
                serialPortScannerProduct.Close();
        }

        private void ButtonInterruptedProduction_Click(object sender, EventArgs e)
        {
            if (PackingProcessStep != "Skanowanie kodu 1P")
            {
                IfPropoerScanProcessAndCartonNotZeroThenSaveToInterruptedProduction();
                ResponseMsg("Produkcja przerywana / Reset", System.Drawing.Color.Yellow);
                ResetProgram();
            }
        }

        private void FormCentralPack_FormClosing(object sender, CancelEventArgs e)
        {
            MyExtensions.Log("Zamykanie programu", "Regular");
            var result = MessageBox.Show("Czy na pewno chcesz zamknąć program?", "Zamykanie", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
            else
            {
                IfPropoerScanProcessAndCartonNotZeroThenSaveToInterruptedProduction();
            }
        }

        private void IfPropoerScanProcessAndCartonNotZeroThenSaveToInterruptedProduction()
        {
            if (PackingProcessStep == "Skan Produktu" && AmountOfProductsInCarton > 0)
                InterruptedProduction.SaveOneRecordToInterruptedProductionFile(CartonLabelAPN, CartonLabelSerialNumber, PackingType, CartonCapacityQInteger, AmountOfProductsInCarton);
        }
    }
}