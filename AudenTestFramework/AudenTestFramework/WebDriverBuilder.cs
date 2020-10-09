using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace AudenTestFramework
{
    class WebDriverBuilder
    {
        //Builder method to allow for a default browser to be created
        public IWebDriver Build(BROWSER browser)
        {

           return BuildWithOptions(browser, null);
            
        }

        //Builder method to allwow for a browser to be created with any additional options. 
        //Such as maximised window or headless mode
        public IWebDriver BuildWithOptions(BROWSER browser, DriverOptions options)
        {
            switch (browser)
            {
                case BROWSER.Chrome:
                default:
                    if (options != null) { 
                    ChromeOptions co = (ChromeOptions)options;
                    return new ChromeDriver(co);
                    }
                    else
                    {
                        return new ChromeDriver();
                    }
            }
        }

    }


    //Enum to allow for the adding of additional browsers.
    //I added this so that errors in reusing the code would be minimal as new values have to be added here 
    public enum BROWSER
    {
        Chrome
    }

}
