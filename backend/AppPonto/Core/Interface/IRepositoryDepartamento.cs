using Core.Entidades;
using System.Reflection.Metadata.Ecma335;

namespace Core.Interface
{
    public interface IRepositoryDepartamento
    {
        Departamento ObterDepartamentoCSV(string caminhoCSV);

        List<Departamento> ObterDeparamentos();
    }
}
