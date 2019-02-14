namespace Objectivity.Test.Automation.Tests.Features
{
    using System;

    using NUnit.Framework;
    using Objectivity.Test.Automation.Common;
    using Objectivity.Test.Automation.Common.Logger;

    using TechTalk.SpecFlow;

    /// <summary>
    /// The base class for all tests <see href="https://github.com/ObjectivityLtd/Test.Automation/wiki/ProjectTestBase-class">More details on wiki</see>
    /// </summary>
    [Binding]
    public class ProjectTestBase : TestBase
    {
        private readonly ScenarioContext scenarioContext;
        private readonly DriverContext driverContext = new DriverContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectTestBase"/> class.
        /// </summary>
        /// <param name="scenarioContext"> Scenario Context </param>
        public ProjectTestBase(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
            {
                throw new ArgumentNullException("scenarioContext");
            }

            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Gets or sets logger instance for driver
        /// </summary>
        public TestLogger LogTest
        {
            get
            {
                return this.DriverContext.LogTest;
            }

            set
            {
                this.DriverContext.LogTest = value;
            }
        }

        /// <summary>
        /// Gets the browser manager
        /// </summary>
        protected DriverContext DriverContext
        {
            get
            {
                return this.driverContext;
            }
        }

        /// <summary>
        /// Before the class.
        /// </summary>
        [BeforeFeature]
        public static void BeforeClass()
        {
        }

        /// <summary>
        /// After the class.
        /// </summary>
        [AfterFeature]
        public static void AfterClass()
        {
        }

        /// <summary>
        /// Before the test.
        /// </summary>
        [Before]
        public void BeforeTest()
        {
            this.DriverContext.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            this.DriverContext.TestTitle = this.scenarioContext.ScenarioInfo.Title;
            this.LogTest.LogTestStarting(this.driverContext);
            this.DriverContext.Start();
            this.scenarioContext["DriverContext"] = this.DriverContext;
            this.DriverContext.Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// After the test.
        /// </summary>
        [After]
        public void AfterTest()
        {
            try
            {
                this.DriverContext.IsTestFailed = this.scenarioContext.TestError != null || !this.driverContext.VerifyMessages.Count.Equals(0);
                var filePaths = this.SaveTestDetailsIfTestFailed(this.driverContext);
                this.SaveAttachmentsToTestContext(filePaths);
                var javaScriptErrors = this.DriverContext.LogJavaScriptErrors();

                this.LogTest.LogTestEnding(this.driverContext);
                //if (this.IsVerifyFailedAndClearMessages(this.driverContext) && this.scenarioContext.TestError == null)
                //{
                //    Assert.Fail();
                //}

                //if (javaScriptErrors)
                //{
                //    Assert.Fail("JavaScript errors found. See the logs for details");
                //}
            }
            finally
            {
                // the context should be cleaned up no matter what
                this.DriverContext.Stop();
            }
        }

        private void SaveAttachmentsToTestContext(string[] filePaths)
        {
            if (filePaths != null)
            {
                foreach (var filePath in filePaths)
                {
                    this.LogTest.Info("Uploading file [{0}] to test context", filePath);
                    TestContext.AddTestAttachment(filePath);
                }
            }
        }
    }
}
