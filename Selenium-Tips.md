# Selenium Technical Tips  
## Select element from a web page
The following are the list of object identifier or locators supported by selenium.
- CSS
- XPath               
- ID
- Name
- Class Name
- Linktext
- Partial Linktext
- Tag Name

ID/Name is the first choose. However, if there is no ID/Name or they are dynamic you might think about CSS or XPath. 

Sometimes CSS Selecor change a lot when the UI is re-design. In this case, XPath might be a good option.

### CSS Vs. XPath
There are a lot of discussion about CSS Vs. XPath. I don't think performance is a big issue. Because Selenium doesn't focus on performance testing. In most of cases page rendering take more time than identify an element.
You can also check this article [Css Vs. XPath](http://elementalselenium.com/tips/32-xpath-vs-css). 
The conclusion is "For starters there is no dramatic difference in performance between XPath and CSS."

### Using ID in CssSelector
```C
By.CssSelector("#ID")
```

### Using Name in CssSelector
```C
By.CssSelector(".Name")
```

### SelectByText()
```C
    SelectElement select = new SelectElement(element);
    select.SelectByText("Perth"); 
```

### Using text get element in XPath
```C
By.XPath("//td[text()='Profile']")

By.XPath("//a[contains(text(),'Profile')]")
```

With relative XPath, we can locate an element directly as well irrespective of its location in the DOM. 

```C
By.XPath("//table/*/td[2][text()='Profile}']/../td[8]/div/button");
```

### JavaScript: Get Elements by ID, Tag, Name, Class, CSS Selector
```
    IJavaScriptExecutor js = (IJavaScriptExecutor)Browser.WebDriver;
    js.ExecuteScript(
        $"document.querySelector('#createModal > div > div > div.modal-body > div:nth-child(1) > span > span > span.k-input.ng-scope').innerHTML='{baseLine}'");
```

## Setup Browse option
```C
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
```C
System.Threading.Thread.Sleep(10000);
```

 2. Explicit waits until time out.
```C	
WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
wait.Until(d => d.FindElement(By.Id("receiptNo")) );
```

 3. Implicit waits until time out
```C 
webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
```

## Using Action Class to emulate advanced interactions, rather than using the Keyboard or Mouse directly.
```C
var element = Browser.WebDriver.FindElement(By.XPath(xPath));
Actions actions = new Actions(Browser.WebDriver);
actions.MoveToElement(element);
actions.Perform();

element.Click();
```

## Executes JavaScript in the context of the currently selected frame or window
```C
((IJavaScriptExecutor) Browser.WebDriver).ExecuteScript("window.scrollTo(0,200)");
```

## Dealing with Element is not currently visible and may not be manipulated exception
```C
// Click the parent node make select element visible
Browser.WebDriver.FindElement(By.CssSelector("#createModal > div > div > div.modal-body > div:nth-child(1) > span > span > span.k-select")).Click();

new Actions(Browser.WebDriver)
    .MoveToElement(Browser.WebDriver.FindElement(By.CssSelector("#scenarioDropdown"))).SendKeys(baseLine).Perform();
```
## Upload File
Note: Can't run in C# debug mode
```C
using System.Windows.Forms;

    SendKeys.SendWait(@"C:\temp\avatar.jpg");
    SendKeys.SendWait(@"{Enter}");
```

## Windows Security
Add user name and password in front of URL. Encrypt password in your code, so others can't see the password.
```C
BaseUrl = $"https://{UserName}:{Password}@{BaseUrl}";
```

## Using Actions class to first focus on the element then send required keys.
Please try Actions class to first focus on the element then send required keys.
```C
    Actions actions = new Actions(driver);
    actions.moveToElement(element);
    actions.click();
    actions.sendKeys("SOME DATA");
    actions.build().perform();
```

## Troubleshooting
### IELaunchURL() error
```
OpenQA.Selenium.WebDriverException: 'Unexpected error launching Internet Explorer. Unable to use CreateProcess() API. To use CreateProcess() with Internet Explorer 8 or higher, the value of registry setting in HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\TabProcGrowth must be '0'.'
```