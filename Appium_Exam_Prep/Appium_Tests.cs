using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Collections.ObjectModel;

namespace appium_tests
{
    class Appium_Tests
    {
        string USERNAME = "chrisstoychev1";
        string AUTOMATE_KEY = "19zjZpa8iEDxzwMMBx7x";
        string appAdress = "bs://9accccd130c3437d5194cf7e12ce117edffe9b20";
        string startActivity = "com.android.example.github.MainActivity";
        private AndroidDriver<AndroidElement> driver;
        


        [OneTimeSetUp]
        public void SetupRemoteServer()
        {

            AppiumOptions caps = new AppiumOptions();
            caps.PlatformName = "Android";
            caps.AddAdditionalCapability("browserstack.user", USERNAME);
            caps.AddAdditionalCapability("browserstack.key", AUTOMATE_KEY);
            //upload app at https://app-automate.browserstack.com/dashboard/v2/getting-started?source=%27home%27
            // to get the appAddress 
            caps.AddAdditionalCapability("app", appAdress);
            caps.AddAdditionalCapability("project", "First CSharp project");
            caps.AddAdditionalCapability("build", "CSharp Android");
            caps.AddAdditionalCapability("name", "first_test");
            caps.AddAdditionalCapability("device", "Google Pixel 3");
            caps.AddAdditionalCapability("os_version", "9.0");
            caps.AddAdditionalCapability("appActivity", startActivity);

             driver = new AndroidDriver<AndroidElement>(
                new Uri("http://hub.browserstack.com/wd/hub"), caps);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
        [Test]
        public void First_Test()
        {
            var inputField =
            driver.FindElement(By.Id("com.android.example.github:id/input"));
            inputField.SendKeys("Selenium");
            inputField.Click();
            driver.PressKeyCode(AndroidKeyCode.Enter);
            var seleniumField =
                driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout[1]/android.view.ViewGroup/android.widget.TextView[2]"));
            seleniumField.Click();
            var barancev = driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/androidx.recyclerview.widget.RecyclerView/android.widget.FrameLayout[2]/android.view.ViewGroup"));
            barancev.Click();
            var nameBarancev = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='user name']"));
            Assert.AreEqual("Alexei Barantsev", nameBarancev.Text);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}