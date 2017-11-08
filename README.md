# Web Application Automation Test Framekwork

WebAppAutomationTests is a C# Web application automation test framework powered by [Selenium](http://www.seleniumhq.org/) and [SpecFlow](http://specflow.org/). 

# Selenium
With Selenium you can create robust, browser-based regression automation suites and tests. Most of time, Selenium is quite straightforward: Find an element and perform an operation on it. Writing test scripts with Selenium WebDriver is much more than knowing the API; it involves programming, HTML, JavaScript, and web browsers.

# SpecFlow
SpecFlow is the official Cucumber implementation for .NET.  Behavior Driven Development(BDD) with SpecFlow provide a understandable communication method to people (Business Analyst, Test Analyst and Developer). 

# Automation Test Framework Features
 - Decouple Selenium test framework from business logical and test case. 
 - Provide a out-of-the-box automation test capability. So that testers can build up a test project for a new web application very quickly. 
 - With ASP.NET Data Access enable back end verification. In most of cases verifying test result from database is more effective and efficient. You can choose Entity Framework, Database Management Systems or any other options to access database.
 - Use SpecFlow to create features and scenarios. 

# Web application demostration
 - Multiple web browser support, like IE, Chrome etc.
 - Navigation 
 - Button
 - Text field
 - Radion button
 - Check list
 - Select list 
 - Pop-up window
 - Drag and drop file to import
 
# Selenium Technical tips  
## Select element from a web page
The following are the list of object identifier or locators supported by selenium.
Css
xpath               
id
Name
class name
Linktext
Partial Linktext
Tag Name

In most situation, we will use CSS and XPath.

### CSS Vs. XPath
There are a lot of discussion about CSS Vs. XPath. I don't think performance is a big issue. Because Selenium doesn't focus on performance testing. In most of cases page rendering take more time than identify a element.
You can also check this article [Css Vs. X Path](http://elementalselenium.com/tips/32-xpath-vs-css). 
The conclusion is "For starters there is no dramatic difference in performance between XPath and CSS."

The reason that I recommand to use CSS as far as possible is it is simple, particularly, when you can use id, name or class name.

However, if there is no id/name or they are dynamic you might think about XPath. With relative XPath, we can locate an element directly irrespective of its location in the DOM. For example we know a label text, then we can locate a input element beside it. Sometimes CSSSelecor change a lot when the UI is re-design. But the the relative path would not change.

```sh
    string xPath = $"//table[1]/tbody/*/td[2][text()='{scenarioName}']/../td[8]/div/button";
```

## Setup Browse option
```sh
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

                    var ieOptions = new InternetExplorerOptions();
                    ieOptions.IgnoreZoomLevel = true;
                    ieOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

                    // To resolve IWebElement.Sendkeys() is too slow
                    ieOptions.RequireWindowFocus = true;

                    // Setting attribute EnableNativeEvents to false enable click button in IE
                    ieOptions.EnableNativeEvents = false;

                    // Setting attribute EnablePersistentHover to false enable action.MoveToElement() in IE
                    //IEOptions.EnablePersistentHover = false;

                    WebDriver = new InternetExplorerDriver(driverPath, ieOptions);
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

                    WebDriver = new ChromeDriver(driverPath, chromeOptions);
                    TurnOnWati();
                }
                else
                {
                    throw new System.ArgumentException($"The browser type {_browserType} is not supported");
                }
            }
```

## Dealing with AJAX / Waiting a page loaded
 1. Wait within a time frame.
```sh
	System.Threading.Thread.Sleep(10000);
```

 2. Explicit waits until time out.
```sh	
	WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
	wait.Until(d => d.FindElement(By.Id("receiptNo")) );
```

 3. Implicit waits until time out
```sh 
    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
```

## Using Action Class to emulate advanced interactions, rather than using the Keyboard or Mouse directly.
```sh
	var element = Browser.WebDriver.FindElement(By.XPath(xPath));
	Actions actions = new Actions(Browser.WebDriver);
	actions.MoveToElement(element);
	actions.Perform();

	element.Click();
```

## Executes JavaScript in the context of the currently selected frame or window
```sh
((IJavaScriptExecutor) Browser.WebDriver).ExecuteScript("window.scrollTo(0,200)");
```