using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium.WebTest.Framework.Browser
{
    public static class SeleniumHelper
    {

        public static bool WaitElementVisible(By by, int timeoutInSeconds = 15 )
        {
            bool result = false;

            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(by));
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    result = false;
                }
            }
            return result;
        }

        public static bool WaitElementExists(By by, int timeoutInSeconds = 15 )
        {
            bool result = false;

            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(Browser.WebDriver, TimeSpan.FromSeconds(timeoutInSeconds));

                try
                {
                    wait.Until(ExpectedConditions.ElementExists(by));
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    result = false;
                }
            }
            return result;
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

        public static void MoveTo(By by)
        {
            IWebElement element = Browser.WebDriver.FindElement(by);
            Actions actions = new Actions(Browser.WebDriver);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}
