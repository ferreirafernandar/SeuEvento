using System;
using AutoMapper;
using SeuEvento.Application.ViewModels;
using SeuEvento.Domain.Eventos.Commands;
using SeuEvento.Domain.Organizadores.Commands;

namespace SeuEvento.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Evento

            CreateMap<EventoViewModel, RegistrarEventoCommand>()
                .ConstructUsing(c => new RegistrarEventoCommand(c.Nome, c.DescricaoCurta, c.DescricaoLonga, c.DataInicio, c.DataFim, c.Gratuito, c.Valor, c.Online, c.NomeEmpresa, c.OrganizadorId, c.CategoriaId,
                                                                new IncluirEnderecoEventoCommand(c.Endereco.Id, c.Endereco.Logradouro, c.Endereco.Numero, c.Endereco.Complemento, c.Endereco.Bairro, c.Endereco.Cep, c.Endereco.Cidade, c.Endereco.Estado, c.Id)));

            CreateMap<EnderecoViewModel, IncluirEnderecoEventoCommand>()
                .ConstructUsing(e => new IncluirEnderecoEventoCommand(Guid.NewGuid(), e.Logradouro, e.Numero, e.Complemento, e.Bairro, e.Cep, e.Cidade, e.Estado, e.EventoId));

            CreateMap<EventoViewModel, AtualizarEventoCommand>()
                .ConstructUsing(c => new AtualizarEventoCommand(c.Id, c.Nome, c.DescricaoCurta, c.DescricaoLonga, c.DataInicio, c.DataFim, c.Gratuito, c.Valor, c.Online, c.NomeEmpresa, c.OrganizadorId, c.CategoriaId));

            CreateMap<EventoViewModel, ExcluirEventoCommand>()
                .ConstructUsing(c => new ExcluirEventoCommand(c.Id));

            //Endereço 

            CreateMap<EnderecoViewModel, IncluirEnderecoEventoCommand>()
                .ConstructUsing(c => new IncluirEnderecoEventoCommand(Guid.NewGuid(), c.Logradouro, c.Numero, c.Complemento, c.Bairro, c.Cep, c.Cidade, c.Estado, c.EventoId));

            CreateMap<EnderecoViewModel, AtualizarEnderecoEventoCommand>()
                .ConstructUsing(c => new AtualizarEnderecoEventoCommand(Guid.NewGuid(), c.Logradouro, c.Numero, c.Complemento, c.Bairro, c.Cep, c.Cidade, c.Estado, c.EventoId));

            // Organizador
            CreateMap<OrganizadorViewModel, RegistrarOrganizadorCommand>()
                .ConstructUsing(c => new RegistrarOrganizadorCommand(c.Id, c.Nome, c.Cpf, c.Email));
        }
    }
}