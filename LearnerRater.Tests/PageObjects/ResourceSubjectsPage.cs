using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace LearnerRater.Tests.PageObjects
{
    public class ResourceSubjectsPage
    {
        private readonly IWebDriver webDriver;
        private readonly WebDriverWait wait;
        private string url = "http://web5qa:8090";

        public ResourceSubjectsPage(IWebDriver webDriver, WebDriverWait wait)
        {
            this.webDriver = webDriver;
            this.wait = wait;
        }

        public ResourceSubjectsPage navigateTo()
        {
            webDriver.Navigate().GoToUrl(url);
            return this;
        }

        public ResourcePage selectSubject(string subject)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(subject)));
            webDriver.FindElement(By.PartialLinkText(subject)).Click();
            return new ResourcePage(webDriver, wait);
        }
    }
}
