﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <summary>
    /// Summary description for CodedUITest5
    /// </summary>
    [CodedUITest]
    public class EditarCobrancaPagamentoOnline
    {
        public EditarCobrancaPagamentoOnline()
        {
        }

        [TestMethod]
        public void EditarCobrancaPagamentoOnline_8661()
        {
            //string holder = "n/s41344-0";

            //MultiClubesFunctions mcFunctions = new MultiClubesFunctions();
            //MultiClubesMenus mcMenus = new MultiClubesMenus();

            //var dc = new DesiredCapabilities();
            //dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            //dc.SetCapability("debugConnectToRunningApp", true);
            //RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            this.UIMap.AlterarConfiguracaoPagamento();


            //mcMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();

            //mcFunctions.SearchHolder(holder);

            //mcFunctions.AcessarCobrancasEditarCobrancas();
            //driver.FindElement(By.Id("linkLabelEdit")).Click();

            //driver.FindElement(By.Id("comboBoxDunType")).Click();
            //driver.FindElement(By.Name("À vista")).Click();
            //driver.FindElement(By.Id("buttonOK")).Click();
            //mcFunctions.TratarTelaAguarde();
            //mcFunctions.CloseWindow("Cobranças do título");
            ////---
            //mcFunctions.AcessarCobrancasEditarCobrancas();
            //driver.FindElement(By.Id("linkLabelEdit")).Click();
            //driver.FindElement(By.Id("comboBoxDunType")).Click();
            //driver.FindElement(By.Name("Pagamento online")).Click();
            //driver.FindElement(By.Id("buttonDetail")).Click();
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
            //McClean.CheckTestTrashMethod();
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
