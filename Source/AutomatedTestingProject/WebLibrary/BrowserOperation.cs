﻿using BasicLIbrary;
using System;

namespace WebLibrary
{
	public class BrowserOperation : Chrome
	{
		public BrowserOperation(CommonBase basicTool, Category type) : base(basicTool, type)
		{

		}
		public void OpenNewWeb(string _url, int timeOut)
		{
			try
			{
				singletonWebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeOut);
				singletonWebDriver.Navigate().GoToUrl(_url);
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.BrowserOperation, ex.ToString(), "OpenNewWeb");
			}
		}
		public void CloseWeb()
		{
			try
			{
				singletonWebDriver.Close();
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.BrowserOperation, ex.ToString(), "CloseWeb");
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
