using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;

namespace TestAutomationFrameworkMentoring.PageObjects
{
    public class FlightsPage
    {
        private readonly DriverContext driverContext;

        public FlightsPage(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }

        private readonly ElementLocator
            flightsBtn = new ElementLocator(Locator.XPath, "//a[@title=\"Flights\"]");

        public void ClickOnFlightsBtn()
        {
            this.driverContext.Driver.GetElement(flightsBtn).Click();
        }
    }
}
