using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Security.AccessControl;

namespace XCleaner
{
    public class disableTelemetry
    {
        public static async Task dynamicServices()
        {
            await Task.Run(() =>
            {
                string[] services = File.ReadAllLines("services.txt");
                foreach (string serv in services)
                {
                    HelpMetods.powershell_WaitforExit($"sc stop \"{serv}\"");
                }
                string[] servicesDyn = File.ReadAllLines("servicesDynamic.txt");
                ServiceController[] scServices = ServiceController.GetServices();
                foreach (ServiceController ser in scServices)
                {
                    string serNane = ser.ServiceName;
                    foreach (string s in servicesDyn)
                    {
                        if (serNane.Contains(s))
                        {
                            HelpMetods.powershell_WaitforExit($"sc stop \"{serNane}\"");
                        }
                    }

                }

            });
        }
        public static async Task correct_host()
        {
            await Task.Run(() =>
            {
                string[] hostsdomains =
               {
                    "a.ads1.msn.com",
                    "a.ads2.msads.net",
                    "a.ads2.msn.com",
                    "a.rad.msn.com",
                    "a-0001.a-msedge.net",
                    "a-0002.a-msedge.net",
                    "a-0003.a-msedge.net",
                    "a-0004.a-msedge.net",
                    "a-0005.a-msedge.net",
                    "a-0006.a-msedge.net",
                    "a-0007.a-msedge.net",
                    "a-0008.a-msedge.net",
                    "a-0009.a-msedge.net",
                    "ac3.msn.com",
                    "ad.doubleclick.net",
                    "adnexus.net",
                    "adnxs.com",
                    "ads.msn.com",
                    "ads1.msads.net",
                    "ads1.msn.com",
                    "aidps.atdmt.com",
                    "aka-cdn-ns.adtech.de",
                    "a-msedge.net",
                    "apps.skype.com",
                    "az361816.vo.msecnd.net",
                    "az512334.vo.msecnd.net",
                    "b.ads1.msn.com",
                    "b.ads2.msads.net",
                    "b.rad.msn.com",
                    "bs.serving-sys.com",
                    "c.atdmt.com",
                    "c.msn.com",
                    "ca.telemetry.microsoft.com",
                    "cache.datamart.windows.com",
                    "cdn.atdmt.com",
                    "cds26.ams9.msecn.net",
                    "choice.microsoft.com",
                    "choice.microsoft.com.nsatc.net",
                    "compatexchange.cloudapp.net",
                    "corp.sts.microsoft.com",
                    "corpext.msitadfs.glbdns2.microsoft.com",
                    "cs1.wpc.v0cdn.net",
                    "db3aqu.atdmt.com",
                    "db3wns2011111.wns.windows.com",
                    "df.telemetry.microsoft.com",
                    "diagnostics.support.microsoft.com",
                    "ec.atdmt.com",
                    "fe2.update.microsoft.com.akadns.net",
                    "fe3.delivery.dsp.mp.microsoft.com.nsatc.net",
                    "feedback.microsoft-hohm.com",
                    "feedback.search.microsoft.com",
                    "feedback.windows.com",
                    "flex.msn.com",
                    "g.msn.com",
                    "h1.msn.com",
                    "i1.services.social.microsoft.com",
                    "i1.services.social.microsoft.com.nsatc.net",
                    "lb1.www.ms.akadns.net",
                    "live.rads.msn.com",
                    "m.adnxs.com",
                    "m.hotmail.com",
                    "msedge.net",
                    "msftncsi.com",
                    "msnbot-207-46-194-33.search.msn.com",
                    "msnbot-65-55-108-23.search.msn.com",
                    "msntest.serving-sys.com",
                    "oca.telemetry.microsoft.com",
                    "oca.telemetry.microsoft.com.nsatc.net",
                    "pre.footprintpredict.com",
                    "preview.msn.com",
                    "pricelist.skype.com",
                    "rad.live.com",
                    "rad.msn.com",
                    "redir.metaservices.microsoft.com",
                    "reports.wes.df.telemetry.microsoft.com",
                    "s.gateway.messenger.live.com",
                    "s0.2mdn.net",
                    "schemas.microsoft.akadns.net ",
                    "secure.adnxs.com",
                    "secure.flashtalking.com",
                    "services.wes.df.telemetry.microsoft.com",
                    "settings.data.microsoft.com",
                    "settings-sandbox.data.microsoft.com",
                    "settings-win.data.microsoft.com",
                    "sls.update.microsoft.com.akadns.net",
                    "sO.2mdn.net",
                    "spynet2.microsoft.com",
                    "spynetalt.microsoft.com",
                    "sqm.df.telemetry.microsoft.com",
                    "sqm.telemetry.microsoft.com",
                    "sqm.telemetry.microsoft.com.nsatc.net",
                    "ssw.live.com",
                    "static.2mdn.net",
                    "statsfe1.ws.microsoft.com",
                    "statsfe2.update.microsoft.com.akadns.net",
                    "statsfe2.ws.microsoft.com",
                    "survey.watson.microsoft.com",
                    "telecommand.telemetry.microsoft.com",
                    "telecommand.telemetry.microsoft.com.nsatc.net",
                    "telecommand.telemetry.microsoft.com.nsat­c.net",
                    "telemetry.appex.bing.net",
                    "telemetry.appex.bing.net:443",
                    "telemetry.microsoft.com",
                    "telemetry.urs.microsoft.com",
                    "ui.skype.com",
                    "v10.vortex-win.data.microsoft.com",
                    "view.atdmt.com",
                    "vortex.data.microsoft.com",
                    "vortex-bn2.metron.live.com.nsatc.net",
                    "vortex-cy2.metron.live.com.nsatc.net",
                    "vortex-sandbox.data.microsoft.com",
                    "vortex-win.data.microsoft.com",
                    "watson.live.com",
                    "watson.microsoft.com",
                    "watson.ppe.telemetry.microsoft.com",
                    "watson.telemetry.microsoft.com",
                    "watson.telemetry.microsoft.com.nsatc.net",
                    "wes.df.telemetry.microsoft.com",
                    "win10.ipv6.microsoft.com",
                    "www.msftncsi.com",
                };
                string[] ipAddr =
            {
                "104.96.147.3",
                "111.221.29.177",
                "111.221.29.253",
                "111.221.64.0-111.221.127.255", // singapure
                "131.253.40.37",
                "134.170.115.60",
                "134.170.165.248",
                "134.170.165.253",
                "134.170.185.70",
                "134.170.30.202",
                "137.116.81.24",
                "137.117.235.16",
                "157.55.129.21",
                "157.55.130.0-157.55.130.255",
                "157.55.133.204",
                "157.55.235.0-157.55.235.255",
                "157.55.236.0-157.55.236.255", // NEW TH2 SPY IP
                "157.55.240.220",
                "157.55.52.0-157.55.52.255",
                "157.55.56.0-157.55.56.255",
                "157.56.106.189",
                "157.56.121.89",
                "157.56.124.87", // NEW TH2 Spy IP
                "157.56.91.77",
                "157.56.96.54",
                "168.63.108.233",
                "191.232.139.2",
                "191.232.139.254",
                "191.232.80.58",
                "191.232.80.62",
                "191.237.208.126",
                "195.138.255.0-195.138.255.255",
                "2.22.61.43",
                "2.22.61.66",
                "204.79.197.200",
                "207.46.101.29",
                "207.46.114.58",
                "207.46.223.94",
                "207.68.166.254",
                "212.30.134.204",
                "212.30.134.205",
                "213.199.179.0-213.199.179.255", // Ireland
                "23.102.21.4",
                "23.218.212.69",
                "23.223.20.82", // cache.datamart.windows.com
                "23.57.101.163",
                "23.57.107.163",
                "23.57.107.27",
                "23.99.10.11",
                "64.4.23.0-64.4.23.255",
                "64.4.54.22",
                "64.4.54.32",
                "64.4.6.100",
                "65.39.117.230",
                "65.39.117.230",
                "65.52.100.11",
                "65.52.100.7",
                "65.52.100.9",
                "65.52.100.91",
                "65.52.100.92",
                "65.52.100.93",
                "65.52.100.94",
                "65.52.108.29",
                "65.52.108.33",
                "65.55.108.23",
                "65.55.138.114",
                "65.55.138.126",
                "65.55.138.186",
                "65.55.223.0-65.55.223.255",
                "65.55.252.63",
                "65.55.252.71",
                "65.55.252.92",
                "65.55.252.93",
                "65.55.29.238",
                "65.55.39.10",
                "77.67.29.176" // NEW TH2 Spy IP
            };
                string path_host = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts");
                string host_data = File.ReadAllText(path_host);
                for (int i= 0; i < hostsdomains.Length; i ++)
                {
                    if(!host_data.Contains(hostsdomains[i]))
                    {
                        File.AppendAllText(path_host, $"{hostsdomains[i]}\n");
                    }
                    
                }
                for (int i = 0; i < ipAddr.Length; i++)
                {
                    if (!host_data.Contains(hostsdomains[i]))
                    {
                        File.AppendAllText(path_host, $"{ipAddr[i]}\n");
                    }
                    
                }
                string[] ipLIST = File.ReadAllLines("blockIP.txt");
                for(int i = 0; i < ipLIST.Length; i++)
                {
                    if (!host_data.Contains(hostsdomains[i]))
                    {
                        File.AppendAllText(path_host, $"{ipLIST[i]}\n");
                    }
                    
                }
            });
        }
        public static async Task EnableTaskMgr()
        {
            await Task.Run(() =>
            {
                RegistryKey rg = Registry.CurrentUser;
                rg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true).SetValue("DisableTaskMgr", 0);
                rg.Close();
            });
        }
        public static async Task disable_History_Files()
        {
            await Task.Run(() =>
            {
                HelpMetods.powershell_WaitforExit("sc stop \"fhsvc\"");
            });
        }
        public static async Task disable_XBox()
        {
            await Task.Run(() =>
            {
                HelpMetods.powershell_WaitforExit("sc stop \"xbgm\"");
            });
        }
        public static async Task disable_Windows_Events()
        {
            await Task.Run(() =>
            {
                RegistryKey rg = Registry.LocalMachine;
                rg.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\diagnosticshub.standardcollector.service", true).SetValue("Start", 4);
                rg.Close();
            });
        }
        public static async Task EnableRegedit()
        {
            await Task.Run(() =>
            {
                RegistryKey rg = Registry.CurrentUser;
                rg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System", true).SetValue("DisableRegistryTools", 0);
                rg.Close();
            });
        }
        public static async Task Disabling_location()
        {
            await Task.Run(() =>
            {
                RegistryKey rg = Registry.LocalMachine;
                rg.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\LocationAndSensors", true).SetValue("DisableLocation", 1);
                rg.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\LocationAndSensors", true).SetValue("DisableLocationScripting", 1);
                rg.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows\LocationAndSensors", true).SetValue("DisableWindowsLocationProvider", 1);
                rg.Close();
            });
        }
        public static async Task RemoveWin10App()
        {
            await Task.Run(() =>
            {
                DeleteWindows10MetroApp("3d");
                DeleteWindows10MetroApp("camera");
                DeleteWindows10MetroApp("communi");
                DeleteWindows10MetroApp("maps");
                DeleteWindows10MetroApp("bing");
                DeleteWindows10MetroApp("zune");
                DeleteWindows10MetroApp("people");
                DeleteWindows10MetroApp("note");
                DeleteWindows10MetroApp("phone");
                DeleteWindows10MetroApp("photo");
                DeleteWindows10MetroApp("solit");
                DeleteWindows10MetroApp("soundrec");
                DeleteWindows10MetroApp("xbox");
            });
        }
        private static void DeleteWindows10MetroApp(string appname)
        {
            ProcStartargs("powershell", string.Format("-command \"Get-AppxPackage *{0}* | Remove-AppxPackage\"", appname));
        }
        private static void ProcStartargs(string name, string args)
        {
            try
            {
                Process process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = name,
                        Arguments = args,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
                        StandardOutputEncoding = Encoding.GetEncoding(866)
                    }
                };
                process.Start();
                string str = null;
                while (!process.StandardOutput.EndOfStream)
                {
                    str = str + Environment.NewLine + process.StandardOutput.ReadLine();
                }
                process.WaitForExit();
            }
            catch { }
        }
        public static async Task disable_hide_monitoring_system()
        {
            await Task.Run(() =>
            {
                RegistryKey rg = Registry.LocalMachine;
                rg.CreateSubKey(@"SYSTEM\CurrentControlSet\Services\CDPUserSvc", true).SetValue("Start", 4);
                rg.Close();

                foreach (string regkeyfolder in new string[]
                {
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{21157C1F-2651-4CC1-90CA-1F28B02263F6}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{2EEF81BE-33FA-4800-9670-1CD474972C3F}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{7D7E8402-7C54-4821-A34E-AEEFD62DED93}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{992AFA70-6F47-4148-B3E9-3003349C1548}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{9D9E0118-1807-4F2E-96E4-2CE57142E196}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{A8804298-2D5F-42E3-9531-9C8C39EB29CE}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{B19F89AF-E3EB-444B-8DEA-202575A71599}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{C1D23ACC-752B-43E5-8448-8D0E519CD6D6}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{D89823BA-7180-4B81-B50C-7E471E6121A3}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{E5323777-F976-4f5b-9B55-B94699C46E44}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{E6AD100E-5F4E-44CD-BE0F-2265D88D14F5}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\{E83AF229-8640-4D18-A213-E22675EBB2C3}",
                    "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeviceAccess\\Global\\LooselyCoupled"
                })
                {
                    SetRegValueHkcu(regkeyfolder, "Value", "Deny", RegistryValueKind.String);
                }
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", "CortanaEnabled", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\InputPersonalization", "RestrictImplicitInkCollection", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", "DisableWebSearch", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\Windows Search", "ConnectedSearchUseWeb", "0", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors", "DisableLocation", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors", "DisableWindowsLocationProvider", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors", "DisableLocationScripting", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\LocationAndSensors", "DisableSensors", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SYSTEM\\CurrentControlSet\\Services\\lfsvc\\Service\\Configuration", "Status", "0", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Sensor\\Overrides\\{BFA794E4-F964-4FDB-90F6-51056BFE4B44}", "SensorPermissionState", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Siuf\\Rules", "NumberOfSIUFInPeriod", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Siuf\\Rules", "PeriodInNanoSeconds", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Search", "BingSearchEnabled", "0", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\TabletPC", "PreventHandwritingDataSharing", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\HandwritingErrorReports", "PreventHandwritingErrorReports", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\AppCompat", "DisableInventory", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\Personalization", "NoLockScreenCamera", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo", "Enabled", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo", "Enabled", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Input\\TIPC", "Enabled", "0", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Biometrics", "Enabled", "0", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows\\CredUI", "DisablePasswordReveal", "1", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync", "SyncPolicy", "5", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\Personalization", "Enabled", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\BrowserSettings", "Enabled", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\Credentials", "Enabled", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\Language", "Enabled", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\Accessibility", "Enabled", "0", RegistryValueKind.DWord);
                SetRegValueHkcu("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\SettingSync\\Groups\\Windows", "Enabled", "0", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows Defender", "DisableAntiSpyware", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet", "SpyNetReporting", "0", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\Windows Defender\\Spynet", "SubmitSamplesConsent", "2", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Policies\\Microsoft\\MRT", "DontReportInfectionInformation", "1", RegistryValueKind.DWord);
                SetRegValueHklm("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer", "SmartScreenEnabled", "Off", RegistryValueKind.String);
            });
        }
        private static void SetRegValueHkcu(string regkeyfolder, string paramname, string paramvalue, RegistryValueKind keytype)
        {
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(regkeyfolder);
            if (registryKey != null)
            {
                registryKey.Close();
            }
            RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey(regkeyfolder, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
            try
            {
                if (registryKey2 != null)
                {
                    registryKey2.SetValue(paramname, paramvalue, keytype);
                }
            }
            catch
            {
            }
            if (registryKey2 != null)
            {
                registryKey2.Close();
            }
        }
        private static void SetRegValueHklm(string regkeyfolder, string paramname, string paramvalue, RegistryValueKind keytype)
        {
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(regkeyfolder);
            if (registryKey != null)
            {
                registryKey.Close();
            }
            RegistryKey registryKey2 = Registry.LocalMachine.OpenSubKey(regkeyfolder, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
            try
            {
                if (registryKey2 != null)
                {
                    registryKey2.SetValue(paramname, paramvalue, keytype);
                }
            }
            catch
            {
            }
            if (registryKey2 != null)
            {
                registryKey2.Close();
            }
        }
        public static async Task disable_Windows_sync()
        {
            await Task.Run(() =>
            {
                RegistryKey rg = Registry.CurrentUser;
                rg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Accessibility", true).SetValue("Enabled", 0);
                rg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\BrowserSettings", true).SetValue("Enabled", 0);
                rg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Credentials", true).SetValue("Enabled", 0);
                rg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Language", true).SetValue("Enabled", 0);
                rg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Personalization", true).SetValue("Enabled", 0);
                rg.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\SettingSync\Groups\Windows", true).SetValue("Enabled", 0);
                rg.Close();
            });
        }
        public static async Task RemoveOneDrive()
        {
            await Task.Run(() =>
            {
                HelpMetods.killProcc("OneDrive");
                Thread.Sleep(100);
                string Users = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

                string AppDataPathLocal = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                RecursiveDel.EnumerateFolder_DeliteRecur(AppDataPathLocal + "\\Microsoft\\OneDrive");
                RecursiveDel.EnumerateFolder_DeliteRecur("C:\\ProgramData\\Microsoft OneDrive");
                RecursiveDel.EnumerateFolder_DeliteRecur(Users + "\\OneDrive");
                RecursiveDel.EnumerateFolder_DeliteRecur("C:\\Windows\\WinSxS\\wow64_microsoft-windows-onedrive-setup_31bf3856ad364e35_10.0.19041.1_none_e585f901f9ce93e6");
                RecursiveDel.EnumerateFolder_DeliteRecur("C:\\Windows\\WinSxS\\wow64_microsoft-windows-settingsync-onedrive_31bf3856ad364e35_10.0.19041.1_none_8f92ee2b150bb996");
            });
        }
        public static async Task DisableSmartScreen()
        {
            await Task.Run(() =>
            {
                HelpMetods.killProcc("smartscreen");
                RegistryKey rg = Registry.LocalMachine;
                rg.CreateSubKey(@"SOFTWARE\Policies\Microsoft\Windows").SetValue("EnableSmartScreen", 0);
                rg.Close();
                HelpMetods.killProcc("smartscreen");
                try
                {
                    File.Delete(@"C:\Windows\System32\smartscreen.exe");
                }
                finally
                {
                    File.Delete(@"C:\Windows\System32\smartscreen.exe");
                }
            });
        }
        public static async Task DisableWindowsDifender()
        {
            await Task.Run(() =>
            {
                HelpMetods.killProcc("SecurityHealthSystray");
                HelpMetods.powershell_WaitforExit("sc delete \"WarpJITSvc\"");
                HelpMetods.RegistryEdit(@"SOFTWARE\Microsoft\Windows Defender\Features", "TamperProtection", "0"); //Windows 10 1903 Redstone 6
                HelpMetods.RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender", "DisableAntiSpyware", "1");
                HelpMetods.RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableBehaviorMonitoring", "1");
                HelpMetods.RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableOnAccessProtection", "1");
                HelpMetods.RegistryEdit(@"SOFTWARE\Policies\Microsoft\Windows Defender\Real-Time Protection", "DisableScanOnRealtimeEnable", "1");
                HelpMetods.killProcc("SecurityHealthSystray");
            });
        }

        public static async Task DisableUAC()
        {
            await Task.Run(() =>
            {
                RegistryKey Key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                Key.SetValue("EnableLUA", 0);
                Key.Close();
            });
        }
    }
}
