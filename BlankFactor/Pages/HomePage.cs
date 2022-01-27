using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlankFactor.Pages
{
    public class HomePage
    {
        #region Constants
        // <summary>
        /// Xpaths to Page elements
        /// </summary>
        private const string InsightsMenuXpath = "//*[@id='menu-item-4436']/a/span[1]";
        private const string BlogTitleXpath= "//*[@class='page-item__title'][contains(text(),'Blog')]";
        private const string Url = "https://blankfactor.com/";
        #endregion

        /// <summary>
        /// WebDriver
        /// </summary>
        #region Properties
        
        /// <summary>
        /// WebDriver
        /// </summary>
        public WebDriver driver { get; set; }

        /// <summary>
        /// Insights menu
        /// </summary>
        public IWebElement InsightsMenu
        {
            get
            {
                return driver.FindElement(By.XPath(InsightsMenuXpath));
            }
        }

        /// <summary>
        /// Blog Title
        /// </summary>
        public IWebElement BlogTitle
        {
            get
            {
                return driver.FindElement(By.XPath(BlogTitleXpath));
            }
        }

        #endregion
        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">webdriver to interact with the browser</param>
        public HomePage(WebDriver driver)
        {
            this.driver = driver;
        }
        #endregion


        #region Methods

        /// <summary>
        /// Navigate to the  HomePage
        /// </summary>
        public void Navigate()
        {
            driver.Manage().Window.Maximize();
            driver.Url = Url;

        }
        #endregion

    }
}
