Feature: ResourcePage
	In order to rate and view certain resources
	As a reviewer
	I want:

Scenario: Show Reviews
	Given I have accessed the resources page
	When I click Show Reviews
	Then All the reviews should be displayed
	And The button should read Hide Reviews

Scenario: Hide Reviews
	Given I have accessed the resources page
	When I click Show Reviews
	And I click Hide Reviews
	Then All the reviews should be hidden
	And The button should read Show Reviews

Scenario: Display Review Overlay
	Given I have accessed the resources page
	When I click You Be The Judge button
	Then The Add Review overlay should appear

Scenario: Add a Review
	Given I have accessed the resources page
	And I have opened the Add Review overlay
	When I enter required fields
	And I click the Submit button
	Then The overlay should close
	And The review should be added to the resource

Scenario: Cancel Adding a Review
	Given I have accessed the resources page
	And I have opened the Add Review overlay
	When I click the Cancel button
	Then The overlay should close
	And The review should not be added

Scenario: Delete a Review
	Given I have accessed the resources page
	And I have clicked Show Reviews
	When I click the Delete button
	Then The review should be deleted
