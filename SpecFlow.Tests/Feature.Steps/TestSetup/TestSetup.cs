using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApp.Test.Framework;
using WebApp.Test.Framework.Support;

namespace WebApp.Tests.Feature.Steps
{
    [Binding]
    public class TestSetup 
    {
        [BeforeFeature]
        public static void BeforeFeature()
        {
            TestEnvironment.Initialize();
            Browser.Initialize();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            if (Browser.webDriver != null)
            {
                Browser.Quit();
            }
        }

    }
}
