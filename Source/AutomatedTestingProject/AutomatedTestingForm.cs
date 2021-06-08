using OpenQA.Selenium;
using System;
using System.Windows.Forms;
using WebLibrary;

namespace AutomatedTestingProject
{
	public partial class AutomatedWebTestingForm : Form
	{
		private AutomatedWebTesting automatedWebTesting;

		IWebElement tempInputAccount, tempSubmitButton;

		public AutomatedWebTestingForm()
		{
			automatedWebTesting = new AutomatedWebTesting(this);
			InitializeComponent();
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
														+ (sender == null ? "" : sender.ToString().Split(':')[1])
														+ "," + name + "\r\n";
			tbMessageShow.Text += msg + "\r\n";
		}

		#region Testing
		private void ConfigButton_Click(object sender, EventArgs e)
		{
			automatedWebTesting.basicTool.accessConfig.Test = "192.168.0.1";
			WriteMsg(sender.ToString(), "", "Wirte " + automatedWebTesting.basicTool.accessConfig.Test + "into Section[Test]" + "entry[IP]");
		}
		private void OpenURLButton_Click(object sender, EventArgs e)
		{
			try
			{
				automatedWebTesting.webGUIBase.browser.OpenNewWeb(tbOpenURL.Text, 10);
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

			if ((tempInputAccount = automatedWebTesting.webGUIBase.webBasic.isElementExist(selector, 5)) != null)
			{
				MessageBox.Show(cbFindElement.Text + ":" + tbFindElement.Text + "\r\nFind it!");
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
					automatedWebTesting.webGUIBase.webBasic.SetElementValue(tbIDSendKey.Text, tbSendKey.Text);
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

			if ((tempSubmitButton = automatedWebTesting.webGUIBase.webBasic.isElementExist(selector, 5)) != null)
			{
				try
				{
					if (cbButtonClick.Text == "ClassName")
					{
						tempSubmitButton = automatedWebTesting.webGUIBase.webBasic.FindAllElements(selector, 5)[Convert.ToInt32(tbClassIndexButtonClick.Text)];
					}//測試功能用
					else if (cbButtonClick.Text == "Id")
					{
						automatedWebTesting.webGUIBase.webBasic.ClickGeneralButton(tbButtonClick.Text);
						return;
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

		private void btnWebRefresh_Click(object sender, EventArgs e)
		{
			if (!automatedWebTesting.webGUIBase.browser.WebRefresh())
				WriteMsg(sender.ToString(), "", "Refresh Website Failed!");
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
			automatedWebTesting.webGUIBase.webBasic.MoveAFixedDistanceWhenElementScroll(dir,
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
			automatedWebTesting.webGUIBase.webBasic.ClickSwitchButton(tbSwitchButtonClick.Text,
													Convert.ToInt32(tbSwitchButtonClassIndex.Text));
			//方法二
			//tempSubmitButton = webElementControl.webElement.FindAllElements(By.ClassName(tbSwitchButtonClick.Text), 5)[Convert.ToInt32(tbSwitchButtonClassIndex.Text)];
			//tempSubmitButton.Click();
		}

		private void btnDropDownList_Click(object sender, EventArgs e)
		{
			if (automatedWebTesting.webGUIBase.webBasic.SelectDropDownMenu(tbDropDownListName.Text,
														Convert.ToInt32(tbSelectItem.Text)))
				WriteMsg(sender, tbDropDownListName.Text, "Control Button Fail");
		}

		private void btnGetElementValue_Click_1(object sender, EventArgs e)
		{
			//方法一
			//IWebElement temp = automatedWebTesting.webElementControl.webBasic.isElementExist(By.Id(tbGetElementValue.Text), 5);
			//string tempStr = automatedWebTesting.webElementControl.webBasic.GetElementValue(temp);
			//WriteMsg(sender, tbGetElementValue.Text + " Value", tempStr);
			//方法二
			string tempStr = automatedWebTesting.webGUIBase.webBasic.GetElementValue(tbGetElementValue.Text);
			WriteMsg(sender, tbGetElementValue.Text + " Value", tempStr);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			automatedWebTesting.networkCand.SetNetworkOfDHCP(tbInterfaceName.Text, true);
		}

		private void btnSetupToStaticIP_Click(object sender, EventArgs e)
		{
			automatedWebTesting.networkCand.SetNetworkOfStaticIP(tbInterfaceName.Text,
																	  tbIPAddress.Text,
																	  tbSubMesk.Text,
																	  tbGateway.Text);
		}

		private void btnEnableInterface_Click(object sender, EventArgs e)
		{
			automatedWebTesting.networkCand.EnableInterface(tbInterfaceName.Text, true);
		}

		private void btnDisableInterface_Click(object sender, EventArgs e)
		{
			automatedWebTesting.networkCand.EnableInterface(tbInterfaceName.Text, false);
		}

		private void btnConnectWiFi_Click(object sender, EventArgs e)
		{
			automatedWebTesting.wifiControl.ConnectWifi();
		}

		private void btnCheckBox_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbMultiSelectBox.Checked)
				{
					automatedWebTesting.webGUIBase.webBasic.ClickSelectBox(tbCheckBoxID.Text, Convert.ToInt32(tbCheckBoxIdx.Text), true);
				}
				else
				{
					automatedWebTesting.webGUIBase.webBasic.ClickSelectBox(tbCheckBoxID.Text, rbtnFront.Checked == true ? 1 : 2);
				}
			}
			catch (Exception ex)
			{
				WriteMsg(sender.ToString(), "btnCheckBox_Click", ex.ToString());
			}
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

		private void btnRadioButton_Click(object sender, EventArgs e)
		{
			if (Convert.ToInt32(tbRadioButtonItem.Text) < 5 || Convert.ToInt32(tbRadioButtonItem.Text) > 0)
			{
				automatedWebTesting.webGUIBase.webBasic.ClickRadioButton(tbRadioButtonID.Text, Convert.ToInt32(tbRadioButtonItem.Text), cbparentNode.Checked);
			}
			else
			{
				MessageBox.Show("Radio button 選擇項次超出範圍，上限為4，下限為1!");
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			ChromeOperation.DriverQuit();
			System.Windows.Forms.Application.Exit();
		}

		private void btnSettingPwd_Click(object sender, EventArgs e)
		{
			bool tempBool = automatedWebTesting.webAccountControl.SettingPwd();
			WriteMsg(sender.ToString(), "SettingPwd", tempBool?"Success": "Failure");
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			bool tempBool = automatedWebTesting.webAccountControl.Login();
			WriteMsg(sender.ToString(), "Login", tempBool ? "Success" : "Failure");
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			bool tempBool = automatedWebTesting.webAccountControl.Logout();
			WriteMsg(sender.ToString(), "Logout", tempBool ? "Success" : "Failure");
		}

		private void btnLoginStatus_Click(object sender, EventArgs e)
		{
			bool tempBool = automatedWebTesting.webAccountControl.CheckLoginStatus();
			WriteMsg(sender.ToString(), "CheckLoginStatus", tempBool ? "Success" : "Failure");
		}

		private void btnLoginWarning_Click(object sender, EventArgs e)
		{
			bool tempBool = automatedWebTesting.webAccountControl.LoginWarning();
			WriteMsg(sender.ToString(), "CheckLoginStatus", tempBool ? "Success" : "Failure");
		}

		private void btnResartDriver_Click(object sender, EventArgs e)
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




		#endregion


	}
}
