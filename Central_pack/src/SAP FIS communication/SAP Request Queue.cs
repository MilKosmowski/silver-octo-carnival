using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Timers;
using System.Threading;
using System.Net.Sockets;
using System.Media;
using System.IO.Ports;


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
