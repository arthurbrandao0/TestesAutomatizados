using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest3
    /// </resumo>
    [CodedUITest]
    public class DesfazerCobrancaEmMassa
    {
        public DesfazerCobrancaEmMassa()
        {
        }

        [TestMethod]
        public void DesfazerCobrancaEmMassa_7687()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoFinanceiroCobrancaGeracaoDeCobranca();

            McFunctions.SearchElementByIdAndClick("checkBoxConsumption", true);

            McFunctions.SearchElementByIdAndClick("buttonGenerate");
            McFunctions.SearchElementByNameAndClick("Sim", true);

            while (Convert.ToInt32(driver.FindElement(By.Id("labelDunCountValue")).GetAttribute("Name")) < 5){
            Thread.Sleep(1000);
            }

            McFunctions.SearchElementByNameAndClick("Cancelar", true);
            McFunctions.SearchElementByNameAndClick("OK", true);
            McFunctions.CloseWindow("Geração de cobrança");

            McMenus.AcessarMenuOperacaoFinanceiroCobrancaGeracoesAnteriores();

            McFunctions.WaitForElementLoad(By.Id("listView"));
                        
            McFunctions.SearchElementByNameAndClick("Data");
            Thread.Sleep(1000);
            McFunctions.SearchElementByNameAndClick("Data");

            McFunctions.WaitForElementLoad(By.Id("listView"));
            driver.FindElement(By.Id("listView")).FindElements(By.Id(""))[0].Click();
            string fileName = driver.FindElement(By.Id("listView")).FindElements(By.Id(""))[0].GetAttribute("Name");

            McFunctions.SearchElementByIdAndClick("buttonReport", true);

            McFunctions.SearchElementByNameAndClick("Desfazer");

            McFunctions.SearchElementByNameAndClick("Sim", true);

            McFunctions.WaitForElementLoad(By.Name("Concluído"), 120);

            if (driver.FindElements(By.Name("Informação")).Count > 0)
            {
                driver.FindElement(By.Name("OK")).Click();
            }

            McFunctions.SearchElementByNameAndClick("OK");
            
            McFunctions.CloseWindow("Gerações anteriores");

            McMenus.AcessarMenuOperacaoFinanceiroCobrancaGeracoesAnteriores();

            bool billingExists = false;
            if (driver.FindElement(By.Id("listView")).FindElements(By.Name(fileName)).Count > 0)
            {
                billingExists = true;
            }

            McFunctions.CloseWindow("Gerações anteriores");
            Assert.IsFalse(billingExists, "Verificando se a cobrança desapareceu");
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
