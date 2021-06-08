using BasicLIbrary;
using OpenQA.Selenium;
using System;

namespace WebLibrary
{
	public class JavaScriptCommand : Chrome
	{
		private static IJavaScriptExecutor singletonJS;
		private IJavaScriptExecutor Scripts(IWebDriver driver)
		{
			return (IJavaScriptExecutor)driver;
		}
		public JavaScriptCommand(CommonBase basicTool, Category type) : base(basicTool, type)
		{
			singletonJS = Scripts(singletonWebDriver);
		}
		public object SendCommandToGUI(string[] connectStr, ref string errStr)
		{
			string tempStr = "";
			try
			{
				for (int idx = 0; idx < connectStr.Length; idx++)
				{
					tempStr += connectStr[idx];
				}
				return singletonJS.ExecuteScript(tempStr);
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, errStr = ex.ToString(), "SendCommandToGUI");
				return null;
			}
		}
		public object ExecuteScript(string script, params object[] args)
		{
			return singletonJS.ExecuteScript(script, args);
		}
		public string UsedIDNameToFindElement(string idName)
		{
			return string.Format($"var elements = document.getElementById(\'{idName}\');");
		}
		public string UsedClassNameToFindElement(string className, int idx)
		{
			return string.Format("var elements = document.getElementsByClassName(\'" + className + "\')[" + idx + "];");
		}
		public string ElementClick()
		{
			return string.Format("elements.click();");
		}
		public void Reset()
		{
			singletonJS = Scripts(singletonWebDriver);
		}
	}
}
