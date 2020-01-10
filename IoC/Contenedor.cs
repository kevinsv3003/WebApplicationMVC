using Autofac;
using Autofac.Integration.Mvc;
using Datos.Contratos;
using Datos.Repositorios;
using Dominio.Contratos;
using Dominio.ReglasNegocio;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IoC
{
    public static class Contenedor
    {
        public static void RegistrarRepos(ContainerBuilder builder)
        {
            builder.RegisterType<ProductoRepositorio>()
                .As<IProducto>().InstancePerLifetimeScope();

            builder.RegisterType<CategoriaRepositorio>()
              .As<ICategoria>().InstancePerLifetimeScope();

            builder.RegisterType<MarcaRepositorio>()
              .As<IMarca>().InstancePerLifetimeScope();
        }

        public static void RegistrarModelo(ContainerBuilder builder)
        {
            builder.RegisterType<ProductoOperacion>()
                .As<IProductoDominio>().InstancePerLifetimeScope();

            builder.RegisterType<MarcaOperacion>()
                .As<IMarcaDominio>().InstancePerLifetimeScope();

            builder.RegisterType<CategoriaOperacion>()
                .As<ICategoriaDominio>().InstancePerLifetimeScope();
        }

        public static void RegitrarClases(ContainerBuilder builder)
        {
            builder.Register(z => new PruebaKsvEntities()).
                            InstancePerLifetimeScope();
        }

    }
}
