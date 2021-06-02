using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Management.Instrumentation;
using System.Management;

namespace WindowsControl
{
    /// <summary>
    /// 後來使用發現很多問題，只能忍痛封印它
    /// </summary>
    public class NetworkAdapter
    {
        public string NetworkInterfaceID;
        public string Description;
        public string NetworkInterfaceType;
        public string Speed;
        public PhysicalAddress MacAddress;
        public GatewayIPAddressInformationCollection Getwaryes;
        public UnicastIPAddressInformationCollection IPAddresses;
        public IPAddressCollection DnsAddresses;
        public IPAddressCollection DhcpServerAddresses;
        public bool IsDhcpEnabled;

        /// <summary>
        /// 設定IP地址
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="submask"></param>
        /// <param name="getway"></param>
        /// <param name="dns"></param>
        public bool SetIPAddress(string[] ip, string[] submask, string[] getway, string[] dns)
        {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            string str = "";
            foreach (ManagementObject mo in moc)
            {

                if (!(bool)mo["IPEnabled"])
                    continue;

                if (this.NetworkInterfaceID == mo["SettingID"].ToString())
                {
                    if (ip != null && submask != null)
                    {
                        string[] ipAddress = (String[])mo["IPAddress"];
                        string[] subnetMask = (String[])mo["IPSubnet"];
                        string[] defaultIPGateway = (String[])mo["DefaultIPGateway"];
                        string[] dnsServerSearchOrder = (String[])mo["DNSServerSearchOrder"];

                        //描述
                        inPar = mo.GetMethodParameters("EnableStatic");
                        inPar["IPAddress"] = ip;
                        inPar["SubnetMask"] = submask;
                        outPar = mo.InvokeMethod("EnableStatic", inPar, null);
                        str = outPar["returnvalue"].ToString();

                        ipAddress = (String[])mo["IPAddress"];
                        subnetMask = (String[])mo["IPSubnet"];
                        defaultIPGateway = (String[])mo["DefaultIPGateway"];
                        dnsServerSearchOrder = (String[])mo["DNSServerSearchOrder"];

                        return (str == "0" || str == "1") ? true : false;
                        //獲取操作設定IP的返回值， 可根據返回值去確認IP是否設定成功。 0或1表示成功 
                        // 返回值說明網址： https://msdn.microsoft.com/en-us/library/aa393301(v=vs.85).aspx
                    }
                    if (getway != null)
                    {
                        inPar = mo.GetMethodParameters("SetGateways");
                        inPar["DefaultIPGateway"] = getway;
                        outPar = mo.InvokeMethod("SetGateways", inPar, null);
                        str = outPar["returnvalue"].ToString();
                        return (str == "0" || str == "1") ? true : false;
                    }
                    if (dns != null)
                    {
                        inPar = mo.GetMethodParameters("SetDNSServerSearchOrder");
                        inPar["DNSServerSearchOrder"] = dns;
                        outPar = mo.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                        str = outPar["returnvalue"].ToString();
                        return (str == "0" || str == "1") ? true : false;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 啟用DHCP服務
        /// </summary>
        public void EnableDHCP()
        {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (!(bool)mo["IPEnabled"])
                    continue;

                if (mo["SettingID"].ToString() == this.NetworkInterfaceID) //網絡卡介面標識是否相等, 相當只設置指定介面卡IP地址
                {
                    mo.InvokeMethod("SetDNSServerSearchOrder", null);
                    mo.InvokeMethod("EnableDHCP", null);
                }
            }
        }
        public void DisableDHCP()
        {
            ManagementClass wmi = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = wmi.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (!(bool)mo["IPEnabled"])
                    continue;

                if (mo["SettingID"].ToString() == this.NetworkInterfaceID) //網絡卡介面標識是否相等, 相當只設置指定介面卡IP地址
                {
                    mo.InvokeMethod("SetDNSServerSearchOrder", null);
                    mo.InvokeMethod("DisableDHCP", null);
                }
            }
        }
    }
    /// <summary>
    /// 後來使用發現很多問題，只能忍痛封印它
    /// </summary>
    public class NetworkAdapterUtil
    {
        public List<NetworkAdapter> adapterList;
        /// <summary>
        /// 獲取所有介面卡型別，介面卡被禁用則不能獲取到
        /// </summary>
        /// <returns></returns>
        public List<NetworkAdapter> GetAllNetworkAdapters() //如果介面卡被禁用則不能獲取到
        {
            IEnumerable<NetworkInterface> adapters = NetworkInterface.GetAllNetworkInterfaces(); //得到所有介面卡
            return GetNetworkAdapters(adapters);
        }

        /// <summary>
        /// 根據條件獲取IP地址集合，
        /// </summary>
        /// <param name="adapters">網路介面地址集合</param>
        /// <param name="adapterTypes">網路連線狀態，如UP,DOWN等</param>
        /// <returns></returns>
        private List<NetworkAdapter> GetNetworkAdapters(IEnumerable<NetworkInterface> adapters, params NetworkInterfaceType[] networkInterfaceTypes)
        {
            adapterList = new List<NetworkAdapter>();

            foreach (NetworkInterface adapter in adapters)
            {
                if (networkInterfaceTypes.Length <= 0) //如果沒傳可選引數，就查詢所有
                {
                    if (adapter != null)
                    {
                        NetworkAdapter adp = SetNetworkAdapterValue(adapter);
                        adapterList.Add(adp);
                    }
                    else
                    {
                        return null;
                    }
                }
                else //過濾查詢資料
                {
                    foreach (NetworkInterfaceType networkInterfaceType in networkInterfaceTypes)
                    {
                        if (adapter.NetworkInterfaceType.ToString().Equals(networkInterfaceType.ToString()))
                        {
                            adapterList.Add(SetNetworkAdapterValue(adapter));
                            break; //退出當前迴圈
                        }
                    }
                }
            }
            return adapterList;
        }

        /// <summary>
        /// 設定網路介面卡資訊
        /// </summary>
        /// <param name="adapter"></param>
        /// <returns></returns>
        private NetworkAdapter SetNetworkAdapterValue(NetworkInterface adapter)
        {

            NetworkAdapter networkAdapter = new NetworkAdapter();
            IPInterfaceProperties ips = adapter.GetIPProperties();
            networkAdapter.Description = adapter.Name;
            networkAdapter.NetworkInterfaceType = adapter.NetworkInterfaceType.ToString();
            networkAdapter.Speed = (adapter.Speed / 1000 / 1000) + "MB"; //速度
            networkAdapter.MacAddress = adapter.GetPhysicalAddress(); //實體地址集合
            networkAdapter.NetworkInterfaceID = adapter.Id;//網路介面卡識別符號

            networkAdapter.Getwaryes = ips.GatewayAddresses; //閘道器地址集合
            networkAdapter.IPAddresses = ips.UnicastAddresses; //IP地址集合
            networkAdapter.DhcpServerAddresses = ips.DhcpServerAddresses;//DHCP地址集合
            networkAdapter.IsDhcpEnabled = ips.GetIPv4Properties() == null ? false : ips.GetIPv4Properties().IsDhcpEnabled; //是否啟用DHCP服務

            IPInterfaceProperties adapterProperties = adapter.GetIPProperties();//獲取IPInterfaceProperties例項 
            networkAdapter.DnsAddresses = adapterProperties.DnsAddresses; //獲取並顯示DNS伺服器IP地址資訊 集合
            return networkAdapter;
        }

        public void EnableAllAdapters()
        {
            // ManagementClass wmi = new ManagementClass("Win32_NetworkAdapter");
            // ManagementObjectCollection moc = wmi.GetInstances();
            System.Management.ManagementObjectSearcher moc = new System.Management.ManagementObjectSearcher("Select * from Win32_NetworkAdapter where NetEnabled!=null ");
            foreach (System.Management.ManagementObject mo in moc.Get())
            {
                //if (!(bool)mo["NetEnabled"])
                //  continue;
                string capation = mo["Caption"].ToString();
                string descrption = mo["Description"].ToString();
                mo.InvokeMethod("Enable", null);
            }

        }

        public void DisableAllAdapters()
        {
            // ManagementClass wmi = new ManagementClass("Win32_NetworkAdapter");
            // ManagementObjectCollection moc = wmi.GetInstances();
            System.Management.ManagementObjectSearcher moc = new System.Management.ManagementObjectSearcher("Select * from Win32_NetworkAdapter where NetEnabled!=null ");
            foreach (System.Management.ManagementObject mo in moc.Get())
            {
                //if ((bool)mo["NetEnabled"])
                //  continue;
                string capation = mo["Caption"].ToString();
                string descrption = mo["Description"].ToString();
                mo.InvokeMethod("Disable", null);
            }
        }
    }

}
