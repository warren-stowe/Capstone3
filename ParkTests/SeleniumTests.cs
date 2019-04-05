using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace ParkTests
{
    [TestClass]
    public class SeleniumTests
    {
        private static IWebDriver webDriver;
        private int SlowDownOne { get; set; } = 1000;
        private int SlowDownTwo { get; set; } = 2000;
      
    
        [TestInitialize]
        public void TestInit()
        {
            webDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            webDriver.Navigate().GoToUrl(Helper.URL);
        }

        [TestCleanup]
        public void CleanUp()
        {
            webDriver.Close();
        }

        [TestMethod]
        public void single_elements_can_be_found_by_class_name()
        {
            IWebElement parkList = webDriver.FindElement(By.Id("x1"));
            IWebElement image = webDriver.FindElement(By.ClassName("image"));
            IWebElement park = webDriver.FindElement(By.ClassName("image"));
            IWebElement description = webDriver.FindElement(By.ClassName("description"));
            Assert.IsNotNull(parkList);
            Assert.IsNotNull(park);
            Assert.IsNotNull(image); 
            Assert.IsNotNull(description); 
        }

        [TestMethod]
        public void pages_can_be_navigated_by_clicking_on_links()
        {
            // selecting and clicking on image, taking us to detail page
            Thread.Sleep(SlowDownTwo);
            IWebElement parkLink = webDriver.FindElement(By.XPath("//*[@id=\"x1\"]/div[1]/a/img"));
            parkLink.Click();
            Thread.Sleep(SlowDownTwo);

            Assert.IsNotNull(parkLink);
            IWebElement detailH2 = webDriver.FindElement(By.TagName("h2"));
            Assert.AreEqual("Detail", detailH2.Text);

            // on detail page scrolling down to quick facts
            IWebElement scrollToFacts = webDriver.FindElement(By.ClassName("facts-headline"));
            Actions scrollDown = new Actions(webDriver);
            scrollDown.MoveToElement(scrollToFacts);
            scrollDown.Perform();
            Thread.Sleep(SlowDownTwo);

            Assert.AreEqual("Quick Facts", scrollToFacts.Text);

            // scrolling down to weather from quick facts
            IWebElement scrollToWeather = webDriver.FindElement(By.ClassName("tile-weather-small"));
            scrollDown.MoveToElement(scrollToWeather);
            scrollDown.Perform();
            Thread.Sleep(SlowDownTwo);

            // going back to home from button home in nav bar
            IWebElement homeLink = webDriver.FindElement(By.XPath("/html/body/nav/div/div[2]/ul/li[1]/a"));
            homeLink.Click();
            Thread.Sleep(SlowDownTwo);

            // going to survey from home via survey button in nav bar
            IWebElement surveyLink = webDriver.FindElement(By.XPath("/html/body/nav/div/div[2]/ul/li[2]/a"));
            surveyLink.Click();
            Thread.Sleep(SlowDownTwo);

            // enter email in survey
            IWebElement surveyEmail = webDriver.FindElement(By.XPath("//*[@id=\"email\"]"));
            surveyEmail.SendKeys("JohnSmith@yahoo.net");
            Thread.Sleep(SlowDownTwo);

            // clicking on park drop down
            IWebElement parkDrop = webDriver.FindElement(By.XPath("//*[@id=\"park-selection\"]"));
            parkDrop.Click();
            Thread.Sleep(SlowDownOne);

            // selecting park from dropdown
            SelectElement parkSelection = new SelectElement(webDriver.FindElement(By.Id("park-selection")));
            parkSelection.SelectByText("Glacier National Park");
            Thread.Sleep(SlowDownOne);

            // clicking on state dropdown
            IWebElement residenceDrop = webDriver.FindElement(By.XPath("//*[@id=\"state-selection\"]"));
            residenceDrop.Click();
            Thread.Sleep(SlowDownOne);

            // selecting state from dropdown
            SelectElement residenceSelection = new SelectElement(webDriver.FindElement(By.Id("state-selection")));
            residenceSelection.SelectByText("Pennsylvania");
            Thread.Sleep(SlowDownTwo);

            // Assert - testing dropdown for activity level
            List<string> activityDropDown = new List<string>() { "Inactive", "Sedentary", "Active", "Extremely Active" };
            IList<IWebElement> activityDropDownList = webDriver.FindElements(By.CssSelector("#activity-selection"));
            foreach (IWebElement i in activityDropDownList)
            {
                foreach(string s in activityDropDown)
                {
                    Assert.AreEqual(true, i.Text.Contains(s));
                }
            }

            // clicking on activity dropdown
            IWebElement activityDrop = webDriver.FindElement(By.XPath("//*[@id=\"activity-selection\"]"));
            activityDrop.Click();
            Thread.Sleep(SlowDownOne);

            // selecting activity level from dropdown
            SelectElement activitySelection = new SelectElement(webDriver.FindElement(By.Id("activity-selection")));
            activitySelection.SelectByText("Extremely Active");
            Thread.Sleep(SlowDownTwo);

            // clicking submit button, going to surveyResults page
            IWebElement submitButton = webDriver.FindElement(By.ClassName("submit-button"));
            submitButton.Click();
            Thread.Sleep(SlowDownTwo);

            // going to home page again from surveyResults page via home button in nav bar
            IWebElement homeLinkReturn = webDriver.FindElement(By.XPath("/html/body/nav/div/div[2]/ul/li[1]/a"));
            homeLinkReturn.Click();
            Thread.Sleep(SlowDownTwo);

            // navigating to google.com 
            webDriver.Navigate().GoToUrl("http://google.com");
            Thread.Sleep(SlowDownTwo);

            // going back to our site from google
            webDriver.Navigate().GoToUrl(Helper.URL);
            Thread.Sleep(SlowDownTwo);
        }
    }
}

