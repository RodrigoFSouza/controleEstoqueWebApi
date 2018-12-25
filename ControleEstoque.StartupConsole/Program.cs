using ControleEstoque.Domain.Models;
using ControleEstoque.Domain.Models.Base;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Domain.Repositories.Base;
using ControleEstoque.Domain.Service;
using ControleEstoque.Infra.Repositories;
using ControleEstoque.Infra.Repositories.Base;
using ControleEstoque.Startup;
using System;
using System.Globalization;
using System.Threading;
using Unity;

namespace ControleEstoque.StartupConsole
{
    class Program
    {
        private IUsuarioService _usuarioService  ;
        private IUnidadeMedidaRepository _unidadeRepo;

        static void Main(string[] args)
        {
            // Idioma
            CultureInfo ci = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            var container = new UnityContainer();
            DependencyResolver.Resolve(container);

            var service = container.Resolve<IUsuarioService>();
            try
            {
                service.Register("Joao da Silva", "joaodasilva@gmail.com", "teste123", "teste123");
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                service.Dispose();
            }

            Console.ReadKey();
        }
    }
}
