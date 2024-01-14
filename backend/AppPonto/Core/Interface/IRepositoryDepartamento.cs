using Core.Entidades;

namespace Core.Interface
{
    public interface IRepositoryDepartamento
    {
        Departamento ObterDepartamentoCSV(string caminhoCSV);
    }
}
