using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Test.Framework.Selenium;

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
            if (Browser.WebDriver != null)
            {
               Browser.Quit();
            }
        }
    }
}
