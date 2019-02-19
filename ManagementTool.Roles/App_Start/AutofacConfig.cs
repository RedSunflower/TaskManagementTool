using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using ManagementTool.BLL;
using ManagementTool.DAL.Models;
using ManagementTool.DAL.Repository;
using ManagementTool.DAL.Repository.Interfaces;
using System.Web.Mvc;

namespace ManagementTool.Roles
{
    public class AutofacConfig
    {
      public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<TrackingTaskRepository>().As<ITrackingTaskRepository>().WithParameter("context",new ApplicationDbContext());
            builder.RegisterType<TrackingTaskBusinessLogic>().As<ITrackingTaskBusinessLogic>();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}