using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using BoDi;
using OpenQA.Selenium.Support.UI;
using System;

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
            webDriver = new ChromeDriver(options);
            objectContainer.RegisterInstanceAs(webDriver);

            wait = new WebDriverWait(webDriver, ts);
            objectContainer.RegisterInstanceAs(wait);
        }

        [AfterScenario]
        public void TearDownScenario()
        {
            webDriver.Dispose();
        }        
    }
}