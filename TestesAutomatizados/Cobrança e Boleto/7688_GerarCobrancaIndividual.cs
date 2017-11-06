﻿using System;
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
using System.Threading;

namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest3
    /// </resumo>
    [CodedUITest]
    public class GerarCobrancaIndividual_7688
    {
        public GerarCobrancaIndividual_7688()
        {
        }

        [TestMethod]
        public void GerarCobrancaIndividual_7688_Metodo()
        {
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            McMenus.AcessarMenuOperacaoTituloCentralDeAtendimento();
            McFunctions.SearchHolder("A28248");

            McFunctions.AcessarCobrancasEditarCobrancas();

            McFunctions.WaitForElementLoad(By.Id("listViewDuns"));
            string billing = driver.FindElement(By.Id("listViewDuns")).FindElements(By.Id(""))[0].GetAttribute("Name");
            string billingValue = billing.Substring(billing.IndexOf("R$"));

            Console.WriteLine(billingValue);

            driver.FindElement(By.Id("linkLabelGenerate")).Click();

            McFunctions.WaitForElementLoad(By.Id("buttonGenerate"));
            driver.FindElement(By.Id("buttonGenerate")).Click();

            McFunctions.WaitForElementLoad(By.Name("Sim"));
            driver.FindElement(By.Name("Sim")).Click();

            McFunctions.WaitForElementLoad(By.Name("OK"), 10);
            
            string generatedBilling = driver.FindElement(By.Id("labelTotalValue")).GetAttribute("Name");
            
            driver.FindElement(By.Name("OK")).Click();

            McFunctions.TratarTelaAguarde();
            McFunctions.CloseWindow("Cobranças do título");

            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.CloseWindow("Central de Atendimento");

            Assert.AreEqual(billingValue, generatedBilling, "Valor previsto foi o valor gerado");

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
