using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRePORT_PingTest.Common
{
    public class CommonMethods
    {
        private static bool isloggedIn = false;
        public static void CaptureScreenshot(IWebDriver driver)
        {
            var wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
            // wait.Until(driver.FindElement(By.Id("knownElementId")).Displayed);           

            string scrshotpath = ConfigurationManager.AppSettings["screenshotpath"];
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            try
            {
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
                screenshot.SaveAsFile(scrshotpath + "iRePORT_" + timestamp + ".png");
            }
            catch (Exception)
            {

                throw;
            }                                                 
        }

        public static void GetURL(IWebDriver driver)
        {
            try
            {
                var appurl = ConfigurationManager.AppSettings["iRePORTURL"];
                driver.Navigate().GoToUrl(appurl);
                driver.Manage().Window.Maximize();
                Console.WriteLine("Browser Opened");
                System.Threading.Thread.Sleep(15000);
            }
            catch (NoSuchElementException)
            {

            }
        }
        public static void cleanup(IWebDriver driver)
        {
            driver.Quit();
          
        }
    }
}
