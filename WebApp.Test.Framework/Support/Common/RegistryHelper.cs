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
        public static void DeleteKeyFromLocalMachine(string keyPath)
        {
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(keyPath, writable: true))
            {
                if (registryKey != null)
                {
                    registryKey.DeleteValue(".");
                    Console.WriteLine("Delete the key in Registry.");
                }
                else
                {
                    Console.WriteLine("Cannot find the key in Registry.");
                }
            }
        }
    }
}
