using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idVeiculo, Veiculo VeiculoU)
        {
            throw new NotImplementedException();
        }

        public Veiculo BuscarPorID(int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Veiculo NovoVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
