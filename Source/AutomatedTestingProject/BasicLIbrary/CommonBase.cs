using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace BasicLIbrary
{
    public enum Category
    {
        WebGUIBase,
        DriverOperation,
        BrowserOperation,
        WebElementOperation,
		WifiControl,
    }
    public class CommonBase 
    {
        public AccessConfig accessConfig;
        public MessageLog messageLog;

        public CommonBase(string configPath)
        {
            accessConfig = AccessConfig.SetConfig(configPath);
            messageLog = MessageLog.SetMessageLog(accessConfig.LogPath);
        }
    }
}
