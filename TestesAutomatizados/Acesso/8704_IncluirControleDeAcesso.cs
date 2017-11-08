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
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class IncluirControleDeAcesso
    {
        public IncluirControleDeAcesso()
        {
        }

        [TestMethod]
        public void IncluirControleDeAcesso_8704()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            string accessControlName = "Controle de Acesso criado em " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            string descriptionAccessControlName = "Descrição " + accessControlName;

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuAdministracaoAcessoControlesDeAcesso();

            IWebElement listViewElement = driver.FindElement(By.Id("listView"));
            new Actions(driver).MoveToElement(listViewElement).ContextClick(listViewElement).Build().Perform();
            driver.FindElement(By.Name("Incluir")).Click();

            McFunctions.SearchElementByIdAndSendKeys("textBoxName", accessControlName);
            McFunctions.SearchElementByIdAndSendKeys("textBoxDescription", descriptionAccessControlName);

            McFunctions.SearchElementByIdAndClick("buttonRules");

            //verificar quais regras serão aplicadas
            
            McFunctions.SearchElementByIdAndClick("buttonOK");
            McFunctions.SearchElementByIdAndClick("buttonOK");
            McFunctions.TreatWaitScreen();

            bool createdAcessControl = false;
            if (listViewElement.FindElements(By.Name(accessControlName)).Count > 0)
            {
                createdAcessControl = true;
            }

            McFunctions.CloseWindow("Controle de Acesso");

            Assert.IsTrue(createdAcessControl);
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
