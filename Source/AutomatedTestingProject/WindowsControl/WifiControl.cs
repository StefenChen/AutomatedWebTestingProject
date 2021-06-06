using BasicLIbrary;
using ManagedNativeWifi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WindowsControl
{
	public class WifiControl : WifiProfile
	{
		private Guid interfaceId;
		public WifiControl(CommonBase basicTool, Category _type) : base(basicTool, _type)
		{

		}
		public bool ConnectWifi()
		{
			try
			{
				//Turn on radio interface.
				TurnOnAsync();
				//Set interfaceId.
				SetInterfaceId();
				//Overwrote Profile.
				SetProfile(interfaceId, basicTool.accessConfig.SsidName, basicTool.accessConfig.SsidPasswd);
				foreach (var ssid in EnumerateNetworkSsids())
				{
					if (ssid == basicTool.accessConfig.SsidName)
					{
						ConnectAsync(basicTool.accessConfig.SsidName);
						RefreshAsync();
						return true;
					}
				}
				basicTool.messageLog.WriteLog(Category.WifiControl, "找不到指定網路SSID", "ConnectWifi");
				return false;
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WifiControl, ex.ToString(), "ConnectWifi");
				return false;
			}
		}
		public void ShowRadioInformation()
		{
			try
			{
				foreach (var interfaceInfo in NativeWifi.EnumerateInterfaces())
				{

					var interfaceRadio = NativeWifi.GetInterfaceRadio(interfaceInfo.Id);
					if (interfaceRadio is null)
						continue;

					foreach (var radioSet in interfaceRadio.RadioSets)
					{
						basicTool.messageLog.WriteLog(Category.WifiControl, $"Type: {radioSet.Type},"
							+ $"HardwareOn: {radioSet.HardwareOn}, SoftwareOn: {radioSet.SoftwareOn}, On: {radioSet.On}",
							$"Interface: {interfaceInfo.Description} ({interfaceInfo.Id})");
					}
				}
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WifiControl, ex.ToString(), "ShowRadioInformation");
			}
		}
		public void TurnOn()
		{
			try
			{
				foreach (var interfaceInfo in NativeWifi.EnumerateInterfaces())
				{
					Trace.WriteLine($"Interface: {interfaceInfo.Description} ({interfaceInfo.Id})");

					try
					{
						Trace.WriteLine($"Turn on: {NativeWifi.TurnOnInterfaceRadio(interfaceInfo.Id)}");
					}
					catch (UnauthorizedAccessException)
					{
						basicTool.messageLog.WriteLog(Category.WifiControl, "Turn on: Unauthorized", "TurnOnRadio");
					}
				}
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WifiControl, ex.ToString(), "TurnOnRadio");
			}
		}
		public void TurnOff()
		{
			foreach (var interfaceInfo in NativeWifi.EnumerateInterfaces())
			{
				try
				{
					basicTool.messageLog.WriteLog(Category.WifiControl, $"Turn off: {NativeWifi.TurnOffInterfaceRadio(interfaceInfo.Id)}",
																			$"Interface: {interfaceInfo.Description} ({interfaceInfo.Id})");
				}
				catch (UnauthorizedAccessException)
				{
					basicTool.messageLog.WriteLog(Category.WifiControl, "Turn off: Unauthorized", "TurnOffRadio");
				}
			}
		}
		private void SetInterfaceId()
		{
			interfaceId = NativeWifi.EnumerateInterfaces()
				.Select(x => x.Id)
				.FirstOrDefault();
		}

		/// <summary>
		/// Turns on the radio of a wireless interface which is not currently on but can be on.
		/// </summary>
		/// <returns>True if successfully turned on. False if not.</returns>
		private static async Task<bool> TurnOnAsync()
		{
			var targetInterface = NativeWifi.EnumerateInterfaces()
				.FirstOrDefault(x =>
				{
					var radioSet = NativeWifi.GetInterfaceRadio(x.Id)?.RadioSets.FirstOrDefault();
					if (radioSet is null)
						return false;

					if (!radioSet.HardwareOn.GetValueOrDefault()) // Hardware radio state is off.
						return false;

					return (radioSet.SoftwareOn == false); // Software radio state is off.
				});

			if (targetInterface is null)
				return false;

			try
			{
				return await Task.Run(() => NativeWifi.TurnOnInterfaceRadio(targetInterface.Id));
			}
			catch (UnauthorizedAccessException)
			{
				return false;
			}
		}
		/// <summary>
		/// Connects to the available wireless LAN which has the highest signal quality.
		/// </summary>
		/// <returns>True if successfully connected. False if not.</returns>
		private async Task<bool> ConnectAsync(string ssidID)
		{
			try
			{
				var availableNetwork = NativeWifi.EnumerateAvailableNetworks()
					.Where(x => !string.IsNullOrWhiteSpace(x.ProfileName))
					.Where(x => x.Ssid.ToString() == ssidID)
					.First();

				if (availableNetwork is null)
					return false;

				return await NativeWifi.ConnectNetworkAsync(
					interfaceId: availableNetwork.Interface.Id,
					profileName: availableNetwork.ProfileName,
					bssType: availableNetwork.BssType,
					timeout: TimeSpan.FromSeconds(10));
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WifiControl, ex.ToString(), "ConnectAsync");
				return false;
			}
		}

		/// <summary>
		/// Refreshes available wireless LANs.
		/// </summary>
		private static Task RefreshAsync()
		{
			return NativeWifi.ScanNetworksAsync(timeout: TimeSpan.FromSeconds(10));
		}
		/// <summary>
		/// Enumerates SSIDs of available wireless LANs.
		/// </summary>
		/// <returns>SSID strings</returns>
		private IEnumerable<string> EnumerateNetworkSsids()
		{
			try
			{
				return NativeWifi.EnumerateAvailableNetworkSsids()
					.Select(x => x.ToString()); // UTF-8 string representation
			}
			catch (Exception ex)
			{
				basicTool.messageLog.WriteLog(Category.WifiControl, ex.ToString(), "ConnectAsync");
				return null;
			}
		}
	}
}