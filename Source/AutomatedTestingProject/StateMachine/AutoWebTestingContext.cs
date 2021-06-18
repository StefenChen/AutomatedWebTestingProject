using BasicLIbrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebLibrary;
using WindowsControl;

namespace StateMachine
{
	//簡單工廠搭配策略模式
	public class AutoWebTestingContext
	{
		public AutoWebTestingContext(string name, CommonBase basicTool, BrowserControl browser, WebAccountControl webAccount,
								WebFunctionControl webFunction, WebSystemControl webSystem,
								WifiControl wifi, NetworkAdapterControl networkAdapter, Communication status)
		{
			SimpleFactory(name, basicTool, browser, webAccount, webFunction, webSystem, wifi, networkAdapter, status);
		}

		public StateMachinesBase stateMachines = null;
		public void SimpleFactory(string name, CommonBase basicTool, BrowserControl browser, WebAccountControl webAccount,
								WebFunctionControl webFunction, WebSystemControl webSystem,
								WifiControl wifi, NetworkAdapterControl networkAdapter, Communication status)
		{
			try
			{
				switch (name)
				{
					case "DHCPStateMachine":
						stateMachines = new DHCPStateMachine(name, basicTool, browser, webAccount,
															 webFunction, webSystem, wifi, networkAdapter, status);
						break;
					case "StaticIPStateMachine":
						stateMachines = new StaticIPStateMachine(name, basicTool, browser, webAccount,
															 webFunction, webSystem, wifi, networkAdapter, status);
						break;
					case "PPPoEStateMachine":
						//stateMachines = new PPPoEStateMachine(name, basicTool, browser, webAccount,
						//			 webFunction, webSystem, wifi, networkAdapter, status);
						break;
					case "BridgeStateMachine":

						break;
					case "L2TPStateMachine":

						break;
					case "PPTPStateMachine":

						break;
					default:
						throw new SystemException("輸入的StateMachine不存在");
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
		public bool Start(ref string errStr)
		{
			if (stateMachines.IsReady(ref errStr))
			{
				stateMachines.Start();
				return true;
			}
			else
			{
				errStr += "IsReady 為 false，請確認剛開啟程式時是否存在異常。";
				return false;
			}
		}

		/// <summary>
		/// -1:異常發生, 0:正在進行, 1:完成StateMachine
		/// </summary>
		/// <returns></returns>
		//public bool WaitStateMachineFinish()
		//{
		//	int tempInt=0;

		//	while (true)
		//	{
		//		wair
		//		if (stateMachines.error)
		//		{
		//			return false;
		//		}else if(stateMachines.targetDone)
		//			return true;
		//		else { }
		//	}
		//}
	}
}
