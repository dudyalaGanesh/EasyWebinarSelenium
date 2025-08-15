using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Utilities;
using NUnit.Framework;

namespace SeleniumProject.Pages
{
    public class Webinar
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public Webinar(IWebDriver webDriver)
        {
            driver = webDriver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.DefaultWaitSeconds));
        }

        public string GetTitle(string xpath)
        {
            ElementHelper.WaitForElementByXPath(driver, xpath);
            return ElementHelper.GetTextByXPath(driver, xpath);
        }

        public bool ClickOnPeople(string xpath)
        {
            ElementHelper.ClickByXPath(driver, xpath);

            var actualTitle = ElementHelper.GetTextByXPath(driver, Config.attendeesTitle);
            string expectedTitle = "Attendees (";
            if (expectedTitle == actualTitle)
                Console.WriteLine($"Webinar title match. Expected: '{expectedTitle}' but got: '{actualTitle}'.");
            else
                Console.WriteLine($"Webinar title mismatch. Expected: '{expectedTitle}' but got: '{actualTitle}'.");

            return true;
        }


        /*  public List<string> GetAttendeelist()
         {
             ElementHelper.WaitForElementByXPath(driver, attendeeList);

         }
  */
    }
}