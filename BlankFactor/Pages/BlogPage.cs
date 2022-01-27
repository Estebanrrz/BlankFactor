using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlankFactor.Pages
{
    public class BlogPage
    {
        #region Constants

        // <summary>
        /// Xpaths to Page elements
        /// </summary>
        private const string LoadMoreButtonXpath = "//*[@class='btn btn-large btn-blue btn-blue-hover-blue-dark btn-load-more btn-load-more-posts']";
        private const string PostsTitlesXpath = "//*[@class='heading-4 post-title']/a";
        private const string ResultsXpath = "//*[@class='results']";
        private const string NewsLetterInputXpath = "//*[@class='form-group']/input";
        private const string SubscribeButtonXpath = "//*[@id='form-newsletter-blog-submit-btn']";

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">webdriver to interact with the browser</param>
        public BlogPage(WebDriver driver)
        {
            this.driver = driver;
        }
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
        /// Load More Button
        /// </summary>
        public IWebElement LoadMoreButton
        {
            get
            {
                WaitForElementToExist(LoadMoreButtonXpath);
                return driver.FindElement(By.XPath(LoadMoreButtonXpath));
            }
        }

        /// <summary>
        /// Blog Post on Current Page
        /// </summary>
        public List<IWebElement> BlogPostsPerPage
        {
            get
            {
                return driver.FindElements(By.XPath(PostsTitlesXpath)).ToList();
            }
        }

        /// <summary>
        /// Results Label
        /// </summary>
        public IWebElement Results
        {
            get
            {
                return driver.FindElement(By.XPath(ResultsXpath));
            }
        }

        /// <summary>
        /// Input email Newsletter
        /// </summary>
        public IWebElement InputEmailNewsLetter
        {
            get
            {
                return driver.FindElement(By.XPath(NewsLetterInputXpath));
            }
        }

        public IWebElement SubscribeButton
        {
            get 
            {
                return driver.FindElement(By.XPath(SubscribeButtonXpath));
            }
        
        }

        #endregion

        #region Methods
        /// <summary>
        /// Wait for the Element to exist
        /// </summary>
        public void WaitForElementToExist(string xpath) 
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(xpath)));
        }

        /// <summary>
        /// Wait for for all Post
        /// </summary>
        public void WaitForAllPosts()
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath(PostsTitlesXpath)));
            WaitForElementToExist(ResultsXpath);
        }
        #endregion




    }
}
