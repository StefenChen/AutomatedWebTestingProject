using BasicLIbrary;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary
{
    public class JavaScriptCommand : Chrome
    {
        private IJavaScriptExecutor js;
        private IJavaScriptExecutor Scripts(IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }
        public JavaScriptCommand(CommonBase basicTool, Category type) : base(basicTool, type)
        {
            js = Scripts(singletonWebDriver);
        }
        public object SendCommandToGUI(string[] connectStr,ref string errStr)
        {
            string tempStr = "";
            try
            {
                for (int idx = 0; idx < connectStr.Length; idx++)
                {
                    tempStr += connectStr[idx];
                }
                return js.ExecuteScript(tempStr);
            }
            catch (Exception ex)
            {
                basicTool.messageLog.WriteLog(Category.WebElementOperation, errStr = ex.ToString(), "SendCommandToGUI");
                return null;
            }
        }

        public object ExecuteScript(string script, params object[] args)
        {
            return js.ExecuteScript(script, args);

        }

        public string UsedIDNameToFindElementCommand(string idName)
        {
            return string.Format("var elements = document.getElementById(\'{0}\');", idName);
        }
        public string UsedClassNameToFindElementCommand(string className, int idx)
        {
            return string.Format("var elements = document.getElementsByClassName(\'" + className + "\')[" + idx + "];");
        }

        public string ClickCommand()
        {
            return string.Format("elements.click();");
        }
    }
}
