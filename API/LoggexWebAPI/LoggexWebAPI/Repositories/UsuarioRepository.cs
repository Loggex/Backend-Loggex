using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idUsuario, Usuario UsuarioU)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarPorID(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
