using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationFrameworkMentoring.PageObjects
{
    public class FlightsPage
    {
        private readonly DriverContext driverContext;

        private readonly ElementLocator
            fromField = new ElementLocator(Locator.Id, "s2id_location_from"),
            cityFromName = new ElementLocator(Locator.CssSelector, "div#select2-drop input"),
            firstFromCity = new ElementLocator(Locator.XPath,
                "//li[@class=\"select2-results-dept-0 select2-result select2-result-selectable select2-highlighted\"]"),
            toField = new ElementLocator(Locator.Id, "s2id_location_to"),
            cityToName = new ElementLocator(Locator.CssSelector, "div#select2-drop input"),
            firstToCity = new ElementLocator(Locator.XPath,
                "//li[@class=\"select2-results-dept-0 select2-result select2-result-selectable select2-highlighted\"]"),
            departDate = new ElementLocator(Locator.Name, "departure"),
            passengersField = new ElementLocator(Locator.Name, "totalManualPassenger"),
            adultsField = new ElementLocator(Locator.XPath, "//select[@name=\"madult\"]"),
            childField = new ElementLocator(Locator.XPath, "//select[@name=\"mchildren\"]"),
            minfantField = new ElementLocator(Locator.XPath, "//select[@name=\"minfant\"]"),
            doneBtn = new ElementLocator(Locator.Id, "sumManualPassenger"),
            searchBtn = new ElementLocator(Locator.CssSelector,
                "form[name=\"flightmanualSearch\"] button[type=\"submit\"]"),
            results = new ElementLocator(Locator.CssSelector, "table#load_data tr:nth-child(1) > td");






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

        public void SetFromCity(string fromCity)
        {
            this.driverContext.Driver.GetElement(fromField).Click();
            this.driverContext.Driver.GetElement(cityFromName).SendKeys(fromCity);
            this.driverContext.Driver.GetElement(firstFromCity).Click();
        }

        public void SetToCity(string toCity)
        {
            this.driverContext.Driver.GetElement(toField).Click();
            this.driverContext.Driver.GetElement(cityToName).SendKeys(toCity);
            this.driverContext.Driver.GetElement(firstToCity).Click();
        }

        public void EnterDepartDate(string date)
        {
            this.driverContext.Driver.GetElement(departDate).SendKeys(date);
            this.driverContext.Driver.GetElement(departDate).Click();
        }

        public void SetTotalNumberOfPassengers()
        {
            this.driverContext.Driver.GetElement(passengersField).Click();

            IWebElement adultDropDown = driverContext.Driver.GetElement(adultsField);
            SelectElement selectAdultNb = new SelectElement(adultDropDown);
            selectAdultNb.SelectByIndex(1);

            IWebElement childDropDown = driverContext.Driver.GetElement(childField);
            SelectElement childAdultNb = new SelectElement(childDropDown);
            childAdultNb.SelectByIndex(2);

            IWebElement minfantDropDown = driverContext.Driver.GetElement(minfantField);
            SelectElement minfantAdultNb = new SelectElement(minfantDropDown);
            minfantAdultNb.SelectByIndex(3);
        }

        public void ConfirmPassengerNumbers()
        {
            this.driverContext.Driver.GetElement(doneBtn).Click();
        }

        public void ClickSearchBtnForFlights()
        {
            this.driverContext.Driver.GetElement(searchBtn).Click();
        }

        public void CheckResultsOfSearch()
        {
            var result = this.driverContext.Driver.GetElement(results).Displayed;
            Assert.AreEqual(true, result);
        }

    }
}
