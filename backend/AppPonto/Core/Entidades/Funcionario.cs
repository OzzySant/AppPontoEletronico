﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Funcionario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double ValorDaHora { get; set; }
        public List<DiaTrabalhado> DiasTrabalhados { get; set; }

        public Funcionario(int codigo, string nome, double valorDaHora)
        {
            Codigo = codigo;
            Nome = nome;
            ValorDaHora = valorDaHora;
            // DiasTrabalhados = new List<DiaTrabalhado>();
        }


        public static implicit operator Funcionario(string[] dados)
        {
            var codigo = dados[0];
            var nome = dados[1];
            var valor = double.Parse(dados[2]);
            
            return new Funcionario(int.Parse(codigo), nome, valor);
        }



        public void AdicionarDiaTrabalhado(DiaTrabalhado diaTrabalhado)
        {
            DiasTrabalhados.Add(diaTrabalhado);
        }
    }
}
