using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using WebApp.Test.Framework.Support;

namespace WebApp.Test.Framework.Selenium
{
    public static class Browser
    {
        public static IWebDriver WebDriver;

        public static string BaseUrl { get; set; }

        private static string _browserType;
        public static string BrowserType => _browserType;

        public static void Initialize()
        {
            if ( WebDriver == null )
            {
                TestEnvironment.Initialize();

                string strBrowserType = "";
                string driverPath = "";
                                
                BaseUrl = TestEnvironment.BaseUrl;

                // Read from App.config
                strBrowserType = ConfigurationManager.AppSettings["BrowserType"];
                driverPath = ConfigurationManager.AppSettings["BrowerDriverPath"];

                _browserType = strBrowserType;

                if (_browserType.Equals("IE"))
                {
                    foreach (var process in Process.GetProcessesByName("IEDriverServer"))
                    {
                        process.Kill();
                    }

                    var internetExplorerOptions = new InternetExplorerOptions();
                    internetExplorerOptions.IgnoreZoomLevel = true;
                    internetExplorerOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

                    // To resolve IWebElement.Sendkeys() is too slow
                    internetExplorerOptions.RequireWindowFocus = true;

                    // Setting attribute EnableNativeEvents to false enable click button in IE
                    internetExplorerOptions.EnableNativeEvents = false;

                    // Setting attribute EnablePersistentHover to false enable action.MoveToElement() in IE
                    //IEOptions.EnablePersistentHover = false;

                    WebDriver = new InternetExplorerDriver(driverPath, internetExplorerOptions);
                    WebDriver.Manage().Window.Maximize();
                    TurnOnWati();
                }
                else if (_browserType.Equals("Chrome"))
                {
                    foreach (var process in Process.GetProcessesByName("chromedriver"))
                    {
                        process.Kill();
                    }
                    
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("start-maximized");
                    //WebDriver.Manage().Window.Maximize();

                    // Setting no-sandbox for TFS build agent
                    chromeOptions.AddArguments("--no-sandbox");

                    //chromeOptions.AddArguments("start-maximized", "--no-sandbox", "--disable-popup-blocking", "--disable-extensions");

                    WebDriver = new ChromeDriver(driverPath, chromeOptions);
                    TurnOnWati();
                }
                else
                {
                    throw new System.ArgumentException($"The browser type {_browserType} is not supported");
                }
            }
        }

        public static void Quit()
        {            
            WebDriver.Quit();
        }

        private static void TurnOnWati()
        {            
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        private static void TurnOffWait()
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        internal static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWati();
        }
    }
}
