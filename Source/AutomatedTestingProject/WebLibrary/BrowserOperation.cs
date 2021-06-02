using BasicLIbrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            singletonWebDriver.Close();
        }
        public bool WebRefresh()
        {
            if (singletonWebDriver != null)
            {
                singletonWebDriver.Navigate().Refresh();
                return true;
            }
            else
                return false;
        }
    }
}
