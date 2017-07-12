﻿using LearnerRater.Tests.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;
using LearnerRater.Tests.Contexts;
using LearnerRater.Tests.Models;
using TechTalk.SpecFlow.Assist;

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
                .GetReviewCountDifference("BeforeAdd")
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

        [When(@"I click the review Delete button")]
        public void WhenIClickTheReviewDeleteButton()
        {
            resourcePage.DeleteReviewButton();
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

        [Then(@"the error text should read '(.*)'")]
        public void ThenTheErrorTextShouldRead_ErrorMessage(string errorMessage)
        {
            resourcePage
                .ErrorMessageText()
                .Should()
                .Be(errorMessage);
        }
    }
}