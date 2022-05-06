using NUnit.Framework;
using ReleaseToWaterScenario.PageObjects;
using ReleaseToWaterScenario.Utilities;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ReleaseToWaterScenario.StepDefinitions
{
    [Binding]
    public class ReleaseToWaterSteps

    {
        ReleaseToWaterPage releaseToWaterPage;

        public ReleaseToWaterSteps()
        {
            releaseToWaterPage = new ReleaseToWaterPage();
        }

        [Given(@"I navigate to the website ""(.*)""")]
        public void GivenINavigateToTheWebsite(string url)
        {
            releaseToWaterPage.Navigate(url);
        }
        
        [Given(@"I enter the username and password as ""(.*)"" and ""(.*)""")]
        public void GivenIEnterTheUsernameAndPasswordAsAnd(string username, string password)
        {
            releaseToWaterPage.EnterUsernameIntoTxtBox(username);
            releaseToWaterPage.EnterPasswordIntoPassBox(password);
        }
        
        [When(@"I click on login button")]
        public void WhenIClickOnLoginButton()
        {
            releaseToWaterPage.ClickOnLoginbttn();
        }
        
        [When(@"I click on Module")]
        public void WhenIClickOnModule()
        {
            releaseToWaterPage.ClickOnModules();
        }
        
        [When(@"I select Enviroment")]
        public void WhenISelectEnviroment()
        {
            releaseToWaterPage.SelectOnEnviroment();
        }
        
        [When(@"I click on Release To Water")]
        public void WhenIClickOnReleaseToWater()
        {
            releaseToWaterPage.ClickOnReleaseToWater();
        }
        
        [When(@"I click on New Record")]
        public void WhenIClickOnNewRecord()
        {
            releaseToWaterPage.ClickOnNewRecord();
        }

        [When(@"I enter the Description and Sample date")]
        public void WhenIEnterTheDescriptionAndSampleDate(Table table)
        {
            var tableData = table.CreateInstance<DataInput>();
            releaseToWaterPage.EnterTextIntoDescriptionField(tableData.description);
            releaseToWaterPage.SelectDateIntoDateField(tableData.sampleDate);
        }
        [When(@"I click on Save and Close button")]
        public void WhenIClickOnSaveAndCloseButton()
        {
            releaseToWaterPage.ClickOnSaveAndCLoseBttn();
        }

       
        [Then(@"the page title ""(.*)"" page is displayed")]
        public void ThenThePageTitlePageIsDisplayed(string expTitle)
        {
            
            Assert.AreEqual(expTitle, releaseToWaterPage.GetPageTitle());
        
        }

        [When(@"I click on Cog setting icon of the first record in the manage records")]
        public void WhenIClickOnCogSettingIconOfTheFirstRecordInTheManageRecords()
        {
            releaseToWaterPage.ClickOnCogManageIcon();
        }

        [When(@"I click on cog delete icon")]
        public void WhenIClickOnCogDeleteIcon()
        {
            releaseToWaterPage.ClickOnDeleteIcon();
        }

        [Then(@"the first record is deleted from the page")]
        public void ThenTheFirstRecordIsDeletedFromThePage()
        {
           Assert.IsTrue(releaseToWaterPage.ThenTheFirstRecordIsDeleted());
            

        }

        [Then(@"the second record is displayed on the page")]
        public void ThenTheSecondRecordIsDisplayedOnThePage()
        {
            Assert.IsTrue(releaseToWaterPage.ThenTheSecondRecordIsDisplayed());
        }


        [When(@"I click on the user dropdown menu at the top of the page")]
        public void WhenIClickOnTheUserDropdownMenuAtTheTopOfThePage()
        {
            releaseToWaterPage.ClickUserDropDown();
        }

        [When(@"I click on logout")]
        public void WhenIClickOnLogout()
        {
            releaseToWaterPage.ClickLogoutButton();
        }

        [Then(@"I am logged out")]
        public void ThenIAmLoggedOut()
        {
            Assert.IsTrue(releaseToWaterPage.ThenTheLogoIsDisplayed());
        }

        [Then(@"a pop up message with ""(.*)"" is displayed on the logout page")]
        public void ThenAPopUpMessageWithIsDisplayedOnTheLogoutPage(string expectedText)
        {
            Assert.AreEqual(expectedText,releaseToWaterPage.GetTheLogoutMessageText());
        }

    }
}
