using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idManutencao, Manutenco manutencaoU)
        {
            throw new NotImplementedException();
        }

        public Manutenco BuscarPorID(int idManutencao)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Manutenco NovaManutencao)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idManutencao)
        {
            throw new NotImplementedException();
        }

        public List<Manutenco> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
