using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using iRePORT_PingTest.Common;
using System.Configuration;
using iRePORT_PingTest.Pages;

namespace iRePORT_PingTest
{
    [Binding]
    [TestClass]
    public class Login_Main
    {
        public static IWebDriver Driver = new FirefoxDriver();
        public LoginPage loginPage = new LoginPage(Driver);

        [Given(@"I have navigated to the login screen")]
        public void GivenIHaveNavigatedToTheLoginScreen()
        {
            if (Driver.PageSource.Contains("Dashboard"))
            {
                Console.WriteLine("I am already logged in");
                return;
            }
            else
            {
                CommonMethods.GetURL(Driver);
                CommonMethods.CaptureScreenshot(Driver);                
            }
        }

        [Given(@"I enter the username and password")]
        public void GivenIEnterTheUsernameAndPassword()
        {
            loginPage.EnterUsernamePassword(ConfigurationManager.AppSettings["USER"].ToString(),
                    ConfigurationManager.AppSettings["PASSWORD"].ToString());
            CommonMethods.CaptureScreenshot(Driver);
            CommonMethods.CaptureScreenshot(Driver);
        }

        [When(@"I click Login button")]
        public void WhenIClickLoginButton()
        {

            loginPage.ClickLogin();
            CommonMethods.CaptureScreenshot(Driver);
        }

        [Then(@"I should see the dashboard")]
        public void ThenIShouldSeeTheDashboard()
        {                       
                Assert.AreEqual(true, Driver.PageSource.Contains("Dashboard"));
               // Console.WriteLine("PASS");                
            
            CommonMethods.CaptureScreenshot(Driver);
            CommonMethods.cleanup(Driver);
        }

    }
}
