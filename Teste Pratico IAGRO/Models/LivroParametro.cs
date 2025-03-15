using System.ComponentModel.DataAnnotations;
using CommandLine.Text;
using NHibernate.Criterion;
using Swashbuckle.AspNetCore.Annotations;

namespace Teste_Pratico_IAGRO.Models
{
    public class LivroParametro
    {
        [Display(Name = "Nome do Autor")]
        [SwaggerSchema(Description = "Nome do Autor")]
        public string? Autor { get; set; }

        [Display(Name = "Nome do Livro")]
        [SwaggerSchema(Description = "Nome do Livro")]
        public string? Nome { get; set; }

        [Display(Name = "Gênero do Livro")]
        [SwaggerSchema(Description = "Gênero do Livro")]
        public string? Genero { get; set; }

        [Display(Name = "Ordenar Por (asc/desc)")]
        [SwaggerSchema(Description = "Ordenar Por (asc/desc)")]
        public string? OrdenarPor { get; set; }
    }
}