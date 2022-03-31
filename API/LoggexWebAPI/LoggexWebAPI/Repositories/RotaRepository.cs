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
            return ctx.Rotas.FirstOrDefault(c => c.IdRota == idRota);
        }

        public void Cadastrar(Rota NovaRota)
        {
            if(NovaRota!=null)
                ctx.Rotas.Add(NovaRota);
            ctx.SaveChanges();
        }

        public void Deletar(int idRota)
        {
            Rota rotaBuscada = BuscarPorID(idRota);
            ctx.Rotas.Remove(rotaBuscada);
            ctx.SaveChanges();
        }

        public List<Rota> Listar()
        {
            return ctx.Rotas.ToList();
        }
    }
}
