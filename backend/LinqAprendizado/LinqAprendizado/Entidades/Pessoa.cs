using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAprendizado.Entidades
{
    public class Pessoa
    {
        public int Id { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        

    }

    public class Endereco
    {
        public string Avenida { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }



    }
}
