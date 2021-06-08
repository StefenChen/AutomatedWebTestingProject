using BasicLIbrary;
using System;
using WebLibrary;
using WindowsControl;

namespace AutomatedTestingProject
{
	public class AutomatedWebTesting
	{
		private AutomatedWebTestingForm mainForm = null;
		private string CONFIG_FILE_PATH = @"C:\AutoTesting\Para\config.ini";

		public WebAccountControl webAccountControl;
		public WebFunctionControl webFunctionControl;
		public WebSystemControl webSystemControl;
		public WebGUIBase webGUIBase;
		public CommonBase basicTool;

		public NetworkCard networkCand;
		public WifiControl wifiControl;

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
			
			webAccountControl = new WebAccountControl(webGUIBase, basicTool);
			webFunctionControl = new WebFunctionControl(webGUIBase, basicTool);
			webSystemControl = new WebSystemControl(webGUIBase, basicTool);

			networkCand = new NetworkCard(basicTool);
			wifiControl = new WifiControl(basicTool, new Category());

			return true;
		}
	}
}
