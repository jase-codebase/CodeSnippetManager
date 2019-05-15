using CodeSnippetManager.DataAccess.Entities;
using CodeSnippetManager.UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.ViewModels
{
    public class CodeSnippetManagerViewModel : ViewModelBase
    {

        public CodeSnippetManagerViewModel(INavigationViewModel navigationViewModel, 
            ISnippetDetailViewModel snippetDetailViewModel)
        {
            this.NavigationViewModel = navigationViewModel;
            this.SnippetDetailViewModel = snippetDetailViewModel;
        }

        public async Task LoadAsync()
        {
            await this.NavigationViewModel.LoadAsync();
        }

        public INavigationViewModel NavigationViewModel { get; }
        public ISnippetDetailViewModel SnippetDetailViewModel { get; }
    }
}
