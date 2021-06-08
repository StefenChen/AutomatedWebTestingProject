using BasicLIbrary;

namespace WebLibrary
{
	public class WebGUIBase
	{
		public ChromeOperation driver;
		public BrowserOperation browser;
		public WebBasicOperation webBasic;
		public static WebGUIBase webGUIBase;
		private WebGUIBase(CommonBase basicTool, Category type)
		{
			browser = new BrowserOperation(basicTool, type);
			webBasic = new WebBasicOperation(basicTool, type);
			driver = new ChromeOperation(basicTool, type, webBasic.js);
		}

		public static WebGUIBase SetWebGUIBase(CommonBase basicTool, Category type)
		{
			if (webGUIBase == null)
			{
				webGUIBase = new WebGUIBase(basicTool, type);
			}
			return webGUIBase;
		}

	}
}
