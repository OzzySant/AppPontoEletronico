using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IRepositoryDepartamento
    {
        Departamento ObterDepartamentoCSV(string caminhoCSV);

    }
}
