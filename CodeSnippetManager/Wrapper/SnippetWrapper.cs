using CodeSnippetManager.DataAccess.Entities;
using CodeSnippetManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.Wrapper
{
    public class SnippetWrapper : ViewModelBase
    {
        private string _description;

        public SnippetWrapper(Snippet model)
        {
            Model = model;
            _description = this.Model.Language.Name + ": " + this.Model.Description;
        }

        public Snippet Model { get; }

        public int Id { get { return this.Model.Id; } }

        public string Description
        {
            get => $"{this.Model.Language.Name}: {this.Model.Description}";
            set
            {
                this.Model.Description = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get => this.Model.Text;
            set
            {
                this.Model.Text = value;
                OnPropertyChanged();
            }
        }
    }
}
