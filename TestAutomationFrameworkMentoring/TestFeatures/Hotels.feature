Feature: SpecFlowHotelsPage
	In order to test demo site
	As a client I will open the page and make some functional tests

Scenario Outline: Verify hotels page and search results
	Given Default page is opened
	When I click on hotels tab
	And I set attributes for <cityname>
	And I choose date for <checkinDate> and <checkoutDate>
	And I add child to travellers
	And I click on search button
	Then I can see at least one result of my search

Examples:
| cityname | checkinDate | checkoutDate |
| Lond     | 12/02/2019  | 28/02/2019   |
| War      | 27/07/2019  | 05/09/2019   |
| Ala      | 01/12/2019  | 10/01/2020   |

