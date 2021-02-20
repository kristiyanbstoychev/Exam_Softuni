using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_test_Exam_Prep.Page_Objects
{
    class Error_Page : BasePage
    {
        public Error_Page(IWebDriver driver) : base(driver)
        {
        }
        public string errorURL;
        public override string PageUrl =>
                   "https://shorturl.kishy.repl.co/go/" + errorURL;

        public IWebElement errorMSG =>
            driver.FindElement(By.XPath
                ("//div[@class='err'][contains(.,'Invalid short code!')]"));

    }
}
