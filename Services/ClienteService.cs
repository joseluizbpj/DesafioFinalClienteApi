using DesafioFinalClienteApi.Data;
using DesafioFinalClienteApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioFinalClienteApi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }
        public bool Atualizar(int id, Cliente clienteAtualizado)
        {
            var clienteBd = _context.Clientes.Find(id);
            if (clienteBd == null)
                return false;

            clienteBd.Email = clienteAtualizado.Email;
            clienteBd.Nome = clienteAtualizado.Nome;
            _context.SaveChanges();
            return true;

        }

        public Cliente? BuscarPorId(int id)
        => _context.Clientes.Find(id);

        public IEnumerable<Cliente> BuscarPorNome(string nome)
        => _context.Clientes.Where(c => c.Nome.Contains(nome)).ToList();

        public int Contar()
        => _context.Clientes.Count();

        public Cliente Criar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public bool Deletar(int id)
        {
            var clienteBd = _context.Clientes.Find(id);
            if (clienteBd == null)
                return false;
            _context.Clientes.Remove(clienteBd);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Cliente> ListarTodos()
        => _context.Clientes.AsNoTracking().ToList();
    }
}