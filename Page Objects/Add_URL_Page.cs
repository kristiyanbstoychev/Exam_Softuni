using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_test_Exam_Prep.Page_Objects
{
    class Add_URL_Page:BasePage
    {
        public Add_URL_Page(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
                    "https://shorturl.kishy.repl.co/add-url";

        public IWebElement inputURLField =>
            driver.FindElement(By.XPath("//input[@class='url']"));
        public IWebElement inputCodeField =>
            driver.FindElement(By.XPath("//input[@class='code']"));

        public IWebElement buttonSubmit =>
            driver.FindElement(By.XPath("//button[@type='submit'][contains(.,'Create')]"));
        public IWebElement errorMSG =>
            driver.FindElement(By.XPath
                ("//div[@class='err'][contains(.,'URL cannot be empty!')]"));

    }
}
