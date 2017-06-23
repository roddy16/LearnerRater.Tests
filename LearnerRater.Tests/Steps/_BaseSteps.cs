using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using BoDi;

namespace LearnerRater.Tests.Steps
{
    [Binding]
    public sealed class BaseSteps
    {
        private IWebDriver webDriver;
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
        }

        [AfterScenario]
        public void TearDownScenario()
        {
            webDriver.Dispose();
        }        
    }
}