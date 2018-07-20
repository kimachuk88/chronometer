using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;

namespace ChronometerTest.Tools
{

    [TestFixture]
    public class TestRunner
    {
        public AppiumDriver<AndroidElement> driver;
        DesiredCapabilities capabilities = new DesiredCapabilities();

        [SetUp]
        public void TestSetup() {


            capabilities.SetCapability(MobileCapabilityType.App, @"D:\ApiDemos-debug.apk");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.Udid, "emulator-5554");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.0");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");

            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));

            //Locate testing app
            driver.Swipe(0, 0, 0, 300, 0);
            driver.FindElement(By.Id("Views")).Click();
            driver.FindElement(By.Id("Chronometer")).Click();
        }
        [TearDown]
        public void TestTearDown()
        {
            driver.CloseApp();
        } 



    }
}
