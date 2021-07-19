using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Integration.Mvc;
using PeopleCrud.Repositorios;
using PeopleCrud.Entity;
using Autofac;
using System.Reflection;
using System.Web.Mvc;
using PeopleCrud.Interfacez;
using PeopleCrud.Models;

namespace PeopleCrud.App_Start
{
}
public class IoCConfiguration
{
    public static void RegistrarControllers(ContainerBuilder builder)
    {
        builder.RegisterControllers
        (Assembly.GetExecutingAssembly());
    }

    public static void RegitrarClases(ContainerBuilder builder)
    {
        //Instacia de la base de datos
        builder.RegisterType<TaskTimeEntities>()
          .As<TaskTimeEntities>().InstancePerRequest();

        //Instacia del TaskRepository
        builder.RegisterType<TaskRepository>()
             .As<TaskRepository>().InstancePerRequest();
        //Instacia del TaskRepository
        builder.RegisterType<Answer>()
             .As<Answer>().InstancePerRequest();
    }
    public static void Configure()
    {
        ContainerBuilder builder = new ContainerBuilder();

        RegistrarControllers(builder);
        RegitrarClases(builder);

        IContainer contenedor = builder.Build();

        DependencyResolver.SetResolver
            (new AutofacDependencyResolver(contenedor));
    }
}