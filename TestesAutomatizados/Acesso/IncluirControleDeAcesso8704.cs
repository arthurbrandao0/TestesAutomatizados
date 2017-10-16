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


namespace TestesAutomatizados.Cobrança_e_Boleto
{
    /// <resumo>
    /// Descrição resumida para CodedUITest1
    /// </resumo>
    [CodedUITest]
    public class IncluirControleDeAcesso8704
    {
        public IncluirControleDeAcesso8704()
        {
        }

        [TestMethod]
        public void IncluirControleDeAcesso8704Metodo()
        {
            // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
            this.UIMap.AcessarAdmAcesControleDeAcesso();
            this.UIMap.ProcurarTituloMultiClubesControleDeAcesso();
            this.UIMap.ProcurarColunaNome();
            this.UIMap.ProcurarColunaUltimaAlteracao();
            this.UIMap.ProcurarColunaCriacao();
            this.UIMap.AbrirTelaIncluirControleAcesso();
            this.UIMap.InserirInformacoesNomeEDescricaoControleDeAcesso();
            this.UIMap.ConfigurarRegrasControleDeAcesso();
            this.UIMap.IncluirCadastroControleAcesso();
            this.UIMap.FecharAdmAcesControleDeAcesso();
            // criado e testado em 21/09/17
        }

        #region Atributos de teste adicionais

        // É possível usar os seguintes atributos adicionais enquanto escreve os testes:

        ////Use TestInitialize para executar código antes de executar cada teste 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
        //}

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
