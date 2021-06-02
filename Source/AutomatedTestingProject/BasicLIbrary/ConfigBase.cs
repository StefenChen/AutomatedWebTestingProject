using AMS.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLIbrary
{
    public class ConfigBase
    {
        protected string configFilePath;
        protected Ini configIni;
        /// <summary>
        /// Inherit system profile access
        /// </summary>
        /// <param name="configFilePath"> The system main config file path </param>
        protected ConfigBase(string configFilePath)
        {
            this.configFilePath = configFilePath;
            configIni = new Ini(configFilePath);
        }
    }
}
