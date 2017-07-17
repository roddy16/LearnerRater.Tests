using FluentAssertions;
using LearnerRater.Tests.Models;
using LearnerRater.Tests.PageObjects;
using TechTalk.SpecFlow;
using LearnerRater.Tests.Contexts;
using TechTalk.SpecFlow.Assist;
using System;
using System.Collections.Generic;
using System.Reflection;
using LearnerRater.Tests.Utils;

namespace LearnerRater.Tests.Steps
{
    [Binding]
    public sealed class NewResourcePageSteps
    {
        private readonly ResourcePage resourcePage;
        private readonly ResourceSubjectsPage resourceSubjectsPage;
        private readonly ResourcePageContext context;

        public NewResourcePageSteps(ResourcePage resourcePage, ResourceSubjectsPage resourceSubjectsPage, ResourcePageContext context)
        {
            this.resourcePage = resourcePage;
            this.resourceSubjectsPage = resourceSubjectsPage;
            this.context = context;
        }

        [When(@"I click the Add Resource Link button")]
        [Given(@"I have clicked the Add Resource Link button")]
        public void WhenIClickTheAddResourceLinkButton()
        {
            context.NumberOfResourcesBeforeAction = resourcePage.GetNumberOfResources();
            resourcePage.AddNewResource();
        }
        
        [Given(@"I have entered the following resource")]
        public void GivenIHaveEnteredTheFollowingResource(Table table)
        {
            context.Resource = table.CreateInstance<Resource>();

            resourcePage.AddResourceFields(context.Resource);
        }

        [When(@"I click the Resource Submit button")]
        [Given(@"I have clicked the Resource Submit button")]
        public void WhenIClickTheResourceSubmitButton()
        {
            resourcePage.AddResourceSubmitButton();
        }

        [Given(@"I have entered more than the maximum allowed characters for the following resource fields")]
        public void GivenIHaveEnteredMoreThanTheMaximumAllowedCharactersForTheFollowingFields(Table table)
        {
            var resourceMaxLength = table.CreateInstance<ResourceMaxLength>();

            var model = new Resource() { Category = "React", Rating = 1 };
            var resource = ModelHelpers.CreateModelWithPropertiesExceedingMaxLength(model, resourceMaxLength);

            resourcePage.AddResourceFields(resource);
        }

        [When(@"I click the Resource Cancel button")]
        public void WhenIClickTheResourceCancelButton()
        {
            resourcePage.AddResourceCancelButton();
        }
        
        [Then(@"the add new resource link form should be displayed")]
        public void ThenTheAddNewResourceLinkFormShouldBeDisplayed()
        {
            resourcePage
                .IsAddResourceFormDisplayed()
                .Should()
                .BeTrue();
        }

        [Then(@"I should be redirected to the selected resource page")]
        public void ThenIShouldBeRedirectedToTheSelectedResourcePage()
        {
            resourcePage
                .IsCorrectResourcePageDisplayed(context.Resource.Category)
                .Should()
                .BeTrue();
        }

        [Then(@"the new resource should display the information entered")]
        public void ThenTheNewResourceShouldDisplayTheInformationEntered()
        {
            resourcePage
                .IsSuccessfullyCreateResourceListed(context.Resource)
                .Should()
                .BeTrue();
        }

        [Then(@"the total count of resources for that subject should be incremented by 1")]
        public void ThenTheTotalCountOfResourcesForThatSubjectShouldBeIncrementedBy1()
        {
            resourcePage
                .GetResourceCountDifference(context.NumberOfResourcesBeforeAction)
                .Should()
                .Be(-1);
        }

        [Then(@"the total count of resources for that subject should be '(.*)'")]
        public void ThenTheTotalCountOfResourcesForThatSubjectShouldBe(int numberOfResources)
        {
            resourcePage
                .NumberOfResources.Text
                .Should()
                .Be($"{numberOfResources}");
        }


        [Then(@"the total count of resources for (.*) should be displayed on the resource subjects page")]
        public void ThenTheTotalCountOfResourcesFor_Subject_ShouldBeDisplayedOnTheResourceSubjectsPage(string subject)
        {
            resourceSubjectsPage.NavigateTo();

            resourceSubjectsPage
                .GetResourceCountDifference(subject, context.NumberOfResourcesBeforeAction)
                .Should()
                .Be(-1);
        }

        [Then(@"the total count of resources for that subject should be displayed on the resource subjects page as '(.*)'")]
        public void ThenTheTotalCountOfResourcesForThatSubjectShouldBeDisplayedOnTheResourceSubjectsPageAs(int numberOfResources)
        {
            resourceSubjectsPage
                .BackToSubjectsPageButton
                .Click();

            resourceSubjectsPage
                .NumberOfResources(context.Resource.Category).Text
                .Should()
                .Be($"{numberOfResources}");
        }

        [Then(@"the form should close")]
        public void ThenTheFormShouldClose()
        {         
            resourcePage
                .IsAddResourceFormDisplayed()
                .Should()
                .BeFalse();
        }

        [Then(@"the new resource should not be added to the resource page")]
        public void ThenTheNewResourceShouldNotBeAddedToTheResourcePage()
        {
            resourcePage
                .IsResourceListed(context.Resource)
                .Should()
                .BeFalse();
        }
    }
}
