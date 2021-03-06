using System;
using System.Collections.Generic;

namespace DevEvents.API.Entidades
{
  public class Usuario
  {
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool IsAtivo { get; set; }
    public List<Inscricao> Inscricoes { get; set; }
  }
}
