using NUnit.Framework;
using Selenium_test_Exam_Prep.Page_Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium_test_Exam_Prep.Tests
{
    class Visit_NoN_Existing_URL : Base_ShortURL_tests
    {
        [Test]
        public void Test_Open_NoN_Existing_URL()
        {
            var errorPage = new Error_Page(driver);
            errorPage.errorURL = "asdf";
            errorPage.Open();

            Assert.AreEqual("Error", errorPage.GetPageTitle());
            Assert.AreEqual("Cannot navigate to given short URL", errorPage.GetPageHeadingText());
            Assert.IsTrue(errorPage.errorMSG.Displayed);
        }
    }
}
