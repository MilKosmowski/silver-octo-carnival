namespace Central_pack
{
    partial class Declarations
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelCounterStaticLabel = new System.Windows.Forms.Label();
            this.labelCartonPackCounter = new System.Windows.Forms.Label();
            this.labelResponseForUser = new System.Windows.Forms.Label();
            this.labelCommandForUser = new System.Windows.Forms.Label();
            this.timer1000ms = new System.Windows.Forms.Timer(this.components);
            this.labelStatusSap = new System.Windows.Forms.Label();
            this.serialPortScannerCarton = new System.IO.Ports.SerialPort(this.components);
            this.serialPortScannerProduct = new System.IO.Ports.SerialPort(this.components);
            this.panelLastInput = new System.Windows.Forms.Panel();
            this.textBoxLastInput = new System.Windows.Forms.TextBox();
            this.labelLastInputStaticString = new System.Windows.Forms.Label();
            this.panelStationNumber = new System.Windows.Forms.Panel();
            this.buttonOptionsMenu = new System.Windows.Forms.Button();
            this.labelStationNumber = new System.Windows.Forms.Label();
            this.panelPackedByCapacity = new System.Windows.Forms.Panel();
            this.panelMiscBoolNotifiers = new System.Windows.Forms.Panel();
            this.labelInterruptedProductionBool = new System.Windows.Forms.Label();
            this.timer5min = new System.Windows.Forms.Timer(this.components);
            this.toolTipCartonLabelScanner = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipProductLabelScanner = new System.Windows.Forms.ToolTip(this.components);
            this.timer600ms = new System.Windows.Forms.Timer(this.components);
            this.textBoxKeyboardWedgeScannerData = new System.Windows.Forms.TextBox();
            this.panelManualInput = new System.Windows.Forms.Panel();
            this.buttonProdukcjaPrzerywana = new System.Windows.Forms.Button();
            this.buttonZamknij = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelStaticLabels = new System.Windows.Forms.Panel();
            this.labelResponseForUserStaticLabel = new System.Windows.Forms.Label();
            this.labelCommandForUserStaticLabel = new System.Windows.Forms.Label();
            this.BoxPackingPicture = new System.Windows.Forms.PictureBox();
            this.BoxCartonFillVisualization = new System.Windows.Forms.PictureBox();
            this.panelCartonLabelAPN = new System.Windows.Forms.Panel();
            this.labelCartonLabelAPNStaticLabel = new System.Windows.Forms.Label();
            this.labelCartonLabelAPN = new System.Windows.Forms.Label();
            this.toolTipInterruptedProduction = new System.Windows.Forms.ToolTip(this.components);
            this.timerChangeCommandForUserColor = new System.Windows.Forms.Timer(this.components);
            this.panelAmountOfPackedInShift = new System.Windows.Forms.Panel();
            this.labelShift = new System.Windows.Forms.Label();
            this.labelAMountPackedThisShift = new System.Windows.Forms.Label();
            this.timerResetCounter = new System.Windows.Forms.Timer(this.components);
            this.panelCartonNumber = new System.Windows.Forms.Panel();
            this.labelCartonNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelLastInput.SuspendLayout();
            this.panelStationNumber.SuspendLayout();
            this.panelPackedByCapacity.SuspendLayout();
            this.panelMiscBoolNotifiers.SuspendLayout();
            this.panelManualInput.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelStaticLabels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxPackingPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxCartonFillVisualization)).BeginInit();
            this.panelCartonLabelAPN.SuspendLayout();
            this.panelAmountOfPackedInShift.SuspendLayout();
            this.panelCartonNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCounterStaticLabel
            // 
            this.labelCounterStaticLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCounterStaticLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCounterStaticLabel.Location = new System.Drawing.Point(13, 10);
            this.labelCounterStaticLabel.Name = "labelCounterStaticLabel";
            this.labelCounterStaticLabel.Size = new System.Drawing.Size(175, 38);
            this.labelCounterStaticLabel.TabIndex = 9;
            this.labelCounterStaticLabel.Text = "W kartonie:";
            this.labelCounterStaticLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCartonPackCounter
            // 
            this.labelCartonPackCounter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCartonPackCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCartonPackCounter.Location = new System.Drawing.Point(194, 0);
            this.labelCartonPackCounter.Name = "labelCartonPackCounter";
            this.labelCartonPackCounter.Size = new System.Drawing.Size(126, 58);
            this.labelCartonPackCounter.TabIndex = 10;
            this.labelCartonPackCounter.Text = "0/0";
            this.labelCartonPackCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResponseForUser
            // 
            this.labelResponseForUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelResponseForUser.BackColor = System.Drawing.Color.Gainsboro;
            this.labelResponseForUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelResponseForUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelResponseForUser.Location = new System.Drawing.Point(323, 723);
            this.labelResponseForUser.MaximumSize = new System.Drawing.Size(316, 300);
            this.labelResponseForUser.Name = "labelResponseForUser";
            this.labelResponseForUser.Size = new System.Drawing.Size(314, 206);
            this.labelResponseForUser.TabIndex = 13;
            this.labelResponseForUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCommandForUser
            // 
            this.labelCommandForUser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCommandForUser.BackColor = System.Drawing.Color.Aqua;
            this.labelCommandForUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCommandForUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCommandForUser.Location = new System.Drawing.Point(5, 724);
            this.labelCommandForUser.MaximumSize = new System.Drawing.Size(316, 300);
            this.labelCommandForUser.Name = "labelCommandForUser";
            this.labelCommandForUser.Size = new System.Drawing.Size(316, 206);
            this.labelCommandForUser.TabIndex = 20;
            this.labelCommandForUser.Text = "Skanowanie etykiety kartonu. Сканування етикетки з картону.";
            this.labelCommandForUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1000ms
            // 
            this.timer1000ms.Interval = 1000;
            this.timer1000ms.Tick += new System.EventHandler(this.Timer1s_Tick);
            // 
            // labelStatusSap
            // 
            this.labelStatusSap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStatusSap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStatusSap.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStatusSap.Location = new System.Drawing.Point(81, 9);
            this.labelStatusSap.MaximumSize = new System.Drawing.Size(400, 150);
            this.labelStatusSap.Name = "labelStatusSap";
            this.labelStatusSap.Size = new System.Drawing.Size(60, 40);
            this.labelStatusSap.TabIndex = 25;
            this.labelStatusSap.Text = "SAP";
            this.labelStatusSap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialPortScannerCarton
            // 
            this.serialPortScannerCarton.DtrEnable = true;
            this.serialPortScannerCarton.RtsEnable = true;
            // 
            // serialPortScannerProduct
            // 
            this.serialPortScannerProduct.DtrEnable = true;
            this.serialPortScannerProduct.ReadTimeout = 10000;
            this.serialPortScannerProduct.RtsEnable = true;
            this.serialPortScannerProduct.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPortProductScanner_DataReceived);
            // 
            // panelLastInput
            // 
            this.panelLastInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelLastInput.BackColor = System.Drawing.Color.Gainsboro;
            this.panelLastInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLastInput.Controls.Add(this.textBoxLastInput);
            this.panelLastInput.Controls.Add(this.labelLastInputStaticString);
            this.panelLastInput.Location = new System.Drawing.Point(185, 932);
            this.panelLastInput.Name = "panelLastInput";
            this.panelLastInput.Size = new System.Drawing.Size(452, 80);
            this.panelLastInput.TabIndex = 63;
            // 
            // textBoxLastInput
            // 
            this.textBoxLastInput.BackColor = System.Drawing.Color.Yellow;
            this.textBoxLastInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxLastInput.Location = new System.Drawing.Point(14, 42);
            this.textBoxLastInput.Name = "textBoxLastInput";
            this.textBoxLastInput.Size = new System.Drawing.Size(422, 29);
            this.textBoxLastInput.TabIndex = 80;
            // 
            // labelLastInputStaticString
            // 
            this.labelLastInputStaticString.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLastInputStaticString.AutoSize = true;
            this.labelLastInputStaticString.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelLastInputStaticString.Location = new System.Drawing.Point(139, 8);
            this.labelLastInputStaticString.Name = "labelLastInputStaticString";
            this.labelLastInputStaticString.Size = new System.Drawing.Size(175, 31);
            this.labelLastInputStaticString.TabIndex = 72;
            this.labelLastInputStaticString.Text = "Ostatni wpis";
            // 
            // panelStationNumber
            // 
            this.panelStationNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelStationNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.panelStationNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelStationNumber.Controls.Add(this.buttonOptionsMenu);
            this.panelStationNumber.Controls.Add(this.labelStationNumber);
            this.panelStationNumber.Location = new System.Drawing.Point(5, 12);
            this.panelStationNumber.Name = "panelStationNumber";
            this.panelStationNumber.Size = new System.Drawing.Size(87, 60);
            this.panelStationNumber.TabIndex = 67;
            // 
            // buttonOptionsMenu
            // 
            this.buttonOptionsMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOptionsMenu.BackColor = System.Drawing.Color.LightGray;
            this.buttonOptionsMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonOptionsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOptionsMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.buttonOptionsMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonOptionsMenu.Location = new System.Drawing.Point(68, 0);
            this.buttonOptionsMenu.Margin = new System.Windows.Forms.Padding(0);
            this.buttonOptionsMenu.Name = "buttonOptionsMenu";
            this.buttonOptionsMenu.Size = new System.Drawing.Size(15, 57);
            this.buttonOptionsMenu.TabIndex = 75;
            this.buttonOptionsMenu.UseVisualStyleBackColor = false;
            this.buttonOptionsMenu.Click += new System.EventHandler(this.ButtonOptions_Click);
            // 
            // labelStationNumber
            // 
            this.labelStationNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStationNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelStationNumber.Location = new System.Drawing.Point(0, 0);
            this.labelStationNumber.Name = "labelStationNumber";
            this.labelStationNumber.Size = new System.Drawing.Size(85, 59);
            this.labelStationNumber.TabIndex = 10;
            this.labelStationNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPackedByCapacity
            // 
            this.panelPackedByCapacity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPackedByCapacity.BackColor = System.Drawing.Color.Gainsboro;
            this.panelPackedByCapacity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPackedByCapacity.Controls.Add(this.labelCounterStaticLabel);
            this.panelPackedByCapacity.Controls.Add(this.labelCartonPackCounter);
            this.panelPackedByCapacity.Location = new System.Drawing.Point(98, 12);
            this.panelPackedByCapacity.Name = "panelPackedByCapacity";
            this.panelPackedByCapacity.Size = new System.Drawing.Size(322, 60);
            this.panelPackedByCapacity.TabIndex = 68;
            // 
            // panelMiscBoolNotifiers
            // 
            this.panelMiscBoolNotifiers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelMiscBoolNotifiers.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMiscBoolNotifiers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMiscBoolNotifiers.Controls.Add(this.labelInterruptedProductionBool);
            this.panelMiscBoolNotifiers.Controls.Add(this.labelStatusSap);
            this.panelMiscBoolNotifiers.Location = new System.Drawing.Point(1122, 12);
            this.panelMiscBoolNotifiers.Name = "panelMiscBoolNotifiers";
            this.panelMiscBoolNotifiers.Size = new System.Drawing.Size(154, 60);
            this.panelMiscBoolNotifiers.TabIndex = 69;
            // 
            // labelInterruptedProductionBool
            // 
            this.labelInterruptedProductionBool.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelInterruptedProductionBool.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelInterruptedProductionBool.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelInterruptedProductionBool.Location = new System.Drawing.Point(10, 9);
            this.labelInterruptedProductionBool.Name = "labelInterruptedProductionBool";
            this.labelInterruptedProductionBool.Size = new System.Drawing.Size(60, 40);
            this.labelInterruptedProductionBool.TabIndex = 71;
            this.labelInterruptedProductionBool.Text = "PP";
            this.labelInterruptedProductionBool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer5min
            // 
            this.timer5min.Enabled = true;
            this.timer5min.Interval = 300000;
            this.timer5min.Tick += new System.EventHandler(this.Timer5min_Tick);
            // 
            // toolTipCartonLabelScanner
            // 
            this.toolTipCartonLabelScanner.AutomaticDelay = 0;
            this.toolTipCartonLabelScanner.AutoPopDelay = 5000;
            this.toolTipCartonLabelScanner.BackColor = System.Drawing.Color.LightCoral;
            this.toolTipCartonLabelScanner.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolTipCartonLabelScanner.InitialDelay = 0;
            this.toolTipCartonLabelScanner.ReshowDelay = 0;
            // 
            // toolTipProductLabelScanner
            // 
            this.toolTipProductLabelScanner.AutomaticDelay = 0;
            this.toolTipProductLabelScanner.AutoPopDelay = 5000;
            this.toolTipProductLabelScanner.BackColor = System.Drawing.Color.LightCoral;
            this.toolTipProductLabelScanner.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolTipProductLabelScanner.InitialDelay = 0;
            this.toolTipProductLabelScanner.ReshowDelay = 0;
            // 
            // timer600ms
            // 
            this.timer600ms.Interval = 600;
            this.timer600ms.Tick += new System.EventHandler(this.CartonLabelScannerSendScanRequestAndGetDataFromScannerEvery600ms);
            // 
            // textBoxKeyboardWedgeScannerData
            // 
            this.textBoxKeyboardWedgeScannerData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxKeyboardWedgeScannerData.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBoxKeyboardWedgeScannerData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.textBoxKeyboardWedgeScannerData.Location = new System.Drawing.Point(11, 24);
            this.textBoxKeyboardWedgeScannerData.Name = "textBoxKeyboardWedgeScannerData";
            this.textBoxKeyboardWedgeScannerData.Size = new System.Drawing.Size(148, 29);
            this.textBoxKeyboardWedgeScannerData.TabIndex = 70;
            this.textBoxKeyboardWedgeScannerData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxManualInput_KeyDown);
            // 
            // panelManualInput
            // 
            this.panelManualInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelManualInput.BackColor = System.Drawing.Color.Gainsboro;
            this.panelManualInput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelManualInput.Controls.Add(this.textBoxKeyboardWedgeScannerData);
            this.panelManualInput.Location = new System.Drawing.Point(5, 932);
            this.panelManualInput.Name = "panelManualInput";
            this.panelManualInput.Size = new System.Drawing.Size(174, 80);
            this.panelManualInput.TabIndex = 72;
            // 
            // buttonProdukcjaPrzerywana
            // 
            this.buttonProdukcjaPrzerywana.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonProdukcjaPrzerywana.BackColor = System.Drawing.Color.LightGray;
            this.buttonProdukcjaPrzerywana.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProdukcjaPrzerywana.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonProdukcjaPrzerywana.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonProdukcjaPrzerywana.Location = new System.Drawing.Point(11, 14);
            this.buttonProdukcjaPrzerywana.Name = "buttonProdukcjaPrzerywana";
            this.buttonProdukcjaPrzerywana.Size = new System.Drawing.Size(346, 120);
            this.buttonProdukcjaPrzerywana.TabIndex = 75;
            this.buttonProdukcjaPrzerywana.Text = "Produkcja przerywana / Reset \r\n\r\nПерервне виробництво / скидання";
            this.buttonProdukcjaPrzerywana.UseVisualStyleBackColor = false;
            this.buttonProdukcjaPrzerywana.Click += new System.EventHandler(this.ButtonInterruptedProduction_Click);
            // 
            // buttonZamknij
            // 
            this.buttonZamknij.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonZamknij.BackColor = System.Drawing.Color.LightGray;
            this.buttonZamknij.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonZamknij.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonZamknij.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZamknij.Location = new System.Drawing.Point(415, 14);
            this.buttonZamknij.Name = "buttonZamknij";
            this.buttonZamknij.Size = new System.Drawing.Size(205, 120);
            this.buttonZamknij.TabIndex = 73;
            this.buttonZamknij.Text = "Zamknij program\r\n\r\nЗакрийте програму\r\n";
            this.buttonZamknij.UseVisualStyleBackColor = false;
            this.buttonZamknij.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelButtons.BackColor = System.Drawing.Color.Gainsboro;
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelButtons.Controls.Add(this.buttonProdukcjaPrzerywana);
            this.panelButtons.Controls.Add(this.buttonZamknij);
            this.panelButtons.Location = new System.Drawing.Point(643, 863);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(633, 149);
            this.panelButtons.TabIndex = 76;
            // 
            // panelStaticLabels
            // 
            this.panelStaticLabels.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelStaticLabels.BackColor = System.Drawing.Color.Silver;
            this.panelStaticLabels.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelStaticLabels.Controls.Add(this.labelResponseForUserStaticLabel);
            this.panelStaticLabels.Controls.Add(this.labelCommandForUserStaticLabel);
            this.panelStaticLabels.Location = new System.Drawing.Point(5, 683);
            this.panelStaticLabels.Name = "panelStaticLabels";
            this.panelStaticLabels.Size = new System.Drawing.Size(632, 38);
            this.panelStaticLabels.TabIndex = 78;
            // 
            // labelResponseForUserStaticLabel
            // 
            this.labelResponseForUserStaticLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelResponseForUserStaticLabel.AutoSize = true;
            this.labelResponseForUserStaticLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelResponseForUserStaticLabel.Location = new System.Drawing.Point(386, 3);
            this.labelResponseForUserStaticLabel.Name = "labelResponseForUserStaticLabel";
            this.labelResponseForUserStaticLabel.Size = new System.Drawing.Size(159, 31);
            this.labelResponseForUserStaticLabel.TabIndex = 34;
            this.labelResponseForUserStaticLabel.Text = "Odpowiedź";
            // 
            // labelCommandForUserStaticLabel
            // 
            this.labelCommandForUserStaticLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCommandForUserStaticLabel.AutoSize = true;
            this.labelCommandForUserStaticLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelCommandForUserStaticLabel.Location = new System.Drawing.Point(121, 3);
            this.labelCommandForUserStaticLabel.Name = "labelCommandForUserStaticLabel";
            this.labelCommandForUserStaticLabel.Size = new System.Drawing.Size(74, 31);
            this.labelCommandForUserStaticLabel.TabIndex = 33;
            this.labelCommandForUserStaticLabel.Text = "Etap";
            // 
            // BoxPackingPicture
            // 
            this.BoxPackingPicture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BoxPackingPicture.BackColor = System.Drawing.Color.Gainsboro;
            this.BoxPackingPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BoxPackingPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BoxPackingPicture.ErrorImage = null;
            this.BoxPackingPicture.InitialImage = null;
            this.BoxPackingPicture.Location = new System.Drawing.Point(5, 78);
            this.BoxPackingPicture.Name = "BoxPackingPicture";
            this.BoxPackingPicture.Size = new System.Drawing.Size(632, 599);
            this.BoxPackingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BoxPackingPicture.TabIndex = 24;
            this.BoxPackingPicture.TabStop = false;
            // 
            // BoxCartonFillVisualization
            // 
            this.BoxCartonFillVisualization.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BoxCartonFillVisualization.BackColor = System.Drawing.Color.Gainsboro;
            this.BoxCartonFillVisualization.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BoxCartonFillVisualization.Location = new System.Drawing.Point(643, 78);
            this.BoxCartonFillVisualization.Name = "BoxCartonFillVisualization";
            this.BoxCartonFillVisualization.Size = new System.Drawing.Size(633, 719);
            this.BoxCartonFillVisualization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BoxCartonFillVisualization.TabIndex = 46;
            this.BoxCartonFillVisualization.TabStop = false;
            // 
            // panelCartonLabelAPN
            // 
            this.panelCartonLabelAPN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCartonLabelAPN.BackColor = System.Drawing.Color.Gainsboro;
            this.panelCartonLabelAPN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCartonLabelAPN.Controls.Add(this.labelCartonLabelAPNStaticLabel);
            this.panelCartonLabelAPN.Controls.Add(this.labelCartonLabelAPN);
            this.panelCartonLabelAPN.Location = new System.Drawing.Point(426, 12);
            this.panelCartonLabelAPN.Name = "panelCartonLabelAPN";
            this.panelCartonLabelAPN.Size = new System.Drawing.Size(211, 60);
            this.panelCartonLabelAPN.TabIndex = 79;
            // 
            // labelCartonLabelAPNStaticLabel
            // 
            this.labelCartonLabelAPNStaticLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCartonLabelAPNStaticLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCartonLabelAPNStaticLabel.Location = new System.Drawing.Point(1, -1);
            this.labelCartonLabelAPNStaticLabel.Name = "labelCartonLabelAPNStaticLabel";
            this.labelCartonLabelAPNStaticLabel.Size = new System.Drawing.Size(208, 58);
            this.labelCartonLabelAPNStaticLabel.TabIndex = 9;
            this.labelCartonLabelAPNStaticLabel.Text = "APN:";
            this.labelCartonLabelAPNStaticLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCartonLabelAPN
            // 
            this.labelCartonLabelAPN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCartonLabelAPN.AutoSize = true;
            this.labelCartonLabelAPN.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.labelCartonLabelAPN.Location = new System.Drawing.Point(22, 7);
            this.labelCartonLabelAPN.Name = "labelCartonLabelAPN";
            this.labelCartonLabelAPN.Size = new System.Drawing.Size(0, 42);
            this.labelCartonLabelAPN.TabIndex = 10;
            // 
            // toolTipInterruptedProduction
            // 
            this.toolTipInterruptedProduction.AutomaticDelay = 0;
            this.toolTipInterruptedProduction.AutoPopDelay = 5000;
            this.toolTipInterruptedProduction.BackColor = System.Drawing.Color.LightCoral;
            this.toolTipInterruptedProduction.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolTipInterruptedProduction.InitialDelay = 0;
            this.toolTipInterruptedProduction.ReshowDelay = 0;
            // 
            // timerChangeCommandForUserColor
            // 
            this.timerChangeCommandForUserColor.Interval = 1500;
            this.timerChangeCommandForUserColor.Tick += new System.EventHandler(this.timerChangeCommandForUserColor_Tick);
            // 
            // panelAmountOfPackedInShift
            // 
            this.panelAmountOfPackedInShift.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAmountOfPackedInShift.BackColor = System.Drawing.Color.Gainsboro;
            this.panelAmountOfPackedInShift.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelAmountOfPackedInShift.Controls.Add(this.labelShift);
            this.panelAmountOfPackedInShift.Controls.Add(this.labelAMountPackedThisShift);
            this.panelAmountOfPackedInShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.panelAmountOfPackedInShift.Location = new System.Drawing.Point(643, 12);
            this.panelAmountOfPackedInShift.Name = "panelAmountOfPackedInShift";
            this.panelAmountOfPackedInShift.Size = new System.Drawing.Size(473, 60);
            this.panelAmountOfPackedInShift.TabIndex = 80;
            // 
            // labelShift
            // 
            this.labelShift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelShift.Location = new System.Drawing.Point(3, 0);
            this.labelShift.Name = "labelShift";
            this.labelShift.Size = new System.Drawing.Size(160, 56);
            this.labelShift.TabIndex = 11;
            this.labelShift.Text = "Zmiana: 1";
            this.labelShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAMountPackedThisShift
            // 
            this.labelAMountPackedThisShift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAMountPackedThisShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAMountPackedThisShift.Location = new System.Drawing.Point(169, 0);
            this.labelAMountPackedThisShift.Name = "labelAMountPackedThisShift";
            this.labelAMountPackedThisShift.Size = new System.Drawing.Size(302, 59);
            this.labelAMountPackedThisShift.TabIndex = 10;
            this.labelAMountPackedThisShift.Text = "Spakowano: 0";
            this.labelAMountPackedThisShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerResetCounter
            // 
            this.timerResetCounter.Enabled = true;
            this.timerResetCounter.Interval = 1000;
            this.timerResetCounter.Tick += new System.EventHandler(this.TimerResetCounter_Tick);
            // 
            // panelCartonNumber
            // 
            this.panelCartonNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelCartonNumber.BackColor = System.Drawing.Color.Gainsboro;
            this.panelCartonNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCartonNumber.Controls.Add(this.labelCartonNumber);
            this.panelCartonNumber.Controls.Add(this.label2);
            this.panelCartonNumber.Location = new System.Drawing.Point(643, 803);
            this.panelCartonNumber.Name = "panelCartonNumber";
            this.panelCartonNumber.Size = new System.Drawing.Size(633, 54);
            this.panelCartonNumber.TabIndex = 82;
            // 
            // labelCartonNumber
            // 
            this.labelCartonNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCartonNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelCartonNumber.Location = new System.Drawing.Point(3, 0);
            this.labelCartonNumber.Name = "labelCartonNumber";
            this.labelCartonNumber.Size = new System.Drawing.Size(628, 50);
            this.labelCartonNumber.TabIndex = 9;
            this.labelCartonNumber.Text = "-";
            this.labelCartonNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(233, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 42);
            this.label2.TabIndex = 10;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Declarations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.panelCartonNumber);
            this.Controls.Add(this.panelAmountOfPackedInShift);
            this.Controls.Add(this.panelCartonLabelAPN);
            this.Controls.Add(this.panelStaticLabels);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelManualInput);
            this.Controls.Add(this.BoxPackingPicture);
            this.Controls.Add(this.BoxCartonFillVisualization);
            this.Controls.Add(this.panelMiscBoolNotifiers);
            this.Controls.Add(this.panelPackedByCapacity);
            this.Controls.Add(this.panelStationNumber);
            this.Controls.Add(this.panelLastInput);
            this.Controls.Add(this.labelCommandForUser);
            this.Controls.Add(this.labelResponseForUser);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Declarations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.WindowDeactivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCentralPack_FormClosing);
            this.panelLastInput.ResumeLayout(false);
            this.panelLastInput.PerformLayout();
            this.panelStationNumber.ResumeLayout(false);
            this.panelPackedByCapacity.ResumeLayout(false);
            this.panelMiscBoolNotifiers.ResumeLayout(false);
            this.panelManualInput.ResumeLayout(false);
            this.panelManualInput.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelStaticLabels.ResumeLayout(false);
            this.panelStaticLabels.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxPackingPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxCartonFillVisualization)).EndInit();
            this.panelCartonLabelAPN.ResumeLayout(false);
            this.panelCartonLabelAPN.PerformLayout();
            this.panelAmountOfPackedInShift.ResumeLayout(false);
            this.panelCartonNumber.ResumeLayout(false);
            this.panelCartonNumber.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelCounterStaticLabel;
        private System.Windows.Forms.Label labelCartonPackCounter;
        private System.Windows.Forms.Label labelResponseForUser;
        private System.Windows.Forms.Label labelCommandForUser;
        private System.Windows.Forms.Timer timer1000ms;
        private System.Windows.Forms.PictureBox BoxPackingPicture;
        private System.Windows.Forms.Label labelStatusSap;
        private System.IO.Ports.SerialPort serialPortScannerCarton;
        private System.Windows.Forms.PictureBox BoxCartonFillVisualization;
        private System.IO.Ports.SerialPort serialPortScannerProduct;
        private System.Windows.Forms.Panel panelLastInput;
        private System.Windows.Forms.Panel panelStationNumber;
        private System.Windows.Forms.Panel panelPackedByCapacity;
        private System.Windows.Forms.Panel panelMiscBoolNotifiers;
        private System.Windows.Forms.Timer timer5min;
        private System.Windows.Forms.ToolTip toolTipCartonLabelScanner;
        private System.Windows.Forms.ToolTip toolTipProductLabelScanner;
        private System.Windows.Forms.Timer timer600ms;
        private System.Windows.Forms.TextBox textBoxKeyboardWedgeScannerData;
        private System.Windows.Forms.Panel panelManualInput;
        private System.Windows.Forms.Button buttonProdukcjaPrzerywana;
        private System.Windows.Forms.Button buttonZamknij;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Label labelStationNumber;
        private System.Windows.Forms.Label labelLastInputStaticString;
        private System.Windows.Forms.TextBox textBoxLastInput;
        private System.Windows.Forms.Label labelInterruptedProductionBool;
        private System.Windows.Forms.Panel panelStaticLabels;
        private System.Windows.Forms.Label labelResponseForUserStaticLabel;
        private System.Windows.Forms.Label labelCommandForUserStaticLabel;
        private System.Windows.Forms.Button buttonOptionsMenu;
        private System.Windows.Forms.Panel panelCartonLabelAPN;
        private System.Windows.Forms.Label labelCartonLabelAPNStaticLabel;
        private System.Windows.Forms.Label labelCartonLabelAPN;
        private System.Windows.Forms.ToolTip toolTipInterruptedProduction;
        private System.Windows.Forms.Timer timerChangeCommandForUserColor;
        private System.Windows.Forms.Panel panelAmountOfPackedInShift;
        private System.Windows.Forms.Timer timerResetCounter;
        private System.Windows.Forms.Label labelAMountPackedThisShift;
        private System.Windows.Forms.Panel panelCartonNumber;
        private System.Windows.Forms.Label labelCartonNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelShift;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

