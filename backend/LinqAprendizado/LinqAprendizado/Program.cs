using LinqAprendizado;
using LinqAprendizado.Entidades;
using Microsoft.VisualBasic;

RepositorioPessoa repositorioPessoa = new RepositorioPessoa();

var pessoas = repositorioPessoa.ObterPessoas();

// LINQ
// filtrar pessoas com id = 1

// filtrando por id pessoa
// var pessoaFiltrada = pessoas.Where(x => x.Id == 1);

// filtrando por data de nascimento
// var pessoaFiltrada = pessoas.Where(x => x.DataNascimento >= new DateTime(1990, 01, 01));

// Filtrar pessoas com endereços que contem avenida no nome
var pessoaFiltrada = pessoas.Where(x => x.Enderecos.Exists(e => e.Avenida.Contains("Av")));


foreach (var pessoa in pessoaFiltrada)
{
    Console.WriteLine(pessoa.Nome);
    Console.WriteLine(pessoa.Id);
    Console.WriteLine(pessoa.DataNascimento);
    Console.WriteLine(pessoa.Altura);
    Console.WriteLine(pessoa.Peso);
    Console.WriteLine(pessoa.Enderecos.Count);

}