using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idSituacao, Situaco SituacoU)
        {
            throw new NotImplementedException();
        }

        public Situaco BuscarPorID(int idSituacao)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Situaco Novasituacao)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idSituacao)
        {
            throw new NotImplementedException();
        }

        public List<Situaco> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
