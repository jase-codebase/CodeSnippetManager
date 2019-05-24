using Autofac;
using CodeSnippetManager.DataAccess;
using CodeSnippetManager.UI.Data;
using CodeSnippetManager.UI.Data.Lookups;
using CodeSnippetManager.UI.Data.Repositories;
using CodeSnippetManager.UI.ViewModels;
using CodeSnippetManager.UI.ViewModels.Services;
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

            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

            builder.RegisterType<CodeSnippetManagerWindow>().AsSelf();
            builder.RegisterType<CodeSnippetManagerViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<SnippetDetailViewModel>().As<ISnippetDetailViewModel>();

            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();
            builder.RegisterType<SnippetManagerRepository>().As<ISnippetManagerRepository>();

            return builder.Build();
        }
    }
}
