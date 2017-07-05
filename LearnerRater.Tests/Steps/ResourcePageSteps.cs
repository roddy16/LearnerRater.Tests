using LearnerRater.Tests.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace LearnerRater.Tests.Steps
{
    [Binding]
    public sealed class ResourcePageSteps
    {
        private readonly ResourcePage resourcePage;

        public ResourcePageSteps(ResourcePage resourcePage)
        {
            this.resourcePage = resourcePage;
        }

        [Given(@"I have accessed the resources page")]
        public void GivenIHaveAccessedTheResourcesPage()
        {
            resourcePage.navigateTo();
        }

        [When(@"I click You Be The Judge button")]
        [Given(@"I have opened the Add Review overlay")]
        public void GivenIHaveOpenedTheAddReviewOverlay()
        {
            resourcePage.openAddReviewOverlay();
        }

        [When(@"I click Show Reviews")]
        [When(@"I click Hide Reviews")]
        [Given(@"I have clicked Show Reviews")]
        public void WhenIClickShowReviews()
        {
            resourcePage.toggleReviews();
        }

        [When(@"I enter (.*), (.*) and (.*)")]
        [Given(@"I have entered (.*), (.*) and (.*)")]
        public void WhenIEnter_UserName_StarRating_and_Comments(string userName, string starRating, string comments)
        {
            resourcePage.addReviewFields(userName, starRating, comments);
        }

        [When(@"I click the Submit button")]
        [Given(@"I have clicked the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            resourcePage.addReviewSubmitButton();
        }

        [When(@"I click the Cancel button")]
        public void WhenIClickTheCancelButton()
        {
            resourcePage.addReviewCancelButton();
        }

        [Then(@"All the reviews should be displayed")]
        public void ThenAllTheReviewsShouldBeDisplayed()
        {
            resourcePage
                .isReviewContainerDisplayed()
                .Should()
                .BeTrue();
        }

        [Then(@"All the reviews should be hidden")]
        public void ThenAllTheReviewsShouldBeHidden()
        {
            resourcePage
                .isReviewContainerDisplayed()
                .Should()
                .BeFalse();
        }

        [Then(@"The button should read Hide Reviews")]
        public void ThenTheButtonShouldReadHideReviews()
        {
            resourcePage
                .reviewButtonToggleDisplayText()
                .Should()
                .StartWith("HIDE REVIEWS");
        }

        [Then(@"The button should read Show Reviews")]
        public void ThenTheButtonShouldReadShowReviews()
        {
            resourcePage
                .reviewButtonToggleDisplayText()
                .Should()
                .StartWith("SHOW REVIEWS");
        }

        [Then(@"The Add Review overlay should appear")]
        public void ThenTheAddReviewOverlayShouldAppear()
        {
            resourcePage
                .isAddReviewOverlayDisplayed()
                .Should()
                .BeTrue();
        }

        [Then(@"The overlay should close")]
        public void ThenTheOverlayShouldClose()
        {
            resourcePage
                .isAddReviewOverlayDisplayed()
                .Should()
                .BeFalse();
        }

        [Then(@"The review by (.*) should be added to the resource with their (.*)")]
        [Then(@"The new resource should have (.*) by (.*) listed")]
        public void ThenTheReviewBy_UserName_ShouldBeAddedToTheResourceWithTheir_Comments(string userName, string comments)
        {
            resourcePage.toggleReviews();

            resourcePage
                .isReviewListed(userName, comments)
                .Should()
                .BeTrue();
        }

        [Then(@"The total count of reviews for that resource should be incremented by 1")]
        public void ThenTheTotalCountOfReviewsForThatResourceShouldBeIncrementedBy1()
        {
            resourcePage
                .getReviewCountDifference("BeforeAdd")
                .Should()
                .Be(-1);
        }

        [Then(@"The review by (.*) should not be added to the resource with their (.*)")]
        public void ThenTheReviewBy_UserName_ShouldNotBeAddedToTheResourceWithTheir_Comments(string userName, string comments)
        {
            resourcePage.toggleReviews();

            resourcePage
                .isReviewListed(userName, comments)
                .Should()
                .BeFalse();
        }

        [Given(@"I have clicked the manage button")]
        public void GivenIHaveClickedTheManageButton()
        {
            resourcePage.toggleManageButton();
        }

        [When(@"I click the review Delete button")]
        public void WhenIClickTheReviewDeleteButton()
        {
            resourcePage.deleteButton();
        }

        [Then(@"The review by (.*) with (.*) should be deleted from the resource")]
        public void ThenTheReviewBy_UserName_ShouldBeDeletedFromTheResource(string userName, string comments)
        {
            resourcePage
                .isReviewListed(userName, comments)
                .Should()
                .BeFalse();
        }

        [Then(@"The total count of reviews for that resource should be reduced by 1")]
        public void ThenTheTotalCountOfReviewsForThatResourceShouldBeReducedBy1()
        {
            resourcePage
                .getReviewCountDifference("BeforeDelete")
                .Should()
                .Be(1);
        }

        [When(@"I click the resource Delete button")]
        public void WhenIClickTheResourceDeleteButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The resource should be deleted")]
        public void ThenTheResourceShouldBeDeleted()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The total count of resources for that subject should be reduced by 1")]
        public void ThenTheTotalCountOfResourcesForThatSubjectShouldBeReducedBy1()
        {
            ScenarioContext.Current.Pending();
        }
    }
}