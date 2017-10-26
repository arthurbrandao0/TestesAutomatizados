using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;


namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest4
    /// </summary>
    [CodedUITest]
    public class CodedUITest4
    {
        public CodedUITest4()
        {
        }

        [TestMethod]
        public void VerificarCobrancaDeDependente_Metodo()
        {
            string holder = "A28234";
            string billingType = "Mensalidade Dependente";

            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();
            McFunctions.SearchHolder(holder);

            McFunctions.AcessarCobrancasEditarCobrancas();
            
            McFunctions.WaitForElementLoad(By.Id("listView"));
            var listViewDunElements = driver.FindElement(By.Id("listView")).FindElements(By.Id(""));

            int counter = 0;
            bool dependentBillingFound = false;
            string valueBilling = String.Empty;
            foreach (IWebElement i in listViewDunElements)
            {
                if (i.GetAttribute("Name") == billingType)
                {
                    valueBilling = listViewDunElements[counter + 3].GetAttribute("Name");
                    dependentBillingFound = true;
                    break;
                }
                counter++;
            }

            bool dependentBillingValueFound = false;
            if (valueBilling.Contains("R$ ") && valueBilling.Contains(","))
            {
                dependentBillingValueFound = true;
            }

            McFunctions.CloseWindow("Cobranças do título");
            McFunctions.TratarTelaAguarde();
            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de atendimento");

            Assert.IsTrue(dependentBillingFound, "Cobrança de dependente encontrada");
            Assert.IsTrue(dependentBillingValueFound, "Valor da cobrança de dependente encontrada");
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
