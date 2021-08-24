using System;
using System.Windows.Forms;

namespace Central_pack
{
    partial class Declarations : Form
    {
        private void Timer5min_Tick(object sender, EventArgs e)
        {
            if (settingsFile.Sap == "1")
            {
                SapRequestSendFromQueue(SAPQueueFilePath);
            }
        }
    }
}