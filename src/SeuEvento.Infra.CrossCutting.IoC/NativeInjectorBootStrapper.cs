using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SeuEvento.Application.Interfaces;
using SeuEvento.Application.Services;
using SeuEvento.Domain.Core.Bus;
using SeuEvento.Domain.Core.Events;
using SeuEvento.Domain.Core.Notifications;
using SeuEvento.Domain.Eventos.Commands;
using SeuEvento.Domain.Eventos.Events;
using SeuEvento.Domain.Eventos.Repository;
using SeuEvento.Domain.Interfaces;
using SeuEvento.Domain.Organizadores.Commands;
using SeuEvento.Domain.Organizadores.Events;
using SeuEvento.Domain.Organizadores.Repository;
using SeuEvento.Infra.CrossCutting.AspNetFilters;
using SeuEvento.Infra.CrossCutting.Bus;
using SeuEvento.Infra.CrossCutting.Identity.Models;
using SeuEvento.Infra.CrossCutting.Identity.Services;
using SeuEvento.Infra.Data.Context;
using SeuEvento.Infra.Data.Repository;
using SeuEvento.Infra.Data.UoW;

namespace SeuEvento.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(serviceProvider => new Mapper(serviceProvider.GetRequiredService<IConfigurationProvider>(), serviceProvider.GetService));
            services.AddScoped<IEventoAppService, EventoAppService>();
            services.AddScoped<IOrganizadorAppService, OrganizadorAppService>();

            // Domain - Commands
            services.AddScoped<IHandler<RegistrarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<ExcluirEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<AtualizarEnderecoEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<IncluirEnderecoEventoCommand>, EventoCommandHandler>();
            services.AddScoped<IHandler<RegistrarOrganizadorCommand>, OrganizadorCommandHandler>();

            // Domain - Eventos
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<EventoRegistradoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoAtualizadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EventoExcluidoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EnderecoEventoAtualizadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<EnderecoEventoAdicionadoEvent>, EventoEventHandler>();
            services.AddScoped<IHandler<OrganizadorRegistradoEvent>, OrganizadorEventHandler>();

            // Infra - Data
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IOrganizadorRepository, OrganizadorRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<EventosContext>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();

            // Infra - Identity
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddScoped<IUser, AspNetUser>();

            // Infra - Filtros
            services.AddScoped<ILogger<GlobalExceptionHandlingFilter>, Logger<GlobalExceptionHandlingFilter>>();
            services.AddScoped<ILogger<GlobalActionLogger>, Logger<GlobalActionLogger>>();
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddScoped<GlobalActionLogger>();
        }
    }
}
