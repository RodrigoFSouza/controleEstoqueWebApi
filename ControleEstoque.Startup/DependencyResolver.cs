
using ControleEstoque.App;
using ControleEstoque.Domain.Models;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Domain.Repositories.Base;
using ControleEstoque.Domain.Service;
using ControleEstoque.Infra.Data;
using ControleEstoque.Infra.Repositories;
using ControleEstoque.Infra.Repositories.Base;
using Unity;
using Unity.Lifetime;

namespace ControleEstoque.Startup
{
    public static class DependencyResolver
    {
        public static void Resolve(UnityContainer container)
        {
            container.RegisterType<ControleEstoqueContext, ControleEstoqueContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepository, UsuarioRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnidadeMedidaRepository, UnidadeMedidaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioService, UsuarioService>(new HierarchicalLifetimeManager());
        }
    }
}
