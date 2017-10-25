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
using System.IO;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest3
    /// </summary>
    [CodedUITest]
    public class CodedUITest3
    {
        public CodedUITest3()
        {
        }

        [TestMethod]
        public void GerarCobrancaAtravesDeImportacaoDeArquivo_Metodo()
        {
            string holder = "A28248";

            string filePath = "C:/TestesAutomatizados/TestResults/";
            string fileName = "cobranca_por_arquivo" + DateTime.Now.ToString("_dd_MM_yyyy_HH_mm_ss") + ".csv";
            string valueBilling = "123,45";

            using (var w = new StreamWriter(filePath + fileName))
            {
                w.WriteLine("Título;Sócio;Valor;Data de vencimento;Produto");
                w.WriteLine("{0};;{1};{2};Produto Teste Cobranca por Arquivo", holder , valueBilling ,DateTime.Now.ToString("dd/MM/yyyy"));
                w.Flush();
            }

            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoFinanceiroCobrancaImportacaoDeCobranca();

            driver.FindElement(By.Id("textBoxFileName")).Click();
            Keyboard.SendKeys(filePath + fileName);

            driver.FindElement(By.Id("buttonGenerate")).Click();

            McFunctions.WaitForElementLoad(By.Name("OK"), 10);
            driver.FindElement(By.Name("OK")).Click();

            McFunctions.CloseWindow("Importação de cobrança");

            McMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();
            McFunctions.SearchHolder(holder);

            McFunctions.AcessarCobrancasAtivas();

            McFunctions.WaitForElementLoad(By.Id("listViewDun"));
            var listViewDunElements = driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""));

            int counter = 0;
            bool importedBillingFound = false;
            foreach (IWebElement i in listViewDunElements)
            {
                if (i.GetAttribute("Name") == DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    if (listViewDunElements[counter + 3].GetAttribute("Name") == "R$ " + valueBilling)
                    {
                        importedBillingFound = true;
                        break;
                    }
                }
                counter++;
            }
            
            McFunctions.CloseWindow("Cobranças ativas");
            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de atendimento");

            Assert.IsTrue(importedBillingFound, "Valor da cobrança encontrado nas cobranças ativas");
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
