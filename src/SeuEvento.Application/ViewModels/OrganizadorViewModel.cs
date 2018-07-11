﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SeuEvento.Application.ViewModels
{
  public class OrganizadorViewModel
  {
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome é requerido")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O CPF é requerido")]
    [StringLength(11)]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O e-mail é requerido")]
    [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
    public string Email { get; set; }
  }
}