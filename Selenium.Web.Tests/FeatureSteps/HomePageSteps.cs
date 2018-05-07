using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using Selenium.WebTest.Framework.Browser;


namespace Selenium.Web.Tests.FeatureSteps
{
    [Binding]
    class HomePageSteps
    {   
        private IEnumerable<HomePageStepsParameters> _homePageStepsParameters;

        [Given(@"I input the following information")]
        public void GivenIInputTheFollowingWords(Table table)
        {
            _homePageStepsParameters = table.CreateSet<HomePageStepsParameters>();

            foreach (var parameters in _homePageStepsParameters)
            {
                // Select element with id
                IWebElement emailAddress = Browser.WebDriver.FindElement(By.CssSelector("#exampleInputEmail"));

                // Clear input element before input
                emailAddress.Clear();
                emailAddress.SendKeys(parameters.EmailAddress);

                IWebElement password = Browser.WebDriver.FindElement(By.CssSelector("#exampleInputPassword"));
                password.Clear();
                password.SendKeys(parameters.Password);


                IWebElement filePath = Browser.WebDriver.FindElement(By.CssSelector("#exampleInputFile"));
                if (Browser.BrowserType.Equals("Chrome"))
                {
                    filePath.SendKeys(parameters.FilePath);
                }
                else
                {
                    // Choose File element is different on IE comparing with Chrome.
                    filePath.Click();
                    System.Threading.Thread.Sleep(5000);
                    SendKeys.SendWait(parameters.FilePath);
                    System.Threading.Thread.Sleep(1000);
                    SendKeys.SendWait(OpenQA.Selenium.Keys.Enter);
                }
              
                // Select element with CSS selector
                IWebElement checkMeOut = Browser.WebDriver.FindElement(By.CssSelector("body > div > div:nth-child(1) > form > div.checkbox > label > input[type='checkbox']"));
                if ( parameters.CheckMeOut.Equals("Yes"))
                {
                    if (!checkMeOut.Selected)
                        checkMeOut.Click();
                }
                else if (parameters.CheckMeOut.Equals("No"))
                {
                    if (checkMeOut.Selected)
                        checkMeOut.Click();
                } else
                {
                    throw new ArgumentException($"CheckMeOut value '{parameters.CheckMeOut}' is wrong.");
                }
                
            }
        }

        [When(@"I click submit button")]
        public void WhenIClickSearchButton()
        {
           Browser.WebDriver.FindElement(By.CssSelector("#Submit")).Click();
        }

        [Then(@"The result should be saved successfully")]
        public void ThenTheSearchResultShouldShows()
        {
            // Add back verification in here, like database checking.
            IWebElement message = Browser.WebDriver.FindElement(By.CssSelector("#message"));

            Assert.IsTrue(message.Text.ToString().Equals("Your input is saved successfully."));
        }

    }
}
