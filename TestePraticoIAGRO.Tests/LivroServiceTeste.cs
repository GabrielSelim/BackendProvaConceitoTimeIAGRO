using Teste_Pratico_IAGRO.Service;
using Teste_Pratico_IAGRO.Service.Interface;

namespace TestePraticoIAGRO.Tests
{
    [TestClass]
    public sealed class LivroServiceTeste
    {
        private ILivroService _livroService;

        [TestInitialize]
        public void Setup()
        {
            _livroService = new LivroService();
        }

        [TestMethod]
        [DataRow("20,0", 4.0)]
        [DataRow("20.0", 4.0)]
        [DataRow("100,50", 20.10)]
        [DataRow("100.50", 20.10)]
        public void DeveCalcularFreteCorretamenteParaPrecosValidos(string preco, double freteEsperado)
        {
            var resultado = _livroService.CalcularFrete(preco);

            Assert.AreEqual((decimal)freteEsperado, resultado);
        }

        [TestMethod]
        [DataRow("abc")]
        [DataRow("-10")]
        [DataRow("0")]
        [DataRow("10,0,0")]
        [DataRow("10.0.0")]
        public void DeveLancarArgumentExceptionParaPrecosInvalidos(string preco)
        {
            Assert.ThrowsException<ArgumentException>(() => _livroService.CalcularFrete(preco));
        }
    }
}