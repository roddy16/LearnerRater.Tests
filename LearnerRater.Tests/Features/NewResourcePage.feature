Feature: NewResourcePage
	In order to add resources to the LearnerRater site
	As a contributor
	I want to:

Scenario: Display Add Resource Link screen
	Given I have selected 'NCrunch' as the category
	When I click the Add Resource Link button
	Then the add new resource link form should be displayed

Scenario Outline: Add a New Resource
	Given I have selected '<subject>' as the category
		And I have clicked the Add Resource Link button
		And I have entered the following resource
		| Category | Title            | Author    | Description             | Website    | Link                   | Username | Rating | Comment            |
		| NCrunch  | Crunching N Time | Dr. Suess | Learn all about NCrunch | LearnStuff | http://learnstuff.com/ | sRods    | 5      | It was awesome!!!! |
	When I click the Resource Submit button
	Then I should be redirected to the selected resource page
		And the new resource should display the information entered
		And the new resource should have added a review
		And the total count of resources for that subject should be '1'
		And the total count of resources for that subject should be displayed on the resource subjects page as '1'
	Examples: 
	| subject |
	| Other   |
	| NCrunch |

Scenario: Cancel a New Resource
	Given I have selected 'JavaScript' as the category
		And I have clicked the Add Resource Link button
		And I have entered the following resource
		| Category   | Title               | Author       | Description               | Website | Link               | Username | Rating | Comment       |
		| JavaScript | JavaScript Not Java | J.S. Manwell | Learn javascript not Java | JS Site | http://jssite.com/ | sRods    | 1      | It was meh!!!! |
	When I click the Resource Cancel button
	Then the form should close
		And the new resource should not be added to the resource page
