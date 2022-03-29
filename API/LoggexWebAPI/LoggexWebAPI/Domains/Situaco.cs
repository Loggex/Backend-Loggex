using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class Situaco
    {
        public Situaco()
        {
            Manutencos = new HashSet<Manutenco>();
            Rota = new HashSet<Rota>();
        }

        public int IdSituacao { get; set; }
        public string TituloSituacao { get; set; }

        public virtual ICollection<Manutenco> Manutencos { get; set; }
        public virtual ICollection<Rota> Rota { get; set; }
    }
}
