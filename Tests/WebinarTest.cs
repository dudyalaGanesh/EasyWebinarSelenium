using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using SeleniumProject.Utilities;
using SeleniumProject.Pages;

namespace SeleniumProject.Tests
{
    public class WebinarTest
    {
        Webinar webinar = null;
        public void RunTest()
        {
            IWebDriver driver = null;
            try
            {
                var options = new ChromeOptions();
                options.AddArgument("start-maximized");

                driver = new ChromeDriver("./Drivers", options);
                webinar = new Webinar(driver);
                var user = CsvUtils.ReadUserData("AutoUserCSV.csv");

                // Construct dynamic URL
                string fullUrl = $"{Config.BaseUrl}?attendee_name={Uri.EscapeDataString(user.Name)}&attendee_email={Uri.EscapeDataString(user.Email)}";

                Console.WriteLine($"Navigating to: {fullUrl}");
                driver.Navigate().GoToUrl(fullUrl);
                ScreenshotHelper.CaptureScreenshot(driver, "Screenshots");
                Thread.Sleep(2000);
                ScreenshotHelper.CaptureScreenshot(driver, "Screenshots");
                //Verify title of the webinar
                VerifyTitle();
               // ScreenshotHelper.CaptureScreenshot(driver, "Screenshots");
                // click on attendee list
               // webinar.ClickOnPeople(Config.attendeesTitle);

                
                // Screenshot
                ScreenshotHelper.CaptureScreenshot(driver, "Screenshots");
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Exception: {ex.Message}");
            }
            finally
            {
                driver?.Quit();
            }
        }

        private void VerifyTitle()
        {
            try
            {
                string title = webinar.GetTitle(Config.webinarTitle);
                Console.WriteLine($"Page Title: {title}");

                //Assertion
                if (title.Contains("Selenium"))
                {
                    Console.WriteLine("Assertion Passed: Title contains 'Selenium'");
                }
                else
                {
                    Console.WriteLine("Assertion Failed: Title does not contain 'Selenium'");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Exception: {ex.Message}");
            }
        }
    }
}