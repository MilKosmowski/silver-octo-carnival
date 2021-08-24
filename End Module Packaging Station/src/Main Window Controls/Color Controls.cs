using System;
using System.Drawing;
using System.Windows.Forms;

using CustomExtensions;

namespace Central_pack
{
    partial class Declarations : Form
    {
        private void WindowDeactivated(object sender, EventArgs e) //Focus na okno
        {
            Activate();
        }

        public void CommandMsg(string msg, Color color) //Co wpisać w label "Polecenie"
        {
            CommandForUser = msg;
            MyExtensions.Log("Command msg: " + msg, "Regular");
            Application.DoEvents();
        }

        public void ResponseMsg(string msg, Color color) //Co wpisać w label "Odpowieź"
        {
            ResponseForUser = msg;
            ReponseForUserColor = color;
            MyExtensions.Log("Response msg: " + msg, "Regular");
            if (color == Color.GreenYellow)
                timerChangeCommandForUserColor.Enabled = true;
        }

        public void StatusFail(string id)
        {
            ResponseForUser = "FAIL\n" + id;
            ReponseForUserColor = Color.LightCoral;
        }

        public void StatusPass(string id)
        {
            ResponseForUser = "PASS\n" + id;
            ReponseForUserColor = Color.LightGreen;
        }

        public void StatusWarning(string id)
        {
            ResponseForUser = "UWAGA\n" + id;
            ReponseForUserColor = Color.Orange;
        }

        public void StatusPassPack(string id)
        {
            ResponseForUser = "PASS\n" + id + "\nSpakowane";
            ReponseForUserColor = Color.LightGreen;
        }

        public void IdOk(string id)
        {
            ResponseForUser = id + " SCAN OK";
            ReponseForUserColor = Color.LightGreen;
        }

        public static void MsgBoxShow(string text, Color color)
        {
            MyExtensions.Log(text, "Regular");
            PopupWindow msgbox = new PopupWindow(text, color, true);
            msgbox.Show();
        }

        public void SapChangeState(int state, string text = "SAP")
        {
            switch (state)
            {
                case 0:
                    labelStatusSap.BackColor = Color.LightCoral;
                    break;

                case 1:
                    labelStatusSap.BackColor = Color.LightGreen;
                    break;

                case 2:
                    labelStatusSap.BackColor = Color.Blue;
                    break;

                default:
                    labelStatusSap.BackColor = Color.Gainsboro;
                    break;
            }
            if (text != "SAP")
                MsgBoxShow("BŁĄD SAP, SPRÓBUJ PONOWNIE", Color.LightCoral);
        }

        public void PingGreen()
        {
            BackgroundColor = Color.LightGreen;
        }

        private void Timer1s_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
            timer1000ms.Enabled = false;
        }

        private void timerChangeCommandForUserColor_Tick(object sender, EventArgs e)
        {
            labelCommandForUser.BackColor = Color.Gainsboro;
            timerChangeCommandForUserColor.Enabled = false;
        }
    }
}