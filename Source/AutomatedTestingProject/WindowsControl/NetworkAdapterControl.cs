﻿using System;
using System.Management;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
// System.Net.NetworkInformation;

namespace WindowsControl
{
    public class NetworkCard
    {
        private Process process;
        private ProcessStartInfo psi;
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }

}
