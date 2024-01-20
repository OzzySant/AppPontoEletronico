using Core.Entidades;
using Core.Helpers;
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

            var linhas = File.ReadAllLines(caminhoDoArquivo, Encoding.UTF8);

            for(int i = 0; i < linhas.Length; i++)
            {
                if(i == 0)
                    continue;

                var linha = linhas[i];

                var arrayDados = linha.Split(";");

                if (arrayDados.Length >= 7)
                {
                    var funcionario = (Funcionario)arrayDados;

                    var data = arrayDados[3].ConverterStringParaData();
                    var entrada = TimeSpan.Parse(arrayDados[4]);
                    var saida = TimeSpan.Parse(arrayDados[5]);

                    var almocoHorarios = arrayDados[6].Split("-");
                    var almocoEntrada = TimeSpan.Parse(almocoHorarios[0].Trim());
                    var almocoSaida = TimeSpan.Parse(almocoHorarios[1].Trim());

                    var horario = new DiaTrabalhado(data, entrada, almocoEntrada, almocoSaida, saida);

                    // Pega a lista de funcionarios e verifica se existe algum funcionario ja adicionado com codigo
                    if(listaDeFuncionarios.Exists(f => f.Codigo == funcionario.Codigo))
                    {
                        var funcionarioEncontrado = listaDeFuncionarios.First(f => f.Codigo == funcionario.Codigo);
                        // Pega funcionario e adiciona o dia trabalhado
                        funcionarioEncontrado.AdicionarDiaTrabalhado(horario);
                    }
                    else
                    {
                        funcionario.AdicionarDiaTrabalhado(horario);
                        listaDeFuncionarios.Add(funcionario);
                    }

                }
            }

            return listaDeFuncionarios;
        }
    }
}