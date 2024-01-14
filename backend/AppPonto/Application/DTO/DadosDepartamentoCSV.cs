using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Application.DTO;

public class DadosDepartamentoCSV
{
    [Required]
    public IFormFile Arquivo {  get; set; }
    [Required]
    public string Usuario { get; set; }
}
