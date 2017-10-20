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

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class EditarCobrancaDebitoEmConta6442
    {
        public EditarCobrancaDebitoEmConta6442()
        {
        }

        [TestMethod]
        public void EditarCobrancaDebitoEmConta6442Metodo()
        {
            string nTitle = "N/S9440-0";
            MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            MultiClubesMenus mcMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            mcMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();

            mcFunctions.WaitForElementLoad(By.Id("textBoxKeyword"));
            driver.FindElement(By.Id("textBoxKeyword")).Click();
            Keyboard.SendKeys(nTitle + "{Enter}");

            mcFunctions.WaitForElementLoad(By.Name("Titular"));
            new Actions(driver).DoubleClick(driver.FindElement(By.Name("Titular"))).Build().Perform();

            mcFunctions.AcessarCobrancasEditarCobrancas();
            driver.FindElement(By.Id("linkLabelEdit")).Click();

            driver.FindElement(By.Id("comboBoxDunType")).Click();
            driver.FindElement(By.Name("À vista")).Click();
            driver.FindElement(By.Id("buttonOK")).Click();
            mcFunctions.TratarTelaAguarde();
            mcFunctions.FecharJanela("Cobranças do título");
            //---
            mcFunctions.AcessarCobrancasEditarCobrancas();
            driver.FindElement(By.Id("linkLabelEdit")).Click();

            driver.FindElement(By.Id("comboBoxDunType")).Click();
            driver.FindElement(By.Name("Débito em conta")).Click();
            driver.FindElement(By.Id("buttonDetail")).Click();

            // Instituição de cobrança
            driver.FindElement(By.Id("comboBoxDunInstitution")).Click();
            string instituition = "BANCO DO BRASIL DEBITO AUTOMATICO";
            driver.FindElement(By.Name(instituition)).Click();

            // Ciclo
            driver.FindElement(By.Id("comboBoxCycle")).Click();
            string cycle = "Mensal";
            driver.FindElement(By.Name(cycle)).Click();

            // Agencia e dígito
            //textBoxCode
            //textBoxDigit

            // Conta e dígito
            //textBoxCode
            //textBoxDigit

            // Dia vencimento
            IWebElement boxDueDay = driver.FindElement(By.Id("textBoxDueDay"));
            boxDueDay.Clear();
            boxDueDay.Click();
            Keyboard.SendKeys("5");

            driver.FindElement(By.Id("buttonOK")).Click();
            driver.FindElement(By.Id("buttonOK")).Click();
            mcFunctions.TratarTelaAguarde();
            mcFunctions.FecharJanela("Cobranças do título");

            Assert.AreEqual(driver.FindElement(By.Id("labelDunModeValue")).GetAttribute("Name"), instituition + " " + cycle.ToLower(), "Verificando se o campo Cobrança presente no título informa os valores escolhidos.");

            mcFunctions.FinalizarAtendimentoTitulo();
            mcFunctions.FecharJanela("Central de Atendimento");
        }

        #region Atributos de teste adicionais

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
