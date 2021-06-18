using BasicLIbrary;
using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
// System.Net.NetworkInformation;

namespace WindowsControl
{
	public class NetworkAdapterControl
	{
		private Process process = null;
		private ProcessStartInfo psi = null;
		private CommonBase basicTool = null;

		public NetworkAdapterControl(CommonBase basicTool)
		{
			this.basicTool = basicTool;
		}

		/// <summary>
		/// 程式或VS要開Admin權限才能使用。
		/// </summary>
		/// <param name="idName">Interface Name</param>
		/// <param name="ipAddress"></param>
		/// <param name="submesk"></param>
		/// <param name="gateWay"></param>
		public bool SetNetworkOfStaticIP(string idName, string ipAddress, string submesk, string gateWay = "")
		{
			try
			{
				process = new Process();
				psi = new ProcessStartInfo("netsh", "interface ip set address \"" + idName + "\" static " + ipAddress + " " + submesk + " " + gateWay);
				process.StartInfo = psi;
				return process.Start();
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.NetworkCard, ex.ToString(), "SetNetworkOfStaticIP");
				return false;
			}
		}
		/// <summary>
		/// 程式或VS要開Admin權限才能使用。
		/// </summary>
		/// <param name="idName">Interface Name</param>
		/// <returns></returns>
		public bool SetNetworkOfDHCP(string idName, bool enable)
		{
			try
			{
				//查詢當前狀態的Power Shell指令
				//Get-NetIPAddress -InterfaceAlias 'Wi-Fi'
				process = new Process();
				psi = new ProcessStartInfo("PowerShell", "Set-NetIPInterface -InterfaceAlias \'" + idName + "\' -Dhcp " + (enable ? "Enable" : "Disable"));
				process.StartInfo = psi;
				return process.Start();
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.NetworkCard, ex.ToString(), "SetNetworkOfDHCP");
				return false;
			}
		}
		/// <summary>
		/// 程式或VS要開Admin權限才能使用。
		/// </summary>
		/// <param name="idName">Interface Name</param>
		/// <param name="enable"></param>
		/// <returns></returns>
		public bool EnableInterface(string idName, bool enable)
		{
			try
			{
				process = new Process();
				psi = new ProcessStartInfo("netsh", "interface set interface \"" + idName + "\" " + (enable ? "Enable" : "Disable"));
				process.StartInfo = psi;
				return process.Start();
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.NetworkCard, ex.ToString(), "EnableInterface");
				return false;
			}
		}

		public bool Ping(string target)
		{
			try
			{
				Ping pingSender = new Ping();
				PingReply reply = pingSender.Send(target, 1000);//第一個引數為ip地址,第二個引數為ping的時間

				if (reply.Status == IPStatus.Success)
				{
					return true;//ping通
				}
				else
				{
					return false;//ping不通
				}
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.NetworkCard, ex.ToString(), "Ping");
				return false;
			}
		}
	}

}
