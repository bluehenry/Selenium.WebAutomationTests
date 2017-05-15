# WebAppAutomationTests

WebAppAutomationTests is a C# Web application test framework powered by [Selenium](http://www.seleniumhq.org/) and [SpecFlow](http://specflow.org/). 

Most of time, Selenium is quite straightforward: Find an element and perform an operation on it. Writing test scripts with Selenium WebDriver is much more than knowing the API; it involves programming, HTML, JavaScript, and web browsers.

# Features
 - Decouple Selenium test framework from business logical.
 - Provide database access function to enable back end verification.
 - Use SpecFlow to create features and scenarios. 

# Web application demostration
 - Multiple web browser support
 - Navigation 
 - Button
 - Text field
 - Radion button
 - Check list
 - Select list 
 - Pop-up window
 
# Deal with AJAX
 - Wait within a time frame.
	System.Threading.Thread.Sleep(10000);
 - Explicit waits until time out.
	WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
	wait.Until(d => d.FindElement(By.Id("receiptNo")) );
 - Implicit waits until time out
    webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);


 
**Free Software, Hell Yeah!**
