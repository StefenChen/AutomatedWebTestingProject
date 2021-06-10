using BasicLIbrary;

namespace WebLibrary
{
	public class WebGUIBase
	{
		public ChromeOperation driver = null;
		public BrowserOperation browser = null;
		public WebBasicOperation webBasic = null;
		public static WebGUIBase singletonWebGUIBase = null;
		private WebGUIBase(CommonBase basicTool, Category type)
		{
			browser = new BrowserOperation(basicTool, type);
			webBasic = new WebBasicOperation(basicTool, type);
			driver = new ChromeOperation(basicTool, type, webBasic.js);
		}
		public static WebGUIBase SetWebGUIBase(CommonBase basicTool, Category type)
		{
			if (singletonWebGUIBase == null)
			{
				singletonWebGUIBase = new WebGUIBase(basicTool, type);
			}
			return singletonWebGUIBase;
		}
	}
}
