using BasicLIbrary;
using ManagedNativeWifi;
using System;
using System.Linq;

namespace WindowsControl
{
	public class WifiProfile
	{
		protected CommonBase basicTool = null;
		protected Category _type;
		public WifiProfile(CommonBase basicTool, Category _type)
		{
			this.basicTool = basicTool;
			this._type = _type;
		}
		/// <summary>
		/// 有密碼的Profile
		/// </summary>
		/// <param name="profileName"></param>
		/// <param name="ssidString"></param>
		/// <param name="passwd"></param>
		/// <returns></returns>
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
		/// <summary>
		/// 無密碼的Profile
		/// </summary>
		/// <param name="profileName"></param>
		/// <param name="ssidString"></param>
		/// <returns></returns>
		public static string CreateProfileXml(string profileName, string ssidString)
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
	<connectionMode>manual</connectionMode>
	<MSM>
		<security>
			<authEncryption>
				<authentication>open</authentication>
				<encryption>none</encryption>
				<useOneX>false</useOneX>
			</authEncryption>
		</security>
	</MSM>
	<MacRandomization xmlns=""http://www.microsoft.com/networking/WLAN/profile/v3"">
		<enableRandomization>false</enableRandomization>
		<randomizationSeed>1987186106</randomizationSeed>
	</MacRandomization>
</WLANProfile>
";

		}
		public bool SetProfile(Guid interfaceId, string ssidString, string passwd="", string profileName = "")
		{
			bool result;
			string profileXml;
			if (passwd!="")
				profileXml =WifiProfile.CreateProfileXml(ssidString, ssidString, passwd);
			else
				profileXml = WifiProfile.CreateProfileXml(ssidString, ssidString);

			if (!(result = NativeWifi.SetProfile(interfaceId, ProfileType.AllUser, profileXml, null, true)))
				basicTool.messageLog.WriteLog(Category.WifiProfile, "設定Profile檔案失敗。", "SetProfile");
			else if (!(result &= NativeWifi.EnumerateProfileNames().Contains(ssidString)))
				basicTool.messageLog.WriteLog(Category.WifiProfile, "找不到設定的Profile檔案。", "SetProfile");
			return result;
		}

		public bool DeletProfile(Guid interfaceId, string profileName)
		{
			bool result;
			if (!(result = NativeWifi.EnumerateProfileNames().Contains(profileName)))
				basicTool.messageLog.WriteLog(Category.WifiProfile, "找不到Profile檔案:" + profileName + "失敗。", "DeletProfile");
			else if (!(result &= NativeWifi.DeleteProfile(interfaceId, profileName)))
				basicTool.messageLog.WriteLog(Category.WifiProfile, "刪除Profile檔案:" + profileName + "失敗。", "DeletProfile");
			else if (!(result &= NativeWifi.EnumerateProfileNames().Contains(profileName)))
				basicTool.messageLog.WriteLog(Category.WifiProfile, "刪除Profile檔案後還是有找到:" + profileName + "失敗。", "DeletProfile");

			return result;
		}
	}
}
