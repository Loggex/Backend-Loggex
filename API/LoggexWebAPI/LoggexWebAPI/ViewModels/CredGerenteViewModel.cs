using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.ViewModels
{
    public class CredGerenteViewModel
    {
        [Required(ErrorMessage = "informe o email do usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "informe a senha do usuário!")]
        public string Senha { get; set; }
    }
}
