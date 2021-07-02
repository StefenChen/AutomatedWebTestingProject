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
			VariableSetting();
		}

		#region para
		private List<string> staticIPBasic;
		protected override bool VariableSetting()
		{
			staticIPBasic = new List<string>();
			staticIPBasic.Add(config.StaticIPAddress);
			staticIPBasic.Add(config.StaticSubnetMask);
			staticIPBasic.Add(config.StaticDefaultGateway);
			staticIPBasic.Add(config.StaticPrimaryDNS);
			staticIPBasic.Add(config.StaticSecondaryDNS);
			return true;
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
		public enum PPPoEProcessErrorState
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
				case PPPoEProcessErrorState.SwitchToStatusPageError:
					msgLog.WriteLog(PPPoEProcessErrorState.SwitchToStatusPageError, optionalString, Name);
					break;
				case PPPoEProcessErrorState.CannotFindElementsError:
					msgLog.WriteLog(PPPoEProcessErrorState.CannotFindElementsError, optionalString, Name);
					break;
				case PPPoEProcessErrorState.GetValueResultError:
					msgLog.WriteLog(PPPoEProcessErrorState.GetValueResultError, optionalString, Name);
					break;
				case PPPoEProcessErrorState.SettingInputBoxError:
					msgLog.WriteLog(PPPoEProcessErrorState.SettingInputBoxError, optionalString, Name);
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
				case PPPoEProcessErrorState.SwitchToStatusPageError:
					GoBackToAutoFromError();
					break;
				case PPPoEProcessErrorState.CannotFindElementsError:
					GoBackToAutoFromError();
					break;
				case PPPoEProcessErrorState.GetValueResultError:
					GoBackToAutoFromError();
					break;
				case PPPoEProcessErrorState.SettingInputBoxError:
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
			switch (autoState)
			{
				case StaticIPProcessState.Idle:
					GoToNewAutoState(StaticIPProcessState.SwitchToInternetPage);
					break;
				case StaticIPProcessState.SwitchToInternetPage:
					if (!webFunction.MoveToSpecificSidePage(1, "internet"))
						GoToErrorState(PPPoEProcessErrorState.MoveToSpecificSidePageError, "SwitchToInternetPage");
					else
						GoToNewAutoState(StaticIPProcessState.SetWANInterface);
					break;
				case StaticIPProcessState.SetWANInterface:
					bool tempBool = true;
					int countItem = 0, countNode = 0;
					if (!webFunction.IsElementDisplayed("_linkType"))
					{
						GoToErrorState(PPPoEProcessErrorState.CannotFindElementsError, "DropDownMenu:_linkType");
						break;
					}
					else if(!(tempBool = webFunction.SelectDropDownMenu("_linkType", 3)))
					{
						GoToErrorState(PPPoEProcessErrorState.SelectDropDownListError, "DropDownMenu:_linkType");
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
								{
									GoToErrorState(PPPoEProcessErrorState.SettingInputBoxError, "StaticIP Setting Error");
									break;
								}
									
								countNode += 2;
							}
							countNode = 0;
							countItem++;
						}
						if (!(tempBool &= webFunction.ClickGeneralButton("saveBtn")))
							GoToErrorState(PPPoEProcessErrorState.ClickGeneralButtonError, "saveBtn");
						Thread.Sleep(3000);
					}
					if (tempBool)
						GoToNewAutoState(StaticIPProcessState.SwitchToStatusPage);
					break;
				case StaticIPProcessState.SwitchToStatusPage:
					if (!webFunction.MoveToSpecificSidePage(2, "status"))
					{
						GoToErrorState(PPPoEProcessErrorState.SwitchToStatusPageError, "SwitchToStatusPage");
					}
					else
						GoToNewAutoState(StaticIPProcessState.CheckIPAddressStatus);
					Thread.Sleep(1000);
					break;
				case StaticIPProcessState.CheckIPAddressStatus:
					string tempStr;
					if (!(staticIPBasic[0] == (tempStr = webFunction.GetElementValue("IPV4"))))
					{
						GoToErrorState(PPPoEProcessErrorState.SettingInputBoxError, $"Get value is different between \"{staticIPBasic[0]}\" and \"{tempStr}\"");
						break;
					}
					else
						GoToNewAutoState(StaticIPProcessState.Done);
					break;
				case StaticIPProcessState.Done:
					Stop();
					communicationStatus = CommunicationStatus.Done;
					break;
			}
		}
		
	}
}
