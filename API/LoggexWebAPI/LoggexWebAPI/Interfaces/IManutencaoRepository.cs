using LoggexWebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggexWebAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório de manutenções
    /// </summary>
    interface IManutencaoRepository
    {
        /// <summary>
        /// Lista todas as manutenções
        /// </summary>
        /// <returns>Uma lista de manutenções</returns>
        List<Manutenco> Listar();

        /// <summary>
        /// Busca uma manutencao a partir de um ID
        /// </summary>
        /// <param name="idManutencao">ID da manutencao a ser buscada</param>
        /// <returns>Uma manutencao encontrada</returns>
        Manutenco BuscarPorID(int idManutencao);

        /// <summary>
        /// Cadastra uma nova manutencao
        /// </summary>
        /// <param name="NovaManutencao">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(Manutenco NovaManutencao);

        /// <summary>
        /// Atualiza os dados de uma manutencao
        /// </summary>
        /// <param name="idManutencao">ID da manutencao a ser atualizada</param>
        /// <param name="manutencaoU">Objeto com as informações a serem atualizadas</param>
        void Atualizar(int idManutencao, Manutenco manutencaoU);

        /// <summary>
        /// Deleta uma manutencao
        /// </summary>
        /// <param name="idManutencao">ID da manutencao a ser deletada</param>
        void Deletar(int idManutencao);
    }
}
