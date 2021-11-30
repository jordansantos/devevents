using DevEvents.API.Entidades;
using DevEvents.API.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DevEvents.API.Controllers
{
  [ApiController]
  [Route("categoria")]
  public class CategoriaController : ControllerBase
  {
    private readonly DevEventsContext _context;

    public CategoriaController(DevEventsContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult obterTodos()
    {
      return Ok(_context.Categorias);
    }

    [HttpGet("{id}")]
    public IActionResult ObterCategoria(int id)
    {
      var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

      if (categoria != null)
      {
        return Ok(categoria);
      }

      return NotFound();
    }

    [HttpPost]
    public IActionResult Cadastrar([FromBody] Categoria categoriaForm)
    {
      var categoria = new Categoria();

      categoria.Id = categoriaForm.Id;
      categoria.Descricao = categoriaForm.Descricao;

      _context.Categorias.Add(categoria);
      _context.SaveChanges();

      return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] Categoria categoriaForm)
    {
      var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);

      if (categoria == null)
      {
        return NotFound();
      }

      categoria.Descricao = categoriaForm.Descricao;
      _context.Categorias.Update(categoria);
      _context.SaveChanges();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
      return Ok();
    }
  }
}
