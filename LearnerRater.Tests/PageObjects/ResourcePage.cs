using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace LearnerRater.Tests.PageObjects
{
    public class ResourcePage
    {
        private readonly IWebDriver webDriver;
        private readonly WebDriverWait wait;
        private static string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        private static string url = $"{baseUrl}/resources/NCrunch";

        public IWebElement toggleReviewsButton => webDriver.FindElement(By.Id("btnToggleReviewVisibility"));
        public IWebElement addReviewButton => webDriver.FindElement(By.Id("btnAddReview"));
        public IWebElement submitReviewButton => webDriver.FindElement(By.Id("btnSubmitRating"));
        public IWebElement cancelReviewButton => webDriver.FindElement(By.Id("btnCancelRating"));
        public IWebElement usernameInput => webDriver.FindElement(By.Id("inputUsername"));
        public IWebElement starRating(string starRating) => webDriver.FindElement(By.Id(starRating));
        public IWebElement userComment => webDriver.FindElement(By.Id("inputComment"));
        public IWebElement manageButton => webDriver.FindElement(By.Id("btnToggleManage"));
        public IWebElement deleteReviewButton(int reviewCount) =>  webDriver.FindElement(By.Id("btnDeleteReview_" + (reviewCount - 1)));
        public IWebElement addNewResourceLinkButton => webDriver.FindElement(By.Id("btnAddCourse"));
        public SelectElement resourceCategory => new SelectElement(webDriver.FindElement(By.Id("category")));
        public IWebElement resourceTitle => webDriver.FindElement(By.Id("Title"));
        public IWebElement resourceAuthor => webDriver.FindElement(By.Id("Author"));
        public IWebElement resourceDescription => webDriver.FindElement(By.Id("Description"));
        public IWebElement resourceWebsite => webDriver.FindElement(By.Id("Website"));
        public IWebElement resourceLink => webDriver.FindElement(By.Id("URL"));
        public IWebElement submitResourceButton => webDriver.FindElement(By.Id("btnSubmitCourse"));
        public IWebElement cancelResourceButton => webDriver.FindElement(By.Id("btnCancelCourse"));

        public IList<IWebElement> userReviews => webDriver.FindElements(By.CssSelector("div[id ^= 'reviewListContainer']"));
        public IList<IWebElement> resourceList => webDriver.FindElements(By.CssSelector("#app > div > div > div > div:nth-child(3) > div.resource-list-container"));
        
        public ResourcePage(IWebDriver webDriver, WebDriverWait wait)
        {
            this.webDriver = webDriver;
            this.wait = wait;
        }

        public ResourcePage navigateTo()
        {
            webDriver.Navigate().GoToUrl(url);
            return this;
        }

        public bool isCorrectResourcePageDisplayed(string subject)
        {
            return webDriver.Url.Equals(baseUrl + "/resources/" + subject) ? true : false;
        }

        public ResourcePage toggleReviews()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnToggleReviewVisibility")));
            toggleReviewsButton.Click();
            return this;
        }

        public bool isReviewContainerDisplayed()
        {
            //TODO find a more graceful way to handle this scenario. Without the thread.sleep call, the 'hidereviews' test fails because the browswer refreshes slower than the driver navigates
            Thread.Sleep(1000);
            return !userReviews.ElementAt(0).GetAttribute("style").Equals("display: none;");
        }

        public string reviewButtonToggleDisplayText()
        {
            return toggleReviewsButton.Text;
        }

        public ResourcePage openAddReviewOverlay()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnAddReview")));
            addReviewButton.Click();
            return this;
        }

        public bool isAddReviewOverlayDisplayed()
        {
            return webDriver.FindElements(By.ClassName("overlay-container")).Count > 0 ? true : false;
        }

        public ResourcePage addReviewSubmitButton()
        {
            int reviewCount = getNumberOfReviews();
            addToScenarioContext("BeforeAdd", reviewCount);

            submitReviewButton.Click();
            return this;
        }

        public ResourcePage addReviewCancelButton()
        {
            cancelReviewButton.Click();
            return this;
        }

        public ResourcePage addReviewFields(string userName, string stars, string comments)
        {        
            usernameInput.SendKeys(userName);
            starRating(stars).Click();
            userComment.SendKeys(comments);
            return this;
        }

        public bool isReviewListed(string userName, string comments)
        {
            return (userReviews[0].Text.Contains(userName) && userReviews[0].Text.Contains(comments)) ? true : false;
        }

        public ResourcePage toggleManageButton()
        {
            manageButton.Click();
            return this;
        }

        public ResourcePage deleteButton()
        {
            int reviewCount = getNumberOfReviews();
            addToScenarioContext("BeforeDelete", reviewCount);

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnDeleteReview_" + (reviewCount - 1))));
            deleteReviewButton(reviewCount).Click();
            return this;
        }

        public int getReviewCountDifference(string key)
        {
            int reviewCount = getNumberOfReviews();
            int beforeActionCount = (int)ScenarioContext.Current[key];

            return beforeActionCount - reviewCount;
        }

        public int getNumberOfReviews()
        {
            string[] numberOfReviews = toggleReviewsButton.Text.Split('/');

            return Convert.ToInt32(numberOfReviews[1]);
        }

        public void addToScenarioContext(string index, int value)
        {
            ScenarioContext.Current.Add(index, value);
        }

        public ResourcePage addNewResource()
        {
            int resourceCount = getNumberOfResources();
            addToScenarioContext("BeforeAdd", resourceCount);

            addNewResourceLinkButton.Click();
            return this;
        }

        public bool doesAddResourceFormExist()
        {
            return webDriver.FindElements(By.ClassName("form--add-resource")).Count > 0 ? true : false;
        }

        public ResourcePage addResourceFields(
            string subject, string title, string author, string description, string website,
            string link, string userName, string rating, string comments)
        {
            resourceCategory.SelectByText(subject);
            resourceTitle.SendKeys(title);
            resourceAuthor.SendKeys(author);
            resourceDescription.SendKeys(description);
            resourceWebsite.SendKeys(website);
            resourceLink.SendKeys(link);
            usernameInput.SendKeys(userName);
            starRating(rating).Click();
            userComment.SendKeys(comments);
            return this;
        }

        public ResourcePage addResourceSubmitButton()
        {
            submitResourceButton.Click();
            return this;
        }

        public bool isResourceListed(string title, string author, string description, string website, string link)
        {
            var resourceLink = webDriver.FindElement(By.LinkText(title)).GetAttribute("href");
            return (resourceList[0].Text.Contains(title) 
                && resourceList[0].Text.Contains(author) 
                && resourceList[0].Text.Contains(description) 
                && resourceList[0].Text.Contains(website))
                && link.Equals(resourceLink) ? true : false;
        }

        public int getResourceCountDifference(string key)
        {
            int resourceCount = getNumberOfResources();
            int beforeActionCount = (int)ScenarioContext.Current[key];

            return beforeActionCount - resourceCount;
        }

        public int getNumberOfResources()
        {
            string numberOfResources = webDriver.FindElement(By.ClassName("badge")).Text;

            return Convert.ToInt32(numberOfResources);
        }

        public ResourcePage addResourceCancelButton()
        {
            cancelResourceButton.Click();
            return this;
        }
    }
}
