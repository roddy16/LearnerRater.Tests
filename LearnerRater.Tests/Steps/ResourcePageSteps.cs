using LearnerRater.Tests.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;
using LearnerRater.Tests.Contexts;
using LearnerRater.Tests.Models;
using TechTalk.SpecFlow.Assist;
using LearnerRater.Tests.Utils;

namespace LearnerRater.Tests.Steps
{
    [Binding]
    public sealed class ResourcePageSteps
    {
        private readonly ResourcePage resourcePage;
        private readonly ResourcePageContext context;

        public ResourcePageSteps(ResourcePage resourcePage, ResourcePageContext context)
        {
            this.resourcePage = resourcePage;
            this.context = context;
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

        [Given(@"I have entered the following review")]
        public void GivenIHaveEnteredTheFollowingReview(Table table)
        {
            context.Resource = table.CreateInstance<Resource>();

            resourcePage.AddReviewFields(context.Resource);
        }

        [When(@"I click the Submit button")]
        [Given(@"I have clicked the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            context.NumberOfReviewsBeforeAction = resourcePage.GetNumberOfReviews();
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

        [Then(@"the new review should display the information entered")]
        public void ThenTheNewReviewShouldDisplayTheInformationEntered()
        {
            resourcePage.ToggleReviews();

            resourcePage
                .IsReviewListed(context.Resource)
                .Should()
                .BeTrue();
        }

        [Then(@"the new resource should have added a review")]
        public void ThenTheNewResourceShouldHaveAddedAReview()
        {
            resourcePage.ToggleReviews();

            resourcePage
                .IsReviewListed(context.Resource)
                .Should()
                .BeTrue();
        }


        [Then(@"the total count of reviews for that resource should be incremented by 1")]
        public void ThenTheTotalCountOfReviewsForThatResourceShouldBeIncrementedBy1()
        {
            resourcePage
                .GetReviewCountDifference(context.NumberOfReviewsBeforeAction)
                .Should()
                .Be(-1);
        }

        [Then(@"the new review should not be added to the resource")]
        public void ThenTheNewReviewShouldNotBeAddedToTheResource()
        {
            resourcePage.ToggleReviews();

            resourcePage
                .IsReviewListed(context.Resource)
                .Should()
                .BeFalse();
        }

        [Given(@"I have clicked the manage button")]
        public void GivenIHaveClickedTheManageButton()
        {
            resourcePage.ToggleManageButton();
        }

        [Given(@"I have entered more than the maximum allowed characters for the following review field")]
        public void GivenIHaveEnteredMoreThanTheMaximumAllowedCharactersForTheFollowingReviewField(Table table)
        {
            var reviewMaxLength = table.CreateInstance<ReviewMaxLength>();

            var model = new Review() { Rating = 1 };
            var review = ModelHelpers.CreateModelWithPropertiesExceedingMaxLength(model, reviewMaxLength);

            resourcePage.AddReviewFields(review);
        }

        [When(@"I click the review Delete button")]
        public void WhenIClickTheReviewDeleteButton()
        {
            context.NumberOfReviewsBeforeAction = resourcePage.GetNumberOfReviews();
            resourcePage.ClickDeleteReviewButton(context.NumberOfReviewsBeforeAction);
        }

        [Then(@"the review should be deleted from the resource")]
        public void ThenTheReviewShouldBeDeletedFromTheResource()
        {
            resourcePage
                .IsReviewListed(context.Resource)
                .Should()
                .BeFalse();
        }

        [Then(@"the total count of reviews for that resource should be reduced by 1")]
        public void ThenTheTotalCountOfReviewsForThatResourceShouldBeReducedBy1()
        {
            resourcePage
                .GetReviewCountDifference(context.NumberOfReviewsBeforeAction)
                .Should()
                .Be(1);
        }

        //TODO: Add parameter to step to specify which resource to delete
        [When(@"I click the resource Delete button")]
        public void WhenIClickTheResourceDeleteButton()
        {
            context.NumberOfResourcesBeforeAction = resourcePage.GetNumberOfResources();
            resourcePage.ClickDeleteResourceButton(context.NumberOfResourcesBeforeAction);
        }

        [Then(@"the total count of resources for that subject should be reduced by 1")]
        public void ThenTheTotalCountOfResourcesForThatSubjectShouldBeReducedBy1()
        {
            resourcePage
                .GetResourceCountDifference(context.NumberOfResourcesBeforeAction)
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

        [Then(@"the error text should read '(.*)'")]
        public void ThenTheErrorTextShouldRead_ErrorMessage(string errorMessage)
        {
            resourcePage
                .ErrorMessageText()
                .Should()
                .Be(errorMessage);
        }

        [Given(@"the sort by resource name option is not already ascending")]
        public void GivenTheSortByResourceNameOptionIsNotAlreadyAscending()
        {          
            //click once to sort descending
            resourcePage.SortResourceName(1);
        }

        [When(@"I click the sort by resource name option")]
        public void WhenIClickTheSortByResourceNameOption()
        {
            resourcePage.SortResourceName(1);
        }

        [Then(@"the resources should be sorted ascending by name")]
        public void ThenTheResourcesShouldBeSortedAscendingByName()
        {
            resourcePage
                .CaptureResourceList()
                .Should()
                .BeInAscendingOrder();
        }

        [Given(@"the sort by resource name option is not already descending")]
        public void GivenTheSortByResourceNameOptionIsNotAlreadyDescending()
        {         
            //click twice to sort ascending
            resourcePage.SortResourceName(2);
        }

        [Then(@"the resources should be sorted descending by name")]
        public void ThenTheResourcesShouldBeSortedDescendingByName()
        {
            resourcePage
                .CaptureResourceList()
                .Should()
                .BeInDescendingOrder();
        }

        [Given(@"the sort by resource average rating option is not already ascending")]
        public void GivenTheSortByResourceAverageRatingOptionIsNotAlreadyAscending()
        {
            resourcePage.SortResourceAverageRating(1);
        }

        [When(@"I click the sort by resource average rating option")]
        public void WhenIClickTheSortByResourceAverageRatingOption()
        {
            resourcePage.SortResourceAverageRating(1);
        }

        [Then(@"the resources should be sorted ascending by average rating")]
        public void ThenTheResourcesShouldBeSortedAscendingByAverageRating()
        {
            resourcePage
                .CaptureResourceListStarRatings()
                .Should()
                .BeInAscendingOrder();
        }

        [Given(@"the sort by resource average rating option is not already descending")]
        public void GivenTheSortByResourceAverageRatingOptionIsNotAlreadyDescending()
        {
            //click twice to trigger sort option and sort to make ascending (default is descending)
            resourcePage.SortResourceAverageRating(2);
        }

        [Then(@"the resources should be sorted descending by average rating")]
        public void ThenTheResourcesShouldBeSortedDescendingByAverageRating()
        {
            resourcePage
                 .CaptureResourceListStarRatings()
                 .Should()
                 .BeInDescendingOrder();
        }
    }
}