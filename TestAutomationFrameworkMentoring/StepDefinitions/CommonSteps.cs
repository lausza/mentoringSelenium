using System;
using System.Globalization;
using Objectivity.Test.Automation.Common;
using TechTalk.SpecFlow;
using NUnit.Framework;
using TestAutomationFrameworkMentoring.StepDefinitions;


namespace Objectivity.Test.Automation.Tests.Features.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private readonly DriverContext driverContext;
        private readonly ScenarioContext scenarioContext;
        private readonly HomePage homePage; 

        public CommonSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;
            this.driverContext = this.scenarioContext.Get<DriverContext>("DriverContext");

            if (homePage == null)
            {
                this.homePage = new HomePage(driverContext);
            }
        }

        [Given(@"Default page is opened")]
        public void GivenDefaultPageIsOpened()
        {
            new HomePage(this.driverContext).OpenHomePage();
        }
    }
}