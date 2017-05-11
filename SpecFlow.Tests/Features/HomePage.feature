Feature: Google Search

Background: 
	Given I open up home page

Scenario Outline: Submit form 
	Given I input the following information  
	| EmailAddress   | Password   | FilePath   | CheckMeOut   |
	| <EmailAddress> | <Password> | <FilePath> | <CheckMeOut> |
	When I click submit button
	Then The result should show

	Examples: 
	| ScenarioName | EmailAddress          | Password | FilePath                   | CheckMeOut |
	| Scenario_1   | jijun.henry@gmail.com | passw0rd | .\TestData\UploadFIleA.txt | yes        |
