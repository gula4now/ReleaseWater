using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ReleaseToWaterScenario.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReleaseToWaterScenario.PageObjects
{
    public class ReleaseToWaterPage
    {
        IWebDriver driver;
        Actions act;
       
        public ReleaseToWaterPage()
        {
            driver = BaseTest.driver;
        }

        private By userNameTxt = By.Id("username");
        private By passWordTxt = By.Id("password");
        private By loginBttn = By.XPath("//button[@id='login']");
        private By modules = By.XPath("//a[normalize-space()='Modules']");
        private By enviroment = By.XPath("//li[@class='she-has-submenu']//a[normalize-space()='Environment']");
        private By releaseToWater = By.XPath("//a[normalize-space()='Release To Water']");
        private By newRecordBttn = By.XPath("//a[normalize-space()='New Record']"); 
        private By saveAndCloseBttn = By.XPath("//button[normalize-space()='Save & Close']");
        private By cogIcon =By.XPath("//div[@class='item-box ui-selectable']/div[2]/child::div[3]/div[2]");
        private By listOfAllCogElements = By.XPath("//body[1]/div[1]/div[3]/section[1]/div[4]/div[2]/div[3]/div[2]/ul[1]/li");                               
        private By confirmDeleteBttn = By.XPath("//button[normalize-space()='Confirm']");
        private By secondRow = By.XPath("//div[@class='item-box ui-selectable']/div[2]"); 
        private By tableD = By.XPath("//div[@class='item-box ui-selectable']");
        private By firstRecordRefNo = By.XPath("//div[@class='item-box ui-selectable']/div[2]/child::div[1]/ul/li[1]/a"); //this is the 1st record reference No 
        private By secondRecordRefNo = By.XPath("//div[@class='item-box ui-selectable']/div[1]/child::div[1]/ul/li[1]/a");  // this is he 2nd record reference No
        private By userDropdownMenu = By.XPath("//div[@class='nav-user-name']");
        private By logout = By.XPath("//a[normalize-space()='Log Out']");
        private By popMessage = By.XPath("//div[@class='she-login-section']//div[1]");
        private By logo = By.XPath("//img[@title='SHE Assure']");
        IWebElement descriptionTxt => driver.FindElement(By.CssSelector("#SheReleaseToWater_Description"));
        IWebElement datetxtBox => driver.FindElement(By.XPath("//input[@id='SheReleaseToWater_SampleDate']"));

        public void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void EnterUsernameIntoTxtBox(string username)
        {
            driver.FindElement(userNameTxt).SendKeys(username);
        }
        
        public void EnterPasswordIntoPassBox(string password )
        {
            driver.FindElement(passWordTxt).SendKeys(password);
        }

        public void ClickOnLoginbttn()
        {
            driver.FindElement(loginBttn).Click();

        }
        public void ClickOnModules()
        {
            driver.FindElement(modules).Click();
        }

        public void SelectOnEnviroment()
        {
            act = new Actions(driver);
            IWebElement _enviroment = driver.FindElement(enviroment);
            act.MoveToElement(_enviroment);
        }
    
        public void ClickOnReleaseToWater()
        {
            IWebElement _releaseToWater = driver.FindElement(releaseToWater);
            act.MoveToElement(_releaseToWater).Click().Build().Perform();
        }
    
    public void ClickOnNewRecord()
        {
            driver.FindElement(newRecordBttn).Click();

        }

        public void EnterTextIntoDescriptionField(string description)
        { 
            descriptionTxt.SendKeys(description);
        }
        public void SelectDateIntoDateField(string sampleDate)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,650)", "");

            datetxtBox.Click();
            datetxtBox.SendKeys(sampleDate);
         }
     
        public void ClickOnSaveAndCLoseBttn()
        {
            driver.FindElement(saveAndCloseBttn).Click();
        }

        public string GetPageTitle()
        {
            return driver.Title;
         }

        public void ClickOnCogManageIcon()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");

            driver.FindElement(tableD).FindElements(secondRow);
            driver.FindElement(cogIcon).Click();

        }

        public void ClickOnDeleteIcon()
        {

         IList <IWebElement> allCogElements= driver.FindElements(listOfAllCogElements);

          foreach (IWebElement element in allCogElements)
            {
                if(element.Text.Equals("Delete"))
                {
                    element.Click();
                    break;
                }

               }

            driver.FindElement(confirmDeleteBttn).Click();  //this clicks is use to confirm the delete 

           }

        public bool ThenTheFirstRecordIsDeleted()
        {
            return driver.FindElement(firstRecordRefNo).Displayed;
         }
        public bool ThenTheSecondRecordIsDisplayed()
        {
            return driver.FindElement(secondRecordRefNo).Displayed;
        }

        public void ClickUserDropDown()
        {
            driver.FindElement(userDropdownMenu).Click();
        }

        public void ClickLogoutButton()
        {
            driver.FindElement(logout).Click();

            }
        public bool ThenTheLogoIsDisplayed()
        {
            return driver.FindElement(logo).Displayed;
        }

        public string GetTheLogoutMessageText()
        {
            return driver.FindElement(popMessage).Text;
        }

       


    }

}
