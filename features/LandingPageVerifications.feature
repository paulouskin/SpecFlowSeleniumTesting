Feature: Landing page verification

Background: Open browser 
	Given open my favorite browser
	When I go to UBS landing page

Scenario: Verify landing page title
	Then page title contains "UBS financial services around the globe"

Scenario: Verify landing page language switch
	When I allow all cookies to be stored
	And I switch page language
	Then page title contains "Unsere Finanzdienstleistungen auf der ganzen Welt"

Scenario: Verify landing page search feature
	When I allow all cookies to be stored
	And I search for "wealth management"
	Then search results text contains "wealth management" query