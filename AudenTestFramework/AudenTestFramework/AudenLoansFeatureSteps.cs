using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using NUnit.Framework;

namespace AudenTestFramework
{
    [Binding]
    public class AudenLoansFeatureSteps
    {

        private IWebDriver WebDriver;
        AudenLoansPage LoansPage;
        [BeforeScenario]
        public void SetUp()
        {
            WebDriver = new WebDriverBuilder().Build(BROWSER.Chrome);

        }

        [AfterScenario]
        public void TearDown()
        {
            WebDriver.Quit();
        }

        [Given(@"I want to apply for a loan with Auden")]
        public void GivenIWantToApplyForALoanWithAuden()
        {
            WebDriver.Navigate().GoToUrl("https://www.auden.co.uk/credit/shorttermloan");
        }
        
        [When(@"I move the Slider to the mount of £(.*)")]
        public void WhenIMoveTheSliderToTheMountOf(int loanAmount)
        {
            LoansPage = new AudenLoansPage(WebDriver);
            Assert.False(LoansPage.SetLoanSlider(loanAmount));
        }
        
        [Then(@"I should see the total payback amount being £(.*)")]
        public void ThenIShouldSeeTheTotalPaybackAmountBeing(String totalPayable)
        {
            Assert.That(totalPayable, Is.EqualTo(LoansPage.GetTotalRepaymentAmount()));
        }

        [When(@"Select the repayment day to be the (.*)")]
        public void WhenSelectTheRepaymentDayToBeTheTh(String repaymentDay)
        {
            LoansPage.SetRepaymentDay(repaymentDay);
        }

        [Then(@"The First repayment will be on the (.*)")]
        public void ThenTheFirstRepaymentWillBeOnTheTh(String actualRepaymentDay)
        {
            Assert.That(actualRepaymentDay, Is.EqualTo(LoansPage.GetActualRepaymentDay()));
        }

    }
}
