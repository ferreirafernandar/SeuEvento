using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SeuEvento.Application.ViewModels
{
  public class EnderecoViewModel
  {
    public SelectList Estados()
    {
      return new SelectList(EstadoViewModel.ListarEstados(), "Uf", "Nome");
    }

    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Logradouro { get; set; }

    public string Numero { get; set; }

    public string Complemento { get; set; }

    public string Bairro { get; set; }

    public string Cep { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }
    public Guid EventoId { get; set; }

    public override string ToString()
    {
      return Logradouro + ", " + Numero + " - " + Bairro + ", " + Cidade + " - " + Estado;
    }
  }
}