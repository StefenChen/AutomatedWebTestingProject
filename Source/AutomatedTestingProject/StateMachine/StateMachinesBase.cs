using BasicLIbrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLibrary;
using WindowsControl;

namespace StateMachine
{
	public class StateMachinesBase
	{
		protected CommonBase Tools = null;
		protected WebAccountControl webAccount = null;
		protected WebFunctionControl webFunction = null;
		protected WebSystemControl webSystem = null;
		protected WifiControl wifi = null;
		protected NetworkAdapterControl networkAdapter = null;

		public StateMachinesBase(CommonBase basicTool, WebAccountControl webAccount, WebFunctionControl webFunction,
								 WebSystemControl webSystem, WifiControl wifi, NetworkAdapterControl networkAdapter)
		{
			this.Tools = basicTool;
			this.webAccount = webAccount;
			this.webFunction = webFunction;
			this.webSystem = webSystem;
			this.wifi = wifi;
			this.networkAdapter = networkAdapter;
		}

	}
}
