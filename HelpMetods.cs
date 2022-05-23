using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCleaner
{
    public class HelpMetods
    {
        public static void powershell_WaitforExit(string command)
        {
            Process.Start(new ProcessStartInfo { FileName = "powershell", Arguments = $"/c {command}", WindowStyle = ProcessWindowStyle.Hidden }).WaitForExit();
        }

        public static void powershell( string command)
        {
            Process.Start(new ProcessStartInfo { FileName = "powershell", Arguments = $"/c {command}", WindowStyle = ProcessWindowStyle.Hidden });
        }
            
        public static void killProcc(string nameProcc)
        {
            Process[] proccess = Process.GetProcessesByName(nameProcc);
            if (proccess.Length > 0)
            {
                foreach (Process procc in proccess)
                {
                    procc.Kill();
                }
            }
        }

        public static void RegistryEdit(string regPath, string name, string value)
        {
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(regPath, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    if (key == null)
                    {
                        Registry.LocalMachine.CreateSubKey(regPath).SetValue(name, value, RegistryValueKind.DWord);
                        return;
                    }
                    if (key.GetValue(name) != (object)value)
                        key.SetValue(name, value, RegistryValueKind.DWord);
                }
            }
            catch { }
        }


        public static void EnumerateFilesDeliteRecur(string path, List<string> extenshs)
        {
            try
            {
                foreach (string Folder in Directory.GetDirectories(path))
                {
                    EnumerateFilesDeliteRecur(Folder, extenshs);
                }
                foreach (string files in Directory.GetFiles(path))
                {

                    string extensh = Path.GetExtension(files);
                    foreach (string norExt in extenshs)
                    {
                        if (norExt == extensh)
                        {
                            try
                            {
                                int y;
                                y = files.Length;
                                Cleaning.File_size = y + Cleaning.File_size;
                                File.Delete(files);
                                Console.WriteLine(files);
                                Cleaning.ALL_files = Cleaning.ALL_files + 1;
                            }
                            catch { }
                        }
                    }
                }
            }
            catch
            {
                return;
            }

        }
    }
}
