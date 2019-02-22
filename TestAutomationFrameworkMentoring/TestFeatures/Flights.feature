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
		And I can book the flight
		And I enter personal details to finish booking <fname>, <lname>, <email>, <emailc>
		And I try enter coupon <number>
		And I book my reservation
	Then I can see summary of reservation

Examples: 
| fromCity | toCity | date       | fname  | lname      | email           | emailc          | number |
| Bro      | Sto    | 2019-03-01 | Joasia | Nowakowska | jkowalska@wp.pl | jkowalska@wp.pl | 154dd  |
| Sel      | Bir    | 2019-04-10 | Maciej | Kowalski   | maciej@op.pl    | maciej@op.pl    | 178_!  |
| Akr      | Tra    | 2019-07-30 | Pawel  | Sobieski   | psobieski@o2.pl | psobieski@o2.pl | test   |