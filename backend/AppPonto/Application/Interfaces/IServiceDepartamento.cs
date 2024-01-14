using Core.Entidades;

namespace Application.Interfaces;

public interface IServiceDepartamento
{
    Departamento ObterDepartamentoCSV(string caminhoCsv, string usuario);
}
