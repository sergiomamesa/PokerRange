Feature: UTG6max_FullTable
	In order to know what action to take in a 6-max full table
	As a UTG Positioned player
	I want to be told the action

@UTG6max
Scenario: Hero is UTG - full table
	Given a six-max player table
	And table is full
	And Hero is UTG
	And Hero has 0, 0, 1, 0
	When Action reaches Hero
	Then Hero is told to take action 5