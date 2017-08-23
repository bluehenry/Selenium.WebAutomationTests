using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WebApp.Test.Framework.Support.Common
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
