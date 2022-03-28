using ApplicationApp.Interfaces;
using ApplicationApp.OpenApp;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceCompra;
using Domain.Interfaces.InterfaceCompraUsuario;
using Domain.Interfaces.InterfaceLogSistema;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.InterfaceUsuario;
using Domain.Services;
using Infrastructure.Repository.Generics;
using Infrastructure.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HelpConfig
{
    public static class HelpStartup
    {

        public static void ConfigureSingleton(IServiceCollection services)
        {
            // INTERFACE E REPOSITORIO
            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
            services.AddSingleton<IProduct, RepositoryProduct>();
            services.AddSingleton<ICompraUsuario, RepositoryCompraUsuario>();
            services.AddSingleton<ICompra, RepositoryCompra>();
            services.AddSingleton<ILogSistema, RepositoryLogSistema>();
            services.AddSingleton<IUsuario, RepositoryUsuario>();

            // INTERFACE APLICAÇÃO
            services.AddSingleton<InterfaceProductApp, AppProduct>();
            services.AddSingleton<InterfaceCompraUsuarioApp, AppCompraUsuario>();
            services.AddSingleton<InterfaceCompraApp, AppCompra>();
            services.AddSingleton<InterfaceLogSistemaApp, AppLogSistema>();
            services.AddSingleton<InterfaceUsuarioApp, AppUsuario>();
            services.AddSingleton<InterfaceMontaMenu, AppMontaMenu>();

            // SERVIÇO DOMINIO
            services.AddSingleton<IServiceProduct, ServiceProduct>();
            services.AddSingleton<IServiceCompraUsuario, ServiceCompraUsuario>();
            services.AddSingleton<IServiceUsuario, ServiceUsuario>();
            services.AddSingleton<IServiceMontaMenu, ServiceMontaMenu>();
        }

    }
}
