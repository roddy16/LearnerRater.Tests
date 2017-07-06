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
            resourcePage.NavigateTo();
        }

        [When(@"I click You Be The Judge button")]
        [Given(@"I have opened the Add Review overlay")]
        public void GivenIHaveOpenedTheAddReviewOverlay()
        {
            resourcePage.OpenAddReviewOverlay();
        }

        [When(@"I click Show Reviews")]
        [When(@"I click Hide Reviews")]
        [Given(@"I have clicked Show Reviews")]
        public void WhenIClickShowReviews()
        {
            resourcePage.ToggleReviews();
        }

        [Given(@"I have entered a review with (.*), (.*) and (.*)")]
        public void GiveIHaveEnteredAReviewWith_UserName_StarRating_and_Comments(string userName, string starRating, string comments)
        {
            resourcePage.AddReviewFields(userName, starRating, comments);
        }

        [When(@"I click the Submit button")]
        [Given(@"I have clicked the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            resourcePage.AddReviewSubmitButton();
        }

        [When(@"I click the Cancel button")]
        public void WhenIClickTheCancelButton()
        {
            resourcePage.AddReviewCancelButton();
        }

        [Then(@"All the reviews should be displayed")]
        public void ThenAllTheReviewsShouldBeDisplayed()
        {
            resourcePage
                .IsReviewContainerDisplayed()
                .Should()
                .BeTrue();
        }

        [Then(@"All the reviews should be hidden")]
        public void ThenAllTheReviewsShouldBeHidden()
        {
            resourcePage
                .IsReviewContainerDisplayed()
                .Should()
                .BeFalse();
        }

        [Then(@"The button should read Hide Reviews")]
        public void ThenTheButtonShouldReadHideReviews()
        {
            resourcePage
                .ReviewButtonToggleDisplayText()
                .Should()
                .StartWith("HIDE REVIEWS");
        }

        [Then(@"The button should read Show Reviews")]
        public void ThenTheButtonShouldReadShowReviews()
        {
            resourcePage
                .ReviewButtonToggleDisplayText()
                .Should()
                .StartWith("SHOW REVIEWS");
        }

        [Then(@"The Add Review overlay should appear")]
        public void ThenTheAddReviewOverlayShouldAppear()
        {
            resourcePage
                .IsAddReviewOverlayDisplayed()
                .Should()
                .BeTrue();
        }

        [Then(@"The overlay should close")]
        public void ThenTheOverlayShouldClose()
        {
            resourcePage
                .IsAddReviewOverlayDisplayed()
                .Should()
                .BeFalse();
        }

        [Then(@"The review by (.*) should be added to the resource with their (.*)")]
        [Then(@"The new resource should have (.*) by (.*) listed")]
        public void ThenTheReviewBy_UserName_ShouldBeAddedToTheResourceWithTheir_Comments(string userName, string comments)
        {
            resourcePage.ToggleReviews();

            resourcePage
                .IsReviewListed(userName, comments)
                .Should()
                .BeTrue();
        }

        [Then(@"The total count of reviews for that resource should be incremented by 1")]
        public void ThenTheTotalCountOfReviewsForThatResourceShouldBeIncrementedBy1()
        {
            resourcePage
                .GetReviewCountDifference("BeforeAdd")
                .Should()
                .Be(-1);
        }

        [Then(@"The review by (.*) should not be added to the resource with their (.*)")]
        public void ThenTheReviewBy_UserName_ShouldNotBeAddedToTheResourceWithTheir_Comments(string userName, string comments)
        {
            resourcePage.ToggleReviews();

            resourcePage
                .IsReviewListed(userName, comments)
                .Should()
                .BeFalse();
        }

        [Given(@"I have clicked the manage button")]
        public void GivenIHaveClickedTheManageButton()
        {
            resourcePage.ToggleManageButton();
        }

        [When(@"I click the review Delete button")]
        public void WhenIClickTheReviewDeleteButton()
        {
            resourcePage.DeleteReviewButton();
        }

        [Then(@"The review by (.*) with (.*) should be deleted from the resource")]
        public void ThenTheReviewBy_UserName_ShouldBeDeletedFromTheResource(string userName, string comments)
        {
            resourcePage
                .IsReviewListed(userName, comments)
                .Should()
                .BeFalse();
        }

        [Then(@"The total count of reviews for that resource should be reduced by 1")]
        public void ThenTheTotalCountOfReviewsForThatResourceShouldBeReducedBy1()
        {
            resourcePage
                .GetReviewCountDifference("BeforeDelete")
                .Should()
                .Be(1);
        }

        [When(@"I click the resource Delete button")]
        public void WhenIClickTheResourceDeleteButton()
        {
            resourcePage.DeleteResourceButton();
        }

        [Then(@"The total count of resources for that subject should be reduced by 1")]
        public void ThenTheTotalCountOfResourcesForThatSubjectShouldBeReducedBy1()
        {
            resourcePage
                .GetResourceCountDifference("BeforeDelete")
                .Should()
                .Be(1);
        }

        [Then(@"I should get (.*) required field error messages")]
        public void ThenIShouldGet_ErrorMessageCount_RequiredFieldErrorMessages(int errorMessageCount)
        {
            resourcePage
                .ErrorMessageCount()
                .Should()
                .Be(errorMessageCount);
        }

        [Then(@"The error text should read '(.*)'")]
        public void ThenTheErrorTextShouldRead(string errorMessage)
        {
            resourcePage
                .ErrorMessageText()
                .Should()
                .Be(errorMessage);
        }
    }
}