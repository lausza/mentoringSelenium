namespace TestAutomationFrameworkMentoring.StepDefinitions
{
    using TechTalk.SpecFlow;
    using Objectivity.Test.Automation.Common;
    using PageObjects;
    using FluentAssertions;

    [Binding]
    public class TourReviewPanelSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private readonly TourReviewPanelPage page;

        public TourReviewPanelSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            this.driverContext = this.scenarioContext.Get<DriverContext>("DriverContext");
            this.page = new TourReviewPanelPage(driverContext);
        }

        [Then(@"Please note text is displayed on add review on tour overview page")]
        public void CheckPleaseNoteText()
        {
            this.page.PleaseNoteText.Contains("Once review added cannot be deleted or updated").Should().BeTrue();
        }
    }
}
