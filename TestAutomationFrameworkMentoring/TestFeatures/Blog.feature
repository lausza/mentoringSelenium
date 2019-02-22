Feature: SpecFlowBlogPage
	In order to test demo site
	As a client I will open the page and make some functional tests


Scenario Outline: As a client I can open blog page
	Given Default page is opened
		And I click on blog link
		And I enter <search> value in quick search area
	When I press Search
	Then The result should be shown on the page

Examples: 
	| search  |
	| Beaches |
	| Africa  |
	| Rain    |
