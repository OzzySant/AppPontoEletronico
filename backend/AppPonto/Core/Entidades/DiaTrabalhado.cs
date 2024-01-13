using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class DiaTrabalhado
    {
        public DateTime DataDoRegistro { get; set; }

        public TimeSpan HoraDaEntrada { get; set; }

        public TimeSpan HoraEntradaAlmoco { get; set; }

        public TimeSpan HoraSaidaAlmoco { get; set; }

        public TimeSpan HoraDaSaida { get; set; }

        public DiaTrabalhado(DateTime dataDoRegistro, TimeSpan horaDaEntrada, TimeSpan horaEntradaAlmoco, TimeSpan horaSaidaAlmoco, TimeSpan horaDaSaida)
        {
            DataDoRegistro = dataDoRegistro;
            HoraDaEntrada = horaDaEntrada;
            HoraEntradaAlmoco = horaEntradaAlmoco;
            HoraSaidaAlmoco = horaSaidaAlmoco;
            HoraDaSaida = horaDaSaida;
        }
    }
}
