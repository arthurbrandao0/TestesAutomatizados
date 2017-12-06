using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class SimulacaoDeGeracaoDeCobrancaSemConfirmacao6392
    {
        public SimulacaoDeGeracaoDeCobrancaSemConfirmacao6392()
        {
        }

        [TestMethod]
        public void SimulacaoDeGeracaoDeCobrancaSemConfirmacao_6392()
        {
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoFinanceiroCobrancaSimulacaoDeCobranca();

            mcFunctions.SearchElementByIdAndClick("buttonSimulate", true);
            mcFunctions.SearchElementByNameAndClick("Não", true);

            mcFunctions.TreatWaitScreen();

            bool simulationScreenFound = false;
            if (driver.FindElementsById("FormDunSimulator").Count > 0)
            {
                simulationScreenFound = true;

                mcFunctions.SearchElementByNameAndClick("Cancelar", true);
                mcFunctions.SearchElementByNameAndClick("OK", true);
            }

            Assert.IsFalse(simulationScreenFound, "Criou a janela de geração de cobrança");

            mcFunctions.CloseWindow("Simulação de cobrança");
        }

        #region Atributos de teste adicionais

        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:

        ////Use TestInitialize para executar código antes de executar cada teste 
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

        /// <resumo>
        ///Obtém ou define o contexto do teste que provê
        ///informação e funcionalidade da execução de teste atual.
        ///</resumo>
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
