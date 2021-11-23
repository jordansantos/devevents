using DevEvents.API.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevEvents.API.Controllers
{
  [ApiController]
  [Route("[categoria]")]
  public class CategoriaController : ControllerBase
  {
    [HttpGet]
    public IActionResult obterTodos()
    {
      return Ok("Chamando Método Corretamente!!!");
    }

    [HttpGet("{id}")]
    public IActionResult ObterCategoria(int id)
    {
      return NotFound();
    }

    [HttpPost]
    public IActionResult Cadastrar([FromBody] Categoria categoria)
    {
      return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar(int id, [FromBody] Categoria categoria)
    {
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
      return Ok();
    }
  }
}
