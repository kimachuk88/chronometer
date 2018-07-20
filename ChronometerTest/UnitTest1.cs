
using System.Threading;
using NUnit.Framework;
using ChronometerTest.Tools;
using OpenQA.Selenium;

namespace ChronometerTest
{

    [TestFixture]
    public class UnitTest1 : TestRunner
    {
        

        [Test]
        public void StartButtonTest()
        {
            Thread.Sleep(5000);
            
            //Read chronometer before start
            string start = driver.FindElement(By.Id("io.appium.android.apis:id/chronometer")).Text;
            

            //Click Start
            driver.FindElement(By.Id("io.appium.android.apis:id/start")).Click();
            Thread.Sleep(2000);

            //Click stop chronometer
            driver.FindElement(By.Id("io.appium.android.apis:id/stop")).Click();

            //Read chronometer 5 sec after start
            string finish = driver.FindElement(By.Id("io.appium.android.apis:id/chronometer")).Text;

            //Reset chronometer
            driver.FindElement(By.Id("io.appium.android.apis:id/reset")).Click();

            //Verify whether chronometer was working
            Assert.AreNotEqual(start, finish);
            Thread.Sleep(5000);
            
            //Exit app

        }

        [Test]
        public void StopButtonTest()
        {
            Thread.Sleep(5000);
            //Read chronometer before start and click Start
            string start = driver.FindElement(By.Id("io.appium.android.apis:id/chronometer")).Text;
            
            //Click Start
            driver.FindElement(By.Id("io.appium.android.apis:id/start")).Click();

            //2 sec wait
            Thread.Sleep(2000);

            //Click stop and read chronometer
            driver.FindElement(By.Id("io.appium.android.apis:id/stop")).Click();
            string finish = driver.FindElement(By.Id("io.appium.android.apis:id/chronometer")).Text;

            //Verify whether chronometer was working
            Assert.AreNotEqual(start, finish);

            //5 seconds wait and read chronometer to check if chronometer is stopped
            Thread.Sleep(2000);
            string delayed = driver.FindElement(By.Id("io.appium.android.apis:id/chronometer")).Text;

            //Reset chronometer
            driver.FindElement(By.Id("io.appium.android.apis:id/reset")).Click();

            //Compare chronometer reading after stop and 5 seconds later
            Assert.AreEqual(finish, delayed);
            
            //Exit app

        }

        [Test]
        public void ResetButtonTest()
        {
            Thread.Sleep(5000);
            //Read chronometer before start and click Start
            string start = driver.FindElement(By.Id("io.appium.android.apis:id/chronometer")).Text;
            driver.FindElement(By.Id("io.appium.android.apis:id/start")).Click();

            //2 sec wait
            Thread.Sleep(2000);

            //Click stop and reset
            driver.FindElement(By.Id("io.appium.android.apis:id/stop")).Click();
            driver.FindElement(By.Id("io.appium.android.apis:id/reset")).Click();

            //Get chronometer reading after stop and reset
            string afterReset = driver.FindElement(By.Id("io.appium.android.apis:id/chronometer")).Text;

            //Verify whether chronometer has the same redings as before start
            Assert.AreEqual(start, afterReset);

            //Exit app
            
        }
        [Test]
        public void SetFormatButtonTest()
        {
            Thread.Sleep(5000);
            
            //Click Start
            driver.FindElement(By.Id("io.appium.android.apis:id/start")).Click();
            

            //Click Set Format String button
            driver.FindElement(By.Id("Set format string")).Click();
            

            //Click stop 
            driver.FindElement(By.Id("io.appium.android.apis:id/stop")).Click();
            Thread.Sleep(5000);

            //Read chronometer
            string afterSetFormat = driver.FindElement(By.Id("io.appium.android.apis:id/chronometer")).Text;

            //Check whether chronometer contains text SetFormat String
            StringAssert.Contains("Formatted time",afterSetFormat,"Formatted time is not displayed");

            //Exit app
            
            
        }

        [Test]
        public void ClearFormatButtonTest()
        {
            Thread.Sleep(5000);
            //Click Start
            driver.FindElement(By.Id("io.appium.android.apis:id/start")).Click();

            //Click Clear Format String Button
            driver.FindElement(By.Id("Clear format string")).Click();

            //Click stop 
            driver.FindElement(By.Id("io.appium.android.apis:id/stop")).Click();

            //Read chronometer
            string afterClearFormat = driver.FindElement(By.Id("io.appium.android.apis:id/chronometer")).Text;

            //Count whether chronometer contains only 5 symbols 
            Assert.IsTrue(afterClearFormat.Length == 5,"00:00 is not displayed");

            //Exit app
            

        }

    }
    
}

