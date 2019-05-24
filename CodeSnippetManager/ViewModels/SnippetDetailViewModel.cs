using CodeSnippetManager.Model;
using CodeSnippetManager.UI.Data.Repositories;
using CodeSnippetManager.UI.Event;
using CodeSnippetManager.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodeSnippetManager.UI.ViewModels
{
    public class SnippetDetailViewModel : ViewModelBase, ISnippetDetailViewModel
    {
        private readonly ISnippetManagerRepository _snippetManagerRepository;
        private readonly IEventAggregator _eventAggregator;
        private SnippetWrapper _snippet;
        private bool _hasChanges;

        public SnippetDetailViewModel(ISnippetManagerRepository snippetManagerRepository,
            IEventAggregator eventAggregator)
        {
            _snippetManagerRepository = snippetManagerRepository;
            _eventAggregator = eventAggregator;

            this.SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public SnippetWrapper Snippet
        {
            get => _snippet;
            set => SetProperty(ref _snippet, value);
        }

        public bool HasChanges
        {
            get { return _hasChanges; }
            set
            {
                if (SetProperty(ref _hasChanges, value))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }


        public ICommand SaveCommand { get; }

        private async void OnSaveExecute()
        {
            await _snippetManagerRepository.SaveAsync();
            this.HasChanges = _snippetManagerRepository.HasChanges();
            _eventAggregator.GetEvent<AfterSnippetSavedEvent>().Publish(
                new AfterSnippetSavedEventArgs
                {
                    Id = Snippet.Id,
                    DisplayMember = Snippet.Description
                });
        }

        private bool OnSaveCanExecute()
        {
            return this.Snippet != null
                && !this.Snippet.HasErrors
                && this.HasChanges;
        }

        public async Task LoadAsync(int snippetId)
        {
            Snippet snippet = await _snippetManagerRepository.GetByIdAsync(snippetId);

            this.Snippet = new SnippetWrapper(snippet);
            this.Snippet.PropertyChanged += (s, e) =>
            {
                if (!this.HasChanges)
                {
                    this.HasChanges = _snippetManagerRepository.HasChanges();
                }
                if (e.PropertyName == nameof(this.Snippet.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }
    }
}
