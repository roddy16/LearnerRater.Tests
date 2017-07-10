using FluentAssertions;
using LearnerRater.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace LearnerRater.Tests.Steps
{
    [Binding]
    public sealed class NewResourcePageSteps
    {
        private readonly ResourcePage resourcePage;
        private readonly ResourceSubjectsPage resourceSubjectsPage;

        public NewResourcePageSteps(ResourcePage resourcePage, ResourceSubjectsPage resourceSubjectsPage)
        {
            this.resourcePage = resourcePage;
            this.resourceSubjectsPage = resourceSubjectsPage;
        }

        [When(@"I click the Add Resource Link button")]
        [Given(@"I have clicked the Add Resource Link button")]
        public void WhenIClickTheAddResourceLinkButton()
        {
            resourcePage.AddNewResource();
        }
        
        [Given(@"I have entered a resource with (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void GivenIHaveEnteredAResourceWith_Subject_Title_Author_Description_Website_Link_Username_Rating_And_Comments(
            string subject, string title, string author, string description, string website, 
            string link, string userName, string rating, string comments)
        {
            resourcePage.AddResourceFields(subject, title, author, description, website, link, userName, rating, comments);
        }
        
        [When(@"I click the Resource Submit button")]
        [Given(@"I have clicked the Resource Submit button")]
        public void WhenIClickTheResourceSubmitButton()
        {
            resourcePage.AddResourceSubmitButton();
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
        
        [Then(@"the new resource (.*), (.*), (.*), (.*) and (.*) should display")]
        public void ThenTheNewResource_Title_Author_Description_Website_And_Link_ShouldDisplay(
            string title, string author, string description, string website, string link)
        {
            resourcePage
                .IsResourceListed(title, author, description, website, link)
                .Should()
                .BeTrue();
        }

        [Then(@"the total count of resources for that subject should be incremented by 1")]
        public void ThenTheTotalCountOfResourcesForThatSubjectShouldBeIncrementedBy1()
        {
            resourcePage
                .GetResourceCountDifference("BeforeAdd")
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
                .GetResourceCountDifference(subject, "BeforeAdd")
                .Should()
                .Be(-1);
        }

        [Then(@"the total count of resources for '(.*)' should be displayed on the resource subjects page as '(.*)'")]
        public void ThenTheTotalCountOfResourcesForShouldBeDisplayedOnTheResourceSubjectsPageAs(string category, int numberOfResources)
        {
            resourceSubjectsPage
                .BackToSubjectsPageButton
                .Click();

            resourceSubjectsPage
                .NumberOfResources(category).Text
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

        [Then(@"the new resource (.*) by (.*) about (.*) on (.*) at (.*) should not be added to the resource page")]
        public void ThenTheNewResource_Title_By_Author_About_Description_On_Website_At_Link_ShouldNotBeAddedToTheResourcePage(
            string title, string author, string description, string website, string link)
        {
            resourcePage
                .IsResourceListed(title, author, description, website, link)
                .Should()
                .BeFalse();
        }
    }
}
