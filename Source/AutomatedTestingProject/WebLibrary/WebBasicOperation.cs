using BasicLIbrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

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
				//basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "isElementExist");
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
				js.SendCommandToGUI(new string[] { findElementCommand, dropDownCommand }, ref errMsg);
				Thread.Sleep(300);
				selectTargetCommand = string.Format($"elements.childNodes[2].childNodes[2].childNodes[{findItem}].click();");
				js.SendCommandToGUI(new string[] { findElementCommand, selectTargetCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "SelectDropdownMenu");
				return false;
			}
		}
		public bool SelectDropDownMenu(string idName, string innerText)
		{
			string findElementCommand, selectTargetCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				selectTargetCommand = "elements.childNodes[2].childNodes[2].childNodes.forEach(function(element) {{if (element.innerText == '" + innerText + "') element.click();}})";
				js.SendCommandToGUI(new string[] { findElementCommand, selectTargetCommand }, ref errMsg);
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
		public IWebElement GetElement(string idName)
		{
			string findElementCommand, getElementCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				getElementCommand = string.Format("return elements;");
				return (IWebElement)js.SendCommandToGUI(new string[] { findElementCommand, getElementCommand }, ref errMsg);
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "GetElement");
				return null;
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
				object tempObj;
				findElementCommand = js.UsedIDNameToFindElement(idName);
				getValueCommand = string.Format("return elements.value;");
				if ((tempObj = js.SendCommandToGUI(new string[] { findElementCommand, getValueCommand }, ref errMsg)) != null)
					return tempObj.ToString();
				else
					return "NULL";
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
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "GetMembersRelatedToIWebElement");
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
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "ClickRadioButton");
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
				getValueCommand = string.Format($"{JSCommand}");
				js.SendCommandToGUI(new string[] { findElementCommand, getValueCommand }, ref errMsg);
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "DesignYourJSFunction");
				return false;
			}
		}
		public string ReturnYourJSFunctionFeedback(string idName, string JSCommand)
		{
			string findElementCommand, getValueCommand;
			try
			{
				findElementCommand = js.UsedIDNameToFindElement(idName);
				getValueCommand = string.Format($"return {JSCommand}");
				return (string)js.SendCommandToGUI(new string[] { findElementCommand, getValueCommand }, ref errMsg);
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebBasicOperation, ex.ToString(), "DesignYourJSFunction");
				return "null";
			}
		}
		public object SendCommandToGUI(string[] connectStr, ref string errStr)
		{
			return js.SendCommandToGUI(connectStr, ref errStr);
		}
	}
}

