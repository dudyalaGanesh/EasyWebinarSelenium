using SeleniumProject.Tests;

namespace Program
{
    static class Webinar
    {
        static void Main(string[] args)
        {
            WebinarTest test = new WebinarTest();
            test.RunTest();
        }
    }
}