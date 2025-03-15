using System.Globalization;
using System.Text.Json;
using Teste_Pratico_IAGRO.Models;
using Teste_Pratico_IAGRO.Service.Interface;

namespace Teste_Pratico_IAGRO.Service
{
    public class LivroService : ILivroService
    {
        private readonly List<Livro> _livros;

        public LivroService()
        {
            var jsonLivros = File.ReadAllText("books.json");
            _livros = JsonSerializer.Deserialize<List<Livro>>(jsonLivros);
        }

        public IEnumerable<Livro> ObterLivros(LivroParametro parametros)
        {
            var query = _livros.AsQueryable();

            if (!string.IsNullOrEmpty(parametros.Autor))
            {
                query = query.Where(l => l.specifications.Author.Contains(parametros.Autor, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(parametros.Nome))
            {
                query = query.Where(l => l.name.Contains(parametros.Nome, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(parametros.Genero))
            {
                query = query.Where(l => l.specifications.Genres.Any(g => g.Contains(parametros.Genero, StringComparison.OrdinalIgnoreCase)));
            }

            if (parametros.OrdenarPor == "asc")
            {
                query = query.OrderBy(l => l.price);
            }
            else if (parametros.OrdenarPor == "desc")
            {
                query = query.OrderByDescending(l => l.price);
            }

            if (!query.Any())
            {
                throw new ArgumentException("Nenhum livro encontrado com os parâmetros fornecidos.");
            }

            return query.ToList();
        }

        public decimal CalcularFrete(string preco)
        {
            var precoDecimal = ValidarPreco(preco);
            return CalcularFreteDecimal(precoDecimal);
        }

        private decimal ValidarPreco(string preco)
        {
            preco = preco.Replace(',', '.');

            if (!decimal.TryParse(preco, NumberStyles.Any, CultureInfo.InvariantCulture, out var precoDecimal))
            {
                throw new ArgumentException("O preço deve ser um número válido.");
            }

            if (precoDecimal <= 0)
            {
                throw new ArgumentException("O preço deve ser maior que zero.");
            }

            return precoDecimal;
        }

        private decimal CalcularFreteDecimal(decimal preco)
        {
            return preco * 0.20m;
        }
    }
}