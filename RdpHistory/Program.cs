using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdpHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyName = @"Software\Microsoft\Terminal Server Client\Default";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true)) {
                if (key == null) {
                    Console.WriteLine("Key not found...");
                } else {
                    Console.WriteLine("RDP History:");
                    foreach (var value in key.GetValueNames()) {
                        Console.WriteLine(value);
                        if(value.StartsWith("MRU")) {
                            Console.WriteLine("Deleting {0}", value);
                            key.DeleteValue(value, true);
                        }
                    }
                }

                key.Close();
            }
        }
    }
}
