using System;
using Objectivity.Test.Automation.Common;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutomationFrameworkMentoring.Helpers;
using TestAutomationFrameworkMentoring.PageObjects;

namespace TestAutomationFrameworkMentoring.StepDefinitions

{
    [Binding]
    public sealed class FlightsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private FlightsPage page;

        public FlightsSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }
            this.scenarioContext = scenarioContext;
            this.driverContext = this.scenarioContext.Get<DriverContext>("DriverContext");
            this.page = new FlightsPage(driverContext);
        }

        [When(@"I click on flights tab")]
        [When(@"I click on flights tab on home page")]
        public void WhenIClickOnFlightsTab()
        {
           this.page.ClickOnFlightsBtn();
        }

        [When(@"I enter (.*) value")]
        public void WhenIEnterValue(string fromCity)
        {
            this.page.SetFromCity(fromCity);
        }

        [When(@"I enter location (.*)")]
        public void WhenIEnterLocationSel(string toCity)
        {
            this.page.SetToCity(toCity);
        }

        [When(@"I enter (.*) of departure")]
        public void WhenIEnterOfDeparture(string date)
        {
            var flightsPage = new FlightsPage(this.driverContext);
            flightsPage.EnterDepartDate(date);
        }

        [When(@"I set passenger numbers")]
        public void WhenISetPassengerNumbers()
        {
            var flightsPage = new FlightsPage(this.driverContext);
            flightsPage.SetTotalNumberOfPassengers();
        }

        [When(@"I confirm my choice")]
        public void WhenIConfirmMyChoice()
        {
            var flightsPage = new FlightsPage(this.driverContext);
            flightsPage.ConfirmPassengerNumbers();
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            var flightsPage = new FlightsPage(this.driverContext);
            flightsPage.ClickSearchBtnForFlights();
        }

        [When(@"I enter flight search parameters on home page")]
        public void SetFlightReservationDetails(Table table)
        {
            var flightReservationDetails = table.CreateInstance<FlightSearchParameters>();
            this.page.SetFromCity(flightReservationDetails.OriginCity);
            this.page.SetToCity(flightReservationDetails.DestinationCity);
            this.page.EnterDepartDate(flightReservationDetails.DepartureDate);

            if (flightReservationDetails.IsRoundTrip)
            {
                this.page.SetOneWayOrRoundTrip(flightReservationDetails.IsRoundTrip);
                //this.page.EnterReturnDate(flightReservationDetails.ReturnDate);
            }
            else
            {
                this.page.SetOneWayOrRoundTrip(flightReservationDetails.IsRoundTrip);
            }
        }

        [Then(@"I see results of my search")]
        public void ThenISeeResultsOfMySearch()
        {
            var flightsPage = new FlightsPage(this.driverContext);
        }
    }
}
