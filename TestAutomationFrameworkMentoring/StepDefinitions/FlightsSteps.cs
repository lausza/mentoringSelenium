using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Objectivity.Test.Automation.Common;
using TechTalk.SpecFlow;
using TestAutomationFrameworkMentoring.PageObjects;

namespace TestAutomationFrameworkMentoring.StepDefinitions
{
    [Binding]
    public sealed class FlightsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;

        public FlightsSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }
            this.scenarioContext = scenarioContext;
            this.driverContext = this.scenarioContext.Get<DriverContext>("DriverContext");
        }
        [When(@"I click on flights tab")]
        public void WhenIClickOnFlightsTab()
        {
            var flightsPage = new FlightsPage(this.driverContext);
            flightsPage.ClickOnFlightsBtn();
        }

        [When(@"I enter (.*) value")]
        public void WhenIEnterValue(string fromCity)
        {
            var flightsPage = new FlightsPage(this.driverContext);
            flightsPage.SetFromCity(fromCity);
        }

        [When(@"I enter location (.*)")]
        public void WhenIEnterLocationSel(string toCity)
        {
            var flightsPage = new FlightsPage(this.driverContext);
            flightsPage.SetToCity(toCity);
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
        [Then(@"I see results of my search")]
        public void ThenISeeResultsOfMySearch()
        {
            var flightsPage = new FlightsPage(this.driverContext);
        }



    }
}
