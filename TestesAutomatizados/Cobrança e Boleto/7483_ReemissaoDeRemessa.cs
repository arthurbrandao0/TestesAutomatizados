using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest3
    /// </resumo>
    [CodedUITest]
    public class ReemissaoDeRemessa
    {
        public ReemissaoDeRemessa()
        {
        }

        [TestMethod]
        public void ReemissaoDeRemessa_7483()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoFinanceiroTransacoesBancariasRemessasAnteriores();

            McFunctions.WaitForElementLoad(By.Id("listView"), 15);
            driver.FindElement(By.Id("listView")).FindElements(By.Id(""))[0].Click();

            string fileName = driver.FindElement(By.Id("listView")).FindElements(By.Id(""))[0].GetAttribute("Name");

            McFunctions.SearchElementByIdAndClick("buttonOptions", true);
            McFunctions.SearchElementByNameAndClick("Reemitir", true);

            McFunctions.WaitForElementLoad(By.Id("textBoxFolder"));

            string folderPath = "C:/TestesAutomatizados/TestResults";
            McFunctions.SearchElementByIdAndSendKeys("textBoxFolder", folderPath);

            McFunctions.SearchElementByIdAndClick("buttonOK");

            McFunctions.WaitForElementLoad(By.Name("Concluído"), 10);
            McFunctions.SearchElementByIdAndClick("buttonOK");
            
            McFunctions.CloseWindow("Diretório Saída Remessa");
            McFunctions.CloseWindow("Remessas anteriores");

            string filePath = folderPath + "/" + fileName;
            
            Assert.IsTrue(File.Exists(filePath), "Arquivo gerado corretamente");
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
