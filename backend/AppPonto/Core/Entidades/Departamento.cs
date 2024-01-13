using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Departamento
    {

        public string Nome { get; set; }
        public string Mes { get; set; }
        public int Ano { get; set; }
        /// <summary>
        /// Um departamento tem muitos funcionarios, um dpto para muitos funcionarios
        /// </summary>
        public List<Funcionario> Funcionarios { get; set; }
    }
}
