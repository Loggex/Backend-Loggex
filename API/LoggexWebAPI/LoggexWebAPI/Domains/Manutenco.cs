using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class Manutenco
    {
        public int IdManutencao { get; set; }
        public int? IdSituacao { get; set; }
        public int? IdVeiculo { get; set; }
        public string Descricao { get; set; }

        public virtual Situaco IdSituacaoNavigation { get; set; }
        public virtual Veiculo IdVeiculoNavigation { get; set; }
    }
}
