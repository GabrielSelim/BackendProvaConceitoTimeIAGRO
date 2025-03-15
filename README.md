Um cliente tem necessidade de buscar livros em um catálogo. Esse cliente quer ler e buscar esse catálogo de um arquivo JSON, e esse arquivo não pode ser modificado. Então com essa informação, é preciso desenvolver:

    Criar uma API para buscar produtos no arquivo JSON disponibilizado.
    Que seja possível buscar livros por suas especificações(autor, nome do livro ou outro atributo)
    É preciso que o resultado possa ser ordenado pelo preço.(asc e desc)
    Disponibilizar um método que calcule o valor do frete em 20% o valor do livro.

Será avaliado no desafio:

    Organização de código;
    Manutenibilidade;
    Princípios de orientação à objetos;
    Padrões de projeto;
    Teste unitário

Para nos enviar o código, crie um fork desse repositório e quando finalizar, mande um pull-request para nós.

O projeto deve ser desenvolvido em C#, utilizando o .NET Core 3.1 ou superior.

Gostaríamos que fosse evitado a utilização de frameworks, e que tivesse uma explicação do que é necessário para funcionar o projeto e os testes.

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
# API de Busca de Livros

Na parte da API de Busca de Livros, implementei uma solução que permite a leitura e busca de livros em um catálogo armazenado em um arquivo JSON. A API oferece as seguintes funcionalidades:

1.	Busca de Livros: A API permite buscar livros no catálogo JSON por diferentes especificações, como autor, nome do livro ou outros atributos.
2.	Ordenação de Livros: A API permite ordenar os resultados da busca por preço, em ordem crescente ou decrescente.
3.	Cálculo de Frete: A API disponibiliza um método para calcular o valor do frete, que é 20% do valor do livro.

- A API realiza validações para garantir que os parâmetros de entrada sejam válidos e que os resultados da busca sejam consistentes.
- Existem Exception personalizadas para tratar erros específicos, como parâmetros inválidos ou livros não encontrados.


# Teste Unitário
Eu utilizei o Framework UNit Test para realizar os testes unitários, pois é uma ferramenta que já vem integrada com o Visual Studio e é muito fácil de utilizar.

Para utilizar o Teste Unitário do Visual Studio, siga os passos abaixo:
   - Abra o `Teste` no Visual Studio (`Teste` > `Gerenciador de Testes`).
   - Clique em `Executar Todos os Testes na Exibição`.

Estrutura dos Testes Unitários

Os testes unitários estão localizados no projeto `TestePraticoIAGRO.Tests`. Eles verificam o comportamento dos métodos principais, como `CalcularFrete` na classe `LivroService`.

Os Testes Unitários foram organizados em 2 classes:

- DeveCalcularFreteCorretamenteParaPrecosValidos:
  - Descrição: Verifica se o método `CalcularFrete` retorna o valor correto do frete para diferentes formatos de preço válidos.
  - Exemplo de Cenário Testado:
    - Preço "20,0" deve retornar frete 4.0

- DeveLancarArgumentExceptionParaPrecosInvalidos:
  - Descrição: Verifica se o método `CalcularFrete` lança uma exceção `ArgumentException` para preços inválidos.
  - Exemplo de Cenário Testado:
    - Preço "abc" deve lançar `ArgumentException`