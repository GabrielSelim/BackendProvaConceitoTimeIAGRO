namespace Teste_Pratico_IAGRO.Models
{
    public class Livro
    {
        public int id { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public Especificacoes specifications { get; set; }
    }
}