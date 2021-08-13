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
        public void CartonContentVisualization(int row, int column)
        {
            foreach (Label onepanel in panelCartonContentVisualization)
                onepanel.Dispose();

            panelCartonContentVisualization.Clear();
            BoxCartonFillVisualization.Visible = false;
            int offsetX = 0;
            int offsetY = 0;    
            int space = 0;
            Point startPoint = BoxCartonFillVisualization.Location;
            Point endPoint = new Point(BoxCartonFillVisualization.Location.X + BoxCartonFillVisualization.Size.Width, BoxCartonFillVisualization.Location.Y + BoxCartonFillVisualization.Size.Height);
            int endWidth = this.Width - 20;
            int width = ((endPoint.X - startPoint.X) / column) - space;
            int height = ((endPoint.Y - startPoint.Y) / row) - space;
            int startDrawX = 0;
            int startDrawY = 0;

            for (int j = 0; j < row; j++)
            {
                Label newPanel = new Label();
                for (int i = 0; i < column; i++)
                {
                    newPanel = new Label();
                    newPanel.Size = new Size(width, height);
                    newPanel.BackColor = Color.Gray;
                    newPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    newPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    newPanel.Margin = new Padding( 5, 5, 5, 5);
                    newPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    newPanel.Location = new Point(startPoint.X + offsetX + startDrawX, startPoint.Y + startDrawY + offsetY);
                    if (i == column - 1)
                        startDrawX = 0;
                    else
                        startDrawX += width;
                    panelCartonContentVisualization.Add(newPanel);
                }
                if (j == row - 1)
                    startDrawY = 0;
                else
                    startDrawY += height;
            }

            foreach (Label onepanel in panelCartonContentVisualization)
            {
                this.Controls.Add(onepanel);
                controlCartonContentVisualization.Add(onepanel);
            }
        }
    }
}