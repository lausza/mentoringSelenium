using System;
using System.Collections.Generic;
using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;
using Objectivity.Test.Automation.Tests.PageObjects;
using OpenQA.Selenium;

namespace TestAutomationFrameworkMentoring.PageObjects
{
    public class HotelsPage : ProjectPageBase
    {
        private readonly ElementLocator
            hotelsBtn = new ElementLocator(Locator.XPath, "//a[@class=\'text-center\'][@title=\'Hotels\']"),
            searchByField = new ElementLocator(Locator.Id, "s2id_autogen8"),
            searchByHotelName = new ElementLocator(Locator.CssSelector, "#select2-drop .select2-input"),
            firstPosition = new ElementLocator(Locator.XPath, "//ul[@class=\"select2-result-sub\"]//li[1]"),
            checkinDatePicker = new ElementLocator(Locator.Name, "checkin"),
            checkoutDatePicker = new ElementLocator(Locator.Name, "checkout"),
            searchBtn = new ElementLocator(Locator.XPath,
                "//button[@class=\"btn btn-lg btn-block btn-primary pfb0 loader\"]"),
            travellersField = new ElementLocator(Locator.Id, "travellersInput"),
            childBtn = new ElementLocator(Locator.Id, "childPlusBtn"),
            adultsMinBtn = new ElementLocator(Locator.Id, "adultMinusBtn"),
            firtValueFromtable = new ElementLocator(Locator.CssSelector,
                "div#body-section tr:nth-child(1) > td > div.col-md-6.col-xs-4.go-right > div > h4 > a > b"),        
            detailsBtn = new ElementLocator(Locator.CssSelector,
                "div#body-section tr:nth-child(8) > td > div.col-md-3.col-xs-4.col-sm-4.go-left.pull-right.price_tab > a > button"),
            priceCheckbox = new ElementLocator(Locator.XPath, "//div[@class='col-md-2 go-right pull-right']//div[@class='control__indicator']"),
            bookNowBtn = new ElementLocator(Locator.XPath,
                "//button[@class=\"book_button btn btn-md btn-success btn-block btn-block chk mob-fs10 loader\"]"),
            fnameField = new ElementLocator(Locator.Name, "firstname"),
            lnameField = new ElementLocator(Locator.Name, "lastname"),
            emailField = new ElementLocator(Locator.Name, "email"),
            emailCField = new ElementLocator(Locator.Name, "confirmemail"),
            mobileField = new ElementLocator(Locator.Name, "phone"),
            addressField = new ElementLocator(Locator.Name, "address"),
            countryDropdown = new ElementLocator(Locator.Id, "s2id_autogen1"),
            valueCountry = new ElementLocator(Locator.XPath, "//div[@class='select2-result-label'][contains(text(), '{0}')]"),
            confirmThisBookingBtn = new ElementLocator( Locator.XPath, "//button[@class='btn btn-success btn-lg btn-block completebook']"),
            invoiceTable = new ElementLocator(Locator.Id, "invoiceTable"),
            tag = new ElementLocator(Locator.TagName, "tr"),
            noResults= new ElementLocator( Locator.XPath, "//h4[@class='alert alert-info']"),
            wishListBtn = new ElementLocator( Locator.XPath, "//span[@class='wishtext']");

        public HotelsPage(DriverContext driverContext) : base(driverContext)
        {

        }
        public HotelsPage ClickOnHotelsBtn()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            this.Driver.GetElement(hotelsBtn).Click();
            return this;
        }
        public void SearchByValues(string cityName)
        {
            this.Driver.GetElement(searchByField).Click();
            this.Driver.GetElement(searchByHotelName).SendKeys(cityName);
            this.Driver.GetElement(firstPosition).Click();
        }
        public void SetDates(string checkin, string checkout)
        {
            this.Driver.GetElement(checkinDatePicker).SendKeys(checkin);
            this.Driver.GetElement(checkinDatePicker).Click();
            this.Driver.GetElement(checkoutDatePicker).SendKeys(checkout);
            this.Driver.GetElement(checkoutDatePicker).Click();
        }
        public void SetTravellers()
        {
            this.Driver.GetElement(travellersField).Click();
            this.Driver.GetElement(childBtn).Click();
            this.Driver.GetElement(adultsMinBtn).Click();
            this.Driver.GetElement(travellersField).Click();
        }
        public void ClickOnSearchBtn()
        {
            this.Driver.GetElement(searchBtn).Click();
        }
        public void CheckResultTable()
        {
            var result = this.Driver.GetElement(firtValueFromtable).Displayed;
            Assert.AreEqual(true, result);
        }
        public void ClickOnDetailsBtn()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("window.scrollBy(0,1000)");

            this.Driver.GetElement(detailsBtn).Click();
        }
        public void BookSelectedHotel()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;
            js.ExecuteScript("window.scrollBy(0,1000)");

            this.Driver.GetElement(priceCheckbox).Click();
            this.Driver.GetElement(bookNowBtn).Click();
        }

        public bool CheckIfFieldsAreDisplayed()
        {
            var waitForElement =
                this.Driver.GetElement(this.fnameField, BaseConfiguration.ShortTimeout, e => e.Displayed);
            return waitForElement.Displayed;
        }

        public void SetFormFields(string fname, string lname, string email, string emailc, string mobile, string address, string country)
        {
            this.Driver.GetElement(fnameField).SendKeys(fname);
            this.Driver.GetElement(lnameField).SendKeys(lname);
            this.Driver.GetElement(emailField).SendKeys(email);
            this.Driver.GetElement(emailCField).SendKeys(emailc);
            this.Driver.GetElement(mobileField).SendKeys(mobile);
            this.Driver.GetElement(addressField).SendKeys(address);
            this.Driver.GetElement(countryDropdown).Click();
            this.Driver.GetElement(valueCountry.Format(country)).Click();
        }

        public void ConfirmHotelBooking()
        {
           this.Driver.GetElement(confirmThisBookingBtn).Click();
        }

        public void GetInvoiceDocument()
        {
            var result = this.Driver.GetElement(invoiceTable).Displayed;
            Assert.AreEqual(true, result);

            IList<IWebElement> allElement = Driver.GetElements(tag.Format(tag));
            foreach (IWebElement element in allElement)
            {
                string cellText = element.Text;
                Console.WriteLine(cellText);
            }
        }
    }
}
