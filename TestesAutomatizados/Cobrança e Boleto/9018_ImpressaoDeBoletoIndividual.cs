﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Windows.Forms;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest5
    /// </summary>
    [CodedUITest]
    public class ImpressaoDeBoletoIndividual
    {
        public ImpressaoDeBoletoIndividual()
        {
        }

        [TestMethod]
        public void ImpressaoDeBoletoIndividual_9018()
        {
            string holder = "A28282";

            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();
            OpenCash openCash = new OpenCash();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();
            McFunctions.SearchHolder(holder);

            McFunctions.AcessarCobrancasAtivas();

            McFunctions.WaitForElementLoad(By.Id("listViewDun"));

            var listViewDunElements = driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""));

            Console.WriteLine("Valor da cobrança: {0}", listViewDunElements[4].GetAttribute("Name"));

            new Actions(driver).MoveToElement(driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""))[0]).Build().Perform();
            new Actions(driver).DoubleClick(driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""))[0]).Build().Perform();

            McFunctions.SearchElementByIdAndClick("buttonOptions");
            McFunctions.SearchElementByNameAndClick("Boleto");
            McFunctions.SearchElementByNameAndClick("Imprimir");
            McFunctions.SearchElementByIdAndClick("buttonPrint");

            this.UIMap.ImprimirDoPdf();

            McFunctions.WaitForElementLoad(By.Name("Impressão concluída"));
            SendKeys.SendWait("(%{F4})");

            McFunctions.CloseWindow("Imprimir boletos");
            McFunctions.TreatWaitScreen();
            McFunctions.CloseWindow("Detalhes da cobrança");
            McFunctions.CloseWindow("Cobranças ativas");
            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de atendimento");

            Assert.Inconclusive("Verificar o boleto gerado em C:/TestesAutomatizados/TestResults/boleto_tc9018.pdf");
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
