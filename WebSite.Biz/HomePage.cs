using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebApp.Test.Framework;
using System.Windows.Forms;

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

        public void Uploadfile(string filePath)
        {
            IWebElement fileSelect = Browser.webDriver.FindElement(By.CssSelector("#fileselect"));
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
    }
}
