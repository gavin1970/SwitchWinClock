using SwitchWinClock.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Reflection;

namespace SwitchWinClock.utils
{
    /// <summary>
    /// This class was created to run within a Library or Application and within
    /// either place it will pull the Application Information, not the library.
    /// </summary>
    public static class About
    {
        public struct ADDR_TYPE
        {
            public string Address;
            public AddressFamily AddressFamily;
        }

        public struct NET_INFO
        {
            public string Name;
            public string Description;
            public List<ADDR_TYPE> Addresses;
            public bool SupportsIPv4;
            public bool SupportsIPv6;
        }

        /// <summary>
        /// structure to collect library information.
        /// </summary>
        public struct APP_INFO
        {
            public string AppFullPath;
            public string AppFileDirectory;
            public string AppFileName;
            public SLFV FileVersion;
            public SLFV ProductVersion;
            public string AppTitle;
            public string Company;
            public string ProductName;
            public string Copyright;
            public string Description;
            public string Trademark;
            public string ServerName;
            public string UserName;
            public string DomainName;
            public List<NET_INFO> NetworkInfo;
        }

        private static APP_INFO _appInfo = new APP_INFO() { NetworkInfo = new List<NET_INFO>() };

        /// <summary>
        /// directly to FileVersion
        /// </summary>
        public static SLFV FileVersion
        {
            get { return AppInfo.FileVersion; }
        }

        public static SLFV ProductVersion
        {
            get { return AppInfo.ProductVersion; }
        }

        public static string AppTitle
        {
            get { return AppInfo.AppTitle; }
        }

        public static string AppPath
        {
            get { return AppInfo.AppFullPath; }
        }

        public static string ProductName
        {
            get { return AppInfo.ProductName; }
        }

        public static string Company
        {
            get { return AppInfo.Company; }
        }

        public static string Copyright
        {
            get { return AppInfo.Copyright; }
        }

        public static string AppFileDirectory
        {
            get { return AppInfo.AppFileDirectory; }
        }

        public static string AppFileName
        {
            get { return AppInfo.AppFileName; }
        }

        public static string Description
        {
            get { return AppInfo.Description; }
        }

        public static string DomainName
        {
            get { return AppInfo.DomainName; }
        }

        public static string UserName
        {
            get { return AppInfo.UserName; }
        }

        public static List<NET_INFO> NetworkInfo
        {
            get { return AppInfo.NetworkInfo; }
        }

        /// <summary>
        /// Property to get all data
        /// </summary>
        public static APP_INFO AppInfo
        {
            get
            {
                if (_appInfo.AppFullPath == null)
                {
                    string appFileDirectory = string.Empty;
                    string appFileName = string.Empty;
                    string fileVersion = string.Empty;
                    string productVersion = string.Empty;

                    Assembly currentAssembly = Assembly.GetExecutingAssembly();
                    var callerAssemblies = new StackTrace().GetFrames()
                                .Select(x => x.GetMethod().ReflectedType.Assembly).Distinct()
                                .Where(x => x.GetReferencedAssemblies().Any(y => y.FullName == currentAssembly.FullName));

                    if (currentAssembly != null && currentAssembly.Location.EndsWith(".dll"))
                        currentAssembly = callerAssemblies.Last();  //only for libraries calling back to parent

                    string appFullPath = currentAssembly?.Location;
                    if (!string.IsNullOrWhiteSpace(appFullPath))
                    {
                        appFileDirectory = Path.GetDirectoryName(appFullPath);
                        appFileName = Path.GetFileName(appFullPath);
                        FileVersionInfo fi = FileVersionInfo.GetVersionInfo(appFullPath);
                        fileVersion = fi.FileVersion;
                        productVersion = fi.ProductVersion;
                    }

                    AssemblyTitleAttribute titleAttr = GetAttribute<AssemblyTitleAttribute>(currentAssembly);
                    AssemblyCompanyAttribute companyAttr = GetAttribute<AssemblyCompanyAttribute>(currentAssembly);
                    AssemblyProductAttribute productAttr = GetAttribute<AssemblyProductAttribute>(currentAssembly);
                    AssemblyCopyrightAttribute copyrightAttr = GetAttribute<AssemblyCopyrightAttribute>(currentAssembly);
                    AssemblyDescriptionAttribute descrAttr = GetAttribute<AssemblyDescriptionAttribute>(currentAssembly);
                    AssemblyTrademarkAttribute tradeAttr = GetAttribute<AssemblyTrademarkAttribute>(currentAssembly);

                    string serverName = Dns.GetHostName();
                    string userName = Environment.UserName;
                    string domainName = Environment.UserDomainName;

                    List<NET_INFO> netInfo = new List<NET_INFO>();

                    foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
                    {
                        List<ADDR_TYPE> allAddrs = new List<ADDR_TYPE>();
                        IPInterfaceProperties ipProps = netInterface.GetIPProperties();

                        bool hasIPv4 = false;
                        bool hasIPv6 = false;
                        foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                        {
                            AddressFamily addrFamily = GetIPAFormat(addr.Address.ToString());
                            if (addrFamily == AddressFamily.InterNetwork)
                                hasIPv4 = true;
                            if (addrFamily == AddressFamily.InterNetworkV6)
                                hasIPv6 = true;

                            allAddrs.Add(new ADDR_TYPE()
                            {
                                Address = addr.Address.ToString(),
                                AddressFamily = addrFamily
                            });
                        }

                        NET_INFO netData = new NET_INFO()
                        {
                            Name = netInterface.Name,
                            Description = netInterface.Description,
                            Addresses = allAddrs,
                            SupportsIPv4 = hasIPv4,
                            SupportsIPv6 = hasIPv6,
                        };

                        netInfo.Add(netData);
                    }

                    _appInfo = new APP_INFO
                    {
                        AppFullPath = appFullPath?.Trim(),
                        AppFileDirectory = appFileDirectory?.Trim(),
                        AppFileName = appFileName?.Trim(),
                        FileVersion = new SLFV(fileVersion?.Trim()),
                        AppTitle = titleAttr?.Title?.Trim(),
                        Company = companyAttr?.Company?.Trim(),
                        ProductName = productAttr?.Product?.Trim(),
                        ProductVersion = new SLFV(productVersion?.Trim()),
                        Copyright = copyrightAttr?.Copyright?.Trim(),
                        Description = descrAttr?.Description?.Trim(),
                        Trademark = tradeAttr?.Trademark?.Trim(),
                        ServerName = serverName?.Trim(),
                        UserName = userName?.Trim(),
                        DomainName = domainName?.Trim(),
                        NetworkInfo = netInfo
                    };
                }

                return _appInfo;
            }
        }

        private static AddressFamily GetIPAFormat(string ipAddr)
        {
            AddressFamily retVal = AddressFamily.Unspecified;

            //InterNetworkV6
            if (IPAddress.TryParse(ipAddr, out IPAddress addr))
                try { retVal = addr.AddressFamily; } catch { }

            return retVal;
        }

        /// <summary>
        /// Generic method for pulling the attributes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static T GetAttribute<T>(Assembly assembly)
        {
            object retVal = default(T);

            var attr = Attribute.GetCustomAttribute(assembly, typeof(T), false);
            if (attr != null)
                retVal = (T)Convert.ChangeType(attr, typeof(T));

            return (T)retVal;
        }
    }
}