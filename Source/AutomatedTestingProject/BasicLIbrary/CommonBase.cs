using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomatedTestingProject;
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
		WifiProfile,
		NetworkCard,
	}
    public class CommonBase 
    {
        public AccessConfig accessConfig;
        public MessageLog messageLog;

        public CommonBase(string configPath, AutomatedWebTestingForm mainFormBase)
        {
            accessConfig = AccessConfig.SetConfig(configPath);
            messageLog = MessageLog.SetMessageLog(accessConfig.LogPath, mainFormBase);
        }
    }
}
