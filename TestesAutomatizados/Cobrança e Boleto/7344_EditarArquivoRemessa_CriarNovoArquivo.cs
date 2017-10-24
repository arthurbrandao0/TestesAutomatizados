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
using OpenQA.Selenium.Interactions;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest2
    /// </resumo>
    [CodedUITest]
    public class CodedUITest2
    {
        public CodedUITest2()
        {
        }

        [TestMethod]
        public void EditarArquivoRemessa_CriarNovoArquivo_7344_Metodo()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();
            McFunctions.SearchHolder("A28225");
            McFunctions.AcessarProdutosAReceber();

            McFunctions.WaitForElementLoad(By.Id("listViewParcel"));

            new Actions(driver).DoubleClick(driver.FindElement(By.Id("listViewParcel")).FindElements(By.Id(""))[0]).Build().Perform();

            McFunctions.BillingRemittanceFiles();

            McFunctions.WaitForElementLoad(By.Id("buttonNew"));
            driver.FindElement(By.Id("buttonNew")).Click();

            McFunctions.WaitForElementLoad(By.Id("comboBoxRemittanceType"));
            driver.FindElement(By.Id("comboBoxRemittanceType")).Click();
            driver.FindElement(By.Name("Impressão")).Click();

            string fileName = "TESTE_NOVO_" + DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");
            driver.FindElement(By.Id("textBoxFileName")).Click();
            Keyboard.SendKeys(fileName);

            driver.FindElement(By.Id("buttonOK")).Click();
            driver.FindElement(By.Id("buttonOK")).Click();

            McFunctions.WaitForElementLoad(By.Name("Detalhes da cobrança"));
            McFunctions.CloseWindow("Detalhes da cobrança");

            McFunctions.WaitForElementLoad(By.Name("Detalhes da parcela e venda"));
            McFunctions.CloseWindow("Detalhes da parcela e venda");

            new Actions(driver).DoubleClick(driver.FindElement(By.Id("listViewParcel")).FindElements(By.Id(""))[8]).Build().Perform();

            McFunctions.BillingRemittanceFiles();

            bool fileNameExists = false;
            if (driver.FindElement(By.Id("listView")).FindElements(By.Name(fileName + ".rem")).Count > 0){
                fileNameExists = true;
            }
            
            driver.FindElement(By.Id("buttonOK")).Click();

            McFunctions.WaitForElementLoad(By.Name("Detalhes da cobrança"));
            McFunctions.CloseWindow("Detalhes da cobrança");

            McFunctions.WaitForElementLoad(By.Name("Detalhes da parcela e venda"));
            McFunctions.CloseWindow("Detalhes da parcela e venda");

            McFunctions.WaitForElementLoad(By.Name("Produtos a receber"));
            McFunctions.CloseWindow("Produtos a receber");

            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de atendimento");

            Assert.IsTrue(fileNameExists, "Encontrou o arquivo remessa criado anteriormente");
        }

        #region Atributos de teste adicionais

        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:

        ////Use TestInitialize para executar código antes de executar cada teste 
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
