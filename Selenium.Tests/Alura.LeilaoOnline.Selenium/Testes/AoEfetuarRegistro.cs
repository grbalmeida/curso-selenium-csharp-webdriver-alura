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
    }
}
