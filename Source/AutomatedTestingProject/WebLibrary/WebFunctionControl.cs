using BasicLIbrary;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace WebLibrary
{
	public class WebFunctionControl
	{
		private WebGUIBase webGUIBase = null;
		private CommonBase basicTool = null;
		private static Dictionary<string, Dictionary<string, int>> advancedPage = null;
		public WebFunctionControl(WebGUIBase webGUIBase, CommonBase basicTool)
		{
			this.webGUIBase = webGUIBase;
			this.basicTool = basicTool;
			advancedPage = new Dictionary<string, Dictionary<string, int>>();
			SettingAdvancedPageSequence();
		}
		private Dictionary<string, int> ReadAdvancedPageSequenceFromConfig(string sequence)
		{
			Dictionary<string, int> pageSequence = new Dictionary<string, int>();
			int index = 0;
			foreach (string tempStr in sequence.Split(';'))
			{
				pageSequence.Add(tempStr, index++);
			}
			return pageSequence;
		}
		private bool SettingAdvancedPageSequence()
		{
			try
			{
				advancedPage.Add("internet", ReadAdvancedPageSequenceFromConfig(basicTool.accessConfig.PageNetwork));
				advancedPage.Add("wireless", ReadAdvancedPageSequenceFromConfig(basicTool.accessConfig.PageWireless));
				advancedPage.Add("tools", ReadAdvancedPageSequenceFromConfig(basicTool.accessConfig.PageSystemTools));
				return true;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebFunctionControl, ex.ToString(), "SettingAdvancedPageSequence");
				return false;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="parentPageID"></param>
		/// <param name="childrenPageName"></param>
		/// <returns>-1:CannotFindPageNameOrID</returns>
		private int GetAdvancedPageIndex(string parentPageID, string childrenPageName)
		{
			try
			{
				return advancedPage[parentPageID][childrenPageName];
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebFunctionControl, ex.ToString(), "GetAdvancedPageIndex");
				return -1;
			}
		}
		public bool MoveToSpecificTopPage(int topPageIndex)
		{
			string topPageID;
			try
			{
				switch (topPageIndex)
				{
					case 0:
						topPageID = "qs";
						break;
					case 1:
						topPageID = "basic";
						break;
					case 2:
						topPageID = "advanced";
						break;
					default:
						throw new Exception("topPageIndex value out of range!");
				}

				if (webGUIBase.webBasic.ClickGeneralButton(topPageID))
				{
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebFunctionControl, ex.ToString(), "MoveToSpecificPage");
				return false;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="topPageIndex">0:Quick,1:Basic,1:Advanced</param>
		/// <param name="parentPageName">左側主標頁的id</param>
		/// <param name="childrenPageName">主標頁點開小標頁的名稱，要config中的一致(只需去除空白)/param>
		/// <returns></returns>
		public bool MoveToSpecificSidePage(int topPageIndex, string parentPageId, string childrenPageName = null)
		{
			int index;
			try
			{
				if (!MoveToSpecificTopPage(topPageIndex))
					return false;
				else if (childrenPageName != null)
				{
					Thread.Sleep(200);
					if ((index = GetAdvancedPageIndex(parentPageId, childrenPageName)) != -1)
					{
						if (webGUIBase.webBasic.DesignYourJSFunction(parentPageId, $".parentElement.parentElement.children[1].childNodes[{index}].children[0].click()"))
							return true;
					}
					return false;
				}
				else
				{
					Thread.Sleep(200);
					if (webGUIBase.webBasic.ClickGeneralButton(parentPageId))
						return true;
					else
						return false;
				}
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WebFunctionControl, ex.ToString(), "MoveToSpecificPage");
				return false;
			}
		}
		public bool SwitchButtonClicked(string idName, int classIndex)
		{
			if (webGUIBase.webBasic.ClickSwitchButton(idName, classIndex))
				return true;
			else
				return false;
		}
		public bool RadioButtonClicked(string idName, int idx, bool needParentNode)
		{
			if (webGUIBase.webBasic.ClickRadioButton(idName, idx, needParentNode))
				return true;
			else
				return false;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="idName"></param>
		/// <param name="type">1:firstElementChild,2:lastElementChild</param>
		/// <returns></returns>
		public bool ClickSelectBox(string idName, int type)
		{
			if (webGUIBase.webBasic.ClickSelectBox(idName, type))
				return true;
			else
				return false;
		}
		public bool ClickSelectBox(string idName, int index, bool multi)
		{
			if (webGUIBase.webBasic.ClickSelectBox(idName, index, multi))
				return true;
			else
				return false;
		}
		public string GetElementValue(IWebElement element)
		{
			return webGUIBase.webBasic.GetElementValue(element);
		}
		public string GetElementValue(string idName)
		{
			return webGUIBase.webBasic.GetElementValue(idName);
		}
		public bool SetElementValue(string idName, string iputStr)
		{
			return webGUIBase.webBasic.SetElementValue(idName, iputStr);
		}
		public bool MoveAFixedDistanceWhenElementScroll(string direction, string name, string nameType, int movedPixels, int classIndex = 0)
		{
			return webGUIBase.webBasic.MoveAFixedDistanceWhenElementScroll(direction, name, nameType, movedPixels, classIndex);
		}
		public bool SelectDropDownMenu(string idName, int findItem)
		{
			return webGUIBase.webBasic.SelectDropDownMenu(idName, findItem);
		}
		public IWebElement IsElementExist(By by)
		{
			return webGUIBase.webBasic.isElementExist(by);
		}
		public IList<IWebElement> FindAllElements(By by, int timeoutInSeconds)
		{
			return webGUIBase.webBasic.FindAllElements(by, timeoutInSeconds);
		}
		public bool ClickGeneralButton(string idName)
		{
			return webGUIBase.webBasic.ClickGeneralButton(idName);
		}
	}
}
