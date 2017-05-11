using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Test.Framework;


namespace WebSite.Pages.Selenium
{
    public class HomePage
    {
        public void GoTo()
        {
            Browser.webDriver.Navigate().GoToUrl(Browser.baseUrl);
        }
        
        public bool IsAt()
        {
            IWebElement h1 = Browser.webDriver.FindElement(By.CssSelector("body > h1"));

            return (h1.Text.ToString().Equals("Selenium test framework"));
        }
    }
}
