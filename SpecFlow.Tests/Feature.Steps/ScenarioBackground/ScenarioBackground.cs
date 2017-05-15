using TechTalk.SpecFlow;
using WebApp.Test.Framework;
using WebSite.Biz;


namespace WebApp.Tests.Feature.Steps.ScenarioBackground
{
    [Binding]
    public class ScenarioBackground
    {
        [Given(@"I open up home page")]
        public void GivenGoToGoogle()
        {
            HomePage homePage = new HomePage();
            homePage.GoTo();
        }
        
    }
}
