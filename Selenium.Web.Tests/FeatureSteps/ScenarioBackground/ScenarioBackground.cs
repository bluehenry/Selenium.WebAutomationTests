using TechTalk.SpecFlow;
using WebSite.Biz;


namespace Selenium.Web.Tests.FeatureSteps.ScenarioBackground
{
    [Binding]
    public class ScenarioBackground
    {
        [Given(@"I open up home page")]
        public void GivenGoToHomePage()
        {
            HomePage homePage = new HomePage();
            homePage.GoTo();
        }
        
    }
}
