using System;
using System.Collections.Generic;

#nullable disable

namespace LoggexWebAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            LogAlteracaos = new HashSet<LogAlteracao>();
            Motorista = new HashSet<Motorista>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string NumCelular { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Senha { get; set; }
        public string ImgPerfil { get; set; }
        public string Cpf { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<LogAlteracao> LogAlteracaos { get; set; }
        public virtual ICollection<Motorista> Motorista { get; set; }
    }
}
