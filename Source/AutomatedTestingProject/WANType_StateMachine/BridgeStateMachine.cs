using BasicLIbrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebLibrary;
using WindowsControl;

namespace StateMachine
{
	public class BridgeStateMachine : StateMachinesBase
	{
		public BridgeStateMachine(string Name,  CommonBase basicTool, BrowserControl browserControl, WebAccountControl webAccount,
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
			get { return status.BridgeStatus; }
			set { status.BridgeStatus = value; }
		}
		public enum BridgeProcessState
		{
			Idle,
			SwitchToAdvancedLANSettingPage,
			DHCPServerCloseDHCPFunction,
			SwitchToAdvancedInternetPage,
			RemoveAllWANInterfaces,
			AddABridgeInterface,
			SetComputerNetworkToDHCP,
			RebootComputerNetworkCard,
			CheckComputerNetworkCardInformation,
			SetComputerNetworkToStaticIP,
			RebootComputerNetworkCardAgain,
			LoginWebsite,
			SwitchToAdvancedLANSettingPageAgain,
			DHCPServerOpenDHCPFunction,
			SwitchToAdvancedInternetPageAgain,
			RemoveAllWANInterfacesAgain,
			SwitchToInternetPage,
			ChangeInternetConnectionToDynamicIP,
			SetComputerNetworkToDHCPAgain,
			Done,
		}
		BridgeProcessState autoState = BridgeProcessState.Idle;
		protected override object AutoState
		{
			get { return autoState; }
			set { autoState = (BridgeProcessState)value; }
		}
		protected override void WriteLogWhenAuto(object state, string optionalString="")
		{
			switch ((BridgeProcessState)state)
			{
				case BridgeProcessState.Idle:
					break;
				case BridgeProcessState.SwitchToAdvancedLANSettingPage:
					msgLog.WriteLog(BridgeProcessState.SwitchToAdvancedLANSettingPage, optionalString, Name);
					break;
				case BridgeProcessState.DHCPServerCloseDHCPFunction:
					msgLog.WriteLog(BridgeProcessState.DHCPServerCloseDHCPFunction, optionalString, Name);
					break;
				case BridgeProcessState.SwitchToAdvancedInternetPage:
					msgLog.WriteLog(BridgeProcessState.SwitchToAdvancedInternetPage, optionalString, Name);
					break;
				case BridgeProcessState.RemoveAllWANInterfaces:
					msgLog.WriteLog(BridgeProcessState.RemoveAllWANInterfaces, optionalString, Name);
					break;
				case BridgeProcessState.AddABridgeInterface:
					msgLog.WriteLog(BridgeProcessState.AddABridgeInterface, optionalString, Name);
					break;
				case BridgeProcessState.SetComputerNetworkToDHCP:
					msgLog.WriteLog(BridgeProcessState.SetComputerNetworkToDHCP, optionalString , Name);
					break;
				case BridgeProcessState.RebootComputerNetworkCard:
					msgLog.WriteLog(BridgeProcessState.RebootComputerNetworkCard, optionalString, Name);
					break;
				case BridgeProcessState.CheckComputerNetworkCardInformation:
					msgLog.WriteLog(BridgeProcessState.CheckComputerNetworkCardInformation, optionalString, Name);
					break;
				case BridgeProcessState.SetComputerNetworkToStaticIP:
					msgLog.WriteLog(BridgeProcessState.SetComputerNetworkToStaticIP, optionalString, Name);
					break;
				case BridgeProcessState.RebootComputerNetworkCardAgain:
					msgLog.WriteLog(BridgeProcessState.RebootComputerNetworkCardAgain, optionalString, Name);
					break;
				case BridgeProcessState.LoginWebsite:
					msgLog.WriteLog(BridgeProcessState.LoginWebsite, optionalString, Name);
					break;
				case BridgeProcessState.SwitchToAdvancedLANSettingPageAgain:
					msgLog.WriteLog(BridgeProcessState.SwitchToAdvancedLANSettingPageAgain, optionalString, Name);
					break;
				case BridgeProcessState.DHCPServerOpenDHCPFunction:
					msgLog.WriteLog(BridgeProcessState.DHCPServerOpenDHCPFunction, optionalString, Name);
					break;
				case BridgeProcessState.SwitchToAdvancedInternetPageAgain:
					msgLog.WriteLog(BridgeProcessState.SwitchToAdvancedInternetPageAgain, optionalString, Name);
					break;
				case BridgeProcessState.RemoveAllWANInterfacesAgain:
					msgLog.WriteLog(BridgeProcessState.RemoveAllWANInterfacesAgain, optionalString, Name);
					break;
				case BridgeProcessState.SwitchToInternetPage:
					msgLog.WriteLog(BridgeProcessState.SwitchToInternetPage, optionalString, Name);
					break;
				case BridgeProcessState.ChangeInternetConnectionToDynamicIP:
					msgLog.WriteLog(BridgeProcessState.ChangeInternetConnectionToDynamicIP, optionalString, Name);
					break;
				case BridgeProcessState.SetComputerNetworkToDHCPAgain:
					msgLog.WriteLog(BridgeProcessState.SetComputerNetworkToDHCPAgain, optionalString, Name);
					break;
				case BridgeProcessState.Done:
					msgLog.WriteLog(BridgeProcessState.Done, "Done", Name);
					break;
			}
		}
		#endregion

		#region ErrorState
		public enum BridgeProcessErrorState
		{
			None,                   // 狀態正常
			SelectDropDownListError,
			ClickGeneralButtonError,
			MoveToSpecificSidePageError,
			SetNetworkOfDHCPError,
			EnableInterfaceError,
			GetNetWorkCardIPInformationError,
			ComputerInterfaceGetDHCPError,
			SetNetworkOfStaticIPError,
		}
		BridgeProcessErrorState errorState = BridgeProcessErrorState.None;
		protected override object ErrorState
		{
			get { return errorState; }
			set { errorState = (BridgeProcessErrorState)value; }
		}
		protected override void WriteLogWhenError(object errorState, string optionalString)
		{
			switch ((BridgeProcessErrorState)errorState)
			{
				case BridgeProcessErrorState.SelectDropDownListError:
					msgLog.WriteLog(BridgeProcessErrorState.SelectDropDownListError, optionalString, Name);
					break;
				case BridgeProcessErrorState.ClickGeneralButtonError:
					msgLog.WriteLog(BridgeProcessErrorState.ClickGeneralButtonError, optionalString, Name);
					break;
				case BridgeProcessErrorState.MoveToSpecificSidePageError:
					msgLog.WriteLog(BridgeProcessErrorState.MoveToSpecificSidePageError, optionalString, Name);
					break;
				case BridgeProcessErrorState.SetNetworkOfDHCPError:
					msgLog.WriteLog(BridgeProcessErrorState.MoveToSpecificSidePageError, optionalString, Name);
					break;
				case BridgeProcessErrorState.EnableInterfaceError:
					msgLog.WriteLog(BridgeProcessErrorState.EnableInterfaceError, optionalString, Name);
					break;
				case BridgeProcessErrorState.GetNetWorkCardIPInformationError:
					msgLog.WriteLog(BridgeProcessErrorState.GetNetWorkCardIPInformationError, optionalString, Name);
					break;
				case BridgeProcessErrorState.ComputerInterfaceGetDHCPError:
					msgLog.WriteLog(BridgeProcessErrorState.ComputerInterfaceGetDHCPError, optionalString, Name);
					break;
				case BridgeProcessErrorState.SetNetworkOfStaticIPError:
					msgLog.WriteLog(BridgeProcessErrorState.SetNetworkOfStaticIPError, optionalString, Name);
					break;
				default:
					break;
			}
		}
		protected override void ErrorHandle()
		{
			switch (errorState)
			{
				case BridgeProcessErrorState.SelectDropDownListError:
					GoBackToAutoFromError();
					break;
				case BridgeProcessErrorState.ClickGeneralButtonError:
					GoBackToAutoFromError();
					break;
				case BridgeProcessErrorState.MoveToSpecificSidePageError:
					GoBackToAutoFromError();
					break;
				case BridgeProcessErrorState.SetNetworkOfDHCPError:
					GoBackToAutoFromError();
					break;
				case BridgeProcessErrorState.EnableInterfaceError:
					GoBackToAutoFromError();
					break;
				case BridgeProcessErrorState.GetNetWorkCardIPInformationError:
					GoBackToAutoFromError();
					break;
				case BridgeProcessErrorState.ComputerInterfaceGetDHCPError:
					GoBackToAutoFromError();
					break;
				case BridgeProcessErrorState.SetNetworkOfStaticIPError:
					GoBackToAutoFromError();
					break;
				default:
					break;
			}
		}
		protected override void AutoSequence()
		{
			switch (autoState)
			{
				case BridgeProcessState.Idle:
					GoToNewAutoState(BridgeProcessState.SwitchToAdvancedLANSettingPage);
					break;
				case BridgeProcessState.SwitchToAdvancedLANSettingPage:
					if (!webFunction.MoveToSpecificSidePage(2, "internet", "LANSettings"))
						GoToErrorState(BridgeProcessErrorState.MoveToSpecificSidePageError, "SwitchToAdvancedLANSettingPage");
					else
						GoToNewAutoState(BridgeProcessState.DHCPServerCloseDHCPFunction);
					break;
				case BridgeProcessState.DHCPServerCloseDHCPFunction:
					if (webFunction.IsElementDisplayed("domain")==false)
						GoToNewAutoState(BridgeProcessState.SwitchToAdvancedInternetPage);
					else if (!webFunction.ClickSelectBox("dhcpEn", 2))
						GoToErrorState(BridgeProcessErrorState.ClickGeneralButtonError, "Button id: deleteAll");
					else if (!webFunction.ClickGeneralButton("saveIPv4Ng"))
						GoToErrorState(BridgeProcessErrorState.ClickGeneralButtonError, "Button id: deleteAll");
					else
						GoToNewAutoState(BridgeProcessState.SwitchToAdvancedInternetPage);
					break;
				case BridgeProcessState.SwitchToAdvancedInternetPage:
					if (!webFunction.MoveToSpecificSidePage(2, "internet", "Internet"))
						GoToErrorState(BridgeProcessErrorState.MoveToSpecificSidePageError, "SwitchToAdvancedInternetPage");
					else
						GoToNewAutoState(BridgeProcessState.RemoveAllWANInterfaces);
					break;
				case BridgeProcessState.RemoveAllWANInterfaces:
					if (!webFunction.ClickGeneralButton("deleteAll"))
						GoToErrorState(BridgeProcessErrorState.ClickGeneralButtonError, "Button id: deleteAll");
					else
						GoToNewAutoState(BridgeProcessState.AddABridgeInterface);
					break;
				case BridgeProcessState.AddABridgeInterface:
					if (!webFunction.ClickGeneralButton("addConnIcon"))
					{
						GoToErrorState(BridgeProcessErrorState.ClickGeneralButtonError, "Button id: addConnIcon");
						break;
					}
					Thread.Sleep(500);
					if (!webFunction.SelectDropDownMenu("_link_type", 6))
						GoToErrorState(BridgeProcessErrorState.SelectDropDownListError, "AddABridgeInterface");
					else if (!webFunction.ClickGeneralButton("saveConnBtn"))
						GoToErrorState(BridgeProcessErrorState.ClickGeneralButtonError, "Button id: saveConnBtn");
					else
					{
						Thread.Sleep(1000);
						GoToNewAutoState(BridgeProcessState.SetComputerNetworkToDHCP);
					}
					break;
				case BridgeProcessState.SetComputerNetworkToDHCP:
					if (!networkAdapter.SetNetworkOfDHCP(config.WiredNetworkName, true))
						GoToErrorState(BridgeProcessErrorState.SetNetworkOfDHCPError, config.WiredNetworkName);
					else
					{
						Thread.Sleep(2000);
						GoToNewAutoState(BridgeProcessState.RebootComputerNetworkCard);
					}
					break;
				case BridgeProcessState.RebootComputerNetworkCard:
					if (!networkAdapter.EnableInterface(config.WiredNetworkName, false))
					{
						GoToErrorState(BridgeProcessErrorState.EnableInterfaceError, config.WiredNetworkName + " change to false");
						break;
					}
					Thread.Sleep(5000);
					if (!networkAdapter.EnableInterface(config.WiredNetworkName, true)) {
						GoToErrorState(BridgeProcessErrorState.EnableInterfaceError, config.WiredNetworkName + " change to true");
						break;
					}
					else
					{
						Thread.Sleep(5000);
						GoToNewAutoState(BridgeProcessState.CheckComputerNetworkCardInformation);
					}
					break;
				case BridgeProcessState.CheckComputerNetworkCardInformation:
					IPInterfaceProperties temp;
					if ((temp = networkAdapter.GetNetWorkCardIPInformation(config.WiredNetworkName)) == null)
						GoToErrorState(BridgeProcessErrorState.GetNetWorkCardIPInformationError, config.WiredNetworkName + " change to true");

					foreach (var element in temp.UnicastAddresses)
					{
						if (element.Address.ToString().Contains("."))
						{
							if (element.Address.ToString().Split('.')[0] == "10")
							{
								GoToNewAutoState(BridgeProcessState.SetComputerNetworkToStaticIP);
								break;
							}
							else
							{
								GoToErrorState(BridgeProcessErrorState.GetNetWorkCardIPInformationError, element.Address.ToString());
								break;
							}
						}
					}
					break;
				case BridgeProcessState.SetComputerNetworkToStaticIP:
					if (!networkAdapter.SetNetworkOfStaticIP(config.WiredNetworkName, config.StaticIPForBridge,config.StaticSubnetMaskForBridge))
						GoToErrorState(BridgeProcessErrorState.SetNetworkOfStaticIPError, config.WiredNetworkName);
					else
						GoToNewAutoState(BridgeProcessState.RebootComputerNetworkCardAgain);
					break;
				case BridgeProcessState.RebootComputerNetworkCardAgain:
					if (!networkAdapter.EnableInterface(config.WiredNetworkName, false))
					{
						GoToErrorState(BridgeProcessErrorState.EnableInterfaceError, config.WiredNetworkName + " change to false");
						break;
					}
					Thread.Sleep(5000);
					if (!networkAdapter.EnableInterface(config.WiredNetworkName, true))
					{
						GoToErrorState(BridgeProcessErrorState.EnableInterfaceError, config.WiredNetworkName + " change to true");
						break;
					}
					else
					{
						Thread.Sleep(5000);
						GoToNewAutoState(BridgeProcessState.LoginWebsite);
					}
					break;
				case BridgeProcessState.LoginWebsite:
					string tempStr="";
					if (!IsReady(ref tempStr))
						Thread.Sleep(5000);
					else
						GoToNewAutoState(BridgeProcessState.SwitchToAdvancedLANSettingPageAgain);
					break;
				case BridgeProcessState.SwitchToAdvancedLANSettingPageAgain:
					if (!webFunction.MoveToSpecificSidePage(2, "internet", "LANSettings"))
						GoToErrorState(BridgeProcessErrorState.MoveToSpecificSidePageError, "SwitchToAdvancedLANSettingPageAgain");
					else
						GoToNewAutoState(BridgeProcessState.DHCPServerOpenDHCPFunction);
					break;
				case BridgeProcessState.DHCPServerOpenDHCPFunction:
					if (webFunction.IsElementDisplayed("domain") == true)
						GoToNewAutoState(BridgeProcessState.SwitchToAdvancedInternetPageAgain);
					else if (!webFunction.ClickSelectBox("dhcpEn", 2))
						GoToErrorState(BridgeProcessErrorState.ClickGeneralButtonError, "Button id: deleteAll");
					else if (!webFunction.ClickGeneralButton("saveIPv4Ng"))
						GoToErrorState(BridgeProcessErrorState.ClickGeneralButtonError, "Button id: deleteAll");
					else
						GoToNewAutoState(BridgeProcessState.SwitchToAdvancedInternetPageAgain);
					break;
				case BridgeProcessState.SwitchToAdvancedInternetPageAgain:
					if (!webFunction.MoveToSpecificSidePage(2, "internet", "Internet"))
						GoToErrorState(BridgeProcessErrorState.MoveToSpecificSidePageError, "SwitchToAdvancedInternetPageAgain");
					else
						GoToNewAutoState(BridgeProcessState.RemoveAllWANInterfacesAgain);
					break;
				case BridgeProcessState.RemoveAllWANInterfacesAgain:
					if (!webFunction.ClickGeneralButton("deleteAll"))
						GoToErrorState(BridgeProcessErrorState.ClickGeneralButtonError, "Button id: deleteAll");
					else
						GoToNewAutoState(BridgeProcessState.SwitchToInternetPage);
					break;
				case BridgeProcessState.SwitchToInternetPage:
					if (!webFunction.MoveToSpecificSidePage(1, "internet"))
						GoToErrorState(BridgeProcessErrorState.MoveToSpecificSidePageError, "SwitchToInternetPage");
					else
						GoToNewAutoState(BridgeProcessState.ChangeInternetConnectionToDynamicIP);
					break;
				case BridgeProcessState.ChangeInternetConnectionToDynamicIP:
					bool tempBool = true;
					if (!(tempBool = webFunction.SelectDropDownMenu("_linkType", 2)))
					{
						GoToErrorState(BridgeProcessErrorState.SelectDropDownListError, "ChangeInternetConnectionToDynamicIP");
						break;
					}
					Thread.Sleep(1000);
					if (!(tempBool &= webFunction.ClickGeneralButton("saveBtn")))
						GoToErrorState(BridgeProcessErrorState.ClickGeneralButtonError, "ChangeInternetConnectionToDynamicIP");
					else if (tempBool)
						GoToNewAutoState(BridgeProcessState.SetComputerNetworkToDHCPAgain);
					break;
				case BridgeProcessState.SetComputerNetworkToDHCPAgain:
					if (!networkAdapter.SetNetworkOfDHCP(config.WiredNetworkName, true))
						GoToErrorState(BridgeProcessErrorState.SetNetworkOfDHCPError, config.WiredNetworkName);
					else
					{
						Thread.Sleep(10000);
						GoToNewAutoState(BridgeProcessState.Done);
					}
					break;
				case BridgeProcessState.Done:
					communicationStatus = CommunicationStatus.Done;
					break;
			}
		}
		#endregion
	}
}
