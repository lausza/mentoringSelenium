namespace TestAutomationFrameworkMentoring.PageObjects
{

    using Objectivity.Test.Automation.Common;
    using Objectivity.Test.Automation.Common.Extensions;
    using Objectivity.Test.Automation.Common.Types;
    using Objectivity.Test.Automation.Tests.PageObjects;

    public class TourReviewPanelPage : ProjectPageBase
    {
        private  readonly ElementLocator submitButton = new ElementLocator(Locator.CssSelector, "#ADDREVIEW .btn.btn-primary");
        private readonly ElementLocator nameInput = new ElementLocator(Locator.CssSelector, "#ADDREVIEW input[name='fullname']");
        private readonly ElementLocator emailInput = new ElementLocator(Locator.CssSelector, "#ADDREVIEW input[name='email']");
        private readonly ElementLocator closePanelButton = new ElementLocator(Locator.CssSelector, "#ADDREVIEW span.badge");
        private readonly ElementLocator descriptionInput = new ElementLocator(Locator.CssSelector, "#ADDREVIEW input[name='reviews_comments']");

        private readonly ElementLocator pleaseNoteText = new ElementLocator(Locator.CssSelector, "#ADDREVIEW p");

        public TourReviewPanelPage(DriverContext driver) : base(driver)
        {
        }

        public string PleaseNoteText => this.Driver.GetElement(this.pleaseNoteText).Text;


        public void SubmitReview()
        {
            this.Driver.GetElement(this.submitButton).Click();
        }

        public TourReviewPanelPage EnterName(string name)
        {
            return this;
        }

        public TourReviewPanelPage EnterEmail(string emailAddress)
        {
            return this;
        }

        public TourReviewPanelPage EnterDescription(string reviewDescription)
        {
            return this;
        }

        public TourReviewPanelPage CloseReviewTourPanel(string name)
        {
            return this;
        }
    }
}
