using TechTalk.SpecFlow;
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ReportingLibrary;
using sampletest.WebAppUtilities;
using System.Configuration;


namespace sampletest.steps.webtests
{
    [Binding]
    public class TShirtOrder
    {
        ExtentReportsHelper extent1 = new ExtentReportsHelper();
        WebUtilities webutil = new WebUtilities();
        JsonReader json = new JsonReader();//for test data reader

        [Given(@"user is loggged in to the Shopping Portal")]
        public void GivenPrecondition2()
        {
            extent1.CreateTest("To validate Tshirt purchase scenario end to end");
            webutil.LaunchApp(ConfigurationManager.AppSettings["BaseUrl"]);
            webutil.login("sumitkumar.wipro.sk@gmail.com","PRACTICE");
                
            extent1.SetStepStatusPass("GIVEN user is loggged in to the Shopping Portal");
        }

        [When(@"the user searches tshirt & pays for it")]
        public void WhenAction2()
        {
            try
            {
                webutil.selectTshirts();
                extent1.SetStepStatusPass("WHEN the user searches tshirt & pays for it");

            }
            catch (Exception e)
            {
                Console.WriteLine("Handled excpetion -" + e.ToString());
                extent1.SetStepStatusFail("WHEN the user searches tshirt & pays for it");

            }
        }

        [Then(@"user should be able to see the order confirmation")]
        public void ThenTestableOutcome2()
        {
            try
            {
                

                string expectedTitle = json.GetTestDataValue(1, "ExpectedPageTitle");
                bool result1 = webutil.ValidatePageTitle(expectedTitle);
                if (result1 == true)
                {
                    extent1.SetStepStatusPass("THEN user should be able to see the order confirmation");
                    extent1.SetTestStatusPass();
                }
                else
                {
                    extent1.SetStepStatusFail("THEN user should be able to see the order confirmation");
                    
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