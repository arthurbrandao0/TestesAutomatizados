using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace TestesAutomatizados
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CloseCash
    {
        public CloseCash()
        {
        }

        public void CloseCashMethod()
        {
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus mcMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            driver.FindElement(By.Name("tabPageCash")).Click();

            mcFunctions.WaitForElementLoad(By.Id("buttonOptions"));
            driver.FindElement(By.Id("buttonOptions")).Click();
            driver.FindElement(By.Name("Fechamento")).Click();

            List<string> textBoxList = new List<string>();
            textBoxList.Add("textBoxClosingConsumptionCardValue");
            textBoxList.Add("textBoxClosingCheckValue");
            textBoxList.Add("textBoxClosingCovenantValue");
            textBoxList.Add("textBoxClosingMoneyValue");
            textBoxList.Add("textBoxClosingDocumentValue");

            foreach (string i in textBoxList)
            {
                Console.WriteLine(i + "/");
                driver.FindElement(By.Id(i)).Click();
                Keyboard.SendKeys("0");
            }

            driver.FindElement(By.Id("textBoxUserPassword")).Click();
            Keyboard.SendKeys("DeZer0@100");

            driver.FindElement(By.Id("buttonUser")).Click();
            mcFunctions.WaitForElementLoad(By.Id("buttonOK"));
            driver.FindElement(By.Id("buttonOK")).Click();
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
