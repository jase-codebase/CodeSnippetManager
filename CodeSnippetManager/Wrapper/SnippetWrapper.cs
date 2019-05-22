using CodeSnippetManager.Model;
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
    public class SnippetWrapper : ModelWrapper<Snippet>
    {
        public SnippetWrapper(Snippet model) : base(model) { }

        public int Id { get { return this.Model.Id; } }

        public Language Language
        {
            get => GetValue<Language>();
            set => SetValue(value);
        }

        public string Description
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Text
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public ICollection<Tag> Tags
        {
            get => GetValue<ICollection<Tag>>();
            set => SetValue(value);
        }

        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(this.Description):
                    if (String.IsNullOrWhiteSpace(this.Description))
                    {
                        yield return "The snippet description cannot be blank.";
                    }
                    break;
                case nameof(this.Text):
                    if (string.IsNullOrWhiteSpace(this.Text))
                    {
                        yield return "The snippet code text cannot be blank.";
                    }
                    break;
            }
        }
    }
}
