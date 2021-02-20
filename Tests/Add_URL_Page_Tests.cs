using NUnit.Framework;
using Selenium_test_Exam_Prep.Page_Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Selenium_test_Exam_Prep.Tests
{
    class Add_URL_Page_Tests : Base_ShortURL_tests
    {
        [Test]
        public void Test_ShortURLsPage_Tests_Content_and_Links()
        {
            var page = new Add_URL_Page(driver);
            var homePage = new HomePage(driver);

            page.Open();

            Assert.AreEqual("Add Short URL", page.GetPageTitle());
            Assert.AreEqual("Add Short URL", page.GetPageHeadingText());

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

        [Test]
        public void Add_URL_Tests_Valid_Data()
        {
            var page = new Add_URL_Page(driver);
            page.Open();
            page.inputURLField.SendKeys("https://www.memecenter.com/");
            page.inputCodeField.SendKeys("meme");
            page.buttonSubmit.Click();

            var shortUrlsPage = new Short_URLs_Page(driver);
            shortUrlsPage.Open();
            Assert.IsTrue(shortUrlsPage.isTableContainsText
                (shortUrlsPage.TableURLs, "https://www.memecenter.com/"));
            Assert.IsTrue(shortUrlsPage.isTableContainsText
                (shortUrlsPage.TableURLs, "meme"));
        }

        [Test]
        public void Add_URL_Tests_NoN_Valid_Data()
        {
            var page = new Add_URL_Page(driver);
            page.Open();
            
            page.inputCodeField.SendKeys("meme");
            page.buttonSubmit.Click();

            Thread.Sleep(500);
            Assert.IsTrue(page.errorMSG.Displayed);
        }
    }
}
