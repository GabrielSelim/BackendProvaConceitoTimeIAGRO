using Teste_Pratico_IAGRO.Models;

namespace Teste_Pratico_IAGRO.Service.Interface
{
    public interface ILivroService
    {
        IEnumerable<Livro> ObterLivros(LivroParametro parametros);

        decimal CalcularFrete(string preco);
    }
}