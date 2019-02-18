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

Scenario Outline: Verify hotels search and book one
	Given Default page is opened
	When I click on hotels tab
		And I set attributes for <cityname>
		And I choose date for <checkinDate> and <checkoutDate>
		And I add child to travellers
		And I click on search button
		And I can see at least one result of my search
		And I choose first hotel from the list
		And I book selected hotel
		And I set form <fname>, <lname>, <email>, <emailc>, <mobile>, <address>, <country> values
		And I click on confirmation this booking button

Examples:
| cityname | checkinDate | checkoutDate | fname   | lname          | email            | emailc           | mobile       | address | country |
| Zabol    | 12/02/2019  | 28/02/2019   | Julia   | Kowalska       | jkowal@wp.pl     | jkowal@wp.pl     | +48520963410 | Wroclaw | Poland  |
| Kazan    | 27/07/2019  | 05/09/2019   | Mateusz | Nowak          | mnowak@gmail.com | mnowak@gmail.com | +49574123698 | Berlin  | Germany |
| Malaysia | 01/12/2019  | 10/01/2020   | Antek   | Blaszczykowski | ablasz@o2.pl     | ablasz@o2.pl     | +49856954000 | Rome    | Italy   |

