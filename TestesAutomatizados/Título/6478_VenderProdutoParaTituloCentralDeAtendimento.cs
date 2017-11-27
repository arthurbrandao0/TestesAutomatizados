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

namespace TestesAutomatizados.Título
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class VenderProdutoParaTituloCentralDeAtendimento
    {
        public VenderProdutoParaTituloCentralDeAtendimento()
        {
        }

        [TestMethod]
        public void VenderProdutoParaTituloCentralDeAtendimento_6478()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();
            OpenCash openCash = new OpenCash();
            openCash.OpenCashMethod();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            string productName = " Festa Junina - Venda de Tickets - 2,00";

            McMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();

            McFunctions.SearchHolder("A28282");

            McFunctions.SearchElementByNameAndClick("Título");
            //McFunctions.SearchElementByIdAndClick("LargeIncrement");
            driver.FindElement(By.Id("sideBar")).FindElement(By.Id("LargeIncrement")).Click();
            McFunctions.SearchElementByNameAndClick("Vender produto");
            McFunctions.TreatWaitScreen();

            McFunctions.SearchElementByIdAndClick("buttonSelect");
            McFunctions.SearchElementByNameAndClick(productName, true, 2);
            McFunctions.SearchElementByIdAndClick("buttonOK");

            string totalValue = driver.FindElementById("labelTotalValue").GetAttribute("Name");

            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.SearchElementByNameAndClick("Sim", true, 2);
            McFunctions.TreatWaitScreen();

            McFunctions.SearchElementByIdAndClick("buttonOK", true, 2);

            McFunctions.SearchElementByIdAndClick("buttonReceive", true, 2);
            driver.FindElement(By.Name("Receber")).FindElement(By.Name("Receber")).Click();

            bool productFound = false;            
            if (driver.FindElement(By.Id("listViewParcels")).FindElements(By.Name(productName)).Count > 0)
            {
                productFound = true;
            }

            bool valueFound = false;
            if (driver.FindElement(By.Id("listViewParcels")).FindElements(By.Name(totalValue)).Count > 0)
            {
                valueFound = true;
            }

            McFunctions.SearchElementByIdAndClick("buttonAdd");

            McFunctions.SearchElementByIdAndClick("buttonOK");
            McFunctions.SearchElementByNameAndClick("Sim", true, 2);
            McFunctions.TreatWaitScreen();
            McFunctions.TreatWaitScreen();

            McFunctions.SearchElementByIdAndClick("buttonOK", true);

            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de atendimento");

            Assert.IsTrue(productFound, "Produto \"" + productName + "\" não encontrado no A Receber");
            Assert.IsTrue(valueFound, "Cobrança de " + totalValue + " não encontrada no A Receber");
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            CheckLoginMulticlubes loginMC = new CheckLoginMulticlubes();
            loginMC.VerificarSeMultiClubesEstaAbertoELogado();
        }

        ////Use TestCleanup para executar código depois de cada execução de teste
        [TestCleanup()]
        public void MyTestCleanup()
        {
            CheckTestTrash McClean = new CheckTestTrash();
            McClean.CheckTestTrashMethod();
        }

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
