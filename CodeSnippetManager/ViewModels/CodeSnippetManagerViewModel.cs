using CodeSnippetManager.UI.Event;
using CodeSnippetManager.UI.ViewModels.Services;
using Prism.Events;
using System;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.ViewModels
{
    public class CodeSnippetManagerViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private Func<ISnippetDetailViewModel> _snippetDetailViewModelCreator;
        private IMessageDialogService _messageDialogService;
        private ISnippetDetailViewModel _snippetDetailViewModel;

        public CodeSnippetManagerViewModel(INavigationViewModel navigationViewModel,
            Func<ISnippetDetailViewModel> snippetDetailViewModelCreator,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _eventAggregator = eventAggregator;
            _snippetDetailViewModelCreator = snippetDetailViewModelCreator;
            _messageDialogService = messageDialogService;

            _eventAggregator.GetEvent<OpenCodeSnippetDetailViewEvent>()
                .Subscribe(OnOpenCodeSnippetDetailView);

            this.NavigationViewModel = navigationViewModel;
        }

        public INavigationViewModel NavigationViewModel { get; }

        public ISnippetDetailViewModel SnippetDetailViewModel
        {
            get { return _snippetDetailViewModel; }
            private set
            {
                _snippetDetailViewModel = value;
                OnPropertyChanged();
            }

        }

        public async Task LoadAsync()
        {
            await this.NavigationViewModel.LoadAsync();
        }

        private async void OnOpenCodeSnippetDetailView(int snippetId)
        {
            if (this.SnippetDetailViewModel != null && this.SnippetDetailViewModel.HasChanges)
            {
                MessageDialogResult result = _messageDialogService.ShowYesNoDialog("You made changes.  Are you sure you want to navigate away before saving?",
                    "Confirmation");
                if (result == MessageDialogResult.No) return;
            }
            this.SnippetDetailViewModel = _snippetDetailViewModelCreator();
            await this.SnippetDetailViewModel.LoadAsync(snippetId);
        }

        
    }
}
