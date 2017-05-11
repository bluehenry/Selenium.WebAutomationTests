using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Test.Framework;
using WebSite.Pages.Selenium;

namespace WebApp.Tests
{    

    [TestClass]
    public class WebSiteTests
    {
        private HomePage homePage;

        public WebSiteTests()
        {
            homePage = new HomePage();
        }

        [TestMethod]
        public void Can_Goto_HomePage()
        {
            homePage.GoTo();            
            Assert.IsTrue(homePage.IsAt());
        }

    }
}
