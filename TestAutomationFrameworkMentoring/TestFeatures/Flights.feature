Feature: SpecFlowFlightsPage
	In order to test demo site
	As a client I will open the page and make some functional tests

Scenario Outline: Verify flights page and search results
	Given Default page is opened
	When I click on flights tab
	And I enter <fromCity> value 
Examples: 
| fromCity |
| Puk      |
| Sto      |
| Asi      |

