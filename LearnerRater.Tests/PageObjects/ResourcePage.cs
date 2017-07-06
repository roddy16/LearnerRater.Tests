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

        public IWebElement ToggleReviewsButton => webDriver.FindElement(By.Id("btnToggleReviewVisibility"));
        public IWebElement AddReviewButton => webDriver.FindElement(By.Id("btnAddReview"));
        public IWebElement SubmitReviewButton => webDriver.FindElement(By.Id("btnSubmitRating"));
        public IWebElement CancelReviewButton => webDriver.FindElement(By.Id("btnCancelRating"));
        public IWebElement UsernameInput => webDriver.FindElement(By.Id("inputUsername"));
        public IWebElement StarRating(string starRating) => webDriver.FindElement(By.Id(starRating));
        public IWebElement UserComment => webDriver.FindElement(By.Id("inputComment"));
        public IWebElement ManageButton => webDriver.FindElement(By.Id("btnToggleManage"));
        public IWebElement DeleteReviewButton(int reviewCount) => webDriver.FindElement(By.Id("btnDeleteReview_" + (reviewCount - 1)));
        public IWebElement AddNewResourceLinkButton => webDriver.FindElement(By.Id("btnAddCourse"));
        public SelectElement ResourceCategory => new SelectElement(webDriver.FindElement(By.Id("category")));
        public IWebElement ResourceTitle => webDriver.FindElement(By.Id("Title"));
        public IWebElement ResourceAuthor => webDriver.FindElement(By.Id("Author"));
        public IWebElement ResourceDescription => webDriver.FindElement(By.Id("Description"));
        public IWebElement ResourceWebsite => webDriver.FindElement(By.Id("Website"));
        public IWebElement ResourceLink => webDriver.FindElement(By.Id("URL"));
        public IWebElement SubmitResourceButton => webDriver.FindElement(By.Id("btnSubmitCourse"));
        public IWebElement CancelResourceButton => webDriver.FindElement(By.Id("btnCancelCourse"));
        public IWebElement DeleteResourceButton(int resourceCount) => webDriver.FindElement(By.Id("deleteResource_" + (resourceCount - 1)));

        public IList<IWebElement> UserReviews => webDriver.FindElements(By.CssSelector("div[id ^= 'reviewListContainer']"));
        public IList<IWebElement> ResourceList => webDriver.FindElements(By.CssSelector("#app > div > div > div > div:nth-child(3) > div.resource-list-container"));

        public ResourcePage(IWebDriver webDriver, WebDriverWait wait)
        {
            this.webDriver = webDriver;
            this.wait = wait;
        }

        public ResourcePage NavigateTo()
        {
            webDriver.Navigate().GoToUrl(url);
            return this;
        }

        public bool IsCorrectResourcePageDisplayed(string subject)
        {
            return webDriver.Url.Equals(baseUrl + "/resources/" + subject) ? true : false;
        }

        public ResourcePage ToggleReviews()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnToggleReviewVisibility")));
            ToggleReviewsButton.Click();
            return this;
        }

        public bool IsReviewContainerDisplayed()
        {
            //TODO find a more graceful way to handle this scenario. Without the thread.sleep call, the 'hidereviews' test fails because the browswer refreshes slower than the driver navigates
            Thread.Sleep(1000);
            return !UserReviews.ElementAt(0).GetAttribute("style").Equals("display: none;");
        }

        public string ReviewButtonToggleDisplayText()
        {
            return ToggleReviewsButton.Text;
        }

        public ResourcePage OpenAddReviewOverlay()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnAddReview")));
            AddReviewButton.Click();
            return this;
        }

        public bool IsAddReviewOverlayDisplayed()
        {
            return webDriver.FindElements(By.ClassName("overlay-container")).Count > 0 ? true : false;
        }

        public ResourcePage AddReviewSubmitButton()
        {
            int reviewCount = GetNumberOfReviews();
            AddToScenarioContext("BeforeAdd", reviewCount);

            SubmitReviewButton.Click();
            return this;
        }

        public ResourcePage AddReviewCancelButton()
        {
            CancelReviewButton.Click();
            return this;
        }

        public ResourcePage AddReviewFields(string userName, string stars, string comments)
        {
            UsernameInput.SendKeys(userName);
            StarRating(stars).Click();
            UserComment.SendKeys(comments);
            return this;
        }

        public bool IsReviewListed(string userName, string comments)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("Rating_5")));
            return (UserReviews[0].Text.Contains(userName) && UserReviews[0].Text.Contains(comments)) ? true : false;
        }

        public ResourcePage ToggleManageButton()
        {
            ManageButton.Click();
            return this;
        }

        public ResourcePage DeleteReviewButton()
        {
            int reviewCount = GetNumberOfReviews();
            AddToScenarioContext("BeforeDelete", reviewCount);

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("btnDeleteReview_" + (reviewCount - 1))));
            DeleteReviewButton(reviewCount).Click();
            return this;
        }

        public int GetReviewCountDifference(string key)
        {
            int reviewCount = GetNumberOfReviews();
            int beforeActionCount = (int)ScenarioContext.Current[key];

            return beforeActionCount - reviewCount;
        }

        public int GetNumberOfReviews()
        {
            string[] numberOfReviews = ToggleReviewsButton.Text.Split('/');

            return Convert.ToInt32(numberOfReviews[1]);
        }

        public void AddToScenarioContext(string index, int value)
        {
            ScenarioContext.Current.Add(index, value);
        }

        public ResourcePage AddNewResource()
        {
            int resourceCount = GetNumberOfResources();
            AddToScenarioContext("BeforeAdd", resourceCount);

            AddNewResourceLinkButton.Click();
            return this;
        }

        public bool DoesAddResourceFormExist()
        {
            return webDriver.FindElements(By.ClassName("form--add-resource")).Count > 0 ? true : false;
        }

        public ResourcePage AddResourceFields(
            string subject, string title, string author, string description, string website,
            string link, string userName, string rating, string comments)
        {
            ResourceCategory.SelectByText(subject);
            ResourceTitle.SendKeys(title);
            ResourceAuthor.SendKeys(author);
            ResourceDescription.SendKeys(description);
            ResourceWebsite.SendKeys(website);
            ResourceLink.SendKeys(link);
            UsernameInput.SendKeys(userName);
            StarRating(rating).Click();
            UserComment.SendKeys(comments);
            return this;
        }

        public ResourcePage AddResourceSubmitButton()
        {
            SubmitResourceButton.Click();
            return this;
        }

        public bool IsResourceListed(string title, string author, string description, string website, string link)
        {
            var scenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            
            if (scenarioTitle.Equals("Add a New Resource"))
            {
                var resourceLink = webDriver.FindElement(By.LinkText(title)).GetAttribute("href");

                return (ResourceList[0].Text.Contains(title)
                    && ResourceList[0].Text.Contains(author)
                    && ResourceList[0].Text.Contains(description)
                    && ResourceList[0].Text.Contains(website))
                    && link.Equals(resourceLink) ? true : false;
            }

            return (ResourceList[0].Text.Contains(title)
                 && ResourceList[0].Text.Contains(author)
                 && ResourceList[0].Text.Contains(description)
                 && ResourceList[0].Text.Contains(website)) ? true : false;
        }

        public int GetResourceCountDifference(string key)
        {
            int resourceCount = GetNumberOfResources();
            int beforeActionCount = (int)ScenarioContext.Current[key];

            return beforeActionCount - resourceCount;
        }

        public int GetNumberOfResources()
        {
            string numberOfResources = webDriver.FindElement(By.ClassName("badge")).Text;

            return Convert.ToInt32(numberOfResources);
        }

        public ResourcePage AddResourceCancelButton()
        {
            CancelResourceButton.Click();
            return this;
        }

        public bool IsAddResourceFormDisplayed()
        {
            return webDriver.FindElements(By.ClassName("form--add-resource")).Count > 0 ? true : false;
        }

        public ResourcePage DeleteResourceButton()
        {

            int resourceCount = GetNumberOfResources();
            AddToScenarioContext("BeforeDelete", resourceCount);

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("deleteResource_" + (resourceCount - 1))));
            DeleteResourceButton(resourceCount).Click();
            webDriver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}