using Autofac;
using CodeSnippetManager.DataAccess;
using CodeSnippetManager.UI.Data;
using CodeSnippetManager.UI.ViewModels;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<CodeSnippetManagerContext>().AsSelf();

            builder.RegisterType<CodeSnippetManagerWindow>().AsSelf();
            builder.RegisterType<CodeSnippetManagerViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<SnippetDetailViewModel>().As<ISnippetDetailViewModel>();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<SnippetManagerDataService>().As<ISnippetManagerDataService>();

            return builder.Build();
        }
    }
}
