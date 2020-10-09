Feature: AudenLoansFeature


@MyTag
Scenario: No Repayment on weekends
	Given I want to apply for a loan with Auden
	When I move the Slider to the mount of £350
	And Select the repayment day to be the 8
	Then I should see the total payback amount being £394.68
	And The First repayment will be on the Friday 6 Nov 2020


Scenario: Min Loan Amount
	Given I want to apply for a loan with Auden
	When I move the Slider to the mount of £200
	And Select the repayment day to be the Last working day
	Then I should see the total payback amount being £222.11
	And The First repayment will be on the Friday 30 Oct 2020

Scenario: Max Loan Amount
	Given I want to apply for a loan with Auden
	When I move the Slider to the mount of £500
	And Select the repayment day to be the Last working day
	Then I should see the total payback amount being £555.29
	And The First repayment will be on the Friday 30 Oct 2020