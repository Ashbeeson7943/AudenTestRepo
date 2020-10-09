using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace AudenTestFramework
{
    class AudenLoansPage
    {

      
        //These fields are being used as 'containers' to get the group of elements that are to be used
        [FindsBy(How = How.CssSelector, Using = ".loan-amount")]
        public IWebElement LoanAmountElement;

        [FindsBy(How = How.CssSelector, Using = ".loan-schedule__tab")]
        public IWebElement RepaymentCalenderElement;

        [FindsBy(How = How.CssSelector, Using = ".loan-summary")]
        public IWebElement TotalsElement;

        private IWebDriver driver;

        public AudenLoansPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public bool SetLoanSlider(int loanAmount)
        {
            bool LoopError = false;
            int loanAmountShown = GetLoanAmountShown();
            IWebElement slider = LoanAmountElement.FindElement(By.CssSelector(".loan-amount__range-slider__input"));
            Actions moveSlider = new Actions(driver);
            int loopCount = 0;
            while (loanAmount != loanAmountShown)
            {
                loanAmountShown = GetLoanAmountShown();
                if (loopCount >= 5)
                {
                    LoopError = true;
                    //Attempting to do a bit of a cheese and change the slider to a number (As changing it to number manually works fine)
                    //Unfortunately I could get it to work
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("document.getElementsByClassName('.loan-amount__range-slider__input input').type = 'number'");
                    slider = LoanAmountElement.FindElement(By.CssSelector(".loan-amount__range-slider__input"));
                    slider.SendKeys(loanAmount.ToString());
                    break;
                }

                //Needs Investigating as to why it can only move to £350?

                if (loanAmount < loanAmountShown)
                {

                    moveSlider.DragAndDropToOffset(slider, -1, 0).Build().Perform();

                }
                else if (loanAmount > loanAmountShown)
                {
                    moveSlider.DragAndDropToOffset(slider, 1, 0).Build().Perform();
                }
                loopCount++;
            }

            return LoopError;
        }

        public int GetLoanAmountShown()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible((By.CssSelector(".loan-amount__header__amount"))));
            IWebElement amount = LoanAmountElement.FindElement(By.CssSelector(".loan-amount__header__amount"));
            Console.WriteLine(amount.Text.Substring(1));
            return int.Parse(amount.Text.Substring(1));
        }

        public String GetTotalRepaymentAmount()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible((By.CssSelector(".loan-summary__column__amount__value"))));
            String totalAmountRepayable = TotalsElement.FindElement(By.CssSelector("div:nth-child(3)")).Text.Trim();
            String digitValue = totalAmountRepayable.Substring(1, 6);
            return float.Parse(digitValue).ToString ("0.00");
        }

        public void SetRepaymentDay(String day)
        {
            ReadOnlyCollection<IWebElement> dates = RepaymentCalenderElement.FindElement(By.CssSelector(".date-selector")).FindElements(By.CssSelector("span"));
            foreach (IWebElement date in dates)
            {
                if(date.Text == day)
                {
                    date.Click();
                    break;
                }
            }
        }

        public String GetActualRepaymentDay()
        {
            return RepaymentCalenderElement.FindElement(By.CssSelector(".loan-schedule__tab__panel__detail .loan-schedule__tab__panel__detail__tag__text")).Text;
        }

    }
}
