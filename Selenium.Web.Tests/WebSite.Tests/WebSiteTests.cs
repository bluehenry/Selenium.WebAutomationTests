using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSite.Biz;

namespace Selenium.Web.Tests.WebSite.Tests
{    

    [TestClass]
    public class WebSiteTests
    {
        private readonly HomePage _homePage;

        public WebSiteTests()
        {
            _homePage = new HomePage();
        }

        [TestMethod]
        public void Can_Goto_HomePage()
        {
            _homePage.GoTo();            
            Assert.IsTrue(_homePage.IsAt());
        }


        [TestMethod]
        public void Can_Select()
        {
            _homePage.GoTo();
            _homePage.Select();
        }

        [TestMethod]
        public void Can_UploadFile()
        {
            _homePage.GoTo();

            string filePath = @"C:\temp\test.txt";
            _homePage.Uploadfile(filePath);
        }

        [TestMethod]
        public void PutEmailTests()
        {
            _homePage.GoTo();

            string header = "Execute Java Script test";
            _homePage.ChangeHeader(header);
        }
    }
}
