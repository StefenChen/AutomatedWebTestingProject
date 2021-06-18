using BasicLIbrary;
using StateMachine;
using System;
using System.Threading;
using WebLibrary;
using WindowsControl;

namespace AutomatedTestingProject
{
	public class AutomatedWebTestingMainProgram
	{
		private AutomatedWebTestingForm mainForm = null;
		private string CONFIG_FILE_PATH = @"C:\AutoTesting\Para\config.ini";

		//basic tools
		public WebGUIBase webGUIBase = null;
		public CommonBase basicTool = null;

		//API Tools
		public WebAccountControl webAccount = null;
		public WebFunctionControl webFunction = null;
		public WebSystemControl webSystem = null;
		public WifiControl wifi = null;
		public NetworkAdapterControl networkAdapter = null;
		public BrowserControl browser = null;
		public AutoWebTestingContext stateMachineContext = null;
		public ChromeOperation driver = null;
		public Communication status;
		public AutomatedWebTestingMainProgram(AutomatedWebTestingForm mainForm)
		{
			this.mainForm = mainForm;
		}

		public bool Initial()
		{
			//Show current version number
			basicTool = new CommonBase(CONFIG_FILE_PATH, mainForm);
			webGUIBase = WebGUIBase.SetWebGUIBase(basicTool, new Category());
			Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			mainForm.lbVersionNum.Text = string.Format("Version {0}", version);
			
			//API Tools initial
			webAccount = new WebAccountControl(webGUIBase, basicTool);
			webFunction = new WebFunctionControl(webGUIBase, basicTool);
			webSystem = new WebSystemControl(webGUIBase, basicTool);
			networkAdapter = new NetworkAdapterControl(basicTool);
			wifi = new WifiControl(basicTool, new Category());
			browser = new BrowserControl(basicTool, new Category());
			status = new Communication();
			return true;
		}
		public void BuildStateMachine(string name)
		{
			//State Machine Base
			stateMachineContext = new AutoWebTestingContext(name, basicTool, browser, webAccount, webFunction, webSystem, wifi, networkAdapter, status);
		}
		public void Start(ref string errStr)
		{
			stateMachineContext.Start(ref errStr);
		}
		public bool BuildNStartStateMachine(string name)
		{
			string tempStr = "";
			BuildStateMachine(name);
			Start(ref tempStr);
			if (tempStr != "")
			{
				basicTool.messageLog.WriteLog(Category.UserCommand, name, tempStr);
				return false;
			}
			else return true;
		}
		public bool FreedStateMachines()
		{
			if (stateMachineContext != null)
			{
				if (stateMachineContext.stateMachines != null)
				{
					if (stateMachineContext.stateMachines.communicationStatus != CommunicationStatus.Idle
						|| stateMachineContext.stateMachines.communicationStatus != CommunicationStatus.Busy)
					{
						stateMachineContext.stateMachines.FreedAll();
						stateMachineContext.stateMachines = null;
						return true;
					}
				}
			}
			
			return false;
		}
	}
}
