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
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private IEventAggregator _eventAggregator;

        public NavigationItemViewModel(int id, string displayMember, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            this.Id = id;
            DisplayMember = displayMember;
            this.OpenSnippetDetailViewCommand = new DelegateCommand(OnOpenFriendDetailView);
        }

        public int Id { get; }

        public string DisplayMember
        {
            get => _displayMember;
            set => SetProperty(ref _displayMember, value);
        }

        public ICommand OpenSnippetDetailViewCommand { get; }

        private void OnOpenFriendDetailView()
        {
            _eventAggregator.GetEvent<OpenCodeSnippetDetailViewEvent>()
                        .Publish(this.Id);
        }
    }
}
