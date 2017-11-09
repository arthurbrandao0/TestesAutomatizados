using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Mapas_de_Ocupação
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class InclusaoDeMapaDeOcupacao
    {
        public InclusaoDeMapaDeOcupacao()
        {
        }

        [TestMethod]
        public void InclusaoDeMapaDeOcupacao_9265()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            string ocupationMapName = "Mapa de ocupação criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            McMenus.AcessarMenuAdministracaoMapasDeOcupacao();

            IWebElement listViewElement = driver.FindElement(By.Id("listView"));
            new Actions(driver).MoveToElement(listViewElement).ContextClick(listViewElement).Build().Perform();
            driver.FindElement(By.Name("Incluir")).Click();

            McFunctions.WaitForElementLoad(By.Id("textBoxName"));
            McFunctions.SearchElementByIdAndSendKeys("textBoxName", ocupationMapName);

            McFunctions.SearchElementByIdAndClick("buttonOK");
            McFunctions.TreatWaitScreen();

            bool createdAcessControl = false;
            if (listViewElement.FindElements(By.Name(ocupationMapName)).Count > 0)
            {
                createdAcessControl = true;
            }

            McFunctions.CloseWindow("Mapas de ocupação");

            Assert.IsTrue(createdAcessControl, "Mapa de ocupação criado");
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
            //McClean.CheckTestTrashMethod();
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
