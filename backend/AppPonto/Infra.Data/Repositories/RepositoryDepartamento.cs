using Core.Entidades;
using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositorys
{
    public class RepositoryDepartamento : IRepositoryDepartamento
    {
        public Departamento ObterDepartamentoCSV(string caminhoCSV)
        {
            if (!File.Exists(caminhoCSV))
                throw new InvalidOperationException("Erro ao Achar o caminho do arquivo");

            var arquivo = new FileInfo(caminhoCSV);
            var nomeAquivo = arquivo.Name.Contains("-") ? arquivo.Name.Split("-") : Array.Empty<string>();

            if (nomeAquivo.Length >= 2)
            {
                var nomeDepartamento = nomeAquivo[0];
                var mesVigencia = nomeAquivo[1];
                var anoVigencia = nomeAquivo[2].Replace(arquivo.Extension, "");

                return new Departamento
                {
                    Nome = nomeDepartamento,
                    Mes = mesVigencia,
                    Ano = int.Parse(anoVigencia),
                    Funcionarios = ObterFuncionarios(caminhoCSV)
                };
            }
            else
            {
                throw new InvalidOperationException("Nome do arquivo não está com esperado, Exemplo: 'nome-mes-ano.csv'");
            }
        }

        private List<Funcionario> ObterFuncionarios(string caminhoDoArquivo)
        {
            var listaDeFuncionarios = new List<Funcionario>();

            var linhas = File.ReadAllLines(caminhoDoArquivo);

            foreach (var linha in linhas)
            {
                // Verificar se a linha lida é a primeira, caso sim, ignora-la, caso não seguir o fluxo.
                // TAREFA PRA FAZER

                var arrayDados = linha.Split(";");

                if (arrayDados.Length >= 7)
                {
                    var funcionario = (Funcionario)arrayDados;

                    var data = DateTime.Parse(arrayDados[3]);
                    var entrada = TimeSpan.Parse(arrayDados[4]);
                    var saida = TimeSpan.Parse(arrayDados[5]);

                    var almocoHorarios = arrayDados[6].Split("-");
                    var almocoEntrada = TimeSpan.Parse(almocoHorarios[0]);
                    var almocoSaida = TimeSpan.Parse(almocoHorarios[1]);

                    var horario = new DiaTrabalhado(data, entrada, almocoEntrada, almocoSaida, saida);

                    funcionario.AdicionarDiaTrabalhado(horario);
                    listaDeFuncionarios.Add(funcionario);
                }
            }

            return listaDeFuncionarios;
        }
    }
}
