using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace LearnerRater.Tests.PageObjects
{
    public class ResourceSubjectsPage
    {
        private readonly IWebDriver webDriver;
        private TimeSpan ts = new TimeSpan(0, 0, 10);
        private WebDriverWait wait;
        private string url = "web5qa:81/resourceSubjects";

        public ResourceSubjectsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public ResourceSubjectsPage navigateTo()
        {
            webDriver.Navigate().GoToUrl(url);
            return this;
        }

        public ResourcePage selectSubject(string subject)
        {
            webDriver.FindElement(By.Id(subject)).Click();
            return new ResourcePage(webDriver);
        }
    }
}
