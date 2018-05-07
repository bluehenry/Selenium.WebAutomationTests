using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.WebTest.Framework.Browser;

namespace Selenium.Web.Tests.TestSetup
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
