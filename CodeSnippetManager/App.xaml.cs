using Autofac;
using CodeSnippetManager.UI.Startup;
using System;
using System.Windows;
using System.Windows.Threading;

namespace CodeSnippetManager.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            IContainer container = bootstrapper.Bootstrap();

            CodeSnippetManagerWindow snippetManagerWindow = container.Resolve<CodeSnippetManagerWindow>();
            snippetManagerWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unexpected error occurred." + Environment.NewLine + e.Exception.Message, "Unexpected Error");
            e.Handled = true;
        }
    }
}
