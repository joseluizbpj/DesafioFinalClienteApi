using DesafioFinalClienteApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFinalClienteApi.Services
{
    public interface IClienteService
    {
        /// <summary>
        /// Lista todos os clientes cadastrados.
        /// </summary>
        /// <returns>Um IEnumarable com os Clientes.</returns>
        IEnumerable<Cliente> ListarTodos();
        /// <summary>
        /// Recebe um ID e busca por um Cliente com este mesmo ID e o retorna.
        /// </summary>
        /// <param name="id">O ID a ser buscado.</param>
        /// <returns>Retorna o Cliente encontrado, se ele existe, ou um objeto Cliente Null se não encontrado.</returns>
        Cliente? BuscarPorId(int id);
        /// <summary>
        /// Recebe uma string e busca por clientes cujo nome contenha a string enviada.
        /// </summary>
        /// <param name="nome">Nome a ser buscado.</param>
        /// <returns>Lista com os clientes encontrados cujo nome contenha a string enviada.</returns>
        IEnumerable<Cliente> BuscarPorNome(string nome);
        /// <summary>
        /// Cria um cliente e o salva no banco de dados.
        /// </summary>
        /// <param name="cliente">O Cliente a ser adicionado.</param>
        /// <returns>O Cliente criado.</returns>
        Cliente Criar(Cliente cliente);
        /// <summary>
        /// Atuliza os dados de um cliente específico.
        /// </summary>
        /// <param name="id">Id do cliente a ser atualizado.</param>
        /// <param name="clienteAtualizado">Objeto cliente com as propriedades a serem atualizadas.</param>
        /// <returns>Um bool indicado se houve ou não atualização. Verdadeiro se foi feito o update, falso se o cliente não for encontrado.</returns>
        bool Atualizar(int id, Cliente clienteAtualizado);
        /// <summary>
        /// Deleta um cliente específico. 
        /// </summary>
        /// <param name="id">O identificador do cliente a ser apagado.</param>
        /// <returns>true se foi executado, falso se o cliente não for encontrado.</returns>
        bool Deletar(int id);
        /// <summary>
        /// Conta quantos clientes estão registrados.
        /// </summary>
        /// <returns>A quantidade de clientes.</returns>
        int Contar();
    }
}