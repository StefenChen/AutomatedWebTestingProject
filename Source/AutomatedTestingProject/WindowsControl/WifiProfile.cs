using BasicLIbrary;
using ManagedNativeWifi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsControl
{
	public class WifiProfile
	{
		protected CommonBase basicTool;
		protected Category _type;
		public WifiProfile(CommonBase basicTool, Category _type)
		{
			this.basicTool = basicTool;
			this._type = _type;
		}
		public static string CreateProfileXml(string profileName, string ssidString, string passwd)
		{
			return
$@"<?xml version=""1.0""?>
<WLANProfile xmlns=""http://www.microsoft.com/networking/WLAN/profile/v1"">
	<name>{profileName}</name>
	<SSIDConfig>
		<SSID>
			<hex>{HexadecimalStringConverter.ToHexadecimalString(ssidString)}</hex>
			<name>{ssidString}</name>
		</SSID>
	</SSIDConfig>
	<connectionType>ESS</connectionType>
	<connectionMode>auto</connectionMode>
	<MSM>
		<security>
			<authEncryption>
				<authentication>WPA2PSK</authentication>
				<encryption>AES</encryption>
				<useOneX>false</useOneX>
			</authEncryption>
			<sharedKey>
				<keyType>passPhrase</keyType>
				<protected>false</protected>
				<keyMaterial>{passwd}</keyMaterial>
			</sharedKey>
		</security>
	</MSM>
	<MacRandomization xmlns=""http://www.microsoft.com/networking/WLAN/profile/v3"">
		<enableRandomization>false</enableRandomization>
	</MacRandomization>
</WLANProfile>";
		}

		public bool SetProfile(Guid interfaceId, string ssidString, string passwd, string profileName = "")
		{
			bool result;
			var profileXml = WifiProfile.CreateProfileXml(ssidString, ssidString, passwd);
			if (!(result = NativeWifi.SetProfile(interfaceId, ProfileType.AllUser, profileXml, null, true)))
				basicTool.messageLog.WriteLog(Category.WifiControl, "設定Profile檔案失敗。", "SetProfile");
			if (!(result &= NativeWifi.EnumerateProfileNames().Contains(ssidString)))
				basicTool.messageLog.WriteLog(Category.WifiControl, "找不到設定的Profile檔案。", "SetProfile");
			return result;
		}

		public static void DeletProfile(Guid interfaceId, string profileName)
		{
			var result = NativeWifi.EnumerateProfileNames().Contains(profileName);
			result = NativeWifi.DeleteProfile(interfaceId, profileName);
			result = NativeWifi.EnumerateProfileNames().Contains(profileName);
		}
	}
	
}
