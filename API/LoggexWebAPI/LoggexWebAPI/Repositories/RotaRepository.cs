using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class RotaRepository : IRotaRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idRota, Rota RotaU)
        {
            throw new NotImplementedException();
        }

        public Rota BuscarPorID(int idRota)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Rota NovaRota)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idRota)
        {
            throw new NotImplementedException();
        }

        public List<Rota> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
