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
            Manutenco manutencoBuscada = BuscarPorID(idManutencao);

            if(manutencaoU.IdManutencao != null) { manutencoBuscada.IdManutencao = manutencaoU.IdManutencao; }
            if(manutencaoU.IdSituacao != null) { manutencoBuscada.IdSituacao = manutencaoU.IdSituacao; }
            if(manutencaoU.IdVeiculo != null) { manutencoBuscada.IdVeiculo = manutencaoU.IdVeiculo; }
            if(manutencaoU.Descricao != null) { manutencoBuscada.Descricao = manutencaoU.Descricao; }

            ctx.Manutencoes.Update(manutencoBuscada);
            ctx.SaveChanges();
        }

        public Manutenco BuscarPorID(int idManutencao)
        {
            return ctx.Manutencoes.FirstOrDefault(c => c.IdManutencao == idManutencao);
        }

        public void Cadastrar(Manutenco NovaManutencao)
        {
            if(NovaManutencao != null) {
                ctx.Manutencoes.Add(NovaManutencao);
            }

            ctx.SaveChanges();

        }

        public void Deletar(int idManutencao)
        {
            Manutenco manutencaoBuscada = BuscarPorID(idManutencao);

            ctx.Manutencoes.Remove(manutencaoBuscada);
            ctx.SaveChanges();
        }

        public List<Manutenco> Listar()
        {
            return ctx.Manutencoes.ToList();
        }
    }
}
