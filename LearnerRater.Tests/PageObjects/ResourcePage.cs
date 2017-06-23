using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace LearnerRater.Tests.PageObjects
{
    public class ResourcePage
    {
        private readonly IWebDriver webDriver;
        private TimeSpan ts = new TimeSpan(0, 0, 20);
        private WebDriverWait wait;
        private string url = "web5qa:81/resources";

        public ResourcePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public ResourcePage navigateTo()
        {
            webDriver.Navigate().GoToUrl(url);
            return this;
        }

        public ResourcePage toggleReviews()
        {
            webDriver.FindElement(By.Id("btnToggleReviews")).Click();
            return this;
        }

        public bool containsReviews()
        {                 
            return webDriver.FindElements(By.ClassName("review-container")).Count > 0 ? true : false;
        }

        public ResourcePage openAddReviewOverlay()
        {
            webDriver.FindElement(By.Id("btnAddReview")).Click();
            return this;
        }

        public ResourcePage addReviewButton(string buttonId)
        {
            webDriver.FindElement(By.Id(buttonId)).Click();
            return this;
        }

        public ResourcePage addReviewFields()
        {           
            webDriver.FindElement(By.Id("inputUsername")).SendKeys("Mr. Bigglesworth");
            webDriver.FindElement(By.Id("Rating_2")).Click();
            webDriver.FindElement(By.Id("inputComment")).SendKeys("There were no sharks with laser beams attached to their heads in this course.");
            return this;
        }
    }
}
