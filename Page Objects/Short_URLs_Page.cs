using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_test_Exam_Prep.Page_Objects
{
    class Short_URLs_Page:BasePage
    {
        public Short_URLs_Page(IWebDriver driver) : base(driver)
        {
        }
        public override string PageUrl =>
                    "https://shorturl.kishy.repl.co/urls";
        public IWebElement TableURLs =>
            driver.FindElement(By.XPath("/html/body/main/table"));
        public IWebElement TableOriginalURL =>
            driver.FindElement(By.XPath("//th[contains(.,'Original URL')]"));
        public IWebElement TableShortlURL =>
            driver.FindElement(By.XPath("//th[contains(.,'Short URL')]"));
        public IWebElement TableDateCreated =>
            driver.FindElement(By.XPath("//th[contains(.,'Date Created')]"));
        public IWebElement TableVisits =>
            driver.FindElement(By.XPath("//th[contains(.,'Visits')]"));
        public IWebElement shortURLnakov =>
            driver.FindElement(By.XPath
                ("//a[@class='shorturl'][contains(.,'http://shorturl.kishy.repl.co/go/nak')]"));
        public IWebElement TableVisitsCountNakov =>
            driver.FindElement(By.XPath("/html/body/main/table/tbody/tr[2]/td[4]"));

        public int GetURLVisitsCount()
        {
            string visitsCount = this.TableVisitsCountNakov.Text;
            return int.Parse(visitsCount);
        }

        public Boolean isTableContainsText(IWebElement table, String text)
        {
            if (table.Text.Contains(text))
            {
                return true;
            }
            return false;
        }


    }
}
