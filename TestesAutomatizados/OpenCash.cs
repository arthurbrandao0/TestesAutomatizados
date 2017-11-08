using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

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

            driver.FindElement(By.Name("tabPageCash")).Click();
            if (driver.FindElements(By.Name("Caixa fechado")).Count == 1)
            {
                driver.FindElement(By.Id("buttonOpen")).Click();
                mcFunctions.WaitForElementLoad(By.Name("Novo"), 1);
                driver.FindElement(By.Name("Novo")).Click();

                if (driver.FindElements(By.Name("Atenção")).Count > 0)
                {
                    Console.WriteLine("Caixa aberto anteriormente");
                    driver.FindElement(By.Id("CommandButton_1")).Click();
                    driver.FindElement(By.Id("buttonOpen")).Click();
                    driver.FindElement(By.Name("Existente")).Click();
                }
                this.UIMap.InserirSenhaAberturaCaixa();

                mcFunctions.TreatWaitScreen();
                driver.FindElement(By.Id("buttonOK")).Click();
            }
            

            Assert.AreEqual(driver.FindElements(By.Name("Caixa aberto")).Count, 1, "Caixa aberto");
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
