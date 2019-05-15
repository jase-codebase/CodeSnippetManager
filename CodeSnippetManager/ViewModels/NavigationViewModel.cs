using CodeSnippetManager.Model;
using CodeSnippetManager.UI.Data;
using CodeSnippetManager.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.ViewModels
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private ICodeSnippetLookupDataService _codeSnippetLookupDataService;
        private IEventAggregator _eventAggregator;

        public ObservableCollection<NavigationItemViewModel> Snippets { get; private set; }

        public NavigationViewModel(ICodeSnippetLookupDataService codeSnippetLookupDataService,
            IEventAggregator eventAggregator)
        {
            _codeSnippetLookupDataService = codeSnippetLookupDataService;
            Snippets = new ObservableCollection<NavigationItemViewModel>();

            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterSnippetSavedEvent>().Subscribe(AfterSnippetSaved);
        }

        private void AfterSnippetSaved(AfterSnippetSavedEventArgs args)
        {
            NavigationItemViewModel navigationItem = Snippets.Single(s => s.Id == args.Id);
            navigationItem.DisplayMember = args.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await _codeSnippetLookupDataService.GetCodeSnippetLookupAsync();
            Snippets.Clear();
            foreach (var item in lookup)
            {
                Snippets.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }

        private NavigationItemViewModel _selectedSnippet;

        public NavigationItemViewModel SelectedSnippet
        {
            get => _selectedSnippet;
            set
            {
                SetProperty(ref _selectedSnippet, value);
                if (_selectedSnippet != null)
                {
                    _eventAggregator.GetEvent<OpenCodeSnippetDetailViewEvent>()
                        .Publish(_selectedSnippet.Id);
                }
            }
        }

    }
}
