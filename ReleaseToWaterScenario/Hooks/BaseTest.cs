using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ReleaseToWaterScenario.Hooks
{
    [Binding]
    public class BaseTest
    {
        public static IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            driver.Manage().Window.Maximize();
        } 

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
