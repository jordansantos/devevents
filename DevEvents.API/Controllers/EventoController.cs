using DevEvents.API.Entidades;
using DevEvents.API.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace DevEvents.API.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class EventoController : ControllerBase
  {
    private readonly DevEventsContext _context;

    public EventoController(DevEventsContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
      var eventos = _context.Eventos
        .Include(e => e.Categoria)
        .Include(e => e.Usuario)
        .Include(e => e.Inscricoes)
        .ToList();
      
      return Ok(eventos);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarEventoPeloId(int id)
    {
      var evento = _context.Eventos
        .Include(e => e.Categoria)
        .Include(e => e.Usuario)
        //.Include(e => e.Inscricoes)
        .SingleOrDefault(e => e.Id == id);

      if (evento == null)
      {
        return NotFound();
      }

      return Ok(evento);
    }

    [HttpPost]
    public IActionResult CadastrarEvento([FromBody] Evento evento)
    {
      evento.DataCadastro = DateTime.Now;
      _context.Eventos.Add(evento);
      _context.SaveChanges();
      
      return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarEvento(int id, [FromBody] Evento eventoForm)
    {
      var evento = _context.Eventos.SingleOrDefault(ev => ev.Id == id);

      if (evento == null)
      {
        return NoContent();
      }

      if (eventoForm.Titulo != null || eventoForm.Titulo != "")
      {
        evento.Titulo = eventoForm.Titulo;
      }

      if (eventoForm != null)
      {
        evento.IsAtivo = eventoForm.IsAtivo;
      }

      _context.Eventos.Update(evento);
      _context.SaveChanges();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult CancelarEvento(int id)
    {
      var evento = _context.Eventos.SingleOrDefault(ev => ev.Id == id);

      if (evento == null)
      {
        return NotFound();
      }

      evento.IsAtivo = false;

      _context.Eventos.Update(evento);
      _context.SaveChanges();

      return NoContent();
    }

    [HttpPost("{idEvento}/usuarios/{idUsuario}/inscrever")]
    public IActionResult Inscrever(int idEvento, int idUsuario, [FromBody] Inscricao inscricao)
    {
      var evento = _context.Eventos.SingleOrDefault(ev => ev.Id == idEvento);

      if (evento == null || !evento.IsAtivo)
      {
        return BadRequest();
      }

      _context.Inscricoes.Add(inscricao);
      _context.SaveChanges();

      return NoContent();
    }
  }
}
