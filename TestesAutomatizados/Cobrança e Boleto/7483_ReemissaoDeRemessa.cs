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
using System.Threading;
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

            McFunctions.WaitForElementLoad(By.Id("listView"));
            driver.FindElement(By.Id("listView")).FindElements(By.Id(""))[0].Click();
            string fileName = driver.FindElement(By.Id("listView")).FindElements(By.Id(""))[0].GetAttribute("Name");
            
            driver.FindElement(By.Id("buttonOptions")).Click();
            driver.FindElement(By.Name("Reemitir")).Click();

            McFunctions.WaitForElementLoad(By.Id("textBoxFolder"));
            string folderPath = "C:/TestesAutomatizados/TestResults";
            driver.FindElement(By.Id("textBoxFolder")).Clear();
            driver.FindElement(By.Id("textBoxFolder")).Click();
            Keyboard.SendKeys(folderPath);
            driver.FindElement(By.Id("buttonOK")).Click();

            McFunctions.WaitForElementLoad(By.Name("Concluído"), 10);
            driver.FindElement(By.Id("buttonOK")).Click();

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
