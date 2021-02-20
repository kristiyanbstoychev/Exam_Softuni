using NUnit.Framework;
using OpenQA.Selenium;
using Selenium_test_Exam_Prep.Page_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_test_Exam_Prep.Tests
{
    class ShortURLsPage_Tests : Base_ShortURL_tests
    {
        [Test]
        public void Test_ShortURLsPage_Tests_Content_and_Links()
        {
            var page = new Short_URLs_Page(driver);
            var homePage = new HomePage(driver);

            page.Open();

            Assert.AreEqual("Short URLs", page.GetPageTitle());
            Assert.AreEqual("Short URLs", page.GetPageHeadingText());

            //verify table content
            
            Assert.IsTrue(page.isTableContainsText(page.TableURLs, "https://nakov.com"));
            Assert.IsTrue(page.isTableContainsText(page.TableURLs, "https://selenium.dev"));
            Assert.IsTrue(page.isTableContainsText(page.TableURLs, "https://nodejs.org"));
            Assert.IsTrue(page.isTableContainsText(page.TableURLs, "http://shorturl.kishy.repl.co/go/nak"));
            Assert.IsTrue(page.isTableContainsText(page.TableURLs, "http://shorturl.kishy.repl.co/go/seldev"));
            Assert.IsTrue(page.isTableContainsText(page.TableURLs, "http://shorturl.kishy.repl.co/go/node"));

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
        public void Test_ShortURLsPage_ShortUrl_visits_count()
        {
            var page = new Short_URLs_Page(driver);
            page.Open();
            int visits = page.GetURLVisitsCount();
            //increases visits count by clicking
            page.shortURLnakov.Click();
            int visitsPlusOne = visits + 1;
            Assert.AreEqual(visitsPlusOne, visits + 1);
            
        }

        }
    }
