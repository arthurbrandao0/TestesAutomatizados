using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Threading;

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
            MultiClubesFunctions McFunctions = new MultiClubesFunctions();
            MultiClubesMenus McMenus = new MultiClubesMenus();

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            dc.SetCapability("debugConnectToRunningApp", true);
            Driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            Actions act = new Actions(Driver);

            // 1. Pré-requisito: Acerto de comissão gerada para o promotor @NomePromotor, associado ao título  @IdTitulo 
            McMenus.AcessarMenuOperacaoFinanceiroAcertoDeComissao();

            Driver.FindElement(By.Name("Localizar")).Click();

            Thread.Sleep(2000);
            List<IWebElement> elementlist = new List<IWebElement>();
            elementlist.AddRange(Driver.FindElement(By.Id("listView")).FindElements(By.Name("Sophie Promotor")));

            if(elementlist.Count > 0)
            {
                act.ContextClick(elementlist[0]).Perform();
                Driver.FindElement(By.Name("Gerar acerto")).Click();
                Driver.FindElement(By.Name("Sim")).Click();
                McFunctions.TratarTelaAguarde();
                Driver.FindElement(By.Id("buttonCancel")).Click();                
            }
            else
            {
                Console.WriteLine("Acerto gerado anteriormente");
            }

            //3.Logar no MultiClubes
            // Presente no TestInitialize

            //4.Acessar Central de Atendimento
            McFunctions.AcessarCentralDeAtendimento();

            //5.Localizar e Acessar Título
            this.UIMap.AbrirAtendimentoTitulo008Pro();

            //6.Acessar o menu Produtos
            //Serem apresentadas as opções A receber, Recebido, Desativados, Créditos, Resgate, Parcelamento e Mudar promotor
            //// Já vem marcada como default

            //7.Clicar na opção A receber
            //Ser apresentada tela contendo as parcelas de produtos a receber, constando parcela do produto Acerto promotor
            McFunctions.AcessarProdutosAReceber();

            //8.Copiar o valor referente a coluna Nosso número
            Thread.Sleep(1000);
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
            
            var nossonumero = list2[counter + 6].GetAttribute("Name");

            McFunctions.ClicarBotaoFechar();
            
            //9.Clicar no menu Cobranças
            //Serem apresentadas as opções Ativas, Desativadas e Editar Cobranças
            //10.Clicar na opção Ativas
            //Ser apresentada tela contendo as cobranças ativas, constando na coluna Nosso número o mesmo valor do número copiado no passo 8
            McFunctions.AcessarCobrancasAtivas();

            var list3 = Driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""));
            var counter2 = 0;
            bool encontrounn = false;

            foreach (IWebElement i in list3)
            {
                string name = i.GetAttribute("Name");
                if (name == nossonumero)
                {
                    encontrounn = true;
                    break;
                }
                counter2++;
            }

            Assert.IsTrue(encontrounn, "Nosso numero encontrado");

            McFunctions.ClicarBotaoFechar();

            McFunctions.FinalizarAtendimentoTitulo();

            //11.Acessar Acerto de Comissão
            this.UIMap.AcessarOperacaoFinanceiroAcertoDeComissao();

            //12.Clicar no menu Histórico
            //Ser apresentada tela para acessar o histórico de acertos de promotores gerados
            Driver.FindElement(By.Id("sideButtonClassHistoric")).Click();

            //13.Clicar no botão Localizar
            //Ser apresentada lista contendo todos os acertos de promotores gerados
            Driver.FindElement(By.Id("buttonFilter")).Click();
            
            //14.Localizar e clicar no acerto de comissão referente aos passos 7 e 10
            //Registro de acerto ser corretamente selecionado e apresentado em destaque
            Thread.Sleep(1000);

            //15.Dar duplo clique no registro de acerto de promotor
            //Ser apresentada tela contendo Detalhe do acerto da comissão

            var lista = Driver.FindElementsByName("Sophie Promotor");
            var Sophie = lista[3];
            Console.WriteLine(Sophie);

            Sophie.Click();
            new Actions(Driver).DoubleClick(Sophie).Build().Perform();
            //act.MoveToElement(Sophie).DoubleClick().Build().Perform();
            
            //16.Clicar no botão Opções
            //Ser apresentado sub - menu contendo as opções disponíveis
            Driver.FindElement(By.Name("Opções")).Click();

            //17.No sub-menu, clicar na opção Desfazer acerto
            //Ser apresentada tela solicitando confirmação para desfazer acerto de comissão para o promotor
            Driver.FindElement(By.Name("Desfazer acerto")).Click();

            //18.Clicar no botão Sim
            //Acerto de comissão de promotor ser corretamente desfeito e ser apresentada tela de histórico de acertos sem constar o acerto de comissão desfeito
            Driver.FindElement(By.Name("Sim")).Click();

            McFunctions.TratarTelaAguarde();

            Driver.FindElement(By.Name("Fechar")).Click();
            
            Driver.FindElement(By.Name("Fechar")).Click();

            //19.Acessar Central de Atendimento
            McFunctions.AcessarCentralDeAtendimento();

            //20.Localizar e Acessar Título
            this.UIMap.AbrirAtendimentoTitulo008Pro();

            //21.Repetir os passos 6 e 7
            //Ser apresentada tela contendo as parcelas de produtos a receber, não constando parcela do produto Acerto promotor, desfeita no passo 18
            McFunctions.AcessarProdutosAReceber();

            var list4 = Driver.FindElement(By.Id("listViewParcel")).FindElements(By.Id(""));
            var counter4 = 0;
            bool encontrouacertopromotor = false;

            foreach (IWebElement i in list4)
            {
                var name = i.GetAttribute("Name");
                if (name == "Acerto Promotor")
                {
                    encontrouacertopromotor = true;
                    break;
                }
               counter4++;
            }
            Assert.IsFalse(encontrouacertopromotor, "Acerto Promotor continuou em Produtos a receber");

            McFunctions.ClicarBotaoFechar();

            //22.Repetir os passos 9 e 10
            McFunctions.AcessarCobrancasAtivas();

            var list5 = Driver.FindElement(By.Id("listViewDun")).FindElements(By.Id(""));
            var counter5 = 0;
            bool encontrounn2 = false;

            foreach (IWebElement i in list5)
            {
                var name = i.GetAttribute("Name");
                if (name == nossonumero)
                {
                    encontrounn = true;
                    break;
                }
                counter5++;
            }
            Assert.IsFalse(encontrounn2, "Nosso numero encontrado nas cobranças ativas");
            McFunctions.ClicarBotaoFechar();

            McFunctions.FinalizarAtendimentoTitulo();
            McFunctions.FecharJanela("Central de Atendimento");

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
