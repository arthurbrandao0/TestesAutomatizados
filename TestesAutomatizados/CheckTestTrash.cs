﻿using System;
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
using System.Threading;

namespace TestesAutomatizados
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CheckTestTrash
    {
        public CheckTestTrash()
        {
        }

        public void CheckTestTrashMethod()
        {
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus mcMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            if (driver.FindElement(By.Id("FormMain")).FindElements(By.Name("Fechar")).Count > 1)
            {
                mcMenus.AcessarMenuArquivoSair();
                Thread.Sleep(500);
                Console.WriteLine(driver.FindElements(By.Name("Erro")).Count);
                if (driver.FindElements(By.Name("Erro")).Count > 0)
                {
                    string errorMessage = driver.FindElement(By.Id("ContentText")).GetAttribute("Name");
                    Console.WriteLine(errorMessage);
                    driver.FindElement(By.Name("OK")).Click();
                    if (errorMessage == "Feche o caixa para finalizar o sistema.")
                    {
                        Console.WriteLine("Fechar caixa");
                        CloseCash closecash = new CloseCash();
                        closecash.CloseCashMethod();
                        mcMenus.AcessarMenuArquivoSair();
                    }
                }

                Console.WriteLine("MultiClubes fechado pelo CheckTestTrash.cs");
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
