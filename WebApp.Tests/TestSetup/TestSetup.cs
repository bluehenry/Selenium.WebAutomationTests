using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Test.Framework;
using WebApp.Test.Framework.Support;

namespace WebApp.Tests.TestSetup
{
    [TestClass]
    public class TestSetup
    {
        [AssemblyInitialize()]
        public static void AssemblyInit(TestContext context)
        {
            Browser.Initialize();            
        }

        [AssemblyCleanup()]
        public static void AssemblyCleanup()
        {
            if (Browser.webDriver != null)
            {
               Browser.Quit();
            }
        }
    }
}
