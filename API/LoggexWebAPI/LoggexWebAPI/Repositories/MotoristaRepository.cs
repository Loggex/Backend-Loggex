using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class MotoristaRepository : IMotoristaRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idMotorista, Motorista MotoristaU)
        {
            throw new NotImplementedException();
        }

        public Motorista BuscarPorID(int idMotorista)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Motorista NovoMotorista)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idMotorista)
        {
            throw new NotImplementedException();
        }

        public List<Motorista> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
