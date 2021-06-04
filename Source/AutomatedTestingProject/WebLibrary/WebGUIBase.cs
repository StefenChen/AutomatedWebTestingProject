using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BasicLIbrary;
using System.Collections.ObjectModel;

namespace WebLibrary
{
    public class WebGUIBase
    {
        public DriverOperation driver;
		public BrowserOperation browser;
		public WebElementOperation webElement;

        public WebGUIBase(CommonBase basicTool, Category type)
        {
            browser = new BrowserOperation(basicTool, type);
            webElement = new WebElementOperation(basicTool, type);
            driver = new DriverOperation(basicTool, type);
        }
    }
}
