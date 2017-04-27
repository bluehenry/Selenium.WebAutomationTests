using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;
using ExpectedObjects;
using WebApp.Test.Framework;
using WebApp.Test.Framework.GooglePage;


namespace WebApp.Tests.Feature.Steps.ScenarioBackground
{
    [Binding]
    public class ScenarioBackground
    {
        [Given(@"I open up Google")]
        public void GivenGoToGoogle()
        {
            GooglePage googlePage = new GooglePage();
            googlePage.GoTo();
        }
    }
}
