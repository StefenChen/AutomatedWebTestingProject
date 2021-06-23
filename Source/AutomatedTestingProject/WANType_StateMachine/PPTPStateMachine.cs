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
	public class PPTPStateMachine : StateMachinesBase
	{
		public PPTPStateMachine(string Name,  CommonBase basicTool, BrowserControl browserControl, WebAccountControl webAccount,
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
			get { return status.PPTPStatus; }
			set { status.PPTPStatus = value; }
		}
		public enum PPTPProcessState
		{
			Idle,
			SwitchToInternetPage,
			ChangeInternetConnectionToPPTP,
			SwitchToStatusPage,
			CheckIPAddressStatus,
			PingPrimaryDNS,
			Done,
		}
		PPTPProcessState autoState = PPTPProcessState.Idle;
		protected override object AutoState
		{
			get { return autoState; }
			set { autoState = (PPTPProcessState)value; }
		}
		protected override void WriteLogWhenAuto(object state, string optionalString="")
		{
			switch ((PPTPProcessState)state)
			{
				case PPTPProcessState.Idle:
					break;
				case PPTPProcessState.SwitchToInternetPage:
					msgLog.WriteLog(PPTPProcessState.SwitchToInternetPage, optionalString, Name);
					break;
				case PPTPProcessState.ChangeInternetConnectionToPPTP:
					msgLog.WriteLog(PPTPProcessState.ChangeInternetConnectionToPPTP, optionalString, Name);
					break;
				case PPTPProcessState.SwitchToStatusPage:
					msgLog.WriteLog(PPTPProcessState.SwitchToStatusPage, optionalString, Name);
					break;
				case PPTPProcessState.CheckIPAddressStatus:
					msgLog.WriteLog(PPTPProcessState.CheckIPAddressStatus, optionalString, Name);
					break;
				case PPTPProcessState.PingPrimaryDNS:
					msgLog.WriteLog(PPTPProcessState.CheckIPAddressStatus, optionalString, Name);
					break;
				case PPTPProcessState.Done:
					msgLog.WriteLog(PPTPProcessState.Done, optionalString, Name);
					break;
			}
		}
		#endregion

		#region ErrorState
		public enum PPTPProcessErrorState
		{
			None,                   // 狀態正常
			SelectDropDownListError,
			ClickGeneralButtonError,
			SetElementsValueError,
			MoveToSpecificSidePageError,
			PingTargetError,
		}
		PPTPProcessErrorState errorState = PPTPProcessErrorState.None;
		protected override object ErrorState
		{
			get { return errorState; }
			set { errorState = (PPTPProcessErrorState)value; }
		}
		protected override void WriteLogWhenError(object errorState, string optionalString)
		{
			switch ((PPTPProcessErrorState)errorState)
			{
				case PPTPProcessErrorState.SelectDropDownListError:
					msgLog.WriteLog(PPTPProcessErrorState.SelectDropDownListError, optionalString, Name);
					break;
				case PPTPProcessErrorState.ClickGeneralButtonError:
					msgLog.WriteLog(PPTPProcessErrorState.ClickGeneralButtonError, optionalString, Name);
					break;
				case PPTPProcessErrorState.MoveToSpecificSidePageError:
					msgLog.WriteLog(PPTPProcessErrorState.MoveToSpecificSidePageError, optionalString, Name);
					break;
				case PPTPProcessErrorState.SetElementsValueError:
					msgLog.WriteLog(PPTPProcessErrorState.SetElementsValueError, optionalString, Name);
					break;
				case PPTPProcessErrorState.PingTargetError:
					msgLog.WriteLog(PPTPProcessErrorState.PingTargetError, optionalString, Name);
					break;
				default:
					break;
			}
		}
		protected override void ErrorHandle()
		{
			switch (errorState)
			{
				case PPTPProcessErrorState.SelectDropDownListError:
					GoBackToAutoFromError();
					break;
				case PPTPProcessErrorState.ClickGeneralButtonError:
					GoBackToAutoFromError();
					break;
				case PPTPProcessErrorState.MoveToSpecificSidePageError:
					GoBackToAutoFromError();
					break;
				case PPTPProcessErrorState.SetElementsValueError:
					GoBackToAutoFromError();
					break;
				case PPTPProcessErrorState.PingTargetError:
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
				case PPTPProcessState.Idle:
					GoToNewAutoState(PPTPProcessState.SwitchToInternetPage);
					break;
				case PPTPProcessState.SwitchToInternetPage:
					if (!webFunction.MoveToSpecificSidePage(1, "internet"))
						GoToErrorState(PPTPProcessErrorState.MoveToSpecificSidePageError, "SwitchToInternetPage");
					else
						GoToNewAutoState(PPTPProcessState.ChangeInternetConnectionToPPTP,"");
					break;
				case PPTPProcessState.ChangeInternetConnectionToPPTP:
					bool tempBool = true;
					if(!(tempBool = webFunction.SelectDropDownMenu("_linkType", 4)))
					{
						GoToErrorState(PPTPProcessErrorState.SelectDropDownListError, "ChangeInternetConnectionToPPTP");
						break;
					}
					Thread.Sleep(1000);
					if(!(tempBool &= webFunction.SetElementValue("usrPPTP", "pptp")))
						GoToErrorState(PPTPProcessErrorState.SetElementsValueError, "設定PPTP的帳號(usrPPTP)輸入發生異常");
					else if (!(tempBool &= webFunction.SetElementValue("pwdPPTP", "pptp")))
						GoToErrorState(PPTPProcessErrorState.SetElementsValueError, "設定PPTP的帳號(pwdPPTP)輸入發生異常");
					else if (!(tempBool &= webFunction.SetElementValue("serverIpOrNamePPTP", "10.0.0.20")))
						GoToErrorState(PPTPProcessErrorState.SetElementsValueError, "設定PPTP的Server IP(SetElementsValueError)輸入發生異常");
					else if (!(tempBool &= webFunction.ClickGeneralButton("saveBtn")))
						GoToErrorState(PPTPProcessErrorState.ClickGeneralButtonError, "ChangeInternetConnectionToDynamicIP");
					else if (tempBool)
					{
						GoToNewAutoState(PPTPProcessState.SwitchToStatusPage);
					}
					break;
				case PPTPProcessState.SwitchToStatusPage:
					if (!webFunction.MoveToSpecificSidePage(2, "status"))
						GoToErrorState(PPTPProcessErrorState.MoveToSpecificSidePageError, "SwitchToStatusPage");
					else
						GoToNewAutoState(PPTPProcessState.CheckIPAddressStatus);
					break;
				case PPTPProcessState.CheckIPAddressStatus:
					Thread.Sleep(1000);
					if (webFunction.GetElementValue("IPV4") == "NULL")
						GoToNewAutoState(PPTPProcessState.SwitchToStatusPage, "Element cannot find.");
					else if (webFunction.GetElementValue("IPV4") == "0.0.0.0")
					{
						Thread.Sleep(10000);
						GoToNewAutoState(PPTPProcessState.SwitchToStatusPage,"等待間隔時間後再次檢查是否取得 DHCP");
					}
					else
						GoToNewAutoState(PPTPProcessState.PingPrimaryDNS);
					break;
				case PPTPProcessState.PingPrimaryDNS:
					string tempStr;
					if (webFunction.GetElementValue("DNS1V4") == "NULL")
						GoToNewAutoState(PPTPProcessState.SwitchToStatusPage, "Element cannot find.");
					else if ((tempStr = webFunction.GetElementValue("DNS1V4")) == "0.0.0.0")
					{
						Thread.Sleep(1000);
						GoToNewAutoState(PPTPProcessState.SwitchToStatusPage, "等待間隔時間後再次檢查是否取得 DHCP");
					}else if ((webFunction.GetElementValue("connTypeV4")) != "PPTP")
						GoToNewAutoState(PPTPProcessState.SwitchToStatusPage, $"Connection Type Error");
					else if (!networkAdapter.Ping(tempStr))
					{
						Thread.Sleep(10000);
						GoToNewAutoState(PPTPProcessState.SwitchToStatusPage, "請確認是否有斷開其他網路連線");
					}
					else
						GoToNewAutoState(PPTPProcessState.Done);
					break;
				case PPTPProcessState.Done:
					communicationStatus = CommunicationStatus.Done;
					break;
			}
		}
		#endregion
	}
}
