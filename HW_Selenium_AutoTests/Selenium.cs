using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace HW_Selenium_AutoTests
{
    public class Selenium
    {

        [Fact]
        public void Test1Search()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://dou.ua/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.Id("txtGlobalSearch"));
            element.SendKeys("ƒ≥€ City");
            element.SendKeys(Keys.Enter);
            string actual = chrome.Url;
            Assert.Equal("https://dou.ua/search/?q=%D0%94%D1%96%D1%8F+City", actual);
            chrome.Quit();
        }

        [Fact]
        public void Test2FirstJob()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://dou.ua/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/first-job/?from=doufp']"));
            element.Click();
            IWebElement elements = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/first-job/?city=dnipro']"));
            elements.Click();
            string actual = chrome.Url;
            Assert.Equal("https://jobs.dou.ua/first-job/?city=dnipro", actual);
            chrome.Quit();
        }

        [Fact]
        public void Test3CarrerIT()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://dou.ua/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://dou.ua/lenta/tags/%D0%9A%D0%B0%D1%80%D1%8C%D0%B5%D1%80%D0%B0%20%D0%B2%20IT/?from=doufp']"));
            element.Click();
            string actual = chrome.Url;
            Assert.Equal("https://dou.ua/lenta/tags/%D0%9A%D0%B0%D1%80%D1%8C%D0%B5%D1%80%D0%B0%20%D0%B2%20IT/?from=doufp", actual);
            chrome.Quit();
        }

        [Fact]
        public void Test4Top50()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://dou.ua/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://dou.ua/lenta/articles/top-50-summer-2021/?from=doufp']"));
            element.Click();
            string actual = chrome.Url;
            Assert.Equal("https://dou.ua/lenta/articles/top-50-summer-2021/?from=doufp", actual);
            chrome.Quit();
        }

        [Fact]
        public void Test5Salaries()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://dou.ua/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/salaries/']"));
            element.Click();
            IWebElement elementCity = chrome.FindElement(By.CssSelector("option[value='Dnipro']"));
            elementCity.Click();
            IWebElement elementPosition = chrome.FindElement(By.XPath("//*[contains(text(),'Junior QA engineer')]"));
            elementPosition.Click();
            IWebElement elementSpecialization = chrome.FindElement(By.XPath("//*[contains(text(),'Automation QA')]"));
            elementSpecialization.Click();
            string actual = chrome.Url;
            Assert.Equal("https://jobs.dou.ua/salaries/#period=jun2021&city=Dnipro&title=Junior%20QA%20engineer&language=&spec=Automation%20QA&exp1=0&exp2=10", actual);
            chrome.Quit();
        }

        [Fact]
        public void Test6Work()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://dou.ua/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/']"));
            element.Click();
            IWebElement elementCategory = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/vacancies/?category=QA']"));
            elementCategory.Click();
            IWebElement elementExperience = chrome.FindElement(By.XPath("//*[contains(text(),'1Е3 роки')]"));
            elementExperience.Click();
            IWebElement elementCity = chrome.FindElement(By.XPath("//*[contains(text(),'ƒн≥про')]"));
            elementCity.Click();
            string actual = chrome.Url;
            Assert.Equal("https://jobs.dou.ua/vacancies/?city=%D0%94%D0%BD%D1%96%D0%BF%D1%80%D0%BE&category=QA&exp=1-3", actual);
            chrome.Quit();

        }

        [Fact]
        public void Test7Ratings()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://dou.ua/");
            chrome.Manage().Window.Maximize();
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/ratings/?from=doufp']"));
            element.Click();
            IWebElement elementCity = chrome.FindElement(By.CssSelector("option[value='/ratings/ƒнепр/']"));
            elementCity.Click();
            IWebElement elementExperience = chrome.FindElement(By.XPath("//*[contains(text(),'”мови прац≥')]"));
            elementExperience.Click();
            string actual = chrome.Url;
            Assert.Equal("https://jobs.dou.ua/ratings/%D0%94%D0%BD%D0%B5%D0%BF%D1%80/?order=2", actual);
            chrome.Quit();
        }

    }

}

