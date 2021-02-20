using OpenQA.Selenium;
using System;

namespace Selenium_test_Exam_Prep.Page_Objects
{
    class HomePage:BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl =>
            "https://shorturl.kishy.repl.co/";

        public IWebElement ElementShortURLsCount =>
            driver.FindElement(By.XPath("//li[contains(.,'Short URLs: 3')]"));

        public IWebElement ElementURLVisitorsCount =>
            driver.FindElement(By.XPath("/html/body/main/ul/li[2]/b"));


        public int GetURLsCount()
        {
            string studentsCountText = this.ElementShortURLsCount.Text;
            return int.Parse(studentsCountText);
        }

        public int GetURLVisitsCount()
        {
            string visitsCount = this.ElementURLVisitorsCount.Text;
            return int.Parse(visitsCount);
        }


    }
}
