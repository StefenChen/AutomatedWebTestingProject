using BasicLIbrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebLibrary
{
    public class WebElementOperation : Chrome
    {
        public JavaScriptCommand js;
        private string errMsg;

        public WebElementOperation(CommonBase basicTool, Category type) : base(basicTool, type)
        {
            js = new JavaScriptCommand(basicTool, type);
        }

        /// <summary>
        /// If element exists return it, or return null.
        /// </summary>
        /// <param name="by">Element</param>
        /// <param name="timeoutInSeconds">Timeout setting</param>
        /// <returns></returns>
        public IWebElement isElementExist(By by, int timeoutInSeconds)
        {
            IWebElement tempElemnet;
            try
            {
                tempElemnet = FindFirstElement(by, timeoutInSeconds);
                return tempElemnet;
            }
            catch (Exception ex)
            {
                basicTool.messageLog.WriteLog(Category.WebElementOperation, ex.ToString(), "isElementExist");
                return null;
            }
        }
        private IWebElement FindFirstElement(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(singletonWebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return singletonWebDriver.FindElement(by);
        }
        public IList<IWebElement> FindAllElements(By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(singletonWebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
                }
                return singletonWebDriver.FindElements(by);
            }
            catch (Exception ex)
            {
                basicTool.messageLog.WriteLog(Category.WebElementOperation, ex.ToString(), "FindAllElements");
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction">'Up','Down','Left','Right'</param>
        /// <param name="name">ID Name or Class Name</param>
        /// <param name="nameType">'Id','Class'</param>
        /// <param name="movedPixels">Scrolling Pixels</param>
        /// <param name="classIndex">Don't enter anything if you choose id type</param>
        /// <returns></returns>
        public bool MoveAFixedDistanceWhenElementScroll(string direction,string name,string nameType,int movedPixels,int classIndex = 0)
        {
            string findElementCommand, moveElementCommand, dir;
            try
            {
                switch (direction)
                {
                    case "Up":
                        dir = ".scrollTop-=";
                        break;
                    case "Down":
                        dir = ".scrollTop+=";
                        break;
                    case "Left":
                        dir = ".scrollLeft-=";
                        break;
                    case "Right":
                        dir = ".scrollLeft+=";
                        break;
                    default:
                        dir = "";
                        break;
                }
                if (nameType == "Id")
                    findElementCommand = js.UsedIDNameToFindElementCommand(name);
                else
                    findElementCommand = js.UsedClassNameToFindElementCommand(name, classIndex);

                moveElementCommand = string.Format("elements" + dir + movedPixels.ToString() + ";");
                js.SendCommandToGUI(new String[] { findElementCommand, moveElementCommand },ref errMsg);
                return true;
            }
            catch (Exception ex)
            {
                basicTool.messageLog.WriteLog(Category.WebElementOperation, ex.ToString(), "MoveAFixedDistanceWhenElementScroll");
                return false;
            }
        }
        public bool ClickSwitchButton(string name,int classIndex)
        {
            string findElementCommand = "", clickCommand;
            try
            {
                findElementCommand = js.UsedClassNameToFindElementCommand(name, classIndex);
                clickCommand = js.ClickCommand();
                js.SendCommandToGUI(new String[] { findElementCommand, clickCommand }, ref errMsg);
                return true;
            }
            catch(Exception ex)
            {
                basicTool.messageLog.WriteLog(Category.WebElementOperation, ex.ToString(), "ClickSwitchButton");
                return false;
            }
        }

        public bool SelectDropdownMenu(string idName, int findItem)
        {
            string findElementCommand, dropDownCommand, selectTargetCommand;
            try
            {
                findElementCommand = js.UsedIDNameToFindElementCommand(idName); 
                dropDownCommand = string.Format("elements.childNodes[2].childNodes[1].click();");
                selectTargetCommand = string.Format("elements.childNodes[2].childNodes[2].childNodes[{0}].click();", findItem);
                js.SendCommandToGUI(new string[] { findElementCommand, dropDownCommand, selectTargetCommand}, ref errMsg);
                return true;
            }
            catch (Exception ex)
            {
                basicTool.messageLog.WriteLog(Category.WebElementOperation, ex.ToString(), "SelectDropdownMenu");
                return false;
            }
        }
        public string GetElementValue(IWebElement element)
        {
            return js.ExecuteScript("return arguments[0].value;", element).ToString();
        }
        public object SendCommandToGUI(string[] connectStr, ref string errStr)
        {
            return js.SendCommandToGUI(connectStr, ref errStr);
        }
    }
}

