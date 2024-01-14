using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Services
{
    public class ServiceUsuarioQualificado : IServiceUsuarioQualificado
    {
        public bool UsuarioQualificado(string usuario)
        {
            // posso fazer uma chamado no banco, verifica o tipo do usuario, vai depender da logida de negocio.
            // porém uma alternativa para essa verificação seria no inicio da requisição implementar um middlware
            // de autenficacao.

            if (usuario.Contains("User") || string.IsNullOrEmpty(usuario))
                return false;

            return true;
        }
    }
}
