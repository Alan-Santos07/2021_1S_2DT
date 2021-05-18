using System;
using System.Collections.Generic;

#nullable disable

namespace senai.inlock.webApi.Domains
{
    public partial class Estudio
    {
        public Estudio()
        {
            Jogos = new HashSet<Jogo>();
        }

        public int IdEstudio { get; set; }
        public string NomeEstudio { get; set; }

        public virtual ICollection<Jogo> Jogos { get; set; }
    }
}
