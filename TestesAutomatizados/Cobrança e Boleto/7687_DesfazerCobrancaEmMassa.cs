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
            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            this.UIMap.AbrirGeracoesAnterioresDeCobranca();
            //aqui entra o código com o range de datas, se necessário
            this.UIMap.AcessarSelecaoDeCobrancasAnteriores();
            Keyboard.SendKeys(this.UIMap.UIGeraçõesanterioresWindow, "{End}");
            this.UIMap.ClicarOpcaoDesfazerCobranca();

            int tempoEspera = 0;

            while (tempoEspera < 500)
            {
                tempoEspera += 1;
                Thread.Sleep(1000);

                Console.WriteLine(tempoEspera + "ª tentativa às " + DateTime.Now.ToString("h:mm:ss:fff tt"));

                WinText UIConcluídaText = new WinText();
                UIConcluídaText.SearchProperties[WinText.PropertyNames.Name] = "Concluído";
                UIConcluídaText.WindowTitles.Add("Desfazer cobrança");


                if (UIConcluídaText.Exists)
                {
                    Console.WriteLine("Desfez cobranca");
                    break;

                }
            }

            this.UIMap.FecharTelaDesfazerCobrancasAnteriores();

        }

        #region Atributos de teste adicionais

        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:

        ////Use TestInitialize para executar código antes de executar cada teste 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            CheckLoginMulticlubes loginMultiClubes = new CheckLoginMulticlubes();
            loginMultiClubes.VerificarSeMultiClubesEstaAbertoELogado();
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
    }
}
