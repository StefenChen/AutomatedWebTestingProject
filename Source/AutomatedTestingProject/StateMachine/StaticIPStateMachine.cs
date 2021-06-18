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
	public class StaticIPStateMachine : StateMachinesBase
	{

		public StaticIPStateMachine(string Name,  CommonBase basicTool, BrowserControl browserControl, WebAccountControl webAccount,
								WebFunctionControl webFunction, WebSystemControl webSystem,
								WifiControl wifi, NetworkAdapterControl networkAdapter,Communication status)
			: base(Name, basicTool, browserControl, webAccount, webFunction, webSystem, wifi, networkAdapter, status)
		{

		}

		#region para
		private List<string> staticIPBasic;
		protected override void VariableSetting()
		{
			staticIPBasic = new List<string>();
			staticIPBasic.Add(config.StaticIPAddress);
			staticIPBasic.Add(config.StaticSubnetMask);
			staticIPBasic.Add(config.StaticDefaultGateway);
			staticIPBasic.Add(config.StaticPrimaryDNS);
			staticIPBasic.Add(config.StaticSecondaryDNS);
		}
		#endregion

		#region ProcessState
		public override CommunicationStatus communicationStatus
		{
			get { return status.StaticIPStatus; }
			set { status.StaticIPStatus = value; }
		}
		public enum StaticIPProcessState
		{
			Idle,
			SwitchToInternetPage,
			SetWANInterface,
			SwitchToStatusPage,
			CheckIPAddressStatus,
			Done,
		}
		StaticIPProcessState autoState = StaticIPProcessState.Idle;
		protected override object AutoState
		{
			get { return autoState; }
			set { autoState = (StaticIPProcessState)value; }
		}
		protected override void WriteLogWhenAuto(object state, string optionalString="")
		{
			switch ((StaticIPProcessState)state)
			{
				case StaticIPProcessState.Idle:
					break;
				case StaticIPProcessState.SwitchToInternetPage:
					msgLog.WriteLog(StaticIPProcessState.SwitchToInternetPage, "SwitchToInternetPage", Name);
					break;
				case StaticIPProcessState.SetWANInterface:
					msgLog.WriteLog(StaticIPProcessState.SetWANInterface, "SetWANInterface", Name);
					break;
				case StaticIPProcessState.SwitchToStatusPage:
					msgLog.WriteLog(StaticIPProcessState.SwitchToStatusPage, "SwitchToStatusPage", Name);
					break;
				case StaticIPProcessState.CheckIPAddressStatus:
					msgLog.WriteLog(StaticIPProcessState.CheckIPAddressStatus, "CheckIPAddressStatus", Name);
					break;
				case StaticIPProcessState.Done:
					msgLog.WriteLog(StaticIPProcessState.Done, "Done", Name);
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
			SwitchToStatusPageError,
			CannotFindElementsError,
			GetValueResultError,
			SettingInputBoxError,
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
				case DHCPProcessErrorState.SwitchToStatusPageError:
					msgLog.WriteLog(DHCPProcessErrorState.SwitchToStatusPageError, optionalString, Name);
					break;
				case DHCPProcessErrorState.CannotFindElementsError:
					msgLog.WriteLog(DHCPProcessErrorState.CannotFindElementsError, optionalString, Name);
					break;
				case DHCPProcessErrorState.GetValueResultError:
					msgLog.WriteLog(DHCPProcessErrorState.GetValueResultError, optionalString, Name);
					break;
				case DHCPProcessErrorState.SettingInputBoxError:
					msgLog.WriteLog(DHCPProcessErrorState.SettingInputBoxError, optionalString, Name);
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
				case DHCPProcessErrorState.SwitchToStatusPageError:
					GoBackToAutoFromError();
					break;
				case DHCPProcessErrorState.CannotFindElementsError:
					GoBackToAutoFromError();
					break;
				case DHCPProcessErrorState.GetValueResultError:
					GoBackToAutoFromError();
					break;
				case DHCPProcessErrorState.SettingInputBoxError:
					GoBackToAutoFromError();
					break;
				default:
					GoBackToAutoFromError();
					break;
			}
		}
		#endregion
		protected override void AutoSequence()
		{
			bool tempBool = true;
			int countItem = 0, countNode = 0;
			string globalStr;
			switch (autoState)
			{
				case StaticIPProcessState.Idle:
					GoToNewAutoState(StaticIPProcessState.SwitchToInternetPage);
					break;
				case StaticIPProcessState.SwitchToInternetPage:
					if (!webFunction.MoveToSpecificSidePage(1, "internet"))
						GoToErrorState(DHCPProcessErrorState.MoveToSpecificSidePageError, "SwitchToInternetPage");
					else
						GoToNewAutoState(StaticIPProcessState.SetWANInterface);
					break;
				case StaticIPProcessState.SetWANInterface:
					if (!webFunction.IsElementDisplayed("_linkType"))
					{
						GoToErrorState(DHCPProcessErrorState.CannotFindElementsError, "DropDownMenu:_linkType");
						break;
					}
					else if(!(tempBool = webFunction.SelectDropDownMenu("_linkType", 3)))
					{
						GoToErrorState(DHCPProcessErrorState.SelectDropDownListError, "DropDownMenu:_linkType");
						break;
					}
					if (tempBool)
					{
						foreach (string tempAddress in staticIPBasic)
						{
							foreach (string partStr in tempAddress.Split('.'))
							{
								if (!(tempBool &= webFunction.DesignYourJSFunction("StaticIPBasic",
																					$"elements.children[{countItem}].children[2].children[{countNode}].value={partStr}")))
									GoToErrorState(DHCPProcessErrorState.ClickGeneralButtonError, "s");
								countNode += 2;
							}
							countNode = 0;
							countItem++;
						}
						if (!(tempBool &= webFunction.ClickGeneralButton("saveBtn")))
							GoToErrorState(DHCPProcessErrorState.ClickGeneralButtonError, "saveBtn");
						Thread.Sleep(3000);
					}
					if (tempBool)
						//GoToNewAutoState(StaticIPProcessState.SetNetworkCardToDHCP);
						GoToNewAutoState(StaticIPProcessState.SwitchToStatusPage);
					break;
				case StaticIPProcessState.SwitchToStatusPage:
					if (!webFunction.MoveToSpecificSidePage(2, "status"))
					{
						GoToErrorState(DHCPProcessErrorState.SwitchToStatusPageError, "SwitchToStatusPage");
					}
					else
						GoToNewAutoState(StaticIPProcessState.CheckIPAddressStatus);
					Thread.Sleep(1000);
					break;
				case StaticIPProcessState.CheckIPAddressStatus:
					tempBool = true;
					if (!(staticIPBasic[0] == (globalStr = webFunction.GetElementValue("IPV4"))))
					{
						GoToErrorState(DHCPProcessErrorState.SettingInputBoxError, $"Get value is different between \"{staticIPBasic[0]}\" and \"{globalStr}\"");
						break;
					}
					else
						GoToNewAutoState(StaticIPProcessState.Done);
					break;
				case StaticIPProcessState.Done:
					communicationStatus = CommunicationStatus.Done;
					break;
			}
		}
		
	}
}
