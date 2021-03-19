using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;
using System.Reflection;
using System.Configuration;
namespace ReportingLibrary
{
    public class ExtentReportsHelper
    {
        public ExtentReports extent { get; set; }
        public ExtentV3HtmlReporter reporter { get; set; }
        public ExtentTest test { get; set; }
        public ExtentReportsHelper()
        {
            //To create time stamp for unique report names 
            string day = DateTime.Today.ToString("dddd");  
            string year = DateTime.Now.Year.ToString("0000");  
            string month = DateTime.Now.Month.ToString("00");  
            string date = DateTime.Now.Day.ToString("00");  
            string hour = DateTime.Now.Hour.ToString("00");  
            string minute = DateTime.Now.Minute.ToString("00");  
            string second = DateTime.Now.Second.ToString("00"); 
            string timestamp2=hour+minute+second+"_"+date+month+"_"+year;
            //var timestamp = DateTime.Now.ToFileTime();//to get timestamp for unique file names each time
            //var timestamp1= DateTime.Now.Date+DateTime.Now.TimeOfDay;
            //reporter = new ExtentV3HtmlReporter(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Reports/ExtentReports.html"));
           
            extent = new ExtentReports();
            //have to change the path to relative one
            
            //reporter = new ExtentV3HtmlReporter("C:/Users/dtdev/csharp/csharp/sampletest/Reports/ExtentReports"+"_"+timestamp2+".html");
            //reporter.LoadConfig("C:/Users/dtdev/csharp/csharp/sampletest/Configs/extent-config.xml");
            reporter = new ExtentV3HtmlReporter(ConfigurationManager.AppSettings["ReportsPath"]+"/"+ConfigurationManager.AppSettings["AppUnderTest"]+"_"+timestamp2+".html");
            reporter.LoadConfig("C:\\Users\\dtdev\\vtaf\\Utilities\\Configs\\extent-config.xml");
            //sampletest\Utilities\Configs\extent-config.xml
           
            //below lines would have been needed in case we did not have seperate config file
            //reporter.Config.DocumentTitle = "Sample Automation Testing Report 1";
            //reporter.Config.ReportName = "Regression Testing Suite 1";
            //reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;//to set different themes
            

            //need to paramterize this below section as well
            extent.AttachReporter(reporter);
            extent.AddSystemInfo("App Under Test", ConfigurationManager.AppSettings["AppUnderTest"]);
            extent.AddSystemInfo("Environment", ConfigurationManager.AppSettings["Environment"]);
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            extent.AddSystemInfo("Browser",ConfigurationManager.AppSettings["BrowserName"]);
        }
        public void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }
    
        public void SetStepStatusPass(string stepDescription)
        {
            test.Log(Status.Pass, stepDescription);
        }
        
        public void SetStepStatusFail(string stepDescription)
        {
            test.Log(Status.Fail, stepDescription);
        }
        public void SetStepStatusWarning(string stepDescription)
        {
            test.Log(Status.Warning, stepDescription);
        }
        public void SetTestStatusPass()
        {
            test.Pass("Test Executed Sucessfully!");
        }
        public void SetTestStatusFail(string message = null)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            test.Fail(printMessage);
        }
        public void AddTestFailureScreenshot(string base64ScreenCapture)
        {
            test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
        }
        public void SetTestStatusSkipped()
        {
            test.Skip("Test skipped!");
        }
        public void Close()
        {
            try{
                extent.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine("The exception handled -"+e.StackTrace);
            }
            
        }
    }
}