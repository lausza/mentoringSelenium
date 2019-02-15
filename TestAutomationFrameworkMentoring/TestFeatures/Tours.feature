Feature: Tours

@Tours
Scenario: Book tours from home page
	Given Default page is opened
	When I book tour HONG KONG ISLAND TOUR on home page
	Then Tour overview page is displayed with following details
		|  |
		|  |
		And 
	