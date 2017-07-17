using LearnerRater.Tests.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
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
        private static string url = $"{baseUrl}/resources";
        private static int maxStarRating = 5;

        public IWebElement ToggleReviewsButton => webDriver.FindElement(By.Id("btnToggleReviewVisibility"));
        public IWebElement AddReviewButton => webDriver.FindElement(By.Id("btnAddReview"));
        public IWebElement SubmitReviewButton => webDriver.FindElement(By.Id("btnSubmitRating"));
        public IWebElement CancelReviewButton => webDriver.FindElement(By.Id("btnCancelRating"));
        public IWebElement UsernameInput => webDriver.FindElement(By.Id("inputUsername"));
        public IWebElement StarRating(int rating) => webDriver.FindElement(By.Id($"Rating_{rating}"));
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
        public IWebElement NumberOfResources => webDriver.FindElement(By.Id("numberOfResourcesBadge"));
        public IWebElement ResourceTitleName(int index) => webDriver.FindElement(By.CssSelector($"#app > div > div > div > div:nth-child(3) > div.resource-list-container > div:nth-child({index}) > div.resource-item__col-1 > div.resource-item__title > h1"));
        public IWebElement ResourceNameSort => webDriver.FindElement(By.Id("sortByNameButton"));
        public IWebElement ResourceAverageRatingSort => webDriver.FindElement(By.Id("sortByAverageRatingButton"));
        public string FindResourceLink(string title) => webDriver.FindElement(By.LinkText(title)).GetAttribute("href");


        public IList<IWebElement> UserReviews => webDriver.FindElements(By.CssSelector("div[id ^= 'reviewListContainer']"));
        public IList<IWebElement> ResourceList => webDriver.FindElements(By.CssSelector("#app > div > div > div > div:nth-child(3) > div.resource-list-container"));
        public IList<IWebElement> ResourceListItems => webDriver.FindElements(By.CssSelector($"#app > div > div > div > div:nth-child(3) > div.resource-list-container > div"));
        public IList<IWebElement> ResourceStarRating(int index) => webDriver.FindElements(By.CssSelector($"#app > div > div > div > div:nth-child(3) > div.resource-list-container > div:nth-child({index}) > div.resource-item__col-2 > div.resource-item__average-rating > div > div > label.dv-star-rating-star.dv-star-rating-empty-star"));

        public ResourcePage(IWebDriver webDriver, WebDriverWait wait)
        {
            this.webDriver = webDriver;
            this.wait = wait;
        }

        public ResourcePage NavigateTo(string category)
        {
            webDriver.Navigate().GoToUrl($"{url}/{category}");

            return this;
        }

        public bool IsCorrectResourcePageDisplayed(string subject)
        {
            return webDriver.Url.Equals(baseUrl + "/resources/" + subject);
        }

        public ResourcePage ToggleReviews()
        {
            ToggleReviewsButton.Click();

            /*
                TODO: Need to find a way to wait for jQuery animation before continuing. The delay that it takes to show/hide the reviews is making tests
                fail.
            */
            Thread.Sleep(1000);

            return this;
        }

        public bool IsReviewContainerDisplayed()
        {
            return !UserReviews.ElementAt(0).GetAttribute("style").Equals("display: none;");
        }

        public string ReviewButtonToggleDisplayText()
        {
            return ToggleReviewsButton.Text;
        }

        public ResourcePage OpenAddReviewOverlay()
        {
            AddReviewButton.Click();

            return this;
        }

        public bool IsAddReviewOverlayDisplayed()
        {
            return webDriver.FindElements(By.ClassName("overlay-container")).Count > 0;
        }

        public ResourcePage AddReviewSubmitButton()
        {
            SubmitReviewButton.Click();

            return this;
        }

        public ResourcePage AddReviewCancelButton()
        {
            CancelReviewButton.Click();

            return this;
        }

        public ResourcePage AddReviewFields(Review review)
        {
            UsernameInput.SendKeys(review.Username);
            StarRating(review.Rating).Click();
            UserComment.SendKeys(review.Comment);

            return this;
        }

        public bool IsReviewListed(Resource resource)
        {
            return (UserReviews[0].Text.Contains(resource.Username) && UserReviews[0].Text.Contains(resource.Comment));
        }

        public ResourcePage ToggleManageButton()
        {
            ManageButton.Click();

            return this;
        }

        public ResourcePage ClickDeleteReviewButton(int indexOfReviewToDelete)
        {
            DeleteReviewButton(indexOfReviewToDelete).Click();

            return this;
        }

        public int GetReviewCountDifference(int numberOfReviewsBeforeAction)
        {
            int reviewCount = GetNumberOfReviews();

            return numberOfReviewsBeforeAction - reviewCount;
        }

        public int GetNumberOfReviews()
        {
            string[] numberOfReviews = ToggleReviewsButton.Text.Split('/');

            return Convert.ToInt32(numberOfReviews[1]);
        }
        
        public ResourcePage AddNewResource()
        {
            AddNewResourceLinkButton.Click();

            return this;
        }

        public ResourcePage AddResourceFields(Resource resource)
        {
            ResourceCategory.SelectByText(resource.Category);
            ResourceTitle.SendKeys(resource.Title);
            ResourceAuthor.SendKeys(resource.Author);
            ResourceDescription.SendKeys(resource.Description);
            ResourceWebsite.SendKeys(resource.Website);
            ResourceLink.SendKeys(resource.Link);
            UsernameInput.SendKeys(resource.Username);
            StarRating(resource.Rating).Click();
            UserComment.SendKeys(resource.Comment);

            return this;
        }

        public ResourcePage AddResourceSubmitButton()
        {
            SubmitResourceButton.Click();

            return this;
        }

        public bool IsResourceListed(Resource resource)
        {
            return (ResourceList[0].Text.Contains(resource.Title)
                 && ResourceList[0].Text.Contains(resource.Author)
                 && ResourceList[0].Text.Contains(resource.Description)
                 && ResourceList[0].Text.Contains(resource.Website));
        }

        public bool IsSuccessfullyCreateResourceListed(Resource resource)
        {
            var resourceLink = webDriver.FindElement(By.LinkText(resource.Title)).GetAttribute("href");

            return IsResourceListed(resource) && resource.Link.Equals(resourceLink);

        }

        public int GetResourceCountDifference(int numberOfResourcesBeforeAction)
        {
            int resourceCount = GetNumberOfResources();

            return numberOfResourcesBeforeAction - resourceCount;
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
            return webDriver.FindElements(By.ClassName("form--add-resource")).Count > 0;
        }

        public ResourcePage ClickDeleteResourceButton(int indexOfResourceToDelete)
        {
            DeleteResourceButton(indexOfResourceToDelete).Click();
            webDriver.SwitchTo().Alert().Accept();

            return this;
        }

        public int ErrorMessageCount()
        {
            return webDriver.FindElements(By.ClassName("error")).Count;
        }

        public string ErrorMessageText()
        {
            return webDriver.FindElement(By.ClassName("error")).Text;
        }

        public IList<string> CaptureResourceList()
        {
            IList<string> titles = new List<string>();

            for (int i = 1; i <= ResourceListItems.Count; i++)
            {
                titles.Add(ResourceTitleName(i).Text);
            }

            return titles;
        }

        public ResourcePage SortResourceName(int clickCount)
        {
            for (int i = 0; i < clickCount; i++)
            {
                ResourceNameSort.Click();
            }

            return this;                 
        }

        public IList<int> CaptureResourceListStarRatings()
        {
            IList<int> starRatings = new List<int>();

            for (int i = 1; i <= ResourceListItems.Count; i++)
            {
                starRatings.Add(maxStarRating - ResourceStarRating(i).Count());
            }

            return starRatings;
        }

        public ResourcePage SortResourceAverageRating(int clickCount)
        {
            for (int i = 0; i < clickCount; i++)
            {
                ResourceAverageRatingSort.Click();
            }

            return this;
        }
    }
}