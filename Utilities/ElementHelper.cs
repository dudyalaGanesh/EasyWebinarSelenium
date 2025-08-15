using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumProject.Utilities;

namespace SeleniumProject.Utilities
{
    public static class ElementHelper
    {
        /// <summary>
        /// Waits for an element by XPath and returns its text.
        /// </summary>
        public static string GetTextByXPath(IWebDriver driver, string xpath)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.DefaultWaitSeconds));

            IWebElement element = wait.Until(drv =>
            {
                try
                {
                    var el = drv.FindElement(By.XPath(xpath));
                    return el.Displayed ? el : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });

            return element?.Text?.Trim() ?? string.Empty;
        }
        /// <summary>
        /// Waits for an element by XPath and returns its webelement.
        /// </summary>
        public static IWebElement GetElementByXPath(IWebDriver driver, string xpath)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.DefaultWaitSeconds));

            IWebElement element = wait.Until(drv =>
            {
                try
                {
                    var el = drv.FindElement(By.XPath(xpath));
                    return el.Displayed ? el : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });

            return element;
        }
        
        /// <summary>
        /// Waits for an element by XPath and returns the element.
        /// </summary>
        public static IWebElement WaitForElementByXPath(IWebDriver driver, string xpath)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.DefaultWaitSeconds));

            return wait.Until(drv =>
            {
                try
                {
                    var el = drv.FindElement(By.XPath(xpath));
                    return el.Displayed ? el : null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
            });
        }

        public static void ClickByXPath(IWebDriver driver, string xpath)
        {
            try
            {
                var element = GetElementByXPath(driver, xpath);
                element?.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Click failed for: {xpath} - {ex.Message}");
            }
        }

        public static bool IsDisplayedByXPath(IWebDriver driver, string xpath)
        {
            try
            {
                var element = GetElementByXPath(driver, xpath);
                return element != null && element.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsEnabledByXPath(IWebDriver driver, string xpath)
        {
            try
            {
                var element = GetElementByXPath(driver, xpath);
                return element != null && element.Enabled;
            }
            catch
            {
                return false;
            }
        }

        public static void SendKeysByXPath(IWebDriver driver, string xpath, string text)
        {
            try
            {
                var element = GetElementByXPath(driver, xpath);
                if (element != null)
                {
                    element.Clear();
                    element.SendKeys(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] SendKeys failed for: {xpath} - {ex.Message}");
            }
        }

        public static List<IWebElement> GetElementListByXPath(IWebDriver driver, string xpath)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Config.DefaultWaitSeconds));

            try
            {

                return wait.Until(drv =>
                {
                    var elements = drv.FindElements(By.XPath(xpath));
                    return elements.Count > 0 ? elements.ToList() : null;
                });
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"[ERROR] Timeout waiting for elements: {xpath}");
                return new List<IWebElement>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] GetElementsByXPath failed for: {xpath} - {ex.Message}");
                return new List<IWebElement>();
            }
        }
    }
}