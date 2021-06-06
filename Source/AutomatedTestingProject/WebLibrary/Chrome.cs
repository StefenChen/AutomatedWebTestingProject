using BasicLIbrary;
using OpenQA.Selenium;

namespace WebLibrary
{
	public class Chrome
	{
		protected Category type;
		protected static IWebDriver singletonWebDriver;
		protected CommonBase basicTool;

		public Chrome(CommonBase basicTool, Category type)
		{
			this.basicTool = basicTool;
			this.type = type;
			if (singletonWebDriver == null)
			{
				singletonWebDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
				singletonWebDriver.Manage().Window.Maximize();
				basicTool.messageLog.WriteLog(Category.BrowserOperation, "Chrome自動控制瀏覽器開啟");
			}
		}
	}
}
