# WebAppAutomationTests

WebAppAutomationTests is a C# solution. 

WebApp.Test.Framework project provides basic web application automation test funcation with Selenium.
I use singleton design pattern to create a Browser object. So that every test case runs on a same browser and don't restart a browser during test.

WebApp.Tests is a MSTest project. Users can unit test framework to run Selenium tests.

Also I demostrate use SpecFlow (Busisness Description Language - Cucumber for .NET) to create features and senarios. 
