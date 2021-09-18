using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    { 
        private IWebDriver driver; // Primeira armazenou o Webdriver
        private By byInputLogin; // Localizadores necessarios para page de login
        private By byInputSenha;
        private By byBotaoLogin;

        // construtor injeção de dependencia(Meu  Login PO depende de Webdriver)
        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            //localizadores inicializados na criação da classe
            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
        }

        public LoginPO Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
            return this;
        }

        public LoginPO PreencheFormulario(string login, string senha)
        {
            return 
                InformarEmail(login)
                .InformarSenha(senha);
        }

        public LoginPO InformarEmail(string login)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            return this;
        }

        public LoginPO InformarSenha(string senha)
        {
            driver.FindElement(byInputSenha).SendKeys(senha);
            return this;
        }

        public LoginPO EfetuarLogin()
        {
            return SubmeteFormulario();
        }

        public LoginPO SubmeteFormulario()
        {
            driver.FindElement(byBotaoLogin).Submit();
            return this;
        }

        public void EfetuarLoginComCredenciais(string login, string senha)
        {
            Visitar()
              .PreencheFormulario(login, senha)
              .SubmeteFormulario();
        }

    }
}
