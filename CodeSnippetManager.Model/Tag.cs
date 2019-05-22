using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CodeSnippetManager.Model
{
    public class Tag
    {
        public Tag()
        {
            this.Snippets = new ObservableCollection<Snippet>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        public virtual ICollection<Snippet> Snippets { get; set; }
    }
}
