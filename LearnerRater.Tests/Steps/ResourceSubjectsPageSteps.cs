﻿using LearnerRater.Tests.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace LearnerRater.Tests.Steps
{
    [Binding]
    public sealed class ResourceSubjectsPageSteps
    {
        private readonly ResourceSubjectsPage resourceSubjectsPage;
        private readonly ResourcePage resourcePage;

        public ResourceSubjectsPageSteps(ResourceSubjectsPage resourceSubjectsPage, ResourcePage resourcePage)
        {
            this.resourceSubjectsPage = resourceSubjectsPage;
            this.resourcePage = resourcePage;
        }

        [Given(@"I have accessed the resource subjects page")]
        public void GivenIHaveAccessedTheResourceSubjectsPage()
        {
            resourceSubjectsPage.NavigateTo();
        }

        [When(@"I click the (.*) link")]
        public void WhenIClickThe_Subject_Link(string subject)
        {
            resourceSubjectsPage.SelectSubject(subject);
        }

        [Then(@"the resource page should be loaded for (.*) resources")]
        public void ThenTheResourcePageShouldBeLoadedFor_Subject_Resources(string subject)
        {
            resourcePage
                .IsCorrectResourcePageDisplayed(subject)
                .Should()
                .BeTrue();
        }
    }
}
