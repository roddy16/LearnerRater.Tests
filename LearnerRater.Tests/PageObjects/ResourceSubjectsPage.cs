using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

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

        public int GetResourceCountDifference(string subject, string key)
        {
            int beforeActionCount = (int)ScenarioContext.Current[key];

            var subjectBadgeValue = webDriver.FindElement(By.PartialLinkText(subject)).FindElement(By.ClassName("badge"));
            int resourceCount = Convert.ToInt32(subjectBadgeValue.Text);       

            return beforeActionCount - resourceCount;
        }
    }
}
