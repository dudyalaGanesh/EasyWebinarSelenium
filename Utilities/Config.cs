using System.IO;
using Newtonsoft.Json.Linq;

namespace SeleniumProject.Utilities
{
    public static class Config
    {
        public static string BaseUrl = "https://dastalasta1.easywebinar.live/oneclick-registration-90";
        public static int DefaultWaitSeconds = 30;
        public static string ScreenshotFolder = "Screenshots";
        public static string webinarTitle = "//div[@class='ew-event-details']/h3";

        public static string attendeeList = "//li[contains(@class,'flex') and contains(@class,'hide-on-mobile')]/a/span[contains(normalize-space(.), 'People')]";

        public static string attendeesTitle = "//*[@id='accordion__heading-b']";
        
        

    }
}