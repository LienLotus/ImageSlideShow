using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using SeleniumImageSlideShow.PageObjects;
using System;

namespace SeleniumImageSlideShow
{
    public class ImageSlideShowTest
    {
        IWebDriver driver;
        ImagesSlideShow image;
        [SetUp]
        public void Setup()
        {
            driver = BrowserFactory.BrowserFactory.InitBrowser("chrome");
            image = new ImagesSlideShow(driver);
            driver.Url = ConfigurationManager.AppSettings["URL"];
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TotalImagesSrcTest()
        {
           
            string msg = "Error when validating total images";
            Console.WriteLine($"Total images:{image.GetTotalImage()}");
            Assert.AreEqual(image.GetTotalImage(), int.Parse(ConfigurationManager.AppSettings["ImageNumbers"]), msg);
        }

        [Test]
        public void IndexImagesTest()
        {
            for (int index = 1; index < image.GetTotalImage()+ 1; index++)
            {
                Assert.AreEqual(image.GetCurrentImageIndex(), $"{index} / {ConfigurationManager.AppSettings["ImageNumbers"]}");
                Console.WriteLine($"Current index: {image.GetCurrentImageIndex()}");
                image.GoToNextImage();
            }
            // Assert that max is 4 /4 images
            image.GoToNextImage();
            Assert.AreEqual(image.GetCurrentImageIndex(), $"{image.GetTotalImage()} / {image.GetTotalImage()}", "Found blank image added" );
        }
    }
}