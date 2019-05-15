using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CodeSnippetManager.DataAccess.Entities
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
        public string Name { get; set; }

        public ObservableCollection<Snippet> Snippets { get; set; }
    }
}
