using System;

namespace BasicLIbrary
{
	public class AccessConfig : ConfigBase
	{
		/// <summary>
		/// singleton para
		/// </summary>
		private static AccessConfig singletonSystemConfig = null;
		public AccessConfig(string configFilePath) : base(configFilePath)
		{

		}
		public static AccessConfig GetConfig()
		{
			if (singletonSystemConfig == null)
				throw new ArgumentException("Parameter cannot be null", "singletonSystemConfig");
			return singletonSystemConfig;
		}

		public static AccessConfig SetConfig(string configFilePath)
		{
			if (singletonSystemConfig == null)
				singletonSystemConfig = new AccessConfig(configFilePath);
			return singletonSystemConfig;
		}
		/// <summary>
		/// The log folder path
		/// </summary>
		public string LogPath
		{
			get
			{
				string logPath = configIni.GetValue("FolderPath", "LogPath", "./RawData/Log/");
				if (!logPath[logPath.Length - 1].Equals('\\') && !logPath[logPath.Length - 1].Equals('/'))
					logPath += @"\";
				return logPath;
			}
			set { configIni.SetValue("FolderPath", "LogPath", value); }
		}

		#region Website Section
		public string URL
		{
			get { return configIni.GetValue("Website", "URL", "192.168.0.1"); }
			set { configIni.SetValue("Website", "URL", value); }
		}
		public string StaticIPForBridge
		{
			get { return configIni.GetValue("Website", "StaticIPForBridge", "192.168.0.100"); }
			set { configIni.SetValue("Website", "StaticIPForBridge", value); }
		}
		public string StaticSubnetMaskForBridge
		{
			get { return configIni.GetValue("Website", "StaticSubnetMaskForBridge", "255.255.255.0"); }
			set { configIni.SetValue("Website", "StaticSubnetMaskForBridge", value); }
		}
		

		#endregion

		#region Account Section

		public string WebLogInPasswd
		{
			get { return configIni.GetValue("Account", "WebLogInPasswd", "StevenUniverse"); }
			set { configIni.SetValue("Account", "WebLogInPasswd", value); }
		}

		#endregion


		#region Wi-Fi Section


		public string WifiName
		{
			get { return configIni.GetValue("Wi-Fi", "WifiName", "Wi-Fi"); }
			set { configIni.SetValue("Wi-Fi", "WifiName", value); }
		}
		public string Ssid1Name
		{
			get { return configIni.GetValue("Wi-Fi", "Ssid1Name", "a_AStefen_Test_2.4G"); }
			set { configIni.SetValue("Wi-Fi", "Ssid1Name", value); }
		}
		public string Ssid1Passwd
		{
			get { return configIni.GetValue("Wi-Fi", "Ssid1Passwd", "0985599568"); }
			set { configIni.SetValue("Wi-Fi", "Ssid1Passwd", value); }
		}
		public string Ssid2Name
		{
			get { return configIni.GetValue("Wi-Fi", "Ssid2Name", "a_AStefen_Test_2.4G"); }
			set { configIni.SetValue("Wi-Fi", "Ssid2Name", value); }
		}
		public string Ssid2Passwd
		{
			get { return configIni.GetValue("Wi-Fi", "Ssid2Passwd", "0985599568"); }
			set { configIni.SetValue("Wi-Fi", "Ssid2Passwd", value); }
		}
		public string Ssid3Name
		{
			get { return configIni.GetValue("Wi-Fi", "Ssid3Name", "a_AStefen_Test_2.4G"); }
			set { configIni.SetValue("Wi-Fi", "Ssid3Name", value); }
		}
		public string Ssid3Passwd
		{
			get { return configIni.GetValue("Wi-Fi", "Ssid3Passwd", "0985599568"); }
			set { configIni.SetValue("Wi-Fi", "Ssid3Passwd", value); }
		}
		#endregion

		#region NetworkCard Section

		public string WiredNetworkName
		{
			get { return configIni.GetValue("NetworkCard", "WiredNetworkName", "Network2"); }
			set { configIni.SetValue("NetworkCard", "WiredNetworkName", value); }
		}

		#endregion

		#region FilePaths

		public string LocalUpgradeFirmwareFilePath
		{
			get { return configIni.GetValue("FilePaths", "LocalUpgradeFirmwareFilePath", ""); }
			set { configIni.SetValue("FilePaths", "LocalUpgradeFirmwareFilePath", value); }
		}
		public string RestoreFilePath
		{
			get { return configIni.GetValue("FilePaths", "RestoreFilePath", ""); }
			set { configIni.SetValue("FilePaths", "RestoreFilePath", value); }
		}

		#endregion

		#region PageSequence

		public string PageNetwork
		{
			get { return configIni.GetValue("PageSequence", "Network", ""); }
			set { configIni.SetValue("PageSequence", "Network", value); }
		}
		public string PageWireless
		{
			get { return configIni.GetValue("PageSequence", "Wireless", ""); }
			set { configIni.SetValue("PageSequence", "Wireless", value); }
		}
		public string PageSystemTools
		{
			get { return configIni.GetValue("PageSequence", "SystemTools", ""); }
			set { configIni.SetValue("PageSequence", "SystemTools", value); }
		}
		#endregion

		#region StaticIP
		public string StaticIPAddress
		{
			get { return configIni.GetValue("StaticIP", "IPAddress", ""); }
			set { configIni.SetValue("StaticIP", "IPAddress", value); }
		}
		public string StaticSubnetMask
		{
			get { return configIni.GetValue("StaticIP", "SubnetMask", ""); }
			set { configIni.SetValue("StaticIP", "SubnetMask", value); }
		}
		public string StaticDefaultGateway
		{
			get { return configIni.GetValue("StaticIP", "DefaultGateway", ""); }
			set { configIni.SetValue("StaticIP", "DefaultGateway", value); }
		}
		public string StaticPrimaryDNS
		{
			get { return configIni.GetValue("StaticIP", "PrimaryDNS", ""); }
			set { configIni.SetValue("StaticIP", "PrimaryDNS", value); }
		}
		public string StaticSecondaryDNS
		{
			get { return configIni.GetValue("StaticIP", "SecondaryDNS", ""); }
			set { configIni.SetValue("StaticIP", "SecondaryDNS", value); }
		}
		#endregion

	}
}
