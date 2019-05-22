using CodeSnippetManager.Model;
using CodeSnippetManager.UI.Data;
using CodeSnippetManager.UI.Event;
using CodeSnippetManager.UI.Wrapper;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodeSnippetManager.UI.ViewModels
{
    public class SnippetDetailViewModel : ViewModelBase, ISnippetDetailViewModel
    {
        private readonly ISnippetManagerDataService _snippetManagerDataService;
        private readonly IEventAggregator _eventAggregator;
        private SnippetWrapper _snippet;

        public SnippetDetailViewModel(ISnippetManagerDataService snippetManagerDataService,
            IEventAggregator eventAggregator)
        {
            _snippetManagerDataService = snippetManagerDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenCodeSnippetDetailViewEvent>()
                .Subscribe(OnOpenCodeSnippetDetailView);

            this.SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public SnippetWrapper Snippet
        {
            get => _snippet;
            set => SetProperty(ref _snippet, value);
        }

        public ICommand SaveCommand { get; }

        private async void OnSaveExecute()
        {
            await _snippetManagerDataService.SaveAsync(this.Snippet.Model);
            _eventAggregator.GetEvent<AfterSnippetSavedEvent>().Publish(
                new AfterSnippetSavedEventArgs
                {
                    Id = Snippet.Id,
                    DisplayMember = Snippet.Description
                });
        }

        private bool OnSaveCanExecute()
        {
            // TODO: Check if snippet is valid
            return this.Snippet != null && !this.Snippet.HasErrors;
        }

        private async void OnOpenCodeSnippetDetailView(int snippetId)
        {
            await this.LoadAsync(snippetId);
        }

        public async Task LoadAsync(int snippetId)
        {
            Snippet snippet = await _snippetManagerDataService.GetByIdAsync(snippetId);

            this.Snippet = new SnippetWrapper(snippet);
            this.Snippet.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(this.Snippet.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }


    }
}
