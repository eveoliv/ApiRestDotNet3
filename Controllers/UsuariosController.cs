using ApiUsuarios.Models;
using ApiUsuarios.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiUsuarios.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository repository;

        public UsuariosController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}", Name ="GetUsuario")]
        public IActionResult GetById(long id)
        {
            var usuario = repository.Find(id);
            if (usuario == null)
                return NotFound();

            return new ObjectResult(usuario);            
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            repository.Add(usuario);

            return CreatedAtRoute("GetUsuario", new {id=usuario.UsuarioId}, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.UsuarioId != id)
                return BadRequest();

            var user = repository.Find(id);
            if (user == null)
                return NotFound();

            user.Nome = usuario.Nome;
            user.Email = usuario.Email;

            repository.Update(user);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = repository.Find(id);
            if (user == null)
                return NotFound();

            repository.Remove(id);

            return new NoContentResult();
        }
    }
}
