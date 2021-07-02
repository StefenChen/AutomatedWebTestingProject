using BasicLIbrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebLibrary;
using WindowsControl;

namespace StateMachine
{
	public class PPPoEStateMachine : StateMachinesBase
	{
		public PPPoEStateMachine(string Name,  CommonBase basicTool, BrowserControl browserControl, WebAccountControl webAccount,
								WebFunctionControl webFunction, WebSystemControl webSystem,
								WifiControl wifi, NetworkAdapterControl networkAdapter, Communication status)
			: base(Name, basicTool, browserControl, webAccount, webFunction, webSystem, wifi, networkAdapter, status)
		{

		}

		#region para
		protected override bool VariableSetting()
		{
			return true;
		}
		#endregion

		#region ProcessState
		public override CommunicationStatus communicationStatus
		{
			get { return status.PPPoEStatus; }
			set { status.PPPoEStatus = value; }
		}
		public enum PPPoEProcessState
		{
			Idle,
			SwitchToInternetPage,
			ChangeInternetConnectionToPPPoE,
			SwitchToStatusPage,
			CheckIPAddressStatus,
			PingPrimaryDNS,
			Done,
		}
		PPPoEProcessState autoState = PPPoEProcessState.Idle;
		protected override object AutoState
		{
			get { return autoState; }
			set { autoState = (PPPoEProcessState)value; }
		}
		protected override void WriteLogWhenAuto(object state, string optionalString="")
		{
			switch ((PPPoEProcessState)state)
			{
				case PPPoEProcessState.Idle:
					break;
				case PPPoEProcessState.SwitchToInternetPage:
					msgLog.WriteLog(PPPoEProcessState.SwitchToInternetPage, optionalString, Name);
					break;
				case PPPoEProcessState.ChangeInternetConnectionToPPPoE:
					msgLog.WriteLog(PPPoEProcessState.ChangeInternetConnectionToPPPoE, optionalString, Name);
					break;
				case PPPoEProcessState.SwitchToStatusPage:
					msgLog.WriteLog(PPPoEProcessState.SwitchToStatusPage, optionalString, Name);
					break;
				case PPPoEProcessState.CheckIPAddressStatus:
					msgLog.WriteLog(PPPoEProcessState.CheckIPAddressStatus, optionalString, Name);
					break;
				case PPPoEProcessState.PingPrimaryDNS:
					msgLog.WriteLog(PPPoEProcessState.CheckIPAddressStatus, optionalString, Name);
					break;
				case PPPoEProcessState.Done:
					msgLog.WriteLog(PPPoEProcessState.Done, optionalString, Name);
					break;
			}
		}
		#endregion

		#region ErrorState
		public enum PPPoEProcessErrorState
		{
			None,                   // 狀態正常
			SelectDropDownListError,
			ClickGeneralButtonError,
			SetElementsValueError,
			MoveToSpecificSidePageError,
			PingTargetError,
		}
		PPPoEProcessErrorState errorState = PPPoEProcessErrorState.None;
		protected override object ErrorState
		{
			get { return errorState; }
			set { errorState = (PPPoEProcessErrorState)value; }
		}
		protected override void WriteLogWhenError(object errorState, string optionalString)
		{
			switch ((PPPoEProcessErrorState)errorState)
			{
				case PPPoEProcessErrorState.SelectDropDownListError:
					msgLog.WriteLog(PPPoEProcessErrorState.SelectDropDownListError, optionalString, Name);
					break;
				case PPPoEProcessErrorState.ClickGeneralButtonError:
					msgLog.WriteLog(PPPoEProcessErrorState.ClickGeneralButtonError, optionalString, Name);
					break;
				case PPPoEProcessErrorState.MoveToSpecificSidePageError:
					msgLog.WriteLog(PPPoEProcessErrorState.MoveToSpecificSidePageError, optionalString, Name);
					break;
				case PPPoEProcessErrorState.SetElementsValueError:
					msgLog.WriteLog(PPPoEProcessErrorState.SetElementsValueError, optionalString, Name);
					break;
				case PPPoEProcessErrorState.PingTargetError:
					msgLog.WriteLog(PPPoEProcessErrorState.PingTargetError, optionalString, Name);
					break;
				default:
					break;
			}
		}
		protected override void ErrorHandle()
		{
			switch (errorState)
			{
				case PPPoEProcessErrorState.SelectDropDownListError:
					GoBackToAutoFromError();
					break;
				case PPPoEProcessErrorState.ClickGeneralButtonError:
					GoBackToAutoFromError();
					break;
				case PPPoEProcessErrorState.MoveToSpecificSidePageError:
					GoBackToAutoFromError();
					break;
				case PPPoEProcessErrorState.SetElementsValueError:
					GoBackToAutoFromError();
					break;
				case PPPoEProcessErrorState.PingTargetError:
					GoBackToAutoFromError();
					break;
				default:
					//GoBackToAutoFromError();
					break;
			}
		}
		#endregion
		protected override void AutoSequence()
		{
			switch (autoState)
			{
				case PPPoEProcessState.Idle:
					GoToNewAutoState(PPPoEProcessState.SwitchToInternetPage);
					break;
				case PPPoEProcessState.SwitchToInternetPage:
					if (!webFunction.MoveToSpecificSidePage(1, "internet"))
						GoToErrorState(PPPoEProcessErrorState.MoveToSpecificSidePageError, "SwitchToInternetPage");
					else
						GoToNewAutoState(PPPoEProcessState.ChangeInternetConnectionToPPPoE,"");
					break;
				case PPPoEProcessState.ChangeInternetConnectionToPPPoE:
					bool tempBool = true;
					if(!(tempBool = webFunction.SelectDropDownMenu("_linkType", 1)))
					{
						GoToErrorState(PPPoEProcessErrorState.SelectDropDownListError, "ChangeInternetConnectionToPPPoE");
						break;
					}
					Thread.Sleep(1000);
					if(!(tempBool &= webFunction.SetElementValue("usrPPPoE","ttt")))
						GoToErrorState(PPPoEProcessErrorState.SetElementsValueError, "設定PPPoE的帳號(usrPPPoE)輸入發生異常");
					else if (!(tempBool &= webFunction.SetElementValue("pwdPPPoE", "ttt")))
						GoToErrorState(PPPoEProcessErrorState.SetElementsValueError, "設定PPPoE的帳號(pwdPPPoE)輸入發生異常");
					else if (!(tempBool &= webFunction.ClickGeneralButton("saveBtn")))
						GoToErrorState(PPPoEProcessErrorState.ClickGeneralButtonError, "ChangeInternetConnectionToDynamicIP");
					else if (tempBool)
					{
						GoToNewAutoState(PPPoEProcessState.SwitchToStatusPage);
					}
					break;
				case PPPoEProcessState.SwitchToStatusPage:
					if (!webFunction.MoveToSpecificSidePage(2, "status"))
						GoToErrorState(PPPoEProcessErrorState.MoveToSpecificSidePageError, "SwitchToStatusPage");
					else
						GoToNewAutoState(PPPoEProcessState.CheckIPAddressStatus);
					break;
				case PPPoEProcessState.CheckIPAddressStatus:
					Thread.Sleep(1000);
					if (webFunction.GetElementValue("IPV4") == "NULL")
						GoToNewAutoState(PPPoEProcessState.SwitchToStatusPage, "Element cannot find.");
					else if (webFunction.GetElementValue("IPV4") == "0.0.0.0")
					{
						Thread.Sleep(10000);
						GoToNewAutoState(PPPoEProcessState.SwitchToStatusPage,"等待間隔時間後再次檢查是否取得 DHCP");
					}
					else
						GoToNewAutoState(PPPoEProcessState.PingPrimaryDNS);
					break;
				case PPPoEProcessState.PingPrimaryDNS:
					string tempStr;
					if (webFunction.GetElementValue("DNS1V4") == "NULL")
						GoToNewAutoState(PPPoEProcessState.SwitchToStatusPage, "Element cannot find.");
					else if ((tempStr = webFunction.GetElementValue("DNS1V4")) == "0.0.0.0")
					{
						Thread.Sleep(1000);
						GoToNewAutoState(PPPoEProcessState.SwitchToStatusPage, "等待間隔時間後再次檢查是否取得 DHCP");
					}else if ((webFunction.GetElementValue("connTypeV4")) != "PPPoE")
						GoToNewAutoState(PPPoEProcessState.SwitchToStatusPage, $"Connection Type Error");
					else if (!networkAdapter.Ping(tempStr))
					{
						Thread.Sleep(10000);
						GoToNewAutoState(PPPoEProcessState.SwitchToStatusPage, "請確認是否有斷開其他網路連線");
					}
					else
						GoToNewAutoState(PPPoEProcessState.Done);
					break;
				case PPPoEProcessState.Done:
					Stop();
					communicationStatus = CommunicationStatus.Done;
					break;
			}
		}
	}
}
