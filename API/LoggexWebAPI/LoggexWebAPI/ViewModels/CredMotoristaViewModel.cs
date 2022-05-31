using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.ViewModels
{
    public class CredMotoristaViewModel
    {
        [Required(ErrorMessage = "informe o telefone do usuário!")]
        public string Telefone { get; set; }

        public string Nome { get; set; }
        public int idTipoUsuario { get; set; }
        public string Sexo { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }


    }
}
