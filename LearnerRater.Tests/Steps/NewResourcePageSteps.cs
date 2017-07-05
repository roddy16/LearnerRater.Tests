using FluentAssertions;
using LearnerRater.Tests.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace LearnerRater.Tests.Steps
{
    [Binding]
    public sealed class NewResourcePageSteps
    {
        private readonly ResourcePage resourcePage;

        public NewResourcePageSteps(ResourcePage resourcePage)
        {
            this.resourcePage = resourcePage;
        }

        [When(@"I click the Add Resource Link button")]
        public void WhenIClickTheAddResourceLinkButton()
        {
            resourcePage.AddNewResource();
        }
        
        [When(@"I input (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenIInput_Subject_Title_Author_Description_Website_Link_Username_Rating_And_Comment(
            string subject, string title, string author, string description, string website, 
            string link, string userName, string rating, string comment)
        {
            resourcePage.AddResourceFields(subject, title, author, description, website, link, userName, rating, comment);
        }
        
        [When(@"I click the Resource Submit button")]
        public void WhenIClickTheResourceSubmitButton()
        {
            resourcePage.AddResourceSubmitButton();
        }
        
        [When(@"I click the Resource Cancel button")]
        public void WhenIClickTheResourceCancelButton()
        {
            resourcePage.AddResourceCancelButton();
        }
        
        [Then(@"The add new resource link form should be displayed")]
        public void ThenTheAddNewResourceLinkFormShouldBeDisplayed()
        {
            resourcePage
                .DoesAddResourceFormExist()
                .Should()
                .BeTrue();
        }
        
        [Then(@"I should be redirected to the (.*) resource page")]
        public void ThenIShouldBeRedirectedToThe_Subject_ResourcePage(string subject)
        {
            resourcePage
                .IsCorrectResourcePageDisplayed(subject)
                .Should()
                .BeTrue();
        }
        
        [Then(@"The new resource (.*), (.*), (.*), (.*) and (.*) should display")]
        public void ThenTheNewResource_Title_Author_Description_Website_And_Link_ShouldDisplay(
            string title, string author, string description, string website, string link)
        {
            resourcePage
                .IsResourceListed(title, author, description, website, link)
                .Should()
                .BeTrue();
        }

        [Then(@"The total count of resources for that subject should be incremented by 1")]
        public void ThenTheTotalCountOfResourcesForThatSubjectShouldBeIncrementedBy1()
        {
            resourcePage
                .GetResourceCountDifference("BeforeAdd")
                .Should()
                .Be(-1);
        }

        [Then(@"The new resource should not be added to the resource page")]
        public void ThenTheNewResourceShouldNotBeAddedToTheResourcePage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
