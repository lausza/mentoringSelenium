Feature: SpecFlowFlightsPage

Scenario Outline: Verify flights page and search results
	Given Default page is opened
	When I click on flights tab
		And I enter <fromCity> value
		And I enter location <toCity> 
		And I enter <date> of departure
		And I set passenger numbers
		And I confirm my choice
		And I click search button
	Then I see results of my search

	Examples: 
	| fromCity | toCity | date       |
	| Elfas    | Sel    | 2019-03-01 |
	| Sto      | Bir    | 2019-04-10 |
	| Asi      | Tra    | 2019-07-30 |

@Flight
Scenario: Flight reservation
	Given Default page is opened
	When I click on flights tab on home page
	Then Flights search control is displayed on home page
	When I enter flight search parameters on home page
		| OriginCity | DestinationCity |
		| Elfas      | Sel             |
		And I confirm my choice
	Then 
