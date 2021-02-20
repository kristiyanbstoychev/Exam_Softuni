using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_test_Exam_Prep.Page_Objects
{
    public class BasePage
    {
        protected readonly IWebDriver driver;
        public virtual string PageUrl { get; }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public IWebElement LinkHomePage =>
            driver.FindElement(By.XPath("//a[@href='/'][contains(.,'Home')]"));

        public IWebElement LinkShortUrlsPage =>
            driver.FindElement(By.XPath("//a[@href='/urls'][contains(.,'Short URLs')]"));

        public IWebElement LinkAddURLPage =>
            driver.FindElement(By.XPath("//a[@href='/add-url'][contains(.,'Add URL')]"));

        public IWebElement ElementPageHeading =>
            driver.FindElement(By.XPath("/html/body/main/h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(this.PageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeadingText()
        {
            return ElementPageHeading.Text;
        }

    }
}
