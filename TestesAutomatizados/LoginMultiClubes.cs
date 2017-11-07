
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
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

        public void VerificarSeMultiClubesEstaAbertoELogado()
        {
            try
            {
                // verificando se o processo já está em execução
                Process[] processlist = Process.GetProcesses();
                // variavel para verificar se o MultiClubes está aberto (por padrão, é falso)
                bool openedMultiClubes = false;
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
                            openedMultiClubes = true;
                        }
                        else if (process.MainWindowTitle.Contains("Winium.Desktop.Driver.exe"))
                        {
                            OpenedWiniumDriver = true;
                        }
                    }
                }

                if (!OpenedWiniumDriver)
                {
                    //Console.WriteLine("Winium Driver fechado {0}", OpenedWiniumDriver);
                    Process.Start("C:/TestesAutomatizados/" + "Winium.Desktop.Driver.exe");
                    Thread.Sleep(5000);
                }

                var dc = new DesiredCapabilities();
                dc.SetCapability("app", @"\\tsidev\Triade\Application\Dev\MultiClubes\System\MultiClubes\MultiClubes.UI.application");

                // se a variavel estiver como falso, entra nessa condição que abre o MultiClubes
                if (openedMultiClubes)
                {
                    dc.SetCapability("debugConnectToRunningApp", true);
                }
                else
                {
                    Thread.Sleep(5000);
                }

                driver = new RemoteWebDriver(new Uri("http://localhost:9999"), dc);

                CheckMCWindow();

                int counter = 0;
                if (!openedMultiClubes) { 
                    while (counter < 50)
                    { 
                        if (driver.FindElements(By.Id("textBoxUsername")).Count > 0 
                            &&
                            driver.FindElements(By.Id("textBoxPassword")).Count > 0)
                        {
                            this.UIMap.InserirUsuarioESenha();
                            break;
                        }
                        Thread.Sleep(1000);
                        counter++;
                    }
                }
                else
                {
                    if (driver.FindElements(By.Id("textBoxUsername")).Count > 0
                            &&
                            driver.FindElements(By.Id("textBoxPassword")).Count > 0)
                    {
                        this.UIMap.InserirUsuarioESenha();
                    }
                }

            }
            catch (ArgumentException e)
            {
                //Please log when you're just catching something. Especially if the catch statement has side effects. Trust me.
                Console.WriteLine("IOException source: {0}", e.Source);
            }
        }

        public void CheckMCWindow()
        {
            WinWindow winMC = new WinWindow();
            winMC.SearchProperties[WinWindow.PropertyNames.Name] = "MultiClubes";
            winMC.WindowTitles.Add("MultiClubes");
            
            while (!winMC.Exists)
            {
                Thread.Sleep(1000);
            }
            winMC.SetFocus();
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
        //    //Para gerar código para este teste, selecione "Gerar Código para Teste de Interface do Usuário Codificado" no menu de atalho e selecione um dos itens do menu.
        //   //Driver.Close();
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
        public RemoteWebDriver driver;

    }
}

