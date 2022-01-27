using BlankFactor.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlankFactor.UI
{
   public  class HomeUI
    {
        #region Fields
        /// <summary>
        /// Page with repository of objects
        /// </summary>
        private HomePage page;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="driver">Driver to interact with the  Browser</param>
        public HomeUI(WebDriver driver)
        {
            this.page = new HomePage(driver);
        }

        #endregion

        #region Methods
        /// <summary>
        /// Navigate  to the page
        /// </summary>
        public void Navigate()
        {
            page.Navigate();

        }

        /// <summary>
        ///  Hover Insights Menu, Then go to  Blog Title and click the Title
        /// </summary>
        
        public void GoToBlogPage() 
        {
            //Instantiating Actions class
            Actions actions = new Actions(page.driver);
            //Hovering on Insights Menu
            actions.MoveToElement(page.InsightsMenu);
            //Hovering  on  Blog title 
            actions.MoveToElement(page.BlogTitle);
            //Perform Steps
            actions.Click().Build().Perform();

        }

        


        #endregion


    }
}
