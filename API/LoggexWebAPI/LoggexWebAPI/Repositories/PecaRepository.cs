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
            Peca pecaBuscada = BuscarPorID(idPeca);

            if(PecaU.IdTipoPeca != null) { pecaBuscada.IdTipoPeca = PecaU.IdTipoPeca; }
            if(PecaU.IdTipoPecaNavigation != null) { pecaBuscada.IdTipoPecaNavigation = PecaU.IdTipoPecaNavigation; }
            if(PecaU.IdVeiculo != null) { pecaBuscada.IdVeiculo = PecaU.IdVeiculo; }
            if(PecaU.IdVeiculoNavigation != null) { pecaBuscada.IdVeiculoNavigation = PecaU.IdVeiculoNavigation; }
            if(PecaU.ImgPeca != null) { pecaBuscada.ImgPeca = PecaU.ImgPeca; }
            if(PecaU.LogAlteracaos != null) { pecaBuscada.LogAlteracaos = PecaU.LogAlteracaos; }

            ctx.SaveChanges();
        }

        public Peca BuscarPorID(int idPeca)
        {
            return ctx.Pecas.FirstOrDefault(c => c.IdPeca == idPeca);
        }

        public void Cadastrar(Peca NovaPeca)
        {
            ctx.Pecas.Add(NovaPeca);
            ctx.SaveChanges();
        }

        public void Deletar(int idPeca)
        {
            Peca pecaBuscada = BuscarPorID(idPeca);

            ctx.Pecas.Remove(pecaBuscada);
            ctx.SaveChanges();
        }

        public List<Peca> Listar()
        {
            return ctx.Pecas.ToList();
        }
    }
}
