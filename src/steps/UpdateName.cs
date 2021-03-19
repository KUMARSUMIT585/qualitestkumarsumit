using TechTalk.SpecFlow;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ReportingLibrary;
using sampletest.WebAppUtilities;
using System.Configuration;


namespace sampletest.steps.tshirtorder
{
    [Binding]
    public class UpdateName
    {
        ExtentReportsHelper extent1 = new ExtentReportsHelper();
        WebUtilities webutil = new WebUtilities();
        JsonReader json = new JsonReader();//for test data reader

        [Given(@"user is loggged in to the Shopping Portal already")]
        public void GivenPrecondition1()
        {
            extent1.CreateTest("To validate Personal Information Update scenario end to end");
            webutil.LaunchApp(ConfigurationManager.AppSettings["BaseUrl"]);
            webutil.login("sumitkumar.wipro.sk@gmail.com","PRACTICE");
                
            extent1.SetStepStatusPass("GIVEN user is loggged in to the Shopping Portal already");
        }

        [When(@"the user clicks on the Name and updates first name")]
        public void WhenAction1()
        {
            try
            {
                webutil.selectTshirts();
                extent1.SetStepStatusPass("WHEN the user clicks on the Name and updates first name");

            }
            catch (Exception e)
            {
                Console.WriteLine("Handled excpetion -" + e.ToString());
                extent1.SetStepStatusFail("WHEN the user clicks on the Name and updates first name");

            }
        }

        [Then(@"user should be able to see the updated name in account details")]
        public void ThenTestableOutcome1()
        {
            try
            {
                

                string expectedTitle = json.GetTestDataValue(1, "ExpectedPageTitle");
                bool result1 = webutil.ValidatePageTitle(expectedTitle);
                if (result1 == true)
                {
                    extent1.SetStepStatusPass("THEN user should be able to see the updated name in account details");
                    extent1.SetTestStatusPass();
                }
                else
                {
                    extent1.SetStepStatusFail("THEN user should be able to see the updated name in account details");
                    
                }
                extent1.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("The exception handled -" + e.ToString());
            }
        }
    }
}