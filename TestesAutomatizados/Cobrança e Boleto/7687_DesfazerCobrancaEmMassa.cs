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
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

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
        public void DesfazerCobrancaEmMassa_7687_Metodo()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoFinanceiroCobrancaGeracoesAnteriores();
            
            //aqui entra o código com o range de datas, se necessário

            McFunctions.WaitForElementLoad(By.Id("listView"));

            driver.FindElement(By.Name("Data")).Click();
            driver.FindElement(By.Name("Data")).Click();

            driver.FindElement(By.Id("listView")).FindElements(By.Id(""))[0].Click();
            string fileName = driver.FindElement(By.Id("listView")).FindElements(By.Id(""))[0].GetAttribute("Name");

            driver.FindElement(By.Id("buttonReport")).Click();
            driver.FindElement(By.Name("Desfazer")).Click();

            McFunctions.WaitForElementLoad(By.Name("Pergunta"));
            driver.FindElement(By.Name("Sim")).Click();

            McFunctions.WaitForElementLoad(By.Name("Concluído"), 30);

            if (driver.FindElements(By.Name("Informação")).Count > 0)
            {
                driver.FindElement(By.Name("OK")).Click();
            }
            driver.FindElement(By.Name("OK")).Click();

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
            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            CheckLoginMulticlubes loginMC = new CheckLoginMulticlubes();
            loginMC.VerificarSeMultiClubesEstaAbertoELogado();
            loginMC.CheckMCWindow();
        }

        //Use TestCleanup para executar código depois de cada execução de teste
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //    CheckTestTrash McClean = new CheckTestTrash();
        //    McClean.CheckTestTrashMethod();
        //}

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
