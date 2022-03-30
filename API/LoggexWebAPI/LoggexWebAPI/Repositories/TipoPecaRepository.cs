using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class TipoPecaRepository : ITipoPecaRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idTiposPeca, TiposPeca TiposPecaU)
        {
            throw new NotImplementedException();
        }

        public TiposPeca BuscarPorID(int idTiposPeca)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TiposPeca NovoTiposPeca)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idTiposPeca)
        {
            throw new NotImplementedException();
        }

        public List<TiposPeca> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
