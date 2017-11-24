using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class OpenCash
    {
        public OpenCash()
        {
        }

        public void OpenCashMethod()
        {
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            driver.FindElement(By.Id("panelLeft")).FindElement(By.Name("tabPageCash")).Click();
            if (driver.FindElement(By.Id("panelLeft")).FindElements(By.Name("Caixa fechado")).Count > 0)
            {
                mcFunctions.SearchElementByIdAndClick("buttonOpen");
                mcFunctions.SearchElementByNameAndClick("Novo");

                if (driver.FindElement(By.Id("FormMain")).FindElements(By.Name("Atenção")).Count > 0)
                {
                    Console.WriteLine("Caixa aberto anteriormente");
                    mcFunctions.SearchElementByIdAndClick("CommandButton_1");
                    mcFunctions.SearchElementByIdAndClick("buttonOpen");
                    mcFunctions.SearchElementByNameAndClick("Existente");
                }

                mcFunctions.SearchElementByIdAndSendKeys("textBoxUserPassword", "DeZer0@100");
                mcFunctions.SearchElementByIdAndClick("buttonUser");
                mcFunctions.SearchElementByIdAndClick("buttonOK");
            }            
        }
                

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
