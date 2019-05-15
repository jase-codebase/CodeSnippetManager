using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.ViewModels
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;

        public NavigationItemViewModel(int id, string displayMember)
        {
            this.Id = id;
            DisplayMember = displayMember;
        }

        public int Id { get; }
        public string DisplayMember
        {
            get => _displayMember;
            set => SetProperty(ref _displayMember, value);
        }
    }
}
