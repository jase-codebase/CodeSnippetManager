using CodeSnippetManager.Data;
using CodeSnippetManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CodeSnippetManager.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CodeSnippetManagerWindow : Window
    {
        private CodeSnippetManagerViewModel _codeSnippetManagerViewModel;

        public CodeSnippetManagerWindow(CodeSnippetManagerViewModel codeSnippetManagerViewModel)
        {
            InitializeComponent();
            _codeSnippetManagerViewModel = codeSnippetManagerViewModel;
            DataContext = _codeSnippetManagerViewModel;
            this.Loaded += this.CodeSnippetManagerWindow_Loaded;
            this.Closing += this.CodeSnippetManagerWindow_Closing;
        }

        private void CodeSnippetManagerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private async void CodeSnippetManagerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _codeSnippetManagerViewModel.LoadAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //SeedFirstSnippet();
            //SeedLanguages();
            //CodeSnippetManagerContext ctx = new CodeSnippetManagerContext();
            //List<Language> languages = ctx.Languages.ToList<Language>();
            //this.cboLanguages.ItemsSource = languages;
            //MessageBox.Show(languages[0].Name);
        }
    }
}
