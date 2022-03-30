using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class PecaRepository: IPecaRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idPeca, Peca PecaU)
        {
            throw new NotImplementedException();
        }

        public Peca BuscarPorID(int idPeca)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Peca NovaPeca)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idPeca)
        {
            throw new NotImplementedException();
        }

        public List<Peca> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
