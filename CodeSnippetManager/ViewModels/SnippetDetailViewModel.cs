using CodeSnippetManager.DataAccess.Entities;
using CodeSnippetManager.UI.Data;
using CodeSnippetManager.UI.Event;
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
        private Snippet _snippet;

        public SnippetDetailViewModel(ISnippetManagerDataService snippetManagerDataService,
            IEventAggregator eventAggregator)
        {
            _snippetManagerDataService = snippetManagerDataService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<OpenCodeSnippetDetailViewEvent>()
                .Subscribe(OnOpenCodeSnippetDetailView);

            this.SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        public Snippet Snippet
        {
            get => _snippet;
            set => SetProperty(ref _snippet, value);
        }

        public ICommand SaveCommand { get; }

        private async void OnSaveExecute()
        {
            await _snippetManagerDataService.SaveAsync(this.Snippet);
            _eventAggregator.GetEvent<AfterSnippetSavedEvent>().Publish(
                new AfterSnippetSavedEventArgs
                {
                    Id = Snippet.Id,
                    DisplayMember = $"{Snippet.Language.Name}: {Snippet.Description}"
                });
        }

        private bool OnSaveCanExecute()
        {
            // TODO: Check if snippet is valid
            return true;
        }

        private async void OnOpenCodeSnippetDetailView(int snippetId)
        {
            await this.LoadAsync(snippetId);
        }

        public async Task LoadAsync(int snippetId)
        {
            this.Snippet = await _snippetManagerDataService.GetByIdAsync(snippetId);
        }

        
    }
}
