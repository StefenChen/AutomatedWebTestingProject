using BasicLIbrary;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary
{
    public class DriverOperation : Chrome
    {
        public DriverOperation(CommonBase basicTool, Category type) : base(basicTool, type)
        {

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
                    singletonWebDriver.Quit();
                    singletonWebDriver = null;
                    singletonWebDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
                    singletonWebDriver.Manage().Window.Maximize();
                }
                return true;
            }
            catch (Exception ex)
            {
                basicTool.messageLog.WriteLog(Category.DriverOperation, ex.ToString(), "RestartDriver");
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
