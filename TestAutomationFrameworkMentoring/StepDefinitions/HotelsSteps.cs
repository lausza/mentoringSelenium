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
    public sealed class HotelsSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;

        public HotelsSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;
            this.driverContext = this.scenarioContext.Get<DriverContext>("DriverContext");
        }

        [When(@"I click on hotels tab")]
        public void WhenIClickOnHotelsTab()
        {
            var homePage = new HotelsPage(this.driverContext);
            homePage.ClickOnHotelsBtn();
        }

        [When(@"I set attributes for (.*)")]
        public void WhenISetAttributesForCityName(string cityName)
        {
            var homePage = new HotelsPage(this.driverContext);
            homePage.SearchByValues(cityName);
        }

        [When(@"I choose date for (.*) and (.*)")]
        public void WhenIChooseDateForAnd(string checkin, string checkout)
        {
            var homePage = new HotelsPage(this.driverContext);
            homePage.SetDates(checkin,checkout);
        }
        [When(@"I add child to travellers")]
        public void WhenIAddChildToTravellers()
        {
            var homePage = new HotelsPage(this.driverContext);
            homePage.SetTravellers();
        }


        [When(@"I click on search button")]
        public void WhenIClickOnSearchButton()
        {
            var homePage = new HotelsPage(this.driverContext);
            homePage.ClickOnSearchBtn();
        }

        [Then(@"I can see at least one result of my search")]
        public void ThenICanSeeAtLeastOneResultOfMySearch()
        {
            var homePage = new HotelsPage(this.driverContext);
            homePage.CheckResultTable();
        }
    }
}
