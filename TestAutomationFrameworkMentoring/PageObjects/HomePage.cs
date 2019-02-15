using System;
using System.Globalization;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;

namespace TestAutomationFrameworkMentoring.StepDefinitions
{
    public class HomePage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly ElementLocator flightSearchControl = new ElementLocator(Locator.CssSelector, "div[id='flights']");


        public HomePage(DriverContext driverContext) : base(driverContext)
        {
        }
        public HomePage OpenHomePage()
        {
            var url = BaseConfiguration.GetUrlValue;
            this.Driver.NavigateTo(new Uri(url));
            Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", url);
            return this;
        }

        public void CheckFlightSearchVisability()
        {
            
        }
    }
}