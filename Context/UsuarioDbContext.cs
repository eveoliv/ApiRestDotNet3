using ApiUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Context
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options) : base(options){}

        public DbSet<Usuario> Usuarios {get; set; }
    }
}