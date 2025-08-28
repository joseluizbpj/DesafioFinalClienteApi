using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DesafioFinalClienteApi.Models;

namespace DesafioFinalClienteApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();
    }
}