using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Teste_Pratico_IAGRO.Models;
using Teste_Pratico_IAGRO.Service.Interface;

namespace Teste_Pratico_IAGRO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public ProdutoController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet("BuscarLivros")]
        [SwaggerOperation(Summary = "Obter livros", Description = "Obtém uma lista de livros com base nos parâmetros fornecidos.")]
        public IActionResult ObterLivros([FromQuery] LivroParametro parametros)
        {
            try
            {
                var livros = _livroService.ObterLivros(parametros);
                return Ok(livros);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro interno no servidor.", details = ex.Message });
            }
        }

        [HttpGet("CalcularFrete")]
        [SwaggerOperation(Summary = "Calcular frete", Description = "Calcula o frete com base no preço fornecido.")]
        public IActionResult CalcularFrete([FromQuery, SwaggerParameter(Description = "Preço do Livro")] string preco)
        {
            try
            {
                var frete = _livroService.CalcularFrete(preco);
                return Ok(frete);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocorreu um erro interno no servidor.", details = ex.Message });
            }
        }
    }
}