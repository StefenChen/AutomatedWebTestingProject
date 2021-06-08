using BasicLIbrary;

namespace WebLibrary
{
	public class WebSystemControl
	{
		private WebGUIBase webGUIBase;
		private CommonBase basicTool;
		public WebSystemControl(WebGUIBase webGUIBase, CommonBase basicTool)
		{
			this.webGUIBase = webGUIBase;
			this.basicTool = basicTool;
		}
	}
}
