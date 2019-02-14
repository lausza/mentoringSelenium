using NUnit.Framework;
using Objectivity.Test.Automation.Common;
using Objectivity.Test.Automation.Common.Extensions;
using Objectivity.Test.Automation.Common.Types;

namespace TestAutomationFrameworkMentoring.PageObjects
{
    public class HotelsPage 
    {
        private readonly DriverContext driverContext;

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
            firtValueFromtable = new ElementLocator(Locator.CssSelector, "div#body-section tr:nth-child(1) > td > div.col-md-6.col-xs-4.go-right > div > h4 > a > b");

        public HotelsPage(DriverContext driverContext)
        {
            this.driverContext = driverContext;
        }
        public void ClickOnHotelsBtn()
        {
           this.driverContext.Driver.GetElement(hotelsBtn).Click();
        }

        public void SearchByValues(string cityName)
        {
            this.driverContext.Driver.GetElement(searchByField).Click();
            this.driverContext.Driver.GetElement(searchByHotelName).SendKeys(cityName);
            this.driverContext.Driver.GetElement(firstPosition).Click();
        }

        public void SetDates(string checkin, string checkout)
        {
            this.driverContext.Driver.GetElement(checkinDatePicker).SendKeys(checkin);
            this.driverContext.Driver.GetElement(checkinDatePicker).Click();
            this.driverContext.Driver.GetElement(checkoutDatePicker).SendKeys(checkout);
            this.driverContext.Driver.GetElement(checkoutDatePicker).Click();
        }
       
        public void SetTravellers()
        {
            this.driverContext.Driver.GetElement(travellersField).Click();
            this.driverContext.Driver.GetElement(childBtn).Click();
            this.driverContext.Driver.GetElement(adultsMinBtn).Click();
            this.driverContext.Driver.GetElement(travellersField).Click();
        }

        public void ClickOnSearchBtn()
        {
            this.driverContext.Driver.GetElement(searchBtn).Click();
        }

        public void CheckResultTable()
        {
            var result = this.driverContext.Driver.GetElement(firtValueFromtable).Displayed;
            Assert.AreEqual(true, result);
        }
    }
}
