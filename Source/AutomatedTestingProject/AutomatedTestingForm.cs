using BasicLIbrary;
using OpenQA.Selenium;
using StateMachine;
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using WebLibrary;

namespace AutomatedTestingProject
{
	public partial class AutomatedWebTestingForm : Form
	{
		private AutomatedWebTestingMainProgram automatedWebTesting = null;

		IWebElement tempInputAccount = null, tempSubmitButton = null;

		public AutomatedWebTestingForm()
		{
			automatedWebTesting = new AutomatedWebTestingMainProgram(this);
			InitializeComponent();
			InitializeTestCaseTimer();
		}

		private void FormBase_Load(object sender, EventArgs e)
		{
			if (automatedWebTesting != null)
			{
				automatedWebTesting.Initial();
			}
		}

		public void WriteMsg(object sender, string name, string msg)
		{
			if (tbMessageShow.Lines.Length >= 100)
			{
				/* 選取第一行第一個字符的索引到第二行第二個字符的索引 */
				tbMessageShow.Select(tbMessageShow.GetFirstCharIndexFromLine(0), tbMessageShow.GetFirstCharIndexFromLine(40));
				/* 然後刪除 */
				tbMessageShow.SelectedText = "";
			}

			tbMessageShow.Text += DateTime.Now.ToString("[HH時mm分ss秒]")
														+ (sender == null ? "" : (sender.ToString().Split(':')[1]+ ","))
														 + name + "\r\n";
			tbMessageShow.Text += msg + "\r\n";
		}
		private void OpenURLButton_Click(object sender, EventArgs e)
		{
			try
			{
				if(!automatedWebTesting.browser.OpenNewWeb(tbOpenURL.Text, 10))
					WriteMsg(sender.ToString(), tbOpenURL.Text, "網頁開啟失敗");
				else
					WriteMsg(sender.ToString(), tbOpenURL.Text, "網頁開啟成功");
			}
			catch (Exception ex)
			{
				WriteMsg(sender.ToString(), tbOpenURL.Text, ex.ToString());
			}
		}
		private void FindElement_Click(object sender, EventArgs e)
		{
			By selector;
			switch (cbFindElement.Text)
			{
				case "Id":
					selector = By.Id(tbFindElement.Text);
					break;
				case "Name":
					selector = By.Name(tbFindElement.Text);
					break;
				case "XPath":
					selector = By.XPath(tbFindElement.Text);
					break;
				case "ClassName":
					selector = By.ClassName(tbFindElement.Text);
					break;
				default:
					selector = By.Name(tbFindElement.Text);
					break;
			}

			if ((tempInputAccount = automatedWebTesting.webFunction.IsElementExist(selector)) != null)
			{
				MessageBox.Show(cbFindElement.Text + ":" + tbFindElement.Text + $"\r\nFind it, and Displayed is {tempInputAccount.Displayed}");
			}
			else
			{
				MessageBox.Show(cbFindElement.Text + ":" + tbFindElement.Text + "\r\nNot found!");
			}
		}
		private void SendKeys_Click(object sender, EventArgs e)
		{
				try
				{
					automatedWebTesting.webFunction.SetElementValue(tbIDSendKey.Text, tbSendKey.Text);
				}
				catch (Exception ex)
				{
					WriteMsg(sender.ToString(), tbSendKey.Text, ex.ToString());
				}
		}
		private void btnButtonClick_Click(object sender, EventArgs e)
		{
			By selector;
			switch (cbButtonClick.Text)
			{
				case "Name":
					selector = By.Name(tbButtonClick.Text);
					break;
				case "Id":
					selector = By.Id(tbButtonClick.Text);
					break;
				case "XPath":
					selector = By.XPath(tbButtonClick.Text);
					break;
				case "ClassName":
					selector = By.ClassName(tbButtonClick.Text);
					break;
				default:
					selector = By.Name(tbButtonClick.Text);
					break;
			}

			if ((tempSubmitButton = automatedWebTesting.webFunction.IsElementExist(selector)) != null)
			{
				try
				{
					if (cbButtonClick.Text == "ClassName")
					{
						tempSubmitButton = automatedWebTesting.webFunction.FindAllElements(selector, 5)[Convert.ToInt32(tbClassIndexButtonClick.Text)];
					}//測試功能用
					else if (cbButtonClick.Text == "Id")
					{
						if(!automatedWebTesting.webFunction.ClickGeneralButton(tbButtonClick.Text))
							WriteMsg(sender.ToString(), cbButtonClick.Text + ":" + tbButtonClick.Text, "Button無法正常按。");
					}
					else
					{
						if (tempSubmitButton.Displayed)
							tempSubmitButton.Click();
						else
							WriteMsg(sender.ToString(), cbButtonClick.Text + ":" + tbButtonClick.Text, "Button沒有顯示在畫面，請確認是否有被遮住或不在可視範圍內。");
					}
				}
				catch (Exception ex)
				{
					WriteMsg(sender.ToString(), cbButtonClick.Text + ":" + tbButtonClick.Text, ex.ToString());
				}
			}
			else
			{
				MessageBox.Show(tbButtonClick.Text + "\r\nNot found!");
			}
		}

		private void btnScrollElement_Click(object sender, EventArgs e)
		{
			string dir;
			switch (((Button)sender).Name)
			{
				case "btnScrollElementUp":
					dir = "Up";
					break;
				case "btnScrollElementDown":
					dir = "Down";
					break;
				case "btnScrollElementLeft":
					dir = "Left";
					break;
				case "btnScrollElementRight":
					dir = "Right";
					break;
				default:
					dir = "";
					break;
			}
			automatedWebTesting.webFunction.MoveAFixedDistanceWhenElementScroll(dir,
																		tbScrollElement.Text,
																		clbScrollElement.SelectedItem.ToString(),
																		Convert.ToInt32(tbMovedPixels.Text),
																		Convert.ToInt32(tbClassIndex.Text));
		}
		private void clbScrollElement_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (clbScrollElement.SelectedIndex == 0)
				clbScrollElement.SetItemChecked(1, false);
			else if (clbScrollElement.SelectedIndex == 1)
				clbScrollElement.SetItemChecked(0, false);
		}

		private void btnSwitchButtonClick_Click(object sender, EventArgs e)
		{
			//方法一
			automatedWebTesting.webFunction.SwitchButtonClicked(tbSwitchButtonClick.Text, Convert.ToInt32(tbSwitchButtonClassIndex.Text));
			//方法二
			//tempSubmitButton = automatedWebTesting.webFunction.FindAllElements(By.ClassName(tbSwitchButtonClick.Text), 5)[Convert.ToInt32(tbSwitchButtonClassIndex.Text)];
			//tempSubmitButton.Click();
		}

		private void btnDropDownList_Click(object sender, EventArgs e)
		{
			if (automatedWebTesting.webFunction.SelectDropDownMenu(tbDropDownListName.Text,Convert.ToInt32(tbSelectItem.Text)))
				WriteMsg(sender, tbDropDownListName.Text, "Control Button Fail");
		}

		private void btnGetElementValue_Click_1(object sender, EventArgs e)
		{
			string tempStr = automatedWebTesting.webFunction.GetElementValue(tbGetElementValue.Text);
			WriteMsg(sender, tbGetElementValue.Text + " Value", tempStr);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			automatedWebTesting.networkAdapter.SetNetworkOfDHCP(tbInterfaceName.Text, true);
		}

		private void btnSetupToStaticIP_Click(object sender, EventArgs e)
		{
			automatedWebTesting.networkAdapter.SetNetworkOfStaticIP(tbInterfaceName.Text,
																	  tbIPAddress.Text,
																	  tbSubMesk.Text,
																	  tbGateway.Text);
		}

		private void btnEnableInterface_Click(object sender, EventArgs e)
		{
			automatedWebTesting.networkAdapter.EnableInterface(tbInterfaceName.Text, true);
		}

		private void btnDisableInterface_Click(object sender, EventArgs e)
		{
			automatedWebTesting.networkAdapter.EnableInterface(tbInterfaceName.Text, false);
		}

		private void btnConnectWiFi_Click(object sender, EventArgs e)
		{
			automatedWebTesting.wifi.ConnectWifi();
		}

		private void cbMultiSelectBox_CheckedChanged(object sender, EventArgs e)
		{
			if (cbMultiSelectBox.Checked)
			{
				tbCheckBoxIdx.Visible = true;
				lbCheckBoxIdx.Visible = true;
				rbtnFront.Visible = false;
				rbtnLast.Visible = false;
			}
			else
			{
				tbCheckBoxIdx.Visible = false;
				lbCheckBoxIdx.Visible = false;
				rbtnFront.Visible = true;
				rbtnLast.Visible = true;
			}
		}

		private void rbtnFront_CheckedChanged(object sender, EventArgs e)
		{
			if (rbtnFront.Checked == true) rbtnLast.Checked = false;
		}

		private void rbtnLast_CheckedChanged(object sender, EventArgs e)
		{
			if (rbtnLast.Checked == true) rbtnFront.Checked = false;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			ChromeOperation.DriverQuit();
			System.Windows.Forms.Application.Exit();
		}

		private void btnSettingPwd_Click(object sender, EventArgs e)
		{
			bool tempBool = automatedWebTesting.webAccount.SettingPwd();
			WriteMsg(sender.ToString(), "SettingPwd", tempBool?"Success": "Failure");
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			bool tempBool = automatedWebTesting.webAccount.Login();
			WriteMsg(sender.ToString(), "Login", tempBool ? "Success" : "Failure");
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			bool tempBool = automatedWebTesting.webAccount.Logout();
			WriteMsg(sender.ToString(), "Logout", tempBool ? "Success" : "Failure");
		}

		private void btnLoginStatus_Click(object sender, EventArgs e)
		{
			int tempInt = automatedWebTesting.webAccount.CheckLoginStatus();
			string tempStr;
			switch (tempInt)
			{
				case 0:
					tempStr = "Setting Passwd Page";
					break;
				case 1:
					tempStr = "Login Page";
					break;
				case 2:
					tempStr = "Logged in Page";
					break;
				default:
					tempStr = "Error";
					break;
			}
			WriteMsg(sender.ToString(), "CheckLoginStatus", tempStr);
		}

		private void btnLoginWarning_Click(object sender, EventArgs e)
		{
			bool tempBool = automatedWebTesting.webAccount.LoginWarning();
			WriteMsg(sender.ToString(), "CheckLoginStatus", tempBool ? "Success" : "Failure");
		}

		private void btnLocalUpgrade_Click(object sender, EventArgs e)
		{
			automatedWebTesting.webSystem.FirmwareUpgrade();
			
		}

		private void btnBackupRestore_Click(object sender, EventArgs e)
		{
			automatedWebTesting.webSystem.BackupFileRestore();
		}

		private void btnBackup_Click(object sender, EventArgs e)
		{
			automatedWebTesting.webSystem.Backup();
		}

		private void btnSaveWiFiInfo_Click(object sender, EventArgs e)
		{
			automatedWebTesting.basicTool.accessConfig.Ssid1Name = tbSsidiName.Text;
			automatedWebTesting.basicTool.accessConfig.Ssid1Passwd = tbSsidPasswd.Text;
		}

		private void btnTurnOnWiFi_Click(object sender, EventArgs e)
		{
			automatedWebTesting.wifi.TurnOn();
		}

		private void btnTurnOffWiFi_Click(object sender, EventArgs e)
		{
			automatedWebTesting.wifi.TurnOff();
		}

		private void btnFactoryRestore_Click(object sender, EventArgs e)
		{
			automatedWebTesting.webSystem.FactoryRestore();
		}

		private void btnWebRefresh_Click_1(object sender, EventArgs e)
		{
			if (!automatedWebTesting.browser.WebRefresh())
				WriteMsg(sender.ToString(), "", "Refresh Website Failed!");
		}

		private void btnCheckBox_Click_1(object sender, EventArgs e)
		{
			try
			{
				if (cbMultiSelectBox.Checked)
				{
					automatedWebTesting.webFunction.ClickSelectBox(tbCheckBoxID.Text, Convert.ToInt32(tbCheckBoxIdx.Text), true);
				}
				else
				{
					automatedWebTesting.webFunction.ClickSelectBox(tbCheckBoxID.Text, rbtnFront.Checked == true ? 1 : 2);
				}
			}
			catch (Exception ex)
			{
				WriteMsg(sender.ToString(), "btnCheckBox_Click", ex.ToString());
			}
		}

		private void btnRadioButton_Click_1(object sender, EventArgs e)
		{
			if (Convert.ToInt32(tbRadioButtonItem.Text) < 5 || Convert.ToInt32(tbRadioButtonItem.Text) > 0)
			{
				automatedWebTesting.webFunction.RadioButtonClicked(tbRadioButtonID.Text, Convert.ToInt32(tbRadioButtonItem.Text), cbparentNode.Checked);
			}
			else
			{
				MessageBox.Show("Radio button 選擇項次超出範圍，上限為4，下限為1!");
			}
		}

		private void btnReboot_Click(object sender, EventArgs e)
		{
			automatedWebTesting.webSystem.Reboot();
		}

		private void btnMovePage_Click(object sender, EventArgs e)
		{
			automatedWebTesting.webFunction.MoveToSpecificSidePage(Convert.ToInt32(tbTopPageIndex.Text), tblbParentPageID.Text, tbChildrenPageName.Text!=""? tbChildrenPageName.Text:null);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string tts;
			IPInterfaceProperties temp = automatedWebTesting.networkAdapter.GetNetWorkCardIPInformation(
												automatedWebTesting.basicTool.accessConfig.WiredNetworkName);
			foreach(var tempT in temp.UnicastAddresses)
			{
				if (tempT.Address.ToString().Contains("."))
					tts = tempT.Address.ToString();
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			automatedWebTesting.networkAdapter.Ping("12.0.0.1");
		}

		private void btnRestartDriver_Click_1(object sender, EventArgs e)
		{
			try
			{
				automatedWebTesting.webGUIBase.driver.RestartDriver();
			}
			catch (Exception ex)
			{
				WriteMsg(sender.ToString(), "", ex.ToString());
			}
		}
		private void btnStart_Click(object sender, EventArgs e)
		{
			TimerStart();
		}

		private void StartTestCase(object sender, ElapsedEventArgs e)
		{
			#region WAN Type
			//WAN Type_DHCP
			if (cbWANType_DHCP.Checked)
			{
				switch (automatedWebTesting.status.DHCPStatus)
				{
					case CommunicationStatus.Idle:
						automatedWebTesting.FreedStateMachines();
						automatedWebTesting.BuildNStartStateMachine("DHCPStateMachine");
						TimerStart();
						return;
					case CommunicationStatus.Error:
						break;
					case CommunicationStatus.Busy:
						TimerStart();
						return;
					case CommunicationStatus.Done:
						break;
				}
			}
			
			//WAN Type_Static IP
			if (cbWANType_StaticIP.Checked)
			{
				switch (automatedWebTesting.status.StaticIPStatus)
				{
					case CommunicationStatus.Idle:
						automatedWebTesting.FreedStateMachines();
						automatedWebTesting.BuildNStartStateMachine("StaticIPStateMachine");
						TimerStart();
						return;
					case CommunicationStatus.Error:
						break;
					case CommunicationStatus.Busy:
						TimerStart();
						return;
					case CommunicationStatus.Done:
						break;
				}
			}

			//WAN Type_PPPoE
			if (cbWANType_PPPoE.Checked)
			{
				switch (automatedWebTesting.status.PPPoEStatus)
				{
					case CommunicationStatus.Idle:
						automatedWebTesting.FreedStateMachines();
						automatedWebTesting.BuildNStartStateMachine("PPPoEStateMachine");
						TimerStart();
						return;
					case CommunicationStatus.Error:
						break;
					case CommunicationStatus.Busy:
						TimerStart();
						return;
					case CommunicationStatus.Done:
						break;
				}
			}

			//WAN Type_Bridge
			if (cbWANType_Bridge.Checked)
			{
				switch (automatedWebTesting.status.BridgeStatus)
				{
					case CommunicationStatus.Idle:
						automatedWebTesting.FreedStateMachines();
						automatedWebTesting.BuildNStartStateMachine("BridgeStateMachine");
						TimerStart();
						return;
					case CommunicationStatus.Error:
						break;
					case CommunicationStatus.Busy:
						TimerStart();
						return;
					case CommunicationStatus.Done:
						break;
				}
			}
			//WAN Type_L2TP
			if (cbWANType_L2TP.Checked)
			{
				switch (automatedWebTesting.status.L2TPStatus)
				{
					case CommunicationStatus.Idle:
						automatedWebTesting.FreedStateMachines();
						automatedWebTesting.BuildNStartStateMachine("L2TPStateMachine");
						TimerStart();
						return;
					case CommunicationStatus.Error:
						break;
					case CommunicationStatus.Busy:
						TimerStart();
						return;
					case CommunicationStatus.Done:
						break;
				}
			}

			//WAN Type_PPTP
			if (cbWANType_PPTP.Checked)
			{
				switch (automatedWebTesting.status.PPTPStatus)
				{
					case CommunicationStatus.Idle:
						automatedWebTesting.FreedStateMachines();
						automatedWebTesting.BuildNStartStateMachine("PPTPStateMachine");
						TimerStart();
						return;
					case CommunicationStatus.Error:
						break;
					case CommunicationStatus.Busy:
						TimerStart();
						return;
					case CommunicationStatus.Done:
						break;
				}
			}
			#endregion
		}

		System.Timers.Timer TestCaseTimer;
		private void InitializeTestCaseTimer()
		{
			TestCaseTimer = new System.Timers.Timer(1000);
			TestCaseTimer.Stop();
			TestCaseTimer.AutoReset = false;
			TestCaseTimer.Elapsed += new System.Timers.ElapsedEventHandler(StartTestCase);
		}
		private void TimerStart()
		{
			TestCaseTimer.Start();
		}
	}
}
