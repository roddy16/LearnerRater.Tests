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

        [Given(@"I have selected '(.*)' as the category")]
        public void GivenIHaveSelectedAsTheCategory(string category)
        {
            resourcePage.NavigateTo(category);
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

        [Then(@"all the reviews should be displayed")]
        public void ThenAllTheReviewsShouldBeDisplayed()
        {
            resourcePage
                .IsReviewContainerDisplayed()
                .Should()
                .BeTrue();
        }

        [Then(@"all the reviews should be hidden")]
        public void ThenAllTheReviewsShouldBeHidden()
        {
            resourcePage
                .IsReviewContainerDisplayed()
                .Should()
                .BeFalse();
        }

        [Then(@"the button should read Hide Reviews")]
        public void ThenTheButtonShouldReadHideReviews()
        {
            resourcePage
                .ReviewButtonToggleDisplayText()
                .Should()
                .StartWith("HIDE REVIEWS");
        }

        [Then(@"the button should read Show Reviews")]
        public void ThenTheButtonShouldReadShowReviews()
        {
            resourcePage
                .ReviewButtonToggleDisplayText()
                .Should()
                .StartWith("SHOW REVIEWS");
        }

        [Then(@"the Add Review overlay should appear")]
        public void ThenTheAddReviewOverlayShouldAppear()
        {
            resourcePage
                .IsAddReviewOverlayDisplayed()
                .Should()
                .BeTrue();
        }

        [Then(@"the overlay should close")]
        public void ThenTheOverlayShouldClose()
        {
            resourcePage
                .IsAddReviewOverlayDisplayed()
                .Should()
                .BeFalse();
        }

        [Then(@"the review by (.*) should be added to the resource with their (.*)")]
        [Then(@"the new resource should have (.*) by (.*) listed")]
        public void ThenTheReviewBy_UserName_ShouldBeAddedToTheResourceWithTheir_Comments(string userName, string comments)
        {
            resourcePage.ToggleReviews();

            resourcePage
                .IsReviewListed(userName, comments)
                .Should()
                .BeTrue();
        }

        [Then(@"the total count of reviews for that resource should be incremented by 1")]
        public void ThenTheTotalCountOfReviewsForThatResourceShouldBeIncrementedBy1()
        {
            resourcePage
                .GetReviewCountDifference("BeforeAdd")
                .Should()
                .Be(-1);
        }

        [Then(@"the review by (.*) should not be added to the resource with their (.*)")]
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

        [Then(@"the review by (.*) with (.*) should be deleted from the resource")]
        public void ThenTheReviewBy_UserName_ShouldBeDeletedFromTheResource(string userName, string comments)
        {
            resourcePage
                .IsReviewListed(userName, comments)
                .Should()
                .BeFalse();
        }

        [Then(@"the total count of reviews for that resource should be reduced by 1")]
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

        [Then(@"the total count of resources for that subject should be reduced by 1")]
        public void ThenTheTotalCountOfResourcesForThatSubjectShouldBeReducedBy1()
        {
            resourcePage
                .GetResourceCountDifference("BeforeDelete")
                .Should()
                .Be(1);
        }

        [Then(@"I should get '(.*)' error messages")]
        [Then(@"I should get '(.*)' error message")]
        public void ThenIShouldGet_ErrorMessageCount_RequiredFieldErrorMessages(int errorMessageCount)
        {
            resourcePage
                .ErrorMessageCount()
                .Should()
                .Be(errorMessageCount);
        }

        [Then(@"The error text should read '(.*)'")]
        public void ThenTheErrorTextShouldRead_ErrorMessage(string errorMessage)
        {
            resourcePage
                .ErrorMessageText()
                .Should()
                .Be(errorMessage);
        }
    }
}