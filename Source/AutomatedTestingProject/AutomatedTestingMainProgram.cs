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

        public WebGUIBase webGUIBase;
        public CommonBase basicTool;
        public NetworkCard networkCand;
        public NetworkAdapterUtil interfaceInfo;

        public AutomatedWebTesting(AutomatedWebTestingForm mainForm)
        {
            this.mainForm = mainForm;
            basicTool = new CommonBase(CONFIG_FILE_PATH);
        }

        public bool Initial()
        {
            //Show current version number
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            mainForm.lbVersionNum.Text = string.Format("Version {0}", version);

            webGUIBase = new WebGUIBase(basicTool, new Category());
            networkCand = new NetworkCard();
            interfaceInfo = new NetworkAdapterUtil();
            return true;
        }
    }
}
