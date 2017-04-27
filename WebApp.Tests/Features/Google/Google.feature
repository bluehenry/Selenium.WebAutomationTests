Feature: Google Search

Background: 
	Given I open up Google

Scenario Outline: Google Search 
	Given I input the following words  
	| KeyWord   |
	| <KeyWord> |
	When I click search button
	Then The search result should shows

	Examples: 
	| ScenarioName  | KeyWord |
	| Google Search | HMAS    |
