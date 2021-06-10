using BasicLIbrary;
using StateMachine;
using System;
using WebLibrary;
using WindowsControl;

namespace AutomatedTestingProject
{
	public class AutomatedWebTesting
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

		public StateMachinesBase temp = null;

		public AutomatedWebTesting(AutomatedWebTestingForm mainForm)
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

			//State Machine Base
			temp = new StateMachinesBase(basicTool, webAccount, webFunction, webSystem, wifi, networkAdapter);
			return true;
		}
	}
}
