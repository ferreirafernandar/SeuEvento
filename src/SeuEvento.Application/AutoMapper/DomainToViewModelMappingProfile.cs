using AutoMapper;
using SeuEvento.Application.ViewModels;
using SeuEvento.Domain.Eventos;
using SeuEvento.Domain.Organizadores;

namespace SeuEvento.Application.AutoMapper
{
  public class DomainToViewModelMappingProfile : Profile
  {
    public DomainToViewModelMappingProfile()
    {
      CreateMap<Evento, EventoViewModel>();
      CreateMap<Endereco, EnderecoViewModel>();
      CreateMap<Categoria, CategoriaViewModel>();
      CreateMap<Organizador, OrganizadorViewModel>();
    }
  }
}