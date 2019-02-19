using System;
using System.Globalization;
using NLog;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Tests.PageObjects;

namespace TestAutomationFrameworkMentoring.StepDefinitions
{
    internal class HomePage : ProjectPageBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public HomePage(DriverContext driverContext) : base(driverContext)
        {
        }
        public HomePage OpenHomePage()
        {
            try
            {
                var url = BaseConfiguration.GetUrlValue;
                this.Driver.NavigateTo(new Uri(url));
                Logger.Info(CultureInfo.CurrentCulture, "Opening page {0}", url);
                return this;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

           


        }
    }
}