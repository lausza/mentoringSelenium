using System;
using Objectivity.Test.Automation.Common;
using TechTalk.SpecFlow;
using TestAutomationFrameworkMentoring.PageObjects;

namespace TestAutomationFrameworkMentoring.StepDefinitions
{
    [Binding]
    public sealed class HotelsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private HotelsPage page;
        public HotelsSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }
            this.scenarioContext = scenarioContext;
            this.driverContext = this.scenarioContext.Get<DriverContext>("DriverContext");
            this.page = new HotelsPage(driverContext);
        }
        [When(@"I click on hotels tab")]
        public void WhenIClickOnHotelsTab()
        {
            this.page.ClickOnHotelsBtn();
        }
        [When(@"I set attributes for (.*)")]
        public void WhenISetAttributesForCityName(string cityName)
        {
            this.page.SearchByValues(cityName);
        }
        [When(@"I choose date for (.*) and (.*)")]
        public void WhenIChooseDateForAnd(string checkin, string checkout)
        {
            this.page.SetDates(checkin, checkout);
        }
        [When(@"I add child to travellers")]
        public void WhenIAddChildToTravellers()
        {
            this.page.SetTravellers();
        }
        [When(@"I click on search button")]
        public void WhenIClickOnSearchButton()
        {
            this.page.ClickOnSearchBtn();
        }
        [Then(@"I can see at least one result of my search")]
        [When(@"I can see at least one result of my search")]
        public void ThenICanSeeAtLeastOneResultOfMySearch()
        {
            this.page.CheckResultTable();
        }
        [When(@"I choose first hotel from the list")]
        public void WhenIChooseFirstFromTheList()
        {
            this.page.ClickOnDetailsBtn();
        }
        [When(@"I book selected hotel")]
        public void WhenIBookSelectedHotel()
        {
            this.page.BookSelectedHotel();
        }
        [When(@"I set form (.*),(.*), (.*), (.*), (.*), (.*), (.*) values")]
        public void WhenISetFormWithValus(string name, string lname, string email, string emailc, string mobile, string address, string country)
        {
            this.page.SetFormFields(name, lname, email, emailc, mobile, address, country);
        }
        [When(@"I click on confirmation this booking button")]
        public void WhenIClickOnConfirmationThisBookingButton()
        {
           this.page.ConfirmHotelBooking();
        }

        [Then(@"I get invoice document")]
        public void ThenIGetInvoiceDocument()
        {
            this.page.GetInvoiceDocument();
        }

    }
}
