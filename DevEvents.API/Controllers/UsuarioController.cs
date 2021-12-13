using DevEvents.API.Entidades;
using DevEvents.API.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DevEvents.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsuarioController : ControllerBase
  {
    private readonly DevEventsContext _context;

    public UsuarioController(DevEventsContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
      return Ok(_context.Usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarUsuarioPeloId(int id)
    {
      var usuario = _context.Usuarios.FirstOrDefault( usuario => usuario.Id == id);

      if (usuario == null)
      {
        return NotFound();
      }

      return Ok(usuario);
    }

    [HttpPost]
    public IActionResult CadastrarUsuario([FromBody] Usuario usuarioForm)
    {
      usuarioForm.DataCadastro = DateTime.Now;
      _context.Usuarios.Add(usuarioForm);
      _context.SaveChanges();

      return CreatedAtAction(nameof(BuscarTodos), new { Id = usuarioForm.Id });
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarUsuario(int id, [FromBody] Usuario usuarioForm)
    {
      var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

      if (usuario == null)
      {
        return NotFound();
      }

      if (usuarioForm.NomeCompleto != null && usuarioForm.NomeCompleto != "")
      {
        usuario.NomeCompleto = usuarioForm.NomeCompleto;
      }

      if (usuarioForm.Email != null && usuarioForm.Email != "")
      {
        usuario.Email = usuarioForm.Email;
      }

      _context.Usuarios.Update(usuario);
      _context.SaveChanges();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarUsuario(int id)
    {
      var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

      if (usuario == null)
      {
        return NotFound();
      }

      _context.Usuarios.Remove(usuario);
      _context.SaveChanges();

      return Ok();
    }
  }
}
