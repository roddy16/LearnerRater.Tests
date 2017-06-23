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
        
        [When(@"I enter required fields")]
        public void WhenIEnterRequiredFields()
        {
            resourcePage.addReviewFields();
        }
        
        [When(@"I click the Submit button")]
        public void WhenIClickTheSubmitButton()
        {
            resourcePage.addReviewButton("btnSubmitRating");
        }
        
        [When(@"I click the Cancel button")]
        public void WhenIClickTheCancelButton()
        {
            resourcePage.addReviewButton("btnCancelRating");
        }
        
        [Then(@"All the reviews should be displayed")]
        public void ThenAllTheReviewsShouldBeDisplayed()
        {
            resourcePage
                .containsReviews()
                .Should()
                .BeTrue();
        }
        
        [Then(@"All the reviews should be hidden")]
        public void ThenAllTheReviewsShouldBeHidden()
        {
            resourcePage
                .containsReviews()
                .Should()
                .BeFalse();
        }

        [Then(@"The button should read Hide Reviews")]
        public void ThenTheButtonShouldReadHideReviews()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The button should read Show Reviews")]
        public void ThenTheButtonShouldReadShowReviews()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The Add Review overlay should appear")]
        public void ThenTheAddReviewOverlayShouldAppear()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The overlay should close")]
        public void ThenTheOverlayShouldClose()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The review should be added to the resource")]
        public void ThenTheReviewShouldBeAddedToTheResource()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"The review should not be added")]
        public void ThenTheReviewShouldNotBeAdded()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click the Delete button")]
        public void WhenIClickTheDeleteButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The review should be deleted")]
        public void ThenTheReviewShouldBeDeleted()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
