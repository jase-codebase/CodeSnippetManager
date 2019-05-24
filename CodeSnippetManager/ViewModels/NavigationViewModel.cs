using CodeSnippetManager.UI.Data.Lookups;
using CodeSnippetManager.UI.Event;
using Prism.Events;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.ViewModels
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private readonly ICodeSnippetLookupDataService _codeSnippetLookupDataService;
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
                Snippets.Add(new NavigationItemViewModel(item.Id, item.DisplayMember, _eventAggregator));
            }
        }
    }
}
