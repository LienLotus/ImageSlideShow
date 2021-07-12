using System;
using OpenQA.Selenium;
using SeleniumProject.QATestCases.Extensions;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumImageSlideShow.PageObjects
{
    class ImagesSlideShow
    {
        public IWebDriver homeDriver;
        public ImagesSlideShow(IWebDriver driver)
        {
            homeDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='react_root']/div/div[1]/button[1]")]
        private IWebElement BackButton
        {
            get; set;
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='react_root']/div/div[1]/button[2]")]
        private IWebElement NextButton
        {
            get; set;
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='react_root']/div/div[1]/div/div")]
        private IWebElement Image
        {
            get; set;
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='react_root']/div/div[2]")]
        private IWebElement CurrenImageIndex
        {
            get; set;
        }

        public void GoToPreviousImage()
        {
            Console.WriteLine("++++++++Back to previous image++++++++");
            BackButton.ClickOnIt("BackButton");
        }

        public void GoToNextImage()
        {
            Console.WriteLine("++++++++Next image++++++++");
            NextButton.ClickOnIt("NextButton");
        }

        public int GetTotalImage()
        {
            return Image.FindElements(By.TagName("img")).Count;
        }

        public string GetCurrentImageIndex()
        {
            return CurrenImageIndex.Text;
        }
    }
}
