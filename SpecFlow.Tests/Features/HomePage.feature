Feature: Home Page

Background: 
	Given I open up home page

Scenario Outline: Input and submit form 
	Given I input the following information  
	| EmailAddress   | Password   | FilePath   | CheckMeOut   |
	| <EmailAddress> | <Password> | <FilePath> | <CheckMeOut> |
	When I click submit button
	Then The result should be saved successfully

	Examples: 
	| ScenarioName | EmailAddress          | Password | FilePath         | CheckMeOut |
	| Scenario_1   | jijun.henry@gmail.com | passw0rd | C:\temp\test.txt | Yes        |