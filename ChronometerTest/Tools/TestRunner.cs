using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;

namespace ChronometerTest.Tools
{
    [TestFixture]
    public abstract class TestRunner
    {
        

        public void TestSetup() {
            AppiumDriver<AndroidElement> driver;
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.App, @"C:\Users\HP DV2 - 1030us\AndroidStudioProjects\App\ApiDemos-debug.apk");
            capabilities.SetCapability(MobileCapabilityType.DeviceName, "j53gxx");
            capabilities.SetCapability(MobileCapabilityType.Udid, "33742dc5");
            capabilities.SetCapability(MobileCapabilityType.PlatformVersion, "6.0.1");
            capabilities.SetCapability(MobileCapabilityType.PlatformName, "Android");
            capabilities.SetCapability(MobileCapabilityType.FullReset, "false");

            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }


    }
}
