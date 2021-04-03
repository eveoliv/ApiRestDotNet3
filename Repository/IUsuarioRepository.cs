using System.Linq;
using ApiUsuarios.Models;
using ApiUsuarios.Context;
using System.Collections.Generic;

namespace ApiUsuarios.Repository
{
    public interface IUsuarioRepository
    {
        void Add(Usuario user);
        IEnumerable<Usuario> GetAll();
        Usuario Find(long id);
        void Remove(long id);
        void Update(Usuario user);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext context;

        public UsuarioRepository(UsuarioDbContext context)
        {
            this.context = context;
        }

        public void Add(Usuario user)
        {
            context.Usuarios.Add(user);
            context.SaveChanges();
        }

        public Usuario Find(long id)
        {
            return context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return context.Usuarios.ToList();
        }

        public void Remove(long id)
        {
            var user = Find(id);
            
            if (user != null)
            {
                context.Usuarios.Remove(user);
                context.SaveChanges();
            }            
        }

        public void Update(Usuario user)
        {
            context.Usuarios.Update(user);
            context.SaveChanges();
        }
    }
}
