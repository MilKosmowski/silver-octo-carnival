using System;
using System.Drawing;
using System.Windows.Forms;

namespace Central_pack
{
    public partial class PopupWindow : Form
    {
        private int timerAction = 0;

        public PopupWindow(string msg, Color color, bool CloseVisible)
        {
            InitializeComponent();
            labelMsgBox.Text = msg;
            labelMsgBox.BackColor = color;

            this.WindowState = FormWindowState.Normal;
            this.TopLevel = true;
            this.Focus();
            this.BringToFront();
            this.Activate();
            this.BackColor = color;
            buttonClose.Visible = CloseVisible;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KeyExit(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            switch (timerAction)
            {
                case 0:
                    labelTime.Text = "3.";
                    break;

                case 1:
                    labelTime.Text = "3..";
                    break;

                case 2:
                    labelTime.Text = "3...";
                    break;

                case 3:
                    labelTime.Text = "2.";
                    break;

                case 4:
                    labelTime.Text = "2..";
                    break;

                case 5:
                    labelTime.Text = "2...";
                    break;

                case 6:
                    labelTime.Text = "1.";
                    break;

                case 7:
                    labelTime.Text = "1..";
                    break;

                case 8:
                    labelTime.Text = "1...";
                    break;

                case 9:
                    this.Close();
                    break;
            }
            timerAction++;
        }
    }
}