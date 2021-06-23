namespace AutomatedTestingProject
{
    public partial class AutomatedWebTestingForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMessageShow = new System.Windows.Forms.TextBox();
            this.tbMainMenu = new System.Windows.Forms.TabControl();
            this.tpBasicFuntion = new System.Windows.Forms.TabPage();
            this.gbSystemTool = new System.Windows.Forms.GroupBox();
            this.gbSecurity = new System.Windows.Forms.GroupBox();
            this.gbWirelessBasic = new System.Windows.Forms.GroupBox();
            this.gbLANBasic = new System.Windows.Forms.GroupBox();
            this.gbWANType = new System.Windows.Forms.GroupBox();
            this.cbWANType_PPPoE = new System.Windows.Forms.CheckBox();
            this.cbWANType_StaticIP = new System.Windows.Forms.CheckBox();
            this.cbWANType_DHCP = new System.Windows.Forms.CheckBox();
            this.tpBasicPataSetting = new System.Windows.Forms.TabPage();
            this.tpFunctionTesting1 = new System.Windows.Forms.TabPage();
            this.gbCheckBox = new System.Windows.Forms.GroupBox();
            this.rbtnLast = new System.Windows.Forms.RadioButton();
            this.rbtnFront = new System.Windows.Forms.RadioButton();
            this.cbMultiSelectBox = new System.Windows.Forms.CheckBox();
            this.tbCheckBoxIdx = new System.Windows.Forms.TextBox();
            this.lbCheckBoxIdx = new System.Windows.Forms.Label();
            this.lbCheckBoxID = new System.Windows.Forms.Label();
            this.tbCheckBoxID = new System.Windows.Forms.TextBox();
            this.btnCheckBox = new System.Windows.Forms.Button();
            this.gbRadioButton = new System.Windows.Forms.GroupBox();
            this.cbparentNode = new System.Windows.Forms.CheckBox();
            this.tbRadioButtonItem = new System.Windows.Forms.TextBox();
            this.lbRadioButtonItem = new System.Windows.Forms.Label();
            this.lbRadioButtonID = new System.Windows.Forms.Label();
            this.tbRadioButtonID = new System.Windows.Forms.TextBox();
            this.btnRadioButton = new System.Windows.Forms.Button();
            this.gbGetElementValue = new System.Windows.Forms.GroupBox();
            this.lbGetElementValue = new System.Windows.Forms.Label();
            this.tbGetElementValue = new System.Windows.Forms.TextBox();
            this.btnGetElementValue = new System.Windows.Forms.Button();
            this.gbDropDownList = new System.Windows.Forms.GroupBox();
            this.tbSelectItem = new System.Windows.Forms.TextBox();
            this.lbSelectItem = new System.Windows.Forms.Label();
            this.lbDropDownListName = new System.Windows.Forms.Label();
            this.tbDropDownListName = new System.Windows.Forms.TextBox();
            this.btnDropDownList = new System.Windows.Forms.Button();
            this.gbSwitchButtonClick = new System.Windows.Forms.GroupBox();
            this.tbSwitchButtonClassIndex = new System.Windows.Forms.TextBox();
            this.lbSwitchButtonClassIndex = new System.Windows.Forms.Label();
            this.lbSwitchButtonClick = new System.Windows.Forms.Label();
            this.tbSwitchButtonClick = new System.Windows.Forms.TextBox();
            this.btnSwitchButtonClick = new System.Windows.Forms.Button();
            this.gbScrollElement = new System.Windows.Forms.GroupBox();
            this.tbClassIndex = new System.Windows.Forms.TextBox();
            this.lbClassIndex = new System.Windows.Forms.Label();
            this.lbElementType = new System.Windows.Forms.Label();
            this.btnScrollElementLeft = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnScrollElementRight = new System.Windows.Forms.Button();
            this.btnScrollElementDown = new System.Windows.Forms.Button();
            this.tbMovedPixels = new System.Windows.Forms.TextBox();
            this.lbMovedPixels = new System.Windows.Forms.Label();
            this.lbScrollElement = new System.Windows.Forms.Label();
            this.tbScrollElement = new System.Windows.Forms.TextBox();
            this.btnScrollElementUp = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.clbScrollElement = new System.Windows.Forms.CheckedListBox();
            this.gpButtonClick = new System.Windows.Forms.GroupBox();
            this.tbClassIndexButtonClick = new System.Windows.Forms.TextBox();
            this.lbClassIndexButtonClick = new System.Windows.Forms.Label();
            this.cbButtonClick = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbButtonClick = new System.Windows.Forms.TextBox();
            this.btnButtonClick = new System.Windows.Forms.Button();
            this.gbKeyIn = new System.Windows.Forms.GroupBox();
            this.tbIDSendKey = new System.Windows.Forms.TextBox();
            this.lbIDSendKey = new System.Windows.Forms.Label();
            this.lbKeyIn = new System.Windows.Forms.Label();
            this.tbSendKey = new System.Windows.Forms.TextBox();
            this.btnSendKeys = new System.Windows.Forms.Button();
            this.gbFindElement = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFindElement = new System.Windows.Forms.ComboBox();
            this.tbFindElement = new System.Windows.Forms.TextBox();
            this.btnFindElement = new System.Windows.Forms.Button();
            this.gbURL = new System.Windows.Forms.GroupBox();
            this.lbOpenURL = new System.Windows.Forms.Label();
            this.tbOpenURL = new System.Windows.Forms.TextBox();
            this.btnOpenURL = new System.Windows.Forms.Button();
            this.tpFunctionTesting2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.gbFunctionControl = new System.Windows.Forms.GroupBox();
            this.gbPageChanging = new System.Windows.Forms.GroupBox();
            this.lbTopPageIndex = new System.Windows.Forms.Label();
            this.tbTopPageIndex = new System.Windows.Forms.TextBox();
            this.tbChildrenPageName = new System.Windows.Forms.TextBox();
            this.lbChildrenPageName = new System.Windows.Forms.Label();
            this.lbParentPageID = new System.Windows.Forms.Label();
            this.tblbParentPageID = new System.Windows.Forms.TextBox();
            this.btnMovePage = new System.Windows.Forms.Button();
            this.gbWebRefresh = new System.Windows.Forms.GroupBox();
            this.btnWebRefresh = new System.Windows.Forms.Button();
            this.gbRestartDriver = new System.Windows.Forms.GroupBox();
            this.btnRestartDriver = new System.Windows.Forms.Button();
            this.gbSystemControl = new System.Windows.Forms.GroupBox();
            this.btnReboot = new System.Windows.Forms.Button();
            this.btnFactoryRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnBackupRestore = new System.Windows.Forms.Button();
            this.btnLocalUpgrade = new System.Windows.Forms.Button();
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.btnLoginWarning = new System.Windows.Forms.Button();
            this.btnLoginStatus = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSettingPwd = new System.Windows.Forms.Button();
            this.gbConnectWiFi = new System.Windows.Forms.GroupBox();
            this.btnSaveWiFiInfo = new System.Windows.Forms.Button();
            this.tbSsidPasswd = new System.Windows.Forms.TextBox();
            this.lbSsidPasswd = new System.Windows.Forms.Label();
            this.btnTurnOffWiFi = new System.Windows.Forms.Button();
            this.lbWiFiName = new System.Windows.Forms.Label();
            this.tbSsidiName = new System.Windows.Forms.TextBox();
            this.btnTurnOnWiFi = new System.Windows.Forms.Button();
            this.btnConnectWiFi = new System.Windows.Forms.Button();
            this.gbSettingNetworkInterface = new System.Windows.Forms.GroupBox();
            this.tbInterfaceName = new System.Windows.Forms.TextBox();
            this.btnDisableInterface = new System.Windows.Forms.Button();
            this.btnEnableInterface = new System.Windows.Forms.Button();
            this.btnSetupToStaticIP = new System.Windows.Forms.Button();
            this.lbGateway = new System.Windows.Forms.Label();
            this.tbGateway = new System.Windows.Forms.TextBox();
            this.lbSubMesk = new System.Windows.Forms.Label();
            this.tbSubMesk = new System.Windows.Forms.TextBox();
            this.lbIPAddress = new System.Windows.Forms.Label();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.lbInterfaceName = new System.Windows.Forms.Label();
            this.btnSetupToDHCP = new System.Windows.Forms.Button();
            this.gbMessageShow = new System.Windows.Forms.GroupBox();
            this.lbVersionNum = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbWANType_L2TP = new System.Windows.Forms.CheckBox();
            this.cbWANType_PPTP = new System.Windows.Forms.CheckBox();
            this.cbWANType_Bridge = new System.Windows.Forms.CheckBox();
            this.tbMainMenu.SuspendLayout();
            this.tpBasicFuntion.SuspendLayout();
            this.gbWANType.SuspendLayout();
            this.tpFunctionTesting1.SuspendLayout();
            this.gbCheckBox.SuspendLayout();
            this.gbRadioButton.SuspendLayout();
            this.gbGetElementValue.SuspendLayout();
            this.gbDropDownList.SuspendLayout();
            this.gbSwitchButtonClick.SuspendLayout();
            this.gbScrollElement.SuspendLayout();
            this.gpButtonClick.SuspendLayout();
            this.gbKeyIn.SuspendLayout();
            this.gbFindElement.SuspendLayout();
            this.gbURL.SuspendLayout();
            this.tpFunctionTesting2.SuspendLayout();
            this.gbFunctionControl.SuspendLayout();
            this.gbPageChanging.SuspendLayout();
            this.gbWebRefresh.SuspendLayout();
            this.gbRestartDriver.SuspendLayout();
            this.gbSystemControl.SuspendLayout();
            this.gbAccount.SuspendLayout();
            this.gbConnectWiFi.SuspendLayout();
            this.gbSettingNetworkInterface.SuspendLayout();
            this.gbMessageShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMessageShow
            // 
            this.tbMessageShow.BackColor = System.Drawing.Color.White;
            this.tbMessageShow.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMessageShow.Location = new System.Drawing.Point(14, 35);
            this.tbMessageShow.Margin = new System.Windows.Forms.Padding(2);
            this.tbMessageShow.Multiline = true;
            this.tbMessageShow.Name = "tbMessageShow";
            this.tbMessageShow.ReadOnly = true;
            this.tbMessageShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbMessageShow.Size = new System.Drawing.Size(374, 615);
            this.tbMessageShow.TabIndex = 1;
            this.tbMessageShow.WordWrap = false;
            // 
            // tbMainMenu
            // 
            this.tbMainMenu.Controls.Add(this.tpBasicFuntion);
            this.tbMainMenu.Controls.Add(this.tpBasicPataSetting);
            this.tbMainMenu.Controls.Add(this.tpFunctionTesting1);
            this.tbMainMenu.Controls.Add(this.tpFunctionTesting2);
            this.tbMainMenu.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tbMainMenu.ItemSize = new System.Drawing.Size(200, 40);
            this.tbMainMenu.Location = new System.Drawing.Point(422, 23);
            this.tbMainMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tbMainMenu.Name = "tbMainMenu";
            this.tbMainMenu.SelectedIndex = 0;
            this.tbMainMenu.Size = new System.Drawing.Size(796, 664);
            this.tbMainMenu.TabIndex = 5;
            // 
            // tpBasicFuntion
            // 
            this.tpBasicFuntion.Controls.Add(this.gbSystemTool);
            this.tpBasicFuntion.Controls.Add(this.gbSecurity);
            this.tpBasicFuntion.Controls.Add(this.gbWirelessBasic);
            this.tpBasicFuntion.Controls.Add(this.gbLANBasic);
            this.tpBasicFuntion.Controls.Add(this.gbWANType);
            this.tpBasicFuntion.Location = new System.Drawing.Point(4, 44);
            this.tpBasicFuntion.Margin = new System.Windows.Forms.Padding(2);
            this.tpBasicFuntion.Name = "tpBasicFuntion";
            this.tpBasicFuntion.Padding = new System.Windows.Forms.Padding(2);
            this.tpBasicFuntion.Size = new System.Drawing.Size(788, 616);
            this.tpBasicFuntion.TabIndex = 1;
            this.tpBasicFuntion.Text = "自動化測項";
            this.tpBasicFuntion.UseVisualStyleBackColor = true;
            // 
            // gbSystemTool
            // 
            this.gbSystemTool.Location = new System.Drawing.Point(472, 15);
            this.gbSystemTool.Name = "gbSystemTool";
            this.gbSystemTool.Size = new System.Drawing.Size(212, 260);
            this.gbSystemTool.TabIndex = 4;
            this.gbSystemTool.TabStop = false;
            this.gbSystemTool.Text = "SystemTool";
            // 
            // gbSecurity
            // 
            this.gbSecurity.Location = new System.Drawing.Point(14, 469);
            this.gbSecurity.Name = "gbSecurity";
            this.gbSecurity.Size = new System.Drawing.Size(212, 128);
            this.gbSecurity.TabIndex = 5;
            this.gbSecurity.TabStop = false;
            this.gbSecurity.Text = "Security";
            // 
            // gbWirelessBasic
            // 
            this.gbWirelessBasic.Location = new System.Drawing.Point(244, 15);
            this.gbWirelessBasic.Name = "gbWirelessBasic";
            this.gbWirelessBasic.Size = new System.Drawing.Size(212, 448);
            this.gbWirelessBasic.TabIndex = 3;
            this.gbWirelessBasic.TabStop = false;
            this.gbWirelessBasic.Text = "WirelessBasic";
            // 
            // gbLANBasic
            // 
            this.gbLANBasic.Location = new System.Drawing.Point(14, 15);
            this.gbLANBasic.Name = "gbLANBasic";
            this.gbLANBasic.Size = new System.Drawing.Size(212, 137);
            this.gbLANBasic.TabIndex = 2;
            this.gbLANBasic.TabStop = false;
            this.gbLANBasic.Text = "LANBasic";
            // 
            // gbWANType
            // 
            this.gbWANType.Controls.Add(this.cbWANType_Bridge);
            this.gbWANType.Controls.Add(this.cbWANType_PPTP);
            this.gbWANType.Controls.Add(this.cbWANType_L2TP);
            this.gbWANType.Controls.Add(this.cbWANType_PPPoE);
            this.gbWANType.Controls.Add(this.cbWANType_StaticIP);
            this.gbWANType.Controls.Add(this.cbWANType_DHCP);
            this.gbWANType.Location = new System.Drawing.Point(14, 168);
            this.gbWANType.Name = "gbWANType";
            this.gbWANType.Size = new System.Drawing.Size(212, 234);
            this.gbWANType.TabIndex = 1;
            this.gbWANType.TabStop = false;
            this.gbWANType.Text = "WANType";
            // 
            // cbWANType_PPPoE
            // 
            this.cbWANType_PPPoE.AutoSize = true;
            this.cbWANType_PPPoE.Location = new System.Drawing.Point(22, 100);
            this.cbWANType_PPPoE.Name = "cbWANType_PPPoE";
            this.cbWANType_PPPoE.Size = new System.Drawing.Size(160, 24);
            this.cbWANType_PPPoE.TabIndex = 2;
            this.cbWANType_PPPoE.Text = "WANType_PPPoE";
            this.cbWANType_PPPoE.UseVisualStyleBackColor = true;
            // 
            // cbWANType_StaticIP
            // 
            this.cbWANType_StaticIP.AutoSize = true;
            this.cbWANType_StaticIP.Location = new System.Drawing.Point(22, 69);
            this.cbWANType_StaticIP.Name = "cbWANType_StaticIP";
            this.cbWANType_StaticIP.Size = new System.Drawing.Size(168, 24);
            this.cbWANType_StaticIP.TabIndex = 1;
            this.cbWANType_StaticIP.Text = "WANType_StaticIP";
            this.cbWANType_StaticIP.UseVisualStyleBackColor = true;
            // 
            // cbWANType_DHCP
            // 
            this.cbWANType_DHCP.AutoSize = true;
            this.cbWANType_DHCP.Location = new System.Drawing.Point(22, 38);
            this.cbWANType_DHCP.Name = "cbWANType_DHCP";
            this.cbWANType_DHCP.Size = new System.Drawing.Size(156, 24);
            this.cbWANType_DHCP.TabIndex = 0;
            this.cbWANType_DHCP.Text = "WANType_DHCP";
            this.cbWANType_DHCP.UseVisualStyleBackColor = true;
            // 
            // tpBasicPataSetting
            // 
            this.tpBasicPataSetting.Location = new System.Drawing.Point(4, 44);
            this.tpBasicPataSetting.Margin = new System.Windows.Forms.Padding(2);
            this.tpBasicPataSetting.Name = "tpBasicPataSetting";
            this.tpBasicPataSetting.Size = new System.Drawing.Size(788, 616);
            this.tpBasicPataSetting.TabIndex = 2;
            this.tpBasicPataSetting.Text = "默認參數設置";
            this.tpBasicPataSetting.UseVisualStyleBackColor = true;
            // 
            // tpFunctionTesting1
            // 
            this.tpFunctionTesting1.Controls.Add(this.gbCheckBox);
            this.tpFunctionTesting1.Controls.Add(this.gbRadioButton);
            this.tpFunctionTesting1.Controls.Add(this.gbGetElementValue);
            this.tpFunctionTesting1.Controls.Add(this.gbDropDownList);
            this.tpFunctionTesting1.Controls.Add(this.gbSwitchButtonClick);
            this.tpFunctionTesting1.Controls.Add(this.gbScrollElement);
            this.tpFunctionTesting1.Controls.Add(this.gpButtonClick);
            this.tpFunctionTesting1.Controls.Add(this.gbKeyIn);
            this.tpFunctionTesting1.Controls.Add(this.gbFindElement);
            this.tpFunctionTesting1.Controls.Add(this.gbURL);
            this.tpFunctionTesting1.Location = new System.Drawing.Point(4, 44);
            this.tpFunctionTesting1.Margin = new System.Windows.Forms.Padding(2);
            this.tpFunctionTesting1.Name = "tpFunctionTesting1";
            this.tpFunctionTesting1.Padding = new System.Windows.Forms.Padding(2);
            this.tpFunctionTesting1.Size = new System.Drawing.Size(788, 616);
            this.tpFunctionTesting1.TabIndex = 0;
            this.tpFunctionTesting1.Text = "部件功能 I";
            this.tpFunctionTesting1.UseVisualStyleBackColor = true;
            // 
            // gbCheckBox
            // 
            this.gbCheckBox.Controls.Add(this.rbtnLast);
            this.gbCheckBox.Controls.Add(this.rbtnFront);
            this.gbCheckBox.Controls.Add(this.cbMultiSelectBox);
            this.gbCheckBox.Controls.Add(this.tbCheckBoxIdx);
            this.gbCheckBox.Controls.Add(this.lbCheckBoxIdx);
            this.gbCheckBox.Controls.Add(this.lbCheckBoxID);
            this.gbCheckBox.Controls.Add(this.tbCheckBoxID);
            this.gbCheckBox.Controls.Add(this.btnCheckBox);
            this.gbCheckBox.Location = new System.Drawing.Point(530, 270);
            this.gbCheckBox.Name = "gbCheckBox";
            this.gbCheckBox.Size = new System.Drawing.Size(253, 205);
            this.gbCheckBox.TabIndex = 37;
            this.gbCheckBox.TabStop = false;
            this.gbCheckBox.Text = "SelectBox";
            // 
            // rbtnLast
            // 
            this.rbtnLast.AutoSize = true;
            this.rbtnLast.Location = new System.Drawing.Point(19, 164);
            this.rbtnLast.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnLast.Name = "rbtnLast";
            this.rbtnLast.Size = new System.Drawing.Size(121, 24);
            this.rbtnLast.TabIndex = 47;
            this.rbtnLast.Text = "LastChildren";
            this.rbtnLast.UseVisualStyleBackColor = true;
            this.rbtnLast.CheckedChanged += new System.EventHandler(this.rbtnLast_CheckedChanged);
            // 
            // rbtnFront
            // 
            this.rbtnFront.AutoSize = true;
            this.rbtnFront.Checked = true;
            this.rbtnFront.Location = new System.Drawing.Point(19, 136);
            this.rbtnFront.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFront.Name = "rbtnFront";
            this.rbtnFront.Size = new System.Drawing.Size(131, 24);
            this.rbtnFront.TabIndex = 46;
            this.rbtnFront.TabStop = true;
            this.rbtnFront.Text = "FrontChildren";
            this.rbtnFront.UseVisualStyleBackColor = true;
            this.rbtnFront.CheckedChanged += new System.EventHandler(this.rbtnFront_CheckedChanged);
            // 
            // cbMultiSelectBox
            // 
            this.cbMultiSelectBox.AutoSize = true;
            this.cbMultiSelectBox.Location = new System.Drawing.Point(19, 62);
            this.cbMultiSelectBox.Margin = new System.Windows.Forms.Padding(2);
            this.cbMultiSelectBox.Name = "cbMultiSelectBox";
            this.cbMultiSelectBox.Size = new System.Drawing.Size(214, 24);
            this.cbMultiSelectBox.TabIndex = 45;
            this.cbMultiSelectBox.Text = "multi-selectboxs in a line";
            this.cbMultiSelectBox.UseVisualStyleBackColor = true;
            this.cbMultiSelectBox.CheckedChanged += new System.EventHandler(this.cbMultiSelectBox_CheckedChanged);
            // 
            // tbCheckBoxIdx
            // 
            this.tbCheckBoxIdx.Location = new System.Drawing.Point(102, 101);
            this.tbCheckBoxIdx.Margin = new System.Windows.Forms.Padding(2);
            this.tbCheckBoxIdx.Name = "tbCheckBoxIdx";
            this.tbCheckBoxIdx.Size = new System.Drawing.Size(32, 29);
            this.tbCheckBoxIdx.TabIndex = 44;
            this.tbCheckBoxIdx.Text = "1";
            // 
            // lbCheckBoxIdx
            // 
            this.lbCheckBoxIdx.AutoSize = true;
            this.lbCheckBoxIdx.Location = new System.Drawing.Point(15, 103);
            this.lbCheckBoxIdx.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCheckBoxIdx.Name = "lbCheckBoxIdx";
            this.lbCheckBoxIdx.Size = new System.Drawing.Size(89, 20);
            this.lbCheckBoxIdx.TabIndex = 40;
            this.lbCheckBoxIdx.Text = "SelectItem";
            // 
            // lbCheckBoxID
            // 
            this.lbCheckBoxID.AutoSize = true;
            this.lbCheckBoxID.Location = new System.Drawing.Point(15, 30);
            this.lbCheckBoxID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbCheckBoxID.Name = "lbCheckBoxID";
            this.lbCheckBoxID.Size = new System.Drawing.Size(72, 20);
            this.lbCheckBoxID.TabIndex = 32;
            this.lbCheckBoxID.Text = "IDName";
            // 
            // tbCheckBoxID
            // 
            this.tbCheckBoxID.Location = new System.Drawing.Point(87, 26);
            this.tbCheckBoxID.Margin = new System.Windows.Forms.Padding(2);
            this.tbCheckBoxID.Name = "tbCheckBoxID";
            this.tbCheckBoxID.Size = new System.Drawing.Size(157, 29);
            this.tbCheckBoxID.TabIndex = 31;
            this.tbCheckBoxID.Text = "mssid1SeeEachOther";
            // 
            // btnCheckBox
            // 
            this.btnCheckBox.Location = new System.Drawing.Point(152, 101);
            this.btnCheckBox.Name = "btnCheckBox";
            this.btnCheckBox.Size = new System.Drawing.Size(91, 90);
            this.btnCheckBox.TabIndex = 30;
            this.btnCheckBox.Text = "SelectBox";
            this.btnCheckBox.UseVisualStyleBackColor = true;
            this.btnCheckBox.Click += new System.EventHandler(this.btnCheckBox_Click_1);
            // 
            // gbRadioButton
            // 
            this.gbRadioButton.Controls.Add(this.cbparentNode);
            this.gbRadioButton.Controls.Add(this.tbRadioButtonItem);
            this.gbRadioButton.Controls.Add(this.lbRadioButtonItem);
            this.gbRadioButton.Controls.Add(this.lbRadioButtonID);
            this.gbRadioButton.Controls.Add(this.tbRadioButtonID);
            this.gbRadioButton.Controls.Add(this.btnRadioButton);
            this.gbRadioButton.Location = new System.Drawing.Point(503, 479);
            this.gbRadioButton.Name = "gbRadioButton";
            this.gbRadioButton.Size = new System.Drawing.Size(280, 135);
            this.gbRadioButton.TabIndex = 36;
            this.gbRadioButton.TabStop = false;
            this.gbRadioButton.Text = "RadioButton";
            // 
            // cbparentNode
            // 
            this.cbparentNode.AutoSize = true;
            this.cbparentNode.Location = new System.Drawing.Point(19, 68);
            this.cbparentNode.Margin = new System.Windows.Forms.Padding(2);
            this.cbparentNode.Name = "cbparentNode";
            this.cbparentNode.Size = new System.Drawing.Size(120, 24);
            this.cbparentNode.TabIndex = 46;
            this.cbparentNode.Text = "parentNode";
            this.cbparentNode.UseVisualStyleBackColor = true;
            // 
            // tbRadioButtonItem
            // 
            this.tbRadioButtonItem.Location = new System.Drawing.Point(102, 101);
            this.tbRadioButtonItem.Margin = new System.Windows.Forms.Padding(2);
            this.tbRadioButtonItem.Name = "tbRadioButtonItem";
            this.tbRadioButtonItem.Size = new System.Drawing.Size(32, 29);
            this.tbRadioButtonItem.TabIndex = 44;
            this.tbRadioButtonItem.Text = "1";
            // 
            // lbRadioButtonItem
            // 
            this.lbRadioButtonItem.AutoSize = true;
            this.lbRadioButtonItem.Location = new System.Drawing.Point(15, 103);
            this.lbRadioButtonItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRadioButtonItem.Name = "lbRadioButtonItem";
            this.lbRadioButtonItem.Size = new System.Drawing.Size(89, 20);
            this.lbRadioButtonItem.TabIndex = 40;
            this.lbRadioButtonItem.Text = "SelectItem";
            // 
            // lbRadioButtonID
            // 
            this.lbRadioButtonID.AutoSize = true;
            this.lbRadioButtonID.Location = new System.Drawing.Point(15, 30);
            this.lbRadioButtonID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRadioButtonID.Name = "lbRadioButtonID";
            this.lbRadioButtonID.Size = new System.Drawing.Size(72, 20);
            this.lbRadioButtonID.TabIndex = 32;
            this.lbRadioButtonID.Text = "IDName";
            // 
            // tbRadioButtonID
            // 
            this.tbRadioButtonID.Location = new System.Drawing.Point(87, 28);
            this.tbRadioButtonID.Margin = new System.Windows.Forms.Padding(2);
            this.tbRadioButtonID.Name = "tbRadioButtonID";
            this.tbRadioButtonID.Size = new System.Drawing.Size(183, 29);
            this.tbRadioButtonID.TabIndex = 31;
            this.tbRadioButtonID.Text = "mssid1SeeEachOther";
            // 
            // btnRadioButton
            // 
            this.btnRadioButton.Location = new System.Drawing.Point(152, 68);
            this.btnRadioButton.Name = "btnRadioButton";
            this.btnRadioButton.Size = new System.Drawing.Size(118, 60);
            this.btnRadioButton.TabIndex = 30;
            this.btnRadioButton.Text = "RadioButton";
            this.btnRadioButton.UseVisualStyleBackColor = true;
            this.btnRadioButton.Click += new System.EventHandler(this.btnRadioButton_Click_1);
            // 
            // gbGetElementValue
            // 
            this.gbGetElementValue.Controls.Add(this.lbGetElementValue);
            this.gbGetElementValue.Controls.Add(this.tbGetElementValue);
            this.gbGetElementValue.Controls.Add(this.btnGetElementValue);
            this.gbGetElementValue.Location = new System.Drawing.Point(530, 146);
            this.gbGetElementValue.Margin = new System.Windows.Forms.Padding(2);
            this.gbGetElementValue.Name = "gbGetElementValue";
            this.gbGetElementValue.Padding = new System.Windows.Forms.Padding(2);
            this.gbGetElementValue.Size = new System.Drawing.Size(253, 120);
            this.gbGetElementValue.TabIndex = 35;
            this.gbGetElementValue.TabStop = false;
            this.gbGetElementValue.Text = "GetElementValue";
            // 
            // lbGetElementValue
            // 
            this.lbGetElementValue.AutoSize = true;
            this.lbGetElementValue.Location = new System.Drawing.Point(11, 31);
            this.lbGetElementValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbGetElementValue.Name = "lbGetElementValue";
            this.lbGetElementValue.Size = new System.Drawing.Size(72, 20);
            this.lbGetElementValue.TabIndex = 34;
            this.lbGetElementValue.Text = "IDName";
            // 
            // tbGetElementValue
            // 
            this.tbGetElementValue.Location = new System.Drawing.Point(83, 29);
            this.tbGetElementValue.Margin = new System.Windows.Forms.Padding(2);
            this.tbGetElementValue.Name = "tbGetElementValue";
            this.tbGetElementValue.Size = new System.Drawing.Size(154, 29);
            this.tbGetElementValue.TabIndex = 33;
            this.tbGetElementValue.Text = "internetStatus";
            // 
            // btnGetElementValue
            // 
            this.btnGetElementValue.Location = new System.Drawing.Point(78, 65);
            this.btnGetElementValue.Name = "btnGetElementValue";
            this.btnGetElementValue.Size = new System.Drawing.Size(110, 45);
            this.btnGetElementValue.TabIndex = 32;
            this.btnGetElementValue.Text = "GetValue";
            this.btnGetElementValue.UseVisualStyleBackColor = true;
            this.btnGetElementValue.Click += new System.EventHandler(this.btnGetElementValue_Click_1);
            // 
            // gbDropDownList
            // 
            this.gbDropDownList.Controls.Add(this.tbSelectItem);
            this.gbDropDownList.Controls.Add(this.lbSelectItem);
            this.gbDropDownList.Controls.Add(this.lbDropDownListName);
            this.gbDropDownList.Controls.Add(this.tbDropDownListName);
            this.gbDropDownList.Controls.Add(this.btnDropDownList);
            this.gbDropDownList.Location = new System.Drawing.Point(530, 14);
            this.gbDropDownList.Name = "gbDropDownList";
            this.gbDropDownList.Size = new System.Drawing.Size(253, 127);
            this.gbDropDownList.TabIndex = 31;
            this.gbDropDownList.TabStop = false;
            this.gbDropDownList.Text = "DropDownList";
            // 
            // tbSelectItem
            // 
            this.tbSelectItem.Location = new System.Drawing.Point(99, 71);
            this.tbSelectItem.Margin = new System.Windows.Forms.Padding(2);
            this.tbSelectItem.Name = "tbSelectItem";
            this.tbSelectItem.Size = new System.Drawing.Size(32, 29);
            this.tbSelectItem.TabIndex = 44;
            this.tbSelectItem.Text = "1";
            // 
            // lbSelectItem
            // 
            this.lbSelectItem.AutoSize = true;
            this.lbSelectItem.Location = new System.Drawing.Point(6, 75);
            this.lbSelectItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSelectItem.Name = "lbSelectItem";
            this.lbSelectItem.Size = new System.Drawing.Size(89, 20);
            this.lbSelectItem.TabIndex = 40;
            this.lbSelectItem.Text = "SelectItem";
            // 
            // lbDropDownListName
            // 
            this.lbDropDownListName.AutoSize = true;
            this.lbDropDownListName.Location = new System.Drawing.Point(6, 30);
            this.lbDropDownListName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDropDownListName.Name = "lbDropDownListName";
            this.lbDropDownListName.Size = new System.Drawing.Size(72, 20);
            this.lbDropDownListName.TabIndex = 32;
            this.lbDropDownListName.Text = "IDName";
            // 
            // tbDropDownListName
            // 
            this.tbDropDownListName.Location = new System.Drawing.Point(78, 26);
            this.tbDropDownListName.Margin = new System.Windows.Forms.Padding(2);
            this.tbDropDownListName.Name = "tbDropDownListName";
            this.tbDropDownListName.Size = new System.Drawing.Size(160, 29);
            this.tbDropDownListName.TabIndex = 31;
            this.tbDropDownListName.Text = "_mssid1Sec";
            // 
            // btnDropDownList
            // 
            this.btnDropDownList.Location = new System.Drawing.Point(139, 61);
            this.btnDropDownList.Name = "btnDropDownList";
            this.btnDropDownList.Size = new System.Drawing.Size(104, 48);
            this.btnDropDownList.TabIndex = 30;
            this.btnDropDownList.Text = "DropDown";
            this.btnDropDownList.UseVisualStyleBackColor = true;
            this.btnDropDownList.Click += new System.EventHandler(this.btnDropDownList_Click);
            // 
            // gbSwitchButtonClick
            // 
            this.gbSwitchButtonClick.Controls.Add(this.tbSwitchButtonClassIndex);
            this.gbSwitchButtonClick.Controls.Add(this.lbSwitchButtonClassIndex);
            this.gbSwitchButtonClick.Controls.Add(this.lbSwitchButtonClick);
            this.gbSwitchButtonClick.Controls.Add(this.tbSwitchButtonClick);
            this.gbSwitchButtonClick.Controls.Add(this.btnSwitchButtonClick);
            this.gbSwitchButtonClick.Location = new System.Drawing.Point(268, 350);
            this.gbSwitchButtonClick.Margin = new System.Windows.Forms.Padding(2);
            this.gbSwitchButtonClick.Name = "gbSwitchButtonClick";
            this.gbSwitchButtonClick.Padding = new System.Windows.Forms.Padding(2);
            this.gbSwitchButtonClick.Size = new System.Drawing.Size(191, 195);
            this.gbSwitchButtonClick.TabIndex = 29;
            this.gbSwitchButtonClick.TabStop = false;
            this.gbSwitchButtonClick.Text = "SwitchButtonClick";
            // 
            // tbSwitchButtonClassIndex
            // 
            this.tbSwitchButtonClassIndex.Location = new System.Drawing.Point(97, 99);
            this.tbSwitchButtonClassIndex.Margin = new System.Windows.Forms.Padding(2);
            this.tbSwitchButtonClassIndex.Name = "tbSwitchButtonClassIndex";
            this.tbSwitchButtonClassIndex.Size = new System.Drawing.Size(34, 29);
            this.tbSwitchButtonClassIndex.TabIndex = 37;
            this.tbSwitchButtonClassIndex.Text = "0";
            // 
            // lbSwitchButtonClassIndex
            // 
            this.lbSwitchButtonClassIndex.AutoSize = true;
            this.lbSwitchButtonClassIndex.Location = new System.Drawing.Point(4, 102);
            this.lbSwitchButtonClassIndex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSwitchButtonClassIndex.Name = "lbSwitchButtonClassIndex";
            this.lbSwitchButtonClassIndex.Size = new System.Drawing.Size(89, 20);
            this.lbSwitchButtonClassIndex.TabIndex = 36;
            this.lbSwitchButtonClassIndex.Text = "ClassIndex";
            // 
            // lbSwitchButtonClick
            // 
            this.lbSwitchButtonClick.AutoSize = true;
            this.lbSwitchButtonClick.Location = new System.Drawing.Point(4, 33);
            this.lbSwitchButtonClick.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSwitchButtonClick.Name = "lbSwitchButtonClick";
            this.lbSwitchButtonClick.Size = new System.Drawing.Size(172, 20);
            this.lbSwitchButtonClick.TabIndex = 28;
            this.lbSwitchButtonClick.Text = "SwitchBtn ClassName";
            // 
            // tbSwitchButtonClick
            // 
            this.tbSwitchButtonClick.Location = new System.Drawing.Point(8, 64);
            this.tbSwitchButtonClick.Margin = new System.Windows.Forms.Padding(2);
            this.tbSwitchButtonClick.Name = "tbSwitchButtonClick";
            this.tbSwitchButtonClick.Size = new System.Drawing.Size(168, 29);
            this.tbSwitchButtonClick.TabIndex = 27;
            this.tbSwitchButtonClick.Text = "button-group-cover";
            // 
            // btnSwitchButtonClick
            // 
            this.btnSwitchButtonClick.Location = new System.Drawing.Point(44, 133);
            this.btnSwitchButtonClick.Name = "btnSwitchButtonClick";
            this.btnSwitchButtonClick.Size = new System.Drawing.Size(103, 48);
            this.btnSwitchButtonClick.TabIndex = 26;
            this.btnSwitchButtonClick.Text = "Switch";
            this.btnSwitchButtonClick.UseVisualStyleBackColor = true;
            this.btnSwitchButtonClick.Click += new System.EventHandler(this.btnSwitchButtonClick_Click);
            // 
            // gbScrollElement
            // 
            this.gbScrollElement.Controls.Add(this.tbClassIndex);
            this.gbScrollElement.Controls.Add(this.lbClassIndex);
            this.gbScrollElement.Controls.Add(this.lbElementType);
            this.gbScrollElement.Controls.Add(this.btnScrollElementLeft);
            this.gbScrollElement.Controls.Add(this.label6);
            this.gbScrollElement.Controls.Add(this.btnScrollElementRight);
            this.gbScrollElement.Controls.Add(this.btnScrollElementDown);
            this.gbScrollElement.Controls.Add(this.tbMovedPixels);
            this.gbScrollElement.Controls.Add(this.lbMovedPixels);
            this.gbScrollElement.Controls.Add(this.lbScrollElement);
            this.gbScrollElement.Controls.Add(this.tbScrollElement);
            this.gbScrollElement.Controls.Add(this.btnScrollElementUp);
            this.gbScrollElement.Controls.Add(this.label3);
            this.gbScrollElement.Controls.Add(this.label4);
            this.gbScrollElement.Controls.Add(this.label5);
            this.gbScrollElement.Controls.Add(this.clbScrollElement);
            this.gbScrollElement.Location = new System.Drawing.Point(268, 14);
            this.gbScrollElement.Margin = new System.Windows.Forms.Padding(2);
            this.gbScrollElement.Name = "gbScrollElement";
            this.gbScrollElement.Padding = new System.Windows.Forms.Padding(2);
            this.gbScrollElement.Size = new System.Drawing.Size(249, 332);
            this.gbScrollElement.TabIndex = 21;
            this.gbScrollElement.TabStop = false;
            this.gbScrollElement.Text = "ScrollElement";
            // 
            // tbClassIndex
            // 
            this.tbClassIndex.Location = new System.Drawing.Point(164, 80);
            this.tbClassIndex.Margin = new System.Windows.Forms.Padding(2);
            this.tbClassIndex.Name = "tbClassIndex";
            this.tbClassIndex.Size = new System.Drawing.Size(34, 29);
            this.tbClassIndex.TabIndex = 35;
            this.tbClassIndex.Text = "0";
            // 
            // lbClassIndex
            // 
            this.lbClassIndex.AutoSize = true;
            this.lbClassIndex.Location = new System.Drawing.Point(160, 57);
            this.lbClassIndex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbClassIndex.Name = "lbClassIndex";
            this.lbClassIndex.Size = new System.Drawing.Size(89, 20);
            this.lbClassIndex.TabIndex = 34;
            this.lbClassIndex.Text = "ClassIndex";
            // 
            // lbElementType
            // 
            this.lbElementType.AutoSize = true;
            this.lbElementType.Location = new System.Drawing.Point(4, 107);
            this.lbElementType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbElementType.Name = "lbElementType";
            this.lbElementType.Size = new System.Drawing.Size(107, 20);
            this.lbElementType.TabIndex = 33;
            this.lbElementType.Text = "ElementType";
            // 
            // btnScrollElementLeft
            // 
            this.btnScrollElementLeft.Location = new System.Drawing.Point(13, 206);
            this.btnScrollElementLeft.Name = "btnScrollElementLeft";
            this.btnScrollElementLeft.Size = new System.Drawing.Size(57, 49);
            this.btnScrollElementLeft.TabIndex = 27;
            this.btnScrollElementLeft.Text = "Left";
            this.btnScrollElementLeft.UseVisualStyleBackColor = true;
            this.btnScrollElementLeft.Click += new System.EventHandler(this.btnScrollElement_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(70, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 40);
            this.label6.TabIndex = 31;
            this.label6.Text = "⬅";
            // 
            // btnScrollElementRight
            // 
            this.btnScrollElementRight.Location = new System.Drawing.Point(161, 206);
            this.btnScrollElementRight.Name = "btnScrollElementRight";
            this.btnScrollElementRight.Size = new System.Drawing.Size(60, 49);
            this.btnScrollElementRight.TabIndex = 26;
            this.btnScrollElementRight.Text = "Right";
            this.btnScrollElementRight.UseVisualStyleBackColor = true;
            this.btnScrollElementRight.Click += new System.EventHandler(this.btnScrollElement_Click);
            // 
            // btnScrollElementDown
            // 
            this.btnScrollElementDown.Location = new System.Drawing.Point(86, 270);
            this.btnScrollElementDown.Name = "btnScrollElementDown";
            this.btnScrollElementDown.Size = new System.Drawing.Size(62, 49);
            this.btnScrollElementDown.TabIndex = 25;
            this.btnScrollElementDown.Text = "Down";
            this.btnScrollElementDown.UseVisualStyleBackColor = true;
            this.btnScrollElementDown.Click += new System.EventHandler(this.btnScrollElement_Click);
            // 
            // tbMovedPixels
            // 
            this.tbMovedPixels.Location = new System.Drawing.Point(106, 65);
            this.tbMovedPixels.Margin = new System.Windows.Forms.Padding(2);
            this.tbMovedPixels.Name = "tbMovedPixels";
            this.tbMovedPixels.Size = new System.Drawing.Size(42, 29);
            this.tbMovedPixels.TabIndex = 24;
            this.tbMovedPixels.Text = "50";
            // 
            // lbMovedPixels
            // 
            this.lbMovedPixels.AutoSize = true;
            this.lbMovedPixels.Location = new System.Drawing.Point(4, 67);
            this.lbMovedPixels.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMovedPixels.Name = "lbMovedPixels";
            this.lbMovedPixels.Size = new System.Drawing.Size(103, 20);
            this.lbMovedPixels.TabIndex = 23;
            this.lbMovedPixels.Text = "MovedPixels";
            // 
            // lbScrollElement
            // 
            this.lbScrollElement.AutoSize = true;
            this.lbScrollElement.Location = new System.Drawing.Point(4, 29);
            this.lbScrollElement.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbScrollElement.Name = "lbScrollElement";
            this.lbScrollElement.Size = new System.Drawing.Size(55, 20);
            this.lbScrollElement.TabIndex = 22;
            this.lbScrollElement.Text = "Name";
            // 
            // tbScrollElement
            // 
            this.tbScrollElement.Location = new System.Drawing.Point(61, 26);
            this.tbScrollElement.Margin = new System.Windows.Forms.Padding(2);
            this.tbScrollElement.Name = "tbScrollElement";
            this.tbScrollElement.Size = new System.Drawing.Size(175, 29);
            this.tbScrollElement.TabIndex = 21;
            this.tbScrollElement.Text = "scroll";
            // 
            // btnScrollElementUp
            // 
            this.btnScrollElementUp.Location = new System.Drawing.Point(85, 148);
            this.btnScrollElementUp.Name = "btnScrollElementUp";
            this.btnScrollElementUp.Size = new System.Drawing.Size(62, 49);
            this.btnScrollElementUp.TabIndex = 20;
            this.btnScrollElementUp.Text = "Up";
            this.btnScrollElementUp.UseVisualStyleBackColor = true;
            this.btnScrollElementUp.Click += new System.EventHandler(this.btnScrollElement_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(94, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 40);
            this.label3.TabIndex = 28;
            this.label3.Text = " ⬆";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(94, 228);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 40);
            this.label4.TabIndex = 29;
            this.label4.Text = " ⬇";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(116, 211);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 40);
            this.label5.TabIndex = 30;
            this.label5.Text = " ➞";
            // 
            // clbScrollElement
            // 
            this.clbScrollElement.ForeColor = System.Drawing.SystemColors.MenuText;
            this.clbScrollElement.FormattingEnabled = true;
            this.clbScrollElement.ImeMode = System.Windows.Forms.ImeMode.On;
            this.clbScrollElement.Items.AddRange(new object[] {
            "Id",
            "Class"});
            this.clbScrollElement.Location = new System.Drawing.Point(10, 135);
            this.clbScrollElement.Margin = new System.Windows.Forms.Padding(2);
            this.clbScrollElement.MultiColumn = true;
            this.clbScrollElement.Name = "clbScrollElement";
            this.clbScrollElement.Size = new System.Drawing.Size(70, 52);
            this.clbScrollElement.TabIndex = 32;
            this.clbScrollElement.SelectedIndexChanged += new System.EventHandler(this.clbScrollElement_SelectedIndexChanged);
            // 
            // gpButtonClick
            // 
            this.gpButtonClick.Controls.Add(this.tbClassIndexButtonClick);
            this.gpButtonClick.Controls.Add(this.lbClassIndexButtonClick);
            this.gpButtonClick.Controls.Add(this.cbButtonClick);
            this.gpButtonClick.Controls.Add(this.label2);
            this.gpButtonClick.Controls.Add(this.tbButtonClick);
            this.gpButtonClick.Controls.Add(this.btnButtonClick);
            this.gpButtonClick.Location = new System.Drawing.Point(12, 454);
            this.gpButtonClick.Margin = new System.Windows.Forms.Padding(2);
            this.gpButtonClick.Name = "gpButtonClick";
            this.gpButtonClick.Padding = new System.Windows.Forms.Padding(2);
            this.gpButtonClick.Size = new System.Drawing.Size(245, 146);
            this.gpButtonClick.TabIndex = 16;
            this.gpButtonClick.TabStop = false;
            this.gpButtonClick.Text = "ButtonClick";
            // 
            // tbClassIndexButtonClick
            // 
            this.tbClassIndexButtonClick.Location = new System.Drawing.Point(194, 24);
            this.tbClassIndexButtonClick.Margin = new System.Windows.Forms.Padding(2);
            this.tbClassIndexButtonClick.Name = "tbClassIndexButtonClick";
            this.tbClassIndexButtonClick.Size = new System.Drawing.Size(34, 29);
            this.tbClassIndexButtonClick.TabIndex = 39;
            this.tbClassIndexButtonClick.Text = "0";
            // 
            // lbClassIndexButtonClick
            // 
            this.lbClassIndexButtonClick.AutoSize = true;
            this.lbClassIndexButtonClick.Location = new System.Drawing.Point(100, 27);
            this.lbClassIndexButtonClick.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbClassIndexButtonClick.Name = "lbClassIndexButtonClick";
            this.lbClassIndexButtonClick.Size = new System.Drawing.Size(89, 20);
            this.lbClassIndexButtonClick.TabIndex = 38;
            this.lbClassIndexButtonClick.Text = "ClassIndex";
            // 
            // cbButtonClick
            // 
            this.cbButtonClick.FormattingEnabled = true;
            this.cbButtonClick.Items.AddRange(new object[] {
            "Id",
            "Name",
            "XPath",
            "ClassName"});
            this.cbButtonClick.Location = new System.Drawing.Point(8, 25);
            this.cbButtonClick.Margin = new System.Windows.Forms.Padding(2);
            this.cbButtonClick.Name = "cbButtonClick";
            this.cbButtonClick.Size = new System.Drawing.Size(80, 28);
            this.cbButtonClick.TabIndex = 20;
            this.cbButtonClick.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Btn ID";
            // 
            // tbButtonClick
            // 
            this.tbButtonClick.Location = new System.Drawing.Point(67, 58);
            this.tbButtonClick.Margin = new System.Windows.Forms.Padding(2);
            this.tbButtonClick.Name = "tbButtonClick";
            this.tbButtonClick.Size = new System.Drawing.Size(162, 29);
            this.tbButtonClick.TabIndex = 10;
            this.tbButtonClick.Text = "pc-login-btn";
            // 
            // btnButtonClick
            // 
            this.btnButtonClick.Location = new System.Drawing.Point(47, 92);
            this.btnButtonClick.Name = "btnButtonClick";
            this.btnButtonClick.Size = new System.Drawing.Size(127, 45);
            this.btnButtonClick.TabIndex = 8;
            this.btnButtonClick.Text = "Click";
            this.btnButtonClick.UseVisualStyleBackColor = true;
            this.btnButtonClick.Click += new System.EventHandler(this.btnButtonClick_Click);
            // 
            // gbKeyIn
            // 
            this.gbKeyIn.Controls.Add(this.tbIDSendKey);
            this.gbKeyIn.Controls.Add(this.lbIDSendKey);
            this.gbKeyIn.Controls.Add(this.lbKeyIn);
            this.gbKeyIn.Controls.Add(this.tbSendKey);
            this.gbKeyIn.Controls.Add(this.btnSendKeys);
            this.gbKeyIn.Location = new System.Drawing.Point(12, 315);
            this.gbKeyIn.Margin = new System.Windows.Forms.Padding(2);
            this.gbKeyIn.Name = "gbKeyIn";
            this.gbKeyIn.Padding = new System.Windows.Forms.Padding(2);
            this.gbKeyIn.Size = new System.Drawing.Size(245, 137);
            this.gbKeyIn.TabIndex = 15;
            this.gbKeyIn.TabStop = false;
            this.gbKeyIn.Text = "KeyIn";
            // 
            // tbIDSendKey
            // 
            this.tbIDSendKey.Location = new System.Drawing.Point(63, 25);
            this.tbIDSendKey.Margin = new System.Windows.Forms.Padding(2);
            this.tbIDSendKey.Name = "tbIDSendKey";
            this.tbIDSendKey.Size = new System.Drawing.Size(169, 29);
            this.tbIDSendKey.TabIndex = 16;
            this.tbIDSendKey.Text = "pc-login-password";
            // 
            // lbIDSendKey
            // 
            this.lbIDSendKey.AutoSize = true;
            this.lbIDSendKey.Location = new System.Drawing.Point(8, 27);
            this.lbIDSendKey.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbIDSendKey.Name = "lbIDSendKey";
            this.lbIDSendKey.Size = new System.Drawing.Size(24, 20);
            this.lbIDSendKey.TabIndex = 15;
            this.lbIDSendKey.Text = "Id";
            // 
            // lbKeyIn
            // 
            this.lbKeyIn.AutoSize = true;
            this.lbKeyIn.Location = new System.Drawing.Point(8, 58);
            this.lbKeyIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbKeyIn.Name = "lbKeyIn";
            this.lbKeyIn.Size = new System.Drawing.Size(54, 20);
            this.lbKeyIn.TabIndex = 14;
            this.lbKeyIn.Text = "String";
            // 
            // tbSendKey
            // 
            this.tbSendKey.Location = new System.Drawing.Point(63, 55);
            this.tbSendKey.Margin = new System.Windows.Forms.Padding(2);
            this.tbSendKey.Name = "tbSendKey";
            this.tbSendKey.Size = new System.Drawing.Size(169, 29);
            this.tbSendKey.TabIndex = 10;
            this.tbSendKey.Text = "StevenUniverse";
            // 
            // btnSendKeys
            // 
            this.btnSendKeys.Location = new System.Drawing.Point(47, 87);
            this.btnSendKeys.Name = "btnSendKeys";
            this.btnSendKeys.Size = new System.Drawing.Size(127, 45);
            this.btnSendKeys.TabIndex = 8;
            this.btnSendKeys.Text = "SendKeys";
            this.btnSendKeys.UseVisualStyleBackColor = true;
            this.btnSendKeys.Click += new System.EventHandler(this.SendKeys_Click);
            // 
            // gbFindElement
            // 
            this.gbFindElement.Controls.Add(this.label1);
            this.gbFindElement.Controls.Add(this.cbFindElement);
            this.gbFindElement.Controls.Add(this.tbFindElement);
            this.gbFindElement.Controls.Add(this.btnFindElement);
            this.gbFindElement.Location = new System.Drawing.Point(12, 142);
            this.gbFindElement.Margin = new System.Windows.Forms.Padding(2);
            this.gbFindElement.Name = "gbFindElement";
            this.gbFindElement.Padding = new System.Windows.Forms.Padding(2);
            this.gbFindElement.Size = new System.Drawing.Size(245, 169);
            this.gbFindElement.TabIndex = 14;
            this.gbFindElement.TabStop = false;
            this.gbFindElement.Text = "FindElement";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Target";
            // 
            // cbFindElement
            // 
            this.cbFindElement.FormattingEnabled = true;
            this.cbFindElement.Items.AddRange(new object[] {
            "Id",
            "Name",
            "XPath",
            "ClassName"});
            this.cbFindElement.Location = new System.Drawing.Point(7, 29);
            this.cbFindElement.Margin = new System.Windows.Forms.Padding(2);
            this.cbFindElement.Name = "cbFindElement";
            this.cbFindElement.Size = new System.Drawing.Size(167, 28);
            this.cbFindElement.TabIndex = 19;
            this.cbFindElement.Text = "Id";
            // 
            // tbFindElement
            // 
            this.tbFindElement.Location = new System.Drawing.Point(63, 67);
            this.tbFindElement.Margin = new System.Windows.Forms.Padding(2);
            this.tbFindElement.Name = "tbFindElement";
            this.tbFindElement.Size = new System.Drawing.Size(169, 29);
            this.tbFindElement.TabIndex = 9;
            this.tbFindElement.Text = "pc-login-password";
            // 
            // btnFindElement
            // 
            this.btnFindElement.Location = new System.Drawing.Point(47, 107);
            this.btnFindElement.Name = "btnFindElement";
            this.btnFindElement.Size = new System.Drawing.Size(127, 49);
            this.btnFindElement.TabIndex = 7;
            this.btnFindElement.Text = "FindElement";
            this.btnFindElement.UseVisualStyleBackColor = true;
            this.btnFindElement.Click += new System.EventHandler(this.FindElement_Click);
            // 
            // gbURL
            // 
            this.gbURL.Controls.Add(this.lbOpenURL);
            this.gbURL.Controls.Add(this.tbOpenURL);
            this.gbURL.Controls.Add(this.btnOpenURL);
            this.gbURL.Location = new System.Drawing.Point(12, 14);
            this.gbURL.Margin = new System.Windows.Forms.Padding(2);
            this.gbURL.Name = "gbURL";
            this.gbURL.Padding = new System.Windows.Forms.Padding(2);
            this.gbURL.Size = new System.Drawing.Size(245, 116);
            this.gbURL.TabIndex = 13;
            this.gbURL.TabStop = false;
            this.gbURL.Text = "URL";
            // 
            // lbOpenURL
            // 
            this.lbOpenURL.AutoSize = true;
            this.lbOpenURL.Location = new System.Drawing.Point(4, 29);
            this.lbOpenURL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOpenURL.Name = "lbOpenURL";
            this.lbOpenURL.Size = new System.Drawing.Size(39, 20);
            this.lbOpenURL.TabIndex = 12;
            this.lbOpenURL.Text = "URL";
            // 
            // tbOpenURL
            // 
            this.tbOpenURL.Location = new System.Drawing.Point(46, 26);
            this.tbOpenURL.Margin = new System.Windows.Forms.Padding(2);
            this.tbOpenURL.Name = "tbOpenURL";
            this.tbOpenURL.Size = new System.Drawing.Size(186, 29);
            this.tbOpenURL.TabIndex = 11;
            this.tbOpenURL.Text = "http://192.168.0.1/";
            // 
            // btnOpenURL
            // 
            this.btnOpenURL.Location = new System.Drawing.Point(47, 59);
            this.btnOpenURL.Name = "btnOpenURL";
            this.btnOpenURL.Size = new System.Drawing.Size(127, 49);
            this.btnOpenURL.TabIndex = 6;
            this.btnOpenURL.Text = "OpenURLTest";
            this.btnOpenURL.UseVisualStyleBackColor = true;
            this.btnOpenURL.Click += new System.EventHandler(this.OpenURLButton_Click);
            // 
            // tpFunctionTesting2
            // 
            this.tpFunctionTesting2.Controls.Add(this.button1);
            this.tpFunctionTesting2.Controls.Add(this.gbFunctionControl);
            this.tpFunctionTesting2.Controls.Add(this.gbWebRefresh);
            this.tpFunctionTesting2.Controls.Add(this.gbRestartDriver);
            this.tpFunctionTesting2.Controls.Add(this.gbSystemControl);
            this.tpFunctionTesting2.Controls.Add(this.gbAccount);
            this.tpFunctionTesting2.Controls.Add(this.gbConnectWiFi);
            this.tpFunctionTesting2.Controls.Add(this.gbSettingNetworkInterface);
            this.tpFunctionTesting2.Location = new System.Drawing.Point(4, 44);
            this.tpFunctionTesting2.Margin = new System.Windows.Forms.Padding(2);
            this.tpFunctionTesting2.Name = "tpFunctionTesting2";
            this.tpFunctionTesting2.Size = new System.Drawing.Size(788, 616);
            this.tpFunctionTesting2.TabIndex = 5;
            this.tpFunctionTesting2.Text = "部件功能 II";
            this.tpFunctionTesting2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 48);
            this.button1.TabIndex = 39;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gbFunctionControl
            // 
            this.gbFunctionControl.Controls.Add(this.gbPageChanging);
            this.gbFunctionControl.Location = new System.Drawing.Point(296, 9);
            this.gbFunctionControl.Name = "gbFunctionControl";
            this.gbFunctionControl.Size = new System.Drawing.Size(189, 319);
            this.gbFunctionControl.TabIndex = 38;
            this.gbFunctionControl.TabStop = false;
            this.gbFunctionControl.Text = "Function";
            // 
            // gbPageChanging
            // 
            this.gbPageChanging.Controls.Add(this.lbTopPageIndex);
            this.gbPageChanging.Controls.Add(this.tbTopPageIndex);
            this.gbPageChanging.Controls.Add(this.tbChildrenPageName);
            this.gbPageChanging.Controls.Add(this.lbChildrenPageName);
            this.gbPageChanging.Controls.Add(this.lbParentPageID);
            this.gbPageChanging.Controls.Add(this.tblbParentPageID);
            this.gbPageChanging.Controls.Add(this.btnMovePage);
            this.gbPageChanging.Location = new System.Drawing.Point(12, 28);
            this.gbPageChanging.Name = "gbPageChanging";
            this.gbPageChanging.Size = new System.Drawing.Size(162, 285);
            this.gbPageChanging.TabIndex = 31;
            this.gbPageChanging.TabStop = false;
            this.gbPageChanging.Text = "PageChanging";
            // 
            // lbTopPageIndex
            // 
            this.lbTopPageIndex.AutoSize = true;
            this.lbTopPageIndex.Location = new System.Drawing.Point(5, 32);
            this.lbTopPageIndex.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTopPageIndex.Name = "lbTopPageIndex";
            this.lbTopPageIndex.Size = new System.Drawing.Size(118, 20);
            this.lbTopPageIndex.TabIndex = 45;
            this.lbTopPageIndex.Text = "TopPageIndex";
            // 
            // tbTopPageIndex
            // 
            this.tbTopPageIndex.Location = new System.Drawing.Point(9, 53);
            this.tbTopPageIndex.Margin = new System.Windows.Forms.Padding(2);
            this.tbTopPageIndex.Name = "tbTopPageIndex";
            this.tbTopPageIndex.Size = new System.Drawing.Size(30, 29);
            this.tbTopPageIndex.TabIndex = 44;
            this.tbTopPageIndex.Text = "2";
            // 
            // tbChildrenPageName
            // 
            this.tbChildrenPageName.Location = new System.Drawing.Point(9, 182);
            this.tbChildrenPageName.Margin = new System.Windows.Forms.Padding(2);
            this.tbChildrenPageName.Name = "tbChildrenPageName";
            this.tbChildrenPageName.Size = new System.Drawing.Size(133, 29);
            this.tbChildrenPageName.TabIndex = 43;
            this.tbChildrenPageName.Text = "Multi-SSID";
            // 
            // lbChildrenPageName
            // 
            this.lbChildrenPageName.AutoSize = true;
            this.lbChildrenPageName.Location = new System.Drawing.Point(5, 160);
            this.lbChildrenPageName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbChildrenPageName.Name = "lbChildrenPageName";
            this.lbChildrenPageName.Size = new System.Drawing.Size(157, 20);
            this.lbChildrenPageName.TabIndex = 42;
            this.lbChildrenPageName.Text = "ChildrenPageName";
            // 
            // lbParentPageID
            // 
            this.lbParentPageID.AutoSize = true;
            this.lbParentPageID.Location = new System.Drawing.Point(5, 95);
            this.lbParentPageID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbParentPageID.Name = "lbParentPageID";
            this.lbParentPageID.Size = new System.Drawing.Size(114, 20);
            this.lbParentPageID.TabIndex = 41;
            this.lbParentPageID.Text = "ParentPageID";
            // 
            // tblbParentPageID
            // 
            this.tblbParentPageID.Location = new System.Drawing.Point(9, 116);
            this.tblbParentPageID.Margin = new System.Windows.Forms.Padding(2);
            this.tblbParentPageID.Name = "tblbParentPageID";
            this.tblbParentPageID.Size = new System.Drawing.Size(133, 29);
            this.tblbParentPageID.TabIndex = 40;
            this.tblbParentPageID.Text = "wireless";
            // 
            // btnMovePage
            // 
            this.btnMovePage.Location = new System.Drawing.Point(9, 226);
            this.btnMovePage.Name = "btnMovePage";
            this.btnMovePage.Size = new System.Drawing.Size(133, 48);
            this.btnMovePage.TabIndex = 30;
            this.btnMovePage.Text = "MovePage";
            this.btnMovePage.UseVisualStyleBackColor = true;
            this.btnMovePage.Click += new System.EventHandler(this.btnMovePage_Click);
            // 
            // gbWebRefresh
            // 
            this.gbWebRefresh.Controls.Add(this.btnWebRefresh);
            this.gbWebRefresh.Location = new System.Drawing.Point(625, 520);
            this.gbWebRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.gbWebRefresh.Name = "gbWebRefresh";
            this.gbWebRefresh.Padding = new System.Windows.Forms.Padding(2);
            this.gbWebRefresh.Size = new System.Drawing.Size(150, 91);
            this.gbWebRefresh.TabIndex = 37;
            this.gbWebRefresh.TabStop = false;
            this.gbWebRefresh.Text = "WebRefresh";
            // 
            // btnWebRefresh
            // 
            this.btnWebRefresh.Location = new System.Drawing.Point(12, 27);
            this.btnWebRefresh.Name = "btnWebRefresh";
            this.btnWebRefresh.Size = new System.Drawing.Size(127, 49);
            this.btnWebRefresh.TabIndex = 17;
            this.btnWebRefresh.Text = "WebRefresh";
            this.btnWebRefresh.UseVisualStyleBackColor = true;
            this.btnWebRefresh.Click += new System.EventHandler(this.btnWebRefresh_Click_1);
            // 
            // gbRestartDriver
            // 
            this.gbRestartDriver.Controls.Add(this.btnRestartDriver);
            this.gbRestartDriver.Location = new System.Drawing.Point(625, 424);
            this.gbRestartDriver.Margin = new System.Windows.Forms.Padding(2);
            this.gbRestartDriver.Name = "gbRestartDriver";
            this.gbRestartDriver.Padding = new System.Windows.Forms.Padding(2);
            this.gbRestartDriver.Size = new System.Drawing.Size(150, 91);
            this.gbRestartDriver.TabIndex = 36;
            this.gbRestartDriver.TabStop = false;
            this.gbRestartDriver.Text = "RestartDriver";
            // 
            // btnRestartDriver
            // 
            this.btnRestartDriver.Location = new System.Drawing.Point(12, 27);
            this.btnRestartDriver.Name = "btnRestartDriver";
            this.btnRestartDriver.Size = new System.Drawing.Size(127, 49);
            this.btnRestartDriver.TabIndex = 17;
            this.btnRestartDriver.Text = "RestartDriver";
            this.btnRestartDriver.UseVisualStyleBackColor = true;
            this.btnRestartDriver.Click += new System.EventHandler(this.btnRestartDriver_Click_1);
            // 
            // gbSystemControl
            // 
            this.gbSystemControl.Controls.Add(this.btnReboot);
            this.gbSystemControl.Controls.Add(this.btnFactoryRestore);
            this.gbSystemControl.Controls.Add(this.btnBackup);
            this.gbSystemControl.Controls.Add(this.btnBackupRestore);
            this.gbSystemControl.Controls.Add(this.btnLocalUpgrade);
            this.gbSystemControl.Location = new System.Drawing.Point(156, 9);
            this.gbSystemControl.Name = "gbSystemControl";
            this.gbSystemControl.Size = new System.Drawing.Size(134, 319);
            this.gbSystemControl.TabIndex = 35;
            this.gbSystemControl.TabStop = false;
            this.gbSystemControl.Text = "System";
            // 
            // btnReboot
            // 
            this.btnReboot.Location = new System.Drawing.Point(12, 254);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(110, 48);
            this.btnReboot.TabIndex = 34;
            this.btnReboot.Text = "Reboot";
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.btnReboot_Click);
            // 
            // btnFactoryRestore
            // 
            this.btnFactoryRestore.Location = new System.Drawing.Point(12, 199);
            this.btnFactoryRestore.Name = "btnFactoryRestore";
            this.btnFactoryRestore.Size = new System.Drawing.Size(110, 48);
            this.btnFactoryRestore.TabIndex = 33;
            this.btnFactoryRestore.Text = "Factory  Restore";
            this.btnFactoryRestore.UseVisualStyleBackColor = true;
            this.btnFactoryRestore.Click += new System.EventHandler(this.btnFactoryRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(12, 91);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(110, 48);
            this.btnBackup.TabIndex = 32;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnBackupRestore
            // 
            this.btnBackupRestore.Location = new System.Drawing.Point(12, 145);
            this.btnBackupRestore.Name = "btnBackupRestore";
            this.btnBackupRestore.Size = new System.Drawing.Size(110, 48);
            this.btnBackupRestore.TabIndex = 31;
            this.btnBackupRestore.Text = "Backup   Restore";
            this.btnBackupRestore.UseVisualStyleBackColor = true;
            this.btnBackupRestore.Click += new System.EventHandler(this.btnBackupRestore_Click);
            // 
            // btnLocalUpgrade
            // 
            this.btnLocalUpgrade.Location = new System.Drawing.Point(12, 37);
            this.btnLocalUpgrade.Name = "btnLocalUpgrade";
            this.btnLocalUpgrade.Size = new System.Drawing.Size(110, 48);
            this.btnLocalUpgrade.TabIndex = 30;
            this.btnLocalUpgrade.Text = "Local Upgrade";
            this.btnLocalUpgrade.UseVisualStyleBackColor = true;
            this.btnLocalUpgrade.Click += new System.EventHandler(this.btnLocalUpgrade_Click);
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.btnLoginWarning);
            this.gbAccount.Controls.Add(this.btnLoginStatus);
            this.gbAccount.Controls.Add(this.btnLogout);
            this.gbAccount.Controls.Add(this.btnLogin);
            this.gbAccount.Controls.Add(this.btnSettingPwd);
            this.gbAccount.Location = new System.Drawing.Point(10, 9);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Size = new System.Drawing.Size(140, 319);
            this.gbAccount.TabIndex = 34;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "Account";
            // 
            // btnLoginWarning
            // 
            this.btnLoginWarning.Location = new System.Drawing.Point(12, 254);
            this.btnLoginWarning.Name = "btnLoginWarning";
            this.btnLoginWarning.Size = new System.Drawing.Size(110, 48);
            this.btnLoginWarning.TabIndex = 34;
            this.btnLoginWarning.Text = "Warning";
            this.btnLoginWarning.UseVisualStyleBackColor = true;
            this.btnLoginWarning.Click += new System.EventHandler(this.btnLoginWarning_Click);
            // 
            // btnLoginStatus
            // 
            this.btnLoginStatus.Location = new System.Drawing.Point(12, 200);
            this.btnLoginStatus.Name = "btnLoginStatus";
            this.btnLoginStatus.Size = new System.Drawing.Size(110, 48);
            this.btnLoginStatus.TabIndex = 33;
            this.btnLoginStatus.Text = "LoginStatus";
            this.btnLoginStatus.UseVisualStyleBackColor = true;
            this.btnLoginStatus.Click += new System.EventHandler(this.btnLoginStatus_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(12, 146);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 48);
            this.btnLogout.TabIndex = 32;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 91);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 48);
            this.btnLogin.TabIndex = 31;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSettingPwd
            // 
            this.btnSettingPwd.Location = new System.Drawing.Point(12, 37);
            this.btnSettingPwd.Name = "btnSettingPwd";
            this.btnSettingPwd.Size = new System.Drawing.Size(110, 48);
            this.btnSettingPwd.TabIndex = 30;
            this.btnSettingPwd.Text = "PwdSetting";
            this.btnSettingPwd.UseVisualStyleBackColor = true;
            this.btnSettingPwd.Click += new System.EventHandler(this.btnSettingPwd_Click);
            // 
            // gbConnectWiFi
            // 
            this.gbConnectWiFi.Controls.Add(this.btnSaveWiFiInfo);
            this.gbConnectWiFi.Controls.Add(this.tbSsidPasswd);
            this.gbConnectWiFi.Controls.Add(this.lbSsidPasswd);
            this.gbConnectWiFi.Controls.Add(this.btnTurnOffWiFi);
            this.gbConnectWiFi.Controls.Add(this.lbWiFiName);
            this.gbConnectWiFi.Controls.Add(this.tbSsidiName);
            this.gbConnectWiFi.Controls.Add(this.btnTurnOnWiFi);
            this.gbConnectWiFi.Controls.Add(this.btnConnectWiFi);
            this.gbConnectWiFi.Location = new System.Drawing.Point(292, 333);
            this.gbConnectWiFi.Margin = new System.Windows.Forms.Padding(2);
            this.gbConnectWiFi.Name = "gbConnectWiFi";
            this.gbConnectWiFi.Padding = new System.Windows.Forms.Padding(2);
            this.gbConnectWiFi.Size = new System.Drawing.Size(178, 282);
            this.gbConnectWiFi.TabIndex = 18;
            this.gbConnectWiFi.TabStop = false;
            this.gbConnectWiFi.Text = "ConnectWiFi";
            // 
            // btnSaveWiFiInfo
            // 
            this.btnSaveWiFiInfo.Location = new System.Drawing.Point(10, 134);
            this.btnSaveWiFiInfo.Name = "btnSaveWiFiInfo";
            this.btnSaveWiFiInfo.Size = new System.Drawing.Size(156, 35);
            this.btnSaveWiFiInfo.TabIndex = 40;
            this.btnSaveWiFiInfo.Text = "Save";
            this.btnSaveWiFiInfo.UseVisualStyleBackColor = true;
            this.btnSaveWiFiInfo.Click += new System.EventHandler(this.btnSaveWiFiInfo_Click);
            // 
            // tbSsidPasswd
            // 
            this.tbSsidPasswd.Location = new System.Drawing.Point(10, 98);
            this.tbSsidPasswd.Margin = new System.Windows.Forms.Padding(2);
            this.tbSsidPasswd.Name = "tbSsidPasswd";
            this.tbSsidPasswd.Size = new System.Drawing.Size(157, 29);
            this.tbSsidPasswd.TabIndex = 39;
            this.tbSsidPasswd.Text = "admin1234";
            // 
            // lbSsidPasswd
            // 
            this.lbSsidPasswd.AutoSize = true;
            this.lbSsidPasswd.Location = new System.Drawing.Point(6, 78);
            this.lbSsidPasswd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSsidPasswd.Name = "lbSsidPasswd";
            this.lbSsidPasswd.Size = new System.Drawing.Size(98, 20);
            this.lbSsidPasswd.TabIndex = 38;
            this.lbSsidPasswd.Text = "Ssid Passwd";
            // 
            // btnTurnOffWiFi
            // 
            this.btnTurnOffWiFi.Location = new System.Drawing.Point(89, 226);
            this.btnTurnOffWiFi.Name = "btnTurnOffWiFi";
            this.btnTurnOffWiFi.Size = new System.Drawing.Size(76, 49);
            this.btnTurnOffWiFi.TabIndex = 37;
            this.btnTurnOffWiFi.Text = "TurnOffWiFi";
            this.btnTurnOffWiFi.UseVisualStyleBackColor = true;
            this.btnTurnOffWiFi.Click += new System.EventHandler(this.btnTurnOffWiFi_Click);
            // 
            // lbWiFiName
            // 
            this.lbWiFiName.AutoSize = true;
            this.lbWiFiName.Location = new System.Drawing.Point(6, 26);
            this.lbWiFiName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbWiFiName.Name = "lbWiFiName";
            this.lbWiFiName.Size = new System.Drawing.Size(89, 20);
            this.lbWiFiName.TabIndex = 36;
            this.lbWiFiName.Text = "Ssid Name";
            // 
            // tbSsidiName
            // 
            this.tbSsidiName.Location = new System.Drawing.Point(10, 47);
            this.tbSsidiName.Margin = new System.Windows.Forms.Padding(2);
            this.tbSsidiName.Name = "tbSsidiName";
            this.tbSsidiName.Size = new System.Drawing.Size(157, 29);
            this.tbSsidiName.TabIndex = 35;
            this.tbSsidiName.Text = "a_Stefen_Test_2.4G";
            // 
            // btnTurnOnWiFi
            // 
            this.btnTurnOnWiFi.Location = new System.Drawing.Point(89, 175);
            this.btnTurnOnWiFi.Name = "btnTurnOnWiFi";
            this.btnTurnOnWiFi.Size = new System.Drawing.Size(76, 49);
            this.btnTurnOnWiFi.TabIndex = 34;
            this.btnTurnOnWiFi.Text = "TurnOnWiFi";
            this.btnTurnOnWiFi.UseVisualStyleBackColor = true;
            this.btnTurnOnWiFi.Click += new System.EventHandler(this.btnTurnOnWiFi_Click);
            // 
            // btnConnectWiFi
            // 
            this.btnConnectWiFi.Location = new System.Drawing.Point(10, 175);
            this.btnConnectWiFi.Name = "btnConnectWiFi";
            this.btnConnectWiFi.Size = new System.Drawing.Size(74, 99);
            this.btnConnectWiFi.TabIndex = 33;
            this.btnConnectWiFi.Text = "ConnectWiFi";
            this.btnConnectWiFi.UseVisualStyleBackColor = true;
            this.btnConnectWiFi.Click += new System.EventHandler(this.btnConnectWiFi_Click);
            // 
            // gbSettingNetworkInterface
            // 
            this.gbSettingNetworkInterface.Controls.Add(this.tbInterfaceName);
            this.gbSettingNetworkInterface.Controls.Add(this.btnDisableInterface);
            this.gbSettingNetworkInterface.Controls.Add(this.btnEnableInterface);
            this.gbSettingNetworkInterface.Controls.Add(this.btnSetupToStaticIP);
            this.gbSettingNetworkInterface.Controls.Add(this.lbGateway);
            this.gbSettingNetworkInterface.Controls.Add(this.tbGateway);
            this.gbSettingNetworkInterface.Controls.Add(this.lbSubMesk);
            this.gbSettingNetworkInterface.Controls.Add(this.tbSubMesk);
            this.gbSettingNetworkInterface.Controls.Add(this.lbIPAddress);
            this.gbSettingNetworkInterface.Controls.Add(this.tbIPAddress);
            this.gbSettingNetworkInterface.Controls.Add(this.lbInterfaceName);
            this.gbSettingNetworkInterface.Controls.Add(this.btnSetupToDHCP);
            this.gbSettingNetworkInterface.Location = new System.Drawing.Point(10, 333);
            this.gbSettingNetworkInterface.Margin = new System.Windows.Forms.Padding(2);
            this.gbSettingNetworkInterface.Name = "gbSettingNetworkInterface";
            this.gbSettingNetworkInterface.Padding = new System.Windows.Forms.Padding(2);
            this.gbSettingNetworkInterface.Size = new System.Drawing.Size(278, 282);
            this.gbSettingNetworkInterface.TabIndex = 17;
            this.gbSettingNetworkInterface.TabStop = false;
            this.gbSettingNetworkInterface.Text = "SettingNetworkInterface";
            // 
            // tbInterfaceName
            // 
            this.tbInterfaceName.Location = new System.Drawing.Point(138, 28);
            this.tbInterfaceName.Margin = new System.Windows.Forms.Padding(2);
            this.tbInterfaceName.Name = "tbInterfaceName";
            this.tbInterfaceName.Size = new System.Drawing.Size(132, 29);
            this.tbInterfaceName.TabIndex = 13;
            this.tbInterfaceName.Text = "乙太網路 2";
            // 
            // btnDisableInterface
            // 
            this.btnDisableInterface.Location = new System.Drawing.Point(185, 218);
            this.btnDisableInterface.Name = "btnDisableInterface";
            this.btnDisableInterface.Size = new System.Drawing.Size(85, 49);
            this.btnDisableInterface.TabIndex = 33;
            this.btnDisableInterface.Text = "Disable Interface";
            this.btnDisableInterface.UseVisualStyleBackColor = true;
            this.btnDisableInterface.Click += new System.EventHandler(this.btnDisableInterface_Click);
            // 
            // btnEnableInterface
            // 
            this.btnEnableInterface.Location = new System.Drawing.Point(185, 163);
            this.btnEnableInterface.Name = "btnEnableInterface";
            this.btnEnableInterface.Size = new System.Drawing.Size(85, 49);
            this.btnEnableInterface.TabIndex = 32;
            this.btnEnableInterface.Text = "Enable  Interface";
            this.btnEnableInterface.UseVisualStyleBackColor = true;
            this.btnEnableInterface.Click += new System.EventHandler(this.btnEnableInterface_Click);
            // 
            // btnSetupToStaticIP
            // 
            this.btnSetupToStaticIP.Location = new System.Drawing.Point(98, 163);
            this.btnSetupToStaticIP.Name = "btnSetupToStaticIP";
            this.btnSetupToStaticIP.Size = new System.Drawing.Size(81, 104);
            this.btnSetupToStaticIP.TabIndex = 31;
            this.btnSetupToStaticIP.Text = "SetupToStaticIP";
            this.btnSetupToStaticIP.UseVisualStyleBackColor = true;
            this.btnSetupToStaticIP.Click += new System.EventHandler(this.btnSetupToStaticIP_Click);
            // 
            // lbGateway
            // 
            this.lbGateway.AutoSize = true;
            this.lbGateway.Location = new System.Drawing.Point(8, 127);
            this.lbGateway.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbGateway.Name = "lbGateway";
            this.lbGateway.Size = new System.Drawing.Size(74, 20);
            this.lbGateway.TabIndex = 30;
            this.lbGateway.Text = "Gateway";
            // 
            // tbGateway
            // 
            this.tbGateway.Location = new System.Drawing.Point(101, 125);
            this.tbGateway.Margin = new System.Windows.Forms.Padding(2);
            this.tbGateway.Name = "tbGateway";
            this.tbGateway.Size = new System.Drawing.Size(169, 29);
            this.tbGateway.TabIndex = 29;
            // 
            // lbSubMesk
            // 
            this.lbSubMesk.AutoSize = true;
            this.lbSubMesk.Location = new System.Drawing.Point(8, 94);
            this.lbSubMesk.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSubMesk.Name = "lbSubMesk";
            this.lbSubMesk.Size = new System.Drawing.Size(78, 20);
            this.lbSubMesk.TabIndex = 28;
            this.lbSubMesk.Text = "SubMesk";
            // 
            // tbSubMesk
            // 
            this.tbSubMesk.Location = new System.Drawing.Point(101, 91);
            this.tbSubMesk.Margin = new System.Windows.Forms.Padding(2);
            this.tbSubMesk.Name = "tbSubMesk";
            this.tbSubMesk.Size = new System.Drawing.Size(169, 29);
            this.tbSubMesk.TabIndex = 27;
            this.tbSubMesk.Text = "255.255.255.0";
            // 
            // lbIPAddress
            // 
            this.lbIPAddress.AutoSize = true;
            this.lbIPAddress.Location = new System.Drawing.Point(8, 62);
            this.lbIPAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbIPAddress.Name = "lbIPAddress";
            this.lbIPAddress.Size = new System.Drawing.Size(84, 20);
            this.lbIPAddress.TabIndex = 26;
            this.lbIPAddress.Text = "IPAddress";
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(101, 59);
            this.tbIPAddress.Margin = new System.Windows.Forms.Padding(2);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(169, 29);
            this.tbIPAddress.TabIndex = 25;
            this.tbIPAddress.Text = "192.168.0.119";
            // 
            // lbInterfaceName
            // 
            this.lbInterfaceName.AutoSize = true;
            this.lbInterfaceName.Location = new System.Drawing.Point(8, 31);
            this.lbInterfaceName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbInterfaceName.Name = "lbInterfaceName";
            this.lbInterfaceName.Size = new System.Drawing.Size(122, 20);
            this.lbInterfaceName.TabIndex = 24;
            this.lbInterfaceName.Text = "InterfaceName";
            // 
            // btnSetupToDHCP
            // 
            this.btnSetupToDHCP.Location = new System.Drawing.Point(12, 163);
            this.btnSetupToDHCP.Name = "btnSetupToDHCP";
            this.btnSetupToDHCP.Size = new System.Drawing.Size(80, 104);
            this.btnSetupToDHCP.TabIndex = 5;
            this.btnSetupToDHCP.Text = "SetupToDHCP";
            this.btnSetupToDHCP.UseVisualStyleBackColor = true;
            this.btnSetupToDHCP.Click += new System.EventHandler(this.button4_Click);
            // 
            // gbMessageShow
            // 
            this.gbMessageShow.BackColor = System.Drawing.Color.Transparent;
            this.gbMessageShow.Controls.Add(this.tbMessageShow);
            this.gbMessageShow.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.gbMessageShow.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.gbMessageShow.Location = new System.Drawing.Point(9, 23);
            this.gbMessageShow.Margin = new System.Windows.Forms.Padding(2);
            this.gbMessageShow.Name = "gbMessageShow";
            this.gbMessageShow.Padding = new System.Windows.Forms.Padding(2);
            this.gbMessageShow.Size = new System.Drawing.Size(400, 661);
            this.gbMessageShow.TabIndex = 6;
            this.gbMessageShow.TabStop = false;
            this.gbMessageShow.Text = "資料結果";
            // 
            // lbVersionNum
            // 
            this.lbVersionNum.AutoSize = true;
            this.lbVersionNum.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbVersionNum.Location = new System.Drawing.Point(1228, 642);
            this.lbVersionNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbVersionNum.Name = "lbVersionNum";
            this.lbVersionNum.Size = new System.Drawing.Size(103, 18);
            this.lbVersionNum.TabIndex = 7;
            this.lbVersionNum.Text = "Version 0.0.0.0";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.SkyBlue;
            this.btnStart.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(1222, 67);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(114, 89);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPause
            // 
            this.btnPause.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btnPause.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnPause.Location = new System.Drawing.Point(1222, 160);
            this.btnPause.Margin = new System.Windows.Forms.Padding(2);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(114, 89);
            this.btnPause.TabIndex = 9;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MediumPurple;
            this.btnClose.Font = new System.Drawing.Font("微軟正黑體", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClose.Location = new System.Drawing.Point(1222, 253);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 89);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbWANType_L2TP
            // 
            this.cbWANType_L2TP.AutoSize = true;
            this.cbWANType_L2TP.Location = new System.Drawing.Point(22, 162);
            this.cbWANType_L2TP.Name = "cbWANType_L2TP";
            this.cbWANType_L2TP.Size = new System.Drawing.Size(147, 24);
            this.cbWANType_L2TP.TabIndex = 3;
            this.cbWANType_L2TP.Text = "WANType_L2TP";
            this.cbWANType_L2TP.UseVisualStyleBackColor = true;
            // 
            // cbWANType_PPTP
            // 
            this.cbWANType_PPTP.AutoSize = true;
            this.cbWANType_PPTP.Location = new System.Drawing.Point(22, 193);
            this.cbWANType_PPTP.Name = "cbWANType_PPTP";
            this.cbWANType_PPTP.Size = new System.Drawing.Size(150, 24);
            this.cbWANType_PPTP.TabIndex = 4;
            this.cbWANType_PPTP.Text = "WANType_PPTP";
            this.cbWANType_PPTP.UseVisualStyleBackColor = true;
            // 
            // cbWANType_Bridge
            // 
            this.cbWANType_Bridge.AutoSize = true;
            this.cbWANType_Bridge.Location = new System.Drawing.Point(22, 131);
            this.cbWANType_Bridge.Name = "cbWANType_Bridge";
            this.cbWANType_Bridge.Size = new System.Drawing.Size(160, 24);
            this.cbWANType_Bridge.TabIndex = 5;
            this.cbWANType_Bridge.Text = "WANType_Bridge";
            this.cbWANType_Bridge.UseVisualStyleBackColor = true;
            // 
            // AutomatedWebTestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 692);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbVersionNum);
            this.Controls.Add(this.gbMessageShow);
            this.Controls.Add(this.tbMainMenu);
            this.Name = "AutomatedWebTestingForm";
            this.Text = "AutomatedTesting";
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.tbMainMenu.ResumeLayout(false);
            this.tpBasicFuntion.ResumeLayout(false);
            this.gbWANType.ResumeLayout(false);
            this.gbWANType.PerformLayout();
            this.tpFunctionTesting1.ResumeLayout(false);
            this.gbCheckBox.ResumeLayout(false);
            this.gbCheckBox.PerformLayout();
            this.gbRadioButton.ResumeLayout(false);
            this.gbRadioButton.PerformLayout();
            this.gbGetElementValue.ResumeLayout(false);
            this.gbGetElementValue.PerformLayout();
            this.gbDropDownList.ResumeLayout(false);
            this.gbDropDownList.PerformLayout();
            this.gbSwitchButtonClick.ResumeLayout(false);
            this.gbSwitchButtonClick.PerformLayout();
            this.gbScrollElement.ResumeLayout(false);
            this.gbScrollElement.PerformLayout();
            this.gpButtonClick.ResumeLayout(false);
            this.gpButtonClick.PerformLayout();
            this.gbKeyIn.ResumeLayout(false);
            this.gbKeyIn.PerformLayout();
            this.gbFindElement.ResumeLayout(false);
            this.gbFindElement.PerformLayout();
            this.gbURL.ResumeLayout(false);
            this.gbURL.PerformLayout();
            this.tpFunctionTesting2.ResumeLayout(false);
            this.gbFunctionControl.ResumeLayout(false);
            this.gbPageChanging.ResumeLayout(false);
            this.gbPageChanging.PerformLayout();
            this.gbWebRefresh.ResumeLayout(false);
            this.gbRestartDriver.ResumeLayout(false);
            this.gbSystemControl.ResumeLayout(false);
            this.gbAccount.ResumeLayout(false);
            this.gbConnectWiFi.ResumeLayout(false);
            this.gbConnectWiFi.PerformLayout();
            this.gbSettingNetworkInterface.ResumeLayout(false);
            this.gbSettingNetworkInterface.PerformLayout();
            this.gbMessageShow.ResumeLayout(false);
            this.gbMessageShow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tbMainMenu;
        public System.Windows.Forms.GroupBox gbMessageShow;
        public System.Windows.Forms.TextBox tbMessageShow;
        public System.Windows.Forms.TabPage tpFunctionTesting1;
        private System.Windows.Forms.Button btnSendKeys;
        private System.Windows.Forms.Button btnFindElement;
        private System.Windows.Forms.Button btnOpenURL;
        public System.Windows.Forms.Label lbVersionNum;
        private System.Windows.Forms.TextBox tbOpenURL;
        private System.Windows.Forms.TextBox tbSendKey;
        private System.Windows.Forms.TextBox tbFindElement;
        private System.Windows.Forms.Label lbOpenURL;
        private System.Windows.Forms.GroupBox gbURL;
        private System.Windows.Forms.GroupBox gbFindElement;
        private System.Windows.Forms.GroupBox gbKeyIn;
        private System.Windows.Forms.ComboBox cbFindElement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpButtonClick;
        private System.Windows.Forms.TextBox tbButtonClick;
        private System.Windows.Forms.Button btnButtonClick;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbKeyIn;
        private System.Windows.Forms.ComboBox cbButtonClick;
        private System.Windows.Forms.Button btnScrollElementUp;
        private System.Windows.Forms.GroupBox gbScrollElement;
        private System.Windows.Forms.Label lbScrollElement;
        private System.Windows.Forms.TextBox tbScrollElement;
        private System.Windows.Forms.TextBox tbMovedPixels;
        private System.Windows.Forms.Label lbMovedPixels;
        private System.Windows.Forms.Button btnScrollElementDown;
        private System.Windows.Forms.Button btnScrollElementLeft;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnScrollElementRight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckedListBox clbScrollElement;
        private System.Windows.Forms.Button btnSwitchButtonClick;
        private System.Windows.Forms.TextBox tbClassIndex;
        private System.Windows.Forms.Label lbClassIndex;
        private System.Windows.Forms.Label lbElementType;
        private System.Windows.Forms.GroupBox gbSwitchButtonClick;
        private System.Windows.Forms.Label lbSwitchButtonClick;
        private System.Windows.Forms.TextBox tbSwitchButtonClick;
        private System.Windows.Forms.TextBox tbSwitchButtonClassIndex;
        private System.Windows.Forms.Label lbSwitchButtonClassIndex;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbDropDownList;
        private System.Windows.Forms.Button btnDropDownList;
        private System.Windows.Forms.Label lbDropDownListName;
        private System.Windows.Forms.TextBox tbDropDownListName;
        private System.Windows.Forms.Label lbSelectItem;
        private System.Windows.Forms.TextBox tbSelectItem;
        private System.Windows.Forms.TextBox tbClassIndexButtonClick;
        private System.Windows.Forms.Label lbClassIndexButtonClick;
        private System.Windows.Forms.TabPage tpFunctionTesting2;
        private System.Windows.Forms.GroupBox gbGetElementValue;
        private System.Windows.Forms.Label lbGetElementValue;
        private System.Windows.Forms.TextBox tbGetElementValue;
        private System.Windows.Forms.Button btnGetElementValue;
        private System.Windows.Forms.GroupBox gbSettingNetworkInterface;
        private System.Windows.Forms.Button btnSetupToDHCP;
        private System.Windows.Forms.TextBox tbInterfaceName;
        private System.Windows.Forms.Label lbInterfaceName;
        private System.Windows.Forms.Label lbGateway;
        private System.Windows.Forms.TextBox tbGateway;
        private System.Windows.Forms.Label lbSubMesk;
        private System.Windows.Forms.TextBox tbSubMesk;
        private System.Windows.Forms.Label lbIPAddress;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Button btnEnableInterface;
        private System.Windows.Forms.Button btnSetupToStaticIP;
        private System.Windows.Forms.Button btnDisableInterface;
		private System.Windows.Forms.GroupBox gbConnectWiFi;
		private System.Windows.Forms.Button btnConnectWiFi;
		private System.Windows.Forms.Button btnTurnOnWiFi;
		private System.Windows.Forms.TextBox tbSsidiName;
		private System.Windows.Forms.Label lbWiFiName;
		private System.Windows.Forms.Button btnTurnOffWiFi;
		private System.Windows.Forms.TextBox tbSsidPasswd;
		private System.Windows.Forms.Label lbSsidPasswd;
		private System.Windows.Forms.Button btnSaveWiFiInfo;
		private System.Windows.Forms.TextBox tbIDSendKey;
		private System.Windows.Forms.Label lbIDSendKey;
		private System.Windows.Forms.GroupBox gbAccount;
		private System.Windows.Forms.Button btnSettingPwd;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnLogout;
		private System.Windows.Forms.Button btnLoginStatus;
		private System.Windows.Forms.Button btnLoginWarning;
		private System.Windows.Forms.GroupBox gbSystemControl;
		private System.Windows.Forms.Button btnLocalUpgrade;
		private System.Windows.Forms.Button btnBackupRestore;
		private System.Windows.Forms.Button btnBackup;
		private System.Windows.Forms.Button btnFactoryRestore;
		private System.Windows.Forms.GroupBox gbRadioButton;
		private System.Windows.Forms.CheckBox cbparentNode;
		private System.Windows.Forms.TextBox tbRadioButtonItem;
		private System.Windows.Forms.Label lbRadioButtonItem;
		private System.Windows.Forms.Label lbRadioButtonID;
		private System.Windows.Forms.TextBox tbRadioButtonID;
		private System.Windows.Forms.Button btnRadioButton;
		private System.Windows.Forms.GroupBox gbWebRefresh;
		private System.Windows.Forms.Button btnWebRefresh;
		private System.Windows.Forms.GroupBox gbRestartDriver;
		private System.Windows.Forms.Button btnRestartDriver;
		private System.Windows.Forms.GroupBox gbCheckBox;
		private System.Windows.Forms.RadioButton rbtnLast;
		private System.Windows.Forms.RadioButton rbtnFront;
		private System.Windows.Forms.CheckBox cbMultiSelectBox;
		private System.Windows.Forms.TextBox tbCheckBoxIdx;
		private System.Windows.Forms.Label lbCheckBoxIdx;
		private System.Windows.Forms.Label lbCheckBoxID;
		private System.Windows.Forms.TextBox tbCheckBoxID;
		private System.Windows.Forms.Button btnCheckBox;
		private System.Windows.Forms.Button btnReboot;
		private System.Windows.Forms.GroupBox gbFunctionControl;
		private System.Windows.Forms.Button btnMovePage;
		private System.Windows.Forms.GroupBox gbPageChanging;
		private System.Windows.Forms.TextBox tbChildrenPageName;
		private System.Windows.Forms.Label lbChildrenPageName;
		private System.Windows.Forms.Label lbParentPageID;
		private System.Windows.Forms.TextBox tblbParentPageID;
		private System.Windows.Forms.Label lbTopPageIndex;
		private System.Windows.Forms.TextBox tbTopPageIndex;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TabPage tpBasicFuntion;
		private System.Windows.Forms.GroupBox gbWANType;
		private System.Windows.Forms.TabPage tpBasicPataSetting;
		private System.Windows.Forms.GroupBox gbLANBasic;
		private System.Windows.Forms.CheckBox cbWANType_DHCP;
		private System.Windows.Forms.CheckBox cbWANType_StaticIP;
		private System.Windows.Forms.GroupBox gbWirelessBasic;
		private System.Windows.Forms.GroupBox gbSystemTool;
		private System.Windows.Forms.GroupBox gbSecurity;
		private System.Windows.Forms.CheckBox cbWANType_PPPoE;
		private System.Windows.Forms.CheckBox cbWANType_L2TP;
		private System.Windows.Forms.CheckBox cbWANType_PPTP;
		private System.Windows.Forms.CheckBox cbWANType_Bridge;
	}
}

