using System;
using Microsoft.Win32;

namespace Selenium.WebTest.Framework.Support.Common
{
    public static class RegistryHelper
    {
        public static void DeleteValueFromLocalMachine(string key, string value)
        {
           
            
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key, writable: true))
            {
                if (registryKey != null)
                {
                    if (registryKey.GetValue(value) != null )
                    { 
                        registryKey.DeleteValue(value);
                    }
                    else
                    {
                        Console.WriteLine($"Cannot find value {key}\\{value} in Registry.");
                    }
                }
                else
                {
                    Console.WriteLine($"Cannot find key {key} in Registry.");
                }
            }
        }
    }
}
