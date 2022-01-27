using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlankFactor
{
    using BlankFactor.UI;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;

    [TestClass]
    public class Tests
    {
        
        private WebDriver driver;
        private HomeUI homeUI;


        [TestInitialize]
        public virtual void TestInit()
        {  //Select the browser to use
            string browser = "Chrome";
            //string browser = "Firefox";

            if (browser.Equals("Chrome"))
            {
                driver = new ChromeDriver();

            }
            else if (browser.Equals("Firefox"))
            {
                driver = new FirefoxDriver();
            }
            homeUI = new HomeUI(driver);

        }

        [TestMethod]
        public void BlankFactorAssestment()
        {

            homeUI.Navigate();
            homeUI.GoToBlogPage();
            BlogUI blogUI= new BlogUI(driver);
            blogUI.SelectPostByTitle("Why Fintech in Latin America Is Having a Boom");
            Assert.AreEqual(driver.Url, "https://blankfactor.com/insights/blog/fintech-in-latin-america/","URL is not the expected");
            blogUI.SubscribeToNewsLetterWithEmail("esteban_rr@hotmail.com");
            driver.Navigate().Back();
            blogUI.WaitforAllPosts();
            blogUI.PrintPostsAndLinks();


        }
       
            /// <summary>
            /// CleanUp the tests
            /// </summary>
            [TestCleanup]
        public virtual void TestCleanUp()
        {
            driver.Close();
        }
    }
}
