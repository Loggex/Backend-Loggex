using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idTiposUsuario, TiposUsuario TiposUsuarioU)
        {
            throw new NotImplementedException();
        }

        public TiposUsuario BuscarPorID(int idTiposUsuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TiposUsuario NovoTiposUsuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idTiposUsuario)
        {
            throw new NotImplementedException();
        }

        public List<TiposUsuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
