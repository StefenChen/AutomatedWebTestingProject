using BasicLIbrary;
using WebLibrary;
using WindowsControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedTestingProject
{
    public class AutomatedWebTesting
    {
        private AutomatedWebTestingForm mainForm = null;
        private string CONFIG_FILE_PATH = @"C:\AutoTesting\Para\config.ini";

		public WebElementControl webElementControl;
		public WebAccountControl webAccountControl;
		public WebFunctionControl webFunctionControl;
		public WebSystemControl webSystemControl;

		public CommonBase basicTool;
        public NetworkCard networkCand;
		public WifiControl wifiControl;

		public AutomatedWebTesting(AutomatedWebTestingForm mainForm)
        {
            this.mainForm = mainForm;
            basicTool = new CommonBase(CONFIG_FILE_PATH, mainForm);
        }

        public bool Initial()
        {
            //Show current version number
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            mainForm.lbVersionNum.Text = string.Format("Version {0}", version);

			webElementControl = new WebElementControl(basicTool, new Category());
			webAccountControl = new WebAccountControl(basicTool, new Category());
			webFunctionControl = new WebFunctionControl(basicTool, new Category());
			webSystemControl = new WebSystemControl(basicTool, new Category());

			networkCand = new NetworkCard(basicTool);
			wifiControl = new WifiControl(basicTool, new Category());

			return true;
        }
    }
}
