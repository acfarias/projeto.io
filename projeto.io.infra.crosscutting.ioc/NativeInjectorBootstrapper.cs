using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using projeto.io.domain.Clientes.Commands;
using projeto.io.domain.core.Notifications;
using projeto.io.domain.Handlers;
using projeto.io.domain.Interfaces;
using projeto.io.infra.data.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace projeto.io.infra.crosscutting.ioc
{
    public static class NativeInjectorBootstrapper
    {
        public static void RegistrarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<ContextoProjeto>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<CadastrarClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarClienteCommand, bool>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<ExcluirClienteCommand, bool>, ClienteCommandHandler>();

            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}
