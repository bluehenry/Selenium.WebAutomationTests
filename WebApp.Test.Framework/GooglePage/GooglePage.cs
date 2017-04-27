using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebApp.Test.Framework.GooglePage
{
    public class GooglePage
    {
        public void GoTo()
        {
            Browser.webDriver.Navigate().GoToUrl(Browser.baseUrl);
        }

        public bool IsAt()
        {
            IWebElement elment = Browser.webDriver.FindElement(By.CssSelector("#tsf > div.tsf-p > div.jsb > center > input[type='submit']:nth-child(1)"));

            return elment.TagName.Equals("input");
        }
    }
}
