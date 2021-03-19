using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
namespace sampletest.WebAppUtilities
{
    public class WebUtilities
    {
        //put this below info in the config manager
        private static IWebDriver driver;
        //string DriverName = "IE";//make this configurable
        String DriverName=ConfigurationManager.AppSettings["BrowserName"];//from app.config file
        String DriverPath=ConfigurationManager.AppSettings["DriverPath"];
        public IWebDriver SelectBrowserType()
        {
            switch (DriverName)
            {
                case "CHROME":
                    driver = new ChromeDriver(@DriverPath); //<-Add your path
                    //return driver;
                    break;

                case "IE":
                    driver = new InternetExplorerDriver(@DriverPath); //<-Add your path
                    //return driver;
                    break;
                
                case "FF":
                    driver= new FirefoxDriver();
                    break;

          }
            return driver;


        }
        public void LaunchApp(string url)
        {
            SelectBrowserType();
            driver.Navigate().GoToUrl(url);//we need to parameterize this later
            
        }
        /**
        method returns true if title is same as expected and false otherwiese
        */
        public bool ValidatePageTitle(string text)
        {
            string title = driver.Title;

            if (title.Equals(text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetPageTitle()
        {
            return driver.Title;

        }

        public void selectTshirts()
        {
            
            driver.FindElement(By.XPath("//*[@id='block_top_menu']/ul/li[3]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='center_column']/ul/li/div/div[1]/div/a[1]/img")).Click();
            driver.FindElement(By.XPath("//*[@id='add_to_cart']/button")).Click();
    
            driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a")).Click();



        }

        public void login(String name,String passsword)
        {
            driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[1]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys(name);
            driver.FindElement(By.XPath("//*[@id='passwd']")).SendKeys(passsword);
            driver.FindElement(By.XPath("//*[@id='SubmitLogin']/span")).Click();
            
        }

        

    }
}