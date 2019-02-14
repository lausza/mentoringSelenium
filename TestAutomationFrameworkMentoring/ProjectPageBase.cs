
namespace Objectivity.Test.Automation.Tests.PageObjects
{
    using Objectivity.Test.Automation.Common;

    using OpenQA.Selenium;

    public partial class ProjectPageBase
    {
        public ProjectPageBase(DriverContext driverContext)
        {
            this.DriverContext = driverContext;
            this.Driver = driverContext.Driver;
        }

        protected IWebDriver Driver { get; set; }

        protected DriverContext DriverContext { get; set; }
    }
}
