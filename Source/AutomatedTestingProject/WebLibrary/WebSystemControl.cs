using BasicLIbrary;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace WebLibrary
{
	public class WebSystemControl
	{
		private WebGUIBase webGUIBase = null;
		private CommonBase basicTool = null;
		private IWebElement tempElement = null;
		public WebSystemControl(WebGUIBase webGUIBase, CommonBase basicTool)
		{
			this.webGUIBase = webGUIBase;
			this.basicTool = basicTool;
		}
		private bool UploadFile(string filePath)
		{
			try
			{
				if ((tempElement = webGUIBase.webBasic.isElementExist(By.Id("filename"))) != null)
				{
					IWebElement temp = webGUIBase.webBasic.GetMembersRelatedToIWebElement(tempElement, "parentNode.childNodes[2]");
					temp.SendKeys(filePath);
					return true;
				}
				else return false;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "UpgradeFile");
				return false;
			}
		}
		public bool FirmwareUpgrade()
		{
			try
			{
				if (UploadFile(basicTool.accessConfig.LocalUpgradeFirmwareFilePath))
				{
					Thread.Sleep(1000);
					if (webGUIBase.webBasic.ClickGeneralButton("t_upgrade"))
						return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "FirmwareUpgrade");
				return false;
			}
		}
		public bool BackupFileRestore()
		{
			try
			{
				if (UploadFile(basicTool.accessConfig.RestoreFilePath))
				{
					Thread.Sleep(1000);
					if (webGUIBase.webBasic.ClickGeneralButton("t_restore"))
						return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "FirmwareUpgrade");
				return false;
			}
		}
		public bool Backup()
		{
			try
			{
				if (webGUIBase.webBasic.ClickGeneralButton("t_backup"))
				{
					return true;
				}
				else return false;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "Backup");
				return false;
			}
		}
		public bool FactoryRestore()
		{
			try
			{
				if (webGUIBase.webBasic.ClickGeneralButton("resetBtn"))
				{
					Thread.Sleep(100);
					if (webGUIBase.webBasic.ClickGeneralButtonByClass("btn-msg-ok", 0))
						return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "FactoryRestore");
				return false;
			}
		}
		public bool Reboot()
		{
			try
			{
				if (webGUIBase.webBasic.ClickGeneralButton("topReboot"))
				{
					Thread.Sleep(100);
					if (webGUIBase.webBasic.ClickGeneralButtonByClass("btn-msg-ok",0))
						return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebAccountControl, ex.ToString(), "Reboot");
				return false;
			}
		}
	}
}
