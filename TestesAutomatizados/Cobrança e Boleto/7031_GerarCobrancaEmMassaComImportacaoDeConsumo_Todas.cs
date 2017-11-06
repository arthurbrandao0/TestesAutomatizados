using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest2
    /// </resumo>
    [CodedUITest]
    public class GerarCobrancaEmMassaComImportacaoDeConsumo_Todas_7031
    {
        public GerarCobrancaEmMassaComImportacaoDeConsumo_Todas_7031()
        {
        }

        [TestMethod]
        public void GerarCobrancaEmMassaComImportacaoDeConsumo_Todas_7031Metodo()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            McMenus.AcessarMenuOperacaoFinanceiroCobrancaGeracaoDeCobranca();

            McFunctions.WaitForElementLoad(By.Id("OPERATION_FINANCIAL+DUN+DUN_GENERATION"));

            //this.UIMap.HabilitarOpcaoImportarConsumosAte();
            //this.UIMap.SelecionarTodasCobrancas();
            //this.UIMap.DesabilitarGerarComOpcaoPorCiclo();
            McFunctions.SearchElementByIdAndClick("buttonGenerate");
            McFunctions.SearchElementByNameAndClick("Sim", true);

            McFunctions.CheckBillingForecast();
            McFunctions.WaitBillingGeneration();
        }

        #region Atributos de teste adicionais

        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:

        ////Use TestInitialize para executar código antes de executar cada teste 
        [TestInitialize()]
        public void MyTestInitialize()
        {
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
