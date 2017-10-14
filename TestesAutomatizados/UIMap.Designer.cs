﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      Este código foi gerado pelo construtor de teste de interface do usuário codificado.
//      Versão: 15.0.0.0
//
//      Alterações feitas neste arquivo podem causar comportamento incorreto
//      e serão perdidas se o código for gerado novamente.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace TestesAutomatizados
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// InserirUsuarioESenha - Use 'InserirUsuarioESenhaParams' para passar parâmetros para este método.
        /// </summary>
        public void InserirUsuarioESenha()
        {
            #region Variable Declarations
            WinEdit uITextBoxUsernameEdit = this.UIMultiClubesWindow.UITextBoxUsernameWindow.UITextBoxUsernameEdit;
            WinEdit uITextBoxPasswordEdit = this.UIMultiClubesWindow.UITextBoxPasswordWindow.UITextBoxPasswordEdit;
            WinButton uIEntrarButton = this.UIMultiClubesWindow.UIEntrarWindow.UIEntrarButton;
            #endregion

            // Digitar 'qualidade' em 'textBoxUsername' caixa de texto
            uITextBoxUsernameEdit.Text = this.InserirUsuarioESenhaParams.UITextBoxUsernameEditText;

            // Digitar '********' em 'textBoxPassword' caixa de texto
            Keyboard.SendKeys(uITextBoxPasswordEdit, this.InserirUsuarioESenhaParams.UITextBoxPasswordEditSendKeys, true);

            // Digitar '{Enter}' em '&Entrar' botão
            Keyboard.SendKeys(uIEntrarButton, this.InserirUsuarioESenhaParams.UIEntrarButtonSendKeys, ModifierKeys.None);
        }
        
        /// <summary>
        /// AltO - Use 'AltOParams' para passar parâmetros para este método.
        /// </summary>
        public void AltO()
        {
            #region Variable Declarations
            WinClient uIMultiClubesClient = this.UIMultiClubesWindow.UIMultiClubesWindow1.UIMultiClubesClient;
            #endregion

            // Digitar 'Alt + o' em 'MultiClubes' cliente
            Keyboard.SendKeys(uIMultiClubesClient, this.AltOParams.UIMultiClubesClientSendKeys, ModifierKeys.Alt);
        }
        
        /// <summary>
        /// GerarAcertoDeComissao - Use 'GerarAcertoDeComissaoParams' para passar parâmetros para este método.
        /// </summary>
        public void GerarAcertoDeComissao()
        {
            #region Variable Declarations
            WinMenuItem uIAcertodecomissãoMenuItem = this.UIMultiClubesWindow.UIMenuMainMenuBar.UIOperaçãoMenuItem.UIFinanceiroMenuItem.UIAcertodecomissãoMenuItem;
            WinButton uILocalizarButton = this.UIMultiClubesAcertodecWindow.UILocalizarWindow.UILocalizarButton;
            WinList uIListViewList = this.UIMultiClubesAcertodecWindow.UIListViewWindow.UIListViewList;
            WinListItem uISophiePromotorListItem = this.UIMultiClubesAcertodecWindow.UIListViewWindow.UIListViewList.UISophiePromotorListItem;
            WinMenuItem uIGeraracertoMenuItem = this.UIItemWindow.UIContextoMenu.UIGeraracertoMenuItem;
            WinButton uISimButton = this.UIAcertodecomissãoWindow.UISimWindow.UISimButton;
            #endregion

            // Clicar 'Operação' -> 'Financeiro' -> 'Acerto de comissão' item de menu
            Mouse.Click(uIAcertodecomissãoMenuItem, new Point(0, 0));

            // Digitar '{Enter}' em '&Localizar' botão
            Keyboard.SendKeys(uILocalizarButton, this.GerarAcertoDeComissaoParams.UILocalizarButtonSendKeys, ModifierKeys.None);

            // Selecionar 'Sophie Promotor' em 'listView' caixa de listagem
            uIListViewList.SelectedItemsAsString = this.GerarAcertoDeComissaoParams.UIListViewListSelectedItemsAsString;

            // Digitar '{Apps}' em 'Sophie Promotor' item de lista
            Keyboard.SendKeys(uISophiePromotorListItem, this.GerarAcertoDeComissaoParams.UISophiePromotorListItemSendKeys, ModifierKeys.None);

            // Clicar 'Gerar acerto' item de menu
            Mouse.Click(uIGeraracertoMenuItem, new Point(0, 0));

            // Digitar '{Enter}' em '&Sim' botão
            Keyboard.SendKeys(uISimButton, this.GerarAcertoDeComissaoParams.UISimButtonSendKeys, ModifierKeys.None);
        }
        
        /// <summary>
        /// ClicarBotaoOkAcertoDeComissao - Use 'ClicarBotaoOkAcertoDeComissaoParams' para passar parâmetros para este método.
        /// </summary>
        public void ClicarBotaoOkAcertoDeComissao()
        {
            #region Variable Declarations
            WinButton uIOKButton = this.UIEmailsWindow.UIOKWindow.UIOKButton;
            #endregion

            // Última ação do mouse não foi gravada.

            // Digitar '{Tab}{Enter}' em '&OK' botão
            Keyboard.SendKeys(uIOKButton, this.ClicarBotaoOkAcertoDeComissaoParams.UIOKButtonSendKeys, ModifierKeys.None);
        }
        
        /// <summary>
        /// LocalizarHistoricoDeAcertos - Use 'LocalizarHistoricoDeAcertosParams' para passar parâmetros para este método.
        /// </summary>
        public void LocalizarHistoricoDeAcertos()
        {
            #region Variable Declarations
            WinButton uIHistóricoButton = this.UIMultiClubesAcertodecWindow.UIHistóricoWindow.UIHistóricoButton;
            WinButton uILocalizarButton = this.UIMultiClubesWindow.UILocalizarWindow.UILocalizarButton;
            #endregion

            // Digitar '{Enter}' em 'Histórico' botão
            Keyboard.SendKeys(uIHistóricoButton, this.LocalizarHistoricoDeAcertosParams.UIHistóricoButtonSendKeys, ModifierKeys.None);

            // Digitar '{Enter}' em 'Localizar' botão
            Keyboard.SendKeys(uILocalizarButton, this.LocalizarHistoricoDeAcertosParams.UILocalizarButtonSendKeys, ModifierKeys.None);
        }
        
        #region Properties
        public virtual InserirUsuarioESenhaParams InserirUsuarioESenhaParams
        {
            get
            {
                if ((this.mInserirUsuarioESenhaParams == null))
                {
                    this.mInserirUsuarioESenhaParams = new InserirUsuarioESenhaParams();
                }
                return this.mInserirUsuarioESenhaParams;
            }
        }
        
        public virtual AltOParams AltOParams
        {
            get
            {
                if ((this.mAltOParams == null))
                {
                    this.mAltOParams = new AltOParams();
                }
                return this.mAltOParams;
            }
        }
        
        public virtual GerarAcertoDeComissaoParams GerarAcertoDeComissaoParams
        {
            get
            {
                if ((this.mGerarAcertoDeComissaoParams == null))
                {
                    this.mGerarAcertoDeComissaoParams = new GerarAcertoDeComissaoParams();
                }
                return this.mGerarAcertoDeComissaoParams;
            }
        }
        
        public virtual ClicarBotaoOkAcertoDeComissaoParams ClicarBotaoOkAcertoDeComissaoParams
        {
            get
            {
                if ((this.mClicarBotaoOkAcertoDeComissaoParams == null))
                {
                    this.mClicarBotaoOkAcertoDeComissaoParams = new ClicarBotaoOkAcertoDeComissaoParams();
                }
                return this.mClicarBotaoOkAcertoDeComissaoParams;
            }
        }
        
        public virtual LocalizarHistoricoDeAcertosParams LocalizarHistoricoDeAcertosParams
        {
            get
            {
                if ((this.mLocalizarHistoricoDeAcertosParams == null))
                {
                    this.mLocalizarHistoricoDeAcertosParams = new LocalizarHistoricoDeAcertosParams();
                }
                return this.mLocalizarHistoricoDeAcertosParams;
            }
        }
        
        public UIMultiClubesWindow UIMultiClubesWindow
        {
            get
            {
                if ((this.mUIMultiClubesWindow == null))
                {
                    this.mUIMultiClubesWindow = new UIMultiClubesWindow();
                }
                return this.mUIMultiClubesWindow;
            }
        }
        
        public UIMultiClubesAcertodecWindow UIMultiClubesAcertodecWindow
        {
            get
            {
                if ((this.mUIMultiClubesAcertodecWindow == null))
                {
                    this.mUIMultiClubesAcertodecWindow = new UIMultiClubesAcertodecWindow();
                }
                return this.mUIMultiClubesAcertodecWindow;
            }
        }
        
        public UIItemWindow UIItemWindow
        {
            get
            {
                if ((this.mUIItemWindow == null))
                {
                    this.mUIItemWindow = new UIItemWindow();
                }
                return this.mUIItemWindow;
            }
        }
        
        public UIAcertodecomissãoWindow UIAcertodecomissãoWindow
        {
            get
            {
                if ((this.mUIAcertodecomissãoWindow == null))
                {
                    this.mUIAcertodecomissãoWindow = new UIAcertodecomissãoWindow();
                }
                return this.mUIAcertodecomissãoWindow;
            }
        }
        
        public UIEmailsWindow UIEmailsWindow
        {
            get
            {
                if ((this.mUIEmailsWindow == null))
                {
                    this.mUIEmailsWindow = new UIEmailsWindow();
                }
                return this.mUIEmailsWindow;
            }
        }
        #endregion
        
        #region Fields
        private InserirUsuarioESenhaParams mInserirUsuarioESenhaParams;
        
        private AltOParams mAltOParams;
        
        private GerarAcertoDeComissaoParams mGerarAcertoDeComissaoParams;
        
        private ClicarBotaoOkAcertoDeComissaoParams mClicarBotaoOkAcertoDeComissaoParams;
        
        private LocalizarHistoricoDeAcertosParams mLocalizarHistoricoDeAcertosParams;
        
        private UIMultiClubesWindow mUIMultiClubesWindow;
        
        private UIMultiClubesAcertodecWindow mUIMultiClubesAcertodecWindow;
        
        private UIItemWindow mUIItemWindow;
        
        private UIAcertodecomissãoWindow mUIAcertodecomissãoWindow;
        
        private UIEmailsWindow mUIEmailsWindow;
        #endregion
    }
    
    /// <summary>
    /// Parâmetros a serem passados para 'InserirUsuarioESenha'
    /// </summary>
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class InserirUsuarioESenhaParams
    {
        
        #region Fields
        /// <summary>
        /// Digitar 'qualidade' em 'textBoxUsername' caixa de texto
        /// </summary>
        public string UITextBoxUsernameEditText = "qualidade";
        
        /// <summary>
        /// Digitar '********' em 'textBoxPassword' caixa de texto
        /// </summary>
        public string UITextBoxPasswordEditSendKeys = "EwKH4AR/i+efPGIZvLkbbxuhIiidiMHRBw0kCMO4UErzCmSWBycOwxwfFbjAR92KTKI+W3n1HTA=";
        
        /// <summary>
        /// Digitar '{Enter}' em '&Entrar' botão
        /// </summary>
        public string UIEntrarButtonSendKeys = "{Enter}";
        #endregion
    }
    
    /// <summary>
    /// Parâmetros a serem passados para 'AltO'
    /// </summary>
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class AltOParams
    {
        
        #region Fields
        /// <summary>
        /// Digitar 'Alt + o' em 'MultiClubes' cliente
        /// </summary>
        public string UIMultiClubesClientSendKeys = "o";
        #endregion
    }
    
    /// <summary>
    /// Parâmetros a serem passados para 'GerarAcertoDeComissao'
    /// </summary>
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class GerarAcertoDeComissaoParams
    {
        
        #region Fields
        /// <summary>
        /// Digitar '{Enter}' em '&Localizar' botão
        /// </summary>
        public string UILocalizarButtonSendKeys = "{Enter}";
        
        /// <summary>
        /// Selecionar 'Sophie Promotor' em 'listView' caixa de listagem
        /// </summary>
        public string UIListViewListSelectedItemsAsString = "Sophie Promotor";
        
        /// <summary>
        /// Digitar '{Apps}' em 'Sophie Promotor' item de lista
        /// </summary>
        public string UISophiePromotorListItemSendKeys = "{Apps}";
        
        /// <summary>
        /// Digitar '{Enter}' em '&Sim' botão
        /// </summary>
        public string UISimButtonSendKeys = "{Enter}";
        #endregion
    }
    
    /// <summary>
    /// Parâmetros a serem passados para 'ClicarBotaoOkAcertoDeComissao'
    /// </summary>
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class ClicarBotaoOkAcertoDeComissaoParams
    {
        
        #region Fields
        /// <summary>
        /// Digitar '{Tab}{Enter}' em '&OK' botão
        /// </summary>
        public string UIOKButtonSendKeys = "{Tab}{Enter}";
        #endregion
    }
    
    /// <summary>
    /// Parâmetros a serem passados para 'LocalizarHistoricoDeAcertos'
    /// </summary>
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class LocalizarHistoricoDeAcertosParams
    {
        
        #region Fields
        /// <summary>
        /// Digitar '{Enter}' em 'Histórico' botão
        /// </summary>
        public string UIHistóricoButtonSendKeys = "{Enter}";
        
        /// <summary>
        /// Digitar '{Enter}' em 'Localizar' botão
        /// </summary>
        public string UILocalizarButtonSendKeys = "{Enter}";
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIMultiClubesWindow : WinWindow
    {
        
        public UIMultiClubesWindow()
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.Name] = "MultiClubes";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("MultiClubes");
            #endregion
        }
        
        #region Properties
        public UITextBoxUsernameWindow UITextBoxUsernameWindow
        {
            get
            {
                if ((this.mUITextBoxUsernameWindow == null))
                {
                    this.mUITextBoxUsernameWindow = new UITextBoxUsernameWindow(this);
                }
                return this.mUITextBoxUsernameWindow;
            }
        }
        
        public UITextBoxPasswordWindow UITextBoxPasswordWindow
        {
            get
            {
                if ((this.mUITextBoxPasswordWindow == null))
                {
                    this.mUITextBoxPasswordWindow = new UITextBoxPasswordWindow(this);
                }
                return this.mUITextBoxPasswordWindow;
            }
        }
        
        public UIEntrarWindow UIEntrarWindow
        {
            get
            {
                if ((this.mUIEntrarWindow == null))
                {
                    this.mUIEntrarWindow = new UIEntrarWindow(this);
                }
                return this.mUIEntrarWindow;
            }
        }
        
        public UIMultiClubesWindow1 UIMultiClubesWindow1
        {
            get
            {
                if ((this.mUIMultiClubesWindow1 == null))
                {
                    this.mUIMultiClubesWindow1 = new UIMultiClubesWindow1(this);
                }
                return this.mUIMultiClubesWindow1;
            }
        }
        
        public UIMenuMainMenuBar UIMenuMainMenuBar
        {
            get
            {
                if ((this.mUIMenuMainMenuBar == null))
                {
                    this.mUIMenuMainMenuBar = new UIMenuMainMenuBar(this);
                }
                return this.mUIMenuMainMenuBar;
            }
        }
        
        public UILocalizarWindow UILocalizarWindow
        {
            get
            {
                if ((this.mUILocalizarWindow == null))
                {
                    this.mUILocalizarWindow = new UILocalizarWindow(this);
                }
                return this.mUILocalizarWindow;
            }
        }
        #endregion
        
        #region Fields
        private UITextBoxUsernameWindow mUITextBoxUsernameWindow;
        
        private UITextBoxPasswordWindow mUITextBoxPasswordWindow;
        
        private UIEntrarWindow mUIEntrarWindow;
        
        private UIMultiClubesWindow1 mUIMultiClubesWindow1;
        
        private UIMenuMainMenuBar mUIMenuMainMenuBar;
        
        private UILocalizarWindow mUILocalizarWindow;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UITextBoxUsernameWindow : WinWindow
    {
        
        public UITextBoxUsernameWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "textBoxUsername";
            this.WindowTitles.Add("MultiClubes");
            #endregion
        }
        
        #region Properties
        public WinEdit UITextBoxUsernameEdit
        {
            get
            {
                if ((this.mUITextBoxUsernameEdit == null))
                {
                    this.mUITextBoxUsernameEdit = new WinEdit(this);
                    #region Critérios de pesquisa
                    this.mUITextBoxUsernameEdit.WindowTitles.Add("MultiClubes");
                    #endregion
                }
                return this.mUITextBoxUsernameEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUITextBoxUsernameEdit;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UITextBoxPasswordWindow : WinWindow
    {
        
        public UITextBoxPasswordWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "textBoxPassword";
            this.WindowTitles.Add("MultiClubes");
            #endregion
        }
        
        #region Properties
        public WinEdit UITextBoxPasswordEdit
        {
            get
            {
                if ((this.mUITextBoxPasswordEdit == null))
                {
                    this.mUITextBoxPasswordEdit = new WinEdit(this);
                    #region Critérios de pesquisa
                    this.mUITextBoxPasswordEdit.WindowTitles.Add("MultiClubes");
                    #endregion
                }
                return this.mUITextBoxPasswordEdit;
            }
        }
        #endregion
        
        #region Fields
        private WinEdit mUITextBoxPasswordEdit;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIEntrarWindow : WinWindow
    {
        
        public UIEntrarWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "button";
            this.WindowTitles.Add("MultiClubes");
            #endregion
        }
        
        #region Properties
        public WinButton UIEntrarButton
        {
            get
            {
                if ((this.mUIEntrarButton == null))
                {
                    this.mUIEntrarButton = new WinButton(this);
                    #region Critérios de pesquisa
                    this.mUIEntrarButton.SearchProperties[WinButton.PropertyNames.Name] = "Entrar";
                    this.mUIEntrarButton.WindowTitles.Add("MultiClubes");
                    #endregion
                }
                return this.mUIEntrarButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIEntrarButton;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIMultiClubesWindow1 : WinWindow
    {
        
        public UIMultiClubesWindow1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "FormWelcome";
            this.WindowTitles.Add("MultiClubes");
            #endregion
        }
        
        #region Properties
        public WinClient UIMultiClubesClient
        {
            get
            {
                if ((this.mUIMultiClubesClient == null))
                {
                    this.mUIMultiClubesClient = new WinClient(this);
                    #region Critérios de pesquisa
                    this.mUIMultiClubesClient.SearchProperties[WinControl.PropertyNames.Name] = "MultiClubes";
                    this.mUIMultiClubesClient.WindowTitles.Add("MultiClubes");
                    #endregion
                }
                return this.mUIMultiClubesClient;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mUIMultiClubesClient;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIMenuMainMenuBar : WinMenuBar
    {
        
        public UIMenuMainMenuBar(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.WindowTitles.Add("MultiClubes");
            #endregion
        }
        
        #region Properties
        public UIOperaçãoMenuItem UIOperaçãoMenuItem
        {
            get
            {
                if ((this.mUIOperaçãoMenuItem == null))
                {
                    this.mUIOperaçãoMenuItem = new UIOperaçãoMenuItem(this);
                }
                return this.mUIOperaçãoMenuItem;
            }
        }
        #endregion
        
        #region Fields
        private UIOperaçãoMenuItem mUIOperaçãoMenuItem;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIOperaçãoMenuItem : WinMenuItem
    {
        
        public UIOperaçãoMenuItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinMenuItem.PropertyNames.Name] = "Operação";
            this.WindowTitles.Add("MultiClubes");
            #endregion
        }
        
        #region Properties
        public UIFinanceiroMenuItem UIFinanceiroMenuItem
        {
            get
            {
                if ((this.mUIFinanceiroMenuItem == null))
                {
                    this.mUIFinanceiroMenuItem = new UIFinanceiroMenuItem(this);
                }
                return this.mUIFinanceiroMenuItem;
            }
        }
        #endregion
        
        #region Fields
        private UIFinanceiroMenuItem mUIFinanceiroMenuItem;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIFinanceiroMenuItem : WinMenuItem
    {
        
        public UIFinanceiroMenuItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinMenuItem.PropertyNames.Name] = "Financeiro";
            this.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
            this.WindowTitles.Add("MultiClubes");
            #endregion
        }
        
        #region Properties
        public WinMenuItem UIAcertodecomissãoMenuItem
        {
            get
            {
                if ((this.mUIAcertodecomissãoMenuItem == null))
                {
                    this.mUIAcertodecomissãoMenuItem = new WinMenuItem(this);
                    #region Critérios de pesquisa
                    this.mUIAcertodecomissãoMenuItem.SearchProperties[WinMenuItem.PropertyNames.Name] = "Acerto de comissão";
                    this.mUIAcertodecomissãoMenuItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mUIAcertodecomissãoMenuItem.WindowTitles.Add("MultiClubes");
                    #endregion
                }
                return this.mUIAcertodecomissãoMenuItem;
            }
        }
        #endregion
        
        #region Fields
        private WinMenuItem mUIAcertodecomissãoMenuItem;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UILocalizarWindow : WinWindow
    {
        
        public UILocalizarWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "buttonFilter";
            this.WindowTitles.Add("MultiClubes");
            #endregion
        }
        
        #region Properties
        public WinButton UILocalizarButton
        {
            get
            {
                if ((this.mUILocalizarButton == null))
                {
                    this.mUILocalizarButton = new WinButton(this);
                    #region Critérios de pesquisa
                    this.mUILocalizarButton.SearchProperties[WinButton.PropertyNames.Name] = "Localizar";
                    this.mUILocalizarButton.WindowTitles.Add("MultiClubes");
                    #endregion
                }
                return this.mUILocalizarButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUILocalizarButton;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIMultiClubesAcertodecWindow : WinWindow
    {
        
        public UIMultiClubesAcertodecWindow()
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.Name] = "MultiClubes - Acerto de comissão";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("MultiClubes - Acerto de comissão");
            #endregion
        }
        
        #region Properties
        public UILocalizarWindow1 UILocalizarWindow
        {
            get
            {
                if ((this.mUILocalizarWindow == null))
                {
                    this.mUILocalizarWindow = new UILocalizarWindow1(this);
                }
                return this.mUILocalizarWindow;
            }
        }
        
        public UIListViewWindow UIListViewWindow
        {
            get
            {
                if ((this.mUIListViewWindow == null))
                {
                    this.mUIListViewWindow = new UIListViewWindow(this);
                }
                return this.mUIListViewWindow;
            }
        }
        
        public UIHistóricoWindow UIHistóricoWindow
        {
            get
            {
                if ((this.mUIHistóricoWindow == null))
                {
                    this.mUIHistóricoWindow = new UIHistóricoWindow(this);
                }
                return this.mUIHistóricoWindow;
            }
        }
        #endregion
        
        #region Fields
        private UILocalizarWindow1 mUILocalizarWindow;
        
        private UIListViewWindow mUIListViewWindow;
        
        private UIHistóricoWindow mUIHistóricoWindow;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UILocalizarWindow1 : WinWindow
    {
        
        public UILocalizarWindow1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "buttonSearch";
            this.WindowTitles.Add("MultiClubes - Acerto de comissão");
            #endregion
        }
        
        #region Properties
        public WinButton UILocalizarButton
        {
            get
            {
                if ((this.mUILocalizarButton == null))
                {
                    this.mUILocalizarButton = new WinButton(this);
                    #region Critérios de pesquisa
                    this.mUILocalizarButton.SearchProperties[WinButton.PropertyNames.Name] = "Localizar";
                    this.mUILocalizarButton.WindowTitles.Add("MultiClubes - Acerto de comissão");
                    #endregion
                }
                return this.mUILocalizarButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUILocalizarButton;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIListViewWindow : WinWindow
    {
        
        public UIListViewWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "listView";
            this.WindowTitles.Add("MultiClubes - Acerto de comissão");
            #endregion
        }
        
        #region Properties
        public UIListViewList UIListViewList
        {
            get
            {
                if ((this.mUIListViewList == null))
                {
                    this.mUIListViewList = new UIListViewList(this);
                }
                return this.mUIListViewList;
            }
        }
        #endregion
        
        #region Fields
        private UIListViewList mUIListViewList;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIListViewList : WinList
    {
        
        public UIListViewList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinList.PropertyNames.Name] = "Filtre os acertos utilizando os filtros acima";
            this.WindowTitles.Add("MultiClubes - Acerto de comissão");
            #endregion
        }
        
        #region Properties
        public WinListItem UISophiePromotorListItem
        {
            get
            {
                if ((this.mUISophiePromotorListItem == null))
                {
                    this.mUISophiePromotorListItem = new WinListItem(this);
                    #region Critérios de pesquisa
                    this.mUISophiePromotorListItem.SearchProperties[WinListItem.PropertyNames.Name] = "Sophie Promotor";
                    this.mUISophiePromotorListItem.WindowTitles.Add("MultiClubes - Acerto de comissão");
                    #endregion
                }
                return this.mUISophiePromotorListItem;
            }
        }
        #endregion
        
        #region Fields
        private WinListItem mUISophiePromotorListItem;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIHistóricoWindow : WinWindow
    {
        
        public UIHistóricoWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "sideButtonClassHistoric";
            this.WindowTitles.Add("MultiClubes - Acerto de comissão");
            #endregion
        }
        
        #region Properties
        public WinButton UIHistóricoButton
        {
            get
            {
                if ((this.mUIHistóricoButton == null))
                {
                    this.mUIHistóricoButton = new WinButton(this);
                    #region Critérios de pesquisa
                    this.mUIHistóricoButton.SearchProperties[WinButton.PropertyNames.Name] = "Histórico";
                    this.mUIHistóricoButton.WindowTitles.Add("MultiClubes - Acerto de comissão");
                    #endregion
                }
                return this.mUIHistóricoButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIHistóricoButton;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIItemWindow : WinWindow
    {
        
        public UIItemWindow()
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.AccessibleName] = "Contexto";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32768";
            #endregion
        }
        
        #region Properties
        public UIContextoMenu UIContextoMenu
        {
            get
            {
                if ((this.mUIContextoMenu == null))
                {
                    this.mUIContextoMenu = new UIContextoMenu(this);
                }
                return this.mUIContextoMenu;
            }
        }
        #endregion
        
        #region Fields
        private UIContextoMenu mUIContextoMenu;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIContextoMenu : WinMenu
    {
        
        public UIContextoMenu(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinMenu.PropertyNames.Name] = "Contexto";
            #endregion
        }
        
        #region Properties
        public WinMenuItem UIGeraracertoMenuItem
        {
            get
            {
                if ((this.mUIGeraracertoMenuItem == null))
                {
                    this.mUIGeraracertoMenuItem = new WinMenuItem(this);
                    #region Critérios de pesquisa
                    this.mUIGeraracertoMenuItem.SearchProperties[WinMenuItem.PropertyNames.Name] = "Gerar acerto";
                    #endregion
                }
                return this.mUIGeraracertoMenuItem;
            }
        }
        #endregion
        
        #region Fields
        private WinMenuItem mUIGeraracertoMenuItem;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIAcertodecomissãoWindow : WinWindow
    {
        
        public UIAcertodecomissãoWindow()
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Acerto de comissão";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Acerto de comissão");
            #endregion
        }
        
        #region Properties
        public UISimWindow UISimWindow
        {
            get
            {
                if ((this.mUISimWindow == null))
                {
                    this.mUISimWindow = new UISimWindow(this);
                }
                return this.mUISimWindow;
            }
        }
        #endregion
        
        #region Fields
        private UISimWindow mUISimWindow;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UISimWindow : WinWindow
    {
        
        public UISimWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "buttonOK";
            this.WindowTitles.Add("Acerto de comissão");
            #endregion
        }
        
        #region Properties
        public WinButton UISimButton
        {
            get
            {
                if ((this.mUISimButton == null))
                {
                    this.mUISimButton = new WinButton(this);
                    #region Critérios de pesquisa
                    this.mUISimButton.SearchProperties[WinButton.PropertyNames.Name] = "Sim";
                    this.mUISimButton.WindowTitles.Add("Acerto de comissão");
                    #endregion
                }
                return this.mUISimButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUISimButton;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIEmailsWindow : WinWindow
    {
        
        public UIEmailsWindow()
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.Name] = "E-mails";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("E-mails");
            #endregion
        }
        
        #region Properties
        public UIOKWindow UIOKWindow
        {
            get
            {
                if ((this.mUIOKWindow == null))
                {
                    this.mUIOKWindow = new UIOKWindow(this);
                }
                return this.mUIOKWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIOKWindow mUIOKWindow;
        #endregion
    }
    
    [GeneratedCode("Construtor de UITest codificado", "15.0.26208.0")]
    public class UIOKWindow : WinWindow
    {
        
        public UIOKWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Critérios de pesquisa
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "buttonCancel";
            this.WindowTitles.Add("E-mails");
            #endregion
        }
        
        #region Properties
        public WinButton UIOKButton
        {
            get
            {
                if ((this.mUIOKButton == null))
                {
                    this.mUIOKButton = new WinButton(this);
                    #region Critérios de pesquisa
                    this.mUIOKButton.SearchProperties[WinButton.PropertyNames.Name] = "OK";
                    this.mUIOKButton.WindowTitles.Add("E-mails");
                    #endregion
                }
                return this.mUIOKButton;
            }
        }
        #endregion
        
        #region Fields
        private WinButton mUIOKButton;
        #endregion
    }
}