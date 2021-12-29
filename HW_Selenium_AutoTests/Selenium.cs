using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Xunit;

namespace HW_Selenium_AutoTests
{
    public class Selenium : BaseTest
    {
        IWebDriver chrome;

        [Fact]
        public void Test1DouCheckSearch()
        {
            chrome = StartDriverWithUrl("https://dou.ua/");
            IWebElement element = chrome.FindElement(By.Id("txtGlobalSearch"));
            element.SendKeys("Ä³ÿ City");
            element.SendKeys(Keys.Enter);
            IWebElement elements = chrome.FindElement(By.LinkText("Îáñóæäåíèÿ ïî òåìå «Ä³ÿ.Ñ³ò³» | DOU"));
            elements.Click();
            string actual = chrome.FindElement(By.LinkText("Îáñóæäåíèÿ ïî òåìå «Ä³ÿ.Ñ³ò³» | DOU")).GetAttribute("href");
            Assert.Equal("https://dou.ua/forums/tags/%D0%94%D1%96%D1%8F.%D0%A1%D1%96%D1%82%D1%96/", actual);
        }

        [Fact]
        public void Test2DouCheckFirstJob()
        {
            chrome = StartDriverWithUrl("https://dou.ua/");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/first-job/?from=doufp']"));
            element.Click();
            IWebElement elements = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/first-job/?city=dnipro']"));
            elements.Click();
            string actual = chrome.Url;
            Assert.Equal("https://jobs.dou.ua/first-job/?city=dnipro", actual);
        }

        [Fact]
        public void Test3DouCheckCarrerIT()
        {
            chrome = StartDriverWithUrl("https://dou.ua/");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://dou.ua/lenta/tags/%D0%9A%D0%B0%D1%80%D1%8C%D0%B5%D1%80%D0%B0%20%D0%B2%20IT/?from=doufp']"));
            element.Click();
            string actual = chrome.Url;
            Assert.Equal("https://dou.ua/lenta/tags/%D0%9A%D0%B0%D1%80%D1%8C%D0%B5%D1%80%D0%B0%20%D0%B2%20IT/?from=doufp", actual);
        }

        [Fact]
        public void Test4DouCheckTop50()
        {
            chrome = StartDriverWithUrl("https://dou.ua/");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://dou.ua/lenta/articles/top-50-summer-2021/?from=doufp']"));
            element.Click();
            IWebElement elements = chrome.FindElement(By.XPath("//a[contains(text(),'EPAM Ukraine')]"));
            elements.Click();
            string actual = chrome.FindElement(By.LinkText("EPAM Ukraine")).GetAttribute("href");
            Assert.Equal("https://jobs.dou.ua/companies/epam-systems/", actual);
        }

        [Fact]
        public void Test5DouCheckSalaries()
        {
            chrome = StartDriverWithUrl("https://dou.ua/");
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
        }

        [Fact]
        public void Test6DouCheckWork()
        {
            chrome = StartDriverWithUrl("https://dou.ua/");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/']"));
            element.Click();
            IWebElement elementCategory = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/vacancies/?category=QA']"));
            elementCategory.Click();
            IWebElement elementExperience = chrome.FindElement(By.XPath("//*[contains(text(),'1…3 ðîêè')]"));
            elementExperience.Click();
            IWebElement elementCity = chrome.FindElement(By.LinkText("Äí³ïðî"));
            elementCity.Click();
            string actual = chrome.Url;
            Assert.Equal("https://jobs.dou.ua/vacancies/?city=%D0%94%D0%BD%D1%96%D0%BF%D1%80%D0%BE&category=QA&exp=1-3", actual);
        }

        [Fact]
        public void Test7DouCheckRatings()
        {
            chrome = StartDriverWithUrl("https://dou.ua/");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://jobs.dou.ua/ratings/?from=doufp']"));
            element.Click();
            IWebElement elementCity = chrome.FindElement(By.CssSelector("option[value='/ratings/Äíåïð/']"));
            elementCity.Click();
            IWebElement elementExperience = chrome.FindElement(By.XPath("//*[contains(text(),'Óìîâè ïðàö³')]"));
            elementExperience.Click();
            string actual = chrome.Url;
            Assert.Equal("https://jobs.dou.ua/ratings/%D0%94%D0%BD%D0%B5%D0%BF%D1%80/?order=2", actual);
        }

        [Fact]
        public void Test8DouCheckForum()
        {
            chrome = StartDriverWithUrl("https://dou.ua/");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://dou.ua/forums/']"));
            element.Click();
            IWebElement elementSelect = chrome.FindElement(By.Name("topic"));
            elementSelect.Click();
            IWebElement elementChoice = chrome.FindElement(By.CssSelector("option[value='https://dou.ua/forums/news/']"));
            elementChoice.Click();
            string actual = chrome.Url;
            Assert.Equal("https://dou.ua/forums/news/", actual);
        }

        [Fact]
        public void Test9ChangeLanguage()
        {
            chrome = StartDriverWithUrl("https://dou.ua/");
            IWebElement elementSwitchLangEn = chrome.FindElement(By.CssSelector("a[href='?switch_lang=en']"));
            elementSwitchLangEn.Click();
            string actual = chrome.FindElement(By.LinkText("employers")).GetAttribute("href");
            Assert.Equal("https://jobs.dou.ua/ratings/?from=doufp", actual);
        }

        [Fact]
        public void Test10ÑalendarOfEvents()
        {
            chrome = StartDriverWithUrl("https://dou.ua/");
            IWebElement element = chrome.FindElement(By.CssSelector("a[href='https://dou.ua/calendar/']"));
            element.Click();
            IWebElement elementCity = chrome.FindElement(By.Name("city"));
            elementCity.Click();
            IWebElement elementChoiceCity = chrome.FindElement(By.CssSelector("option[value='https://dou.ua/calendar/city/%D0%94%D0%BD%D0%B5%D0%BF%D1%80/']"));
            elementChoiceCity.Click();
            IWebElement elementTag = chrome.FindElement(By.Name("tag"));
            elementTag.Click();
            for (int i = 0; i < 5; i++)
            {
                elementTag.SendKeys(Keys.ArrowDown);
            }
            elementTag.SendKeys(Keys.Enter);
            string actual = chrome.Url;
            Assert.Equal("https://dou.ua/calendar/tags/QA/%D0%94%D0%BD%D0%B5%D0%BF%D1%80/", actual);
        }

        
    }

}

