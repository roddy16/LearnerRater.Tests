Feature: ResourceSubjectsPage
	In order to rate certain resources
	As a reviewer
	I want to get to the resource page for the subject chosen

Scenario Outline: Navigate to the resource page for the chosen subject
	Given I have accessed the resource subjects page
	When I click the <subject> link
	Then The resource page should be loaded for <subject> resources
	Examples: 
		| subject  |
		| React    |
		| Specflow |
		| NCrunch  |