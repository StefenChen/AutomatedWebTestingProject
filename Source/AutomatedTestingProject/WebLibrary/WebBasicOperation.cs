using BasicLIbrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace WebLibrary
{
	public class WebBasicOperation : Chrome
	{
		public JavaScriptCommand js = null;
		private string errMsg = null;
		public WebBasicOperation(CommonBase basicTool, Category type) : base(basicTool, type)
		{
			js = new JavaScriptCommand(basicTool, type);
		}
		/// <summary>
		/// If element exists return it, or return null.
		/// </summary>
		/// <param name="by">Element</param>
		/// <param name="timeoutInSeconds">Timeout setting</param>
		/// <returns></returns>
		public IWebElement isElementExist(By by)
		{
			try
			{
				//if (timeoutInSeconds > 0)
				//{
				//	var wait = new WebDriverWait(singletonWebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
				//	IWebElement temp = wait.Until(drv => drv.FindElement(by));
				//	return temp;
				//}
				return singletonWebDriver.FindElement(by);
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "isElementExist");
				return null;
			}
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
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "FindAllElements");
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
		public bool MoveAFixedDistanceWhenElementScroll(string direction, string name, string nameType, int movedPixels, int classIndex = 0)
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
					findElementCommand = js.UsedIDNameToFindElement(name);
				else
					findElementCommand = js.UsedClassNameToFindElement(name, classIndex);

				moveElementCommand = string.Format("elements" + dir + movedPixels.ToString() + ";");
				js.SendCommandToGUI(new String[] { findElementCommand, moveElementCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "MoveAFixedDistanceWhenElementScroll");
				return false;
			}
		}
		public bool ClickSwitchButton(string idName, int classIndex)
		{
			string findElementCommand = "", clickCommand;
			try
			{
				findElementCommand = js.UsedClassNameToFindElement(idName, classIndex);
				clickCommand = js.ElementClick();
				js.SendCommandToGUI(new String[] { findElementCommand, clickCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "ClickSwitchButton");
				return false;
			}
		}
		public bool SelectDropDownMenu(string idName, int findItem)
		{
			string findElementCommand, dropDownCommand, selectTargetCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				dropDownCommand = string.Format("elements.childNodes[2].childNodes[1].click();");
				selectTargetCommand = string.Format($"elements.childNodes[2].childNodes[2].childNodes[{findItem}].click();");
				js.SendCommandToGUI(new string[] { findElementCommand, dropDownCommand, selectTargetCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "SelectDropdownMenu");
				return false;
			}
		}
		public bool ClickGeneralButton(string idName)
		{
			string findElementCommand = "", clickCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				clickCommand = js.ElementClick();
				js.SendCommandToGUI(new String[] { findElementCommand, clickCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "ClickGeneralButton");
				return false;
			}
		}
		public bool ClickGeneralButtonByClass(string className,int idx)
		{
			string findElementCommand = "", clickCommand;
			try
			{
				findElementCommand = js.UsedClassNameToFindElement(className, idx);
				clickCommand = js.ElementClick();
				js.SendCommandToGUI(new String[] { findElementCommand, clickCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "ClickGeneralButton");
				return false;
			}
		}
		public string GetElementValue(IWebElement element)
		{
			try
			{
				return js.ExecuteScript("return arguments[0].value;", element).ToString();
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "GetElementValueByIWebElement");
				return "NULL";
			}
		}
		public string GetElementValue(string idName)
		{
			string findElementCommand, getValueCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				getValueCommand = string.Format("return elements.value;");
				return js.SendCommandToGUI(new string[] { findElementCommand, getValueCommand }, ref errMsg).ToString();
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "GetElementValueByString");
				return "NULL";
			}
		}
		public bool SetElementValue(string idName, string iputStr)
		{
			string findElementCommand, getValueCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				getValueCommand = string.Format($"elements.value = \'{iputStr}\';");
				js.SendCommandToGUI(new string[] { findElementCommand, getValueCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "SetElementValue");
				return false;
			}
		}
		public IWebElement GetMembersRelatedToIWebElement(IWebElement element, string member)
		{
			try
			{
				IWebElement temp;
				temp=(IWebElement)js.ExecuteScript($"return arguments[0].{member};", element);
				return temp;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "GetElementValueByIWebElement");
				return null;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="idName"></param>
		/// <param name="idx">idx從1開始為第一項，以此類推。</param>
		/// <param name="needParentNode">由於RadioButton有兩種類型，因此用這個來切。</param>
		/// <returns></returns>
		public bool ClickRadioButton(string idName, int idx, bool needParentNode)
		{
			string findElementCommand = "", clickCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				if (needParentNode)
					clickCommand = string.Format($"elements.parentNode.children[{idx * 2}].click();");
				else
					clickCommand = string.Format($"elements.children[{idx}].children[1].click();");

				js.SendCommandToGUI(new String[] { findElementCommand, clickCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "ClickSelectRadioButton");
				return false;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="idName"></param>
		/// <param name="type">1:firstElementChild,2:lastElementChild</param>
		/// <returns></returns>
		public bool ClickSelectBox(string idName, int type)
		{
			string findElementCommand = "", clickCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				clickCommand = string.Format($"elements.parentElement." + (type == 1 ? "firstElementChild" : "lastElementChild") + ".click();");
				js.SendCommandToGUI(new String[] { findElementCommand, clickCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "ClickSelectBox");
				return false;
			}
		}
		public bool ClickSelectBox(string idName, int index, bool multi)
		{
			string findElementCommand = "", clickCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				clickCommand = string.Format($"elements.children[{index}].children[1].click();");
				js.SendCommandToGUI(new String[] { findElementCommand, clickCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "ClickSelectBox");
				return false;
			}
		}
		public bool DesignYourJSFunction(string idName, string JSCommand)
		{
			string findElementCommand, getValueCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				getValueCommand = string.Format($"elements{JSCommand}");
				js.SendCommandToGUI(new string[] { findElementCommand, getValueCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "DesignJSFunction");
				return false;
			}
		}
		public object SendCommandToGUI(string[] connectStr, ref string errStr)
		{
			return js.SendCommandToGUI(connectStr, ref errStr);
		}
	}
}

