using System;
using Objectivity.Test.Automation.Common;
using TechTalk.SpecFlow;
using TestAutomationFrameworkMentoring.PageObjects;

namespace TestAutomationFrameworkMentoring.StepDefinitions
{
    [Binding]
    public sealed class BlogSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private BlogPage page;
   

        public BlogSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }
            this.scenarioContext = scenarioContext;
            this.driverContext = this.scenarioContext.Get<DriverContext>("DriverContext");
            this.page = new BlogPage(driverContext);
        }

        [Given(@"I click on blog link")]
        public void GivenIClickOnBlogLink()
        {
           this.page.ClickOnBlogLink();
        }

        [Given(@"I enter (.*) value in quick search area")]
        public void GivenIEnterValueInQuickSearchArea(string searchValue)
        {
           this.page.SearchForElement(searchValue);
        }

        [When(@"I press Search")]
        public void WhenIPressSearch()
        {
            this.page.ClickOnSearchBtn();
        }

        [Then(@"The result should be shown on the page")]
        public void ThenTheResultShouldBeShownOnThePage()
        {
            this.page.CheckResultsOnPage();
        }


    }
}
