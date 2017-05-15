using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Test.Framework;


namespace WebSite.Biz
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

        public void Select()
        {
            // Checkbox
            Browser.webDriver.FindElement(By.CssSelector("#checkBox1")).Click();
            Browser.webDriver.FindElement(By.CssSelector("#checkBox2")).Click();

            // Radio - WA
            Browser.webDriver.FindElement(By.CssSelector("#optionsRadios3")).Click();

            // Select - Perth
            IWebElement element = Browser.webDriver.FindElement(By.CssSelector("body > div > div:nth-child(3) > form > select"));
            SelectElement select = new SelectElement(element);
            select.SelectByText("Perth"); 

        }
    }
}
