using NUnit.Framework;
using Selenium_test_Exam_Prep.Page_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_test_Exam_Prep.Tests
{
    class HomePage_tests : Base_ShortURL_tests
    {
        [Test]
        public void Test_HomePage_Content()
        {
            var page = new HomePage(driver);
            page.Open();
            Assert.AreEqual("URL Shortener", page.GetPageTitle());
            Assert.AreEqual("URL Shortener", page.GetPageHeadingText());
            page.GetURLVisitsCount();
            Assert.Pass();
        }

        [Test]
        public void Test_HomePage_Links()
        {
            var homePage = new HomePage(driver);

            homePage.Open();
            homePage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            homePage.Open();
            homePage.LinkAddURLPage.Click();
            Assert.IsTrue(new Add_URL_Page(driver).IsOpen());

            homePage.Open();
            homePage.LinkShortUrlsPage.Click();
            Assert.IsTrue(new Short_URLs_Page(driver).IsOpen());
        }

    }
}
