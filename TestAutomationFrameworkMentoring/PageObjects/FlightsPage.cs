using System;
using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestAutomationFrameworkMentoring.Helpers;

namespace TestAutomationFrameworkMentoring.PageObjects
{
    public class FlightsPage : ProjectPageBase
    {
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
            searchBtn = new ElementLocator(Locator.XPath,
                "//button[@class='btn-primary btn btn-lg btn-block pfb0']"),
            results = new ElementLocator(Locator.CssSelector, "table#load_data tr:nth-child(1) > td"),
            flightsBtn = new ElementLocator(Locator.XPath, "//a[@title=\"Flights\"]"),
            filterNonStopCheckbox = new ElementLocator(Locator.CssSelector,
                "div#body-section div.panel-body > div:nth-child(1) > label"),
            filterRadioBtn = new ElementLocator(Locator.XPath,
                "//div[@class='pure-checkbox']//div[@class='iradio_square-grey']"),
            cabinClassDropdown = new ElementLocator(Locator.XPath, "//select[@name='cabinclass']"),
            bookNowBtn = new ElementLocator(Locator.Id, "bookbtn"),
            fname = new ElementLocator(Locator.Name, "firstname"),
            lname = new ElementLocator(Locator.Name, "lastname"),
            email = new ElementLocator(Locator.Name, "email"),
            emailc = new ElementLocator(Locator.Name, "confirmemail"),
            bookBtn = new ElementLocator(Locator.CssSelector, "div#body-section button[type=\"submit\"]"),
            invoiceTable = new ElementLocator(Locator.Id, "invoiceTable"),
            couponNbField = new ElementLocator(Locator.XPath, "//input[@class='RTL form-control coupon']"),
            applyCouponBtn = new ElementLocator(Locator.XPath, "//div[@class='col-md-6 go-left']");

        public FlightsPage(DriverContext driverContext) : base(driverContext)
        {
        }
        private IWebElement MyAccount { get; set; }

        public FlightsPage ClickOnFlightsBtn()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            this.Driver.GetElement(flightsBtn).Click();
            return this;
        }

        public void SetFromCity(string fromCity)
        {
            this.Driver.GetElement(fromField).Click();
            this.Driver.GetElement(cityFromName).SendKeys(fromCity);
            this.Driver.GetElement(firstFromCity).Click();

        }

        public void SetToCity(string toCity)
        {
            this.Driver.GetElement(toField).Click();
            this.Driver.GetElement(cityToName).SendKeys(toCity);
            this.Driver.GetElement(firstToCity).Click();
        }

        public void EnterDepartDate(string date)
        {
            this.Driver.GetElement(departDate).SendKeys(date);
            this.Driver.GetElement(departDate).Click();
        }

        public void SetTotalNumberOfPassengers()
        {
            this.Driver.GetElement(passengersField).Click();

            IWebElement adultDropDown = Driver.GetElement(adultsField);
            SelectElement selectAdultNb = new SelectElement(adultDropDown);
            selectAdultNb.SelectByIndex(1);

            IWebElement childDropDown = Driver.GetElement(childField);
            SelectElement childAdultNb = new SelectElement(childDropDown);
            childAdultNb.SelectByIndex(2);

            IWebElement minfantDropDown = Driver.GetElement(minfantField);
            SelectElement minfantAdultNb = new SelectElement(minfantDropDown);
            minfantAdultNb.SelectByIndex(3);
        }

        public void ConfirmPassengerNumbers()
        {
            this.Driver.GetElement(doneBtn).Click();
        }

        public void ClickSearchBtnForFlights()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            this.Driver.GetElement(searchBtn).Click();
        }

        public void CheckResultsOfSearch()
        {
            var result = this.Driver.GetElement(results).Displayed;
            Assert.AreEqual(true, result);
        }

        public void SelectFilters()
        {
            this.Driver.GetElement(filterNonStopCheckbox).Click();
            this.Driver.GetElement(filterRadioBtn).Click();

            IWebElement cabinclass = Driver.GetElement(cabinClassDropdown);
            SelectElement cabinClassElement = new SelectElement(cabinclass);
            cabinClassElement.SelectByText("Business");
        }

        public void BookFlight()
        {
            this.Driver.GetElement(bookNowBtn).Click();
        }

        public void EnterDetails(string f_name, string l_name, string e_mail, string e_mailc)
        {
            this.Driver.GetElement(fname).SendKeys(f_name);
            this.Driver.GetElement(lname).SendKeys(l_name);
            this.Driver.GetElement(email).SendKeys(e_mail);
            this.Driver.GetElement(emailc).SendKeys(e_mailc);
        }

        public void EnetrCouponNumber(string couponNb)
        {
            
            JavaScriptHelper.JavaScriptScroll(this.Driver);

            this.Driver.GetElement(couponNbField).SendKeys(couponNb);
            this.Driver.GetElement(applyCouponBtn).Click();

            var wait = new WebDriverWait(Driver,TimeSpan.FromMilliseconds(3000));
            wait.Until(ExpectedConditions.AlertIsPresent());

            try
            {
                var alertText = this.Driver.SwitchTo().Alert().Text;
                Console.WriteLine(alertText);
                Assert.IsTrue(alertText.Contains("Invalid"));
                this.Driver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void BookReservation()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            this.Driver.GetElement(bookBtn).Click();
        }

        public void CheckReservationStatus()
        {
            var result = this.Driver.GetElement(invoiceTable).Text;
            Assert.IsTrue(result != null && result.Contains("UNPAID"));
        }
    }
}