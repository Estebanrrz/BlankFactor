using BlankFactor.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeleniumExtras.WaitHelpers;

namespace BlankFactor.UI
{
    public class BlogUI
    {
        #region Fields
        /// <summary>
        /// Page with repository of objects
        /// </summary>
        private BlogPage page;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">Driver to interact with the  Browser</param>
        public BlogUI(WebDriver driver)
        {
            this.page = new BlogPage(driver);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Scroll down to Load More Button
        /// </summary>
        public void ScrollDownToLoadMore()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)page.driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", page.Results);
        }

        /// <summary>
        /// CLicj on Load More Button
        /// </summary>
        public void ClickOnLoadMoreButton()
        {
            int numberOfPost = GetListOfTitlesPosts().Count();
            page.LoadMoreButton.Click(); 
            WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));
            wait.Until(x => numberOfPost < GetListOfTitlesPosts().Count());


        }

        /// <summary>
        /// Get all list of posts
        /// </summary>
        public List<string> GetListOfTitlesPosts()
        {
            page.WaitForAllPosts();
            return page.BlogPostsPerPage.Select(x => x.Text).ToList();
        }

        /// <summary>
        /// Select post based on title parameter
        /// </summary>
        /// <param name="title">title to look</param>
        public  void SelectPostByTitle(string title)
        {
            page.WaitForAllPosts();
            List<string> ListOfPost = this.GetListOfTitlesPosts();

            while (!ListOfPost.Any(x => x.Equals(title)))
            {
                ScrollDownToLoadMore();
                WaitForLoadMoreButtonToBeClickeable();
                ClickOnLoadMoreButton();
                
                page.WaitForAllPosts();
                ListOfPost = GetListOfTitlesPosts();
            }

            IWebElement post = page.BlogPostsPerPage.First(x => x.Text.Equals(title));
            post.Click();

        }
        /// <summary>
        /// print Posts And Links
        /// </summary>
        public  void PrintPostsAndLinks()
        {
              var x = GetListOfTitlesPosts();
            var y = page.BlogPostsPerPage.Select(x => x.GetAttribute("href")).ToList();

            for (int i = 0; i < x.Count; i++)
            {
                Console.WriteLine($"Title : {x[i]}  Link: {y[i]}"  );
            }


        }

        /// <summary>
        /// Subscribe To News Letter With Email(string email) 
        
        /// </summary>
        /// <param name="email"></param>
        public void SubscribeToNewsLetterWithEmail(string email) 
        {
            page.InputEmailNewsLetter.SendKeys(email);
            page.SubscribeButton.Click();
            WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.SubscribeButton));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(page.SubscribeButton, "Subscribe"));

        }

        /// <summary>
        /// Wait For Load more Button To Be Clickeable
        /// </summary>
        public void WaitForLoadMoreButtonToBeClickeable()
        {
            WebDriverWait wait = new WebDriverWait(page.driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(page.LoadMoreButton));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(page.LoadMoreButton, "Load more"));
        }

        public void WaitforAllPosts() 
        {
            page.WaitForAllPosts();
        }
       


        #endregion
    }
}