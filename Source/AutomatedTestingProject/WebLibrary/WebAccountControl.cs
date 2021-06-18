using BasicLIbrary;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace WebLibrary
{
	public class WebAccountControl
	{
		private WebGUIBase webGUIBase = null;
		private CommonBase basicTool = null;
		public WebAccountControl(WebGUIBase webGUIBase, CommonBase basicTool)
		{
			this.webGUIBase = webGUIBase;
			this.basicTool = basicTool;
		}
		public bool SettingPwd()
		{
			bool tempBool = true;
			try
			{
				IWebElement tempElement;
				if ((tempElement = webGUIBase.webBasic.GetElement("pc-setPwd-new")) != null)
				{
					if (tempElement.Displayed)
						tempBool = webGUIBase.webBasic.SetElementValue("pc-setPwd-new", basicTool.accessConfig.WebLogInPasswd);
					Thread.Sleep(100);
				}
				else
					tempBool = false;
				Thread.Sleep(100);
				if ((tempElement = webGUIBase.webBasic.GetElement("pc-setPwd-confirm")) != null)
				{
					if(tempElement.Displayed)
						tempBool &= webGUIBase.webBasic.SetElementValue("pc-setPwd-confirm", basicTool.accessConfig.WebLogInPasswd);
					Thread.Sleep(100);
				}
				else
					tempBool = false;
				Thread.Sleep(100);
				if ((tempElement = webGUIBase.webBasic.GetElement("pc-setPwd-btn")) != null)
				{
					if (tempElement.Displayed)
						tempBool &= webGUIBase.webBasic.ClickGeneralButton("pc-setPwd-btn");
				}
				else
					tempBool = false;

				return tempBool;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "SettingPwd");
				return false;
			}
		}
		public bool Login()
		{
			bool tempBool;
			try
			{
				tempBool = webGUIBase.webBasic.SetElementValue("pc-login-password", basicTool.accessConfig.WebLogInPasswd);
				Thread.Sleep(100);
				tempBool &= webGUIBase.webBasic.ClickGeneralButton("pc-login-btn");
				return tempBool;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "Login");
				return false;
			}
		}
		public bool LoginWarning()
		{
			IWebElement tempElement;
			try
			{
				if((tempElement = webGUIBase.webBasic.GetElement("confirm-yes")) != null)
				{
					if(tempElement.Displayed)
						return webGUIBase.webBasic.ClickGeneralButton("confirm-yes");
				}
				return false;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "LoginWarning");
				return false;
			}
		}
		public bool Logout()
		{
			bool tempBool;
			try
			{
				tempBool = webGUIBase.webBasic.ClickGeneralButton("topLogout");
				Thread.Sleep(100);

				//MR200中是1，BBA2.5是0。
				tempBool &= webGUIBase.webBasic.ClickGeneralButtonByClass("btn-msg-ok", 0);
				return tempBool;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "Login");
				return false;
			}
		}
		/// <summary>
		/// -1:Error, 0:Setting Page, 1:Logout, 2:Login.
		/// </summary>
		/// <returns></returns>
		public int CheckLoginStatus()
		{
			IWebElement tempElement;
			try
			{
				if ((tempElement = webGUIBase.webBasic.isElementExist(By.Id("topLogout"))) != null)
				{
					if (tempElement.Displayed)
						return 2;
				}
				Thread.Sleep(100);
				if ((tempElement = webGUIBase.webBasic.isElementExist(By.Id("pc-login-btn"))) != null)
				{
					if (tempElement.Displayed)
						return 1;
				}
				Thread.Sleep(100);
				if ((tempElement = webGUIBase.webBasic.isElementExist(By.Id("pc-setPwd-btn"))) != null)
				{
					if (tempElement.Displayed)
						return 0;
				}
				return -1;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "Login");
				return -1;
			}
		}
	}
}
