using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using WebApp.Test.Framework.Support;

namespace WebApp.Test.Framework
{
    public static class Browser
    {   
        public static IWebDriver webDriver { get; set; }

        public static string baseUrl { get; set; }

        public static string browserType { get; set; }

        public static void Initialize()
        {
            if ( webDriver == null )
            { 
                string strBrowserType = "";
                string driverPath = "";

                // Read from App.config
                baseUrl = TestEnvironment.BaseUrl;
                strBrowserType = ConfigurationManager.AppSettings["BrowserType"];
                driverPath = ConfigurationManager.AppSettings["BrowerDriverPath"];

                browserType = strBrowserType;

                if (browserType.Equals("IE"))
                {
                    foreach (var process in Process.GetProcessesByName("IEDriverServer"))
                    {
                        process.Kill();
                    }

                    var IEOptions = new InternetExplorerOptions();
                    IEOptions.IgnoreZoomLevel = true;
                    IEOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

                    // To resolve IWebElement.Sendkeys() is too slow
                    IEOptions.RequireWindowFocus = true;

                    // Setting attribute EnableNativeEvents to false enable click button in IE
                    IEOptions.EnableNativeEvents = false;

                    // Setting attribute EnablePersistentHover to false enable action.MoveToElement() in IE
                    //IEOptions.EnablePersistentHover = false;

                    webDriver = new InternetExplorerDriver(driverPath, IEOptions);
                    webDriver.Manage().Window.Maximize();
                    TurnOnWati();
                }
                else if (browserType.Equals("Chrome"))
                {
                    foreach (var process in Process.GetProcessesByName("chromedriver"))
                    {
                        process.Kill();
                    }

                    // Setting no-sandbox for TFS build agent
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("no-sandbox");

                    webDriver = new ChromeDriver(driverPath, chromeOptions);
                    webDriver.Manage().Window.Maximize();
                    TurnOnWati();
                }
                else
                {
                    throw new System.ArgumentException("The browser type " + browserType + " is not supported");
                }
            }
        }

        public static void Quit()
        {            
            webDriver.Quit();
        }

        private static void TurnOnWati()
        {            
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        private static void TurnOffWait()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        internal static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWati();
        }
    }
}
