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
	public class L2TPStateMachine : StateMachinesBase
	{
		public L2TPStateMachine(string Name,  CommonBase basicTool, BrowserControl browserControl, WebAccountControl webAccount,
								WebFunctionControl webFunction, WebSystemControl webSystem,
								WifiControl wifi, NetworkAdapterControl networkAdapter, Communication status)
			: base(Name, basicTool, browserControl, webAccount, webFunction, webSystem, wifi, networkAdapter, status)
		{

		}

		#region para
		protected override void VariableSetting()
		{
		}
		#endregion

		#region ProcessState
		public override CommunicationStatus communicationStatus
		{
			get { return status.L2TPStatus; }
			set { status.L2TPStatus = value; }
		}
		public enum L2TPProcessState
		{
			Idle,
			SwitchToInternetPage,
			ChangeInternetConnectionToL2TP,
			SwitchToStatusPage,
			CheckIPAddressStatus,
			PingPrimaryDNS,
			Done,
		}
		L2TPProcessState autoState = L2TPProcessState.Idle;
		protected override object AutoState
		{
			get { return autoState; }
			set { autoState = (L2TPProcessState)value; }
		}
		protected override void WriteLogWhenAuto(object state, string optionalString="")
		{
			switch ((L2TPProcessState)state)
			{
				case L2TPProcessState.Idle:
					break;
				case L2TPProcessState.SwitchToInternetPage:
					msgLog.WriteLog(L2TPProcessState.SwitchToInternetPage, optionalString, Name);
					break;
				case L2TPProcessState.ChangeInternetConnectionToL2TP:
					msgLog.WriteLog(L2TPProcessState.ChangeInternetConnectionToL2TP, optionalString, Name);
					break;
				case L2TPProcessState.SwitchToStatusPage:
					msgLog.WriteLog(L2TPProcessState.SwitchToStatusPage, optionalString, Name);
					break;
				case L2TPProcessState.CheckIPAddressStatus:
					msgLog.WriteLog(L2TPProcessState.CheckIPAddressStatus, optionalString, Name);
					break;
				case L2TPProcessState.PingPrimaryDNS:
					msgLog.WriteLog(L2TPProcessState.CheckIPAddressStatus, optionalString, Name);
					break;
				case L2TPProcessState.Done:
					msgLog.WriteLog(L2TPProcessState.Done, optionalString, Name);
					break;
			}
		}
		#endregion

		#region ErrorState
		public enum L2TPProcessErrorState
		{
			None,                   // 狀態正常
			SelectDropDownListError,
			ClickGeneralButtonError,
			SetElementsValueError,
			MoveToSpecificSidePageError,
			PingTargetError,
		}
		L2TPProcessErrorState errorState = L2TPProcessErrorState.None;
		protected override object ErrorState
		{
			get { return errorState; }
			set { errorState = (L2TPProcessErrorState)value; }
		}
		protected override void WriteLogWhenError(object errorState, string optionalString)
		{
			switch ((L2TPProcessErrorState)errorState)
			{
				case L2TPProcessErrorState.SelectDropDownListError:
					msgLog.WriteLog(L2TPProcessErrorState.SelectDropDownListError, optionalString, Name);
					break;
				case L2TPProcessErrorState.ClickGeneralButtonError:
					msgLog.WriteLog(L2TPProcessErrorState.ClickGeneralButtonError, optionalString, Name);
					break;
				case L2TPProcessErrorState.MoveToSpecificSidePageError:
					msgLog.WriteLog(L2TPProcessErrorState.MoveToSpecificSidePageError, optionalString, Name);
					break;
				case L2TPProcessErrorState.SetElementsValueError:
					msgLog.WriteLog(L2TPProcessErrorState.SetElementsValueError, optionalString, Name);
					break;
				case L2TPProcessErrorState.PingTargetError:
					msgLog.WriteLog(L2TPProcessErrorState.PingTargetError, optionalString, Name);
					break;
				default:
					break;
			}
		}
		protected override void ErrorHandle()
		{
			switch (errorState)
			{
				case L2TPProcessErrorState.SelectDropDownListError:
					GoBackToAutoFromError();
					break;
				case L2TPProcessErrorState.ClickGeneralButtonError:
					GoBackToAutoFromError();
					break;
				case L2TPProcessErrorState.MoveToSpecificSidePageError:
					GoBackToAutoFromError();
					break;
				case L2TPProcessErrorState.SetElementsValueError:
					GoBackToAutoFromError();
					break;
				case L2TPProcessErrorState.PingTargetError:
					GoBackToAutoFromError();
					break;
				default:
					//GoBackToAutoFromError();
					break;
			}
		}
		protected override void AutoSequence()
		{
			switch (autoState)
			{
				case L2TPProcessState.Idle:
					GoToNewAutoState(L2TPProcessState.SwitchToInternetPage);
					break;
				case L2TPProcessState.SwitchToInternetPage:
					if (!webFunction.MoveToSpecificSidePage(1, "internet"))
						GoToErrorState(L2TPProcessErrorState.MoveToSpecificSidePageError, "SwitchToInternetPage");
					else
						GoToNewAutoState(L2TPProcessState.ChangeInternetConnectionToL2TP,"");
					break;
				case L2TPProcessState.ChangeInternetConnectionToL2TP:
					bool tempBool = true;
					if(!(tempBool = webFunction.SelectDropDownMenu("_linkType", 5)))
					{
						GoToErrorState(L2TPProcessErrorState.SelectDropDownListError, "ChangeInternetConnectionToL2TP");
						break;
					}
					Thread.Sleep(1000);
					if(!(tempBool &= webFunction.SetElementValue("usrL2TP", "l2tp")))
						GoToErrorState(L2TPProcessErrorState.SetElementsValueError, "設定L2TP的帳號(usrL2TP)輸入發生異常");
					else if (!(tempBool &= webFunction.SetElementValue("pwdL2TP", "l2tp")))
						GoToErrorState(L2TPProcessErrorState.SetElementsValueError, "設定L2TP的帳號(pwdL2TP)輸入發生異常");
					else if (!(tempBool &= webFunction.SetElementValue("serverIpOrNameL2TP", "10.0.0.20")))
						GoToErrorState(L2TPProcessErrorState.SetElementsValueError, "設定L2TP的Server IP(SetElementsValueError)輸入發生異常");
					else if (!(tempBool &= webFunction.ClickGeneralButton("saveBtn")))
						GoToErrorState(L2TPProcessErrorState.ClickGeneralButtonError, "ChangeInternetConnectionToDynamicIP");
					else if (tempBool)
					{
						GoToNewAutoState(L2TPProcessState.SwitchToStatusPage);
					}
					break;
				case L2TPProcessState.SwitchToStatusPage:
					if (!webFunction.MoveToSpecificSidePage(2, "status"))
						GoToErrorState(L2TPProcessErrorState.MoveToSpecificSidePageError, "SwitchToStatusPage");
					else
						GoToNewAutoState(L2TPProcessState.CheckIPAddressStatus);
					break;
				case L2TPProcessState.CheckIPAddressStatus:
					Thread.Sleep(1000);
					if ((webFunction.GetElementValue("IPV4")) == "NULL")
						GoToNewAutoState(L2TPProcessState.SwitchToStatusPage, "Element cannot find.");
					else if (webFunction.GetElementValue("IPV4") == "0.0.0.0")
					{
						Thread.Sleep(10000);
						GoToNewAutoState(L2TPProcessState.SwitchToStatusPage,"等待間隔時間後再次檢查是否取得 DHCP");
					}
					else
						GoToNewAutoState(L2TPProcessState.PingPrimaryDNS);
					break;
				case L2TPProcessState.PingPrimaryDNS:
					string tempStr;
					if (webFunction.GetElementValue("DNS1V4") == "NULL")
						GoToNewAutoState(L2TPProcessState.SwitchToStatusPage, "Element cannot find.");
					else if ((tempStr = webFunction.GetElementValue("DNS1V4")) == "0.0.0.0")
					{
						Thread.Sleep(1000);
						GoToNewAutoState(L2TPProcessState.SwitchToStatusPage, "等待間隔時間後再次檢查是否取得 DHCP");
					}else if ((webFunction.GetElementValue("connTypeV4")) != "L2TP")
						GoToNewAutoState(L2TPProcessState.SwitchToStatusPage, $"Connection Type Error");
					else if (!networkAdapter.Ping(tempStr))
					{
						Thread.Sleep(10000);
						GoToNewAutoState(L2TPProcessState.SwitchToStatusPage, "請確認是否有斷開其他網路連線");
					}
					else
						GoToNewAutoState(L2TPProcessState.Done);
					break;
				case L2TPProcessState.Done:
					communicationStatus = CommunicationStatus.Done;
					break;
			}
		}
		#endregion
	}
}
