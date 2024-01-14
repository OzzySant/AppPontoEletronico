using Application.DTO;
using Application.Interfaces;
using Core.Entidades;
using Core.Interface;

namespace Application.Services;

public class ServiceDepartamento : IServiceDepartamento
{
    private readonly IRepositoryDepartamento _repository;
    private readonly IServiceUsuarioQualificado _serviceUsuarioQualificado;

    public ServiceDepartamento(IRepositoryDepartamento repository,
        IServiceUsuarioQualificado serviceUsuarioQualificado)
    {
        _repository = repository;
        _serviceUsuarioQualificado = serviceUsuarioQualificado;
    }

    public Departamento ObterDepartamentoCSV(string caminhoCsv, string usuario)
    {
        if (!_serviceUsuarioQualificado.UsuarioQualificado(usuario))
            throw new Exception("Usuario não qualificado para operação!");

        return _repository.ObterDepartamentoCSV(caminhoCsv);
    }
}
