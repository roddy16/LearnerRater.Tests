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

Scenario: Add a Resource without Title, Author, Description, Website, Link, Username or Star Rating
	Given I have selected 'Git' as the category
		And I have clicked the Add Resource Link button
	When I click the Resource Submit button
	Then I should get '7' error messages
		And the error text should read 'Required'

Scenario: Add a Resource with a long Title, Author, Website, Link and Username
	Given I have selected 'SpecFlow' as the category
		And I have clicked the Add Resource Link button
		And I have entered more than the maximum allowed characters for the following fields
			| fieldName | maxCharacters |
			| title     | 100           |
			| author    | 50            |
			| website   | 50            |
			| link      | 2048          |
			| username  | 50            |
	When I click the Resource Submit button
	Then I should get '5' error messages
		And the error text should read 'Exceeded max field size'

Scenario: Add a Resource with a link missing http:// or https://
	Given I have selected 'NCrunch' as the category
		And I have clicked the Add Resource Link button
		And I have entered the following resource
		| Category | Title            | Author    | Description             | Website    | Link                   | Username | Rating | Comment            |
		| NCrunch  | Crunching N Time | Dr. Suess | Learn all about NCrunch | LearnStuff | wwww.learnstuff.com/   | sRods    | 5      | It was awesome!!!! |
	When I click the Resource Submit button
	Then I should get '1' error message
		And the error text should read 'URL link should start with http:// OR https://'
