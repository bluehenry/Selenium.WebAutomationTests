using System;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace WebApp.Test.Framework.Selenium
{
    public static class SeleniumHelper
    {

        public static void WaitElementVisible(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
        }

        public static void WaitElementExists(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementExists(by));
            }
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
