﻿using OpenQA.Selenium;
using System;
using System.Windows.Forms;

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
				automatedWebTesting.webElementControl.browser.OpenNewWeb(tbOpenURL.Text, 10);
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

			if ((tempInputAccount = automatedWebTesting.webElementControl.webBasic.isElementExist(selector, 5)) != null)
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
			if (tempInputAccount != null)
			{
				try
				{
					automatedWebTesting.webElementControl.webBasic.SetElementValue(tbIDSendKey.Text, tbSendKey.Text);
				}
				catch (Exception ex)
				{
					WriteMsg(sender.ToString(), tbSendKey.Text, ex.ToString());
				}
			}
			else
			{
				MessageBox.Show(cbFindElement.Text + ":" + tbFindElement.Text + "\r\nNot found!");
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

			if ((tempSubmitButton = automatedWebTesting.webElementControl.webBasic.isElementExist(selector, 5)) != null)
			{
				try
				{
					if (cbButtonClick.Text == "ClassName")
					{
						tempSubmitButton = automatedWebTesting.webElementControl.webBasic.FindAllElements(selector, 5)[Convert.ToInt32(tbClassIndexButtonClick.Text)];
					}//測試功能用
					else if (cbButtonClick.Text == "Id")
					{
						automatedWebTesting.webElementControl.webBasic.ClickGeneralButton(tbButtonClick.Text);
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
			if (!automatedWebTesting.webElementControl.browser.WebRefresh())
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
			automatedWebTesting.webElementControl.webBasic.MoveAFixedDistanceWhenElementScroll(dir,
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
			automatedWebTesting.webElementControl.webBasic.ClickSwitchButton(tbSwitchButtonClick.Text,
													Convert.ToInt32(tbSwitchButtonClassIndex.Text));
			//方法二
			//tempSubmitButton = webElementControl.webElement.FindAllElements(By.ClassName(tbSwitchButtonClick.Text), 5)[Convert.ToInt32(tbSwitchButtonClassIndex.Text)];
			//tempSubmitButton.Click();
		}

		private void btnDropDownList_Click(object sender, EventArgs e)
		{
			if (automatedWebTesting.webElementControl.webBasic.SelectDropDownMenu(tbDropDownListName.Text,
														Convert.ToInt32(tbSelectItem.Text)))
				WriteMsg(sender, tbDropDownListName.Text, "Control Button Fail");
		}

		private void btnGetElementValue_Click_1(object sender, EventArgs e)
		{
			IWebElement temp = automatedWebTesting.webElementControl.webBasic.isElementExist(By.Id(tbGetElementValue.Text), 5);
			string tempStr = automatedWebTesting.webElementControl.webBasic.GetElementValue(temp);
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

		private void btnResartDriver_Click(object sender, EventArgs e)
		{
			try
			{
				automatedWebTesting.webElementControl.driver.RestartDriver();
			}
			catch (Exception ex)
			{
				WriteMsg(sender.ToString(), "", ex.ToString());
			}
		}




		#endregion


	}
}
