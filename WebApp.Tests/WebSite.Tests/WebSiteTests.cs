using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Test.Framework;
using WebSite.Biz;

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


        [TestMethod]
        public void Can_Select()
        {
            homePage.GoTo();
            homePage.Select();
        }

    }
}
