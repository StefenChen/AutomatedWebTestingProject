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
        #region Shared parameters
        public string Test
        {
            get { return configIni.GetValue("Test", "IP", "192.168.100.100"); }
            set { configIni.SetValue("Test", "IP", value); }
        }
        public string NetConnectionID
        {
            get { return configIni.GetValue("NetworkCard", "NetConnectionID", "Wi-Fi"); }
            set { configIni.SetValue("NetworkCard", "NetConnectionID", value); }
        }

        #endregion
    }
}
