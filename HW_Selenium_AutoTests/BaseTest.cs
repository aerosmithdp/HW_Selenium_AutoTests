using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW_Selenium_AutoTests
{
    public class BaseTest : IDisposable
    {
        private IWebDriver _chrome;

        public void Dispose()
        {
            _chrome.Quit();
        }

        public IWebDriver StartDriverWithUrl(string url)
        {
            _chrome = new ChromeDriver();
            _chrome.Navigate().GoToUrl(url);
            _chrome.Manage().Window.Maximize();
            _chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            return _chrome;
        }
    }
}
