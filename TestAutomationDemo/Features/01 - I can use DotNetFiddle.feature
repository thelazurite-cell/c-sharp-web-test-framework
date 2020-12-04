@DotFiddle
Feature: 01 - I can use DotNetFiddle
  AS a software developer 
  I want to be able to write code on the go
  So that I can test out ideas from anywhere 
  
  @BrowserTest
  # Sometimes the dotnetfiddle page will display an invisible overlay, the extra given step waits until it is removed from the DOM 
  Scenario: 01 - I can see output for a generic hello world application
    Given I have visited the DotNetFiddle page
    And The overlay is not visible 
    When I click the run button
    Then The output window should contain 'Hello World'
    
  @BrowserTest
  Scenario: 02 - Check NUnit package has been added
    Given I have visited the DotNetFiddle page
    And The overlay is not visible
    When I search for the 'NUnit' package
    And I click the result that exactly matches 'NUnit'
    Then Version '3.12.0' should be added
    