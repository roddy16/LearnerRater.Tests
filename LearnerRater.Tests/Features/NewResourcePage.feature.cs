﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LearnerRater.Tests.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class NewResourcePageFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "NewResourcePage.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "NewResourcePage", "\tIn order to add resources to the LearnerRater site\r\n\tAs a contributor\r\n\tI want t" +
                    "o:", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "NewResourcePage")))
            {
                global::LearnerRater.Tests.Features.NewResourcePageFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Display Add Resource Link screen")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NewResourcePage")]
        public virtual void DisplayAddResourceLinkScreen()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Display Add Resource Link screen", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I have selected \'NCrunch\' as the category", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.When("I click the Add Resource Link button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 9
 testRunner.Then("the add new resource link form should be displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void AddANewResource(string subject, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a New Resource", exampleTags);
#line 11
this.ScenarioSetup(scenarioInfo);
#line 12
 testRunner.Given(string.Format("I have selected \'{0}\' as the category", subject), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 13
  testRunner.And("I have clicked the Add Resource Link button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Category",
                        "Title",
                        "Author",
                        "Description",
                        "Website",
                        "Link",
                        "Username",
                        "Rating",
                        "Comment"});
            table1.AddRow(new string[] {
                        "NCrunch",
                        "Crunching N Time",
                        "Dr. Suess",
                        "Learn all about NCrunch",
                        "LearnStuff",
                        "http://learnstuff.com/",
                        "sRods",
                        "5",
                        "It was awesome!!!!"});
#line 14
  testRunner.And("I have entered the following resource", ((string)(null)), table1, "And ");
#line 17
 testRunner.When("I click the Resource Submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("I should be redirected to the selected resource page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
  testRunner.And("the new resource should display the information entered", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
  testRunner.And("the new resource should have added a review", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
  testRunner.And("the total count of resources for that subject should be \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
  testRunner.And("the total count of resources for that subject should be displayed on the resource" +
                    " subjects page as \'1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add a New Resource: Other")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NewResourcePage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "Other")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:subject", "Other")]
        public virtual void AddANewResource_Other()
        {
#line 11
this.AddANewResource("Other", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add a New Resource: NCrunch")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NewResourcePage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "NCrunch")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:subject", "NCrunch")]
<<<<<<< Updated upstream
        public virtual void AddANewResource_NCrunch()
        {
#line 11
this.AddANewResource("NCrunch", ((string[])(null)));
=======
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:title", "Crunching N Time")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:author", "Dr. Suess")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:description", "Learn all about NCrunch")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:website", "LearnStuff")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:link", "http://learnncrunchstuff.com/")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:username", "sRods")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:rating", "Rating_5")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:comments", "It was awesome!!!!")]
        public virtual void AddANewResource_NCrunch()
        {
#line 11
this.AddANewResource("NCrunch", "Crunching N Time", "Dr. Suess", "Learn all about NCrunch", "LearnStuff", "http://learnncrunchstuff.com/", "sRods", "Rating_5", "It was awesome!!!!", ((string[])(null)));
>>>>>>> Stashed changes
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cancel a New Resource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NewResourcePage")]
        public virtual void CancelANewResource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cancel a New Resource", ((string[])(null)));
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
 testRunner.Given("I have selected \'JavaScript\' as the category", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
  testRunner.And("I have clicked the Add Resource Link button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Category",
                        "Title",
                        "Author",
                        "Description",
                        "Website",
                        "Link",
                        "Username",
                        "Rating",
                        "Comment"});
            table2.AddRow(new string[] {
                        "JavaScript",
                        "JavaScript Not Java",
                        "J.S. Manwell",
                        "Learn javascript not Java",
                        "JS Site",
                        "http://jssite.com/",
                        "sRods",
                        "1",
                        "It was meh!!!!"});
#line 31
  testRunner.And("I have entered the following resource", ((string)(null)), table2, "And ");
#line 34
 testRunner.When("I click the Resource Cancel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.Then("the form should close", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
  testRunner.And("the new resource should not be added to the resource page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
<<<<<<< Updated upstream
=======
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cancel a New Resource: JavaScript")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NewResourcePage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "JavaScript")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:subject", "JavaScript")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:title", "JavaScript Not Java")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:author", "J.S. Manwell")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:description", "Learn javascript not Java")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:website", "JS Site")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:link", "http://jssite.com/")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:username", "sRods")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:rating", "Rating_1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:comments", "It was meh!!!!")]
        public virtual void CancelANewResource_JavaScript()
        {
#line 25
this.CancelANewResource("JavaScript", "JavaScript Not Java", "J.S. Manwell", "Learn javascript not Java", "JS Site", "http://jssite.com/", "sRods", "Rating_1", "It was meh!!!!", ((string[])(null)));
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add a Resource without Title, Author, Description, Website, Link, Username or Sta" +
            "r Rating")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NewResourcePage")]
        public virtual void AddAResourceWithoutTitleAuthorDescriptionWebsiteLinkUsernameOrStarRating()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a Resource without Title, Author, Description, Website, Link, Username or Sta" +
                    "r Rating", ((string[])(null)));
#line 36
this.ScenarioSetup(scenarioInfo);
#line 37
 testRunner.Given("I have selected \'Git\' as the category", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
  testRunner.And("I have clicked the Add Resource Link button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.When("I click the Resource Submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.Then("I should get \'7\' error messages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
  testRunner.And("the error text should read \'Required\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void AddAResourceWithALongTitleAuthorWebsiteLinkAndUsername(string subject, string title, string author, string description, string website, string link, string username, string rating, string comments, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a Resource with a long Title, Author, Website, Link and Username", exampleTags);
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given(string.Format("I have selected \'{0}\' as the category", subject), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
  testRunner.And("I have clicked the Add Resource Link button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "fieldName",
                        "maxCharacters"});
            table1.AddRow(new string[] {
                        "title",
                        "100"});
            table1.AddRow(new string[] {
                        "author",
                        "50"});
            table1.AddRow(new string[] {
                        "website",
                        "50"});
            table1.AddRow(new string[] {
                        "link",
                        "2048"});
            table1.AddRow(new string[] {
                        "username",
                        "50"});
#line 46
  testRunner.And("I have entered more than the maximum allowed characters for the following fields", ((string)(null)), table1, "And ");
#line 53
 testRunner.When("I click the Resource Submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("I should get \'5\' error messages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
  testRunner.And("the error text should read \'Exceeded max field size\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add a Resource with a long Title, Author, Website, Link and Username: JavaScript")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NewResourcePage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "JavaScript")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:subject", "JavaScript")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:title", "JavaScript Not Java")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:author", "J.S. Manwell")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:description", "Learn javascript not Java")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:website", "JS Site")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:link", "http://jssite.com/")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:username", "sRods")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:rating", "Rating_1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:comments", "It was meh!!!!")]
        public virtual void AddAResourceWithALongTitleAuthorWebsiteLinkAndUsername_JavaScript()
        {
#line 43
this.AddAResourceWithALongTitleAuthorWebsiteLinkAndUsername("JavaScript", "JavaScript Not Java", "J.S. Manwell", "Learn javascript not Java", "JS Site", "http://jssite.com/", "sRods", "Rating_1", "It was meh!!!!", ((string[])(null)));
#line hidden
        }
        
        public virtual void AddAResourceWithALinkMissingHttpOrHttps(string subject, string title, string author, string description, string website, string link, string username, string rating, string comments, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add a Resource with a link missing http:// or https://", exampleTags);
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
 testRunner.Given(string.Format("I have selected \'{0}\' as the category", subject), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
  testRunner.And("I have clicked the Add Resource Link button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
  testRunner.And(string.Format("I have entered a resource with {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} and {8}", subject, title, author, description, website, link, username, rating, comments), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.When("I click the Resource Submit button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.Then("I should get \'1\' error message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
  testRunner.And("the error text should read \'URL link should start with http:// OR https://\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Add a Resource with a link missing http:// or https://: JavaScript")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "NewResourcePage")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "JavaScript")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:subject", "JavaScript")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:title", "JavaScript Not Java")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:author", "J.S. Manwell")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:description", "Learn javascript not Java")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:website", "JS Site")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:link", "justasite.com")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:username", "sRods")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:rating", "Rating_1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:comments", "It was meh!!!!")]
        public virtual void AddAResourceWithALinkMissingHttpOrHttps_JavaScript()
        {
#line 60
this.AddAResourceWithALinkMissingHttpOrHttps("JavaScript", "JavaScript Not Java", "J.S. Manwell", "Learn javascript not Java", "JS Site", "justasite.com", "sRods", "Rating_1", "It was meh!!!!", ((string[])(null)));
#line hidden
        }
>>>>>>> Stashed changes
    }
}
#pragma warning restore
#endregion
