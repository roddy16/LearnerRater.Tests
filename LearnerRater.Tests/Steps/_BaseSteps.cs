using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using BoDi;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Collections.Generic;
using LearnerRater.Tests.Utils;

namespace LearnerRater.Tests.Steps
{
    [Binding]
    public sealed class BaseSteps
    {
        private IWebDriver webDriver;
        private WebDriverWait wait;
        private TimeSpan ts = new TimeSpan(0, 0, 10);
        private readonly IObjectContainer objectContainer;

        public BaseSteps(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitScenario()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            webDriver = new ChromeDriver(ConfigurationManager.AppSettings["ChromeDriverLocation"], options);
            webDriver.Manage().Timeouts().ImplicitWait = ts;
            objectContainer.RegisterInstanceAs(webDriver);

            wait = new WebDriverWait(webDriver, ts);
            objectContainer.RegisterInstanceAs(wait);
        }

        [AfterScenario]
        public void TearDownScenario()
        {
            webDriver.Dispose();
        }

        [BeforeScenario]
        [AfterScenario]
        public void ResetDatabase()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ClientDatabase"].ConnectionString;
            var keysToReplace = new Dictionary<string, string>()
            {
                { "{DatabaseName}", ConfigurationManager.AppSettings["DatabaseName"] },
                { "{SnapShotName}", ConfigurationManager.AppSettings["SnapShotName"] }
            };

            DatabaseCommands.RunScriptFromFile(connectionString, @"Scripts\RestoreDatabaseFromSnapShot.sql", keysToReplace);
        }
    }
}