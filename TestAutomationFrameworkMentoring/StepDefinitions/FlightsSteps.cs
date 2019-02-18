using System;
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
            this.page.EnterDepartDate(date);
        }

        [When(@"I set passenger numbers")]
        public void WhenISetPassengerNumbers()
        {
           this.page.SetTotalNumberOfPassengers();
        }

        [When(@"I confirm my choice")]
        public void WhenIConfirmMyChoice()
        {
           this.page.ConfirmPassengerNumbers();
        }

        [When(@"I click search button")]
        public void WhenIClickSearchButton()
        {
            this.page.ClickSearchBtnForFlights();
        }
        [Then(@"I see results of my search")]
        [When(@"I see results of my search")]
        public void ThenISeeResultsOfMySearch()
        {
            this.page.CheckResultsOfSearch();
        }
        [When(@"I set filter values")]
        public void WhenISetFilterValues()
        {
            this.page.SelectFilters();
        }

    }
}
