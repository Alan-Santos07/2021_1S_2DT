using System;
using System.Collections.Generic;

#nullable disable

namespace senai.inlock.webApi.Domains
{
    public partial class Jogo
    {
        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
        public int? IdEstudio { get; set; }

        public virtual Estudio IdEstudioNavigation { get; set; }
    }
}
