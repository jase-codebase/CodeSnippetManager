using CodeSnippetManager.DataAccess.Entities;
using CodeSnippetManager.UI.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippetManager.UI.Wrapper
{
    public class SnippetWrapper : ViewModelBase, INotifyDataErrorInfo
    {
        public SnippetWrapper(Snippet model)
        {
            Model = model;
        }

        public Snippet Model { get; }

        public int Id { get { return this.Model.Id; } }

        public Language Language
        {
            get => this.Model.Language;
            set
            {
                this.Model.Language = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Language));
            }
        }

        public string Description
        {
            get => this.Model.Description;
            set
            {
                this.Model.Description = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Description));
            }
        }

        public string Text
        {
            get => this.Model.Text;
            set
            {
                this.Model.Text = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Text));
            }
        }

        public ICollection<Tag> Tags
        {
            get => this.Model.Tags;
            set
            {
                this.Model.Tags = value;
                OnPropertyChanged();
                ValidateProperty(nameof(Tags));
            }
        }

        private void ValidateProperty(string propertyName)
        {
            this.ClearErrors(propertyName);
            switch (propertyName)
            {
                case nameof(this.Description):
                    if (String.IsNullOrWhiteSpace(this.Description))
                    {
                        this.AddError(propertyName, "The snippet description cannot be blank.");
                    }
                    break;
            }
        }

        private Dictionary<string, List<string>> _errorsByPropertyName =
            new Dictionary<string, List<string>>();

        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsByPropertyName.ContainsKey(propertyName)
                ? _errorsByPropertyName[propertyName]
                : null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName] = new List<string>();
            }

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
    }
}
