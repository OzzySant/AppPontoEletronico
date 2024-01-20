using System.IO;
using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IServiceDepartamento _service;

        public DepartamentoController(IServiceDepartamento service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ObterDepartamentos([FromQuery] string usuario)
        {
            return Ok(_service.ObterTodosDepartamentos(usuario));
        }

        [HttpPost("ObterDadosDepartamentoCSV")]
        public IActionResult ObterDadosDepartamentoCSV([FromForm] DadosDepartamentoCSV dados)
        {
            var caminho = Path.Combine(Path.GetTempPath(), dados.Arquivo.FileName);

            using (FileStream fileStream = System.IO.File.Create(caminho))
            {
                dados.Arquivo.CopyTo(fileStream);
            }

            var departamento = _service.ObterDepartamentoCSV(caminho, dados.Usuario);

            return Ok(departamento);
        }
    }
}
