using BasicLIbrary;
using OpenQA.Selenium.Chrome;
using System;

namespace WebLibrary
{
	public class ChromeOperation : Chrome
	{
		JavaScriptCommand js;
		public ChromeOperation(CommonBase basicTool, Category type, JavaScriptCommand js) : base(basicTool, type)
		{
			this.js = js;
		}
		public static void DriverQuit()
		{
			singletonWebDriver.Quit();
		}
		public bool RestartDriver()
		{
			try
			{
				ChromeOptions options = new ChromeOptions();
				if (singletonWebDriver == null)
				{
					singletonWebDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
					singletonWebDriver.Manage().Window.Maximize();
				}
				else
				{
					singletonWebDriver.Close();
					singletonWebDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
					singletonWebDriver.Manage().Window.Maximize();
					js.Reset();
				}
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.ChromeOperation, ex.ToString(), "RestartDriver");
				return false;
			}
		}
		public bool isDriverAlive()
		{
			if (singletonWebDriver == null)
				return false;
			else
				return true;
		}
	}
}
