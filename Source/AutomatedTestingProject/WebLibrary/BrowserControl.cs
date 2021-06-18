using BasicLIbrary;
using System;

namespace WebLibrary
{
	public class BrowserControl : Chrome
	{
		public BrowserControl(CommonBase basicTool, Category type) : base(basicTool, type)
		{

		}
		public bool OpenNewWeb(string _url, int timeOut)
		{
			try
			{
				singletonWebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeOut);
				singletonWebDriver.Navigate().GoToUrl(_url);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.BrowserOperation, ex.ToString(), "OpenNewWeb");
				return false;
			}
		}
		public bool CloseWeb()
		{
			try
			{
				singletonWebDriver.Close();
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.BrowserOperation, ex.ToString(), "CloseWeb");
				return false;
			}
		}
		public bool WebRefresh()
		{
			try
			{
				if (singletonWebDriver != null)
				{
					singletonWebDriver.Navigate().Refresh();
					return true;
				}
				else
					return false;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.BrowserOperation, ex.ToString(), "WebRefresh");
				return false;
			}
		}
	}
}
