using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void DesfazerCobrancaIndividual_Metodo()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();
            McFunctions.SearchHolder("A28248");

            McFunctions.AcessarCobrancasAtivas();
            
            McFunctions.WaitForElementLoad(By.Id("listViewYear"));
            driver.FindElement(By.Id("listViewYear")).FindElements(By.Id(""))[0].Click();
            
            McFunctions.WaitForElementLoad(By.Id("listViewDun"));
            var listViewDunElements = driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""));

            int counter = 0;
            foreach (IWebElement i in listViewDunElements)
            {
                if (i.GetAttribute("Name") == "")
                {
                    break;
                }
                counter++;
            }

            Console.WriteLine(listViewDunElements[counter - 4].GetAttribute("Name"));
            listViewDunElements[counter - 4].Click();

            new Actions(driver).DoubleClick(listViewDunElements[counter - 4]).Build().Perform();
            
            McFunctions.WaitForElementLoad(By.Id("buttonOptions"));
            driver.FindElement(By.Id("buttonOptions")).Click();

            driver.FindElement(By.Name("Desfazer cobrança")).Click();
            driver.FindElement(By.Name("Sim")).Click();

            McFunctions.WaitForElementLoad(By.Name("OK"));
            driver.FindElement(By.Name("OK")).Click();

            McFunctions.CloseWindow("Cobranças ativas");
            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de atendimento");


        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            CheckLoginMulticlubes loginMC = new CheckLoginMulticlubes();
            loginMC.VerificarSeMultiClubesEstaAbertoELogado();
            loginMC.CheckMCWindow();

            OpenCash openCash = new OpenCash();
            openCash.OpenCashMethod();
        }

        ////Use TestCleanup para executar código depois de cada execução de teste
        [TestCleanup()]
        public void MyTestCleanup()
        {
            CheckTestTrash McClean = new CheckTestTrash();
            //McClean.CheckTestTrashMethod();
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
