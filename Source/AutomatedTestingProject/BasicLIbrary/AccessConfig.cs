using System;
using AMS.Profile;

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



		#endregion

		#region Account Section

		public string WebLogInAccount
		{
			get { return configIni.GetValue("Account", "WebLogInAccount", "StevenUniverse"); }
			set { configIni.SetValue("Account", "WebLogInAccount", value); }
		}
		public string WebLogInPasswd
		{
			get { return configIni.GetValue("Account", "WebLogInPasswd", "FinntheHuman"); }
			set { configIni.SetValue("Account", "WebLogInPasswd", value); }
		}

		#endregion


		#region NetworkCard Section

		public string WebIP
		{
			get { return configIni.GetValue("NetworkCard", "WebIP", "192.168.0.1"); }
			set { configIni.SetValue("NetworkCard", "WebIP", value); }
		}
		public string WifiName
		{
			get { return configIni.GetValue("NetworkCard", "WifiName", "Wi-Fi"); }
			set { configIni.SetValue("NetworkCard", "WifiName", value); }
		}
		public string SsidName
		{
			get { return configIni.GetValue("NetworkCard", "SsidName", "a_AStefen_Test_2.4G"); }
			set { configIni.SetValue("NetworkCard", "SsidName", value); }
		}
		public string SsidPasswd
		{
			get { return configIni.GetValue("NetworkCard", "SsidPasswd", "0985599568"); }
			set { configIni.SetValue("NetworkCard", "SsidPasswd", value); }
		}

		#endregion

		#region Test Section

		public string Test
		{
			get { return configIni.GetValue("Test", "IP", "192.168.100.100"); }
			set { configIni.SetValue("Test", "IP", value); }
		}

		#endregion

	}
}
