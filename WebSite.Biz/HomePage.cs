using System;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Selenium.WebTest.Framework.Browser;

namespace WebSite.Biz
{
    public class HomePage
    {
        public void GoTo()
        {
            Browser.WebDriver.Navigate().GoToUrl(Browser.BaseUrl);
        }
        
        public bool IsAt()
        {
            return true;
            //IWebElement h1 = Browser.WebDriver.FindElement(By.CssSelector("body > h1"));

            //return (h1.Text.ToString().Equals("Selenium test framework"));
        }

        public void Select()
        {
            // Checkbox
            Browser.WebDriver.FindElement(By.CssSelector("#checkBox1")).Click();
            Browser.WebDriver.FindElement(By.CssSelector("#checkBox2")).Click();

            // Radio - WA
            Browser.WebDriver.FindElement(By.CssSelector("#optionsRadios3")).Click();

            // Select - Perth
            IWebElement element = Browser.WebDriver.FindElement(By.CssSelector("body > div > div:nth-child(3) > form > select"));
            SelectElement select = new SelectElement(element);
            select.SelectByText("Perth"); 

        }

        public void Uploadfile(string filePath)
        {
            IWebElement fileSelect = Browser.WebDriver.FindElement(By.CssSelector("#fileselect"));
            if (Browser.BrowserType.Equals("Chrome"))
            {
                fileSelect.SendKeys(filePath);
            }
            else
            {
                // Choose File element is different on IE comparing with Chrome.
                fileSelect.Click();
                System.Threading.Thread.Sleep(5000);
                SendKeys.SendWait(filePath);
                System.Threading.Thread.Sleep(1000);
                SendKeys.SendWait(OpenQA.Selenium.Keys.Enter);
            }
        }

        public void ChangeHeader(string header)
        {
            if (SeleniumHelper.WaitElementExists(By.CssSelector("body > div:nth-child(2) > div:nth-child(1) > form > h2")))
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.WebDriver;
                js.ExecuteScript(
                    $"document.querySelector('body > div:nth-child(2) > div:nth-child(1) > form > h2').innerHTML='{header}'");

            }
            else
            {
                throw new ApplicationException("Cannot find email input element.");
            }
        }
    }
}
