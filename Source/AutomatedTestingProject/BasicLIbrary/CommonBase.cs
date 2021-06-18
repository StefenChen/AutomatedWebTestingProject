using AutomatedTestingProject;


namespace BasicLIbrary
{
	public enum Category
	{
		UserCommand,
		WebGUIBase,
		ChromeOperation,
		BrowserOperation,
		WebBasicOperation,
		WifiControl,
		WebAccountControl,
		WebFunctionControl,
		WifiProfile,
		NetworkCard,
		DHCPStateMachine,

	}
	public class CommonBase
	{
		public AccessConfig accessConfig;
		public MessageLog messageLog;
		public CommonBase(string configPath, AutomatedWebTestingForm mainFormBase)
		{
			accessConfig = AccessConfig.SetConfig(configPath);
			messageLog = MessageLog.SetMessageLog(accessConfig.LogPath, mainFormBase);
		}
	}
}
