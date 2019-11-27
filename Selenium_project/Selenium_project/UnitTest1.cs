using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_project
{
    [TestFixture]
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver();
        [OneTimeSetUp]
        public void LoadDriver()
        {
            driver.Navigate().GoToUrl("https://10.171.91.29:9669/");
            driver.Manage().Window.Maximize();
            Console.WriteLine("SetUp Finished Successfully");
        }

        [Test, Order(1)]
        public void VerifyWindow()
        {
            //driver.Quit();
            try
            {
                String url = driver.Url;
                if (url != null)
                {
                    Console.WriteLine("Browser is opened");
                }
                else
                {
                    Console.WriteLine("Browser is closed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("exception");
            } 
        }


        [Test, Order(2)]
        public void Login()
        {
            IWebElement Username = driver.FindElement(By.Id("userNameInput"));
            Username.SendKeys("root");
            IWebElement Pass = driver.FindElement(By.Id("passwordInput"));
            Pass.SendKeys("Zertodata1!");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(2000);
            Console.WriteLine("Login test Finished Successfully");
        }

        [Test, Order(3)]
        public void Logout()
        {
            driver.FindElement(By.XPath("//md-icon[@md-svg-src='assets/header/menu.svg']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@aria-label='Log Out']")).Click();
            Thread.Sleep(1000);
            Console.WriteLine("Logout test Finished Successfully");
        }

        [Test, Order(4)]
        public void CheckFolBtn()
        {
            Login();
            Thread.Sleep(2000);
            IWebElement FolBtn = driver.FindElement(By.XPath("//button[@ng-click='vm.showFailoverLiveWizard()']"));

            //FolBtn element has an attribute: disabled="disabled", it actually returns true instead of string to GetAttribute function
            string attr = FolBtn.GetAttribute("disabled");
            if (attr == "true")
            {
                Console.WriteLine("Failover button is disabled");
            }

            else 
            {
                FolBtn.Click();
                Thread.Sleep(3000);
                Console.WriteLine("Failover button is enabled");
            }
        }


        [OneTimeTearDown]
        public void UnloadDriver()
        {
            driver.Quit();
            Console.WriteLine("TearDown Finished Successfully");
        }

    }
        
}
