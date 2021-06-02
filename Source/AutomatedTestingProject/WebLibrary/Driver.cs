using BasicLIbrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }
        }
    }
}
