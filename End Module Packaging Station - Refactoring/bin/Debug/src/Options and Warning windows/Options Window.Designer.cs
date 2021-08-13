namespace Central_pack_Refactoring
{
    public partial class OptionsMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBoxPingFIS = new System.Windows.Forms.ListBox();
            this.buttonPingFIS = new System.Windows.Forms.Button();
            this.listBoxPingSAP = new System.Windows.Forms.ListBox();
            this.buttonPingSAP = new System.Windows.Forms.Button();
            this.LokalizacjaPPOzdoba = new System.Windows.Forms.Label();
            this.textBoxInterruptedProductionFilePath = new System.Windows.Forms.TextBox();
            this.groupBoxRadioCzyPrzerywana = new System.Windows.Forms.GroupBox();
            this.radioInterruptedProductionTrue = new System.Windows.Forms.RadioButton();
            this.radioInterruptedProductionFalse = new System.Windows.Forms.RadioButton();
            this.labelCzyPrzerywanaOzdoba = new System.Windows.Forms.Label();
            this.listBoxAvailablePorts = new System.Windows.Forms.ListBox();
            this.labelDostepnePorty = new System.Windows.Forms.Label();
            this.buttonOpcjeZapisz = new System.Windows.Forms.Button();
            this.buttonOpcjeZapiszIWyjdz = new System.Windows.Forms.Button();
            this.groupBoxRadioSAPKomunikacja = new System.Windows.Forms.GroupBox();
            this.radioSAPCommunicationTrue = new System.Windows.Forms.RadioButton();
            this.radioSAPCommunicationFalse = new System.Windows.Forms.RadioButton();
            this.labelSAPKomunikacjaOzdoba = new System.Windows.Forms.Label();
            this.textBoxCOMProductLabelScanner = new System.Windows.Forms.TextBox();
            this.COMSkDetaluOzdoba = new System.Windows.Forms.Label();
            this.textBoxCOMCartonLabelScanner = new System.Windows.Forms.TextBox();
            this.labelCOMSkKartonuOzdoba = new System.Windows.Forms.Label();
            this.textBoxPortSAP = new System.Windows.Forms.TextBox();
            this.labelPortSAPOzdoba = new System.Windows.Forms.Label();
            this.textBoxIPSAP = new System.Windows.Forms.TextBox();
            this.labelIPSAPOzdoba = new System.Windows.Forms.Label();
            this.textBoxStationName = new System.Windows.Forms.TextBox();
            this.labelNazwaStacjiOzdoba = new System.Windows.Forms.Label();
            this.textBoxPortFIS = new System.Windows.Forms.TextBox();
            this.labelPortFISOzdoba = new System.Windows.Forms.Label();
            this.textBoxIPFIS = new System.Windows.Forms.TextBox();
            this.labelIPFISOzdoba = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioLegacyInterruptedProductionMethodTrue = new System.Windows.Forms.RadioButton();
            this.radioLegacyInterruptedProductionMethodFalse = new System.Windows.Forms.RadioButton();
            this.labelStaryTrybPrzerywanejOzdoba = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBoxRadioCzyPrzerywana.SuspendLayout();
            this.groupBoxRadioSAPKomunikacja.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.listBoxPingFIS);
            this.panel2.Controls.Add(this.buttonPingFIS);
            this.panel2.Controls.Add(this.listBoxPingSAP);
            this.panel2.Controls.Add(this.buttonPingSAP);
            this.panel2.Controls.Add(this.LokalizacjaPPOzdoba);
            this.panel2.Controls.Add(this.textBoxInterruptedProductionFilePath);
            this.panel2.Controls.Add(this.groupBoxRadioCzyPrzerywana);
            this.panel2.Controls.Add(this.listBoxAvailablePorts);
            this.panel2.Controls.Add(this.labelDostepnePorty);
            this.panel2.Controls.Add(this.buttonOpcjeZapisz);
            this.panel2.Controls.Add(this.buttonOpcjeZapiszIWyjdz);
            this.panel2.Controls.Add(this.groupBoxRadioSAPKomunikacja);
            this.panel2.Controls.Add(this.textBoxCOMProductLabelScanner);
            this.panel2.Controls.Add(this.COMSkDetaluOzdoba);
            this.panel2.Controls.Add(this.textBoxCOMCartonLabelScanner);
            this.panel2.Controls.Add(this.labelCOMSkKartonuOzdoba);
            this.panel2.Controls.Add(this.textBoxPortSAP);
            this.panel2.Controls.Add(this.labelPortSAPOzdoba);
            this.panel2.Controls.Add(this.textBoxIPSAP);
            this.panel2.Controls.Add(this.labelIPSAPOzdoba);
            this.panel2.Controls.Add(this.textBoxStationName);
            this.panel2.Controls.Add(this.labelNazwaStacjiOzdoba);
            this.panel2.Controls.Add(this.textBoxPortFIS);
            this.panel2.Controls.Add(this.labelPortFISOzdoba);
            this.panel2.Controls.Add(this.textBoxIPFIS);
            this.panel2.Controls.Add(this.labelIPFISOzdoba);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(710, 523);
            this.panel2.TabIndex = 68;
            // 
            // listBoxPingFIS
            // 
            this.listBoxPingFIS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxPingFIS.BackColor = System.Drawing.SystemColors.Menu;
            this.listBoxPingFIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxPingFIS.HorizontalScrollbar = true;
            this.listBoxPingFIS.ItemHeight = 16;
            this.listBoxPingFIS.Location = new System.Drawing.Point(162, 295);
            this.listBoxPingFIS.Name = "listBoxPingFIS";
            this.listBoxPingFIS.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxPingFIS.Size = new System.Drawing.Size(300, 52);
            this.listBoxPingFIS.TabIndex = 98;
            // 
            // buttonPingFIS
            // 
            this.buttonPingFIS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPingFIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonPingFIS.Location = new System.Drawing.Point(56, 295);
            this.buttonPingFIS.Name = "buttonPingFIS";
            this.buttonPingFIS.Size = new System.Drawing.Size(100, 44);
            this.buttonPingFIS.TabIndex = 97;
            this.buttonPingFIS.Text = "Ping FIS";
            this.buttonPingFIS.UseVisualStyleBackColor = true;
            this.buttonPingFIS.Click += new System.EventHandler(this.buttonPingFIS_Click);
            // 
            // listBoxPingSAP
            // 
            this.listBoxPingSAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxPingSAP.BackColor = System.Drawing.SystemColors.Menu;
            this.listBoxPingSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxPingSAP.HorizontalScrollbar = true;
            this.listBoxPingSAP.ItemHeight = 16;
            this.listBoxPingSAP.Location = new System.Drawing.Point(163, 353);
            this.listBoxPingSAP.Name = "listBoxPingSAP";
            this.listBoxPingSAP.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxPingSAP.Size = new System.Drawing.Size(300, 68);
            this.listBoxPingSAP.TabIndex = 96;
            // 
            // buttonPingSAP
            // 
            this.buttonPingSAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPingSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonPingSAP.Location = new System.Drawing.Point(57, 353);
            this.buttonPingSAP.Name = "buttonPingSAP";
            this.buttonPingSAP.Size = new System.Drawing.Size(100, 44);
            this.buttonPingSAP.TabIndex = 95;
            this.buttonPingSAP.Text = "Ping SAP";
            this.buttonPingSAP.UseVisualStyleBackColor = true;
            this.buttonPingSAP.Click += new System.EventHandler(this.buttonPingSAP_Click);
            // 
            // LokalizacjaPPOzdoba
            // 
            this.LokalizacjaPPOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LokalizacjaPPOzdoba.AutoSize = true;
            this.LokalizacjaPPOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.LokalizacjaPPOzdoba.Location = new System.Drawing.Point(52, 223);
            this.LokalizacjaPPOzdoba.Name = "LokalizacjaPPOzdoba";
            this.LokalizacjaPPOzdoba.Size = new System.Drawing.Size(163, 24);
            this.LokalizacjaPPOzdoba.TabIndex = 94;
            this.LokalizacjaPPOzdoba.Text = "LOKALIZACJA PP";
            // 
            // textBoxInterruptedProductionFilePath
            // 
            this.textBoxInterruptedProductionFilePath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxInterruptedProductionFilePath.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxInterruptedProductionFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxInterruptedProductionFilePath.Location = new System.Drawing.Point(56, 250);
            this.textBoxInterruptedProductionFilePath.Multiline = true;
            this.textBoxInterruptedProductionFilePath.Name = "textBoxInterruptedProductionFilePath";
            this.textBoxInterruptedProductionFilePath.Size = new System.Drawing.Size(406, 30);
            this.textBoxInterruptedProductionFilePath.TabIndex = 93;
            this.textBoxInterruptedProductionFilePath.Text = "-";
            // 
            // groupBoxRadioCzyPrzerywana
            // 
            this.groupBoxRadioCzyPrzerywana.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxRadioCzyPrzerywana.Controls.Add(this.radioInterruptedProductionTrue);
            this.groupBoxRadioCzyPrzerywana.Controls.Add(this.radioInterruptedProductionFalse);
            this.groupBoxRadioCzyPrzerywana.Controls.Add(this.labelCzyPrzerywanaOzdoba);
            this.groupBoxRadioCzyPrzerywana.Location = new System.Drawing.Point(468, 280);
            this.groupBoxRadioCzyPrzerywana.Name = "groupBoxRadioCzyPrzerywana";
            this.groupBoxRadioCzyPrzerywana.Size = new System.Drawing.Size(194, 73);
            this.groupBoxRadioCzyPrzerywana.TabIndex = 88;
            this.groupBoxRadioCzyPrzerywana.TabStop = false;
            // 
            // radioInterruptedProductionTrue
            // 
            this.radioInterruptedProductionTrue.AutoSize = true;
            this.radioInterruptedProductionTrue.Location = new System.Drawing.Point(42, 50);
            this.radioInterruptedProductionTrue.Name = "radioInterruptedProductionTrue";
            this.radioInterruptedProductionTrue.Size = new System.Drawing.Size(44, 17);
            this.radioInterruptedProductionTrue.TabIndex = 83;
            this.radioInterruptedProductionTrue.TabStop = true;
            this.radioInterruptedProductionTrue.Text = "Tak";
            this.radioInterruptedProductionTrue.UseVisualStyleBackColor = true;
            this.radioInterruptedProductionTrue.CheckedChanged += new System.EventHandler(this.radioCzyPrzerywanaTak_CheckedChanged);
            // 
            // radioInterruptedProductionFalse
            // 
            this.radioInterruptedProductionFalse.AutoSize = true;
            this.radioInterruptedProductionFalse.Location = new System.Drawing.Point(115, 50);
            this.radioInterruptedProductionFalse.Name = "radioInterruptedProductionFalse";
            this.radioInterruptedProductionFalse.Size = new System.Drawing.Size(41, 17);
            this.radioInterruptedProductionFalse.TabIndex = 85;
            this.radioInterruptedProductionFalse.TabStop = true;
            this.radioInterruptedProductionFalse.Text = "Nie";
            this.radioInterruptedProductionFalse.UseVisualStyleBackColor = true;
            this.radioInterruptedProductionFalse.CheckedChanged += new System.EventHandler(this.radioCzyPrzerywanaNie_CheckedChanged);
            // 
            // labelCzyPrzerywanaOzdoba
            // 
            this.labelCzyPrzerywanaOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCzyPrzerywanaOzdoba.AutoSize = true;
            this.labelCzyPrzerywanaOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelCzyPrzerywanaOzdoba.Location = new System.Drawing.Point(9, 18);
            this.labelCzyPrzerywanaOzdoba.Name = "labelCzyPrzerywanaOzdoba";
            this.labelCzyPrzerywanaOzdoba.Size = new System.Drawing.Size(177, 20);
            this.labelCzyPrzerywanaOzdoba.TabIndex = 73;
            this.labelCzyPrzerywanaOzdoba.Text = "PROD. PRZERYWANA";
            // 
            // listBoxAvailablePorts
            // 
            this.listBoxAvailablePorts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxAvailablePorts.BackColor = System.Drawing.SystemColors.Menu;
            this.listBoxAvailablePorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.listBoxAvailablePorts.HorizontalScrollbar = true;
            this.listBoxAvailablePorts.ItemHeight = 20;
            this.listBoxAvailablePorts.Location = new System.Drawing.Point(468, 117);
            this.listBoxAvailablePorts.Name = "listBoxAvailablePorts";
            this.listBoxAvailablePorts.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxAvailablePorts.Size = new System.Drawing.Size(194, 84);
            this.listBoxAvailablePorts.TabIndex = 91;
            // 
            // labelDostepnePorty
            // 
            this.labelDostepnePorty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDostepnePorty.AutoSize = true;
            this.labelDostepnePorty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelDostepnePorty.Location = new System.Drawing.Point(467, 89);
            this.labelDostepnePorty.Name = "labelDostepnePorty";
            this.labelDostepnePorty.Size = new System.Drawing.Size(183, 24);
            this.labelDostepnePorty.TabIndex = 90;
            this.labelDostepnePorty.Text = "DOSTĘPNE PORTY";
            // 
            // buttonOpcjeZapisz
            // 
            this.buttonOpcjeZapisz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOpcjeZapisz.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonOpcjeZapisz.Location = new System.Drawing.Point(57, 453);
            this.buttonOpcjeZapisz.Name = "buttonOpcjeZapisz";
            this.buttonOpcjeZapisz.Size = new System.Drawing.Size(181, 44);
            this.buttonOpcjeZapisz.TabIndex = 89;
            this.buttonOpcjeZapisz.Text = "Zapisz";
            this.buttonOpcjeZapisz.UseVisualStyleBackColor = true;
            this.buttonOpcjeZapisz.Click += new System.EventHandler(this.ButtonOpcjeZapisz_Click);
            // 
            // buttonOpcjeZapiszIWyjdz
            // 
            this.buttonOpcjeZapiszIWyjdz.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOpcjeZapiszIWyjdz.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonOpcjeZapiszIWyjdz.Location = new System.Drawing.Point(257, 453);
            this.buttonOpcjeZapiszIWyjdz.Name = "buttonOpcjeZapiszIWyjdz";
            this.buttonOpcjeZapiszIWyjdz.Size = new System.Drawing.Size(180, 44);
            this.buttonOpcjeZapiszIWyjdz.TabIndex = 88;
            this.buttonOpcjeZapiszIWyjdz.Text = "Zapisz i restart";
            this.buttonOpcjeZapiszIWyjdz.UseVisualStyleBackColor = true;
            this.buttonOpcjeZapiszIWyjdz.Click += new System.EventHandler(this.ButtonOpcjeZapiszIWyjdz_Click);
            // 
            // groupBoxRadioSAPKomunikacja
            // 
            this.groupBoxRadioSAPKomunikacja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxRadioSAPKomunikacja.Controls.Add(this.radioSAPCommunicationTrue);
            this.groupBoxRadioSAPKomunikacja.Controls.Add(this.radioSAPCommunicationFalse);
            this.groupBoxRadioSAPKomunikacja.Controls.Add(this.labelSAPKomunikacjaOzdoba);
            this.groupBoxRadioSAPKomunikacja.Location = new System.Drawing.Point(468, 207);
            this.groupBoxRadioSAPKomunikacja.Name = "groupBoxRadioSAPKomunikacja";
            this.groupBoxRadioSAPKomunikacja.Size = new System.Drawing.Size(194, 73);
            this.groupBoxRadioSAPKomunikacja.TabIndex = 87;
            this.groupBoxRadioSAPKomunikacja.TabStop = false;
            // 
            // radioSAPCommunicationTrue
            // 
            this.radioSAPCommunicationTrue.AutoSize = true;
            this.radioSAPCommunicationTrue.Location = new System.Drawing.Point(42, 50);
            this.radioSAPCommunicationTrue.Name = "radioSAPCommunicationTrue";
            this.radioSAPCommunicationTrue.Size = new System.Drawing.Size(44, 17);
            this.radioSAPCommunicationTrue.TabIndex = 83;
            this.radioSAPCommunicationTrue.TabStop = true;
            this.radioSAPCommunicationTrue.Text = "Tak";
            this.radioSAPCommunicationTrue.UseVisualStyleBackColor = true;
            this.radioSAPCommunicationTrue.CheckedChanged += new System.EventHandler(this.RadioSAPKomunikacjaTak_CheckedChanged);
            // 
            // radioSAPCommunicationFalse
            // 
            this.radioSAPCommunicationFalse.AutoSize = true;
            this.radioSAPCommunicationFalse.Location = new System.Drawing.Point(115, 50);
            this.radioSAPCommunicationFalse.Name = "radioSAPCommunicationFalse";
            this.radioSAPCommunicationFalse.Size = new System.Drawing.Size(41, 17);
            this.radioSAPCommunicationFalse.TabIndex = 85;
            this.radioSAPCommunicationFalse.TabStop = true;
            this.radioSAPCommunicationFalse.Text = "Nie";
            this.radioSAPCommunicationFalse.UseVisualStyleBackColor = true;
            this.radioSAPCommunicationFalse.CheckedChanged += new System.EventHandler(this.RadioSAPKomunikacjaNie_CheckedChanged);
            // 
            // labelSAPKomunikacjaOzdoba
            // 
            this.labelSAPKomunikacjaOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSAPKomunikacjaOzdoba.AutoSize = true;
            this.labelSAPKomunikacjaOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelSAPKomunikacjaOzdoba.Location = new System.Drawing.Point(21, 16);
            this.labelSAPKomunikacjaOzdoba.Name = "labelSAPKomunikacjaOzdoba";
            this.labelSAPKomunikacjaOzdoba.Size = new System.Drawing.Size(159, 20);
            this.labelSAPKomunikacjaOzdoba.TabIndex = 73;
            this.labelSAPKomunikacjaOzdoba.Text = "KOMUNIKACJA SAP";
            // 
            // textBoxCOMProductLabelScanner
            // 
            this.textBoxCOMProductLabelScanner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCOMProductLabelScanner.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxCOMProductLabelScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxCOMProductLabelScanner.Location = new System.Drawing.Point(56, 116);
            this.textBoxCOMProductLabelScanner.Name = "textBoxCOMProductLabelScanner";
            this.textBoxCOMProductLabelScanner.Size = new System.Drawing.Size(181, 26);
            this.textBoxCOMProductLabelScanner.TabIndex = 82;
            this.textBoxCOMProductLabelScanner.Text = "-";
            this.textBoxCOMProductLabelScanner.TextChanged += new System.EventHandler(this.TextBoxCOMSkDetalu_TextChanged);
            // 
            // COMSkDetaluOzdoba
            // 
            this.COMSkDetaluOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.COMSkDetaluOzdoba.AutoSize = true;
            this.COMSkDetaluOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.COMSkDetaluOzdoba.Location = new System.Drawing.Point(52, 89);
            this.COMSkDetaluOzdoba.Name = "COMSkDetaluOzdoba";
            this.COMSkDetaluOzdoba.Size = new System.Drawing.Size(123, 24);
            this.COMSkDetaluOzdoba.TabIndex = 81;
            this.COMSkDetaluOzdoba.Text = "SK1 DETALU";
            // 
            // textBoxCOMCartonLabelScanner
            // 
            this.textBoxCOMCartonLabelScanner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCOMCartonLabelScanner.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxCOMCartonLabelScanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxCOMCartonLabelScanner.Location = new System.Drawing.Point(56, 184);
            this.textBoxCOMCartonLabelScanner.Name = "textBoxCOMCartonLabelScanner";
            this.textBoxCOMCartonLabelScanner.Size = new System.Drawing.Size(181, 26);
            this.textBoxCOMCartonLabelScanner.TabIndex = 80;
            this.textBoxCOMCartonLabelScanner.Text = "-";
            this.textBoxCOMCartonLabelScanner.TextChanged += new System.EventHandler(this.TextBoxCOMSkKartonu_TextChanged);
            // 
            // labelCOMSkKartonuOzdoba
            // 
            this.labelCOMSkKartonuOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCOMSkKartonuOzdoba.AutoSize = true;
            this.labelCOMSkKartonuOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelCOMSkKartonuOzdoba.Location = new System.Drawing.Point(52, 161);
            this.labelCOMSkKartonuOzdoba.Name = "labelCOMSkKartonuOzdoba";
            this.labelCOMSkKartonuOzdoba.Size = new System.Drawing.Size(141, 24);
            this.labelCOMSkKartonuOzdoba.TabIndex = 79;
            this.labelCOMSkKartonuOzdoba.Text = "SK2 KARTONU";
            // 
            // textBoxPortSAP
            // 
            this.textBoxPortSAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPortSAP.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxPortSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPortSAP.Location = new System.Drawing.Point(256, 116);
            this.textBoxPortSAP.Name = "textBoxPortSAP";
            this.textBoxPortSAP.Size = new System.Drawing.Size(180, 26);
            this.textBoxPortSAP.TabIndex = 78;
            this.textBoxPortSAP.Text = "-";
            this.textBoxPortSAP.TextChanged += new System.EventHandler(this.TextBoxPortSAP_TextChanged);
            // 
            // labelPortSAPOzdoba
            // 
            this.labelPortSAPOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPortSAPOzdoba.AutoSize = true;
            this.labelPortSAPOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelPortSAPOzdoba.Location = new System.Drawing.Point(252, 89);
            this.labelPortSAPOzdoba.Name = "labelPortSAPOzdoba";
            this.labelPortSAPOzdoba.Size = new System.Drawing.Size(104, 24);
            this.labelPortSAPOzdoba.TabIndex = 77;
            this.labelPortSAPOzdoba.Text = "PORT SAP";
            // 
            // textBoxIPSAP
            // 
            this.textBoxIPSAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxIPSAP.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxIPSAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxIPSAP.Location = new System.Drawing.Point(256, 48);
            this.textBoxIPSAP.Name = "textBoxIPSAP";
            this.textBoxIPSAP.Size = new System.Drawing.Size(180, 26);
            this.textBoxIPSAP.TabIndex = 76;
            this.textBoxIPSAP.Text = ".";
            this.textBoxIPSAP.TextChanged += new System.EventHandler(this.TextBoxIPSAP_TextChanged);
            // 
            // labelIPSAPOzdoba
            // 
            this.labelIPSAPOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelIPSAPOzdoba.AutoSize = true;
            this.labelIPSAPOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelIPSAPOzdoba.Location = new System.Drawing.Point(252, 21);
            this.labelIPSAPOzdoba.Name = "labelIPSAPOzdoba";
            this.labelIPSAPOzdoba.Size = new System.Drawing.Size(68, 24);
            this.labelIPSAPOzdoba.TabIndex = 75;
            this.labelIPSAPOzdoba.Text = "IP SAP";
            // 
            // textBoxStationName
            // 
            this.textBoxStationName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxStationName.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxStationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxStationName.Location = new System.Drawing.Point(56, 48);
            this.textBoxStationName.Name = "textBoxStationName";
            this.textBoxStationName.Size = new System.Drawing.Size(181, 26);
            this.textBoxStationName.TabIndex = 72;
            this.textBoxStationName.Text = "-";
            this.textBoxStationName.TextChanged += new System.EventHandler(this.TextBoxNazwaStacji_TextChanged);
            // 
            // labelNazwaStacjiOzdoba
            // 
            this.labelNazwaStacjiOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNazwaStacjiOzdoba.AutoSize = true;
            this.labelNazwaStacjiOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelNazwaStacjiOzdoba.Location = new System.Drawing.Point(52, 21);
            this.labelNazwaStacjiOzdoba.Name = "labelNazwaStacjiOzdoba";
            this.labelNazwaStacjiOzdoba.Size = new System.Drawing.Size(148, 24);
            this.labelNazwaStacjiOzdoba.TabIndex = 71;
            this.labelNazwaStacjiOzdoba.Text = "NAZWA STACJI";
            // 
            // textBoxPortFIS
            // 
            this.textBoxPortFIS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPortFIS.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxPortFIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxPortFIS.Location = new System.Drawing.Point(256, 184);
            this.textBoxPortFIS.Name = "textBoxPortFIS";
            this.textBoxPortFIS.Size = new System.Drawing.Size(180, 26);
            this.textBoxPortFIS.TabIndex = 70;
            this.textBoxPortFIS.Text = "-";
            this.textBoxPortFIS.TextChanged += new System.EventHandler(this.TextBoxPortFIS_TextChanged);
            // 
            // labelPortFISOzdoba
            // 
            this.labelPortFISOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPortFISOzdoba.AutoSize = true;
            this.labelPortFISOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelPortFISOzdoba.Location = new System.Drawing.Point(252, 157);
            this.labelPortFISOzdoba.Name = "labelPortFISOzdoba";
            this.labelPortFISOzdoba.Size = new System.Drawing.Size(95, 24);
            this.labelPortFISOzdoba.TabIndex = 69;
            this.labelPortFISOzdoba.Text = "PORT FIS";
            // 
            // textBoxIPFIS
            // 
            this.textBoxIPFIS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxIPFIS.BackColor = System.Drawing.SystemColors.Menu;
            this.textBoxIPFIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxIPFIS.Location = new System.Drawing.Point(468, 48);
            this.textBoxIPFIS.Name = "textBoxIPFIS";
            this.textBoxIPFIS.Size = new System.Drawing.Size(180, 26);
            this.textBoxIPFIS.TabIndex = 68;
            this.textBoxIPFIS.Text = "-";
            this.textBoxIPFIS.TextChanged += new System.EventHandler(this.TextBoxIPFIS_TextChanged);
            // 
            // labelIPFISOzdoba
            // 
            this.labelIPFISOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelIPFISOzdoba.AutoSize = true;
            this.labelIPFISOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelIPFISOzdoba.Location = new System.Drawing.Point(464, 21);
            this.labelIPFISOzdoba.Name = "labelIPFISOzdoba";
            this.labelIPFISOzdoba.Size = new System.Drawing.Size(59, 24);
            this.labelIPFISOzdoba.TabIndex = 67;
            this.labelIPFISOzdoba.Text = "IP FIS";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(587, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 30);
            this.label2.TabIndex = 67;
            this.label2.Text = "OPCJE";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.radioLegacyInterruptedProductionMethodTrue);
            this.groupBox1.Controls.Add(this.radioLegacyInterruptedProductionMethodFalse);
            this.groupBox1.Controls.Add(this.labelStaryTrybPrzerywanejOzdoba);
            this.groupBox1.Location = new System.Drawing.Point(468, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 100);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            // 
            // radioLegacyInterruptedProductionMethodTrue
            // 
            this.radioLegacyInterruptedProductionMethodTrue.AutoSize = true;
            this.radioLegacyInterruptedProductionMethodTrue.Location = new System.Drawing.Point(42, 77);
            this.radioLegacyInterruptedProductionMethodTrue.Name = "radioLegacyInterruptedProductionMethodTrue";
            this.radioLegacyInterruptedProductionMethodTrue.Size = new System.Drawing.Size(44, 17);
            this.radioLegacyInterruptedProductionMethodTrue.TabIndex = 83;
            this.radioLegacyInterruptedProductionMethodTrue.TabStop = true;
            this.radioLegacyInterruptedProductionMethodTrue.Text = "Tak";
            this.radioLegacyInterruptedProductionMethodTrue.UseVisualStyleBackColor = true;
            this.radioLegacyInterruptedProductionMethodTrue.CheckedChanged += new System.EventHandler(this.radioLegacyInterruptedProductionMethodTrue_CheckedChanged);
            // 
            // radioLegacyInterruptedProductionMethodFalse
            // 
            this.radioLegacyInterruptedProductionMethodFalse.AutoSize = true;
            this.radioLegacyInterruptedProductionMethodFalse.Location = new System.Drawing.Point(115, 77);
            this.radioLegacyInterruptedProductionMethodFalse.Name = "radioLegacyInterruptedProductionMethodFalse";
            this.radioLegacyInterruptedProductionMethodFalse.Size = new System.Drawing.Size(41, 17);
            this.radioLegacyInterruptedProductionMethodFalse.TabIndex = 85;
            this.radioLegacyInterruptedProductionMethodFalse.TabStop = true;
            this.radioLegacyInterruptedProductionMethodFalse.Text = "Nie";
            this.radioLegacyInterruptedProductionMethodFalse.UseVisualStyleBackColor = true;
            this.radioLegacyInterruptedProductionMethodFalse.CheckedChanged += new System.EventHandler(this.radioLegacyInterruptedProductionMethodFalse_CheckedChanged);
            // 
            // labelStaryTrybPrzerywanejOzdoba
            // 
            this.labelStaryTrybPrzerywanejOzdoba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStaryTrybPrzerywanejOzdoba.AutoSize = true;
            this.labelStaryTrybPrzerywanejOzdoba.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStaryTrybPrzerywanejOzdoba.Location = new System.Drawing.Point(9, 13);
            this.labelStaryTrybPrzerywanejOzdoba.Name = "labelStaryTrybPrzerywanejOzdoba";
            this.labelStaryTrybPrzerywanejOzdoba.Size = new System.Drawing.Size(173, 60);
            this.labelStaryTrybPrzerywanejOzdoba.TabIndex = 73;
            this.labelStaryTrybPrzerywanejOzdoba.Text = "STARY TRYB PRZER.\r\n(OSTROŻNIE Z TĄ\r\n OPCJĄ)";
            this.labelStaryTrybPrzerywanejOzdoba.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OptionsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(733, 554);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsMenu";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = ",";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBoxRadioCzyPrzerywana.ResumeLayout(false);
            this.groupBoxRadioCzyPrzerywana.PerformLayout();
            this.groupBoxRadioSAPKomunikacja.ResumeLayout(false);
            this.groupBoxRadioSAPKomunikacja.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPortFISOzdoba;
        private System.Windows.Forms.TextBox textBoxIPFIS;
        private System.Windows.Forms.Label labelIPFISOzdoba;
        private System.Windows.Forms.TextBox textBoxPortFIS;
        private System.Windows.Forms.TextBox textBoxCOMProductLabelScanner;
        private System.Windows.Forms.Label COMSkDetaluOzdoba;
        private System.Windows.Forms.TextBox textBoxCOMCartonLabelScanner;
        private System.Windows.Forms.Label labelCOMSkKartonuOzdoba;
        private System.Windows.Forms.TextBox textBoxPortSAP;
        private System.Windows.Forms.Label labelPortSAPOzdoba;
        private System.Windows.Forms.TextBox textBoxIPSAP;
        private System.Windows.Forms.Label labelIPSAPOzdoba;
        private System.Windows.Forms.Label labelSAPKomunikacjaOzdoba;
        private System.Windows.Forms.TextBox textBoxStationName;
        private System.Windows.Forms.Label labelNazwaStacjiOzdoba;
        private System.Windows.Forms.GroupBox groupBoxRadioSAPKomunikacja;
        private System.Windows.Forms.RadioButton radioSAPCommunicationTrue;
        private System.Windows.Forms.RadioButton radioSAPCommunicationFalse;
        private System.Windows.Forms.Button buttonOpcjeZapisz;
        private System.Windows.Forms.Button buttonOpcjeZapiszIWyjdz;
        private System.Windows.Forms.Label labelDostepnePorty;
        private System.Windows.Forms.ListBox listBoxAvailablePorts;
        private System.Windows.Forms.GroupBox groupBoxRadioCzyPrzerywana;
        private System.Windows.Forms.RadioButton radioInterruptedProductionTrue;
        private System.Windows.Forms.RadioButton radioInterruptedProductionFalse;
        private System.Windows.Forms.Label labelCzyPrzerywanaOzdoba;
        private System.Windows.Forms.TextBox textBoxInterruptedProductionFilePath;
        private System.Windows.Forms.Label LokalizacjaPPOzdoba;
        private System.Windows.Forms.ListBox listBoxPingFIS;
        private System.Windows.Forms.Button buttonPingFIS;
        private System.Windows.Forms.ListBox listBoxPingSAP;
        private System.Windows.Forms.Button buttonPingSAP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioLegacyInterruptedProductionMethodTrue;
        private System.Windows.Forms.RadioButton radioLegacyInterruptedProductionMethodFalse;
        private System.Windows.Forms.Label labelStaryTrybPrzerywanejOzdoba;
    }
}
