using System;
using SeuEvento.Application.ViewModels;

namespace SeuEvento.Application.Interfaces
{
  public interface IOrganizadorAppService : IDisposable
  {
    void Registrar(OrganizadorViewModel organizadorViewModel);
  }
}