using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using WebApp.Test.Framework;
using WebApp.Test.Framework.GooglePage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApp.Tests.Feature.Steps.Google
{
    [Binding]
    class EditTTRConfigurationSteps
    {   
        IEnumerable<GoogleStepsParameters> googleStepsParameters;

        [Given(@"I input the following words")]
        public void GivenIInputTheFollowingWords(Table table)
        {
            IEnumerable<GoogleStepsParameters> googleStepsParameters = table.CreateSet<GoogleStepsParameters>();

            foreach (var parameters in googleStepsParameters)
            {
                Browser.webDriver.FindElement(By.CssSelector("#lst-ib")).SendKeys(parameters.KeyWord);
            }
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            Browser.webDriver.FindElement(By.CssSelector("#_fZl > span > svg")).Click();
        }

        [Then(@"The search result should shows")]
        public void ThenTheSearchResultShouldShows()
        {
           //
        }

    }
}
