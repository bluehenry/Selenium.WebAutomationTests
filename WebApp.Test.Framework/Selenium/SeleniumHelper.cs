using System.Threading;
using OpenQA.Selenium;

namespace WebApp.Test.Framework.Selenium
{
    public static class SeleniumHelper
    {
        public static void WaitElementDisplayed(IWebElement element)
        {
            do
            {
                Thread.Sleep(1000);
            } while (element.Displayed == false);
        }

        public static void ForceClick(IWebElement element)
        {
            if (Browser.BrowserType.Equals("Chrome"))
            {
                element.Click();
            }
            else
            {
                element.SendKeys(Keys.Enter);
            }
        }

    }
}
