using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest5
    /// </summary>
    [CodedUITest]
    public class VisualizarMensagemInstrucaoEMensagemExternaDeBoletoPago
    {
        public VisualizarMensagemInstrucaoEMensagemExternaDeBoletoPago()
        {
        }

        [TestMethod]
        public void VisualizarMensagemInstrucaoEMensagemExternaDeBoletoPago_9061()
        {
            string holder = "N/S41344-0";

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

            McFunctions.WaitForElementLoad(By.Id("listViewYear"));
            driver.FindElement(By.Id("listViewYear")).FindElements(By.Id(""))[0].Click();

            new Actions(driver).DoubleClick(driver.FindElement(By.Id("listViewDun")).FindElements(By.Name("444100000143"))[0]).Build().Perform();
            McFunctions.TreatWaitScreen();
            McFunctions.SearchElementByIdAndClick("buttonOptions");
            McFunctions.SearchElementByNameAndClick("Boleto");
            McFunctions.SearchElementByNameAndClick("Visualizar mensagem");

            bool messageFound = false;
            if (driver.FindElements(By.Name("MSG TESTE")).Count > 0)
            {
                messageFound = true;
            }

            McFunctions.SearchElementByNameAndClick("Instrução");
            bool instructionFound = false;
            if (driver.FindElements(By.Name("INSTRUCAO TESTE")).Count > 0)
            {
                instructionFound = true;
            }

            McFunctions.SearchElementByNameAndClick("Mensagem externa");
            bool externalMessageFound = false;
            if (driver.FindElements(By.Name("MSG EXTERNA TESTE")).Count > 0)
            {
                externalMessageFound = true;
            }
            
            driver.FindElement(By.Name("Cancelar")).Click();
            McFunctions.CloseWindow("Detalhes da cobrança");
            McFunctions.CloseWindow("Cobranças ativas");
            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de atendimento");

            Assert.IsTrue(messageFound, "Mensagem Encontrada");
            Assert.IsTrue(instructionFound, "Instrução Encontrada");
            Assert.IsTrue(externalMessageFound, "Mensagem externa Encontrada");
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
