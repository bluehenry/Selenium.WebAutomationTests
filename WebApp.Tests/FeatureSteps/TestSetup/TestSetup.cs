using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApp.Test.Framework.Selenium;
using WebApp.Test.Framework.Support;

namespace WebApp.Tests.FeatureSteps.TestSetup
{
    [Binding]
    public class TestSetup 
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {   
            Browser.Initialize();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            if (Browser.WebDriver != null)
            {
                Browser.Quit();
            }
        }

    }
}
