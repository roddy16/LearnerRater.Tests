using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace LearnerRater.Tests.PageObjects
{
    public class ResourceSubjectsPage
    {
        private readonly IWebDriver webDriver;
        private readonly WebDriverWait wait;
        private static string url = ConfigurationManager.AppSettings["BaseUrl"];

        public ResourceSubjectsPage(IWebDriver webDriver, WebDriverWait wait)
        {
            this.webDriver = webDriver;
            this.wait = wait;
        }

        public ResourceSubjectsPage NavigateTo()
        {
            webDriver.Navigate().GoToUrl(url);
            return this;
        }

        public ResourcePage SelectSubject(string subject)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(subject)));
            webDriver.FindElement(By.PartialLinkText(subject)).Click();
            return new ResourcePage(webDriver, wait);
        }
    }
}
