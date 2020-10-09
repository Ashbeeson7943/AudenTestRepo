Feature: SetUpCheckFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

@mytag
Scenario: Loading a browser
	Given I want to see a browser
	When I open chrome
	Then as new browser window should be displayed 
