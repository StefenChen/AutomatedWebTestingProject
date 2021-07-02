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
	public class DHCPStateMachine : StateMachinesBase
	{
		public DHCPStateMachine(string Name,  CommonBase basicTool, BrowserControl browserControl, WebAccountControl webAccount,
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
			get { return status.DHCPStatus; }
			set { status.DHCPStatus = value; }
		}
		public enum DHCPProcessState
		{
			Idle,
			SwitchToInternetPage,
			ChangeInternetConnectionToDynamicIP,
			SwitchToStatusPage,
			CheckIPAddressStatus,
			Done,
		}
		DHCPProcessState autoState = DHCPProcessState.Idle;
		protected override object AutoState
		{
			get { return autoState; }
			set { autoState = (DHCPProcessState)value; }
		}
		protected override void WriteLogWhenAuto(object state, string optionalString="")
		{
			switch ((DHCPProcessState)state)
			{
				case DHCPProcessState.Idle:
					break;
				case DHCPProcessState.SwitchToInternetPage:
					msgLog.WriteLog(DHCPProcessState.SwitchToInternetPage, optionalString, Name);
					break;
				case DHCPProcessState.ChangeInternetConnectionToDynamicIP:
					msgLog.WriteLog(DHCPProcessState.ChangeInternetConnectionToDynamicIP, optionalString, Name);
					break;
				case DHCPProcessState.SwitchToStatusPage:
					msgLog.WriteLog(DHCPProcessState.SwitchToStatusPage, optionalString, Name);
					break;
				case DHCPProcessState.CheckIPAddressStatus:
					msgLog.WriteLog(DHCPProcessState.CheckIPAddressStatus, optionalString , Name);
					break;
				case DHCPProcessState.Done:
					msgLog.WriteLog(DHCPProcessState.Done, "Done", Name);
					break;
			}
		}
		#endregion

		#region ErrorState
		public enum DHCPProcessErrorState
		{
			None,                   // 狀態正常
			SelectDropDownListError,
			ClickGeneralButtonError,
			MoveToSpecificSidePageError,
		}
		DHCPProcessErrorState errorState = DHCPProcessErrorState.None;
		protected override object ErrorState
		{
			get { return errorState; }
			set { errorState = (DHCPProcessErrorState)value; }
		}
		protected override void WriteLogWhenError(object errorState, string optionalString)
		{
			switch ((DHCPProcessErrorState)errorState)
			{
				case DHCPProcessErrorState.SelectDropDownListError:
					msgLog.WriteLog(DHCPProcessErrorState.SelectDropDownListError, optionalString, Name);
					break;
				case DHCPProcessErrorState.ClickGeneralButtonError:
					msgLog.WriteLog(DHCPProcessErrorState.ClickGeneralButtonError, optionalString, Name);
					break;
				case DHCPProcessErrorState.MoveToSpecificSidePageError:
					msgLog.WriteLog(DHCPProcessErrorState.MoveToSpecificSidePageError, optionalString, Name);
					break;
				default:
					break;
			}
		}
		protected override void ErrorHandle()
		{
			switch (errorState)
			{
				case DHCPProcessErrorState.SelectDropDownListError:
					GoBackToAutoFromError();
					break;
				case DHCPProcessErrorState.ClickGeneralButtonError:
					GoBackToAutoFromError();
					break;
				case DHCPProcessErrorState.MoveToSpecificSidePageError:
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
				case DHCPProcessState.Idle:
					GoToNewAutoState(DHCPProcessState.SwitchToInternetPage);
					break;
				case DHCPProcessState.SwitchToInternetPage:
					if (!webFunction.MoveToSpecificSidePage(1, "internet"))
						GoToErrorState(DHCPProcessErrorState.MoveToSpecificSidePageError, "SwitchToInternetPage");
					else
						GoToNewAutoState(DHCPProcessState.ChangeInternetConnectionToDynamicIP);
					break;
				case DHCPProcessState.ChangeInternetConnectionToDynamicIP:
					bool tempBool = true;
					if(!(tempBool = webFunction.SelectDropDownMenu("_linkType", 2)))
					{
						GoToErrorState(DHCPProcessErrorState.SelectDropDownListError, "ChangeInternetConnectionToDynamicIP");
						break;
					}
					Thread.Sleep(1000);
					if (!(tempBool &= webFunction.ClickGeneralButton("saveBtn")))
						GoToErrorState(DHCPProcessErrorState.ClickGeneralButtonError, "ChangeInternetConnectionToDynamicIP");
					else if (tempBool)
						GoToNewAutoState(DHCPProcessState.SwitchToStatusPage);
					break;
				case DHCPProcessState.SwitchToStatusPage:
					if (!webFunction.MoveToSpecificSidePage(2, "status"))
						GoToErrorState(DHCPProcessErrorState.MoveToSpecificSidePageError, "SwitchToStatusPage");
					else
						GoToNewAutoState(DHCPProcessState.CheckIPAddressStatus);
					break;
				case DHCPProcessState.CheckIPAddressStatus:
					string tempStr;
					Thread.Sleep(1000);
					if (webFunction.GetElementValue("IPV4") == "NULL")
						GoToNewAutoState(DHCPProcessState.SwitchToStatusPage, "Element cannot find.");
					else if ((tempStr = webFunction.GetElementValue("IPV4")) == "0.0.0.0")
					{
						Thread.Sleep(500);
						GoToNewAutoState(DHCPProcessState.SwitchToStatusPage);
					}
					else
						GoToNewAutoState(DHCPProcessState.Done);
					break;
				case DHCPProcessState.Done:
					Stop();
					communicationStatus = CommunicationStatus.Done;
					break;
			}
		}
	}
}
