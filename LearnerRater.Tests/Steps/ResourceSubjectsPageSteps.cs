using LearnerRater.Tests.PageObjects;
using TechTalk.SpecFlow;

namespace LearnerRater.Tests.Steps
{
    [Binding]
    public sealed class ResourceSubjectsPageSteps
    {
        private readonly ResourceSubjectsPage resourceSubjectsPage;

        public ResourceSubjectsPageSteps(ResourceSubjectsPage resourceSubjectsPage)
        {
            this.resourceSubjectsPage = resourceSubjectsPage;
        }

        [Given(@"I have accessed the resource subjects page")]
        public void GivenIHaveAccessedTheResourceSubjectsPage()
        {
            resourceSubjectsPage.navigateTo();
        }

        [When(@"I click the (.*) link")]
        public void WhenIClickThe_Subject_Link(string subject)
        {

            resourceSubjectsPage.selectSubject(subject);
        }

        [Then(@"The resource page should be loaded for (.*) resources")]
        public void ThenTheResourcePageShouldBeLoadedFor_Subject_Resources(string subject)
        {
            
        }
    }
}
