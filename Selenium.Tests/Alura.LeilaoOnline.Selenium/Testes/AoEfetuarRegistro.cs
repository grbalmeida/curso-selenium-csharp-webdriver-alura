using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDeAgradecimento()
        {
            // Arrange - dado chrome aberto, página inicial do sist. de leilões,
            // dados de registros válidos informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            IWebElement inputNome = driver.FindElement(By.Id("Nome"));
            IWebElement inputEmail = driver.FindElement(By.Id("Email"));
            IWebElement inputSenha = driver.FindElement(By.Id("Password"));
            IWebElement inputConfirmacaoSenha = driver.FindElement(By.Id("ConfirmPassword"));
            IWebElement btnRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Daniel Portugal");
            inputEmail.SendKeys("daniel.portugal@caelum.com.br");
            inputSenha.SendKeys("123");
            inputConfirmacaoSenha.SendKeys("123");

            // Act - efetuo o registro
            btnRegistro.Click();

            // Assert - devo ser direcionado para uma página de agradecimento
            Assert.Contains("Obrigado por se registrar!", driver.PageSource);
        }

        [Theory]
        [InlineData("", "daniel.portugal@caelum.com.br", "123", "123")]
        [InlineData("Daniel Portugal", "daniel", "123", "123")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "456")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "")]
        public void DadoInformacoesInvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmacaoSenha)
        {
            // Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            IWebElement inputNome = driver.FindElement(By.Id("Nome"));
            IWebElement inputEmail = driver.FindElement(By.Id("Email"));
            IWebElement inputSenha = driver.FindElement(By.Id("Password"));
            IWebElement inputConfirmacaoSenha = driver.FindElement(By.Id("ConfirmPassword"));
            IWebElement btnRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmacaoSenha.SendKeys(confirmacaoSenha);

            // Act
            btnRegistro.Click();

            // Assert
            Assert.Contains("section-registro", driver.PageSource);
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            // Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            IWebElement btnRegistro = driver.FindElement(By.Id("btnRegistro"));

            // Act
            btnRegistro.Click();

            // Assert
            IWebElement msgErroNome = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));

            Assert.True(msgErroNome.Displayed);
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            // Arrange
            driver.Navigate().GoToUrl("http://localhost:5000");

            IWebElement inputEmail = driver.FindElement(By.Id("Email"));
            IWebElement btnRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputEmail.SendKeys("daniel");

            // Act
            btnRegistro.Click();

            // Assert
            IWebElement msgErroEmail = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Email]"));

            Assert.True(msgErroEmail.Displayed);
        }
    }
}
