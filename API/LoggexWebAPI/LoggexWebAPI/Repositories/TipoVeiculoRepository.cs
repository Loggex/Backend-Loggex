using LoggexWebAPI.Contexts;
using LoggexWebAPI.Domains;
using LoggexWebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Repositories
{
    public class TipoVeiculoRepository : ITipoVeiculoRepository
    {
        LoggexContext ctx = new LoggexContext();

        public void Atualizar(int idTiposVeiculo, TiposVeiculo TiposVeiculoU)
        {
            throw new NotImplementedException();
        }

        public TiposVeiculo BuscarPorID(int idTiposVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TiposVeiculo NovoTiposVeiculo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idTiposVeiculo)
        {
            throw new NotImplementedException();
        }

        public List<TiposVeiculo> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
