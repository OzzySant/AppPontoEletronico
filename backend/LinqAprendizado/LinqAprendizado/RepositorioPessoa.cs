using LinqAprendizado.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAprendizado
{
    public class RepositorioPessoa
    {
        public static  List<Pessoa> Pessoas { get; set; }
        public RepositorioPessoa()
        {
            Pessoas = new List<Pessoa>();
        }

        public List<Pessoa> ObterPessoas()
        {
            var pessoa = new Pessoa()
            {
                Id = 1,
                Nome = "Ozzy",
                DataNascimento = new DateTime(1993, 12, 11),
                Enderecos = new List<Endereco>()
                {
                    new Endereco()
                    {
                        Avenida = "Av. das Nações Unidas",
                        Cep = "00000-000",
                        Numero = 100
                    }
                },
                Altura = 1.80f,
                Peso = 80.0f
            };

            Pessoas.Add(pessoa);

            var pessoa2 = new Pessoa()
            {
                Id = 2,
                Nome = "Matheus",
                DataNascimento = new DateTime(1992, 12, 11),
                Enderecos = new List<Endereco>()
                {
                    new Endereco()
                    {
                        Avenida = "Av. das Nações Unidas",
                        Cep = "00002-000",
                        Numero = 100
                    }
                },
                Altura = 1.80f,
                Peso = 80.0f
            };

            Pessoas.Add(pessoa2);

            var pessoa3 = new Pessoa()
            {
                Id = 3,
                Nome = "João",
                DataNascimento = new DateTime(1991, 12, 11),
                Enderecos = new List<Endereco>()
                {
                    new Endereco()
                    {
                        Avenida = "trevessa das Nações Unidas",
                        Cep = "00003-000",
                        Numero = 100
                    }
                },
                Altura = 1.80f,
                Peso = 80.0f
            };

            Pessoas.Add(pessoa3);

            var pessoa4 = new Pessoa()
            {
                Id = 4,
                Nome = "Maria",
                DataNascimento = new DateTime(1980, 12, 11),
                Enderecos = new List<Endereco>()
                {
                    new Endereco()
                    {
                        Avenida = "rua das Nações Unidas",
                        Cep = "00004-000",
                        Numero = 100
                    }
                },
                Altura = 1.50f,
                Peso = 80.0f
            };

            Pessoas.Add(pessoa4);

            return Pessoas;
        }
    }
}
