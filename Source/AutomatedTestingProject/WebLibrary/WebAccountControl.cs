using BasicLIbrary;
using OpenQA.Selenium;
using System;

namespace WebLibrary
{
	public class WebAccountControl
	{
		private WebGUIBase webGUIBase;
		private CommonBase basicTool;
		public WebAccountControl(WebGUIBase webGUIBase, CommonBase basicTool)
		{
			this.webGUIBase = webGUIBase;
			this.basicTool = basicTool;
		}

		public bool SettingPwd()
		{
			bool tempBool;
			try
			{
				tempBool = webGUIBase.webBasic.SetElementValue("pc-setPwd-new", basicTool.accessConfig.WebLogInPasswd);
				tempBool &= webGUIBase.webBasic.SetElementValue("pc-setPwd-confirm", basicTool.accessConfig.WebLogInPasswd);
				tempBool &= webGUIBase.webBasic.ClickGeneralButton("pc-setPwd-btn");
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
			bool tempBool;
			try
			{
				tempBool = webGUIBase.webBasic.ClickGeneralButton("confirm-yes");
				return tempBool;
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
				tempBool &= webGUIBase.webBasic.ClickGeneralButtonByClass("btn-msg-ok", 0);
				return tempBool;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "Login");
				return false;
			}
		}
		public bool CheckLoginStatus()
		{
			try
			{
				if(webGUIBase.webBasic.isElementExist(By.Id("pc-login-password"), 100) != null
					 || webGUIBase.webBasic.isElementExist(By.Id("pc-login-btn"), 100) != null
					 || webGUIBase.webBasic.isElementExist(By.Id("topLogout"), 100) == null)
					return false;
				else
					return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "Login");
				return false;
			}
		}
	}
}
