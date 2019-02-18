Feature: SpecFlowFlightsPage
	In order to test demo site
	As a client I will open the page and make some functional tests

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

Scenario Outline: Verify flights page and make some custom search
	Given Default page is opened
	When I click on flights tab
		And I enter <fromCity> value
		And I enter location <toCity> 
		And I enter <date> of departure
		And I set passenger numbers
		And I confirm my choice
		And I click search button
		And I see results of my search
		And I set filter values


Examples: 
| fromCity | toCity | date       |
| Bro      | Sto    | 2019-03-01 |
| Sel      | Bir    | 2019-04-10 |
| Akr      | Tra    | 2019-07-30 |