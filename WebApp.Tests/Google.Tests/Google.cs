using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApp.Test.Framework;
using WebApp.Test.Framework.GooglePage;

namespace WebApp.Tests
{    

    [TestClass]
    public class GoogleTests
    {
        private GooglePage googlePage;

        public GoogleTests()
        {
            googlePage = new GooglePage();
        }

        [TestCategory("GoogleTests"), TestMethod]
        public void Can_Goto_GooglePage()
        {
            googlePage.GoTo();            
            Assert.IsTrue(googlePage.IsAt());
        }

    }
}
