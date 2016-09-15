Feature: UTG6max_NoUTGplusOne
	In order to know what action to take in a 6-max full table
	As a UTG Positioned player
	I want to be told the action

@UTG6max
Scenario: Hero is UTG - UTG plus one is empty
	Given a six-max player table not full
	And UTG plus one is empty
	And Hero is UTG
	And Hero has "specific hand"
	When Action reaches Hero
	Then Hero is told the action to take