
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
//using OpenQA.Selenium.Remote;
using System.Diagnostics;
using System.Threading;

namespace TestesAutomatizados
{
    /// <resumo>
    /// Verificar se o MultiClubes está aberto e logado
    /// </resumo>
    [CodedUITest]
    public class CheckLoginMulticlubes
    {
        public CheckLoginMulticlubes()
        {
        }

        [TestMethod]

        public void VerificarSeMultiClubesEstaAbertoELogado()
        {
            // verificando se o processo já está em execução
            Process[] processlist = Process.GetProcesses();
            // variavel para verificar se o MultiClubes está aberto (por padrão, é falso)
            bool OpenedMultiClubes = false;
            bool OpenedWiniumDriver = false;

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {
                    //a linha abaixo, que está comentada, mostra todos os processos em execução
                    //Console.WriteLine("Process: {0} | ID: {1} | Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                    if (process.MainWindowTitle.Contains("MultiClubes"))
                    {
                        // se for identificado algum processo em que o título contenha "MultiClubes", a variavel recebe True
                        OpenedMultiClubes = true;
                    }
                    else if (process.MainWindowTitle.Contains("Winium.Desktop.Driver.exe"))
                    {
                        OpenedWiniumDriver = true;
                    }
                }
            }

            if (!OpenedWiniumDriver)
            {
                Console.WriteLine("Winium Driver fechado {0}", OpenedWiniumDriver);
                Process.Start("C:/Users/arthur.gama/automatizados/TestesAutomatizados/" + "Winium.Desktop.Driver.exe");
                Thread.Sleep(5000);
            }

            var dc = new DesiredCapabilities();
            dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");
            //dc.SetCapability("app", @"C:/Triade/MultiClubes/System/MultiClubes/MultiClubes.UI.application");

            // se a variavel estiver como falso, entra nessa condição que abre o MultiClubes
            if (OpenedMultiClubes)
            {
                dc.SetCapability("debugConnectToRunningApp", true);
            }

            Thread.Sleep(5000);
            Driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

            //Driver.FindElement(By.XPath("*[starts-with(@Name, 'MultiClubes')]")).Click();
            //Driver.FindElement(By.Name("MultiClubes")).Click();

            //foreach (IWebElement i in Driver.FindElements(By.XPath("//*[starts-with(@Name, 'MultiClubes')]")))
            //{
            //    Console.WriteLine(i.GetAttribute("Name"));
            //}
            //Thread.Sleep(10000);

            //Driver.FindElement(By.Id("textBoxUsername")).SendKeys("suporte");
            //Driver.FindElement(OpenQA.Selenium.By.Id("textBoxPassword")).SendKeys("DeZer0@100");
            //Driver.FindElement(OpenQA.Selenium.By.Id("button")).Click();


            if (Driver.FindElements(OpenQA.Selenium.By.Id("textBoxUsername")).Count > 0 &&
                Driver.FindElements(OpenQA.Selenium.By.Id("textBoxPassword")).Count > 0)
            {
                this.UIMap.InserirUsuarioESenha();
            }
            //Assert.AreEqual(Driver.FindElements(OpenQA.Selenium.By.Id("panelFooter")).Count, 1);



            //Process proc = new Process();
            //proc.StartInfo.FileName = @"C:/Triade/MultiClubes/System/MultiClubes/MultiClubes.UI.application";
            //proc.Start();
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
        [TestCleanup()]
        public void MyTestCleanup()
        {
            //Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
           Driver.Close();
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
        private RemoteWebDriver Driver;

    }
}

