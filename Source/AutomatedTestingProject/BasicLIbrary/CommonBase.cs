using AutomatedTestingProject;


namespace BasicLIbrary
{
	public enum Category
	{
		WebGUIBase,
		ChromeOperation,
		BrowserOperation,
		WebBasicOperation,
		WifiControl,
		WebAccountControl,
		WifiProfile,
		NetworkCard,
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
