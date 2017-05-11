using TechTalk.SpecFlow;
using WebApp.Test.Framework;
using WebSite.Pages.Selenium;


namespace WebApp.Tests.Feature.Steps.ScenarioBackground
{
    [Binding]
    public class ScenarioBackground
    {
        [Given(@"I open up home page")]
        public void GivenGoToGoogle()
        {
            HomePage indexPage = new HomePage();
            indexPage.GoTo();
        }
    }
}
