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
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace TestesAutomatizados.CobrancaEBoleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class DesfazerAcertoDePromotorComCobrancaGerada_8200
    {
        public DesfazerAcertoDePromotorComCobrancaGerada_8200()
        {
        }

        [TestMethod]
        public void DesfazerAcertoDePromotorComCobrancaGerada_8200_Metodo()
        {
            MenusAndFunctions AcessarMenu = new MenusAndFunctions();
            
            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            Driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            Actions act = new Actions(Driver);

            // 1. Pré-requisito: Acerto de comissão gerada para o promotor @NomePromotor, associado ao título  @IdTitulo 
            this.UIMap.AcessarOperacaoFinanceiroAcertoDeComissao();

            Driver.FindElement(By.Name("Localizar")).Click();

            List<IWebElement> elementlist = new List<IWebElement>();
            elementlist.AddRange(Driver.FindElement(By.Id("listView")).FindElements(By.Name("Sophie Promotor")));

            if(elementlist.Count > 0)
            {
                act.ContextClick(elementlist[0]).Perform();
                Driver.FindElement(By.Name("Gerar acerto")).Click();
                Driver.FindElement(By.Name("Sim")).Click();
                AcessarMenu.TratarTelaAguarde();
                Driver.FindElement(By.Name("OK")).Click();
            }
            else
            {
                Console.WriteLine("Acerto gerado anteriormente");
            }

            //2. Pré - requisito: Cobrança gerada contendo o acerto do promotor @NomePromotor

            //3.Logar no MultiClubes
            // Presente no TestInitialize

            //4.Acessar Central de Atendimento
            AcessarMenu.AcessarCentralDeAtendimento();

            //5.Localizar e Acessar Título
            this.UIMap.AbrirAtendimentoTitulo008Pro();

            //6.Acessar o menu Produtos
            //Serem apresentadas as opções A receber, Recebido, Desativados, Créditos, Resgate, Parcelamento e Mudar promotor
            //// Já vem marcada como default

            //7.Clicar na opção A receber
            //Ser apresentada tela contendo as parcelas de produtos a receber, constando parcela do produto Acerto promotor
            this.UIMap.AcessarProdutosAReceber();

            //8.Copiar o valor referente a coluna Nosso número
            var list2 = Driver.FindElement(By.Id("listViewParcel")).FindElements(By.Id(""));
            var counter = 0;

            foreach (IWebElement i in list2)
            {
                var name = i.GetAttribute("Name");
                Console.WriteLine(name);

                if (name == "Acerto Promotor")
                {
                    break;
                }
                counter++;
            }
            Console.WriteLine("NN:");
            var nossonumero = list2[counter + 6].GetAttribute("Name");
            Console.WriteLine(nossonumero);

            AcessarMenu.ClicarBotaoFechar();

            //9.Clicar no menu Cobranças
            //Serem apresentadas as opções Ativas, Desativadas e Editar Cobranças
            Driver.FindElement(By.Name("Cobranças")).FindElement(By.Id("headerButton")).Click();

            //10.Clicar na opção Ativas
            //Ser apresentada tela contendo as cobranças ativas, constando na coluna Nosso número o mesmo valor do número copiado no passo 8
            Driver.FindElement(By.Name("Ativas")).Click();

            var list3 = Driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""));
            var counter2 = 0;
            bool encontrounn = false;

            foreach (IWebElement i in list3)
            {
                var name = i.GetAttribute("Name");
                Console.WriteLine(name);

                if (name == nossonumero)
                {
                    encontrounn = true;
                    break;
                }
                counter2++;
            }

            Console.WriteLine("NN encontrado? {0}", encontrounn);
            Assert.IsTrue(encontrounn, "Nosso numero encontrado");

            AcessarMenu.ClicarBotaoFechar();

            AcessarMenu.FinalizarAtendimentoTitulo();

            //11.Acessar Acerto de Comissão
            this.UIMap.AcessarOperacaoFinanceiroAcertoDeComissao();

            //12.Clicar no menu Histórico
            //Ser apresentada tela para acessar o histórico de acertos de promotores gerados
            Driver.FindElement(By.Id("sideButtonClassHistoric")).Click();

            //13.Clicar no botão Localizar
            //Ser apresentada lista contendo todos os acertos de promotores gerados
            Driver.FindElement(By.Id("buttonFilter")).Click();
            this.UIMap.LocalizarHistoricoDeAcertos();

            //14.Localizar e clicar no acerto de comissão referente aos passos 7 e 10
            //Registro de acerto ser corretamente selecionado e apresentado em destaque
            var list = Driver.FindElement(By.Id("listView")).FindElements(By.Name("Sophie Promotor"));

            //15.Dar duplo clique no registro de acerto de promotor
            //Ser apresentada tela contendo Detalhe do acerto da comissão
                        
            act.DoubleClick(list[2]).Perform();
            
            //16.Clicar no botão Opções
            //Ser apresentado sub - menu contendo as opções disponíveis
            Driver.FindElement(By.Name("Opções")).Click();

            //17.No sub-menu, clicar na opção Desfazer acerto
            //Ser apresentada tela solicitando confirmação para desfazer acerto de comissão para o promotor
            Driver.FindElement(By.Name("Desfazer acerto")).Click();

            //18.Clicar no botão Sim
            //Acerto de comissão de promotor ser corretamente desfeito e ser apresentada tela de histórico de acertos sem constar o acerto de comissão desfeito
            Driver.FindElement(By.Name("Sim")).Click();

            AcessarMenu.TratarTelaAguarde();

            Driver.FindElement(By.Name("Fechar")).Click();
            
            Driver.FindElement(By.Name("Fechar")).Click();

            //19.Acessar Central de Atendimento
            AcessarMenu.AcessarCentralDeAtendimento();

            //20.Localizar e Acessar Título
            this.UIMap.AbrirAtendimentoTitulo008Pro();

            //21.Repetir os passos 6 e 7

            //Ser apresentada tela contendo as parcelas de produtos a receber, não constando parcela do produto Acerto promotor, desfeita no passo 18
            //22.Repetir os passos 9 e 10
            //Ser apresentada tela contendo as cobranças ativas, não constando cobrança referente ao acerto de comissão de promotor, desfeita no passo 18
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
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
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
        private RemoteWebDriver Driver;
    }
}
